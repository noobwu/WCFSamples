using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Artech.VideoMall.Common.Extensions;
using Artech.VideoMall.Models;
using Artech.VideoMall.Orders.BusinessEntity;
using Artech.VideoMall.Orders.Service.Interface;
using Artech.VideoMall.Products.Interface;
namespace Artech.VideoMall.Controllers
{
    public class OrdersController : ExtendedController
    {
        public IProducts ProductService { get; private set; }
        public IOrdersService OrdersService { get; private set; }

        public OrdersController(IProducts productService, IOrdersService ordersService)
        {
            this.ProductService = productService;
            this.OrdersService = ordersService;
        }
        public ActionResult Index()
        {
            ShoppingCartEntry[] entries = ShoppingCart.Current.Items.Select(
                item => new ShoppingCartEntry(item) 
                { 
                    ProductName = this.ProductService.GetMovie(item.ProductId).Name 
                }).ToArray();
            return View("ShoppingCart", entries);
        }

        public ActionResult AddProductIntoCart()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddProductIntoCart(string productId, decimal price)
        {
            ShoppingCart.Current.AddProduct(productId, price);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult RemoveProductFromCart(string productId)
        {
            ShoppingCartItem cartItem = ShoppingCart.Current.Items.FirstOrDefault(item => item.ProductId == productId);
            if (null != cartItem)
            {
                ShoppingCart.Current.Items.Remove(cartItem);
            }
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult CheckOut()
        {
            Order order = new Order(Guid.NewGuid().ToString(), DateTime.Now, HttpContext.User.Identity.Name);
            foreach(var item in  ShoppingCart.Current.Items)
            {
                order.AddOrderLine(item.ProductId, item.Quantity);
            }
            this.OrdersService.Submit(order);
            ShoppingCart.Current = null;
            return View();
        }
    }
}
