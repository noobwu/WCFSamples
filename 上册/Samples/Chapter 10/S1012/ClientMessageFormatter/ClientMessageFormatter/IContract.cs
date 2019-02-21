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
        //Message & Stream
        [WebInvoke]
        [DisplayClientMessageFormatter]
        Message Operation1();

        [WebInvoke]
        [DisplayClientMessageFormatter]
        Stream Operation2();

        //Bare
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare)]
        [DataContractFormat]
        [DisplayClientMessageFormatter]
        string[] Operation3();

        [WebInvoke(ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        [XmlSerializerFormat]
        [DisplayClientMessageFormatter]
        string[] Operation4();

        [WebInvoke(ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        [DisplayClientMessageFormatter]
        void Operation5();

        //Wrapped
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [DisplayClientMessageFormatter]
        string[] Operation6();

        [WebInvoke(ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [DataContractFormat]
        [DisplayClientMessageFormatter]
        string[] Operation7();

        [WebInvoke(ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped)]
        [XmlSerializerFormat]
        [DisplayClientMessageFormatter]
        string[] Operation8();
    }
}