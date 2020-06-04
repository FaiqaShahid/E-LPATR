using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_LPATR.Models.View_Models
{
    public class ViewProfile
    {
        public User User { get; set; }
        public IEnumerable<Profile> Profiles { get; set; }
    }
}