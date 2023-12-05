using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDS.Models
{
    public class BloodPressureDetails
    {
        public int? BloodPressureCode { set; get; }
        public string BillDate { set; get; }
        public string PatientID { set; get; }
        public string PatientName { set; get; }
        public string TreatmentID { set; get; }
        public string TreatmentDate { set; get; }
        public string DoctorName { set; get; }
        public string Pressure { set; get; }
        public string BPRate { set; get; }
        public string Amount { set; get; }
        
    }
}