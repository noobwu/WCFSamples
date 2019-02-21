using System.ServiceModel;
using System.ServiceModel.Description;
namespace Artech.ServiceMetadataBehaviorSimulator
{
    [MessageContract(IsWrapped = false)]
    public class MetadataMessage
    {
        public MetadataMessage(MetadataSet metadata)
        {
            this.Metadata = metadata;
        }
        [MessageBodyMember(Name = "Metadata", 
                           Namespace = "http://schemas.xmlsoap.org/ws/2004/09/mex")]
        public MetadataSet Metadata { get; set; }
    }
}
