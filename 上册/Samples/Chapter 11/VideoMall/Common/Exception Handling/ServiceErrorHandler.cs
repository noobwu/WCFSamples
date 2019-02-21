using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.Unity.Utility;

namespace Artech.VideoMall.Common.Extensions
{
    public class ServiceErrorHandler : IErrorHandler
    {
        public string ExceptionPolicyName { get; private set; }

        public ServiceErrorHandler(string exceptionPolicyName)
        {
            Guard.ArgumentNotNullOrEmpty(exceptionPolicyName, "exceptionPolicyName");
            this.ExceptionPolicyName = exceptionPolicyName;
        }
        public bool HandleError(Exception error)
        {
            return false;
        }
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (typeof(FaultException).IsInstanceOfType(error))
            {
                return;
            }
            try
            {
                if (ExceptionPolicy.HandleException(error, this.ExceptionPolicyName))
                {
                    fault = Message.CreateMessage(version, BuildFault(error), ServiceExceptionDetail.FaultAction);
                }
            }
            catch (Exception ex)
            {
                fault = Message.CreateMessage(version, BuildFault(ex), ServiceExceptionDetail.FaultAction);
            }
        }
        private MessageFault BuildFault(Exception error)
        {
            ServiceExceptionDetail exceptionDetail = new ServiceExceptionDetail(error);
            FaultCode code = FaultCode.CreateReceiverFaultCode(ServiceExceptionDetail.FaultSubCodeName,ServiceExceptionDetail.FaultSubCodeNamespace);
            return MessageFault.CreateFault(code, new FaultReason(error.Message),exceptionDetail);
        }
    }
}
