using Artech.WcfServices.Service.Interface;
using Artech.WcfServices.Service.Properties;
namespace Artech.WcfServices.Service
{
    public class ResourceService : IResourceService
    {
        public IResourceProvider Provider { get; private set; }

        public ResourceService(IResourceProvider provider)
        {
            this.Provider = provider;
        }
        public string GetString(string key)
        {
            return this.Provider.GetString(key);
        }
    }
}