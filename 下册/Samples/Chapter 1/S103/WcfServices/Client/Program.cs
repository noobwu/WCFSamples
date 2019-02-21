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
                    int result = calculator.Divide(1, 0);
                }
            }
        }
    }
}
