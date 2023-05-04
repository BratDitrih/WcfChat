using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using WcfChatDAL;

namespace WcfChat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WcfChatService : IWcfChatSevice
    {
        private IList<User> _users = new List<User>();
        private readonly MessageRepository _repository;

        public WcfChatService()
        {
            try
            {
                _repository = new MessageRepository();
            }
            catch
            {
                throw new Exception("Ошибка при подключении к БД");
            }
            
        }

        public string Connect(string userName)
        {
            var newUser = new User()
            {
                Name = userName,
                OperationContext = OperationContext.Current
            };

            _users.Add(newUser);
            SendMessage(newUser.Name + " подключился");
            return newUser.Id;
        }

        public void Disconnect(string id)
        {
            var userToRemove = _users.FirstOrDefault(x => x.Id == id);
            if (userToRemove == null) return;

            SendMessage(userToRemove.Name + " отключился");
            _users.Remove(userToRemove);
        }

        public void SendMessage(string message, string senderUserId = null)
        {
            StringBuilder stringBuilder = new StringBuilder();

            DateTime dispatchTime = DateTime.Now;

            string senderName;
            if (senderUserId == null) senderName = "Server";
            else
            {
                var senderUser = _users.FirstOrDefault(x => x.Id == senderUserId);
                if (senderUser == null) return;
                senderName = senderUser.Name;
            }

            stringBuilder.Append(dispatchTime.ToShortTimeString() + " " + senderName + ": " + message);

            var newMessage = new Message()
            {
                Text = message,
                SenderUserId = senderUserId,
                SenderUserName = senderName,
                SendTime = dispatchTime
            };
            try
            {
                _repository.Add(newMessage);
            }
            catch
            {
                throw new Exception("Ошибка при добавлении сообщения в БД");
            }

            foreach (var user in _users)
            {
                user.OperationContext.GetCallbackChannel<IMessageCallBack>()
                    .GetMessage(stringBuilder.ToString());
            }
        }

        public IList<string> GetAllMessages()
        {
            try
            {
                var messages = _repository.GetAll();
                return messages.Select(x => x.ToString()).ToList();
            }
            catch
            {
                throw new Exception("Ошибка при запросе сообщений из БД");
            }
        }
    }
}
