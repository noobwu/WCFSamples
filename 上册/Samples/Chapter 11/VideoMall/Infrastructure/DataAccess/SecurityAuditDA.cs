using Artech.VideoMall.Common;
namespace Artech.VideoMall.Infrastructure.DataAccess
{
    public class SecurityAuditDA: DataAccessBase
    {
        public void WriteAuditEntry(string id, string category, string ipAddress, string message)
        {
            this.Helper.ExecuteNonQuery("P_SECURITY_AUDIT_I", id, category, ipAddress, message);
        }
    }
}
