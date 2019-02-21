using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;

namespace Artech.MessageEncoding.Extension
{
public class CompressionTextMessageEncodingBindingElement : MessageEncodingBindingElement
{
    public TextMessageEncodingBindingElement TextEncodingElement { get; private set; }
    public MessageCompressor MessageCompressor { get; private set; }
    private CompressionTextMessageEncodingBindingElement() { }
    public CompressionTextMessageEncodingBindingElement(TextMessageEncodingBindingElement textEncodingElement, CompressionAlgorithm algorithm, int minMessageSize)
    {
        this.TextEncodingElement = textEncodingElement;
        this.MessageCompressor = new MessageCompressor(algorithm, minMessageSize);
    }
    public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
    {
        context.BindingParameters.Add(this);
        return base.BuildChannelFactory<TChannel>(context);
    }

    public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
    {
        context.BindingParameters.Add(this);
        return base.BuildChannelListener<TChannel>(context);
    }
    public override MessageEncoderFactory CreateMessageEncoderFactory()
    {
        return new CompressionMessageEncoderFactory(this.TextEncodingElement.CreateMessageEncoderFactory(), this.MessageCompressor);
    }
    public override MessageVersion MessageVersion
    {
        get { return this.TextEncodingElement.MessageVersion; }
        set { this.TextEncodingElement.MessageVersion = value; }
    }
    public override BindingElement Clone()
    {
        TextMessageEncodingBindingElement textEncodingElement = new TextMessageEncodingBindingElement()
        {
            MaxReadPoolSize = this.TextEncodingElement.MaxReadPoolSize,
            MaxWritePoolSize = this.TextEncodingElement.MaxWritePoolSize,
            MessageVersion = this.TextEncodingElement.MessageVersion,
            ReaderQuotas = this.TextEncodingElement.ReaderQuotas,
            WriteEncoding = this.TextEncodingElement.WriteEncoding
        };
        return new CompressionTextMessageEncodingBindingElement()
        {
            TextEncodingElement = textEncodingElement,
            MessageCompressor = this.MessageCompressor
        };          
    }
}
}
