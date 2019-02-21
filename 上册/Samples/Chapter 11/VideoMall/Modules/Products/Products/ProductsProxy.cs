using System;
using Artech.VideoMall.Common;
using Artech.VideoMall.Products.BusinessEntity;
using Artech.VideoMall.Products.Service.Interface;
namespace Artech.VideoMall.Products
{
    public class ProductsProxy : ServiceProxyBase<IProductsService>, IProductsService
    {
        public ProductsProxy()
            : base("productsService")
        { }
        [CachingCallHandler]
        public Movie[] GetAllMovies()
        {
            return this.Invoker.Invoke(proxy => proxy.GetAllMovies());
        }
        public int GetStock(string productId)
        {
            throw new NotImplementedException();
        }
    }
}
