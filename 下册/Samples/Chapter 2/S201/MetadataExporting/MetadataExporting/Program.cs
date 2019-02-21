using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Xml;
namespace Artech.MetadataExporting
{
    class Program
    {
        static void Main(string[] args)
        {
            ContractDescription contract = ContractDescription.GetContract(typeof(IOrderService));
            EndpointAddress address1 = new EndpointAddress("http://127.0.0.1/orderservice");
            EndpointAddress address2 = new EndpointAddress("net.tcp://127.0.0.1/orderservice");
            ServiceEndpoint endpoint1 = new ServiceEndpoint(contract, new WS2007HttpBinding(), address1);
            ServiceEndpoint endpoint2 = new ServiceEndpoint(contract, new NetTcpBinding(), address2);
            XmlQualifiedName serviceName = new XmlQualifiedName("OrderService", "http://www.artech.com/services/");
            WsdlExporter exporter = new WsdlExporter();
            exporter.ExportEndpoints(new ServiceEndpoint[] { endpoint1, endpoint2 }, serviceName);
            MetadataSet metadata = exporter.GetGeneratedMetadata();
            using (XmlWriter writer = new XmlTextWriter("metadata.xml", Encoding.UTF8))
            {
                metadata.WriteTo(writer);
            }
            Process.Start("metadata.xml");
        }
    }
}
