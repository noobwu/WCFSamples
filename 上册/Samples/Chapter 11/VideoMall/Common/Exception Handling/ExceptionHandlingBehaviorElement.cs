using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Configuration;
using System.Configuration;

namespace Artech.VideoMall.Common.Extensions
{
    public class ExceptionHandlingBehaviorElement:BehaviorExtensionElement
    {
        [ConfigurationProperty("exceptionPolicy", IsRequired = true)]
        public string ExceptionPolicyName
        {
            get { return (string)this["exceptionPolicy"]; }
            set { this["exceptionPolicy"] = value; }
        }

        public override Type BehaviorType
        {
            get { return typeof(ExceptionHandlingBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new ExceptionHandlingBehavior(this.ExceptionPolicyName);
        }
    }
}