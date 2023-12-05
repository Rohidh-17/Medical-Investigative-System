using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDS.Models
{
    public class XRayDetails
    {
        public int? XRayCode { set; get; }
        public string PatientID { set; get; }
        public string PatientName { set; get; }
        public string BloodPressureAmount { set; get; }
        public string CTAmount { set; get; }
        public string XRayAmount { set; get; }
        public string UrineTestAmount { set; get; }
        public string DoctorFees { set; get; }
        public string BedCharges { set; get; }
        public string OtherCharges { set; get; }
        public string TotalAmount { set; get; }
        public string PaidAmount { set; get; } 

    }
}