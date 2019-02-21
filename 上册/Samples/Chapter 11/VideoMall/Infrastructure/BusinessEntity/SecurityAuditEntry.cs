using System.Runtime.Serialization;
using Artech.VideoMall.Common;
using Microsoft.Practices.Unity.Utility;
namespace Artech.VideoMall.Infrastructure.BusinessEntity
{
    [DataContract(Namespace = Constants.DataContractNamespace)]
    public class SecurityAuditEntry
    {
        [DataMember]
        public string Id { get; private set; }
        [DataMember]
        public SecurityAuditType AuditType { get; set; }
        [DataMember]
        public string IPAddress { get; set; }
        [DataMember]
        public string Message { get; set; }

        public SecurityAuditEntry(string id, SecurityAuditType auditType, string ipAddress="")
        {
            Guard.ArgumentNotNullOrEmpty(id, "id");
            this.Id = id;
            this.AuditType = auditType;
            this.IPAddress = ipAddress;
        }
    }
}
