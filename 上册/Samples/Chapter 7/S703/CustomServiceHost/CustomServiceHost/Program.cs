using System;
using System.ServiceModel;

namespace Artech.CustomServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MexServiceHost host = new MexServiceHost(typeof(CalculatorService), "mex",
                new Uri("http://127.0.0.1/calculatorservice/")))
            {
                host.AddServiceEndpoint(typeof(ICalculator), new WS2007HttpBinding(), "");
                host.Open();
                Console.Read();
            }
        }
    }
}
