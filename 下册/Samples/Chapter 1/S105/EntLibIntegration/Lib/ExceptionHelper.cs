using System;
using System.ServiceModel;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace Artech.EntLibIntegration
{
   public static class ExceptionHelper
   {
       public static bool HandleException(Exception ex,string exceptionPolicy)
       {
           FaultException<ServiceExceptionDetail> faultException = ex as FaultException<ServiceExceptionDetail>;
           if (faultException != null)
           {
               ex = GetException(faultException.Detail);               
           }
           return ExceptionPolicy.HandleException(ex, exceptionPolicy);
       }
       public static Exception GetException(ServiceExceptionDetail exceptionDetail)
       {
           Type exceptionType = Type.GetType(exceptionDetail.AssemblyQualifiedName);
           if (null == exceptionDetail.InnerException)
           {              
               return (Exception)Activator.CreateInstance(exceptionType, exceptionDetail.Message);
           }

           Exception innerException = GetException(exceptionDetail.InnerException);
           return (Exception)Activator.CreateInstance(exceptionType, exceptionDetail.Message, innerException);
       }
    }
}