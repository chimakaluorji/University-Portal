<%@ Page Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="UploadPIN.aspx.vb" Inherits="Admin_UploadPIN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <!-- Toastr style -->
    <link href="css/plugins/toastr/toastr.min.css" rel="stylesheet">

    <!-- Gritter -->
    <link href="js/plugins/gritter/jquery.gritter.css" rel="stylesheet">

    <link href="css/plugins/dataTables/datatables.min.css" rel="stylesheet">

 
    <link href="css/solidrock.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">

    <link href="css/plugins/iCheck/custom.css" rel="stylesheet">

    <link href="css/plugins/chosen/chosen.css" rel="stylesheet">

    <link href="css/plugins/colorpicker/bootstrap-colorpicker.min.css" rel="stylesheet">

    <link href="css/plugins/cropper/cropper.min.css" rel="stylesheet">

    <link href="css/plugins/switchery/switchery.css" rel="stylesheet">

    <link href="css/plugins/jasny/jasny-bootstrap.min.css" rel="stylesheet">

    <link href="css/plugins/nouslider/jquery.nouislider.css" rel="stylesheet">

    <link href="css/plugins/datapicker/datepicker3.css" rel="stylesheet">

    <link href="css/plugins/ionRangeSlider/ion.rangeSlider.css" rel="stylesheet">
    <link href="css/plugins/ionRangeSlider/ion.rangeSlider.skinFlat.css" rel="stylesheet">

    <link href="css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css" rel="stylesheet">

    <link href="css/plugins/clockpicker/clockpicker.css" rel="stylesheet">

    <link href="css/plugins/daterangepicker/daterangepicker-bs3.css" rel="stylesheet">

    <link href="css/plugins/select2/select2.min.css" rel="stylesheet">

    <link href="css/plugins/touchspin/jquery.bootstrap-touchspin.min.css" rel="stylesheet">


     <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">
    <link href="css/plugins/iCheck/custom.css" rel="stylesheet">
   <link href="css/plugins/steps/jquery.steps.css" rel="stylesheet">
    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">

    <link href="DropzoneJs_scripts/dropzone.css" rel="stylesheet" />

