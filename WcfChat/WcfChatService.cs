using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WcfChat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WcfChatService : IWcfChatSevice
    {
        private IList<User> _users = new List<User>();

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

            string dispatchTime = DateTime.Now.ToShortTimeString();

            string senderName;
            if (senderUserId == null) senderName = "";
            else
            {
                var senderUser = _users.FirstOrDefault(x => x.Id == senderUserId);
                if (senderUser == null) return;
                senderName = " " + senderUser.Name;
            }

            stringBuilder.Append(dispatchTime + senderName + ": " + message);

            foreach (var user in _users)
            {
                user.OperationContext.GetCallbackChannel<IMessageCallBack>()
                    .GetMessage(stringBuilder.ToString());
            }
        }
    }
}
