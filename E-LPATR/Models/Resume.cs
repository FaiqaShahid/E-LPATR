using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public virtual User Teacher { get; set; }
        public byte[] Attachment { get; set; }
    }
}