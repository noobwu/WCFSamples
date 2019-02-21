using System.ServiceModel;
namespace Artech.WcfServices.Service.Interface
{
[ServiceContract(Namespace ="http://www.artech.com/", SessionMode = SessionMode.Required)]
public interface ICalculator
{
    [OperationContract(IsInitiating = true, IsTerminating = false)]
    void Reset();
    [OperationContract(IsInitiating = false, IsTerminating = false)]
    void Add(double op);
    [OperationContract(IsInitiating = false, IsTerminating = true)]
    double GetResult();
}
}
