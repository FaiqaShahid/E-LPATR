using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class Issues
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string IssueMessage { get; set; }
        public byte[] Attachment { get; set; }
        public DateTime DateTime { get; set; }
    }
}