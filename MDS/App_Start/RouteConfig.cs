using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MDS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "DegreeDetails",
              url: "DegreeDetails",
              defaults: new { controller = "Admin", action = "DegreeDetails", id = UrlParameter.Optional }
          );

           

            routes.MapRoute(
              name: "DoctorRegistrationDetails",
              url: "DoctorRegistrationDetails",
              defaults: new { controller = "Admin", action = "DoctorRegistrationDetails", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "HospitalApproval",
              url: "HospitalApproval",
              defaults: new { controller = "Admin", action = "HospitalApproval", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "HospitalDetails",
              url: "HospitalDetails",
              defaults: new { controller = "Admin", action = "HospitalDetails", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "PatientDetails",
              url: "PatientDetails",
              defaults: new { controller = "Admin", action = "PatientDetails", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "TreatmentDetails",
              url: "TreatmentDetails",
              defaults: new { controller = "Admin", action = "TreatmentDetails", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "XRayDetails",
              url: "XRayDetails",
              defaults: new { controller = "Admin", action = "XRayDetails", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "BloodPressureDetails",
              url: "BloodPressureDetails",
              defaults: new { controller = "Admin", action = "BloodPressureDetails", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "CXRaysDetails",
              url: "CXRaysDetails",
              defaults: new { controller = "Admin", action = "CXRaysDetails", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "CTScanDetails",
              url: "CTScanDetails",
              defaults: new { controller = "Admin", action = "CTScanDetails", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "ReportDetails",
              url: "ReportDetails",
              defaults: new { controller = "Admin", action = "ReportDetails", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "BloodPressureReportDetails",
              url: "BloodPressureReportDetails",
              defaults: new { controller = "Admin", action = "BloodPressureReportDetails", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "XRayReportDetails",
              url: "XRayReportDetails",
              defaults: new { controller = "Admin", action = "XRayReportDetails", id = UrlParameter.Optional }
          );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

          
        }
    }
}