using System;
using System.ServiceModel.Channels;

namespace Artech.ImageTransfer.Extensions
{
    public class UnreliableNetworkSimulateChannel : IDuplexSessionChannel
    {
        public IDuplexSessionChannel InnerChannel
        { get; private set; }

        public MessageInspector MessageInspector
        { get; private set; }

        public UnreliableNetworkSimulateChannel(IDuplexSessionChannel innerChannel, int dropRate)
        {
            if (null == innerChannel)
            {
                throw new ArgumentNullException("innerChannel");
            }

            this.InnerChannel = innerChannel;
            this.MessageInspector = new MessageInspector(dropRate);
        }

        #region IInputChannel Members

        public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.InnerChannel.BeginReceive(timeout, callback, state);
        }

        public IAsyncResult BeginReceive(AsyncCallback callback, object state)
        {
            return this.InnerChannel.BeginReceive( callback, state);
        }

        public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.InnerChannel.BeginTryReceive(timeout,callback, state);
        }

        public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.InnerChannel.BeginWaitForMessage(timeout, callback, state);
        }

        public Message EndReceive(IAsyncResult result)
        {
            return this.InnerChannel.EndReceive(result);
        }

        public bool EndTryReceive(IAsyncResult result, out Message message)
        {
            return this.InnerChannel.EndTryReceive(result, out message);
        }

        public bool EndWaitForMessage(IAsyncResult result)
        {
            return this.InnerChannel.EndWaitForMessage(result);
        }

        public System.ServiceModel.EndpointAddress LocalAddress
        {
            get { return this.InnerChannel.LocalAddress; }
        }

        public Message Receive(TimeSpan timeout)
        {
            return this.InnerChannel.Receive(timeout);
        }

        public Message Receive()
        {
            return this.InnerChannel.Receive();
        }

        public bool TryReceive(TimeSpan timeout, out Message message)
        {
            return this.InnerChannel.TryReceive(timeout, out message);
        }

        public bool WaitForMessage(TimeSpan timeout)
        {
            return this.InnerChannel.WaitForMessage(timeout);
        }

        #endregion

        #region IChannel Members

        public T GetProperty<T>() where T : class
        {
            return this.InnerChannel.GetProperty<T>();
        }

        #endregion

        #region ICommunicationObject Members

        public void Abort()
        {
            this.InnerChannel.Abort();
        }

        public IAsyncResult BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.InnerChannel.BeginClose(timeout, callback, state);
        }

        public IAsyncResult BeginClose(AsyncCallback callback, object state)
        {
            return this.InnerChannel.BeginClose(callback, state);
        }

        public IAsyncResult BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.InnerChannel.BeginOpen(timeout, callback, state);
        }

        public IAsyncResult BeginOpen(AsyncCallback callback, object state)
        {
            return this.InnerChannel.BeginOpen(callback, state);
        }

        public void Close(TimeSpan timeout)
        {
            this.InnerChannel.Close(timeout);
        }

        public void Close()
        {
            this.InnerChannel.Close();
        }

        public event EventHandler Closed;

        public event EventHandler Closing;

        public void EndClose(IAsyncResult result)
        {
            this.InnerChannel.EndClose(result);
        }

        public void EndOpen(IAsyncResult result)
        {
            this.InnerChannel.EndOpen(result); 
        }

        public event EventHandler Faulted;

        public void Open(TimeSpan timeout)
        {
            this.InnerChannel.Open(timeout); 
        }

        public void Open()
        {
            this.InnerChannel.Open(); 
        }

        public event EventHandler Opened;

        public event EventHandler Opening;

        public System.ServiceModel.CommunicationState State
        {
            get { return this.InnerChannel.State; }
        }

        #endregion

        #region IOutputChannel Members

        public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.InnerChannel.BeginSend(message, timeout, callback, state);
        }

        public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
        {
            return this.InnerChannel.BeginSend(message, callback, state);
        }

        public void EndSend(IAsyncResult result)
        {
            this.InnerChannel.EndSend(result);
        }

        public System.ServiceModel.EndpointAddress RemoteAddress
        {
            get { return this.InnerChannel.RemoteAddress; }
        }

        public void Send(Message message, TimeSpan timeout)
        {
            this.MessageInspector.ProcessMessage(ref message);
            if(null != message)
            {
                this.InnerChannel.Send(message, timeout);
            }
        }

        public void Send(Message message)
        {
            this.MessageInspector.ProcessMessage(ref message);
            if (null != message)
            {
                this.InnerChannel.Send(message);
            }
        }

        public Uri Via
        {
            get { return this.InnerChannel.Via; }
        }

        #endregion

        #region ISessionChannel<IDuplexSession> Members

        public IDuplexSession Session
        {
            get { return this.InnerChannel.Session; }
        }

        #endregion

        
    }
}
