using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.Security.Principal;
using System.ServiceModel;
using System.Threading;
using System.ServiceModel.Channels;

namespace Artech.WcfServices.Service
{
    public abstract class AuthorizationCallContextInitializerBase : ICallContextInitializer
    {
        public void AfterInvoke(object correlationState)
        {
            IPrincipal principal = correlationState as IPrincipal;
            if (null != principal)
            {
                Thread.CurrentPrincipal = principal;
            }
        }
        public object BeforeInvoke(InstanceContext instanceContext, IClientChannel channel, Message message)
        {
            var originalPrincipal = Thread.CurrentPrincipal;
            Thread.CurrentPrincipal = this.GetPrincipal(ServiceSecurityContext.Current);
            return originalPrincipal;
        }
        protected abstract IPrincipal GetPrincipal(ServiceSecurityContext serviceSecurityContext);
    }

}
