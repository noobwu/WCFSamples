using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artech.VideoMall.Products.Service.Interface;
using Artech.VideoMall.Products.BusinessComponent;
using Artech.VideoMall.Common;
using Artech.VideoMall.Products.BusinessEntity;

namespace Artech.VideoMall.Products.Service
{
    public class ProductsService : ServiceBase<ProductsBC>, IProductsService
    {
        public ProductsService(ProductsBC bc)
            : base(bc)
        { }

        public Movie[] GetAllMovies()
        {
            return this.Business.GetAllMovies();
        }
        public int GetStock(string productId)
        {
            return this.Business.GetStock(productId);
        }
    }
}
