using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel.Web;
using System.ServiceModel;

namespace Artech.WcfServices.Service.Interface
{
    [ServiceContract]
    public interface IEmployees
    {
        [WebGet(UriTemplate = "all")]
        IEnumerable<Employee> GetAll();

        [WebGet(UriTemplate = "{id}")]
        Employee Get(string id);

        [WebInvoke(UriTemplate = "/", Method = "POST")]
        void Create(Employee employee);

        [WebInvoke(UriTemplate = "/", Method = "PUT")]
        void Update(Employee employee);

        [WebInvoke(UriTemplate = "{id}", Method = "DELETE")]
        void Delete(string id);
    }

    [DataContract(Namespace = "http://www.artech.com/")]
    public class Employee
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Department { get; set; }
        [DataMember]
        public string Grade { get; set; }

        public override string ToString()
        {
            return string.Format("ID: {0,-5}姓名: {1, -5}级别: {2, -4} 部门: {3}", Id, Name, Grade, Department);
        }
    }
}
