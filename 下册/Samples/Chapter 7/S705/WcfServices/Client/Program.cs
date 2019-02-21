using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.Net;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorService"))
            {
                ICalculator calculator = channelFactory.CreateChannel();
                Console.WriteLine("x + y = {2} when x = {0} and y = {1}", 1, 2, calculator.Add(1, 2)); ;
            }
            Console.Read();
        }
    }
}
