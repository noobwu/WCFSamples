using System;
using System.Configuration;
using System.ServiceModel.Configuration;
namespace Artech.EntLibIntegration
{
    public class ExceptionHandlingBehaviorElement:BehaviorExtensionElement
    {
        [ConfigurationProperty("exceptionPolicy")]
        public string ExceptionPolicy
        {
            get{return this["exceptionPolicy"] as string;}
            set{ this["exceptionPolicy"] = value; }
        }
        public override Type BehaviorType
        {
            get { return typeof(ExceptionHandlingBehaviorAttribute); }
        }
        protected override object CreateBehavior()
        {
            return new ExceptionHandlingBehaviorAttribute(this.ExceptionPolicy);
        }
    }
}
