using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Xml;
namespace Artech.ServiceMetadataBehaviorSimulator
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceMetadataBehaviorAttribute : Attribute, IServiceBehavior
    {
        private const string MexContractName = "IMetadataProvisionService";
        private const string MexContractNamespace = "http://schemas.microsoft.com/2006/04/mex";
        private const string SingletonInstanceContextProviderType = "System.ServiceModel.Dispatcher.SingletonInstanceContextProvider,System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) { }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            MetadataSet metadata = GetExportedMetadata(serviceDescription);
            CustomizeMexEndpoints(serviceDescription, serviceHostBase, metadata);
        }
        private static MetadataSet GetExportedMetadata(ServiceDescription serviceDescription)
        {
            Collection<ServiceEndpoint> endpoints = new Collection<ServiceEndpoint>();
            foreach (var endpoint in serviceDescription.Endpoints)
            {
                if (endpoint.Contract.ContractType == typeof(IMetadataProvisionService))
                {
                    continue;
                }
                ServiceEndpoint newEndpoint = new ServiceEndpoint(endpoint.Contract, endpoint.Binding, endpoint.Address);
                newEndpoint.Name = endpoint.Name;
                foreach (var behavior in endpoint.Behaviors)
                {
                    newEndpoint.Behaviors.Add(behavior);
                }
                endpoints.Add(newEndpoint);
            }
            WsdlExporter exporter = new WsdlExporter();
            XmlQualifiedName wsdlServiceQName = new XmlQualifiedName(serviceDescription.Name, serviceDescription.Namespace);
            exporter.ExportEndpoints(endpoints, wsdlServiceQName);
            MetadataSet metadata = exporter.GetGeneratedMetadata();
            return metadata;
        }
        private static void CustomizeMexEndpoints(ServiceDescription description, ServiceHostBase host, MetadataSet metadata)
        {
            foreach (ChannelDispatcher channelDispatcher in host.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpoint in channelDispatcher.Endpoints)
                {
                    if (endpoint.ContractName == MexContractName && endpoint.ContractNamespace == MexContractNamespace)
                    {
                        DispatchRuntime dispatchRuntime = endpoint.DispatchRuntime;
                        dispatchRuntime.InstanceContextProvider = Utility.CreateInstance<IInstanceContextProvider>(SingletonInstanceContextProviderType, new Type[] { typeof(DispatchRuntime) }, new object[] { dispatchRuntime });
                        MetadataProvisionService serviceInstance = new MetadataProvisionService(metadata);
                        dispatchRuntime.SingletonInstanceContext = new InstanceContext(host, serviceInstance);
                    }
                }
            }
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) {}
    }
}
