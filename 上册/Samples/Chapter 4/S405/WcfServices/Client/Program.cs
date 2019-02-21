using System;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Channels;
using System.Threading;
namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            InstanceContext callback = new InstanceContext(new CalculatorCallbackService());
            using (DuplexChannelFactory<ICalculator> channelFactory = new DuplexChannelFactory<ICalculator>(callback, "calculatorservice"))
            {
                ICalculator calculator = channelFactory.CreateChannel();
                calculator.Add(1, 2);
                Console.Read();
            }
        }
    }
}
