using System;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Channels;
namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorService"))
            {
                ICalculator proxy = channelFactory.CreateChannel();
                Console.WriteLine("x + y = {2} when x = {0} and y = {1}",1,2, proxy.Add(1,2));              
            }
            Console.Read();
        }
    }
}


