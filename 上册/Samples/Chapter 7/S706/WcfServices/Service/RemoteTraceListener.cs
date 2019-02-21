using System;
using System.Diagnostics;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel;

namespace Artech.WcfServices.Service
{
public class RemoteTraceListener : TraceListener
{
    public ITrace Tracer { get; private set; }
    public RemoteTraceListener(string traceServiceEndpoint)
    {
        ChannelFactory<ITrace> chanenlFactory = new ChannelFactory<ITrace>(traceServiceEndpoint);
        this.Tracer = chanenlFactory.CreateChannel();
    }
    public override void Write(string message)
    {
        this.Tracer.Write(message);
    }
    public override void WriteLine(string message)
    {
        this.Tracer.WriteLine(message);
    }
}
}
