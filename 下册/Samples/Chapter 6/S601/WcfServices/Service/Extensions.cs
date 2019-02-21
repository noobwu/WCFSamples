using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Artech.WcfServices.Service
{
    public static class Extensions
    {
        public static MsmqMessageProperty GetMsmqMessageProperty(this OperationContext context)
        {
            if (context.IncomingMessageProperties.ContainsKey(MsmqMessageProperty.Name))
            {
                return (MsmqMessageProperty)context.IncomingMessageProperties[MsmqMessageProperty.Name];
            }
            return null;
        }
    }
}
