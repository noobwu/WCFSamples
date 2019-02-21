﻿using Artech.WcfServices.Service.Interface;
using System;
using System.ServiceModel;
namespace Artech.WcfServices.Service
{
public class CalculatorService : ICalculator
{
    public int Add(int x, int y)
    {
        return x + y;
    }
    public int Subtract(int x, int y)
    {
        return x - y;
    }
    public int Multiply(int x, int y)
    {
        return x * y;
    }
    public int Divide(int x, int y)
    {
        return x / y;
    }
}
}
