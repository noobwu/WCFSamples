using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;

namespace Artech.Serialization.Extension
{
public class CompressionMessageFormatter: IDispatchMessageFormatter,IClientMessageFormatter
{
    public MessageCompressor MessageCompressor { get; private set; }
    public IDispatchMessageFormatter InnerDispatchMessageFormatter { get; private set; }
    public IClientMessageFormatter InnerClientMessageFormatter { get; private set; }

    public CompressionMessageFormatter(MessageCompressor messageCompressor,
        IDispatchMessageFormatter innerDispatchMessageFormatter, IClientMessageFormatter innerClientMessageFormatter)
    {
        this.MessageCompressor = messageCompressor;
        this.InnerDispatchMessageFormatter = innerDispatchMessageFormatter;
        this.InnerClientMessageFormatter = innerClientMessageFormatter;
    }


    public void DeserializeRequest(Message message, object[] parameters)
    {
        message = this.MessageCompressor.DecompressMessage(message);
        this.InnerDispatchMessageFormatter.DeserializeRequest(message, parameters);
    }

    public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
    {
        Message message = this.InnerDispatchMessageFormatter.SerializeReply(messageVersion, parameters, result);
        return this.MessageCompressor.CompressMessage(message);
    }

    public object DeserializeReply(Message message, object[] parameters)
    {
        message = this.MessageCompressor.DecompressMessage(message);
        return this.InnerClientMessageFormatter.DeserializeReply(message, parameters);
    }

    public Message SerializeRequest(MessageVersion messageVersion, object[] parameters)
    {
        Message message = this.InnerClientMessageFormatter.SerializeRequest(messageVersion, parameters);
        return this.MessageCompressor.CompressMessage(message);
    }
}
}
