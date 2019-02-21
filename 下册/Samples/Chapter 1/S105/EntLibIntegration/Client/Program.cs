using System;
using System.ServiceModel;
using Artech.EntLibIntegration.Service.Interface;
using Artech.EntLibIntegration;
namespace Artech.WcfServices.Client
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
                    catch (Exception ex)
                    {
                        if (ExceptionHelper.HandleException(ex, "client policy"))
                        {
                            throw;
                        }
                           
                    }
                }
            }
            Console.Read();
        }
    }
}