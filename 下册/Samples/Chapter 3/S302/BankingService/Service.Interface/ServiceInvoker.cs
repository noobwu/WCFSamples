using System;
using System.ServiceModel;

namespace Artech.TransactionalService.Service.Interface
{
    public static class ServiceInvoker
    {
        public static void Invoke<TChannel>(Action<TChannel> action, string endpointConfigurationName)
        {
            Guard.ArgumentNotNull(action, "action");
            Guard.ArgumentNotNullOrEmpty(endpointConfigurationName, "endpointConfigurationName");

            using (ChannelFactory<TChannel> channelFactory = new ChannelFactory<TChannel>(endpointConfigurationName))
            {
                TChannel channel = channelFactory.CreateChannel();
                using (channel as IDisposable)
                {
                    try
                    {
                        action(channel);
                    }
                    catch (TimeoutException)
                    {
                        (channel as ICommunicationObject).Abort();
                        throw;
                    }
                    catch (CommunicationException)
                    {
                        (channel as ICommunicationObject).Abort();
                        throw;
                    }
                }
            }
        }

        public static TResult Invoke<TChannel, TResult>(Func<TChannel, TResult> func, string endpointConfigurationName)
        {
            Guard.ArgumentNotNull(func, "func");
            Guard.ArgumentNotNullOrEmpty(endpointConfigurationName, "endpointConfigurationName");

            using (ChannelFactory<TChannel> channelFactory = new ChannelFactory<TChannel>(endpointConfigurationName))
            {
                TChannel channel = channelFactory.CreateChannel();
                using (channel as IDisposable)
                {
                    try
                    {
                        return func(channel);
                    }
                    catch (TimeoutException)
                    {
                        (channel as ICommunicationObject).Abort();
                        throw;
                    }
                    catch (CommunicationException)
                    {
                        (channel as ICommunicationObject).Abort();
                        throw;
                    }
                }
            }
        }
    }
}