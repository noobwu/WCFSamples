using System.Threading;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Client
{
    public class CalculatorCallbackService : ICalculatorCallback
    {
        public void ShowResult(double result)
        {
            EventMonitor.Send(EventType.StartExecuteCallback);
            Thread.Sleep(10000);
            EventMonitor.Send(EventType.EndExecuteCallback);
        }
    }
}
