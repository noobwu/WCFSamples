using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity.Utility;
namespace Artech.VideoMall.Models
{
    [Serializable]
    public class ShoppingCart
    {
        public IList<ShoppingCartItem> Items { get; private set; }
        public int TotalQuantity
        {
            get{return Items.Sum(item=>item.Quantity);}
        }        
        public decimal TotalPrice
        {
            get{return Items.Sum(item=>item.Quantity * item.Price);}
        }

        public ShoppingCart()
        {
            this.Items = new List<ShoppingCartItem>();
        }
        public void AddProduct(string productId, decimal price, int quantity = 1)
        {
            ShoppingCartItem shoppingCartItem = this.Items.SingleOrDefault(item => item.ProductId == productId);
            if (null != shoppingCartItem)
            {
                shoppingCartItem.Quantity += quantity;
            }
            else
            {
                this.Items.Add(new ShoppingCartItem
                {
                    ProductId = productId,
                    Price = price,
                    Quantity = quantity
                });                 
            }
        }
        public static ShoppingCart Current
        {
            get
            { 
                ShoppingCart shoppingCart = HttpContext.Current.Session["ShoppingCart"] as ShoppingCart;
                if (null == shoppingCart)
                {
                    shoppingCart = new ShoppingCart();
                    HttpContext.Current.Session["ShoppingCart"] = shoppingCart;
                }               
                return shoppingCart;
            }
            set
            {
                HttpContext.Current.Session["ShoppingCart"] = value;
            }
        }
    }

    public class ShoppingCartItem
    {        
        public string ProductId{get;set;}
        public decimal Price{get;set;}
        public int Quantity{get;set;}
    }

    public class ShoppingCartEntry : ShoppingCartItem
    {
        public ShoppingCartEntry(ShoppingCartItem shoppingCartItem)
        {
            Guard.ArgumentNotNull(shoppingCartItem, "shoppingCartItem");
            this.ProductId = shoppingCartItem.ProductId;
            this.Price = shoppingCartItem.Price;
            this.Quantity = shoppingCartItem.Quantity;
        }
        public string ProductName { get; set; }
    }
}