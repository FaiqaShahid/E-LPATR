﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_LPATR.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public bool Active { get; set; }
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinedOn { get; set; }
        public virtual Country Country { get; set; }
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
        public int AccountStatusID { get; set; }
        public virtual AccountStatus AccountStatus { get; set; }
        public virtual Degree Degree { get; set; }

    }
}