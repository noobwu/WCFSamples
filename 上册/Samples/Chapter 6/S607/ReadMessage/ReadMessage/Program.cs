using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;

namespace Artech.ReadMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order
            {
                ID = Guid.NewGuid(),
                Date = DateTime.Today,
                Customer = "张三",
                ShipAddress = "江苏省 苏州市 星湖街 328号"
            };

            string action = "http://www.artech.com/crm/CreateCustomer";
            Message message = Message.CreateMessage(MessageVersion.Default, action, order);
            Console.WriteLine("消息当前状态为:{0}", message.State);
            order = message.GetBody<Order>();
            Console.WriteLine("从消息中读取到订单信息");
            Console.WriteLine("\t{0,-2}: {1}", "单号", order.ID);
            Console.WriteLine("\t{0,-2}: {1}", "日期", order.Date.ToString("yyyy-MM-dd"));
            Console.WriteLine("\t{0,-2}: {1}", "客户", order.Customer);
            Console.WriteLine("\t{0,-2}: {1}", "地址", order.ShipAddress);
            Console.WriteLine("消息当前状态为:{0}", message.State);

        }
    }
}



 

 
