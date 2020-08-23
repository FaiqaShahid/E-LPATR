using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class Earning
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public virtual User Teacher { get; set; }
        public int Cost { get; set; }
        public int RequestId { get; set; }
        public virtual Request Request { get; set; }
    }
}