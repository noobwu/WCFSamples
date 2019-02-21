using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using Artech.Serialization;
using System.Runtime.Serialization;

namespace Serialization
{
    class Program
    {
        public static void Serialize<T>(T instance, string fileName, params Type[] knownTypes)
        {
            DataContractSerializer serializer = new DataContractSerializer(typeof(T),knownTypes, int.MaxValue, false, false, null);
            using (XmlWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                serializer.WriteObject(writer, instance);
            }
            Process.Start(fileName);
        }

        private static Bill<OrderBillHeader, OrderBillDetail> CreateOrderBill()
        {
            OrderBillHeader header = new OrderBillHeader
            {
                OrderID = Guid.NewGuid(),
                Date = DateTime.Today,
                Customer = "张三"
            };

            List<OrderBillDetail> details = new List<OrderBillDetail>();
            OrderBillDetail detail = new OrderBillDetail
            {
                ProductID = Guid.NewGuid(),
                Quantity = 20,
                UnitPrice = 8888
            };
            details.Add(detail);
            detail = new OrderBillDetail
            {
                ProductID = Guid.NewGuid(),
                Quantity = 10,
                UnitPrice = 9999
            };
            details.Add(detail);
            Bill<OrderBillHeader, OrderBillDetail> orderBill =
                new Bill<OrderBillHeader, OrderBillDetail>()
                {
                    Header = header,
                    Details = details.ToArray()
                };
            return orderBill;
        }

        static void Main(string[] args)
        {
            Bill<OrderBillHeader, OrderBillDetail> orderBill = CreateOrderBill();
            Serialize<Bill<OrderBillHeader, OrderBillDetail>>(
                orderBill, "orderbill.xml");
        }
    }
}
