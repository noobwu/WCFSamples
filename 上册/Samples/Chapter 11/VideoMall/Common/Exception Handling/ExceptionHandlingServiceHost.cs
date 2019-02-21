using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Artech.VideoMall.Common.Extensions
{
    public class ExceptionHandlingServiceHost : ServiceHost
    {
        public ExceptionHandlingServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        { }

        protected override void OnOpening()
        {
            foreach (ServiceEndpoint endpoint in this.Description.Endpoints)
            {
                foreach (OperationDescription operation in endpoint.Contract.Operations)
                { 
                    FaultDescription fault = new FaultDescription(ServiceExceptionDetail.FaultAction);
                    fault.DetailType = typeof(ServiceExceptionDetail);
                    operation.Faults.Add(fault);
                }
            }
            base.OnOpening();
        }
    }
}
