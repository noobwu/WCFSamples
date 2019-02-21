using Artech.WcfServices.Service.Interface;
using System.ServiceModel;
using System;
using System.Threading;
namespace Artech.WcfServices.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CalculatorService : ICalculator
    {
        public double Add(double x, double y)
        {
            Thread.Sleep(5000);
            Console.WriteLine("{0, -2}: 操作方法被调用[{1}]", Thread.CurrentThread.ManagedThreadId, DateTime.Now.ToLongTimeString());
            return x + y;
        }
    }
}