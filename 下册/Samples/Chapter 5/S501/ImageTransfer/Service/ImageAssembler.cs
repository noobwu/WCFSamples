using System;
namespace Artech.ImageTransfer.Service
{
    public static class ImageAssembler
    {
        public static void ReceiveImageSlice(byte[] imageSlice)
        {
            if (null != ImageSliceReceived)
            {
                ImageSliceReceived(null, new ImageReceivedEventArgs(imageSlice));
            }
        }

        public static void Erase()
        {
            if (null != ImageErasing)
            {
                ImageErasing(null,  EventArgs.Empty);
            }
        }

        public static event EventHandler<ImageReceivedEventArgs> ImageSliceReceived;
        public static event EventHandler ImageErasing;
    }

    public class ImageReceivedEventArgs : EventArgs
    {
        public byte[] ImageSlice
        { get; private set; }

        public ImageReceivedEventArgs(byte[] imageSlice)
        {
            if (null == imageSlice)
            {
                throw new ArgumentNullException("imageSlice");
            }

            this.ImageSlice = imageSlice;
        }
    }
}
