using Artech.WcfServices.Service.Interface;
using System;
namespace Artech.WcfServices.Service
{
    public class CalculatorService : ICalculator
    {      
        public double Add(double x, double y)
        {
            return x + y;
        }
    }
}
