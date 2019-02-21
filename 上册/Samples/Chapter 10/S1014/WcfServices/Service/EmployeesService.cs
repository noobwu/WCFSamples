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

    public IEnumerable<Employee> GetAll()
    {
        int hashCode = employees.GetHashCode();
        WebOperationContext.Current.IncomingRequest.CheckConditionalRetrieve(hashCode);
        WebOperationContext.Current.OutgoingResponse.SetETag(hashCode);
        return employees;
    }
}
}