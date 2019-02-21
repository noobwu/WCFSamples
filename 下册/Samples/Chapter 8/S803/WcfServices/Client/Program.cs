using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Net;
using Artech.WcfServices.Service.Interface;

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
            NetworkCredential credential = channelFactory.Credentials.Windows.ClientCredential;
            credential.UserName = "Foo";
            credential.Password = "Password";
            ICalculator calculator = channelFactory.CreateChannel();
            Invoke(calculator);

            channelFactory = new ChannelFactory<ICalculator>("calculatorService");
            credential = channelFactory.Credentials.Windows.ClientCredential;
            credential.UserName = "Bar";
            credential.Password = "Password";
            calculator = channelFactory.CreateChannel();
            Invoke(calculator);
        }
    }
}
