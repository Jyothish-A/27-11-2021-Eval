using System;
using System.Collections.Generic;

namespace TravelEvalApp.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int? Phone { get; set; }
        public int Loginid { get; set; }

        public virtual Login Login { get; set; }
    }
}
