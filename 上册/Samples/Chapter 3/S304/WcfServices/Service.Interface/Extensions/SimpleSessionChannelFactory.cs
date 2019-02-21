using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Artech.WcfServices
{
    public class SimpleSessionChannelFactory<TChannel> : SimpleChannelFactoryBase<TChannel>
    {
        public SimpleSessionChannelFactory(BindingContext context)
            : base(context)
        {
            this.Print("SimpleSessionChannelFactory()");
        }
        protected override TChannel OnCreateChannel(EndpointAddress address, Uri via)
        {
            this.Print("OnCreateChannel()");
            IDuplexSessionChannel innerChannel = (IDuplexSessionChannel)this.InnerChannelFactory.CreateChannel(address, via);
            if (null != innerChannel)
            {
                return (TChannel)(object)new SimpleDuplexSessionChannel(this, innerChannel);
            }
            return default(TChannel);
        }
    }
}
