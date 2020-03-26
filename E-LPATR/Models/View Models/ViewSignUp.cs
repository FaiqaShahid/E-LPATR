using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_LPATR.Models
{
    public class ViewSignUp
    {
        public User User { get; set; }
        public List<SelectListItem> Countries { get; set; }
    }
}