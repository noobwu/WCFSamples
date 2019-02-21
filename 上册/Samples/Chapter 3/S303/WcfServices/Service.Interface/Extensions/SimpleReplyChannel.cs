using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Artech.WcfServices
{
    public class SimpleReplyChannel : SimpleChannelBase, IReplyChannel
    {
        public IReplyChannel InnerReplyChannel
        {
            get { return (IReplyChannel)this.InnerChannel; }
        }

        public SimpleReplyChannel(ChannelManagerBase channelManager, IReplyChannel innerChannel)
            : base(channelManager, (ChannelBase)innerChannel)
        {
            this.Print("SimpleReplyChannel()");
        }

        public IAsyncResult BeginReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.Print("BeginReceiveRequest()");
            return this.InnerReplyChannel.BeginReceiveRequest(timeout, callback, state);
        }

        public IAsyncResult BeginReceiveRequest(AsyncCallback callback, object state)
        {
            this.Print("BeginReceiveRequest()");
            return this.InnerReplyChannel.BeginReceiveRequest(callback, state);
        }

        public IAsyncResult BeginTryReceiveRequest(TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.Print("BeginTryReceiveRequest()");
            return this.InnerReplyChannel.BeginTryReceiveRequest(timeout, callback, state);
        }

        public IAsyncResult BeginWaitForRequest(TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.Print("BeginWaitForRequest()");
            return this.InnerReplyChannel.BeginWaitForRequest(timeout, callback, state);
        }

        public RequestContext EndReceiveRequest(IAsyncResult result)
        {
            this.Print("EndReceiveRequest()");
            return this.InnerReplyChannel.EndReceiveRequest(result);
        }

        public bool EndTryReceiveRequest(IAsyncResult result, out RequestContext context)
        {
            this.Print("EndTryReceiveRequest()");
            return this.InnerReplyChannel.EndTryReceiveRequest(result, out context);
        }

        public bool EndWaitForRequest(IAsyncResult result)
        {
            this.Print("EndWaitForRequest()");
            return this.InnerReplyChannel.EndWaitForRequest(result);
        }

        public EndpointAddress LocalAddress
        {
            get{ return this.InnerReplyChannel.LocalAddress;}
        }

        public RequestContext ReceiveRequest(TimeSpan timeout)
        {
            this.Print("ReceiveRequest()");
            return this.InnerReplyChannel.ReceiveRequest(timeout);
        }

        public RequestContext ReceiveRequest()
        {
            this.Print("ReceiveRequest()");
            return this.InnerReplyChannel.ReceiveRequest();
        }

        public bool TryReceiveRequest(TimeSpan timeout, out RequestContext context)
        {
            this.Print("TryReceiveRequest()");
            return this.InnerReplyChannel.TryReceiveRequest(timeout, out context);
        }

        public bool WaitForRequest(TimeSpan timeout)
        {
            this.Print("WaitForRequest()");
            return this.InnerReplyChannel.WaitForRequest(timeout);
        }
    }
}
