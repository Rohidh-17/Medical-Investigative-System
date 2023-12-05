using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDS.Models
{
    public class DoctorRegistrationDetails
    {
        public int? DoctorCode { set; get; }
        public string DoctorName { set; get; }
        public string DegreeName { set; get; }
        public string Speciality { set; get; }
        public string HospitalName { set; get; }
        public string Address { set; get; }
        public string City { set; get; }
        public string MobileNo { set; get; }
        public string EmailID { set; get; }
        public string Password { set; get; } 


    }
}