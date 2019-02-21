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
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
            {
                ICalculator calclator = channelFactory.CreateChannel();
                Console.WriteLine("初始值为: {0}", calclator.GetResult());

                calclator.Add(3);
                Console.WriteLine("加上3;运算结果为: {0}", calclator.GetResult());

                calclator.Subtract(2);
                Console.WriteLine("减去2;运算结果为: {0}", calclator.GetResult());

                calclator.Multiply(4);
                Console.WriteLine("乘以4;运算结果为: {0}", calclator.GetResult());

                calclator.Divide(2);
                Console.WriteLine("除以2;运算结果为: {0}", calclator.GetResult());
            }
            Console.Read();
        }
    }
}
