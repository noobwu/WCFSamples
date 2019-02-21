using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Configuration;
using System.Configuration;

namespace Artech.VideoMall.Common.Extensions
{
    public class IoCIntegrationBehaviorElement: BehaviorExtensionElement
    {
        [ConfigurationProperty("serviceLocator", IsRequired =false, DefaultValue = "")]
        public string ServiceLocatorName
        {
            get { return (string)this["serviceLocator"]; }
            set { this["serviceLocator"] = value; }
        }

        public override Type BehaviorType
        {
            get { return typeof(IoCIntegrationBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new IoCIntegrationBehavior(this.ServiceLocatorName);
        }
    }
}
