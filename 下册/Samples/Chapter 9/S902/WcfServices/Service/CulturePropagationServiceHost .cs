using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;

namespace Artech.WcfServices.Service
{
    public class CulturePropagationServiceHost : ServiceHost
    {
        public CulturePropagationServiceHost(Type serviceType, params Uri[]
            baseAddresses)
            : base(serviceType, baseAddresses)
        { }

        protected override void OnOpening()
        {
            base.OnOpening();
            CulturePropagationBehaviorAttribute behavior =
                this.Description.Behaviors.Find<CulturePropagationBehaviorAttribute>();
            if (null == behavior)
            {
                this.Description.Behaviors.Add(new
                    CulturePropagationBehaviorAttribute());
            }
        }
    }

}
