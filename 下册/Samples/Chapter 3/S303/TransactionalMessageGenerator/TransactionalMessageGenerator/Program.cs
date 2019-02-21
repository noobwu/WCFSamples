using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Transactions;
using System.Xml;
using System.Diagnostics;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace TransactionalMessageGenerator
{
    class Program
    {
        private const string OleTxTransactionFormatter = "System.ServiceModel.Transactions.OleTxTransactionFormatter,System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        private const string WsatTransactionFormatter10 = "System.ServiceModel.Transactions.WsatTransactionFormatter10,System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        private const string WsatTransactionFormatter11 = "System.ServiceModel.Transactions.WsatTransactionFormatter11,System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        private const string TransactionFormatter= "System.ServiceModel.Transactions.TransactionFormatter,System.ServiceModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

        static void Main(string[] args)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                WriteTransactionDataToMessage(TransactionProtocol.OleTransactions, "message.oletx.xml");
                WriteTransactionDataToMessage(TransactionProtocol.WSAtomicTransactionOctober2004, "message.wsat10.xml");
                WriteTransactionDataToMessage(TransactionProtocol.WSAtomicTransaction11, "message.wsat11.xml");
            }
        }

        public static void WriteTransactionDataToMessage(TransactionProtocol protocol, string fileName)
        {
            object transactionFormatter = null;
            if (protocol == TransactionProtocol.OleTransactions)
            {
                transactionFormatter = RefUtil.CreateInstance<object>(OleTxTransactionFormatter);
            }
            else if (protocol == TransactionProtocol.WSAtomicTransactionOctober2004)
            {
                transactionFormatter = RefUtil.CreateInstance<object>(WsatTransactionFormatter10);
            }
            else
            {
                transactionFormatter = RefUtil.CreateInstance<object>(WsatTransactionFormatter11);
            }

            Type type = Type.GetType(TransactionFormatter);
            Message message = Message.CreateMessage(MessageVersion.Default, "http://www.artech.com/writetransaction", Transaction.Current);
            RefUtil.Invoke(type,"WriteTransaction",transactionFormatter,new object[]{Transaction.Current, message});
            using (XmlWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                message.WriteMessage(writer);
            }
            Process.Start(fileName);
        }
    }
}





