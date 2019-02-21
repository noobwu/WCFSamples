using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artech.TransactionalService.Service.Interface;
using System.ServiceModel;

namespace Artech.TransactionalService.Service
{
    public class DepositService : IDepositService
    {
        public void Deposit(string accountId, double amount)
        {
            Guard.ArgumentNotNullOrEmpty(accountId, "accountId");
            Guard.ArgumenGreaterThanZero(amount, "amount");

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("id", accountId);
            parameters.Add("amount", amount);

            try
            {
                DbAccessUtil.ExecuteNonQuery("P_DEPOSIT", parameters);
            }
            catch (Exception ex)
            {
                throw new FaultException(new FaultReason(ex.Message));
            }
        }
    }
}
