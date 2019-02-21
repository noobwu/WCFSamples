using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Artech.Serialization.Extension
{
public class MessageCompressionBehavior: IEndpointBehavior
{
    public MessageCompressor MessageCompressor { get; private set; }
    public MessageCompressionBehavior(CompressionAlgorithm algorithm, int minMessageSize)
    {
        this.MessageCompressor = new MessageCompressor(algorithm, minMessageSize);
    }
    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters) { }
    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
        foreach(OperationDescription operation in endpoint.Contract.Operations)
        {
            IOperationBehavior serializerBehavior = operation.Behaviors.Find<XmlSerializerOperationBehavior>();
            if (null == serializerBehavior)
            {
                serializerBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
            }
            serializerBehavior.ApplyClientBehavior(operation, clientRuntime.Operations[operation.Name]);
        }           

        foreach (ClientOperation operation in clientRuntime.Operations)
        {
            operation.Formatter = new CompressionMessageFormatter(this.MessageCompressor, null, operation.Formatter);
        }
    }
    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
    {
        foreach (OperationDescription operation in endpoint.Contract.Operations)
        {
            IOperationBehavior serializerBehavior = operation.Behaviors.Find<XmlSerializerOperationBehavior>();
            if (null == serializerBehavior)
            {
                serializerBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
            }
            serializerBehavior.ApplyDispatchBehavior(operation, endpointDispatcher.DispatchRuntime.Operations[operation.Name]);
        }
        foreach (DispatchOperation operation in endpointDispatcher.DispatchRuntime.Operations)
        {
            operation.Formatter = new CompressionMessageFormatter(this.MessageCompressor, operation.Formatter, null);
        }
    }
    public void Validate(ServiceEndpoint endpoint) { }
}
}
