using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;

namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
using(ServiceHost host = new ServiceHost(typeof(TraceService)))
using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
{
    host.Open();
    ICalculator calculator = channelFactory.CreateChannel();
    calculator.Add(1,2);
}
Console.Read();
        }
    }
}
