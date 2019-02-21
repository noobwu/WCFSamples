using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.Xml;
using System.Net;
using System.Reflection;

namespace Artech.WcfServices.Client
{
public class ServiceChannelProxy<TChannel>: RealProxy
{
    public Uri Address { get; private set; }
    public MessageVersion MessageVersion { get; private set; }
    public IDictionary<string, IClientMessageFormatter> MessageFormatters { get; private set; }
    public MessageEncoderFactory MessageEncoderFactory { get; private set; }

    public ServiceChannelProxy(Uri address, MessageVersion messageVersion, MessageEncoderFactory encoderFactory): base(typeof(TChannel))
    {
        this.Address = address;
        this.MessageVersion = messageVersion;
        this.MessageEncoderFactory = encoderFactory;
        this.MessageFormatters = new Dictionary<string, IClientMessageFormatter>();
    }

    public override IMessage Invoke(IMessage msg)
    {
        IMethodCallMessage methodCall = (IMethodCallMessage)msg;
            
        //得到操作名称
        object[] attributes = methodCall.MethodBase.GetCustomAttributes(typeof(OperationContractAttribute), true);           
        OperationContractAttribute attribute = (OperationContractAttribute)attributes[0];
        string operationName = string.IsNullOrEmpty(attribute.Name) ? methodCall.MethodName : attribute.Name;
            
        //序列化请求消息
        Message requestMessage = this.MessageFormatters[operationName].SerializeRequest(this.MessageVersion, methodCall.InArgs);

        //添加必要的WS-Address报头
        EndpointAddress address = new EndpointAddress(this.Address);
        requestMessage.Headers.MessageId = new UniqueId(Guid.NewGuid());
        requestMessage.Headers.ReplyTo = new EndpointAddress("http://www.w3.org/2005/08/addressing/anonymous");
        address.ApplyTo(requestMessage);

        //对请求消息进行编码，并将编码生成的字节发送通过HttpWebRequest向服务端发送
        HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(this.Address);
        webRequest.Method = "Post";
        webRequest.KeepAlive = true;
        webRequest.ContentType = "application/soap+xml; charset=utf-8";
        ArraySegment<byte> bytes = this.MessageEncoderFactory.Encoder.WriteMessage(requestMessage, int.MaxValue, BufferManager.CreateBufferManager(long.MaxValue, int.MaxValue));
        webRequest.ContentLength = bytes.Array.Length;
        webRequest.GetRequestStream().Write(bytes.Array, 0, bytes.Array.Length);
        webRequest.GetRequestStream().Close();
        WebResponse webResponse = webRequest.GetResponse();

        //对HttpResponse进行解码生成回复消息.
        Message responseMessage = this.MessageEncoderFactory.Encoder.ReadMessage(webResponse.GetResponseStream(), int.MaxValue);
            
        //回复消息进行反列化生成相应的对象，并映射为方法调用的返回值或者ref/out参数
        object[] allArgs = (object[])Array.CreateInstance(typeof(object),methodCall.ArgCount);
        Array.Copy(methodCall.Args, allArgs, methodCall.ArgCount);
        object[] refOutParameters = new object[GetRefOutParameterCount(methodCall.MethodBase)];            
        object returnValue = this.MessageFormatters[operationName].DeserializeReply(responseMessage, refOutParameters);
        MapRefOutParameter(methodCall.MethodBase, allArgs, refOutParameters);

        //通过ReturnMessage的形式将返回值和ref/out参数返回
        return new ReturnMessage(returnValue, allArgs, allArgs.Length, methodCall.LogicalCallContext, methodCall);
    }

    private int GetRefOutParameterCount(MethodBase method)
    {
        int count = 0;
        foreach (ParameterInfo parameter in method.GetParameters())
        {
            if (parameter.IsOut || parameter.ParameterType.IsByRef)
            {
                count++;
            }
        }
        return count;
    }

    private void MapRefOutParameter(MethodBase method, object[] allArgs,object[] refOutArgs)
    {
        List<int> refOutParamPositionsList = new List<int>();
        foreach (ParameterInfo parameter in method.GetParameters())
        {
            if (parameter.IsOut || parameter.ParameterType.IsByRef)
            {
                refOutParamPositionsList.Add(parameter.Position);
            }
        }
        int[] refOutParamPositionArray = refOutParamPositionsList.ToArray();
        for (int i = 0; i < refOutArgs.Length; i++)
        {
            allArgs[refOutParamPositionArray[i]] = refOutArgs[i];
        }
    }
}
}
