namespace Artech.VideoMall.Infrastructure.Interface
{
    public interface ISecurityAudit
    {
        void AuditForAuthenticationSuccess(string userName);
        void AuditForAuthenticationFailure(string userName);
    }
}