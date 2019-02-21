using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.Xml;

namespace Artech.MessageEncoding.Extension
{
    public static class Extensions
    {
        public static bool IsCompressed(this Message message)
        {
            return message.Headers.FindHeader(Constants.CompressionMessageHeader, Constants.Namespace) > -1;
        }
        public static void AddCompressionHeader(this Message message, CompressionAlgorithm algorithm)
        {
            message.Headers.Add(MessageHeader.CreateHeader(Constants.CompressionMessageHeader, Constants.Namespace, string.Format("algorithm = \"{0}\"", algorithm)));
        }
        public static void RemoveCompressionHeader(this Message message)
        {
            message.Headers.RemoveAll(Constants.CompressionMessageHeader, Constants.Namespace);
        }
        public static CompressionAlgorithm GetCompressionAlgorithm(this Message message)
        {
            var algorithm = message.Headers.GetHeader<string>(Constants.CompressionMessageHeader, Constants.Namespace);
            algorithm = algorithm.Replace("algorithm =", string.Empty).Replace("\"", string.Empty).Trim();
            if (algorithm == CompressionAlgorithm.Deflate.ToString())
            {
                return CompressionAlgorithm.Deflate;
            }
            if (algorithm == CompressionAlgorithm.GZip.ToString())
            {
                return CompressionAlgorithm.GZip;
            }
            throw new InvalidOperationException("未知压缩算法");
        }
        public static byte[] GetCompressedBody(this Message message)
        {
            byte[] buffer;
            using (XmlReader reader = message.GetReaderAtBodyContents())
            {
                buffer = Convert.FromBase64String(reader.ReadElementString(Constants.CompressionMessageBody, Constants.Namespace));
            }
            return buffer;
        }
    }
}
