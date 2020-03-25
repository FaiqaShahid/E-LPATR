using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual User Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Request Request { get; set; }
        public DateTime DateTime { get; set; }
    }
}