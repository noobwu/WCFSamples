using Artech.WcfServices.Service.Interface;
using System;
namespace Artech.WcfServices.Service
{
public class CalculatorService: ICalculator
{
    double ICalculator.Add(double x, double y)
    {
        Console.WriteLine("Add操作开始执行...");
        return x + y;
    }
}
}