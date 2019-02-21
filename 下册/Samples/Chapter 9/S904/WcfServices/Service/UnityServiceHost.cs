using System;
using System.ServiceModel;
namespace Artech.WcfServices.Service
{
    public class UnityServiceHost : ServiceHost
    {
        private string containerName;
        public UnityServiceHost(Type serviceType, string containerName, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            this.containerName = containerName;
        }
        protected override void OnOpening()
        {
            base.OnOpening();
            if (this.Description.Behaviors.Find<UnityServiceBehaviorAttribute>() == null)
            {
                this.Description.Behaviors.Add(new UnityServiceBehaviorAttribute(containerName));
            }
        }
    }
}