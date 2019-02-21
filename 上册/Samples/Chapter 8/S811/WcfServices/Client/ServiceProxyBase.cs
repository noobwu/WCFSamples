using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artech.WcfServices.Client
{
public abstract class ServiceProxyBase<TChannel>
{
    public OperationInvoker<TChannel> Invoker { get; private set; }
    public ServiceProxyBase(string endpointname)
    {
        this.Invoker = new OperationInvoker<TChannel>(endpointname);
    }
}
}
