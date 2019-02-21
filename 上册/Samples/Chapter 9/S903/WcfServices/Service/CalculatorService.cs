using Artech.WcfServices.Service.Interface;
using System.ServiceModel;
using System;
using System.Threading;
namespace Artech.WcfServices.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class CalculatorService : ICalculator, IDisposable
    {
        public CalculatorService()
        {
            Console.WriteLine("{0}: 构造器被调用", Thread.CurrentThread.ManagedThreadId);
        }

        ~CalculatorService()
        {
            Console.WriteLine("{0}: 终止化器被调用", Thread.CurrentThread.ManagedThreadId);
        }
        public void Dispose()
        {
            Console.WriteLine("{0}: Dispose方法被调用", Thread.CurrentThread.ManagedThreadId);
        }
        public double Add(double x, double y)
        {
            Console.WriteLine("{0}: 操作方法被调用", Thread.CurrentThread.ManagedThreadId);
            return x + y;
        }
    }
}