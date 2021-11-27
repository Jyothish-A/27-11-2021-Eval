using System;
using System.Collections.Generic;

namespace TravelEvalApp.Models
{
    public partial class Request
    {
        public int Requestid { get; set; }
        public string TravelCause { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Mode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int? NoDays { get; set; }
        public string Priority { get; set; }
        public int? ProjectId { get; set; }
        public int? EmpId { get; set; }
        public string Status { get; set; }
    }
}
