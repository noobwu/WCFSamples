using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Web;
using System.Net;
using System.Reflection;

namespace Artech.WcfServices.Service
{
public class EmployeesService : IEmployees
{
    private static IList<Employee> employees = new List<Employee>
    {
        new Employee{ Id = "001", Name="张三", Department="开发部", Grade = "G7"},    
        new Employee{ Id = "002", Name="李四", Department="人事部", Grade = "G6"}
    };
    public Employee Get(string id)
    {
        Employee employee = employees.FirstOrDefault(e => e.Id == id);
        if (null == employee)
        {
            throw new WebFaultException(HttpStatusCode.NotFound);
        }
        WebOperationContext.Current.OutgoingResponse.SetETag(employee.GetHashCode());
        return employee;
    }
    public void Update(Employee employee)
    {
        var existing = employees.FirstOrDefault(e => e.Id == employee.Id);
        if (null == existing)
        {
            throw new WebFaultException(HttpStatusCode.NotFound);
        }
        //模拟并发修改
        existing.Name += Guid.NewGuid().ToString();

        WebOperationContext.Current.IncomingRequest.CheckConditionalUpdate(existing.GetHashCode());
        employees.Remove(existing);            
        employees.Add(employee);
        WebOperationContext.Current.OutgoingResponse.SetETag(employee.GetHashCode());
    }
}
}