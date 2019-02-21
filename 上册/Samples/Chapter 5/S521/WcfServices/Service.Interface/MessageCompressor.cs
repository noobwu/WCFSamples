using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.Xml;
using System.IO;

namespace Artech.Serialization.Extension
{
    public class MessageCompressor
    {
        public virtual DataCompressor DataCompressor { get; private set; }
        public int MinMessageSize { get; private set; }

        public MessageCompressor(CompressionAlgorithm algorithm, int minMessageSize)
        {
            this.DataCompressor = new DataCompressor(algorithm);
            this.MinMessageSize = minMessageSize;
        }
        public Message CompressMessage(Message sourceMessage)
        {
            byte[] buffer;
            MessageBuffer messageBuffer = sourceMessage.CreateBufferedCopy(int.MaxValue);
            sourceMessage.Close();
            sourceMessage = messageBuffer.CreateMessage();
            using (XmlDictionaryReader reader1 = sourceMessage.GetReaderAtBodyContents())
            {
                buffer = Encoding.UTF8.GetBytes(reader1.ReadOuterXml());
            }
            if (buffer.Length < this.MinMessageSize)
            {
                sourceMessage.Close();
                return messageBuffer.CreateMessage();
            }
            byte[] compressedData = DataCompressor.Compress(buffer);
            string copressedBody = CreateCompressedBody(compressedData);
            XmlTextReader reader = new XmlTextReader(new StringReader(copressedBody), new NameTable());
            Message compressedMessage = Message.CreateMessage(sourceMessage.Version, null, (XmlReader)reader);
            compressedMessage.Headers.CopyHeadersFrom(sourceMessage);
            compressedMessage.Properties.CopyProperties(sourceMessage.Properties);
            compressedMessage.AddCompressionHeader(this.DataCompressor.Algorithm);
            sourceMessage.Close();
            return compressedMessage;
        }
        public Message DecompressMessage(Message sourceMessage)
        {
            if (!sourceMessage.IsCompressed())
            {
                return sourceMessage;
            }
            CompressionAlgorithm algorithm = sourceMessage.GetCompressionAlgorithm();
            sourceMessage.RemoveCompressionHeader();
            byte[] compressedBody = sourceMessage.GetCompressedBody();
            byte[] decompressedBody = DataCompressor.Decompress(compressedBody, algorithm);
            string newMessageXml = Encoding.UTF8.GetString(decompressedBody);
          
            XmlTextReader reader = new XmlTextReader(new StringReader(newMessageXml));
            Message decompressedMessage = Message.CreateMessage(sourceMessage.Version, null, reader);
            decompressedMessage.Headers.CopyHeadersFrom(sourceMessage);
            decompressedMessage.Properties.CopyProperties(sourceMessage.Properties);
            return decompressedMessage;
        }
        public static string CreateCompressedBody(byte[] content)
        {
            StringWriter output = new StringWriter();
            using (XmlWriter writer2 = XmlWriter.Create(output))
            {
                writer2.WriteStartElement(Constants.CompressionMessageBody, Constants.Namespace);
                writer2.WriteBase64(content, 0, content.Length);
                writer2.WriteEndElement();
            }
            return output.ToString();
        }
    }
}
