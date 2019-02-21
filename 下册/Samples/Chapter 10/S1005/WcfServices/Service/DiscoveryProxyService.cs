using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
namespace Artech.WcfServices.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                     ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DiscoveryProxyService : DiscoveryProxy
    {
        public IDictionary<EndpointAddress, EndpointDiscoveryMetadata> Endpoints { get; private set; }
        public DiscoveryProxyService()
        {
            this.Endpoints = new Dictionary<EndpointAddress, EndpointDiscoveryMetadata>();
        }

        //Find(Probe)
        protected override IAsyncResult OnBeginFind(FindRequestContext findRequestContext, AsyncCallback callback, object state)
        {
            var endpoints = from item in this.Endpoints
                            where findRequestContext.Criteria.IsMatch(item.Value)
                            select item.Value;
            foreach (var endppint in endpoints)
            {
                findRequestContext.AddMatchingEndpoint(endppint);
            }
            return new DiscoveryAsyncResult(callback, state);
        }
        protected override void OnEndFind(IAsyncResult result) {}

        //Resolve
        protected override IAsyncResult OnBeginResolve(ResolveCriteria resolveCriteria, AsyncCallback callback, object state)
        {
            EndpointDiscoveryMetadata endpoint = null;
            if (this.Endpoints.ContainsKey(resolveCriteria.Address))
            {
                endpoint = this.Endpoints[resolveCriteria.Address];
            }
            return new DiscoveryAsyncResult(callback, endpoint);
        }
        protected override EndpointDiscoveryMetadata OnEndResolve(IAsyncResult result)
        {
            return ((DiscoveryAsyncResult)result).Endpoint;
        }

        //OnlineAnnouncement
        protected override IAsyncResult OnBeginOnlineAnnouncement(DiscoveryMessageSequence messageSequence, EndpointDiscoveryMetadata endpointDiscoveryMetadata, AsyncCallback callback, object state)
        {
            this.Endpoints[endpointDiscoveryMetadata.Address] = endpointDiscoveryMetadata;
            return new DiscoveryAsyncResult(callback, state);
        }
        protected override void OnEndOnlineAnnouncement(IAsyncResult result) {}

        //OfflineAnnouncement
        protected override IAsyncResult OnBeginOfflineAnnouncement(DiscoveryMessageSequence messageSequence, EndpointDiscoveryMetadata endpointDiscoveryMetadata, AsyncCallback callback, object state)
        {
            if (this.Endpoints.ContainsKey(endpointDiscoveryMetadata.Address))
            {
                this.Endpoints.Remove(endpointDiscoveryMetadata.Address);
            }
            return new DiscoveryAsyncResult(callback, state);
        }
        protected override void OnEndOfflineAnnouncement(IAsyncResult result) {}
    }
}
