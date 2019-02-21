using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Artech.WcfServices.Client
{
public class ServiceProxyFactory<TChannel>
{
    public Uri Address { get; private set; }
       
    public ServiceProxyFactory(Uri address)
    {
        this.Address = address;
    }
    public TChannel CreateChannel()
    {
        MessageEncoderFactory encoderFactory = ComponentBuilder.GetMessageEncoderFactory(MessageVersion.Default, Encoding.UTF8);
        ServiceChannelProxy<TChannel> proxy = new ServiceChannelProxy<TChannel>(this.Address, MessageVersion.Default, encoderFactory);
        ContractDescription contract = ContractDescription.GetContract(typeof(TChannel));
        foreach (OperationDescription operation in contract.Operations)
        {
            IClientMessageFormatter messageFormatter = (IClientMessageFormatter)ComponentBuilder.GetFormatter(operation, true);
            proxy.MessageFormatters.Add(operation.Name, messageFormatter);
        }
        return (TChannel)proxy.GetTransparentProxy();
    }
}
}
