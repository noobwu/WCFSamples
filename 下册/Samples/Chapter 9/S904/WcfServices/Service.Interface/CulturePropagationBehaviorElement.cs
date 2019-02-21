using System;
using System.Configuration;
using System.ServiceModel.Configuration;
namespace Artech.WcfServices.Service.Interface
{
    public class CulturePropagationBehaviorElement : BehaviorExtensionElement
    {
        [ConfigurationProperty("namespace", IsRequired = false, DefaultValue = CulturePropagationBehaviorAttribute.DefaultNamespace)]
        public string Namespace
        {
            get { return (string)this["namespace"]; }
            set { this["namespace"] = value; }
        }
        [ConfigurationProperty("currentCultureName", IsRequired = false, DefaultValue = CulturePropagationBehaviorAttribute.DefaultCurrentCultureName)]
        public string CurrentCultureName
        {
            get { return (string)this["currentCultureName"]; }
            set { this["currentCultureName"] = value; }
        }
        [ConfigurationProperty("currentUICultureName", IsRequired = false, DefaultValue = CulturePropagationBehaviorAttribute.DefaultCurrentUICultureName)]
        public string CurrentUICultureName
        {
            get { return (string)this["currentUICultureName"]; }
            set { this["currentUICultureName"] = value; }
        }
        public override Type BehaviorType
        {
            get { return typeof(CulturePropagationBehaviorAttribute); }
        }
        protected override object CreateBehavior()
        {
            return new CulturePropagationBehaviorAttribute
            {
                Namespace = this.Namespace,
                CurrentCultureName = this.CurrentCultureName,
                CurrentUICultureName = this.CurrentUICultureName
            };
        }
    }
}