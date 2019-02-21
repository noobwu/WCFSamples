using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;

namespace Artech.WcfServices
{
    public class SimpleSessionChannelListener<TChannel> : SimpleChannelListenerBase<TChannel> where TChannel : class, IChannel
    {
        public SimpleSessionChannelListener(BindingContext context)
            : base(context)
        {
            this.Print("SimpleSessionChannelListener()");
        }
        protected override TChannel OnAcceptChannel(TimeSpan timeout)
        {
            this.Print("OnAcceptChannel()");
            IDuplexSessionChannel innerChannel = (IDuplexSessionChannel)this.InnerChannelListener.AcceptChannel(timeout);
            return new SimpleDuplexSessionChannel(this, innerChannel) as TChannel;
        }
        protected override TChannel OnEndAcceptChannel(IAsyncResult result)
        {
            this.Print("OnEndAcceptChannel()");
            IDuplexSessionChannel innerChannel = (IDuplexSessionChannel)this.InnerChannelListener.EndAcceptChannel(result);
            if (null != innerChannel)
            {
                return new SimpleDuplexSessionChannel(this, innerChannel) as TChannel;
            }
            return default(TChannel);
        }
    }
}