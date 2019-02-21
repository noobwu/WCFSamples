using System.ServiceModel;

namespace Artech.TransactionalService.Service.Interface
{
    [ServiceContract(Namespace="http://www.artech.com/banking/")]
    public interface IDepositService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void Deposit(string accountId, double amount);
    }
}
