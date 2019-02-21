using System.Web.Mvc;
using Artech.VideoMall.Common.Extensions;
using Artech.VideoMall.Products.Service.Interface;
namespace Artech.VideoMall.Controllers
{
    public class ProductsController : ExtendedController
    {
        public IProductsService Proxy { get; private set; }
        public ProductsController(IProductsService proxy)
        {
            this.Proxy = proxy;
        }
        public ActionResult Index()
        {
            return View(this.Proxy.GetAllMovies());
        }
    }
}
