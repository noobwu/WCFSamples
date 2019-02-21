using System.ServiceModel;
using System.Threading;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Service
{
    [ServiceBehavior(UseSynchronizationContext = false)]
    public class CalculatorService : ICalculator
    {
        public double Add(double x, double y)
        {
            EventMonitor.Send(EventType.StartExecute);
            Thread.Sleep(5000);
            double result = x + y;
            EventMonitor.Send(EventType.EndExecute);
            return result;
        }
    }
}
