using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Artech.VideoMall.Common.Extensions
{
    public class ExceptionHandlingChannelFactory<TChannel>: ChannelFactory<TChannel>
    {
        public ExceptionHandlingChannelFactory(string endpointConfigurationName)
            : base(endpointConfigurationName)
        { }

        protected override void OnOpening()
        {
            foreach (OperationDescription operation in this.Endpoint.Contract.Operations)
            {
                FaultDescription fault = new FaultDescription(ServiceExceptionDetail.FaultAction);
                fault.DetailType = typeof(ServiceExceptionDetail);
                operation.Faults.Add(fault);
            }
            base.OnOpening();
        }
    }
}
