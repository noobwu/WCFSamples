using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Description;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ChannelFactory<IEmployees> channelFactory = new ChannelFactory<IEmployees>("employeeService"))
            {
                IEmployees proxy = channelFactory.CreateChannel();
                proxy.Create(new Employee
                {
                    Id = "003",
                    Name = "王五",
                    Grade = "G9",
                    Department = "行政部"
                });               
            }
            Console.Read();
        }
    }
}
