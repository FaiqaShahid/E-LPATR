using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_LPATR.Models.View_Models
{
    public class ViewCreateProfile
    {
        public Profile Profile { get; set; }
        public List<SelectListItem> Subcategory { get; set; }
        public List<SelectListItem> Category { get; set; }
        public ProfileStatus ProfileStatus { get; set; }
    }
}