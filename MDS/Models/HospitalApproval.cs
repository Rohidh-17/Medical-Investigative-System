using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDS.Models
{
    public class HospitalApproval
    {
        public int? HospitalApprovalCode { set; get; }
        public int HospitalCode { set; get; }
        public string HospitalID { set; get; }
        public string HospitalName { set; get; }
        public string Address { set; get; }
        public string MobileNo { set; get; }
        public string HospitalDetail { set; get; }
    }
}