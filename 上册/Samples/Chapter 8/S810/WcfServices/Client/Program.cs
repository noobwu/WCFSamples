using System;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel;
using System.Threading;
using System.Reflection;
using System.ServiceModel.Channels;

namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                ServiceProxy<ICalculator> serviceProxy = new ServiceProxy<ICalculator>("calculatorservice");
                serviceProxy.Channel.Add(1, 2);
                Console.WriteLine("第{0}个服务代理调用成功！", i + 1);
            }
            Console.Read();
        }
    }
}