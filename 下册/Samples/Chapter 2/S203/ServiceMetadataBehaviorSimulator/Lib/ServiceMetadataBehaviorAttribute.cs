using System;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Xml;
using System.Reflection;
namespace Artech.ServiceMetadataBehaviorSimulator
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceMetadataBehaviorAttribute : Attribute, IServiceBehavior
    {
        private const string MexContractName = "IMetadataProvisionService";
        private const string MexContractNamespace = "http://schemas.microsoft.com/2006/04/mex";
        private const string SingletonInstanceContextProviderType = "System.ServiceModel.Dispatcher.SingletonInstanceContextProvider,System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        private const string SyncMethodInvokerType = "System.ServiceModel.Dispatcher.SyncMethodInvoker,System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        private const string MessageOperationFormatterType = "System.ServiceModel.Dispatcher.MessageOperationFormatter, System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

        public bool HttpGetEnabled{ get; set; }
        public string HttpGetUrl{ get; set; }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) { }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            MetadataSet metadata = GetExportedMetadata(serviceDescription);
            CustomizeMexEndpoints(serviceDescription, serviceHostBase, metadata);
            if (this.HttpGetEnabled)
            {
                CreateHttpGetChannelDispatcher(serviceHostBase, new Uri(this.HttpGetUrl), metadata);
            }    
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
        private static void CreateHttpGetChannelDispatcher(ServiceHostBase host, Uri listenUri, MetadataSet metadata)
        {
            //创建Binding
            TextMessageEncodingBindingElement messageEncodingElement = new TextMessageEncodingBindingElement() { MessageVersion = MessageVersion.None };
            HttpTransportBindingElement transportElement = new HttpTransportBindingElement();
            Utility.SetPropertyValue(transportElement, "Method", "GET");
            Binding binding = new CustomBinding(messageEncodingElement, transportElement);

            //创建ChannelListener
            IChannelListener listener = binding.BuildChannelListener<IReplyChannel>(listenUri, string.Empty, ListenUriMode.Explicit, new BindingParameterCollection());
            ChannelDispatcher dispatcher = new ChannelDispatcher(listener, "ServiceMetadataBehaviorHttpGetBinding", binding) { MessageVersion = binding.MessageVersion };

            //创建EndpointDispatcher
            EndpointDispatcher endpoint = new EndpointDispatcher(new EndpointAddress(listenUri), "IHttpGetMetadata", "http://www.artech.com/");

            //创建DispatchOperation，并设置DispatchMessageFormatter和OperationInvoker
            DispatchOperation operation = new DispatchOperation(endpoint.DispatchRuntime, "Get", "*", "*");
            operation.Formatter = Utility.CreateInstance<IDispatchMessageFormatter>(MessageOperationFormatterType, Type.EmptyTypes, new object[0]);
            MethodInfo method = typeof(IHttpGetMetadata).GetMethod("Get");
            operation.Invoker = Utility.CreateInstance<IOperationInvoker>(SyncMethodInvokerType, new Type[] { typeof(MethodInfo) }, new object[] { method });
            endpoint.DispatchRuntime.Operations.Add(operation);

            //设置SingletonInstanceContext和InstanceContextProvider
            MetadataProvisionService serviceInstance = new MetadataProvisionService(metadata);
            endpoint.DispatchRuntime.SingletonInstanceContext = new InstanceContext(host, serviceInstance);
            endpoint.DispatchRuntime.InstanceContextProvider = Utility.CreateInstance<IInstanceContextProvider>(SingletonInstanceContextProviderType, new Type[] { typeof(DispatchRuntime) }, new object[] { endpoint.DispatchRuntime });
            dispatcher.Endpoints.Add(endpoint);

            //设置ContractFilter和AddressFilter
            endpoint.ContractFilter = new MatchAllMessageFilter();
            endpoint.AddressFilter = new MatchAllMessageFilter();

            host.ChannelDispatchers.Add(dispatcher);
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) {}
    }
}
