using Artech.WcfServices.Service.Properties;
namespace Artech.WcfServices.Service
{
    public class ResxFileProvider : IResourceProvider
    {
        public string GetString(string key)
        {
            return Resources.ResourceManager.GetString(key);
        }
    }
}
