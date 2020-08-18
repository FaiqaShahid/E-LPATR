using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class RequestMessage
    {
        public int Id { get; set; }
        public virtual Request Request { get; set; }
        public string Message { get; set; }
        public virtual User Sender { get; set; }
        public virtual User Reciever { get; set; }
        public byte[] Attachment { get; set; }
        public DateTime DateTime { get; set; }
    }
}