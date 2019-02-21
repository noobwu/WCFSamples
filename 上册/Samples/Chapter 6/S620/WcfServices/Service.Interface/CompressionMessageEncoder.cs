using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.IO;

namespace Artech.MessageEncoding.Extension
{
public class CompressionMessageEncoder: MessageEncoder
{
    public MessageEncoder InnerMessageEncoder { get; private set; }
    public MessageCompressor MessageCompressor { get; private set; }
    public CompressionMessageEncoder(MessageEncoder innerMessageEncoder, MessageCompressor messageCompressor)
    {
        this.InnerMessageEncoder = innerMessageEncoder;
        this.MessageCompressor = messageCompressor;
    }

    public override string ContentType
    {
        get { return this.InnerMessageEncoder.ContentType; }
    }
    public override string MediaType
    {
        get { return this.InnerMessageEncoder.MediaType; }
    }
    public override MessageVersion MessageVersion
    {
        get { return this.InnerMessageEncoder.MessageVersion; }
    }
    public override T GetProperty<T>()
    {
        return this.InnerMessageEncoder.GetProperty<T>();
    }

    public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
    {
        Message message = this.InnerMessageEncoder.ReadMessage(buffer, bufferManager, contentType);
        return this.MessageCompressor.DecompressMessage(message);
    }
    public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
    {
        Message message = this.InnerMessageEncoder.ReadMessage(stream, maxSizeOfHeaders, contentType);
        return this.MessageCompressor.DecompressMessage(message);
    }
    public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
    {
        message = this.MessageCompressor.CompressMessage(message);
        return this.InnerMessageEncoder.WriteMessage(message, maxMessageSize, bufferManager, messageOffset);
    }

    public override void WriteMessage(Message message, Stream stream)
    {
        message = this.MessageCompressor.CompressMessage(message);
        this.InnerMessageEncoder.WriteMessage(message, stream);
    }
}
}
