using System;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Client
{
public partial class MonitorForm : Form
{
    private SynchronizationContext _syncContext;
    private DuplexChannelFactory<ICalculator> _channelFactory;
    private InstanceContext _callbackInstance;
    private int _clientId = 0;

    public MonitorForm()
    {
        InitializeComponent();
    }

    //其他成员
    private void MonitorForm_Load(object sender, EventArgs e)
    {
        string header = string.Format("{0, -13}{1, -22}{2}", "Client", "Time", "Event");
        this.listBoxExecutionProgress.Items.Add(header);
        _syncContext = SynchronizationContext.Current;
        _callbackInstance = new InstanceContext(new CalculatorCallbackService());
        _channelFactory = new DuplexChannelFactory<ICalculator>(_callbackInstance, "calculatorservice");

        EventMonitor.MonitoringNotificationSended += ReceiveMonitoringNotification;
        this.Disposed += delegate
        {
            EventMonitor.MonitoringNotificationSended -= ReceiveMonitoringNotification;
            _channelFactory.Close();
        };

        for (int i = 0; i < 2; i++)
        {
            ThreadPool.QueueUserWorkItem(state =>
            {
                int clientId = Interlocked.Increment(ref _clientId);
                EventMonitor.Send(clientId, EventType.StartCall);
                ICalculator proxy = _channelFactory.CreateChannel();
                using (OperationContextScope contextScope = new OperationContextScope(proxy as IContextChannel))
                {
                    MessageHeader<int> messageHeader = new MessageHeader<int>(clientId);
                    OperationContext.Current.OutgoingMessageHeaders.Add(messageHeader.GetUntypedHeader(EventMonitor.CientIdHeaderLocalName, EventMonitor.CientIdHeaderNamespace));
                    proxy.Add(1, 2);
                }
                EventMonitor.Send(clientId, EventType.EndCall);
            }, null);
        }
    }

    public void ReceiveMonitoringNotification(object sender, MonitorEventArgs args)
    {
        string message = string.Format("{0, -15}{1, -20}{2}", args.ClientId, args.EventTime.ToLongTimeString(), args.EventType);
        _syncContext.Post(state => this.listBoxExecutionProgress.Items.Add(message), null);
    }
}
}
