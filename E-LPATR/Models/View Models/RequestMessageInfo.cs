using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models.View_Models
{
    public class RequestMessageInfo
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public byte[] Attachment { get; set; }
        public DateTime DateTime { get; set; }
    }
}