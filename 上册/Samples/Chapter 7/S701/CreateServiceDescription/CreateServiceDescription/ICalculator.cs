using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CreateServiceDescription
{
[ServiceContract(Namespace = "http://www.artech.com", ConfigurationName = "ICalculator1")]
[SimpleContractBehavior]
public interface ICalculator1
{
    [OperationContract]
    double Add(double x, double y);
    [OperationContract]
    double Substract(double x, double y);
}

[ServiceContract(Namespace = "http://www.artech.com", ConfigurationName = "ICalculator2")]
[SimpleContractBehavior]
public interface ICalculator2
{
    [OperationContract]
    [SimpleOperationBehavior]
    double Multiply(double x, double y);
    [OperationContract]
    double Divide(double x, double y);
}
}
