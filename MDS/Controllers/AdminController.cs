using MDS.Models;
using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace MDS.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult DegreeDetails()
        {
            return View();
        }

  
        public ActionResult DegreeSave(Degree objDegree)
        {
            Common objCom = new Common();
            SqlConnection objConnection = new SqlConnection(objCom.GetConnectionStr());
            SqlCommand objCommand = new SqlCommand();
            try
            {
                objConnection.Open();
                objCommand = new SqlCommand("sp_DegreeDetails_Insert", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                if (objDegree.DegreeCode > 0)
                    objCommand.Parameters.AddWithValue("@DegreeCode", objDegree.DegreeCode);
                objCommand.Parameters.AddWithValue("@DegreeName", objDegree.DegreeName);

                objCommand.ExecuteNonQuery();
                objCommand.Dispose();
                return Json(new { Result = "Success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UQ_DegreeName"))
                    return Json(new { Result = "Degree Name Already Exists" }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                objConnection.Close();
                objCommand.Dispose();
            }

        }

       
        public ActionResult Degree_Select(int? DegreeCode)
        {
            try
            {
                Common com = new Common();
                if (DegreeCode == null)
                {
                    var jsonResult = Json(new { Result = "Success", Data = com.objJSON_dTable("sp_Degree_GetAll") }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                else
                {
                    var jsonResult = Json(new { Result = "Success", Data = com.objJSON_dTable("sp_Degree_GetAll @DegreeCode=" + DegreeCode) }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;

                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Degree_Delete(int? DegreeCode)
        {
            try
            {
                Common com = new Common();
                if (DegreeCode == null)
                {
                    var jsonResult = Json(new { Result = "Success", Data = com.objJSON_dTable("sp_Degree_Delete") }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                else
                {
                    var jsonResult = Json(new { Result = "Success", Data = com.objJSON_dTable("sp_Degree_Delete @DegreeCode=" + DegreeCode) }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;

                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult DoctorRegistrationDetails()
        {
            return View();
        }

        [HttpPost]

        public ActionResult DoctorRegisSave(DoctorRegistrationDetails objDoctorRegis)
        {
            Common objCom = new Common();
            SqlConnection objConnection = new SqlConnection(objCom.GetConnectionStr());
            SqlCommand objCommand = new SqlCommand();
            try
            {
                objConnection.Open();
                objCommand = new SqlCommand("sp_DoctorRegistrationDetails_Insert", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                if (objDoctorRegis.DoctorCode > 0)
                    objCommand.Parameters.AddWithValue("@DoctorCode", objDoctorRegis.DoctorCode);
                objCommand.Parameters.AddWithValue("@DegreeName", objDoctorRegis.DegreeName);

                objCommand.Parameters.AddWithValue("@DoctorName", objDoctorRegis.DoctorName);
                objCommand.Parameters.AddWithValue("@Speciality", objDoctorRegis.Speciality);
                objCommand.Parameters.AddWithValue("@HospitalName", objDoctorRegis.HospitalName);
                objCommand.Parameters.AddWithValue("@Address", objDoctorRegis.Address);
                objCommand.Parameters.AddWithValue("@City", objDoctorRegis.City);
                objCommand.Parameters.AddWithValue("@MobileNo", objDoctorRegis.MobileNo);
                objCommand.Parameters.AddWithValue("@EmailID", objDoctorRegis.EmailID);
                objCommand.Parameters.AddWithValue("@Password", objDoctorRegis.Password);
                objCommand.ExecuteNonQuery();
                objCommand.Dispose();
                return Json(new { Result = "Success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                objConnection.Close();
                objCommand.Dispose();
            }

        }

        public ActionResult HospitalDetails()
        {
            return View();
        }

        [HttpPost]

        public ActionResult HospitalSave(HospitalDetails objHospital)
        {
            Common objCom = new Common();
            SqlConnection objConnection = new SqlConnection(objCom.GetConnectionStr());
            SqlCommand objCommand = new SqlCommand();
            try
            {
                objConnection.Open();
                objCommand = new SqlCommand("sp_HospitalDetails_Insert", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                if (objHospital.HospitalCode > 0)
                    objCommand.Parameters.AddWithValue("@HospitalCode", objHospital.HospitalCode);
                objCommand.Parameters.AddWithValue("@HospitalID", objHospital.HospitalID);

                objCommand.Parameters.AddWithValue("@HospitalName", objHospital.HospitalName);
                objCommand.Parameters.AddWithValue("@Address", objHospital.Address);
                objCommand.Parameters.AddWithValue("@City", objHospital.City);
                objCommand.Parameters.AddWithValue("@MobileNo", objHospital.MobileNo);
                objCommand.Parameters.AddWithValue("@EmailID", objHospital.EmailID);
                objCommand.Parameters.AddWithValue("@Password", objHospital.Password);
                objCommand.Parameters.AddWithValue("@HospitalDetail", objHospital.HospitalDetail);
                objCommand.ExecuteNonQuery();
                objCommand.Dispose();
                return Json(new { Result = "Success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                objConnection.Close();
                objCommand.Dispose();
            }

        }

        [HttpPost]
        public ActionResult Hospital_Select(int? HospitalCode)
        {
            try
            {
                Common com = new Common();
                if (HospitalCode == null)
                {
                    var jsonResult = Json(new { Result = "Success", Data = com.objJSON_dTable("sp_Hospital_GetAll") }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                else
                {
                    var jsonResult = Json(new { Result = "Success", Data = com.objJSON_dTable("sp_Hospital_GetAll @HospitalCode=" + HospitalCode) }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;

                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Hospital_Approval_Pending_Select(int? HospitalCode)
        {
            try
            {
                Common com = new Common();

                var jsonResult = Json(new { Result = "Success", Data = com.objJSON_dTable("sp_Hospital_GetAll_Approval_Pending") }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;

            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult HospitalApproval()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HospitalApprovalStatus(int HospitalCode)
        {
            Common objCom = new Common();
            SqlConnection objConnection = new SqlConnection(objCom.GetConnectionStr());
            SqlCommand objCommand = new SqlCommand();
            try
            {
                objConnection.Open();
                objCommand = new SqlCommand("sp_HospitalCode_Status_Approval", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;

                objCommand.Parameters.AddWithValue("@HospitalCode", HospitalCode);

                
                objCommand.ExecuteNonQuery();
                objCommand.Dispose();
                return Json(new { Result = "Success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                objConnection.Close();
                objCommand.Dispose();
            }

        }

        public ActionResult AdminLoginPage()
        {
            return View();
        }

        public ActionResult LoginPage(string HospitalID, string Password)
        {
            Common objCom = new Common();
            SqlConnection objConnection = new SqlConnection(objCom.GetConnectionStr());
            SqlCommand objCommand = new SqlCommand();
            try
            {
                objConnection.Open();
                objCommand = new SqlCommand("sp_HospitalLogin", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;


                objCommand.Parameters.AddWithValue("@HospitalID", HospitalID);
                objCommand.Parameters.AddWithValue("@Password", Password);
                DataTable objDataTable = objCom.objDT(objCommand);
                
                objCommand.Dispose();
                return Json(new { Result = "Success",Data=objDataTable.Rows.Count   }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                objConnection.Close();
                objCommand.Dispose();
            }

        }

        public ActionResult PatientDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PatientSave(PatientDetails objPatient)
        {
            Common objCom = new Common();
            SqlConnection objConnection = new SqlConnection(objCom.GetConnectionStr());
            SqlCommand objCommand = new SqlCommand();
            try
            {
                objConnection.Open();
                objCommand = new SqlCommand("sp_PatientDetails_Insert", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                if (objPatient.PatientCode > 0)
                    objCommand.Parameters.AddWithValue("@PatientCode", objPatient.PatientCode);

                objCommand.Parameters.AddWithValue("@HospitalID", objPatient.HospitalID);
                objCommand.Parameters.AddWithValue("@HospitalName", objPatient.HospitalName);
                objCommand.Parameters.AddWithValue("@PatientID", objPatient.PatientID);
                objCommand.Parameters.AddWithValue("@PatientName", objPatient.PatientName);
                objCommand.Parameters.AddWithValue("@Address", objPatient.Address);
                objCommand.Parameters.AddWithValue("@City", objPatient.City);
                objCommand.Parameters.AddWithValue("@MobileNo", objPatient.MobileNo);
                objCommand.Parameters.AddWithValue("@DiseasesDetail", objPatient.DiseasesDetail);
                objCommand.ExecuteNonQuery();
                objCommand.Dispose();
                return Json(new { Result = "Success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                objConnection.Close();
                objCommand.Dispose();
            }

        }

        [HttpPost]
        public ActionResult PatientDetails_Select(int? PatientCode)
        {
            try
            {
                Common com = new Common();
                if (PatientCode == null)
                {
                    var jsonResult = Json(new { Result = "Success", Data = com.objJSON_dTable("sp_PatientDetails_GetAll") }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                else
                {
                    var jsonResult = Json(new { Result = "Success", Data = com.objJSON_dTable("sp_PatientDetails_GetAll @PatientCode=" + PatientCode) }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;

                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult TreatmentDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TreatmentSave(TreatmentDetails objTreatment)
        {
            Common objCom = new Common();
            SqlConnection objConnection = new SqlConnection(objCom.GetConnectionStr());
            SqlCommand objCommand = new SqlCommand();
            try
            {
                objConnection.Open();
                objCommand = new SqlCommand("sp_TreatmentDetails_Insert", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                if (objTreatment.TreatmentCode > 0)
                    objCommand.Parameters.AddWithValue("@TreatmentCode", objTreatment.TreatmentCode);

                objCommand.Parameters.AddWithValue("@HospitalID", objTreatment.HospitalID);
                objCommand.Parameters.AddWithValue("@HospitalName", objTreatment.HospitalName);
                objCommand.Parameters.AddWithValue("@PatientID", objTreatment.PatientID);
                objCommand.Parameters.AddWithValue("@PatientName", objTreatment.PatientName);
                objCommand.Parameters.AddWithValue("@Address", objTreatment.Address);
                objCommand.Parameters.AddWithValue("@DoctorName", objTreatment.DoctorName);
                objCommand.Parameters.AddWithValue("@Speciality", objTreatment.Speciality);
                objCommand.Parameters.AddWithValue("@TreatmentID", objTreatment.TreatmentID);
                objCommand.Parameters.AddWithValue("@TreatmentDate", objTreatment.TreatmentDate);
                objCommand.Parameters.AddWithValue("@Prescription", objTreatment.Prescription);

                objCommand.ExecuteNonQuery();
                objCommand.Dispose();
                return Json(new { Result = "Success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                objConnection.Close();
                objCommand.Dispose();
            }

        }

        public ActionResult XRayDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult XRaySave(XRayDetails objXRay)
        {
            Common objCom = new Common();
            SqlConnection objConnection = new SqlConnection(objCom.GetConnectionStr());
            SqlCommand objCommand = new SqlCommand();
            try
            {
                objConnection.Open();
                objCommand = new SqlCommand("sp_XRayDetails_Insert", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                if (objXRay.XRayCode > 0)
                    objCommand.Parameters.AddWithValue("@XRayCode", objXRay.XRayCode);

                objCommand.Parameters.AddWithValue("@PatientID", objXRay.PatientID);
                objCommand.Parameters.AddWithValue("@PatientName", objXRay.PatientName);
                objCommand.Parameters.AddWithValue("@BloodPressureAmount", objXRay.BloodPressureAmount);
                objCommand.Parameters.AddWithValue("@CTAmount", objXRay.CTAmount);
                objCommand.Parameters.AddWithValue("@XRayAmount", objXRay.XRayAmount);
                objCommand.Parameters.AddWithValue("@UrineTestAmount", objXRay.UrineTestAmount);
                objCommand.Parameters.AddWithValue("@DoctorFees", objXRay.DoctorFees);
                objCommand.Parameters.AddWithValue("@BedCharges", objXRay.BedCharges);
                objCommand.Parameters.AddWithValue("@OtherCharges", objXRay.OtherCharges);
                objCommand.Parameters.AddWithValue("@TotalAmount", objXRay.TotalAmount);
                objCommand.Parameters.AddWithValue("@PaidAmount", objXRay.PaidAmount);


                objCommand.ExecuteNonQuery();
                objCommand.Dispose();
                return Json(new { Result = "Success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                objConnection.Close();
                objCommand.Dispose();
            }

        }

        public ActionResult AdminLogins()
        {
            return View();
        }

        public ActionResult BloodPressureDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BloodPressureSave(BloodPressureDetails objBloodPressure)
        {
            Common objCom = new Common();
            SqlConnection objConnection = new SqlConnection(objCom.GetConnectionStr());
            SqlCommand objCommand = new SqlCommand();
            try
            {
                objConnection.Open();
                objCommand = new SqlCommand("sp_BloodPressureDetails_Insert", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                if (objBloodPressure.BloodPressureCode > 0)
                    objCommand.Parameters.AddWithValue("@BloodPressureCode", objBloodPressure.BloodPressureCode);

                objCommand.Parameters.AddWithValue("@BillDate", objBloodPressure.BillDate);
                objCommand.Parameters.AddWithValue("@PatientID", objBloodPressure.PatientID);
                objCommand.Parameters.AddWithValue("@PatientName", objBloodPressure.PatientName);
                objCommand.Parameters.AddWithValue("@TreatmentID", objBloodPressure.TreatmentID);
                objCommand.Parameters.AddWithValue("@DoctorName", objBloodPressure.DoctorName);
                objCommand.Parameters.AddWithValue("@TreatmentDate", objBloodPressure.TreatmentDate);
                objCommand.Parameters.AddWithValue("@Pressure", objBloodPressure.Pressure);
                objCommand.Parameters.AddWithValue("@BPRate", objBloodPressure.BPRate);
                objCommand.Parameters.AddWithValue("@Amount", objBloodPressure.Amount);

                objCommand.ExecuteNonQuery();
                objCommand.Dispose();
                return Json(new { Result = "Success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                objConnection.Close();
                objCommand.Dispose();
            }

        }

        [HttpPost]
        public ActionResult BloodPressureDetails_Select(int? BloodPressureCode)
        {
            try
            {
                Common com = new Common();
                if (BloodPressureCode == null)
                {
                    var jsonResult = Json(new { Result = "Success", Data = com.objJSON_dTable("sp_BloodPressureDetails_GetAll") }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                else
                {
                    var jsonResult = Json(new { Result = "Success", Data = com.objJSON_dTable("sp_BloodPressureDetails_GetAll @BloodPressureCode=" + BloodPressureCode) }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;

                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CXRaysDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult XRays_Save(CXRaysDetails objXRays)
        {
            Common objCom = new Common();
            SqlConnection objConnection = new SqlConnection(objCom.GetConnectionStr());
            SqlCommand objCommand = new SqlCommand();
            try
            {
                objConnection.Open();
                objCommand = new SqlCommand("sp_CXRaysDetails_Insert", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                if (objXRays.CXRaysCode > 0)
                    objCommand.Parameters.AddWithValue("@CXRaysCode", objXRays.CXRaysCode);

                objCommand.Parameters.AddWithValue("@BillDate", objXRays.BillDate);
                objCommand.Parameters.AddWithValue("@PatientID", objXRays.PatientID);
                objCommand.Parameters.AddWithValue("@PatientName", objXRays.PatientName);
                objCommand.Parameters.AddWithValue("@TreatmentID", objXRays.TreatmentID);
                objCommand.Parameters.AddWithValue("@DoctorName", objXRays.DoctorName);
                objCommand.Parameters.AddWithValue("@TreatmentDate", objXRays.TreatmentDate);
                objCommand.Parameters.AddWithValue("@BillNo", objXRays.BillNo);
                objCommand.Parameters.AddWithValue("@XRayType", objXRays.XRayType);
                objCommand.Parameters.AddWithValue("@ResultDetails", objXRays.ResultDetails);
                objCommand.Parameters.AddWithValue("@Amount", objXRays.Amount);

                objCommand.ExecuteNonQuery();
                objCommand.Dispose();
                return Json(new { Result = "Success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                objConnection.Close();
                objCommand.Dispose();
            }

        }

        [HttpPost]
        public ActionResult XRayDetails_Select(int? XRayCode)
        {
            try
            {
                Common com = new Common();
                if (XRayCode == null)
                {
                    var jsonResult = Json(new { Result = "Success", Data = com.objJSON_dTable("sp_XRayDetails_GetAll") }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                else
                {
                    var jsonResult = Json(new { Result = "Success", Data = com.objJSON_dTable("sp_XRayDetails_GetAll @XRayCode=" + XRayCode) }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;

                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult CTScanDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CTScanSave(CTScanDetails objXRays)
        {
            Common objCom = new Common();
            SqlConnection objConnection = new SqlConnection(objCom.GetConnectionStr());
            SqlCommand objCommand = new SqlCommand();
            try
            {
                objConnection.Open();
                objCommand = new SqlCommand("sp_CTScanDetails_Insert", objConnection);
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                if (objXRays.CXRaysCode > 0)
                    objCommand.Parameters.AddWithValue("@CXRaysCode", objXRays.CXRaysCode);

                objCommand.Parameters.AddWithValue("@BillDate", objXRays.BillDate);
                objCommand.Parameters.AddWithValue("@PatientID", objXRays.PatientID);
                objCommand.Parameters.AddWithValue("@PatientName", objXRays.PatientName);
                objCommand.Parameters.AddWithValue("@TreatmentID", objXRays.TreatmentID);
                objCommand.Parameters.AddWithValue("@DoctorName", objXRays.DoctorName);
                objCommand.Parameters.AddWithValue("@TreatmentDate", objXRays.TreatmentDate);
                objCommand.Parameters.AddWithValue("@BillNo", objXRays.BillNo);
                objCommand.Parameters.AddWithValue("@XRayType", objXRays.XRayType);
                objCommand.Parameters.AddWithValue("@ResultDetails", objXRays.ResultDetails);
                objCommand.Parameters.AddWithValue("@Amount", objXRays.Amount);

                objCommand.ExecuteNonQuery();
                objCommand.Dispose();
                return Json(new { Result = "Success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Result = ex.Message }, JsonRequestBehavior.AllowGet);
            }
            finally
            {
                objConnection.Close();
                objCommand.Dispose();
            }

        }

        public ActionResult ReportDetails()
        {
            return View();
        }
        public ActionResult BloodPressureReportDetails()
        {
            return View();
        }
        public ActionResult XRayReportDetails()
        {
            return View();
        }

    }
}
