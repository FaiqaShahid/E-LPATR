using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_LPATR.Models.View_Models
{
    public class ViewProfile
    {
        public virtual Profile Profile { get; set; }
        public virtual List<SelectListItem> Subcategory { get; set; }
        
    }
}