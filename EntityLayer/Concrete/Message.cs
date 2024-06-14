
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        public int MessageID { get; set; }
        public string SenderNameSurname { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverNameSurname { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
        public bool ReceiverDelete { get; set; } = false;
        public bool SenderDelete { get; set; } = false;
        public bool ReceiverTrashDelete { get; set; } =false;
        public bool SenderTrashDelete { get; set; }  = false;
    }

}
