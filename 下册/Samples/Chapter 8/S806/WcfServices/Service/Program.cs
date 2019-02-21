using System.ServiceModel;
using Artech.WcfServices.Service;
using System;
using System.Web.Security;
namespace Artech.WcfServices.Service
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.Open();
                Console.Read();
            }
        }
    }
}
