using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class PackagePlan
    {
        public int Id { get; set; }
        [Range(100,Int32.MaxValue)]
        public int CostPerHour { get; set; }
        [Range(100, Int32.MaxValue)]
        public int CostPerDay { get; set; }
        [Range(100, Int32.MaxValue)]
        public int CostPer3Days { get; set; }
    }
}