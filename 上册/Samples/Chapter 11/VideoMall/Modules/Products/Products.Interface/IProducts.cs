using Artech.VideoMall.Products.BusinessEntity;
namespace Artech.VideoMall.Products.Interface
{
    public interface IProducts
    {
        Movie GetMovie(string productId);
    }
}
