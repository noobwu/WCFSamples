using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Artech.WcfServices
{
    public class SimpleRequestChannel : SimpleChannelBase, IRequestChannel
    {
        public IRequestChannel InnerRequestChannel
        {
            get { return (IRequestChannel)this.InnerChannel; }
        }

        public SimpleRequestChannel(ChannelManagerBase channelManager, IRequestChannel innerChannel)
            : base(channelManager, (ChannelBase)innerChannel)
        {
            this.Print("SimpleRequestChannel()");
        }

        public IAsyncResult BeginRequest(Message message, TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.Print("BeginRequest()");
            return this.InnerRequestChannel.BeginRequest(message, timeout, callback, state);
        }

        public IAsyncResult BeginRequest(Message message, AsyncCallback callback, object state)
        {
            this.Print("BeginRequest()");
            return this.InnerRequestChannel.BeginRequest(message, callback, state);
        }

        public Message EndRequest(IAsyncResult result)
        {
            this.Print("EndRequest()");
            return this.InnerRequestChannel.EndRequest(result);
        }

        public EndpointAddress RemoteAddress
        {
            get { return this.InnerRequestChannel.RemoteAddress; }
        }

        public Message Request(Message message, TimeSpan timeout)
        {
            this.Print("Request");
            return this.InnerRequestChannel.Request(message, timeout);
        }

        public Message Request(Message message)
        {
            this.Print("Request");
            return this.InnerRequestChannel.Request(message);
        }

        public Uri Via
        {
            get { return this.InnerRequestChannel.Via; }
        }
    }
}
