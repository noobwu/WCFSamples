using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel;
using System.Net;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorService");
            NetworkCredential credential = channelFactory.Credentials.Windows.ClientCredential;
            credential.UserName = "Foo";
            credential.Password = "Password";
            ICalculator calculator = channelFactory.CreateChannel();
            Invoke(calculator);

            channelFactory = new ChannelFactory<ICalculator>("calculatorService");
            credential = channelFactory.Credentials.Windows.ClientCredential;
            credential.UserName = "Bar";
            credential.Password = "InvalidPass";
            calculator = channelFactory.CreateChannel();
            Invoke(calculator);

            Console.Read();
        }

        static void Invoke(ICalculator calculator)
        {
            try
            {
                calculator.Add(1, 2);
                Console.WriteLine("服务调用成功...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("服务调用失败...");
            }
        }

    }
}
