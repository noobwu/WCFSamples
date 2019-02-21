using System;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Channels;
using System.Net;
namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string securityToke = Guid.NewGuid().ToString();
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
            {
                ICalculator proxy = channelFactory.CreateChannel();
                using (OperationContextScope contextScope = new OperationContextScope(proxy as IContextChannel))
                {
                    HttpRequestMessageProperty messageProperty;
                    if (OperationContext.Current.OutgoingMessageProperties.ContainsKey(HttpRequestMessageProperty.Name))
                    {
                        messageProperty = (HttpRequestMessageProperty)OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name];
                    }
                    else
                    {
                        messageProperty = new HttpRequestMessageProperty();
                        OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, messageProperty);
                    }
                    messageProperty.Headers.Add(HttpRequestHeader.Cookie, "SecurityToken=" + securityToke);
                    proxy.Add(1, 2);
                }
            }
            Console.Read();
        }
    }
}
