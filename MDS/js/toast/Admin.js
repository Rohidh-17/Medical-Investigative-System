var app = angular.module('MyApp', []);

app.controller('DegreeController', function ($scope, $http) {
    $scope.ModelInitialize = function () {
        $scope.Degree = {
            DegreeCode: "",
            DegreeName: "",

        }
    }

    $scope.ModelInitialize();

    $scope.FormLoad = function () {

        $http({
            method: 'POST',
            url: '/Admin/Degree_Select',

        })
           .success(function (data) {
               if (data.Result == "Success") {
                   $scope.Record = JSON.parse(data.Data);
               }
               else
                   alert(data);
           });
    }

    $scope.FormLoad();

    $scope.Edit = function (DegreeCode) {

        $http({
            method: 'POST',
            url: '/Admin/Degree_Select',
            data: {
                DegreeCode: DegreeCode
            }
        })
           .success(function (data) {
               $scope.Degree = JSON.parse(data.Data)[0];
           });
    }
    $scope.Delete = function (DegreeCode) {
        alert("Record is Deleted!");

        $http({
            method: 'POST',
            url: '/Admin/Degree_Delete',
            data: {
                DegreeCode: DegreeCode
            }

        })
           .success(function (data) {
               $scope.Degree = JSON.parse(data.Data)[0];
               $scope.FormLoad();
           });
    }

    $scope.Save = function () {
        if ($scope.Degree.DegreeName == "") {
            alert("Please type  Degree Name ");
            $("#txtDegreeName").focus();
            return;
        }


        $http({
            method: 'POST',
            url: '/Admin/DegreeSave',
            data: {
                objDegree: $scope.Degree
            }
        })
         .success(function (data) {
             if (data.Result == "Success") {
                 alert("The record is saved");
                 $scope.FormLoad();
                 $scope.ModelInitialize();
             }
             else
                 alert(data);
         });
    }

});

app.controller('DoctorController', function ($scope, $http) {
    $scope.ModelInitialize = function () {
        $scope.DoctorRegis = {
            DoctorCode: "",
            DoctorName: "",
            DegreeName: "",
            Speciality: "",
            HospitalName: "",
            Address: "",
            City: "",
            MobileNo: "",
            EmailID: "",
            Password: "",

        }
    }

    $scope.ModelInitialize();

    $scope.FormLoad = function () {

        $http({
            method: 'POST',
            url: '/Admin/DoctorRegis_Select',

        })
           .success(function (data) {
               if (data.Result == "Success") {
                   $scope.Record = JSON.parse(data.Data);
               }
               else
                   alert(data);
           });
    }
    $scope.FormLoad();

    $scope.DegreeLoad = function () {

        $http({
            method: 'POST',
            url: '/Admin/Degree_Select',

        })
           .success(function (data) {
               if (data.Result == "Success") {
                   $scope.Degree = JSON.parse(data.Data);
               }
               else
                   alert(data);
           });
    }

    $scope.DegreeLoad();

    $scope.Save = function () {
        if ($scope.DoctorRegis.DoctorName == "") {
            alert("Please type  Doctor Name ");
            $("#txtDoctorName").focus();
            return;
        }

        if ($scope.DoctorRegis.DegreeName == "") {
            alert("Please type  Degree Name ");
            $("#txtDegreeName").focus();
            return;
        }
        if ($scope.DoctorRegis.Speciality == "") {
            alert("Please type  Speciality ");
            $("#txtSpeciality").focus();
            return;
        }
        if ($scope.DoctorRegis.HospitalName == "") {
            alert("Please type  Hospital Name ");
            $("#txtHospitalName").focus();
            return;
        }
        if ($scope.DoctorRegis.Address == "") {
            alert("Please type Address ");
            $("#txtAddress").focus();
            return;
        }
        if ($scope.DoctorRegis.City == "") {
            alert("Please type City");
            $("#txtCity").focus();
            return;
        }
        if ($scope.DoctorRegis.MobileNo == "") {
            alert("Please type Mobile Number");
            $("#txtMobileNo").focus();
            return;
        }
        if ($scope.DoctorRegis.EmailID == "") {
            alert("Please type Email ID");
            $("#txtEmailID").focus();
            return;
        }
        if ($scope.DoctorRegis.Password == "") {
            alert("Please type Password");
            $("#txtPassword").focus();
            return;
        }


        $http({
            method: 'POST',
            url: '/Admin/DoctorRegisSave',
            data: {
                objDoctorRegis: $scope.DoctorRegis
            }
        })
         .success(function (data) {
             if (data.Result == "Success") {
                 alert("The record is saved");
                 $scope.FormLoad();
                 $scope.ModelInitialize();
             }
             else
                 alert(data);
         });
    }

});

