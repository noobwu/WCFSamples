using System;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.ObjectBuilder2;
namespace Artech.EntLibIntegration.Client
{
    [ConfigurationElementType(typeof(ErrorReportingHandlerData))]
    public class ErrorReportingHandler : IExceptionHandler
    {
        public Exception HandleException(Exception exception, Guid handlingInstanceId)
        {            
            Console.WriteLine("{0}[{1}]",exception.Message, exception.GetType().FullName);
            return exception;
        }
    }
    [Assembler(typeof(ErrorReportingHandlerAssembler))]
    public class ErrorReportingHandlerData : ExceptionHandlerData
    {
        public ErrorReportingHandlerData() { }
        public ErrorReportingHandlerData(string name, Type type)
            : base(name, type){}
    }
    public class ErrorReportingHandlerAssembler : IAssembler<IExceptionHandler, ExceptionHandlerData>
    {
        public IExceptionHandler Assemble(IBuilderContext context, ExceptionHandlerData objectConfiguration, IConfigurationSource configurationSource, ConfigurationReflectionCache reflectionCache)
        {
            ErrorReportingHandlerData handlerData = (ErrorReportingHandlerData)objectConfiguration;
            return new ErrorReportingHandler();
        }
    }
}