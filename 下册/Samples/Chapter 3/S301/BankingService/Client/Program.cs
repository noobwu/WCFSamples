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
            string tooAccountId = "987654321";
            double amount = 1000;
            ServiceInvoker.Invoke<IBankingService>(proxy => proxy.Transfer(fromAccountId, tooAccountId, amount), "bankingservice");
        }
    }
}