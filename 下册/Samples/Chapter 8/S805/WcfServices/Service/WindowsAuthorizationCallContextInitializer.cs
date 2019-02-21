using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.ServiceModel;

namespace Artech.WcfServices.Service
{
    public class WindowsAuthorizationCallContextInitializer : AuthorizationCallContextInitializerBase
    {
        protected override IPrincipal GetPrincipal(ServiceSecurityContext serviceSecurityContext)
        {
            WindowsIdentity identity = serviceSecurityContext.WindowsIdentity;
            if (null == identity)
            {
                identity = WindowsIdentity.GetAnonymous();
            }
            return new WindowsPrincipal(identity);
        }
    }
}
