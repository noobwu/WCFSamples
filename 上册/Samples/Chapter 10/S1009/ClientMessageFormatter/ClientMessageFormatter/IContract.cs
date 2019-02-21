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
    void Operation1(Message stream);

    [WebInvoke]
    [DisplayClientMessageFormatter]
    void Operation2(Stream stream);
}
}



 


