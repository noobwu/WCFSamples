using System;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Service
{
    class Program
    {
        static void Main(string[] args)
        {
using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
{
    host.AddServiceEndpoint(typeof(ICalculator),
        new SimpleSessionBinding(),
        "net.tcp://127.0.0.1:3721/calculatorservice");
    host.Open();
    Console.ReadLine();
}
            Console.Read();
        }
    }
}