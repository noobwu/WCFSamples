using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Microsoft.Practices.Unity.Utility;

namespace Artech.VideoMall.Common.Extensions
{
    public class OperationInvoker
    {
        public static void Invoke<TChanne>(Action<TChanne> serviceInvocation,TChanne channel)
        {
            Guard.ArgumentNotNull(serviceInvocation, "serviceInvocation");
            Guard.ArgumentNotNull(channel, "channel");

            ICommunicationObject communicationObject = (ICommunicationObject)channel;
            try
            {
                serviceInvocation(channel);
                communicationObject.Close();
            }
            catch (Exception ex)
            {
                HandleException(ex, communicationObject);
            }
        }
        public static TResult Invoke<TChanne, TResult>(Func<TChanne, TResult> serviceInvocation, TChanne channel)
        {
            Guard.ArgumentNotNull(serviceInvocation, "serviceInvocation");
            Guard.ArgumentNotNull(channel, "channel");

            ICommunicationObject communicationObject = (ICommunicationObject)channel;
            TResult result = default(TResult);
            try
            {
                result = serviceInvocation(channel);
                communicationObject.Close();
            }
            catch (Exception ex)
            {
                HandleException(ex, communicationObject);
            }
            return result;
        }
        public static void HandleException(Exception ex,ICommunicationObject channel)
        {
            Guard.ArgumentNotNull(ex, "ex");
            Guard.ArgumentNotNull(channel, "channel");

            if (ex is TimeoutException || ex is CommunicationException)
            {
                channel.Abort();
            }
            FaultException<ServiceExceptionDetail> faultException = ex as FaultException<ServiceExceptionDetail>;
            if (faultException != null)
            {
                ex = GetException(faultException.Detail); 
            }
            throw ex;
        }

        private static Exception GetException(ServiceExceptionDetail exceptionDetail)
        {
            Type exceptionType = Type.GetType(exceptionDetail.AssemblyQualifiedName);
            if (null == exceptionDetail.InnerException)
            {
                return (Exception)Activator.CreateInstance(exceptionType, exceptionDetail.Message);
            }
            Exception innerException = GetException(exceptionDetail.InnerException);
            return (Exception)Activator.CreateInstance(exceptionType,exceptionDetail.Message, innerException);
        }
    }
}
