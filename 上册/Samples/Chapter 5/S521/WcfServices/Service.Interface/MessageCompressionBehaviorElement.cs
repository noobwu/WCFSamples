using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Configuration;
using System.Configuration;

namespace Artech.Serialization.Extension
{
    public class MessageCompressionBehaviorElement: BehaviorExtensionElement
    {
        [ConfigurationProperty("algorithm", IsRequired = false, DefaultValue = CompressionAlgorithm.GZip)]
        public CompressionAlgorithm Algorithm
        {
            get { return (CompressionAlgorithm)this["algorithm"]; }
            set { this["algorithm"] = value; }
        }
        [ConfigurationProperty("minMessageSize", IsRequired = false, DefaultValue = 1024)]
        [IntegerValidator(MinValue = 0)]
        public int MinMessageSize
        {
            get { return (int)this["minMessageSize"]; }
            set { this["minMessageSize"] = value; }
        }
        public override Type BehaviorType
        {
            get { return typeof(MessageCompressionBehavior); }
        }
        protected override object CreateBehavior()
        {
            return new MessageCompressionBehavior(this.Algorithm, this.MinMessageSize);
        }
    }
}
