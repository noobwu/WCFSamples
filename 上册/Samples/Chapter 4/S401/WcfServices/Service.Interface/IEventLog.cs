using System.Diagnostics;
using System.ServiceModel;
namespace Artech.WcfServices.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface IEventLog
    {
        [OperationContract]
        void WriteEntry(string source, string message, EventLogEntryType type, int eventID, short category);
    }
}