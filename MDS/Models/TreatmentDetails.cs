using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDS.Models
{
    public class TreatmentDetails
    {
        public int? TreatmentCode { set; get; }
        public string HospitalID { set; get; }
        public string HospitalName { set; get; }
        public string PatientID { set; get; }
        public string PatientName { set; get; }
        public string Address { set; get; }
        public string DoctorName { set; get; }
        public string Speciality { set; get; }
        public string TreatmentID { set; get; }
        public string TreatmentDate { set; get; }
        public string Prescription { set; get; } 

    }
}