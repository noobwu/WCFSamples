using System.ServiceModel;

namespace Artech.TransactionalService.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/banking/")]
    public interface IBankingService
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void Transfer(string fromAccountId, string toAccountId, double amount);
    }
}