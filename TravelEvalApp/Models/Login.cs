using System;
using System.Collections.Generic;

namespace TravelEvalApp.Models
{
    public partial class Login
    {
        public Login()
        {
            Employee = new HashSet<Employee>();
        }

        public int Loginid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Usertype { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
