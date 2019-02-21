using System;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel;
using System.Threading;

namespace Artech.WcfServices.Client
{
    class Program
    {
        static int index;
        static void Main(string[] args)
        {
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
            {
                for (int i = 0; i < 5; i++)
                {
                    ICommunicationObject proxy = (ICommunicationObject)channelFactory.CreateChannel();
                    proxy.Open();
                    proxy.Closed += (sender, arg) =>
                        {
                            Console.WriteLine("第{0}个服务代理被关闭", Interlocked.Add(ref index, 1));
                        };
                }
            }
            Console.Read();
        }
    }
}