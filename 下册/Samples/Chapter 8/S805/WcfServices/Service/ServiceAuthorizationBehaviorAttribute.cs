using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.Collections.ObjectModel;
using System.Web.Security;
using System.ServiceModel.Channels;

namespace Artech.WcfServices.Service
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceAuthorizationBehaviorAttribute : Attribute, IServiceBehavior
    {
        public PrincipalPermissionMode PrincipalPermissionMode { get; private set; }
        public ICallContextInitializer CallContextInitializer { get; private set; }

        public ServiceAuthorizationBehaviorAttribute(PrincipalPermissionMode principalPermissionMode, string roleProviderName = "")
        {
            switch (principalPermissionMode)
            {
                case PrincipalPermissionMode.UseWindowsGroups:
                    {
                        this.CallContextInitializer = new WindowsAuthorizationCallContextInitializer();
                        break;
                    }
                case PrincipalPermissionMode.UseAspNetRoles:
                    {
                        if (string.IsNullOrEmpty(roleProviderName))
                        {
                            this.CallContextInitializer = new AspRoleAuthorizationCallContextInitializer(Roles.Provider);
                        }
                        else
                        {
                            this.CallContextInitializer = new AspRoleAuthorizationCallContextInitializer(Roles.Providers[roleProviderName]);
                        }
                        break;
                    }
                case PrincipalPermissionMode.Custom:
                    {
                        throw new ArgumentException("只有UseWindowsGroups和UseAspNetRoles模式被支持！");
                    }
            }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) { }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            if (null == this.CallContextInitializer)
            {
                return;
            }

            foreach (ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach (EndpointDispatcher endpoint in channelDispatcher.Endpoints)
                {
                    foreach (DispatchOperation operation in endpoint.DispatchRuntime.Operations)
                    {
                        operation.CallContextInitializers.Add(this.CallContextInitializer);
                    }
                }
            }
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
    }

}
