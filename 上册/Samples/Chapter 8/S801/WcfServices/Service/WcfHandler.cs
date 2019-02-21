using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Web;

namespace Artech.WcfServices.Service
{
public class WcfHandler: IHttpHandler
{
    public Type ServiceType { get; private set; }
    public MessageEncoderFactory MessageEncoderFactory { get; private set; }
    public IDictionary<string, MethodInfo> Methods { get; private set; }
    public IDictionary<string, IDispatchMessageFormatter> MessageFormatters { get; private set; }
    public IDictionary<string, IOperationInvoker> OperationInvokers { get; private set; } 

    public bool IsReusable
    {
        get { return false; }
    }

    public WcfHandler(Type serviceType, MessageEncoderFactory messageEncoderFactory)
    {
        this.ServiceType = serviceType;
        this.MessageEncoderFactory = messageEncoderFactory;
        this.Methods = new Dictionary<string, MethodInfo>();
        this.MessageFormatters = new Dictionary<string, IDispatchMessageFormatter>();
        this.OperationInvokers = new Dictionary<string, IOperationInvoker>();            
    }

    public void ProcessRequest(HttpContext context)
    {
        //对HttpPRequest进行解码生成请求消息对象
        Message request = this.MessageEncoderFactory.Encoder.ReadMessage(context.Request.InputStream, int.MaxValue, "application/soap+xml; charset=utf-8");

        //通过请求消息得到代表服务操作的Action
        string action = request.Headers.Action;

        //通过Action从MethodInfo字典中获取服务操作对应的MethodInfo对象
        MethodInfo method = this.Methods[action];

        //得到输出参数的数量
        int outArgsCount = 0;
        foreach (var parameter in method.GetParameters())
        {
            if (parameter.IsOut)
            {
                outArgsCount++;
            }
        }

        //创建数组容器，用于保存请求消息反序列后生成的输入参数对象
        int inputArgsCount = method.GetParameters().Length - outArgsCount;
        object[] parameters = new object[inputArgsCount];
        try
        {
            this.MessageFormatters[action].DeserializeRequest(request, parameters);
        }
        catch
        {}

        List<object> inputArgs = new List<object>();
        object[] outArgs = new object[outArgsCount];
        //创建服务对象，在WCF中服务对象通过InstanceProvider创建

        object serviceInstance = Activator.CreateInstance(this.ServiceType);

        //执行服务操作
        object result = this.OperationInvokers[action].Invoke(serviceInstance,parameters, out outArgs);

        //将操作执行的结果（返回值或者输出参数）序列化生成回复消息
        Message reply = this.MessageFormatters[action].SerializeReply(request.Version, outArgs, result);
        context.Response.ClearContent();
        context.Response.ContentEncoding = Encoding.UTF8;
        context.Response.ContentType = "application/soap+xml; charset=utf-8";

        //对回复消息进行编码，并将编码后的消息通过HttpResponse返回
        this.MessageEncoderFactory.Encoder.WriteMessage(reply, context.Response.OutputStream);
        context.Response.Flush();

    }
}
}