using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Artech.MessageContractOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            ContractDescription contract = ContractDescription.GetContract(typeof(IEmployeeManager));
            OperationDescription operation = contract.Operations[0];
            MessageDescription message = operation.Messages[0];
            Console.WriteLine("{0, -15}: {1}", "ProtectionLevel", message.ProtectionLevel);
            Console.WriteLine("{0, -15}: {1}", "MessageType", message.MessageType.Name);
            Console.WriteLine("{0,-15}: {1}", "Headers", message.Headers[0].Name);
            for (int i = 1; i < message.Headers.Count; i++)
            {
                Console.WriteLine("{0,-15}: {1}", "", message.Headers[i].Name);
            }
            Console.WriteLine("{0,-15}: {1}", "Body Parts", message.Body.Parts[0].Name);
            for (int i = 1; i < message.Body.Parts.Count; i++)
            {
                Console.WriteLine("{0,-15}: {1}", "", message.Body.Parts[i].Name);
            }
        }
    }
    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface IEmployeeManager
    {
        [OperationContract]
        void CreateEmployee(Employee employee);
    }
}
