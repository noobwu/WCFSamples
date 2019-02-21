using System;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel;
using System.Threading;
using System.Reflection;
using System.ServiceModel.Channels;

namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorClient client1 = new CalculatorClient("calculatorservice");
            client1.Open();
            CalculatorClient client2 = new CalculatorClient("calculatorservice");
            client2.Open();

            client1.Close();
            client2.Close();

            Console.WriteLine("ChannelFactory的状态: {0}", client1.ChannelFactory.State);
            Console.WriteLine("ChannelFactory的状态: {0}\n", client2.ChannelFactory.State);

            EndpointAddress address = new EndpointAddress("http://127.0.0.1:3721/calculatorservice");
            Binding binding = new WS2007HttpBinding();

            CalculatorClient client3 = new CalculatorClient(binding, address);
            client3.Open();
            CalculatorClient client4 = new CalculatorClient(binding, address);
            client4.Open();

            client3.Close();
            client4.Close();

            Console.WriteLine("ChannelFactory的状态: {0}", client3.ChannelFactory.State);
            Console.WriteLine("ChannelFactory的状态: {0}", client4.ChannelFactory.State);

            Console.Read();
        }
    }

}