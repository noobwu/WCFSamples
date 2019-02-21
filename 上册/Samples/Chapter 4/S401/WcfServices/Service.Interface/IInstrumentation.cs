using System.ServiceModel;
namespace Artech.WcfServices.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface IInstrumentation: IEventLog
    {
        [OperationContract]
        void IncreasePerformanceCounter(string categoryName, string counterName);

        [OperationContract]
        void SetWmiProperty(string propertyName, object value);
    }
}