app.controller('HospitalDetailsController', function ($scope, $http) {
    $scope.ModelInitialize = function () {
        $scope.Hospital = {
            HospitalCode: "",
            HospitalID: "",
            HospitalName: "",
            Address: "",
            City: "",
            MobileNo: "",
            EmailID: "",
            Password: "",
            HospitalDetail: "",
        }

        $scope.HospitalApproval = {
            HospitalCode: "",
            HospitalApprovalCode: "",
            HospitalID: "",
            HospitalName: "",
            Address: "",
            MobileNo: "",
            HospitalDetail: "",
        }
    }

    $scope.ModelInitialize();

    $scope.FormLoad = function () {

        $http({
            method: 'POST',
            url: '/Admin/Hospital_Approval_Pending_Select',

        })
           .success(function (data) {
               if (data.Result == "Success") {
                   $scope.Record = JSON.parse(data.Data);
               }
               else
                   alert(data);
           });
    }

    $scope.FormLoad();

    $scope.HospitalDetailsLoad = function (HospitalCode) {

        $http({
            method: 'post',
            url: '/Admin/Hospital_Select',
            data: { HospitalCode: HospitalCode },

        })
        .success(function (data) {
            if (data.Result == "Success") {
                $scope.HospitalApproval = JSON.parse(data.Data)[0];
            }
            else
                toastr.error(data.Result);
        });
    }


    $scope.Save = function () {
        $http({
            method: 'POST',
            url: '/Admin/HospitalSave',
            data: {
                objHospital: $scope.Hospital
            }
        })
         .success(function (data) {
             if (data.Result == "Success") {
                 alert("The record is saved");
                 $scope.FormLoad();
                 $scope.ModelInitialize();
             }
             else
                 alert(data);
         });
    }

    $scope.Approval = function () {

        $http({
            method: 'POST',
            url: '/Admin/HospitalApprovalStatus',
            data: {
                HospitalCode: $scope.HospitalApproval.HospitalCode
            }
        })
         .success(function (data) {
             if (data.Result == "Success") {
                 alert("The record is Approved");
                 $scope.ModelInitialize();
                 $scope.FormLoad();
             }
             else
                 alert(data);
         });
    }

});

app.controller('HospitalLoginController', function ($scope, $http) {
    $scope.ModelInitialize = function () {
        $scope.Hospital = {
            HospitalID: "",
            Password: "",
        }
    }

    $scope.ModelInitialize();

    $scope.Login = function () {

        $http({
            method: 'POST',
            url: "/Admin/LoginPage",
            data: {
                HospitalID: $scope.Hospital.HospitalID,
                Password: $scope.Hospital.Password
            }
        })
         .success(function (data) {


             if (data.Data == "0")
                 alert("Please Check your username and password");
             else
                 window.location.href = "HospitalApproval";
         });
    }



});

app.controller('PatientDetailsController', function ($scope, $http) {
    $scope.ModelInitialize = function () {
        $scope.Patient = {
            PatientCode: "",
            HospitalID: "",
            HospitalName: "",
            PatientID: "",
            PatientName: "",
            Address: "",
            City: "",
            MobileNo: "",
            DiseasesDetail: ""
        }
    }

    $scope.ModelInitialize();

    $scope.FormLoad = function () {

        $http({
            method: 'POST',
            url: '/Admin/Patient_Select',

        })
           .success(function (data) {
               if (data.Result == "Success") {
                   $scope.Record = JSON.parse(data.Data);
               }
               else
                   alert(data);
           });
    }

    $scope.FormLoad();

    $scope.HospitalLoad = function () {
        $http({
            method: 'post',
            url: '/Admin/Hospital_Select',

        })
        .success(function (data) {
            if (data.Result == "Success") {
                $scope.Hospital = JSON.parse(data.Data);
            }
            else
                toastr.error(data.Result);
        });
    }

    $scope.HospitalLoad();


    $scope.Save = function () {
        //if ($scope.Degree.DegreeName == "") {
        //    alert("Please type  Degree Name ");
        //    $("#txtDegreeName").focus();
        //    return;
        //}
        $http({
            method: 'POST',
            url: '/Admin/PatientSave',
            data: {
                objPatient: $scope.Patient
            }
        })
         .success(function (data) {
             if (data.Result == "Success") {
                 alert("The record is saved");
                 $scope.FormLoad();
                 $scope.ModelInitialize();
             }
             else
                 alert(data);
         });
    }

});

