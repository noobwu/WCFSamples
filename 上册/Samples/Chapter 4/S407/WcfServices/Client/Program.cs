using System;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Channels;
using System.Threading;
using Artech.WcfServices.Client.ServiceReferences;
namespace Artech.WcfServices.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileReaderClient proxy = new FileReaderClient())
            {
                Console.WriteLine("文件内容：{0}", proxy.Read("HelloWorld.txt"));
            }
            Console.Read();
        }
    }
}
