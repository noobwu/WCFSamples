using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Artech.WcfServices.Client
{
    public class CalculatorClient : ClientBase<ICalculator>, ICalculator
    {
        public CalculatorClient(string endpointConfigurationName)
            : base(endpointConfigurationName)
        { }

        public CalculatorClient(Binding binding, EndpointAddress remoteAddress)
            : base(binding, remoteAddress)
        { }

        public double Add(double x, double y)
        {
            return this.Channel.Add(x, y);
        }
    }
}
