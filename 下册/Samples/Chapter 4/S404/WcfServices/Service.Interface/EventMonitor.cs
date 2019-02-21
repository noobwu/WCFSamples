using System;
using System.ServiceModel;
using System.Threading;
namespace Artech.WcfServices.Service.Interface
{
    public static class EventMonitor
    {
        public const string CientIdHeaderNamespace = "http://www.artech.com/";
        public const string CientIdHeaderLocalName = "ClientId";
        public static EventHandler<MonitorEventArgs> MonitoringNotificationSended;

        public static void Send(EventType eventType)
        {
            if (null != MonitoringNotificationSended)
            {
                int clientId = OperationContext.Current.IncomingMessageHeaders.GetHeader<int>(CientIdHeaderLocalName, CientIdHeaderNamespace);
                MonitoringNotificationSended(null, new MonitorEventArgs(clientId, eventType, DateTime.Now));
            }
        }
        public static void Send(int clientId, EventType eventType)
        {
            if (null != MonitoringNotificationSended)
            {
                MonitoringNotificationSended(null, new MonitorEventArgs(clientId, eventType, DateTime.Now));
            }
        }
    }
    public class MonitorEventArgs : EventArgs
    {
        public int ClientId { get; private set; }
        public EventType EventType { get; private set; }
        public DateTime EventTime { get; private set; }
        public MonitorEventArgs(int clientId, EventType eventType, DateTime eventTime)
        {
            this.ClientId = clientId;
            this.EventType = eventType;
            this.EventTime = eventTime;
        }
    }
}
