using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfChat
{
    [ServiceContract(CallbackContract = typeof(IMessageCallBack))]
    public interface IWcfChatSevice
    {
        [OperationContract]
        string Connect(string userName);

        [OperationContract]
        void Disconnect(string id);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string message, string senderUserId);

        [OperationContract]
        IList<string> GetAllMessages();
    }

    public interface IMessageCallBack
    {
        [OperationContract(IsOneWay = true)]
        void GetMessage(string message);
    }
}
