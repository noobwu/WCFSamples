using System;
using System.ServiceModel;
namespace Artech.EntLibIntegration.Service
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






 


 
