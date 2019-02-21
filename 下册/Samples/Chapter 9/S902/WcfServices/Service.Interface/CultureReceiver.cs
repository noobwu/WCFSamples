using System.Globalization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading;
namespace Artech.WcfServices.Service.Interface
{
    internal class CultureReceiver : ICallContextInitializer
    {
        public CultureMessageHeaderInfo messageHeaderInfo;
        public CultureReceiver(CultureMessageHeaderInfo messageHeaderInfo)
        {
            this.messageHeaderInfo = messageHeaderInfo;
        }

        public void AfterInvoke(object correlationState)
        {
            CultureInfo[] cultureInfos = correlationState as CultureInfo[];
            if (null != cultureInfos)
            {
                Thread.CurrentThread.CurrentCulture = cultureInfos[0];
                Thread.CurrentThread.CurrentUICulture = cultureInfos[1];
            }
        }

        public object BeforeInvoke(InstanceContext instanceContext, IClientChannel channel, Message message)
        {
            CultureInfo[] originalCulture = new CultureInfo[] { CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture };
            CultureInfo currentCulture = null;
            CultureInfo currentUICulture = null;
            if (message.Headers.FindHeader(this.messageHeaderInfo.CurrentCultureName, this.messageHeaderInfo.Namespace) > -1)
            {
                currentCulture = new CultureInfo(message.Headers.GetHeader<string>(this.messageHeaderInfo.CurrentCultureName, this.messageHeaderInfo.Namespace));
                Thread.CurrentThread.CurrentCulture = currentCulture;
            }
            if (message.Headers.FindHeader(this.messageHeaderInfo.CurrentUICultureName, this.messageHeaderInfo.Namespace) > -1)
            {
                currentUICulture = new CultureInfo(message.Headers.GetHeader<string>(this.messageHeaderInfo.CurrentUICultureName, this.messageHeaderInfo.Namespace));
                Thread.CurrentThread.CurrentUICulture = currentUICulture;
            }
            return originalCulture;
        }
    }
}
