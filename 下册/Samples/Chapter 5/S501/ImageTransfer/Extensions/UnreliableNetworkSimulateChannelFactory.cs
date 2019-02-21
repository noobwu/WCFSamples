using System;
using System.ServiceModel.Channels;
using System.ServiceModel;
namespace Artech.ImageTransfer.Extensions
{
    public class UnreliableNetworkSimulateChannelFactory<TChannel> : ChannelFactoryBase<IDuplexSessionChannel>
    {
        public int DropRate
        {get; private set;}

        public IChannelFactory<TChannel> InnerChannelFactory
        { get; private set; }

        public UnreliableNetworkSimulateChannelFactory(BindingContext context, int dropRate):base(context.Binding)
        {
            this.InnerChannelFactory = context.BuildInnerChannelFactory<TChannel>();
            this.DropRate = dropRate;
        }

        protected override IDuplexSessionChannel OnCreateChannel(EndpointAddress address, Uri via)
        {
            var innerChannel = (IDuplexSessionChannel)this.InnerChannelFactory.CreateChannel(address, via);
            return new UnreliableNetworkSimulateChannel(innerChannel,this.DropRate);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.InnerChannelFactory.BeginOpen(timeout, callback, state);
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            this.InnerChannelFactory.EndOpen(result);
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            this.InnerChannelFactory.Open(timeout);
        }
    }
}