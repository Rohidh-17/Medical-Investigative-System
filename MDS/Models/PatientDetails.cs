using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDS.Models
{
    public class PatientDetails
    {
        public int? PatientCode { set; get; }
        public string HospitalID { set; get; }
        public string HospitalName { set; get; }
        public string PatientID { set; get; }
        public string PatientName { set; get; }
        public string Address { set; get; }
        public string City { set; get; }
        public string MobileNo { set; get; }
        public string DiseasesDetail { set; get; } 
    }
}