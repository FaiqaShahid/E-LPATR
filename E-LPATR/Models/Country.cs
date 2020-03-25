using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class Country : IListable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}