using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artech.VideoMall.Products.Interface;
using Artech.VideoMall.Products.BusinessEntity;
using Artech.VideoMall.Products.Service.Interface;

namespace Artech.VideoMall.Products
{
    public class Products : IProducts
    {
        public IProductsService ProductsProxy { get; private set; }
        public Products(IProductsService productsProxy)
        {
            this.ProductsProxy = productsProxy;
        }
        public Movie GetMovie(string productId)
        {
            return this.ProductsProxy.GetAllMovies().FirstOrDefault(m => m.Id == productId);
        }
    }
}
