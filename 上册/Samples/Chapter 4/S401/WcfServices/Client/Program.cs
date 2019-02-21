using System;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Channels;
using System.Diagnostics;
namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChannelFactory<IEventLog> channelFactory1 = new ChannelFactory<IEventLog>("eventLogService"))
            {
                IEventLog proxy = channelFactory1.CreateChannel();
                string source = "...<<source>>...";
                string message = "...<<message>>...";
                EventLogEntryType logEntryType = EventLogEntryType.Error;
                int eventId = 123;
                short category = 456;
                proxy.WriteEntry(source, message, logEntryType, eventId, category);
            }

            using (ChannelFactory<IInstrumentation> channelFactory2 =new ChannelFactory<IInstrumentation>("instrumentationservice"))
            {
                IInstrumentation proxy = channelFactory2.CreateChannel();
                string performanceCounterCategory = "...<<category>>...";
                string performanceCounterName = "...<<performance name>>...";
                string wmiPropertyName = "...<<WMI Properpty Name>>...";
                string wmiPropertyValye = "...<<>WMI Property Value>...";
                proxy.IncreasePerformanceCounter(performanceCounterCategory,performanceCounterName);
                proxy.SetWmiProperty(wmiPropertyName, wmiPropertyValye);
            }
            Console.Read();
        }
    }
}
