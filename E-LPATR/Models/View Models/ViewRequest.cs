using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_LPATR.Models
{
    public class ViewRequest
    {
        public Request Request { get; set; }
        public List<RequestMessage> RequestMessage { get; set; }
        public RequestMessage AddMessage { get; set; }
    }
}