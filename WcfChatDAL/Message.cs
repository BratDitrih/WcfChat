using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfChatDAL
{
    public class Message
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public DateTime SendTime { get; set; }
        public string Text { get; set; }
    }
}
