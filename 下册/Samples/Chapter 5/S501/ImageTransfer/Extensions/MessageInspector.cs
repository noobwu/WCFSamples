using System;
using System.ServiceModel.Channels;
namespace Artech.ImageTransfer.Extensions
{
    public class MessageInspector
    {
        public int DropRate
        { get; private set; }

        public Random Randomizer
        { get; private set; }

        public MessageInspector(int dropRate)
        {
            this.DropRate = dropRate;
            this.Randomizer = new Random();
        }

        public virtual void ProcessMessage(ref Message message)
        {
            int randomNumber = this.Randomizer.Next(100);
            if (randomNumber <= this.DropRate)
            {
                message = null;
            }
        }
    }
}