using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.ServiceModel;
using Artech.TransactionalService.Service.Interface;

namespace Artech.TransactionalService.Service
{
    public class BankingService : IBankingService
    {       
        [OperationBehavior(TransactionScopeRequired = true)]
        public void Transfer(string fromAccountId, string toAccountId, double amount)
        {
            try
            {
                ServiceInvoker.Invoke<IWithdrawService>(proxy => proxy.Withdraw(fromAccountId, amount), "withdrawservice");
                ServiceInvoker.Invoke<IDepositService>(proxy => proxy.Deposit(toAccountId, amount), "depositservice");
            }
            catch (Exception ex)
            {
                throw new FaultException(new FaultReason(ex.Message));
            }
        }
    }
}
