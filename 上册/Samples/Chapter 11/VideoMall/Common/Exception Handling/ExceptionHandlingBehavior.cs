using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity.Utility;

namespace Artech.VideoMall.Common.Extensions
{
    public class ExceptionHandlingBehavior :IServiceBehavior
    {
        public string ExceptionPolicyName { get; private set; }
        public ExceptionHandlingBehavior(string exceptionPolicyName)
        {
            Guard.ArgumentNotNullOrEmpty(exceptionPolicyName, "exceptionPolicyName");
            this.ExceptionPolicyName = exceptionPolicyName;
        }
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) { }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription,ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                channelDispatcher.ErrorHandlers.Add(new ServiceErrorHandler(this.ExceptionPolicyName));
            }
        }
        public void Validate(ServiceDescription serviceDescription,ServiceHostBase serviceHostBase) { }
    }
}
