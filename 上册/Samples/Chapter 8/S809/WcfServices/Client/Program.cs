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
            try
            {
                using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
                {
                    ICalculator calculator = channelFactory.CreateChannel();
                    Invoke(proxy => proxy.Divide(1, 0), calculator);
                    Invoke(proxy => proxy.Add(1, 0), calculator);
                    Invoke(proxy => proxy.Subtract(1, 0), calculator);
                    Invoke(proxy => proxy.Multiply(1, 0), calculator);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("抛出异常: {0}", ex.Message);
            }

            Console.Read();
        }

        static void Invoke(Action<ICalculator> action, ICalculator calculator)
        {
            try
            {
                action(calculator);
                Console.WriteLine("服务调用成功！");
            }
            catch (Exception ex)
            {
                Console.WriteLine("抛出异常: {0}", ex.Message);
            }
        }
    }

}