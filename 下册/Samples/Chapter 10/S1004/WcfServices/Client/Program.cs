using System;
using System.ServiceModel;
using System.ServiceModel.Discovery;
namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            AnnouncementService announcementService = new AnnouncementService();
            announcementService.OnlineAnnouncementReceived += (sender, e) =>
            {
                string contractTypes = string.Empty;
                Console.WriteLine("Receive Service Online Announcement.");
                Console.WriteLine("\tAddress: {0}", e.EndpointDiscoveryMetadata.Address.Uri);
                Console.WriteLine("\tContract: {0}", e.EndpointDiscoveryMetadata.ContractTypeNames[0]);
            };
            announcementService.OfflineAnnouncementReceived += (sender, e) =>
            {
                string contractTypes = string.Empty;
                Console.WriteLine("Receive Service Offline Announcement.");
                Console.WriteLine("\tAddress: {0}", e.EndpointDiscoveryMetadata.Address.Uri);
                Console.WriteLine("\tContract: {0}", e.EndpointDiscoveryMetadata.ContractTypeNames[0]);
            };
            using (ServiceHost host = new ServiceHost(announcementService))
            {
                host.Open();
                Console.Read();
            }
        }
    }
}
