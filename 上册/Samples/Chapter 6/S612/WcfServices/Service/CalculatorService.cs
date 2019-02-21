using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Artech.WcfServices.Service.Interface;
using System.Diagnostics;
namespace Artech.WcfServices.Service
{
    public class CalculatorService : ICalculator
    {
        public double Add(double x, double y)
        {
            Console.WriteLine("接收到来自客户端的上下文");
            foreach (var item in ApplicationContext.Current)
            {
                Console.WriteLine("{0,-3}: {1}", item.Key, item.Value);
            }
            return x + y;
        }
    }
}