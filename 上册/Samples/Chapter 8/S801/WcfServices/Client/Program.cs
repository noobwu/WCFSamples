using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artech.WcfServices.Service.Interface;

namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost/WcfServices/CalculatorService");
            ServiceProxyFactory<ICalculator> factory = new ServiceProxyFactory<ICalculator>(address);
            ICalculator proxy = factory.CreateChannel();
            Console.WriteLine("x + y = {2} when x = {0} and y = {1}", 1, 2, proxy.Add(1, 2));
            Console.WriteLine("x - y = {2} when x = {0} and y = {1}", 1, 2, proxy.Subtract(1, 2));
            Console.WriteLine("x * y = {2} when x = {0} and y = {1}", 1, 2, proxy.Multiply(1, 2));
            Console.WriteLine("x / y = {2} when x = {0} and y = {1}", 1, 2, proxy.Divide(1, 2));
        }
    }
}