using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;

namespace Artech.WebHttpModel
{
    class Program
    {
        static void Main(string[] args)
        {
EndpointAddress address = new EndpointAddress("http://127.0.0.1:3721/calculatorservice");
Binding binding = new WebHttpBinding();
ContractDescription contract = ContractDescription.GetContract(typeof(ICalculator));
ServiceEndpoint endpoint = new ServiceEndpoint(contract, binding, address);
WebHttpOperationSelector operationSelector = new WebHttpOperationSelector(endpoint);

Uri addAdress       = new Uri("http://127.0.0.1:3721/calculatorservice/add/1/2");
Uri substractAdress = new Uri("http://127.0.0.1:3721/calculatorservice/substract/1/2");
Uri multiplyAdress  = new Uri("http://127.0.0.1:3721/calculatorservice/multiply/1/2");
Uri divideAdress    = new Uri("http://127.0.0.1:3721/calculatorservice/divide/1/2");

Console.WriteLine(GetOperationName(addAdress,operationSelector));
Console.WriteLine(GetOperationName(substractAdress, operationSelector));
Console.WriteLine(GetOperationName(multiplyAdress, operationSelector));
Console.WriteLine(GetOperationName(divideAdress, operationSelector));
        }

static string  GetOperationName(Uri address, IDispatchOperationSelector operationSelector)
{
    Message message = Message.CreateMessage(MessageVersion.None, "");
    message.Headers.To = address;
    HttpRequestMessageProperty messageProperty = new HttpRequestMessageProperty();
    messageProperty.Method = "GET";
    message.Properties.Add(HttpRequestMessageProperty.Name, messageProperty);
    return operationSelector.SelectOperation(ref message);
}
    }
[ServiceContract(Namespace = "http://www.artech.com")]
public interface ICalculator
{
    [WebGet(UriTemplate = "Add/{x}/{y}")]
    double Add(double x, double y);
    [WebGet(UriTemplate = "Substract/{x}/{y}")]
    double Substract(double x, double y);
    [WebGet(UriTemplate = "Multiply/{x}/{y}")]
    double Multiply(double x, double y);
    [WebGet(UriTemplate = "Divide/{x}/{y}")]
    double Divide(double x, double y);
}
}
