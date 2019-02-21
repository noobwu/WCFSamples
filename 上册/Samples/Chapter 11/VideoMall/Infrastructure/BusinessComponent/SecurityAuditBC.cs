using Artech.VideoMall.Common;
using Artech.VideoMall.Infrastructure.BusinessEntity;
using Artech.VideoMall.Infrastructure.DataAccess;
namespace Artech.VideoMall.Infrastructure.BusinessComponent
{
    public class SecurityAuditBC: BusinessComponentBase<SecurityAuditDA>
    {
        public SecurityAuditBC(SecurityAuditDA da)
            : base(da)
        { }

        public void WriteAuditEntry(SecurityAuditEntry auditEntry)
        {
            string category = "";
            switch (auditEntry.AuditType)
            {
                case SecurityAuditType.AuthenticationSuccess:
                    {
                        category = "认证成功";
                        break;
                    }
                case SecurityAuditType.AuthenticationFailure:
                    {
                        category = "认证失败";
                        break;
                    }
                case SecurityAuditType.AuthorizationSuccess:
                    {
                        category = "授权成功";
                        break;
                    }
                case SecurityAuditType.AuthorizationFailure:
                    {
                        category = "授权失败";
                        break;
                    }
            }
            this.DataAccess.WriteAuditEntry(auditEntry.Id, category, auditEntry.IPAddress, auditEntry.Message);
        }
    }
}
