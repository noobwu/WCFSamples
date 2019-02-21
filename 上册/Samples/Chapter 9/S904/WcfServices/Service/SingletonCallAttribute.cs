using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.Reflection;

namespace Artech.WcfServices.Service
{
    public class SingletonAttribute : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                {
                    DispatchRuntime runtime = endpointDispatcher.DispatchRuntime;
                    ServiceHost serviceHost = (ServiceHost)serviceHostBase;
                    if (null != serviceHost.SingletonInstance)
                    {
                        runtime.SingletonInstanceContext = new InstanceContext(serviceHostBase, serviceHost.SingletonInstance);
                        SetDisposableInstance(serviceHost, serviceHost.SingletonInstance);
                    }
                    else
                    {
                        object serviceInstance = Activator.CreateInstance(serviceDescription.ServiceType);
                        runtime.SingletonInstanceContext = new InstanceContext(serviceInstance);
                        SetDisposableInstance(serviceHost, serviceInstance);
                    }
                    IInstanceContextProvider provider = new SingletonInstanceContextProvider(runtime);
                    runtime.InstanceContextProvider = provider;
                }
            }
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        private void SetDisposableInstance(ServiceHost serviceHost, object serviceInstance)
        {
            if (!serviceInstance.GetType().GetInterfaces().Contains(typeof(IDisposable)))
            {
                return;
            }
            FieldInfo field = typeof(ServiceHost).GetField("disposableInstance", BindingFlags.Instance | BindingFlags.NonPublic);
            field.SetValue(serviceHost, serviceInstance);
        }
    }
}
