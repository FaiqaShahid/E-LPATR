using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class Issues
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public string Issue { get; set; }
        public string Attachment { get; set; }
        public DateTime DateTime { get; set; }
    }
}