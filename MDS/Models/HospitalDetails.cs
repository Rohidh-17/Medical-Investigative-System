using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDS.Models
{
    public class HospitalDetails
    {
        public int? HospitalCode { set; get; }
        public string HospitalID { set; get; }
        public string HospitalName { set; get; }
        public string Address { set; get; }
        public string City { set; get; }
        public string MobileNo { set; get; }
        public string EmailID { set; get; }
        public string Password { set; get; }
        public string HospitalDetail { set; get; } 
    }
}