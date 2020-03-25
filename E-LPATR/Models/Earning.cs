using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class Earning
    {
        public int Id { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual EarningStatus EarningStatus { get; set; }
        public string Cost { get; set; }
        public virtual Request Request { get; set; }
    }
}