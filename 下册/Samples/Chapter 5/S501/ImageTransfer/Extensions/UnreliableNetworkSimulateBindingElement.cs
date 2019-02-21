using System.ServiceModel.Channels;
namespace Artech.ImageTransfer.Extensions
{
    public class UnreliableNetworkSimulateBindingElement : BindingElement
    {
        public int DropRate { get; set; }

        public UnreliableNetworkSimulateBindingElement(int dropRate)
        {
            this.DropRate = dropRate;
        }

        public override BindingElement Clone()
        {
            return new UnreliableNetworkSimulateBindingElement(this.DropRate);
        }

        public override T GetProperty<T>(BindingContext context)
        {
            return context.GetInnerProperty<T>();
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            return (IChannelFactory<TChannel>)new UnreliableNetworkSimulateChannelFactory<TChannel>(context, this.DropRate);
        }
    }
}
