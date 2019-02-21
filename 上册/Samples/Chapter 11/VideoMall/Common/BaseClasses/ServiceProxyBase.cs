using System;
using Artech.VideoMall.Common.Extensions;
using Microsoft.Practices.Unity.Utility;
namespace Artech.VideoMall.Common
{
    public abstract class ServiceProxyBase: MarshalByRefObject
    {
    }
    public abstract class ServiceProxyBase<TChannel> : ServiceProxyBase
    {
        public OperationInvoker<TChannel> Invoker { get; private set; }
        public ServiceProxyBase(string endpointConfigurationName)
        {
            Guard.ArgumentNotNullOrEmpty(endpointConfigurationName, "endpointConfigurationName");
            this.Invoker = new OperationInvoker<TChannel>(endpointConfigurationName);
        }
    }
}
