using System;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Client
{
    public class CalculatorCallbackService : ICalculatorCallback
    {
        public void DisplayResult(double result, double x, double y)
        {
            Console.WriteLine("x + y = {2} when x = {0}  and y = {1}", x, y, result);
        }
    }
}
