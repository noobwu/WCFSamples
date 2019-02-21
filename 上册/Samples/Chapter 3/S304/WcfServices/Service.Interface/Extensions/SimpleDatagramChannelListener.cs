using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;

namespace Artech.WcfServices
{
    public class SimpleDatagramChannelListener<TChannel> : SimpleChannelListenerBase<TChannel> where TChannel : class,IChannel
    {
        public SimpleDatagramChannelListener(BindingContext context)
            : base(context)
        {
            this.Print("SimpleDatagramChannelListener()");
        }
        protected override TChannel OnAcceptChannel(TimeSpan timeout)
        {
            this.Print("OnAcceptChannel()");
            IReplyChannel innerChannel = (IReplyChannel)this.InnerChannelListener.AcceptChannel(timeout);
            if (null != innerChannel)
            {
                return new SimpleReplyChannel(this, innerChannel) as TChannel;
            }
            return null;
        }
        protected override TChannel OnEndAcceptChannel(IAsyncResult result)
        {
            this.Print("OnEndAcceptChannel()");
            IReplyChannel innerChannel = (IReplyChannel)this.InnerChannelListener.EndAcceptChannel(result);
            if (null != innerChannel)
            {
                return new SimpleReplyChannel(this, innerChannel) as TChannel;
            }
            return null;
        }
    }
}