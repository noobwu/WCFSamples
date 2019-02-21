using Artech.WcfServices.Service.Interface;
using System.ServiceModel;
using System;
using System.Threading;
namespace Artech.WcfServices.Service
{
    public class CalculatorService : ICalculator
    {
        private double result;
        public void Reset()
        {
            result = 0;
        }
        public void Add(double op)
        {
            result += op;
        }
        public double GetResult()
        {
            return result;
        }
    }
}