using System;
using Artech.WcfServices.Service.Interface;

namespace Artech.WcfServices.Service
{
    public class InstrumentationService : EventLogService, IInstrumentation
    {
        public void IncreasePerformanceCounter(string categoryName, string counterName)
        {
            Console.WriteLine("IncreasePerformanceCounter...");
        }

        public void SetWmiProperty(string propertyName, object value)
        {
            Console.WriteLine("SetWmiProperty...");
        }
    }
}
