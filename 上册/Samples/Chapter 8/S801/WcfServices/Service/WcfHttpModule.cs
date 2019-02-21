using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Channels;
using Artech.WcfServices.Service.Interface;
using System.Text;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Artech.WcfServices.Service
{
public class WcfHttpModule: IHttpModule
{
    public void Dispose() {}

    public void Init(HttpApplication context)
    {
        context.BeginRequest += (sender, args) =>
            {
                string relativeAddress = HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.Remove(0,2);
                Type serviceType = RouteTable.Routes.Find(relativeAddress);
                if (null == serviceType)
                {
                    return;
                }
                IHttpHandler handler = this.CreateHttpHandler(serviceType);
                context.Context.RemapHandler(handler);
            };
    }
    protected IHttpHandler CreateHttpHandler(Type serviceType)
    {
        MessageEncoderFactory encoderFactory = ComponentBuilder.GetMessageEncoderFactory(MessageVersion.Default, Encoding.UTF8);
        WcfHandler handler = new WcfHandler(serviceType, encoderFactory);
        Type interfaceType = serviceType.GetInterfaces()[0];
        ContractDescription contract = ContractDescription.GetContract(interfaceType);
        foreach (OperationDescription operation in contract.Operations)
        {
            IDispatchMessageFormatter messageFormatter = (IDispatchMessageFormatter)ComponentBuilder.GetFormatter(operation, false);
            handler.MessageFormatters.Add(operation.Messages[0].Action, messageFormatter);

            IOperationInvoker operationInvoker = ComponentBuilder.GetOperationInvoker(operation.SyncMethod);
            handler.OperationInvokers.Add(operation.Messages[0].Action, operationInvoker);

            handler.Methods.Add(operation.Messages[0].Action, operation.SyncMethod);
        }
        return handler;
    }
}
}