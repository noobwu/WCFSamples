using System;
using System.ServiceModel.Channels;
using Artech.ServiceMetadataBehaviorSimulator;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Service
{
    [ServiceMetadataBehavior]
    public class CalculatorService : ICalculator, IMetadataProvisionService
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public Message Get(Message request)
        {
            throw new NotImplementedException();
        }
    }
}
