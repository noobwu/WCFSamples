using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artech.VideoMall.Common;
using Artech.VideoMall.Products.DataAccess;
using Artech.VideoMall.Products.BusinessEntity;

namespace Artech.VideoMall.Products.BusinessComponent
{
    public class ProductsBC: BusinessComponentBase<ProductsDA>
    {
        public ProductsBC(ProductsDA da)
            : base(da)
        { }

        public Movie[] GetAllMovies()
        {
            return this.DataAccess.GetAllMovies();
        }

        public int GetStock(string productId)
        {
            return this.DataAccess.GetStock(productId);
        }
    }
}
