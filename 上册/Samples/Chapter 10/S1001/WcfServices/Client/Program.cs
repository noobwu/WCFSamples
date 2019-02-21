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

            Console.WriteLine("所有员工列表：");
            Array.ForEach<Employee>(proxy.GetAll().ToArray(), employee => Console.WriteLine(employee));

            Console.WriteLine("\n添加一个新员工（003）：");
                proxy.Create(new Employee
                {
                    Id = "003",
                    Name = "王五",
                    Grade = "G9",
                    Department = "行政部"
                });
                Array.ForEach<Employee>(proxy.GetAll().ToArray(), employee => Console.WriteLine(employee));

                Console.WriteLine("\n修改员工（003）信息：");
                proxy.Update(new Employee
                {
                    Id = "003",
                    Name = "王五",
                    Grade = "G11",
                    Department = "销售部"
                });
                Array.ForEach<Employee>(proxy.GetAll().ToArray(), employee => Console.WriteLine(employee));
                Console.WriteLine("\n删除员工（003）信息：");

                proxy.Delete("003");
                Array.ForEach<Employee>(proxy.GetAll().ToArray(), employee => Console.WriteLine(employee));
            }

            Console.Read();
        }

    }
}
