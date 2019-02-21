using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Artech.WcfServices.Service.Interface
{
[CollectionDataContract(Namespace = "http://www.artech.com",
                        ItemName = "context",
                        KeyName = "name",
                        ValueName = "value")]
public class ApplicationContext : Dictionary<string, object>
{
    public const string HeaderName = "ApplicationContext";
    public const string Namespace = "http://www.artech.com";
    public const string PropertyName = "ApplicationContext";

    [ThreadStatic]
    private static ApplicationContext current;
    public static ApplicationContext Current
    {
        get
        {
            if (null == OperationContext.Current)
            {
                return current ;
            }
            MessageProperties incomingProperties = OperationContext.Current.IncomingMessageProperties;
            if (null != incomingProperties && incomingProperties.ContainsKey(PropertyName))
            {
                return (ApplicationContext)OperationContext.Current.IncomingMessageProperties[PropertyName];
            }
            MessageHeaders incomingHeaders = OperationContext.Current.IncomingMessageHeaders;
            if (null != incomingHeaders && incomingHeaders.FindHeader(HeaderName, Namespace) > -1)
            {
                ApplicationContext context = OperationContext.Current.IncomingMessageHeaders.GetHeader<ApplicationContext>(HeaderName, Namespace);
                OperationContext.Current.IncomingMessageProperties.Add(PropertyName, context);
                return context;
            }
            return current;
        }
        set { current = value; }
    }
}

public static class Extensions
{
    public static void AttachApplicationContext(this OperationContext context)
    {
        if (null == ApplicationContext.Current)
        {
            return;
        }
        MessageHeader<ApplicationContext> header = new MessageHeader<ApplicationContext>(ApplicationContext.Current);
        OperationContext.Current.OutgoingMessageHeaders.Add(header.GetUntypedHeader(ApplicationContext.HeaderName, ApplicationContext.Namespace));
    }
}
}
