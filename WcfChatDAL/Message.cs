using System;

namespace WcfChatDAL
{
    public class Message
    {
        public int Id { get; set; }
        public string SenderUserId { get; set; }
        public string SenderUserName { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }

        public override string ToString() => $"{SendTime.ToShortTimeString()} {SenderUserName}: {Text}";

    }
}
