using System.ServiceModel;
namespace Artech.ImageTransfer.Service.Interface
{
    [ServiceContract(Namespace="http://www.artech.com/")]
    public interface IImageTransfer
    {
        [OperationContract(IsOneWay = true)]
        void Transfer(byte[] imageSlice);

        [OperationContract(IsOneWay = true)]
        void Erase();
    }
}