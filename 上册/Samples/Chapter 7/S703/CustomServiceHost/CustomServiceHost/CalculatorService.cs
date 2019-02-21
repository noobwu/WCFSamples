using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Artech.CustomServiceHost
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double x, double y);
    }
    public class CalculatorService : ICalculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
    }
}
