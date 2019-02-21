using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Collections;
namespace Artech.Serialization
{
    [DataContract(Namespace = "http://www.artech.com/")]
    public class Customer
    {
        [DataMember(Order = 1)]
        public Guid ID { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
        [DataMember(Order = 3)]
        public string Phone { get; set; }
        [DataMember(Order = 4)]
        public string CompanyAddress { get; set; }
    }

    public class CustomerCollection : IEnumerable<Customer>
    {
        public IList<Customer> Customers { get; private set; }
        public CustomerCollection(params Customer[] customers)
        {
            if (null == customers)
            {
                this.Customers = new List<Customer>();
            }
            else
            {
                this.Customers = customers;
            }
        }
        public CustomerCollection()
        { }
        public void Add(Customer customer)
        {
            this.Customers.Add(customer);
        }
        public IEnumerator<Customer> GetEnumerator()
        {
            return this.Customers.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Customers.GetEnumerator();
        }
    }
}