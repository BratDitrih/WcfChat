using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
