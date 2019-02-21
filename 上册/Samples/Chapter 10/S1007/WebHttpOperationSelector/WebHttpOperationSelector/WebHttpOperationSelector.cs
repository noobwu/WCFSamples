using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace Artech.WebHttpModel
{
public class WebHttpOperationSelector:IDispatchOperationSelector
{
    public IDictionary<string, UriTemplateTable> UriTemplateTables { get; private set; }
    public WebHttpOperationSelector(ServiceEndpoint endpoint)
    {
        this.UriTemplateTables = new Dictionary<string, UriTemplateTable>();
        Uri baseAddress = endpoint.Address.Uri;
        foreach (var operation in endpoint.Contract.Operations)
        {
            WebGetAttribute webGet = operation.Behaviors.Find<WebGetAttribute>();
            WebInvokeAttribute webInvoke = operation.Behaviors.Find<WebInvokeAttribute>();
            string method = (null != webGet) ? "GET" : webInvoke.Method;
            UriTemplateTable uriTemplateTable;
            if (!this.UriTemplateTables.TryGetValue(method, out uriTemplateTable))
            {
                uriTemplateTable = new UriTemplateTable(baseAddress);
                this.UriTemplateTables.Add(method, uriTemplateTable);
            }
            string template = (null != webGet)?webGet.UriTemplate:webInvoke.UriTemplate;
            uriTemplateTable.KeyValuePairs.Add(new KeyValuePair<UriTemplate, object>(new UriTemplate(template), operation.Name));
        }
    }
    public string SelectOperation(ref Message message)
    {
        if (!message.Properties.ContainsKey(HttpRequestMessageProperty.Name))
        {
            return "";
        }
        HttpRequestMessageProperty messageProperty = (HttpRequestMessageProperty)message.Properties[HttpRequestMessageProperty.Name];

        var address = message.Headers.To;
        var method = messageProperty.Method;
        UriTemplateTable uriTemplateTable = null;
        if(!this.UriTemplateTables.TryGetValue(method, out uriTemplateTable))
        {
            return "";
        }

        UriTemplateMatch match = uriTemplateTable.MatchSingle(address);
        if(null == match)
        {
            return "";
        }
        return match.Data.ToString();
    }
}
}
