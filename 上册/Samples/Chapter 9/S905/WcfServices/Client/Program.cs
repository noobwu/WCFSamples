using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.Runtime.Remoting;
using System.Diagnostics;
using System.Threading;

namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
{
    ICalculator serviceProxy1 = channelFactory.CreateChannel();               
    ICalculator serviceProxy2 = channelFactory.CreateChannel();
    ICalculator serviceProxy3 = channelFactory.CreateChannel();
    ICalculator serviceProxy4 = channelFactory.CreateChannel();
    ICalculator serviceProxy5 = channelFactory.CreateChannel();

    Action<ICalculator> serviceInvocation = serviceProxy =>
        {
            ThreadPool.QueueUserWorkItem(state => serviceProxy.Add(1, 2));
        };

    serviceInvocation(serviceProxy1);
    serviceInvocation(serviceProxy2);
    serviceInvocation(serviceProxy3);
    serviceInvocation(serviceProxy4);
    serviceInvocation(serviceProxy5);
    Console.Read();
}
            Console.Read();
        }
    }
}



 





