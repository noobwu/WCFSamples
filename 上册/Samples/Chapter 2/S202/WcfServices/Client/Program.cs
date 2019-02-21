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
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
            {
                ICalculator calculator = channelFactory.CreateChannel();
                using (OperationContextScope contextScope = new OperationContextScope(calculator as IClientChannel))
                {
                    string sn = "{DDA095DA-93CA-49EF-BE01-EF5B47179FD0}";
                    string ns = "http://www.artech.com/";
                    AddressHeader addressHeader = AddressHeader.CreateAddressHeader("sn", ns, sn);
                    MessageHeader messageHeader = addressHeader.ToMessageHeader();
                    OperationContext.Current.OutgoingMessageHeaders.Add(messageHeader);
                    Console.WriteLine("x + y = {2} when x = {0} and y = {1}", 1, 2, calculator.Add(1, 2));
                }
            }
            Console.Read();
        }
    }
}