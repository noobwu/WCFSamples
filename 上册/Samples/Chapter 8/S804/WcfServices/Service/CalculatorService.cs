using Artech.WcfServices.Service.Interface;
using System;
namespace Artech.WcfServices.Service
{
    public class CalculatorService : ICalculator
    {
        public CalculatorService()
        {
            Console.WriteLine("Constructor...");
        }

        ~CalculatorService()
        {
            Console.WriteLine("Deconstructor...");
        }

        public double Add(double x, double y)
        {
            return x + y;
        }
    }
}
