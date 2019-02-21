using System;
using System.ServiceModel;
namespace Artech.WcfServices.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using(ServiceHost  discoveryProxyService = new ServiceHost(typeof(DiscoveryProxyService)))
            using (ServiceHost calculatorService = new ServiceHost(typeof(CalculatorService)))
            {
                discoveryProxyService.Open();
                calculatorService.Open();
                Console.Read();
            }
        }
    }
}
