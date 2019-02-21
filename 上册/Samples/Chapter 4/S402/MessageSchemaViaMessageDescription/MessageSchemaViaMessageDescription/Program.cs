using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace MessageSchemaViaMessageDescription
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ICalculator1");
            ContractDescription contract = ContractDescription.GetContract(typeof(ICalculator1));
            ShowOperationMessages(contract.Operations[0]);

            Console.WriteLine("\nICalculator2");
            contract = ContractDescription.GetContract(typeof(ICalculator2));
            ShowOperationMessages(contract.Operations[0]);

            Console.WriteLine("\nICalculator3");
            contract = ContractDescription.GetContract(typeof(ICalculator3));
            ShowOperationMessages(contract.Operations[0]);

            Console.WriteLine("\nICalculator4");
            contract = ContractDescription.GetContract(typeof(ICalculator4));
            ShowOperationMessages(contract.Operations[0]);
        }

        private static void ShowOperationMessages(OperationDescription operation)
        {
            MessageDescription inputMessage = operation.Messages[0];
            ShowMessageBody(inputMessage);
            if (operation.Messages.Count == 2)
            {
                MessageDescription outputMessage = operation.Messages[1];
                ShowMessageBody(outputMessage);
            }
            else
            {
                Console.WriteLine("无回复消息");
            }

        }
        static void ShowMessageBody(MessageDescription message)
        {
            Console.WriteLine(message.Direction == MessageDirection.Input ?"请求消息：" : "回复消息：");
            MessageBodyDescription body = message.Body;
            Console.WriteLine("<tns:{0} xmlns:tns=\"{1}\">", body.WrapperName,body.WrapperNamespace);
            foreach (var part in body.Parts)
            {
                Console.WriteLine("\t<tns:{0}>...</tns:{0}>", part.Name);
            }
            if (null != body.ReturnValue)
            {
                Console.WriteLine("\t<tns:{0}>...</tns:{0}>",
                    body.ReturnValue.Name);
            }
            Console.WriteLine("</tns:{0}>", body.WrapperName);
        }
    }

    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface ICalculator1
    {
        [OperationContract]
        double Add(double x, double y);
    }
    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface ICalculator2
    {
        [OperationContract]
        void Add(double x, double y, out double result);
    }

    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface ICalculator3
    {
        [OperationContract]
        void Add(ref double x, ref double y, out double result);
    }
    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface ICalculator4
    {
        [OperationContract(IsOneWay = true)]
        void Add(double x, double y);
    }
}