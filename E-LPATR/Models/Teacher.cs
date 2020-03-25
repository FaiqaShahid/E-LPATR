using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class Teacher 
    {
        public int Id { get; set; }
        public TeachersRequests TeacherRequests { get; set; }
    }
}