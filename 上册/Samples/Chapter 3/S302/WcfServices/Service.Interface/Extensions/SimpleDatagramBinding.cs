using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;

namespace Artech.WcfServices
{
    public class SimpleDatagramBinding : Binding
    {
        private TransportBindingElement transportBindingElement;
        private BindingElementCollection bindingElementCollection;
        public SimpleDatagramBinding()
        {
            BindingElement[] bindingElements = new BindingElement[]
        {
            new SimpleDatagramBindingElement(),                    
            new TextMessageEncodingBindingElement(),
            new HttpTransportBindingElement()
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