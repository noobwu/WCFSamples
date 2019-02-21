using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel;

namespace Artech.VideoMall.Common.Extensions
{
    public class ExceptionHandlingServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new ExceptionHandlingServiceHost(serviceType, baseAddresses);
        }
    }
}
