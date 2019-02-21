using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artech.WcfServices.Service.Interface;

namespace Artech.WcfServices.Client
{
public class CalculatorServiceProxy : ServiceProxyBase<ICalculator>, ICalculator
{
    public CalculatorServiceProxy()
        : base("calculatorservice")
    { }
    public int Add(int x, int y)
    {
        return this.Invoker.Invoke<int>(proxy => proxy.Add(x, y));
    }
    public int Subtract(int x, int y)
    {
        return this.Invoker.Invoke<int>(proxy => proxy.Subtract(x, y));
    }
    public int Multiply(int x, int y)
    {
        return this.Invoker.Invoke<int>(proxy => proxy.Multiply(x, y));
    }
    public int Divide(int x, int y)
    {
        return this.Invoker.Invoke<int>(proxy => proxy.Divide(x, y));
    }
}
}
