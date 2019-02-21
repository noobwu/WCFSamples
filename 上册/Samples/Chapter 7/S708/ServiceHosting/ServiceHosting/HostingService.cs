using System.ServiceProcess;
using Artech.BatchingHosting;
namespace Artech.ServiceHosting
{
partial class HostingService : ServiceBase
{
    public ServiceHostCollection ServiceHosts { get; private set; }

    public HostingService()
    {
        InitializeComponent();
    }
    protected override void OnStart(string[] args)
    {
        this.ServiceHosts = new ServiceHostCollection();
        this.ServiceHosts.Open();
    }
    protected override void OnStop()
    {
        this.ServiceHosts.Dispose();
        this.ServiceHosts = null;
    }
}
}
