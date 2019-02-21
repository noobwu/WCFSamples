using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Artech.WcfServices.Service
{
    public class PerCallInstanceContextProvider : IInstanceContextProvider
    {
        public InstanceContext GetExistingInstanceContext(Message message, IContextChannel channel)
        {
            return null;
        }
        public void InitializeInstanceContext(InstanceContext instanceContext, Message message, IContextChannel channel) { }
        public bool IsIdle(InstanceContext instanceContext)
        {
            return true;
        }
        public void NotifyIdle(InstanceContextIdleCallback callback, System.ServiceModel.InstanceContext instanceContext) { }
    }
}
