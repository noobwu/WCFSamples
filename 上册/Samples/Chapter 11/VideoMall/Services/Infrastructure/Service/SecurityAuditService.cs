using System.ServiceModel;
using Artech.VideoMall.Common;
using Artech.VideoMall.Infrastructure.BusinessComponent;
using Artech.VideoMall.Infrastructure.BusinessEntity;
using Artech.VideoMall.Infrastructure.Service.Interface;
using Microsoft.Practices.Unity.Utility;
namespace Artech.VideoMall.Infrastructure.Service
{
   [ServiceBehavior(Namespace = Constants.ServiceNamespace)]
   public  class SecurityAuditService :ServiceBase<SecurityAuditBC>, ISecurityAuditService
    {
       public SecurityAuditService(SecurityAuditBC bc)
           : base(bc)
       { }
        [OperationBehavior(TransactionScopeRequired = true)]
        public void WriteAuditEntry(SecurityAuditEntry auditEntry)
        {
            Guard.ArgumentNotNull(auditEntry, "auditEntry");
            this.Business.WriteAuditEntry(auditEntry);
        }
    }
}
