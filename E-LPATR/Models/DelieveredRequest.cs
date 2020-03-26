using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class DelieveredRequest
    {
        public int Id { get; set; }
        public byte[] Attachment { get; set; }
        public string Description { get; set; }
        public virtual Request Request{ get; set; }
    }
}