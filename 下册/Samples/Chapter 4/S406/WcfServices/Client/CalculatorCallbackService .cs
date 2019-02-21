using System.Threading;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel;
namespace Artech.WcfServices.Client
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
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
