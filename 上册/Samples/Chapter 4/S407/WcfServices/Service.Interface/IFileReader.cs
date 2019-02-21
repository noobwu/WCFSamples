using System;
using System.ServiceModel;
namespace Artech.WcfServices.Service.Interface
{
    [ServiceContract(Namespace = "http://www.artech.com/")]
    public interface IFileReader
    {
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginRead(string fileName, AsyncCallback userCallback,object stateObject);
        string EndRead(IAsyncResult asynResult);
    }
}
