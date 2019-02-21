using System;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel;

namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
            {
                bool stop = false;
                for (int i = 0; i < 1000 && !stop; i++)
                {
                    ICalculator calcultor = channelFactory.CreateChannel();
                    try
                    {
                        calcultor.Add(1, 2);
                        (calcultor as ICommunicationObject).Close();
                        Console.WriteLine("第{0}个服务代理调用成功！", i + 1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("出现异常：{0}", ex.Message);
                        stop = true;
                    }
                }
                Console.Read();
            }
        }
    }
}