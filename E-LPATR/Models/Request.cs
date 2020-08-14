using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Describtion { get; set; }
        public int Cost { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
        public virtual User Student { get; set; }
        public virtual User Teacher { get; set; }
        public DateTime DeliveryTime { get; set; }
        public virtual RequestStatus RequestStatus { get; set; }
        public virtual Payment Payment { get; set; }
    }
}