using System.ServiceModel;

namespace Artech.TransactionalService.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/banking/")]
    public interface IWithdrawService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Mandatory)]
        void Withdraw(string accountId, double amount);
    }
}
