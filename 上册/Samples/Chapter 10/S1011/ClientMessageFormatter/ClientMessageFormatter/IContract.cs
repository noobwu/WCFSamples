using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;

namespace Artech.WebHttpModel
{
[ServiceContract(Namespace = "http://www.artech.com/")]
public interface IContract
{
    [WebInvoke( RequestFormat = WebMessageFormat.Json,BodyStyle = WebMessageBodyStyle.Wrapped)]
    [DataContractFormat]
    [DisplayClientMessageFormatter]
    void Operation1(string[] args);

    [WebInvoke(RequestFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped)]
    [DataContractFormat]
    [DisplayClientMessageFormatter]
    void Operation2(string[] args);

    [WebInvoke(RequestFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped)]
    [XmlSerializerFormat]
    [DisplayClientMessageFormatter]
    void Operation3(string[] args);
}
}