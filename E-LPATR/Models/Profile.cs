using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Desciption { get; set; }
        public virtual PackagePlan PackagePlan { get; set; }
    }
}