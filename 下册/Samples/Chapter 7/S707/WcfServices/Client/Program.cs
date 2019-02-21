using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorService"))
{
    channelFactory.Credentials.UserName.UserName = "Foo";
    channelFactory.Credentials.UserName.Password = "Password";
    ICalculator calculator = channelFactory.CreateChannel();
    calculator.Add(1, 2);
    calculator.Add(1, 2);
    calculator.Add(1, 2);
}
            Console.Read();
        }
    }
}
