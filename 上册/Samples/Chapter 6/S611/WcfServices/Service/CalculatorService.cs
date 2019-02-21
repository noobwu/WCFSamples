using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Artech.WcfServices.Service.Interface;
using System.Diagnostics;
namespace Artech.WcfServices.Service
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class CalculatorService : ICalculator
    {
        public double Add(double x, double y)
        {
            HttpResponseMessageProperty messageProperty;
            if (OperationContext.Current.OutgoingMessageProperties.ContainsKey(HttpResponseMessageProperty.Name))
            {
                messageProperty = (HttpResponseMessageProperty)OperationContext.Current.OutgoingMessageProperties[HttpResponseMessageProperty.Name];
            }
            else
            {
                messageProperty = new HttpResponseMessageProperty();
                OperationContext.Current.OutgoingMessageProperties.Add(HttpResponseMessageProperty.Name, messageProperty);
            }
            messageProperty.Headers.Add(HttpResponseHeader.SetCookie, "Timestamp=" + Stopwatch.GetTimestamp());
            return x + y;
        }
    }
}
