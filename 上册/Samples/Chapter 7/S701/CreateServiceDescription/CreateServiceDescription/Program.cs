using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;

namespace CreateServiceDescription
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceDescription = CreateDescription(typeof(CalculatorService));
            Console.WriteLine("{0, -17}: {1}", "Name", serviceDescription.Name);
            Console.WriteLine("{0, -17}: {1}", "Namespace", serviceDescription.Namespace);
            Console.WriteLine("{0, -17}: {1}", "ConfigurationName", serviceDescription.ConfigurationName);
            Console.WriteLine("{0, -17}: {1}", "Behaviors", serviceDescription.Behaviors[0].GetType().Name);
            for (int i = 1; i < serviceDescription.Behaviors.Count; i++)
            {
                Console.WriteLine("{0, -17}: {1}", "", serviceDescription.Behaviors[i].GetType().Name);
            }
            Console.WriteLine();
            for (int i = 1; i <= serviceDescription.Endpoints.Count; i++)
            {
                ServiceEndpoint endpoint = serviceDescription.Endpoints[i - 1];
                Console.WriteLine("第{0}个终结点", i);
                Console.WriteLine("\t{0, -9}: {1}", "Address", endpoint.Address);
                Console.WriteLine("\t{0, -9}: {1}", "Binding", endpoint.Binding);
                Console.WriteLine("\t{0, -9}: {1}", "Contract", endpoint.Contract.ContractType.Name);
                if (endpoint.Behaviors.Count > 0)
                {
                    Console.WriteLine("\t{0, -9}: {1}", "Behaviors", endpoint.Behaviors[0].GetType().Name);
                }
                for (int j = 1; j < endpoint.Behaviors.Count; j++)
                {
                    Console.WriteLine("\t{0, -9}: {1}", "", endpoint.Behaviors[j].GetType().Name);
                }
                Console.WriteLine();
            }
        }

        static ServiceDescription CreateDescription(Type serviceType)
        {
            ServiceDescription description = new ServiceDescription();

            //添加以特性方式应用的服务行为
            description.ServiceType = serviceType;
            var behaviors = (from attribute in serviceType.GetCustomAttributes(false)
                             where attribute is IServiceBehavior
                             select (IServiceBehavior)attribute).ToArray();
            Array.ForEach<IServiceBehavior>(behaviors, behavior => description.Behaviors.Add(behavior));

            //确保服务具有一个ServiceBehaviorAttribute行为
            ServiceBehaviorAttribute serviceBehaviorAttribute = description.Behaviors.Find<ServiceBehaviorAttribute>();
            if (null == serviceBehaviorAttribute)
            {
                serviceBehaviorAttribute = new ServiceBehaviorAttribute();
                description.Behaviors.Add(serviceBehaviorAttribute);
            }

            //初始化Name、Namespace和ConfigurationName
            description.Name = serviceBehaviorAttribute.Name ?? serviceType.Name;
            description.Namespace = serviceBehaviorAttribute.Namespace ?? "http://tempuri.org/";
            description.ConfigurationName = serviceBehaviorAttribute.ConfigurationName ?? serviceType.Namespace + "." + serviceType.Name;

            //添加以配置方式应用的服务行为
            ServiceElement serviceElement = ConfigLoader.GetServiceElement(description.ConfigurationName);
            if (!string.IsNullOrEmpty(serviceElement.BehaviorConfiguration))
            {
                ServiceBehaviorElement behaviorElement = ConfigLoader.GetServiceBehaviorElement(serviceElement.BehaviorConfiguration);
                foreach (BehaviorExtensionElement extensionElement in behaviorElement)
                {
                    IServiceBehavior serviceBehavior = (IServiceBehavior)extensionElement.CreateBehavior();
                    description.Behaviors.Add(serviceBehavior);
                }
            }

            //添加配置的终结点
            foreach (ServiceEndpointElement endpointElement in serviceElement.Endpoints)
            {
                description.Endpoints.Add(CreateServiceEndpoint(serviceType, endpointElement));
            }
            return description;
        }

        static ServiceEndpoint CreateServiceEndpoint(Type serviceType, ServiceEndpointElement endpointElement)
        {
            //创建ServiceEndpoint
            EndpointAddress address = new EndpointAddress(endpointElement.Address);
            Binding binding = ConfigLoader.CreateBinding(endpointElement.Binding);
            ContractDescription contract = CreateContractDescription(serviceType, endpointElement.Contract);
            ServiceEndpoint endpoint = new ServiceEndpoint(contract, binding, address);

            //添加终结点行为
            if (!string.IsNullOrEmpty(endpointElement.BehaviorConfiguration))
            {
                EndpointBehaviorElement behaviorElement = ConfigLoader.GetEndpointBehaviorElement(endpointElement.BehaviorConfiguration);
                foreach (BehaviorExtensionElement extensionElement in behaviorElement)
                {
                    IEndpointBehavior endpointBehavior = (IEndpointBehavior)extensionElement.CreateBehavior();
                    endpoint.Behaviors.Add(endpointBehavior);
                }
            }
            return endpoint;
        }

        static ContractDescription CreateContractDescription(Type serviceType, string configurationName)
        {
            foreach (Type contract in serviceType.GetInterfaces())
            {
                ServiceContractAttribute serviceContractAttribute = contract.GetCustomAttributes(typeof(ServiceContractAttribute), false).FirstOrDefault() as ServiceContractAttribute;
                if (null != serviceContractAttribute)
                {
                    string configName = serviceContractAttribute.ConfigurationName ?? contract.Namespace + "." + contract.Name;
                    if (configurationName == configName)
                    {
                        return ContractDescription.GetContract(contract, serviceType);
                    }
                }
            }
            return null;
        }
    }
}