<div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h2>Upload PIN</h2>
                    <ol class="breadcrumb">
                        <li>
                            <a href="Default.aspx">Dashboard</a>
                        </li>
                        
                        <li class="active">
                            <strong>Manage PIN</strong>
                        </li>
                    </ol>
                </div>
                <div class="col-lg-2">

                </div>
            </div>

            <div class="wrapper wrapper-content animated fadeInRight">
            <div class="row">
                <div class="col-lg-6">
                                <div class="ibox float-e-margins">
                                    <div class="wrapper wrapper-content animated fadeInRight">
                                             
                                        <div class="row">
                                            <div class="col-lg-12">
                                            <div class="ibox float-e-margins">
                                                <div class="ibox-title">
                                                    <h5>Upload School Fees PIN</h5><br />
                                                    <asp:Label ID="lblError" runat="server" Text="" Font-Size="15px" Font-Bold="true"></asp:Label>
                                                    
                                                    <div class="ibox-tools">
                                                        <a class="collapse-link">
                                                            <i class="fa fa-chevron-up"></i>
                                                        </a>
                                                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                                            <i class="fa fa-wrench"></i>
                                                        </a>
                                                        <a class="close-link">
                                                            <i class="fa fa-times"></i>
                                                        </a>
                                                    </div>
                                                </div>
                                               <div class="ibox-content">
                                                        <div class="form-horizontal">
                                                            <div class="form-group">
                                                               <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerFees" >
                                                                           <img src="img/loading.gif" />
                                                                             Uploading School Fees PIN........
                                                                          <img src="img/loader7.gif" />
                                                      
                                                                   </div>  
                                                            </div>

                                                             <div class="form-group" id="successMsgFees" style="display:none;">
                                                                 <div class="col-lg-10">
                                                                    <div class="alert alert-success" >
                                                                       The School Fees PIN was successfully uploaded.
                                                                    </div>
                                                                  </div>
                                                             </div>

                                                            <div class="form-group">
                                                                <label class="col-lg-2 control-label">Excel: </label>
                                                                 <div class="col-lg-10">
                                                                        <div id="dZUpload" class="dropzone">
                                                                           <div class="dz-default dz-message">
                                                                                Browse or Drop an excel file here. 
                                                                          </div>
                                                                        </div>
                                                                </div>
                                                            </div>
                                        
                                                            <div class="form-group">
                                                                <div class="col-lg-offset-2 col-lg-10">
                                                                    <input type="button" value="Upload Fees PIN" id="btnUploadFess" class="btn btn-success-primary"/>
                                                                    <%--<asp:Button ID="Button1" runat="server" Text="Button" />
                                                                    <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                            </div>
                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-6">
                                <div class="ibox float-e-margins">
                                    <div class="wrapper wrapper-content animated fadeInRight">
                                             
                                        <div class="row">
                                            <div class="col-lg-12">
                                            <div class="ibox float-e-margins">
                                                <div class="ibox-title">
                                                     <h5>Upload Result PIN</h5><br />
                                                    <asp:Label ID="Label1" runat="server" Text="" Font-Size="15px" Font-Bold="true"></asp:Label>
                                                    <div class="ibox-tools">
                                                        <a class="collapse-link">
                                                            <i class="fa fa-chevron-up"></i>
                                                        </a>
                                                        <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                                            <i class="fa fa-wrench"></i>
                                                        </a>
                                                        <a class="close-link">
                                                            <i class="fa fa-times"></i>
                                                        </a>
                                                    </div>
                                                </div>
                                                <div class="ibox-content">
                                                        <div class="form-horizontal">
                                                            <div class="form-group">
                                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerResult" >
                                                                       <img src="img/loading.gif" />
                                                                         Uploading Result PIN........
                                                                      <img src="img/loader7.gif" />
                                                      
                                                               </div> 
                                                            </div>

                                                             <div class="form-group" id="successMsgResult" style="display:none;">
                                                                 <div class="col-lg-10">
                                                                    <div class="alert alert-success" >
                                                                       The Result PIN was successfully uploaded.
                                                                    </div>
                                                                  </div>
                                                             </div>
                                                            <div class="form-group">
                                                                <label class="col-lg-2 control-label">Excel: </label>
                                                                 <div class="col-lg-10">
                                                                    <div id="dZUploadResult" class="dropzone">
                                                                           <div class="dz-default dz-message">
                                                                                Browse or Drop an excel file here. 
                                                                          </div>
                                                                        </div>
                                                                </div>
                                                            </div>
                                        
                                                            <div class="form-group">
                                                                <div class="col-lg-offset-2 col-lg-10">
                                                                   <input type="button" value="Upload Result PIN" id="btnUploadResult" class="btn btn-success-primary"/>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                            </div>
                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                    </div>
                </div>


 <script src="latestJs_1.11/jquery.min.js"></script>
 <script src="DropzoneJs_scripts/dropzone.js"></script>
    
    <script type="text/javascript">

        $(document).ready(function () {
            console.log("Hello");
            Dropzone.autoDiscover = false;

            var imgNameFees = '';
            var imgNameResult = '';

            //Uploading School Fees PIN
            $("#dZUpload").dropzone({
                url: "excelPINUploader.ashx",
                maxFiles: 5,
                addRemoveLinks: true,
                success: function (file, response) {
                    imgNameFees = response;
                    file.previewElement.classList.add("dz-success");
                    console.log("Successfully uploaded :" + imgNameFees);
                },
                error: function (file, response) {
                    file.previewElement.classList.add("dz-error");
                }
            });


            //Upload Result PIN
            $("#dZUploadResult").dropzone({
                url: "excelPINUploader.ashx",
                maxFiles: 5,
                addRemoveLinks: true,
                success: function (file, response) {
                    imgNameResult = response;
                    file.previewElement.classList.add("dz-success");
                    console.log("Successfully uploaded :" + imgNameResult);
                },
                error: function (file, response) {
                    file.previewElement.classList.add("dz-error");
                }
            });

            
            //Upload School Fees PIN to the database
            $('#btnUploadFess').click(function () {
                //Checking if excel file was selected for upload
                if (imgNameFees == '') {
                    alert('Please select an excel file to continue');
                   return false;
                }


                //Uploading School Fees Data
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "UploadPIN.aspx/InsertSchoolFeesData",
                    data: "{'EimgNameFees':'" + imgNameFees + "'}",
                    dataType: "json",
                    success: function (data) {
                        var obj = data.d;
                        if (obj != '') {
                            $('#successMsgFees').show();
                        }

                    },
                    beforeSend: function () {
                        // Code to display spinner
                        $('#spinnerFees').show();
                    },
                    complete: function () {
                        // Code to hide spinner.
                        $('#spinnerFees').hide();
                    },
                    error: function (result) {
                        alert('Error Occurred, Please Contact Admin.');
                    }
                });


            });


            //Upload Result PIN to the database
            $('#btnUploadResult').click(function () {
                //Checking if excel file was selected for upload
                if (imgNameResult == '') {
                    alert('Please select an excel file to continue');
                    return false;
                }


                //Uploading School Fees Data
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "UploadPIN.aspx/InsertResultData",
                    data: "{'EimgNameResult':'" + imgNameResult + "'}",
                    dataType: "json",
                    success: function (data) {
                        var obj = data.d;
                        if (obj != '') {
                            $('#successMsgResult').show();
                        }

                    },
                    beforeSend: function () {
                        // Code to display spinner
                        $('#spinnerResult').show();
                    },
                    complete: function () {
                        // Code to hide spinner.
                        $('#spinnerResult').hide();
                    },
                    error: function (result) {
                        alert('Error Occurred, Please Contact Admin.');
                    }
                });


            });

        });

    </script>
    <!-- Mainly scripts -->
    <script src="js/bootstrap.min.js"></script>
    <script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="js/plugins/slimscroll/jquery.slimscroll.min.js"></script>

    <!-- Custom and plugin javascript -->
    <script src="js/inspinia.js"></script>
    <script src="js/plugins/pace/pace.min.js"></script>

</asp:Content>