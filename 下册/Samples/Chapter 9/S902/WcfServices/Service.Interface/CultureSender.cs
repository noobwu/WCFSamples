using System.Globalization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
namespace Artech.WcfServices.Service.Interface
{
    internal class CultureSender : IClientMessageInspector
    {
        private CultureMessageHeaderInfo messageHeaderInfo;
        public CultureSender(CultureMessageHeaderInfo messageHeaderInfo)
        {
            this.messageHeaderInfo = messageHeaderInfo;
        }
        public void AfterReceiveReply(ref Message reply, object correlationState) { }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            request.Headers.Add(MessageHeader.CreateHeader(this.messageHeaderInfo.CurrentCultureName, this.messageHeaderInfo.Namespace, CultureInfo.CurrentCulture.Name));
            request.Headers.Add(MessageHeader.CreateHeader(this.messageHeaderInfo.CurrentUICultureName, this.messageHeaderInfo.Namespace, CultureInfo.CurrentUICulture.Name));
            return null;
        }
    }
}
