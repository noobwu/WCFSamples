using System;
using System.ServiceModel.Discovery;
using System.Threading;
namespace Artech.WcfServices.Service
{
    public class DiscoveryAsyncResult : IAsyncResult
    {
        public object AsyncState { get; private set; }
        public WaitHandle AsyncWaitHandle { get; private set; }
        public bool CompletedSynchronously { get; private set; }
        public bool IsCompleted { get; private set; }
        public EndpointDiscoveryMetadata Endpoint { get; private set; }

        public DiscoveryAsyncResult(AsyncCallback callback, object asyncState)
        {
            this.AsyncState = asyncState;
            this.AsyncWaitHandle = new ManualResetEvent(true);
            this.CompletedSynchronously = this.IsCompleted = true;
            if (callback != null)
            {
                callback(this);
            }
        }
        public DiscoveryAsyncResult(AsyncCallback callback, object asyncState, EndpointDiscoveryMetadata Endpoint)
            : this(callback, asyncState)
        {
            this.Endpoint = Endpoint;
        }
    }
}
