using System.ServiceModel.Channels;
using System.ServiceModel.Description;
namespace Artech.ServiceMetadataBehaviorSimulator
{
    public class MetadataProvisionService : IMetadataProvisionService, IHttpGetMetadata
    {
        public MetadataSet Metadata{ get; private set; }
        public MetadataProvisionService(MetadataSet metadata)
        {
            this.Metadata = metadata;
        }
        public Message Get(Message request)
        {
            MetadataMessage message = new MetadataMessage(this.Metadata);
            string action = "http://schemas.xmlsoap.org/ws/2004/09/transfer/GetResponse";
            TypedMessageConverter converter = TypedMessageConverter.Create(typeof(MetadataMessage), action);
            return converter.ToMessage(message, request.Version);
        }
    }
}