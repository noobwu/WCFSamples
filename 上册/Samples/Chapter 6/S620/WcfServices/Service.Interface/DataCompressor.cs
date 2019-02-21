using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Artech.MessageEncoding.Extension
{
    public class DataCompressor
    {
        public CompressionAlgorithm Algorithm { get; private set; }
        public DataCompressor(CompressionAlgorithm algorithm)
        {
            this.Algorithm = algorithm;
        }

        public virtual byte[] Compress(byte[] decompressedData)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                if (this.Algorithm == CompressionAlgorithm.Deflate)
                {
                    GZipStream stream2 = new GZipStream(stream, CompressionMode.Compress, true);
                    stream2.Write(decompressedData, 0, decompressedData.Length);
                    stream2.Close();
                }
                else
                {
                    DeflateStream stream3 = new DeflateStream(stream, CompressionMode.Compress, true);
                    stream3.Write(decompressedData, 0, decompressedData.Length);
                    stream3.Close();
                }
                return stream.ToArray();
            }
        }
        public virtual byte[] Decompress(byte[] compressedData, CompressionAlgorithm algorithm)
        {
            using (MemoryStream stream = new MemoryStream(compressedData))
            {
                if (algorithm == CompressionAlgorithm.Deflate)
                {
                    using (GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress))
                    {
                        return LoadToBuffer(stream2);
                    }
                }
                else
                {
                    using (DeflateStream stream3 = new DeflateStream(stream, CompressionMode.Decompress))
                    {
                        return LoadToBuffer(stream3);
                    }
                }
            }
        }
        private static byte[] LoadToBuffer(Stream stream)
        {
            using (MemoryStream stream2 = new MemoryStream())
            {
                int num;
                byte[] buffer = new byte[0x400];
                while ((num = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    stream2.Write(buffer, 0, num);
                }
                return stream2.ToArray();
            }
        }
    }
}