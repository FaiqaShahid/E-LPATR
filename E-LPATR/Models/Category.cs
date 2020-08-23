using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class Category : IListable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public virtual ICollection<Subcategory> Subcategory { get; set; }
    }
}