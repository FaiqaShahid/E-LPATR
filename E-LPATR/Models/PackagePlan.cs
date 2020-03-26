using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class PackagePlan
    {
        public int Id { get; set; }
        public string CostPerHour { get; set; }
        public string CostPerDay { get; set; }
        public string CostPer3Days { get; set; }
    }
}