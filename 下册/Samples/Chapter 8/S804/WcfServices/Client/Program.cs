using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Net;
using Artech.WcfServices.Service.Interface;
using System.Security.Cryptography.X509Certificates;

namespace Client
{
    class Program
    {
        static void Invoke(ICalculator calculator)
        {
            try
            {
                calculator.Add(1, 2);
                Console.WriteLine("服务调用成功...");
            }
            catch
            {
                Console.WriteLine("服务调用失败...");
            }
        }

        static void Main(string[] args)
        {
            ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorService");
            channelFactory.Credentials.ClientCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, "Foo");
            ICalculator calculator = channelFactory.CreateChannel();
            Invoke(calculator);

            channelFactory = new ChannelFactory<ICalculator>("calculatorService");
            channelFactory.Credentials.ClientCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, "Bar");
            calculator = channelFactory.CreateChannel();
            Invoke(calculator);

        }
    }
}
