using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Artech.VideoMall.Common.Extensions
{
[DataContract(Namespace = "http://www.artech.com/")]
public class ServiceExceptionDetail : ExceptionDetail
{
    public const string FaultSubCodeNamespace = "http://www.artech.com/exceptionhandling/";
    public const string FaultSubCodeName = "ServiceError";
    public const string FaultAction = "http://www.artech.com/fault";

    [DataMember]
    public string AssemblyQualifiedName { get; private set; }
    [DataMember]
    public new ServiceExceptionDetail InnerException { get; private set; }

    public ServiceExceptionDetail(Exception ex)
        : base(ex)
    {
        this.AssemblyQualifiedName = ex.GetType().AssemblyQualifiedName;
        if (null != ex.InnerException)
        {
            this.InnerException = new ServiceExceptionDetail(ex.InnerException);
        }
    }
    public override string ToString()
    {
        return this.Message;
    }
}
}
