using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Artech.WcfServices.Service
{
    public class SingletonInstanceContextProvider : IInstanceContextProvider
    {
        public DispatchRuntime DispatchRuntime { get; private set; }
        public SingletonInstanceContextProvider(DispatchRuntime runtime)
        {
            this.DispatchRuntime = runtime;
        }

        public InstanceContext GetExistingInstanceContext(Message message, IContextChannel channel)
        {
            return this.DispatchRuntime.SingletonInstanceContext;
        }
        public void InitializeInstanceContext(InstanceContext instanceContext, Message message, IContextChannel channel) { }
        public bool IsIdle(InstanceContext instanceContext)
        {
            return false;
        }
        public void NotifyIdle(InstanceContextIdleCallback callback, InstanceContext instanceContext) { }
    }
}
