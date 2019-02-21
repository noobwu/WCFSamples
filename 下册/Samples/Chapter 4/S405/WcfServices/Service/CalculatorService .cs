using System.ServiceModel;
using System.Threading;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Service
{
    [ServiceBehavior(UseSynchronizationContext = false,
                     InstanceContextMode = InstanceContextMode.Single,
                     ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class CalculatorService : ICalculator
    {
        public void Add(double x, double y)
        {
            //PreCallback
            EventMonitor.Send(EventType.StartExecute);
            Thread.Sleep(5000);
            double result = x + y;

            //Callback
            EventMonitor.Send(EventType.StartCallback);
            int clientId = OperationContext.Current.IncomingMessageHeaders.GetHeader<int>(EventMonitor.CientIdHeaderLocalName, EventMonitor.CientIdHeaderNamespace);
            MessageHeader<int> messageHeader = new MessageHeader<int>(clientId);
            OperationContext.Current.OutgoingMessageHeaders.Add(messageHeader.GetUntypedHeader(EventMonitor.CientIdHeaderLocalName, EventMonitor.CientIdHeaderNamespace));
            OperationContext.Current.GetCallbackChannel<ICalculatorCallback>().ShowResult(result);
            EventMonitor.Send(EventType.EndCallback);

            //PostCallback
            Thread.Sleep(5000);
            EventMonitor.Send(EventType.EndExecute);
        }
    }

}
