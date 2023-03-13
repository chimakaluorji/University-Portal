<%@ Page Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="AdminUploadStudentProfile.aspx.vb" Inherits="Admin_AdminUploadStudentProfile" %>

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
            <h2>Upload Student Profile</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Dashboard</a>
                </li>

                <li class="active">
                    <strong>Upload Student Profile</strong>
                </li>
            </ol>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="wrapper wrapper-content animated fadeInRight">

                        <div class="row">
                            <div class="col-lg-12">
                                <div class="ibox float-e-margins">
                                    <div class="ibox-title">
                                        <h5>Upload Student Profile</h5>
                                        <br />
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
                                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinner1" >
                                                                       <img src="img/loading.gif" />
                                                                        Loading Programme ........
                                                                      <img src="img/loader7.gif" />
                                                      
                                                               </div>   
                                                     </div>

                                                    <div>&nbsp;</div>
                                                                <div class="form-group">
                                                                    <label class="col-lg-2 control-label">Session:</label>
                                                                    <div class="col-lg-10">
                                                                          <asp:DropDownList ID="ddlSession" runat="server" AppendDataBoundItems="True" DataSourceID="odsSession"
                                                                                        DataTextField="SessionName" DataValueField="SessionID" CssClass="form-control">
                                                                                      <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                                                  </asp:DropDownList>
                                                                                  <asp:ObjectDataSource ID="odsSession" runat="server" EnableCaching="True"
                                                                                       SelectMethod="FindAllSessions" TypeName="SessionSemesterDepartmentDAL">
                                                                                  </asp:ObjectDataSource>
                                                                    </div>
                                                                </div>
                                                                <div>&nbsp;</div>
                                                                <div class="form-group">
                                                                    <label class="col-lg-2 control-label">Semester:</label>
                                                                    <div class="col-lg-10">
                                                                         <asp:DropDownList ID="ddlSemester" AppendDataBoundItems="true" runat="server" DataSourceID="odsSemester"
                                                                                     DataTextField="SemesterName" DataValueField="SemesterID" CssClass="form-control">
                                                                                    <asp:ListItem>--Please Select--</asp:ListItem>
                                                                                 </asp:DropDownList>
                                                                                 <asp:ObjectDataSource ID="odsSemester" runat="server" SelectMethod="FindAllSemesters"
                                                                                      TypeName="SessionSemesterDepartmentDAL" CacheDuration="Infinite">
                                                                                 </asp:ObjectDataSource>
                                                                    </div>
                                                                </div>
                                                               <%-- <div>&nbsp;</div>
                                                                <div class="form-group">
                                                                    <label class="col-lg-2 control-label">Department:</label>
                                                                    <div class="col-lg-10">
                                                                         <asp:DropDownList ID="ddlDepartment" runat="server" AppendDataBoundItems="True" DataSourceID="odsDepartment"
                                                                                        DataTextField="DeptName" DataValueField="DeptID" CssClass="form-control">
                                                                                      <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                                                  </asp:DropDownList>
                                                                                  <asp:ObjectDataSource ID="odsDepartment" runat="server" EnableCaching="True"
                                                                                       SelectMethod="FindAllDepartment" TypeName="SessionSemesterDepartmentDAL">
                                                                                  </asp:ObjectDataSource>
                                                                    </div>
                                                                </div>

                                                                <div>&nbsp;</div>
                                                                <div class="form-group">
                                                                    <label class="col-lg-2 control-label">Programme: </label>
                                                                    <div class="col-lg-10">
                                                                         <asp:DropDownList ID="ddlProgramme" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                                                                      <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                                                  </asp:DropDownList>
                                                                    </div>
                                                                </div>--%>
                                                                <div>&nbsp;</div>
                                                                <div class="form-group">
                                                                    <label class="col-lg-2 control-label">Programme:</label>
                                                                    <div class="col-lg-10">
                                                                         <asp:DropDownList ID="ddlLevel" runat="server" AppendDataBoundItems="True" DataSourceID="odsLevel"
                                                                                        DataTextField="LevelName" DataValueField="LevelID" CssClass="form-control">
                                                                                      <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                                                  </asp:DropDownList>
                                                                                  <asp:ObjectDataSource ID="odsLevel" runat="server" EnableCaching="True"
                                                                                       SelectMethod="FindAllLevel" TypeName="SessionSemesterDepartmentDAL">
                                                                                  </asp:ObjectDataSource>
                                                                    </div>
                                                                </div>
                                                            <div>&nbsp;</div>
                                                            
                                                            <div class="form-group">
                                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerFees" >
                                                                       <img src="img/loading.gif" />
                                                                         Uploading Student Profile........
                                                                      <img src="img/loader7.gif" />
                                                      
                                                               </div>   
                                                            </div>

                                                             <div class="form-group" id="successMsgFees" style="display:none;">
                                                                 <div class="col-lg-10">
                                                                    <div class="alert alert-success" >
                                                                       The Student Profile was successfully uploaded.
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
                                                            <div>&nbsp;</div>

                                                            <div class="form-group">
                                                                <div class="col-lg-offset-2 col-lg-10">
                                                                    <input type="button" value="Upload Student Profile" id="btnStudentProfile" class="btn btn-success-primary"/>
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

            var ExcelUrl = '';

            //Uploading School Fees PIN
            $("#dZUpload").dropzone({
                url: "excelStudentProfileUploader.ashx",
                maxFiles: 5,
                addRemoveLinks: true,
                success: function (file, response) {
                    ExcelUrl = response;
                    file.previewElement.classList.add("dz-success");
                    console.log("Successfully uploaded :" + ExcelUrl);
                },
                error: function (file, response) {
                    file.previewElement.classList.add("dz-error");
                }
            });

            
            //Upload School Fees PIN to the database
            $('#btnStudentProfile').click(function () {
                
                var SessionID = $("[id*=ddlSession] option:selected").val();
                var SemesterID = $("[id*=ddlSemester] option:selected").val();
                //var DepartmentID = $("[id*=ddlDepartment] option:selected").val();
                //var ProgrammeID = $("[id*=ddlProgramme] option:selected").val();
                var LevelID = $("[id*=ddlLevel] option:selected").val();


                //Checking if excel file was selected for upload
                if (ExcelUrl == '') {
                    alert('Please select an excel file to continue');
                   return false;
                }


                //Uploading School Fees Data
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "AdminUploadStudentProfile.aspx/InsertStudentProfileData",
                    data: "{'EExcelUrl':'" + ExcelUrl + "','ESessionID':'" + SessionID + "','ESemesterID':'" + SemesterID + "','ELevelID':'" + LevelID + "'}",
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
            //End of Upload button


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