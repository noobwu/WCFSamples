using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Description;
using System.Net;
using System.IO;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://127.0.0.1:3721/employees/001");
            var request = (HttpWebRequest)HttpWebRequest.Create(address);
            request.Method = "GET";
            var response = (HttpWebResponse)request.GetResponse();
            string employee;
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                employee = reader.ReadToEnd();
                Console.WriteLine("获取员工信息：");
                Console.WriteLine(employee + "\n");
            }
            try
            {
                address = new Uri("http://127.0.0.1:3721/employees/");
                request = (HttpWebRequest)HttpWebRequest.Create(address);
                request.Method = "POST";
                request.ContentType = "application/xml";
                byte[] buffer = Encoding.UTF8.GetBytes(employee);
                request.GetRequestStream().Write(Encoding.UTF8.GetBytes(employee), 0, buffer.Length);
                request.Headers.Add(HttpRequestHeader.IfMatch, response.Headers[HttpResponseHeader.ETag]);
                Console.WriteLine("修改员工信息:");
                request.GetResponse();
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
                if (null == response)
                {
                    throw;
                }
                if (response.StatusCode == HttpStatusCode.PreconditionFailed)
                {
                    Console.WriteLine("服务端数据已发生变化");
                }
                else
                {
                    throw;
                }
            }
            Console.Read();
        }
    }
}
