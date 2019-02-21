using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
namespace Artech.EntLibIntegration
{
    public class ExceptionHandlingBehaviorAttribute:Attribute,IServiceBehavior
    {
        public string ExceptionPolicyName { get; private set; }
        public ExceptionHandlingBehaviorAttribute(string exceptionPolicyName)
        {
            this.ExceptionPolicyName = exceptionPolicyName;
        }
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters){}
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {              
                channelDispatcher.ErrorHandlers.Add(new ServiceErrorHandler(this.ExceptionPolicyName));
            }
        }
        public void Validate(ServiceDescription serviceDescription, System.ServiceModel.ServiceHostBase serviceHostBase){}
    }
}