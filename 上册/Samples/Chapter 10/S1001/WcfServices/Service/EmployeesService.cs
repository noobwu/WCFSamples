using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artech.WcfServices.Service.Interface;
using System.ServiceModel.Web;
using System.Net;

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
            WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
        }
        return employee;
    }
    public void Create(Employee employee)
    {
        employees.Add(employee);
    }
    public void Update(Employee employee)
    {
        this.Delete(employee.Id);
        employees.Add(employee);
    }
    public void Delete(string id)
    {
        Employee employee = this.Get(id);
        if (null != employee)
        {
            employees.Remove(employee);
        }
    }
    public IEnumerable<Employee> GetAll()
    {
        return employees;
    }
}
}