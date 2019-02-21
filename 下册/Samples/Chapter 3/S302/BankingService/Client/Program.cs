using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.TransactionalService.Service.Interface;
using System.Transactions;

namespace Artech.TransactionalService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string fromAccountId = "123456789";
            string toAccountId = "987654321";
            double amount = 1000;
            using (TransactionScope transactionScope = new TransactionScope())
            {
                ServiceInvoker.Invoke<IWithdrawService>(proxy => proxy.Withdraw(fromAccountId, amount), "withdrawservice");
                ServiceInvoker.Invoke<IDepositService>(proxy => proxy.Deposit(toAccountId, amount), "depositservice");
                transactionScope.Complete();
            }
        }
    }
}