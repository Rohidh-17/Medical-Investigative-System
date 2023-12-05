using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDS.Models
{
    public class CTScanDetails
    {
        public int? CXRaysCode { set; get; }
        public string BillNo { set; get; }
        public string BillDate { set; get; }
        public string PatientID { set; get; }
        public string PatientName { set; get; }
        public string TreatmentID { set; get; }
        public string TreatmentDate { set; get; }
        public string DoctorName { set; get; }
        public string XRayType { set; get; }
        public string ResultDetails { set; get; }
        public string Amount { set; get; }
    }
}