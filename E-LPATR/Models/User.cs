using System;
using System.Collections.Generic;
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
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoinedOn { get; set; }
        public virtual Country Country { get; set; }
        public virtual int RoleID { get; set; }
        public virtual Role Role { get; set; }
        public virtual int AccountStatusID { get; set; }
        public virtual AccountStatus AccountStatus { get; set; }

        public static implicit operator User(HttpCookie v)
        {
            throw new NotImplementedException();
        }
    }
}