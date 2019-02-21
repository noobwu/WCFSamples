using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Artech.WcfServices
{
    public class SimpleDuplexSessionChannel : SimpleChannelBase, IDuplexSessionChannel
    {
        public IDuplexSessionChannel InnerDuplexSessionChannel
        {
            get { return (IDuplexSessionChannel)this.InnerChannel; }
        }

        public SimpleDuplexSessionChannel(ChannelManagerBase channelManager, IDuplexSessionChannel innerChannel)
            : base(channelManager, (ChannelBase)innerChannel)
        {
            this.Print("SimpleDuplexSessionChannel()");
        }

        public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.Print("BeginReceive()");
            return this.InnerDuplexSessionChannel.BeginReceive(timeout, callback, state);
        }

        public IAsyncResult BeginReceive(AsyncCallback callback, object state)
        {
            this.Print("BeginReceive()");
            return this.InnerDuplexSessionChannel.BeginReceive(callback, state);
        }

        public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.Print("BeginTryReceive()");
            return this.InnerDuplexSessionChannel.BeginTryReceive(timeout, callback, state);
        }

        public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.Print("BeginWaitForMessage()");
            return this.InnerDuplexSessionChannel.BeginWaitForMessage(timeout, callback, state);
        }

        public Message EndReceive(IAsyncResult result)
        {
            this.Print("EndReceive()");
            return this.InnerDuplexSessionChannel.EndReceive(result);
        }

        public bool EndTryReceive(IAsyncResult result, out Message message)
        {
            this.Print("EndTryReceive()");
            return this.InnerDuplexSessionChannel.EndTryReceive(result, out message);
        }

        public bool EndWaitForMessage(IAsyncResult result)
        {
            this.Print("EndWaitForMessage()");
            return this.InnerDuplexSessionChannel.EndWaitForMessage(result);
        }

        public EndpointAddress LocalAddress
        {
            get { return this.InnerDuplexSessionChannel.LocalAddress; }
        }

        public Message Receive(TimeSpan timeout)
        {
            this.Print("Receive()");
            return this.InnerDuplexSessionChannel.Receive(timeout);
        }

        public Message Receive()
        {
            this.Print("Receive()");
            return this.InnerDuplexSessionChannel.Receive();
        }

        public bool TryReceive(TimeSpan timeout, out Message message)
        {
            this.Print("TryReceive()");
            return this.InnerDuplexSessionChannel.TryReceive(timeout, out message);
        }

        public bool WaitForMessage(TimeSpan timeout)
        {
            this.Print("WaitForMessage()");
            return this.InnerDuplexSessionChannel.WaitForMessage(timeout);
        }

        public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.Print("BeginSend()");
            return this.InnerDuplexSessionChannel.BeginSend(message, timeout, callback, state);
        }

        public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
        {
            this.Print("BeginSend()");
            return this.InnerDuplexSessionChannel.BeginSend(message, callback, state);
        }

        public void EndSend(IAsyncResult result)
        {
            this.Print("EndSend()");
            this.InnerDuplexSessionChannel.EndSend(result);
        }

        public EndpointAddress RemoteAddress
        {
            get { return this.InnerDuplexSessionChannel.RemoteAddress; }
        }

        public void Send(Message message, TimeSpan timeout)
        {
            this.Print("Send()");
            this.InnerDuplexSessionChannel.Send(message, timeout);
        }

        public void Send(Message message)
        {
            this.Print("Send()");
            this.InnerDuplexSessionChannel.Send(message);
        }

        public Uri Via
        {
            get { return this.InnerDuplexSessionChannel.Via; }
        }

        public IDuplexSession Session
        {
            get { return this.InnerDuplexSessionChannel.Session; }
        }
    }
}
