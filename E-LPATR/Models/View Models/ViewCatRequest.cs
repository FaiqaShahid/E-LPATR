using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models.View_Models
{
    public class ViewCatRequest
    {
        public List<Request> Request { get; set; }
        public List<Category> Category { get; set; }
    }
}