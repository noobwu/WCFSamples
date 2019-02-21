using System;
using System.IO;
using System.Text;
using Artech.WcfServices.Service.Interface;
namespace Artech.WcfServices.Service
{
    public class FileReaderService : IFileReader
    {
        private const string baseLocation = @"E:\";
        private FileStream _stream;
        private byte[] _buffer;

        public IAsyncResult BeginRead(string fileName, AsyncCallback userCallback, object stateObject)
        {
            _stream = new FileStream(baseLocation + fileName, FileMode.Open,FileAccess.Read, FileShare.Read);
            _buffer = new byte[this._stream.Length];
            return _stream.BeginRead(this._buffer, 0, _buffer.Length, userCallback, stateObject);
        }
        public string EndRead(IAsyncResult ar)
        {
            _stream.EndRead(ar);
            _stream.Close();
            return Encoding.ASCII.GetString(_buffer);
        }
    }
}
