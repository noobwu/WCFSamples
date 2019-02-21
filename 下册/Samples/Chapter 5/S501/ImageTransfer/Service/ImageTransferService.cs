using System.ServiceModel;
using Artech.ImageTransfer.Service.Interface;
namespace Artech.ImageTransfer.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ImageTransferService : IImageTransfer
    {
        public void Transfer(byte[] imageSlice)
        {
            ImageAssembler.ReceiveImageSlice(imageSlice);
        }
        public void Erase()
        {
            ImageAssembler.Erase();
        }
    }
}