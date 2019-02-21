using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Artech.WcfServices.Service
{
    public class UnityServiceBehaviorAttribute : Attribute, IServiceBehavior
    {
        static Dictionary<string, IUnityContainer> containers = new Dictionary<string, IUnityContainer>();
        public IUnityContainer UnityContainer { get; private set; }
        public UnityServiceBehaviorAttribute()
            : this(string.Empty)
        { }
        public UnityServiceBehaviorAttribute(string containerName)
        {
            containerName = containerName ?? string.Empty;
            if (containers.ContainsKey(containerName))
            {
                this.UnityContainer = containers[containerName];
            }
            else
            {
                lock (typeof(UnityServiceBehaviorAttribute))
                {
                    IUnityContainer container = new UnityContainer();
                    UnityConfigurationSection configuration = (UnityConfigurationSection)ConfigurationManager.GetSection(UnityConfigurationSection.SectionName);
                    if (containerName == string.Empty)
                    {
                        configuration.Configure(container);
                    }
                    else
                    {
                        configuration.Configure(container, containerName);
                    }
                    containers[containerName] = container;
                    this.UnityContainer = container;
                }
            }
        }
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) {}
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                {
                    Type contractType = (from endpoint in serviceHostBase.Description.Endpoints
                                         where endpoint.Contract.Name == endpointDispatcher.ContractName && endpoint.Contract.Namespace == endpointDispatcher.ContractNamespace
                                         select endpoint.Contract.ContractType).FirstOrDefault();
                    if (null == contractType)
                    {
                        continue;
                    }
                    if (!this.UnityContainer.Registrations.Any(registration => registration.RegisteredType == contractType))
                    {
                        this.UnityContainer.RegisterType(contractType, serviceHostBase.Description.ServiceType);
                    }
                    endpointDispatcher.DispatchRuntime.InstanceProvider = new UnityInstanceProvider(this.UnityContainer, contractType);
                }
            }
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) {}
    }
}