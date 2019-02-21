using Artech.VideoMall.Common;
using Artech.VideoMall.Infrastructure.BusinessEntity;
using Artech.VideoMall.Infrastructure.Service.Interface;
namespace Artech.VideoMall.Infrastructure
{
    public class SecurityAuditProxy : ServiceProxyBase<ISecurityAuditService>, ISecurityAuditService
    {
        public SecurityAuditProxy()
            : base("securityAuditService")
        { }
        public void WriteAuditEntry(SecurityAuditEntry auditEntry)
        {
            this.Invoker.Invoke(proxy=>proxy.WriteAuditEntry(auditEntry));
        }
    }
}
