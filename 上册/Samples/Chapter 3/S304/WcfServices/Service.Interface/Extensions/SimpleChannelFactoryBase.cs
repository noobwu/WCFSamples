using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace Artech.WcfServices
{
public abstract class SimpleChannelFactoryBase<TChannel>: ChannelFactoryBase<TChannel>
{
    protected void Print(string methodName)
    {
        Console.WriteLine("{0}.{1}", this.GetType().Name, methodName);
    }
    public IChannelFactory<TChannel> InnerChannelFactory{ get; private set; }
    public SimpleChannelFactoryBase(BindingContext context)
    {
        this.InnerChannelFactory = context.BuildInnerChannelFactory<TChannel>();
    }
    protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
    {
        this.Print("OnBeginOpen()");
        return this.InnerChannelFactory.BeginOpen(timeout, callback,state);
    }

    protected override void OnEndOpen(IAsyncResult result)
    {
        this.Print("OnEndOpen()");
        this.InnerChannelFactory.EndOpen(result);
    }

    protected override void OnOpen(TimeSpan timeout)
    {
        this.Print("OnOpen()");
        this.InnerChannelFactory.Open(timeout);
    }

    public override T GetProperty<T>()
    {
        return this.InnerChannelFactory.GetProperty<T>();
    }
}
}
