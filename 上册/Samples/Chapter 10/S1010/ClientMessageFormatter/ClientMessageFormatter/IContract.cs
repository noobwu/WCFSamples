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
    [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare)]
    [DataContractFormat]
    [DisplayClientMessageFormatter]
    void Operation1(string[] args);

    [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare)]
    [XmlSerializerFormat]
    [DisplayClientMessageFormatter]
    void Operation2(string[] args);

    [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare)]
    [XmlSerializerFormat]
    [DisplayClientMessageFormatter]
    void Operation3();

    [WebInvoke(UriTemplate="Op4/{arg}",BodyStyle = WebMessageBodyStyle.Bare)]
    [DisplayClientMessageFormatter]
    void Operation4(string arg);
}
}



 


