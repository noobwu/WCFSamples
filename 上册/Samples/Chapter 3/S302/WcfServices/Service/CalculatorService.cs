using Artech.WcfServices.Service.Interface;
using System.ServiceModel;
using System;
namespace Artech.WcfServices.Service
{
    public class CalculatorService : ICalculator
    {
        public double Add(double x, double y)
        {
            double result = x + y;
            Console.WriteLine("Done...");
            return result;
        }
    }
}
