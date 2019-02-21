using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Microsoft.Practices.Unity.Utility;

namespace Artech.VideoMall.Common.Extensions
{
    public class ServiceLocatableInstanceProvider: IInstanceProvider
    {
        public string ServiceLocatorName { get; private set; }
        public Type ServiceType { get; private set; }

        public ServiceLocatableInstanceProvider(Type serviceType,string serviceLocatorName = "")
        {
            Guard.ArgumentNotNull(serviceType, "serviceType");
            this.ServiceLocatorName = serviceLocatorName;
            this.ServiceType = serviceType;
        }

        public object GetInstance(InstanceContext instanceContext,Message message)
        {
            return ServiceLocatorFactory.GetServiceLocator(ServiceLocatorName).GetService(ServiceType);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return this.GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            IDisposable dispoable = instance as IDisposable;
            if (null != dispoable)
            {
                dispoable.Dispose();
            }
        }
    }
}
