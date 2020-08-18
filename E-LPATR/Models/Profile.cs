using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class Profile : IListable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public virtual int TeacherId { get; set; }
        public virtual User Teacher { get; set; }
        public virtual int ProfileStatusId { get; set; }
        public virtual ProfileStatus ProfileStatus { get; set; }
        public virtual int SubcategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }
        public virtual int PackagePlanId { get; set; }
        public virtual PackagePlan PackagePlan { get; set; }
    }
}