using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.Xml;

namespace Artech.CreateMessage
{
    public class XmlReaderBodyWriter : BodyWriter
    {
        public String FileName { get; private set; }
        public XmlReaderBodyWriter(String fileName)
            : base(false)
        {
            this.FileName = fileName;
        }
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            using (XmlReader reader = new XmlTextReader(this.FileName))
            {
                while (!reader.EOF)
                {
                    writer.WriteNode(reader, false);
                }
            }
        }
    }
}