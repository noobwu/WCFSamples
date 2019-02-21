using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Security.Principal;
using System.ServiceModel;

namespace Artech.WcfServices.Service
{
    public class AspRoleAuthorizationCallContextInitializer :AuthorizationCallContextInitializerBase
    {
        public RoleProvider RoleProvider { get; private set; }
        public AspRoleAuthorizationCallContextInitializer(RoleProvider roleProvider)
        {
            this.RoleProvider = roleProvider;
        }
        protected override IPrincipal GetPrincipal(ServiceSecurityContext
            serviceSecurityContext)
        {
            var userName = serviceSecurityContext.PrimaryIdentity.Name;
            var identity = new GenericIdentity(userName);
            var roles = this.RoleProvider.GetRolesForUser(userName);
            return new GenericPrincipal(identity, roles);
        }
    }

}
