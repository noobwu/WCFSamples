using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Artech.WebHttpModel
{   

[ServiceContract(Namespace = "http://www.artech.com/")]
public interface IContract
{
    [WebInvoke]
    [DisplayClientMessageFormatter]
    void Operation1(Stream stream);

    [WebInvoke(RequestFormat = WebMessageFormat.Json)]
    [DisplayClientMessageFormatter]
    void Operation2(string[] args);

        [WebInvoke(RequestFormat = WebMessageFormat.Xml)]
    [DisplayClientMessageFormatter]
    void Operation3(string[] args);
}
}