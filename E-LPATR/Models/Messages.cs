using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class Messages
    {
        public int Id { get; set; }
        public virtual User Student { get; set; }
        public virtual User Teacher { get; set; }
        public string Message { get; set; }
        public byte[] Attachment { get; set; }
        public DateTime DateTime { get; set; }
    }
}