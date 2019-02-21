using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.ServiceModel;
using System.Windows.Forms;
using Artech.ImageTransfer.Service.Interface;

namespace Client
{
    public partial class Sender : Form
    {
        private string _imageSource = string.Empty;
        private IImageTransfer _nonReliableSessionProxy = null;
        private IImageTransfer _reliableSessionProxy = null;
        private IImageTransfer _orderedDeliveryProxy = null;
        ChannelFactory<IImageTransfer> _nonReliableSessionFactory = new ChannelFactory<IImageTransfer>("nonReliableSession");
        ChannelFactory<IImageTransfer> _reliableSessionFactory = new ChannelFactory<IImageTransfer>("reliableSession");
        ChannelFactory<IImageTransfer> _orderedDeliveryFactory = new ChannelFactory<IImageTransfer>("orderedDelivery");

        public Sender()
        {
            InitializeComponent();
        }

        private IImageTransfer GetProxy()
        {
            if(null != _nonReliableSessionProxy)
            {
                (_nonReliableSessionProxy as ICommunicationObject).Close();
            }

             if(null != _reliableSessionProxy)
            {
                (_reliableSessionProxy as ICommunicationObject).Close();
            }

             if(null != _orderedDeliveryProxy)
            {
                (_orderedDeliveryProxy as ICommunicationObject).Close();
            }

             if (!this.checkBoxReliableSession.Checked)
             {
                 _nonReliableSessionProxy = _nonReliableSessionFactory.CreateChannel();
                 (_nonReliableSessionProxy as ICommunicationObject).Open();
                 return _nonReliableSessionProxy;
             }
             else if (!this.checkBoxOrdered.Checked)
             {
                 _reliableSessionProxy = _reliableSessionFactory.CreateChannel();
                 (_reliableSessionProxy as ICommunicationObject).Open();
                 return _reliableSessionProxy;
             }
             else
             {
                 _orderedDeliveryProxy = _orderedDeliveryFactory.CreateChannel();
                 (_orderedDeliveryProxy as ICommunicationObject).Open();
                 return _orderedDeliveryProxy;
             }
        }
        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog()== DialogResult.OK)
            {
                _imageSource = openFileDialog.FileName;
                this.pictureBox1.Load(_imageSource);
            }
            this.buttonSend.Enabled = true;
        }

        private byte[] BitmapToBytes(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Bmp);
                byte[] data = new byte[ms.Length];
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(data, 0, Convert.ToInt32(ms.Length));
                return data;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            this.buttonSend.Enabled = false;
            IList<byte[]> imageSlices = new List<byte[]>();
            Bitmap bmp = new Bitmap(this._imageSource);
            double width = (double)bmp.Width / 5;
            double height = (double)bmp.Height / 5;
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    Rectangle rect = new Rectangle(Convert.ToInt32(x * width), Convert.ToInt32(y * height),
                        Convert.ToInt32(width), Convert.ToInt32(height));

                    byte[] data = BitmapToBytes(bmp.Clone(rect, PixelFormat.DontCare));
                    imageSlices.Add(data);
                }
            }

            IImageTransfer proxy = GetProxy();
            proxy.Erase();
            for (int i = 0; i < imageSlices.Count; i++)
            {
                proxy.Transfer(imageSlices[i]);
            }
            this.buttonSend.Enabled = true;
        }

        private void checkBoxOrdered_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxOrdered.Checked)
            {
                this.checkBoxReliableSession.Checked = true;
            }
        }

        private void checkBoxReliableSession_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.checkBoxReliableSession.Checked)
            {
                this.checkBoxOrdered.Checked = false;
            }
        }
    }
}