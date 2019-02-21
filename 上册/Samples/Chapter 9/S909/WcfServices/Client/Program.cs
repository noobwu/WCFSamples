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
                ICalculator calculator = channelFactory.CreateChannel();
                calculator.Reset();
                calculator.Add(100);
                Console.WriteLine("计算结果: {0}", calculator.GetResult());

                calculator.Reset();
                calculator.Add(200);
                Console.WriteLine("计算结果: {0}", calculator.GetResult());
            }
        }
    }
}