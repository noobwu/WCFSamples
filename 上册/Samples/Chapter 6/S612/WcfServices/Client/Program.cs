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
using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
{
    ICalculator proxy = channelFactory.CreateChannel();
    using(ApplicationContextScope appContextScope = new ApplicationContextScope())
    using (OperationContextScope opContextScope = new OperationContextScope(proxy as IContextChannel))
    {
        ApplicationContext.Current.Add("Foo", "ABC");
        ApplicationContext.Current.Add("Bar", "abc");
        ApplicationContext.Current.Add("Baz", "123");
        OperationContext.Current.AttachApplicationContext();
        proxy.Add(1, 2);
    }
}
            Console.Read();
        }
    }
}
