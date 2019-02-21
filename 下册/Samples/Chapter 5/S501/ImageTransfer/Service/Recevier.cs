using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
namespace Artech.ImageTransfer.Service
{
    public partial class Recevier : Form
    {
        private PictureBox[] _pictureBoxes;
        private SynchronizationContext _synchronizationContext = null;
        private int _index = 0;
        private ServiceHost _serviceHost = null;
        public Recevier()
        {
            InitializeComponent();
            _pictureBoxes = new PictureBox[]{
                this.pictureBox11,this.pictureBox12,this.pictureBox13,this.pictureBox14,this.pictureBox15,
                this.pictureBox21,this.pictureBox22,this.pictureBox23,this.pictureBox24,this.pictureBox25,
                this.pictureBox31,this.pictureBox32,this.pictureBox33,this.pictureBox34,this.pictureBox35,
                this.pictureBox41,this.pictureBox42,this.pictureBox43,this.pictureBox44,this.pictureBox45,
                this.pictureBox51,this.pictureBox52,this.pictureBox53,this.pictureBox54,this.pictureBox55};
            ImageAssembler.ImageSliceReceived += ImageAssembler_ImageCliceReceived;
            ImageAssembler.ImageErasing += ImageAssembler_ImageErasing;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        private void ImageAssembler_ImageCliceReceived(object sender, ImageReceivedEventArgs args)
        {
            Bitmap bitmap = null;
            using (MemoryStream stream = new MemoryStream(args.ImageSlice))
            {
                bitmap = new Bitmap(stream);
                _synchronizationContext.Send(state => _pictureBoxes[_index++].Image = bitmap, null);
            }
        }
        private void ImageAssembler_ImageErasing(object sender, EventArgs args)
        {
            _index = 0;
            foreach (var pictureBox in _pictureBoxes)
            {
                pictureBox.Image = null;
            }
        }
        private void Recevier_Load(object sender, EventArgs e)
        {
            _synchronizationContext = SynchronizationContext.Current;
            _serviceHost = new ServiceHost(typeof(ImageTransferService));
            _serviceHost.Open();
        }
    }
}