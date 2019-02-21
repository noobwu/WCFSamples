using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.Collections.ObjectModel;

namespace CreateServiceDescription
{
[AttributeUsage(AttributeTargets.Class| AttributeTargets.Interface)]
public class SimpleContractBehavior : Attribute, IContractBehavior
{
    public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }
    public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime) { }
    public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime) { }
    public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint) { }
}
[AttributeUsage(AttributeTargets.Class)]
public class SimpleServiceBehaviorAttribute : Attribute, IServiceBehavior
{
    public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) { }
    public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
}
[AttributeUsage(AttributeTargets.Method)]
public class SimpleOperationBehaviorAttribute : Attribute, IOperationBehavior
{
    public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters) { }
    public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation) { }
    public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation) { }
    public void Validate(OperationDescription operationDescription) { }
}
}
