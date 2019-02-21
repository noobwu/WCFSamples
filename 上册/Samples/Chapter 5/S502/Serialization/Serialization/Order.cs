using System;
namespace Artech.Serialization
{
    public class Order
    {
        private double _totalPrice;
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string ShipAddress { get; set; }

        public Order() { }
        public Order(double totalPrice, Guid id)
        {
            _totalPrice = totalPrice;
            this.ID = id;
        }
    }
}
