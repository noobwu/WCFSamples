using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CreateServiceDescription
{
[ServiceBehavior(Namespace = "http://www.artech.com", ConfigurationName = "CalculatorService")]
[SimpleServiceBehavior]
public class CalculatorService : ICalculator1, ICalculator2
{
    [SimpleOperationBehavior]
    public double Add(double x, double y)
    {
        throw new NotImplementedException();
    }

    public double Substract(double x, double y)
    {
        throw new NotImplementedException();
    }

    public double Multiply(double x, double y)
    {
        throw new NotImplementedException();
    }

    public double Divide(double x, double y)
    {
        throw new NotImplementedException();
    }
}
}
