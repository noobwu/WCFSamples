using System;
using System.Configuration;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
namespace Artech.ImageTransfer.Extensions
{
    public class UnreliableNetworkSimulateExtensionElement:BindingElementExtensionElement
    {
        [ConfigurationProperty("dropRate", IsRequired = false, DefaultValue = 20)]
        public int DropRate
        {
            get
            {
                return (int)this["dropRate"];
            }
            set
            {
                this["dropRate"] = value;
            }
        }
        public override Type BindingElementType
        {
            get { return typeof(UnreliableNetworkSimulateBindingElement); }
        }
        protected override BindingElement CreateBindingElement()
        {
            return new UnreliableNetworkSimulateBindingElement(this.DropRate);
        }
    }
}
