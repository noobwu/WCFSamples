using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Service
{
    public class HelloService : IHello
    {
        public string SayHello(string userName)
        {
            return string.Format("Hello, {0}", userName);
        }
    }
    public class GoodbyeService : IGoodbye
    {
        public string SayGoodbye(string userName)
        {
            return string.Format("Goodbye, {0}", userName);
        }
    }
}