app.controller('TreatmentDetailsController', function ($scope, $http) {
    $scope.ModelInitialize = function () {
        $scope.Treatment = {
            TreatmentCode: "",
            HospitalID: "",
            HospitalName: "",
            PatientID: "",
            PatientName: "",
            Address: "",
            DoctorName: "",
            Speciality: "",
            TreatmentID: "",
            TreatmentDate: "",
            Prescription: "",
        }
    }

    $scope.ModelInitialize();

    $scope.FormLoad = function () {

        $http({
            method: 'POST',
            url: '/Admin/Treatment_Select',

        })
           .success(function (data) {
               if (data.Result == "Success") {
                   $scope.Record = JSON.parse(data.Data);
               }
               else
                   alert(data);
           });
    }

    $scope.FormLoad();

    $scope.HospitalLoad = function () {
        $http({
            method: 'post',
            url: '/Admin/Hospital_Select',

        })
        .success(function (data) {
            if (data.Result == "Success") {
                $scope.Hospital = JSON.parse(data.Data);
            }
            else
                toastr.error(data.Result);
        });
    }

    $scope.HospitalLoad();


    $scope.Save = function () {
        //if ($scope.Degree.DegreeName == "") {
        //    alert("Please type  Degree Name ");
        //    $("#txtDegreeName").focus();
        //    return;
        //}
        $http({
            method: 'POST',
            url: '/Admin/TreatmentSave',
            data: {
                objTreatment: $scope.Treatment
            }
        })
         .success(function (data) {
             if (data.Result == "Success") {
                 alert("The record is saved");
                 $scope.FormLoad();
                 $scope.ModelInitialize();
             }
             else
                 alert(data);
         });
    }

});

app.controller('XRayDetailsController', function ($scope, $http) {
    $scope.ModelInitialize = function () {
        $scope.XRay = {
            XRayCode: "",
            PatientID: "",
            PatientName: "",
            BloodPressureAmount: "",
            CTAmount: "",
            XRayAmount: "",
            UrineTestAmount: "",
            DoctorFees: "",
            BedCharges: "",
            OtherCharges: "",
            TotalAmount: "",
            PaidAmount: "",
        }
    }

    $scope.ModelInitialize();

    $scope.FormLoad = function () {

        $http({
            method: 'POST',
            url: '/Admin/XRay_Select',

        })
           .success(function (data) {
               if (data.Result == "Success") {
                   $scope.Record = JSON.parse(data.Data);
               }
               else
                   alert(data);
           });
    }

    $scope.FormLoad();


    $scope.Save = function () {
        //if ($scope.Degree.DegreeName == "") {
        //    alert("Please type  Degree Name ");
        //    $("#txtDegreeName").focus();
        //    return;
        //}
        $http({
            method: 'POST',
            url: '/Admin/XRaySave',
            data: {
                objXRay: $scope.XRay
            }
        })
         .success(function (data) {
             if (data.Result == "Success") {
                 alert("The record is saved");
                 $scope.FormLoad();
                 $scope.ModelInitialize();
             }
             else
                 alert(data);
         });
    }

});

