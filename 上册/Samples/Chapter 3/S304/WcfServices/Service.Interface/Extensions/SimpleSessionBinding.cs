using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;

namespace Artech.WcfServices
{
public class SimpleSessionBinding : Binding
{
    private TransportBindingElement transportBindingElement;
    private BindingElementCollection bindingElementCollection;
    public SimpleSessionBinding()
    {
        BindingElement[] bindingElements = new BindingElement[]
    {
        new SimpleSessionBindingElement(),                    
        new BinaryMessageEncodingBindingElement(),
        new TcpTransportBindingElement()
    };
        bindingElementCollection = new BindingElementCollection(bindingElements);
        transportBindingElement = (TransportBindingElement)bindingElements[2];
    }
    public override BindingElementCollection CreateBindingElements()
    {
        return bindingElementCollection;
    }
    public override string Scheme
    {
        get { return transportBindingElement.Scheme; }
    }
}
}