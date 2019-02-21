using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Security;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorService"))
            {
                UserNamePasswordClientCredential credential =
                  channelFactory.Credentials.UserName;
                credential.UserName = "Zhansan";
                credential.Password = "Pass@word";
                ICalculator calculator = channelFactory.CreateChannel();
                calculator.Add(1, 2);
                Console.WriteLine("服务调用成功...");
            }
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorService"))
            {
                UserNamePasswordClientCredential credential =
                    channelFactory.Credentials.UserName;
                credential.UserName = "lisi";
                credential.Password = "Pass@word";
                ICalculator calculator = channelFactory.CreateChannel();
                try
                {
                    calculator.Add(1, 2);
                }
                catch
                {
                    Console.WriteLine("服务调用失败...");
                }
            }
        }
    }
}
