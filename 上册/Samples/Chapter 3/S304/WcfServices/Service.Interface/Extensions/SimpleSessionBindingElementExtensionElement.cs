using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;

namespace Artech.WcfServices
{
    public class SimpleSessionBindingElementExtensionElement : BindingElementExtensionElement
    {
        public override Type BindingElementType
        {
            get { return typeof(SimpleSessionBindingElement); }
        }
        protected override BindingElement CreateBindingElement()
        {
            return new SimpleSessionBindingElement();
        }
    }
}