app.controller('BloodPressureController', function ($scope, $http) {
    $scope.ModelInitialize = function () {
        $scope.BloodPressure = {
            BloodPressureCode: "",
            BillDate: "",
            PatientID: "",
            PatientName: "",
            TreatmentID: "",
            TreatmentDate: "",
            DoctorName: "",
            Pressure: "",
            BPRate: "",
            Amount: "",
        }
    }

    $scope.ModelInitialize();

    $scope.FormLoad = function () {

        $http({
            method: 'POST',
            url: '/Admin/BloodPressure_Select',

        })
           .success(function (data) {
               if (data.Result == "Success") {
                   $scope.Record = JSON.parse(data.Data);
               }
               else
                   alert(data);
           });
    }

    $scope.FormLoad();

    $scope.Save = function () {
        //if ($scope.Degree.DegreeName == "") {
        //    alert("Please type  Degree Name ");
        //    $("#txtDegreeName").focus();
        //    return;
        //}
        $http({
            method: 'POST',
            url: '/Admin/BloodPressureSave',
            data: {
                objBloodPressure: $scope.BloodPressure
            }
        })
         .success(function (data) {
             if (data.Result == "Success") {
                 alert("The record is saved");
                 $scope.FormLoad();
                 $scope.ModelInitialize();
             }
             else
                 alert(data);
         });
    }

});

app.controller('CXRaysController', function ($scope, $http) {
    $scope.ModelInitialize = function () {
        $scope.XRays = {
            CXRaysCode: "",
            BillNo: "",
            BillDate: "",
            PatientID: "",
            PatientName: "",
            TreatmentID: "",
            TreatmentDate: "",
            DoctorName: "",
            XRayType: "",
            ResultDetails: "",
            Amount: "",
        }
    }

    $scope.ModelInitialize();

    $scope.FormLoad = function () {

        $http({
            method: 'POST',
            url: '/Admin/XRays_Select',

        })
           .success(function (data) {
               if (data.Result == "Success") {
                   $scope.Record = JSON.parse(data.Data);
               }
               else
                   alert(data);
           });
    }

    $scope.FormLoad();

    $scope.Save = function () {
        //if ($scope.Degree.DegreeName == "") {
        //    alert("Please type  Degree Name ");
        //    $("#txtDegreeName").focus();
        //    return;
        //}
        $http({
            method: 'POST',
            url: '/Admin/XRays_Save',
            data: {
                objXRays: $scope.XRays
            }
        })
         .success(function (data) {
             if (data.Result == "Success") {
                 alert("The record is saved");
                 $scope.FormLoad();
                 $scope.ModelInitialize();
             }
             else
                 alert(data);
         });
    }

});

app.controller('CTScanDetailsController', function ($scope, $http) {
    $scope.ModelInitialize = function () {
        $scope.CTScan = {
            CXRaysCode: "",
            BillNo: "",
            BillDate: "",
            PatientID: "",
            PatientName: "",
            TreatmentID: "",
            TreatmentDate: "",
            DoctorName: "",
            XRayType: "",
            ResultDetails: "",
            Amount: "",
        }
    }

    $scope.ModelInitialize();

    $scope.FormLoad = function () {

        $http({
            method: 'POST',
            url: '/Admin/CTScan_Select',

        })
           .success(function (data) {
               if (data.Result == "Success") {
                   $scope.Record = JSON.parse(data.Data);
               }
               else
                   alert(data);
           });
    }

    $scope.FormLoad();

    $scope.Save = function () {
        //if ($scope.Degree.DegreeName == "") {
        //    alert("Please type  Degree Name ");
        //    $("#txtDegreeName").focus();
        //    return;
        //}
        $http({
            method: 'POST',
            url: '/Admin/CTScanSave',
            data: {
                objXRays: $scope.CTScan
            }
        })
         .success(function (data) {
             if (data.Result == "Success") {
                 alert("The record is saved");
                 $scope.FormLoad();
                 $scope.ModelInitialize();
             }
             else
                 alert(data);
         });
    }

});


