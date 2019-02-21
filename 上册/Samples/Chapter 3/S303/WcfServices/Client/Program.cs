using System;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Channels;
namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress address = new EndpointAddress("net.tcp://127.0.0.1:3721/calculatorservice");
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>(new SimpleSessionBinding(), address))
            {
                //创建第一个服务代理
                ICalculator proxy = channelFactory.CreateChannel();
                proxy.Add(1, 2);
                Console.WriteLine("Done");
                proxy.Add(1, 2);
                Console.WriteLine("Done");
                (proxy as ICommunicationObject).Close();

                //创建第二个服务代理
                proxy = channelFactory.CreateChannel();
                proxy.Add(1, 2);
                Console.WriteLine("Done");
                proxy.Add(1, 2);
                Console.WriteLine("Done");
                (proxy as ICommunicationObject).Close();

                channelFactory.Close();
            }
            Console.Read();
        }
    }
}
