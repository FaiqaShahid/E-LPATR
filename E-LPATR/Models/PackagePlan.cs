using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class PackagePlan
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public DateTime DeliveryTime { get; set; }
    }
}