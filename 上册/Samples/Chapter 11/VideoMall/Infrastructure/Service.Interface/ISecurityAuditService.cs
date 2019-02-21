using System.ServiceModel;
using Artech.VideoMall.Common;
using Artech.VideoMall.Infrastructure.BusinessEntity;
namespace Artech.VideoMall.Infrastructure.Service.Interface
{
    [ServiceContract(Namespace = Constants.ServiceContractNamespace)]
    public interface ISecurityAuditService
    {
        [OperationContract]
        void WriteAuditEntry(SecurityAuditEntry auditEntry);
    }
}
