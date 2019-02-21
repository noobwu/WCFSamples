using Artech.WcfServices.Service.Interface;
using System.ServiceModel;
using System;
namespace Artech.WcfServices.Service
{
    public class EventLogService : IEventLog
    {
        public void WriteEntry(string source, string message, System.Diagnostics.EventLogEntryType type, int eventID, short category)
        {
            Console.WriteLine("WriteEntry...");
        }
    }
}
