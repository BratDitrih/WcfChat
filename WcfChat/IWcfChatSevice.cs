﻿using System.ServiceModel;

namespace WcfChatService
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
    }

    public interface IMessageCallBack
    {
        [OperationContract(IsOneWay = true)]
        void GetMessage(string message);
    }
}