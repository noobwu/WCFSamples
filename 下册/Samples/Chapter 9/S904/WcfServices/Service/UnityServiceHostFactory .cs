using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
namespace Artech.WcfServices.Service
{
    public class UnityServiceHostFactory : ServiceHostFactory
    {
        public string ContianerName { get; private set; }
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new UnityServiceHost(serviceType, this.ContianerName, baseAddresses);
        }
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            var split = constructorString.Split(':');
            constructorString = split[0];
            if (split.Length > 1)
            {
                this.ContianerName = split[1].Trim();
            }
            return base.CreateServiceHost(constructorString, baseAddresses);
        }
    }
}
