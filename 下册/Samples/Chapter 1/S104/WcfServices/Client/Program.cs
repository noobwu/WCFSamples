using System;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Clients
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
            {
                ICalculator calculator = channelFactory.CreateChannel();
                using (calculator as IDisposable)
                {
                    try
                    {
                        int result = calculator.Divide(1, 0);
                    }
                    catch (FaultException<CalculationError> ex)
                    {
                        Console.WriteLine("运算错误");
                        Console.WriteLine("运算操作：{0}", ex.Detail.Operation);
                        Console.WriteLine("错误消息: {0}", ex.Detail.Message);
                        (calculator as ICommunicationObject).Abort();
                    }
                }                
            }
            Console.Read();

        }
    }
}
