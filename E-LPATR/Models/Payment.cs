using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
        public int Cost { get; set; }
        public DateTime DateTime { get; set; }
        public string PaidVia { get; set; }
    }
}