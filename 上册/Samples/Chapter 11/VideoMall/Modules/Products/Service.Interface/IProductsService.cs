using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Artech.VideoMall.Common;
using Artech.VideoMall.Products.BusinessEntity;

namespace Artech.VideoMall.Products.Service.Interface
{
    [ServiceContract(Namespace = Constants.ServiceContractNamespace)]
    public interface IProductsService
    {
        [OperationContract]
        Movie[] GetAllMovies();
        int GetStock(string productId);
    }
}