app.controller('PatientDetailsReport_Controller', function ($scope, $http) {
    $scope.ModelInitialize = function () {
        $scope.Patients = {
            PatientCode: "",
            PatientID: "",
            PatientName: "",
            Address: "",
            City: "",
            DiseasesDetail: "",
            

        }
    }

    $scope.ModelInitialize();

    $scope.Patient_Load = function () {
        $scope.PatientCode = $("#txt").val();

        $http({
            method: 'post',
            url: '/Admin/PatientDetails_Select',
            data: {
                PatientCode: $scope.PatientCode,
            },
        })
       .success(function (data) {
           if (data.Result == "Success") {
               $scope.Data = JSON.parse(data.Data)[0];

               $scope.Patients.PatientName = $scope.Data.PatientName;
               $scope.Patients.Address = $scope.Data.Address;
               $scope.Patients.City = $scope.Data.City;
               $scope.Patients.DiseasesDetail = $scope.Data.DiseasesDetail;
               $scope.Patients.PatientName = $scope.Data.PatientName;

           }
           else
               toastr.error(data.Result);
       });
    }

    $scope.PatientDetailsLoad = function () {
        $http({
            method: 'post',
            url: '/Admin/PatientDetails_Select',

        })
        .success(function (data) {
            if (data.Result == "Success") {
                $scope.Patient = JSON.parse(data.Data);
            }
            else
                toastr.error(data.Result);
        });
    }

    $scope.PatientDetailsLoad();









    $scope.BloodPressureDetailsLoad = function () {
        //$scope.PatientCode = $("#txt").val();

        $http({
            method: 'post',
            url: '/Admin/BloodPressureDetails_Select',
            data: {
                
                BloodPressureCode: $scope.BloodPressureCode,
            },
        })
       .success(function (data) {
           if (data.Result == "Success") {
               $scope.Data = JSON.parse(data.Data)[0];

               $scope.Patients.BillDate = $scope.Data.BillDate;
               $scope.Patients.TreatmentID = $scope.Data.TreatmentID;
               $scope.Patients.TreatmentDate = $scope.Data.TreatmentDate;
               $scope.Patients.DoctorName = $scope.Data.DoctorName;
               $scope.Patients.Pressure = $scope.Data.Pressure;
               $scope.Patients.BPRate = $scope.Data.BPRate;
               $scope.Patients.Amount = $scope.Data.Amount;
           }
           else
               toastr.error(data.Result);
       });
    }

    $scope.BloodPressureDetailsLoad = function () {
        $http({
            method: 'post',
            url: '/Admin/BloodPressureDetails_Select',

        })
        .success(function (data) {
            if (data.Result == "Success") {
                $scope.BloodPressure = JSON.parse(data.Data);

            }
            else
                toastr.error(data.Result);
        });
    }

    $scope.BloodPressureDetailsLoad();



   


});


app.controller('BloodPressureDetailsReport_Controller', function ($scope, $http) {
    $scope.ModelInitialize = function () {
        $scope.BloodPressure = {
            BloodPressureCode: "",
            BillDate: "",
            PatientID: "",
            PatientName: "",
            TreatmentID: "",
            TreatmentDate: "",
            DoctorName: "",
            Pressure: "",
            BPRate: "",
            Amount: "",
        }
    }

    $scope.ModelInitialize();

    $scope.FormLoad = function () {

        $http({
            method: 'POST',
            url: '/Admin/BloodPressureDetails_Select',

        })
           .success(function (data) {
               if (data.Result == "Success") {
                   $scope.Record = JSON.parse(data.Data);
               }
               else
                   alert(data);
           });
    }

    $scope.FormLoad();

    //$scope.BloodPressureDetailsLoad = function () {
    //    $http({
    //        method: 'post',
    //        url: '/Admin/BloodPressureDetails_Select',

    //    })
    //    .success(function (data) {
    //        if (data.Result == "Success") {
    //            $scope.BloodPressure = JSON.parse(data.Data);

    //        }
    //        else
    //            toastr.error(data.Result);
    //    });
    //}

    //$scope.BloodPressureDetailsLoad();






});

app.controller('XRayReport_Controller', function ($scope, $http) {
    $scope.ModelInitialize = function () {
        $scope.XRay = {
            XRayCode: "",
            PatientID: "",
            PatientName: "",
            BloodPressureAmount: "",
            CTAmount: "",
            XRayAmount: "",
            UrineTestAmount: "",
            DoctorFees: "",
            BedCharges: "",
            OtherCharges: "",
            TotalAmount: "",
            PaidAmount: "",
        }
    }

    $scope.ModelInitialize();

    $scope.FormLoad = function () {

        $http({
            method: 'POST',
            url: '/Admin/XRayDetails_Select',

        })
           .success(function (data) {
               if (data.Result == "Success") {
                   $scope.Record = JSON.parse(data.Data);
               }
               else
                   alert(data);
           });
    }

    $scope.FormLoad();

 });

