using System.ServiceModel;
using Artech.WcfServices.Service;
using System;
using System.Threading;
namespace Artech.WcfServices.Service
{
    public class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");

            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.Open();
                Console.Read();
            }
        }
    }
}
