using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;

namespace Artech.WcfServices
{
    public abstract class SimpleChannelBase : ChannelBase
    {
        protected void Print(string methodName)
        {
            Console.WriteLine("{0}.{1}", this.GetType().Name, methodName);
        }
        public ChannelBase InnerChannel { get; private set; }
        public SimpleChannelBase(ChannelManagerBase channelManager, ChannelBase innerChannel)
            : base(channelManager)
        {
            this.InnerChannel = innerChannel;
        }

        protected override void OnAbort()
        {
            this.Print("OnAbort()");
            this.InnerChannel.Abort();
        }

        protected override IAsyncResult OnBeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.Print("OnBeginClose()");
            return this.InnerChannel.BeginClose(timeout, callback, state);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            this.Print("OnBeginOpen()");
            return this.InnerChannel.BeginOpen(timeout, callback, state);
        }

        protected override void OnClose(TimeSpan timeout)
        {
            this.Print("OnClose()");
            this.InnerChannel.Close(timeout);
        }

        protected override void OnEndClose(IAsyncResult result)
        {
            this.Print("OnEndClose()");
            this.InnerChannel.EndClose(result);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            this.Print("OnEndOpen()");
            this.InnerChannel.EndOpen(result);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            this.Print("OnOpen()");
            this.InnerChannel.Open(timeout);
        }

        public override T GetProperty<T>()
        {
            return this.InnerChannel.GetProperty<T>();
        }
    }
}
