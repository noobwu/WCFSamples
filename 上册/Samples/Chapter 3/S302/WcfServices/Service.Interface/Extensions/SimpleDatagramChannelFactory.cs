using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Artech.WcfServices
{
    public class SimpleDatagramChannelFactory<TChannel> : SimpleChannelFactoryBase<TChannel>
    {
        public SimpleDatagramChannelFactory(BindingContext context) :
            base(context) 
        {
            this.Print("SimpleDatagramChannelFactory()");
        }

        protected override TChannel OnCreateChannel(EndpointAddress address, Uri via)
        {
            this.Print("OnCreateChannel()");
            IRequestChannel innerChannel = (IRequestChannel)this.InnerChannelFactory.CreateChannel(address, via);
            if (null != innerChannel)
            {
                return (TChannel)(object)new SimpleRequestChannel(this, innerChannel);
            }
            else
            {
                return default(TChannel);
            }
        }
    }
}
