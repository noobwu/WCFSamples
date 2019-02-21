using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
namespace Artech.WcfServices.Service.Interface
{
    public class CulturePropagationBehaviorAttribute : Attribute, IServiceBehavior, IEndpointBehavior, IContractBehavior
    {
        private CultureMessageHeaderInfo messageHeaderInfo;

        public const string DefaultNamespace = "http://www.artech.com/culturepropagation";
        public const string DefaultCurrentCultureName = "CurrentCultureName";
        public const string DefaultCurrentUICultureName = "CurrentUICultureName";

        public string Namespace { get; set; }
        public string CurrentCultureName { get; set; }
        public string CurrentUICultureName { get; set; }

        public CulturePropagationBehaviorAttribute()
        {
            messageHeaderInfo = new CultureMessageHeaderInfo
            {
                Namespace = DefaultNamespace,
                CurrentCultureName = DefaultCurrentCultureName,
                CurrentUICultureName = DefaultCurrentUICultureName
            };
        }

        //IServiceBehavior
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) { }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpoint in channelDispatcher.Endpoints)
                {
                    foreach (DispatchOperation operation in endpoint.DispatchRuntime.Operations)
                    {
                        operation.CallContextInitializers.Add(new CultureReceiver(messageHeaderInfo));
                    }
                }
            }
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }

        //IEndpointBehavior
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new CultureSender(messageHeaderInfo));
        }
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            foreach (DispatchOperation operation in endpointDispatcher.DispatchRuntime.Operations)
            {
                operation.CallContextInitializers.Add(new CultureReceiver(messageHeaderInfo));
            }
        }
        public void Validate(ServiceEndpoint endpoint) { }

        //IContractBehavior
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }
        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new CultureSender(messageHeaderInfo));
        }
        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            foreach (DispatchOperation operation in dispatchRuntime.Operations)
            {
                operation.CallContextInitializers.Add(new CultureReceiver(messageHeaderInfo));
            }
        }
        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint) { }
    }
}
