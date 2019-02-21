using Artech.WcfServices.Service.Interface;
using Artech.WcfServices.Service.Properties;
namespace Artech.WcfServices.Service
{
    public class ResourceService : IResourceService
    {
        public string GetString(string key)
        {
            return Resources.ResourceManager.GetString(key);
        }
    }
}