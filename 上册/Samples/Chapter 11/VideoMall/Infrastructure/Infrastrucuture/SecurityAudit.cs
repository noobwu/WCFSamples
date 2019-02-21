using System;
using System.Web;
using Artech.VideoMall.Infrastructure.BusinessEntity;
using Artech.VideoMall.Infrastructure.Interface;
using Artech.VideoMall.Infrastructure.Service.Interface;
namespace Artech.VideoMall.Infrastructure
{
    public class SecurityAudit : ISecurityAudit
    {
        public ISecurityAuditService SecurityAuditProxy { get; private set; }

        public SecurityAudit(ISecurityAuditService securityAuditProxy)
        {
            this.SecurityAuditProxy = securityAuditProxy;
        }
        public void AuditForAuthenticationSuccess(string userName)
        {
            string ipAddress = HttpContext.Current.Request.UserHostAddress;
            SecurityAuditEntry auditEntry = new SecurityAuditEntry(Guid.NewGuid().ToString(), SecurityAuditType.AuthenticationSuccess, ipAddress);
            auditEntry.Message = string.Format("用户\"{0}\"成功登录",userName);
            this.SecurityAuditProxy.WriteAuditEntry(auditEntry);
        }
        public void AuditForAuthenticationFailure(string userName)
        {
            string ipAddress = HttpContext.Current.Request.UserHostAddress;
            SecurityAuditEntry auditEntry = new SecurityAuditEntry(Guid.NewGuid().ToString(), SecurityAuditType.AuthenticationFailure, ipAddress);
            auditEntry.Message = string.Format("用户\"{0}\"登录失败", userName);
            this.SecurityAuditProxy.WriteAuditEntry(auditEntry);
        }
    }
}
