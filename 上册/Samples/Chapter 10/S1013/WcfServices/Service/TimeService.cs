using System;
using System.ServiceModel.Activation;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TimeService : ITime
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}