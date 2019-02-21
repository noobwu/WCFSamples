using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Net;
using System.IO;

namespace Client
{
    class Program
    {
        static void GetAllEmployees(string ifNoneMatch, out string eTag)
        {
            eTag = ifNoneMatch;
            Uri address = new Uri("http://127.0.0.1:3721/employees/all");
            var request = (HttpWebRequest)HttpWebRequest.Create(address);
            if (!string.IsNullOrEmpty(ifNoneMatch))
            {
                request.Headers.Add(HttpRequestHeader.IfNoneMatch, ifNoneMatch);
            }
            request.Method = "GET";
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                eTag = response.Headers[HttpResponseHeader.ETag];
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    Console.WriteLine(reader.ReadToEnd() + Environment.NewLine);
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse response = ex.Response as HttpWebResponse;
                if (null == response)
                {
                    throw;
                }
                if (response.StatusCode == HttpStatusCode.NotModified)
                {
                    Console.WriteLine("服务端数据未发生变化");
                    return;
                }
                throw;
            }
        }

        static void Main(string[] args)
        {
            string etag;
            Console.WriteLine("第1次服务调用:");
            GetAllEmployees("", out etag);
            Console.WriteLine("第2次服务调用:");
            GetAllEmployees(etag, out etag);
            Console.Read();
        }

        public static string eTag { get; set; }
    }
}
