<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Students/StudentMasterPage.master" CodeFile="StudentRegisterCourse.aspx.vb" Inherits="Students_StudentRegisterCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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


    
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Manage Courses</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="Home.aspx">Dashboard</a>
                </li>

                <li class="active">
                    <strong>Manage Courses</strong>
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
                                        <h5>Manage Courses</h5>
                                        <br />
                                        <div class="ibox-tools">
                                            <a class="collapse-link">
                                                <i class="fa fa-chevron-up"></i>
                                            </a>
                                            
                                            <a class="close-link">
                                                <i class="fa fa-times"></i>
                                            </a>
                                        </div>
                                         <div class="form-group">
                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerLoad" >
                                                       <img src="img/loading.gif" />
                                                        Loading for Courses........
                                                      <img src="img/loader7.gif" />
                                                      
                                               </div>   
                                           </div>
                                    </div>


                                    <div class="ibox-content">
                                        <div id="Search">

                                            <div class="form-group">
                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinner" >
                                                       <img src="img/loading.gif" />
                                                        Searching for Courses........
                                                      <img src="img/loader7.gif" />
                                                      
                                               </div>   
                                           </div>

                                            <div class="form-group">
                                                <label class="col-lg-2 control-label">Session: </label>
                                                <div class="col-lg-10">
                                                    <asp:DropDownList AppendDataBoundItems="true" ID="ddlSession" runat="server" DataSourceID="odsSession" DataTextField="SessionName"
                                                            DataValueField="SessionID" CssClass="form-control">
                                                             <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:ObjectDataSource ID="odsSession" runat="server" SelectMethod="FindAllSessions"
                                                            TypeName="SessionLevelSemesterCourseDAL" CacheDuration="Infinite"></asp:ObjectDataSource>
                                                </div>
                                            </div>
                                       
                                            <div>&nbsp;</div>

                                           <div class="form-group">
                                                <label class="col-lg-2 control-label">Semester: </label>
                                                <div class="col-lg-10">
                                                   <asp:DropDownList AppendDataBoundItems="true" ID="ddlSemester" runat="server" DataSourceID="odsSemester" DataTextField="SemesterName"
                                                        DataValueField="SemesterID" CssClass="form-control">
                                                        <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="odsSemester" runat="server" SelectMethod="FindAllSemesters"
                                                        TypeName="SessionLevelSemesterCourseDAL" CacheDuration="Infinite"></asp:ObjectDataSource>
                                                </div>
                                            </div>

                                            <div>&nbsp;</div>

                                            <div class="modal-footer">
                                                <input type="button" id="btnSearch" value="Search" class="btn btn-primary" />
                                            </div>

                                          </div>

                                      <div id="Course" style="display:none;">
                                        <div class="alert alert-success" id="alreadyRegisterMsg" style="display:none;">
                                            You have already registered your courses for the selected session and semester. But you can add more course(s) and carry over course(s) or delete some course(s).
                                         </div>
                                        <div>
                                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal3" id="addCourses" style="display:none;">
                                                Add Course
                                            </button>
                                        </div>
                                        
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-hover dataTables-example" id="editable1">
                                                <thead>
                                                    <tr>
                                                        <th>Reg Number</th>
                                                        <th>Session Name</th>
                                                        <th>Semester Name</th>
                                                        <th>Course Code</th>
                                                        <th>Course Name</th>
                                                        <th>Credit Unit</th>
                                                        <th>Level Name</th>
                                                        <th>Lecture Name</th>
                                                         <th><asp:Label ID="lblEdit" runat="server" Text=""></asp:Label></th>
                                                    </tr>
                                                </thead>
                                               
                                                <tbody>
                                                    <tr class="gradeX">
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </tbody>

                                                <tfoot>
                                                    <tr>
                                                        <th>Reg Number</th>
                                                        <th>Session Name</th>
                                                        <th>Semester Name</th>
                                                        <th>Course Code</th>
                                                        <th>Course Name</th>
                                                        <th>Credit Unit</th>
                                                        <th>Level Name</th>
                                                        <th>Lecture Name</th>
                                                        <th><asp:Label ID="lblDelete" runat="server" Text=""></asp:Label></th>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                                      
                                        <div class="alert alert-success" id="successRegister" style="display:none;">
                                           <b>Congratulation, </b> you have successfully registered your courses for the selected session and semester. Scroll up to add more course(s) and carry over course(s).
                                         </div>

                                        <div class="alert alert-danger" id="dangerRegister" style="display:none;">
                                           <b>Sorry, </b>the course registration was NOT successful for the selected session and semester.
                                         </div>

                                       <div class="modal-footer" id="registerButton" style="display:none;">
                                             <input type="button" id="btnRegister" value="Register" class="btn btn-primary" />
                                       </div>
                                       
                                       <div class="form-group">
                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerRegister" >
                                                       <img src="img/loading.gif" />
                                                        Registering Courses........
                                                      <img src="img/loader7.gif" />
                                                      
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


    <div class="modal inmodal" id="myModal2" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content animated flipInY">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Delete Course</h4>

                </div>


                <div class="modal-body">
                    <b>Are you sure you want to delete this course?</b>
                    <br />
                     <div class="form-group">
                           <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerDelete" >
                                 <img src="img/loading.gif" />
                                      Deleting Course........
                                 <img src="img/loader7.gif" />                    
                          </div>   
                     </div>

                    <div class="alert alert-success" id="successDelete1" style="display:none;">
                           The course was successfully deleted. Course Registration will start afresh after 8 seconds.
                   </div>

                   <div class="alert alert-success" id="successDelete" style="display:none;">
                           The course was successfully deleted. Course Registration will start afresh after 8 seconds.
                   </div>

                   <div class="alert alert-danger" id="dangerDelete1" style="display:none;">
                          The course was NOT successfully deleted, chat with Admin. Course Registration will start afresh after 8 seconds.
                   </div>

                    <div class="alert alert-danger" id="dangerDelete" style="display:none;">
                          The course was NOT successfully deleted, chat with Admin. Course Registration will start afresh after 8 seconds.
                   </div>


                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                    <input type="button" id="btnDelete" value="Continue" class="btn btn-primary" />
                </div>


            </div>
        </div>
    </div>


    <div class="modal inmodal" id="myModal3" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content animated flipInY">
             <div class="ibox-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">ADD COURSE</h4>
                    
                     <div class="form-group">
                           <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerAddLoad" >
                                 <img src="img/loading.gif" />
                                      Loading Courses........
                                 <img src="img/loader7.gif" />
                                                      
                          </div> 
                   </div>

                    <div class="form-group">
                           <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerAdd" >
                                 <img src="img/loading.gif" />
                                      Adding New Course........
                                 <img src="img/loader7.gif" />
                                                      
                          </div> 
                   </div>
                </div>


                <div class="modal-body">
                  <div id="Search2">
                    <div class="form-group">
                         <label class="col-lg-2 control-label">Session: </label>
                         <div class="col-lg-10">
                             <asp:DropDownList AppendDataBoundItems="true" ID="ddlSession2" runat="server" DataSourceID="odsSession2" DataTextField="SessionName"
                                   DataValueField="SessionID" CssClass="form-control">
                                   <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                              </asp:DropDownList>
                             <asp:ObjectDataSource ID="odsSession2" runat="server" SelectMethod="FindAllSessions"
                                                            TypeName="SessionLevelSemesterCourseDAL" CacheDuration="Infinite"></asp:ObjectDataSource>
                         </div>
                   </div>
                                       
                   <div>&nbsp;</div>

                   <div class="form-group">
                        <label class="col-lg-2 control-label">Semester: </label>
                              <div class="col-lg-10">
                                  <asp:DropDownList AppendDataBoundItems="true" ID="ddlSemester2" runat="server" DataSourceID="odsSemester2" DataTextField="SemesterName"
                                       DataValueField="SemesterID" CssClass="form-control">
                                    <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                  </asp:DropDownList>
                                  <asp:ObjectDataSource ID="odsSemester2" runat="server" SelectMethod="FindAllSemesters"
                                                        TypeName="SessionLevelSemesterCourseDAL" CacheDuration="Infinite"></asp:ObjectDataSource>
                               </div>
                   </div>

                    <div>&nbsp;</div>

                  <div class="modal-footer">
                        <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                         <input type="button" id="btnSearch2" value="Search" class="btn btn-primary" />
                    </div>

                  </div>

                 <div id="Course2" style="display:none;">
                   
                    <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-hover dataTables-example" id="editable2">
                                                <thead>
                                                    <tr>
                                                        <th>Reg Number</th>
                                                        <th>Session Name</th>
                                                        <th>Semester Name</th>
                                                        <th>Course Code</th>
                                                        <th>Course Name</th>
                                                        <th>Credit Unit</th>
                                                        <th>Level Name</th>
                                                        <th>Lecture Name</th>
                                                        <th>Check to Add</th>
                                                    </tr>
                                                </thead>
                                               
                                                <tbody>
                                                    <tr class="gradeX">
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                </tbody>

                                                <tfoot>
                                                    <tr>
                                                        <th>Reg Number</th>
                                                        <th>Session Name</th>
                                                        <th>Semester Name</th>
                                                        <th>Course Code</th>
                                                        <th>Course Name</th>
                                                        <th>Credit Unit</th>
                                                        <th>Level Name</th>
                                                        <th>Lecture Name</th>
                                                        <th>Check to Add</th>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                    
                                    <div class="modal-footer">
                                         <div class="alert alert-success" id="successAdd" style="display:none;">
                                               The course(s) was successfully Added. Course Registration will start afresh after 8 seconds.
                                         </div>

                                          <div class="alert alert-danger" id="dangerAdd" style="display:none;">
                                                  The course(s) was NOT successfully Added, chat with Admin. Course Registration will start afresh after 8 seconds.
                                         </div>

                                        <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                                        <input type="button" id="btnAdd" value="ADD" class="btn btn-primary" />
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
            
            //Handling Delete Load
            var delconfirm = '';
            var delRegNumber = '';
            var delSession = '';
            var delSemester = ''

            delconfirm = localStorage.getItem("delconfirm");
            delRegNumber = localStorage.getItem("delRegNumber");
            delSession = localStorage.getItem("delSession");
            delSemester = localStorage.getItem("delSemester");

            if (delconfirm == 'YES') {

                $('#Course').show();
                $('#Search').hide();


                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "StudentRegisterCourse.aspx/GetAllCourses",
                    data: "{'regNumber':'" + delRegNumber + "','Session':'" + delSession + "','Semester':'" + delSemester + "'}",
                    dataType: "json",
                    success: function (data) {

                        $("[id*=lblEdit]").text("Delete")
                        $("[id*=lblDelete]").text("Delete")
                        $('#addCourses').show();

                        for (var i = 0; i < data.d.length; i++) {
                            $('#editable1').dataTable().fnAddData([data.d[i].RegNumber, data.d[i].SessionName, data.d[i].SemesterName, data.d[i].CourseCode, data.d[i].CourseName, data.d[i].CreditUnit, data.d[i].LevelName, data.d[i].LecName, "<a href='#myModal' id='" + data.d[i].ID + "' data-toggle='modal' data-target='#myModal2'><i class='fa fa-check text-navy'></i></a> "]);
                        }


                        var essay_id1;

                        //Getting the primary key for deleting and updating
                        $("a[data-toggle=modal]").click(function () {
                            essay_id1 = $(this).attr('id');
                        });


                        //Deleting Courses
                        $('#btnDelete').click(function () {
                            var CourseID1 = essay_id1;


                            $.ajax({
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                url: "StudentRegisterCourse.aspx/DeleteCourse",
                                data: "{'CourseID':'" + CourseID1 + "'}",
                                dataType: "json",
                                success: function (data) {
                                    var returnMsg = data.d

                                    if (returnMsg == 'success') {
                                        $('#successDelete1').show();

                                        ////For reloading table when the page is delete
                                        localStorage.setItem("delconfirm", "YES");
                                        localStorage.setItem("delRegNumber", delRegNumber);
                                        localStorage.setItem("delSession", delSession);
                                        localStorage.setItem("delSemester", delSemester);

                                        setTimeout(function () { location.reload(); }, 8000);
                                    } else {
                                        //$('#dangerDelete').show();

                                        ////For reloading table when the page is delete
                                        localStorage.setItem("delconfirm", "YES");
                                        localStorage.setItem("delRegNumber", delRegNumber);
                                        localStorage.setItem("delSession", delSession);
                                        localStorage.setItem("delSemester", delSemester);
                                        setTimeout(function () { location.reload(); }, 8000);
                                    }


                                },
                                beforeSend: function () {
                                    // Code to display spinner
                                    $('#spinnerDelete').show();
                                },
                                complete: function () {
                                    // Code to hide spinner.
                                    $('#spinnerDelete').hide();
                                },
                                error: function (result) {
                                    alert('Error Occurred, Please Chat with Admin..');
                                    GCM_Send();
                                }
                            });//End of ajax
                        });



                    },
                    beforeSend: function () {
                        // Code to display spinner
                        $('#spinnerLoad').show();
                    },
                    complete: function () {
                        // Code to hide spinner.
                        $('#spinnerLoad').hide();
                    },
                    error: function (result) {
                        alert('Error Occurred, Please Chat with Admin.');
                        GCM_Send();
                    }
                });//Ending Ajax
            }

            localStorage.setItem("delconfirm", "");
            localStorage.setItem("delRegNumber", "");
            localStorage.setItem("delSession", "");
            localStorage.setItem("delSemester", "");




            //Handling add Load
            var addconfirm = '';
            var addRegNumber = '';
            var addSession = '';
            var addSemester = ''

            addconfirm = localStorage.getItem("addconfirm");
            addRegNumber = localStorage.getItem("addRegNumber");
            addSession = localStorage.getItem("addSession");
            addSemester = localStorage.getItem("addSemester");

            if (addconfirm == 'YES') {

                $('#Course').show();
                $('#Search').hide();


                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "StudentRegisterCourse.aspx/GetAllCourses",
                    data: "{'regNumber':'" + addRegNumber + "','Session':'" + addSession + "','Semester':'" + addSemester + "'}",
                    dataType: "json",
                    success: function (data) {

                        $("[id*=lblEdit]").text("Delete")
                        $("[id*=lblDelete]").text("Delete")
                        $('#addCourses').show();

                        for (var i = 0; i < data.d.length; i++) {
                            $('#editable1').dataTable().fnAddData([data.d[i].RegNumber, data.d[i].SessionName, data.d[i].SemesterName, data.d[i].CourseCode, data.d[i].CourseName, data.d[i].CreditUnit, data.d[i].LevelName, data.d[i].LecName, "<a href='#myModal' id='" + data.d[i].ID + "' data-toggle='modal' data-target='#myModal2'><i class='fa fa-check text-navy'></i></a> "]);
                        }


                        var essay_id3;

                        //Getting the primary key for deleting and updating
                        $("a[data-toggle=modal]").click(function () {
                            essay_id3 = $(this).attr('id');
                        });


                        //Deleting Courses
                        $('#btnDelete').click(function () {
                            var CourseID3 = essay_id3;


                            $.ajax({
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                url: "StudentRegisterCourse.aspx/DeleteCourse",
                                data: "{'CourseID':'" + CourseID3 + "'}",
                                dataType: "json",
                                success: function (data) {
                                    var returnMsg = data.d

                                    if (returnMsg == 'success') {
                                        $('#successDelete1').show();

                                        ////For reloading table when the page is delete
                                        localStorage.setItem("addconfirm", "YES");
                                        localStorage.setItem("addRegNumber", addRegNumber);
                                        localStorage.setItem("addSession", addSession);
                                        localStorage.setItem("addSemester", addSemester);

                                        setTimeout(function () { location.reload(); }, 8000);
                                    } else {
                                        $('#dangerDelete1').show();

                                        ////For reloading table when the page is delete
                                        localStorage.setItem("addconfirm", "YES");
                                        localStorage.setItem("addRegNumber", addRegNumber);
                                        localStorage.setItem("addSession", addSession);
                                        localStorage.setItem("addSemester", addSemester);
                                        setTimeout(function () { location.reload(); }, 8000);
                                    }


                                },
                                beforeSend: function () {
                                    // Code to display spinner
                                    $('#spinnerDelete').show();
                                },
                                complete: function () {
                                    // Code to hide spinner.
                                    $('#spinnerDelete').hide();
                                },
                                error: function (result) {
                                    alert('Error Occurred, Please Chat with Admin..');
                                    GCM_Send();
                                }
                            });//End of ajax
                        });



                    },
                    beforeSend: function () {
                        // Code to display spinner
                        $('#spinnerLoad').show();
                    },
                    complete: function () {
                        // Code to hide spinner.
                        $('#spinnerLoad').hide();
                    },
                    error: function (result) {
                        alert('Error Occurred, Please Chat with Admin.');
                        GCM_Send();
                    }
                });//Ending Ajax
            }

            localStorage.setItem("addconfirm", "");
            localStorage.setItem("addRegNumber", "");
            localStorage.setItem("addSession", "");
            localStorage.setItem("addSemester", "");





            //Upload School Fees PIN to the database
            $('#btnSearch').click(function () {
                //Setting Registration number
                var regNumber = '<%= Request.QueryString("RegNumber").Trim%>';
                var SessionID = $("[id*=ddlSession]").find("option:selected").val()
                var SemesterID = $("[id*=ddlSemester]").find("option:selected").val()

                var Session = $("[id*=ddlSession]").find("option:selected").text()
                var Semester = $("[id*=ddlSemester]").find("option:selected").text()

                //Checking if excel file was selected for upload
                
                

                if (SessionID == 0) {
                    alert('Please Select the Session to continue');
                    return false;
                }

                if (SemesterID == 0) {
                    alert('Please Select the Semester to continue');
                    return false;
                }

                if (regNumber == '') {
                    alert('Please fill the Reg. Number to continue');
                    return false;
                }

                //Working on session
                var splitSession = Session.split("-");
                var newSession = splitSession[0]

                //Working on Semester
                var splitSemester = Semester.split("-");
                var newSemester = splitSemester[0]

                //Uploading School Fees Data
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "StudentRegisterCourse.aspx/GetCourse",
                    data: "{'regNumber':'" + regNumber + "','SemesterID':'" + SemesterID + "','Session':'" + newSession + "','Semester':'" + newSemester + "'}",
                    dataType: "json",
                    success: function (data) {
                        $('#Course').show();
                        $('#Search').hide();
                        
                        var checkIfCourseIsRegistered = data.d[0].SessionName;

                        if (checkIfCourseIsRegistered == "noSession") {
                            $("[id*=lblEdit]").text("Check to Add")
                            $("[id*=lblDelete]").text("Check to Add")
                            $('#registerButton').show();

                            for (var i = 0; i < data.d.length; i++) {
                                $('#editable1').dataTable().fnAddData([data.d[i].RegNumber, newSession, data.d[i].SemesterName, data.d[i].CourseCode, data.d[i].CourseName, data.d[i].CreditUnit, data.d[i].LevelName, data.d[i].LecName, "<input type='checkbox' id='" + data.d[i].ID + "'/> "]);
                            }

                          } else {
                            $("[id*=lblEdit]").text("Delete")
                            $("[id*=lblDelete]").text("Delete")
                            $('#alreadyRegisterMsg').show();
                            $('#addCourses').show();
                            

                            for (var i = 0; i < data.d.length; i++) {
                                $('#editable1').dataTable().fnAddData([data.d[i].RegNumber, data.d[i].SessionName, data.d[i].SemesterName, data.d[i].CourseCode, data.d[i].CourseName, data.d[i].CreditUnit, data.d[i].LevelName, data.d[i].LecName, "<a href='#myModal' id='" + data.d[i].ID + "' data-toggle='modal' data-target='#myModal2'><i class='fa fa-check text-navy'></i></a>"]);
                            }
                        }
                        

                        var essay_id;

                        //Getting the primary key for deleting and updating
                        $("a[data-toggle=modal]").click(function () {
                            essay_id = $(this).attr('id');
                        });


                        //Deleting Courses
                        $('#btnDelete').click(function () {
                            var CourseID = essay_id;

                            $.ajax({
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                url: "StudentRegisterCourse.aspx/DeleteCourse",
                                data: "{'CourseID':'" + CourseID + "'}",
                                dataType: "json",
                                success: function (data) {
                                    var returnMsg = data.d

                                    if (returnMsg == 'success') {
                                        $('#successDelete').show();

                                        //For reloading table when the page is delete
                                        localStorage.setItem("delconfirm", "YES");
                                        localStorage.setItem("delRegNumber", regNumber);
                                        localStorage.setItem("delSession", newSession);
                                        localStorage.setItem("delSemester", newSemester);

                                        localStorage.setItem("RegNumber", regNumber);

                                        setTimeout(function () {location.reload();}, 8000);
                                    } else {
                                        $('#dangerDelete').show();
                                        setTimeout(function () { location.reload(); }, 8000);
                                    }


                                },
                                beforeSend: function () {
                                    // Code to display spinner
                                    $('#spinnerDelete').show();
                                },
                                complete: function () {
                                    // Code to hide spinner.
                                    $('#spinnerDelete').hide();
                                },
                                error: function (result) {
                                    alert('Error Occurred, Please Chat with Admin..');
                                    GCM_Send();
                                }
                            });//End of ajax
                        });



                        //Registering Courses
                        $('#btnRegister').click(function () {
                            $("input:checked").each(function () {
                                var id = $(this).attr("id");
                                var CourseID = id;
                                
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "StudentRegisterCourse.aspx/RegisterCourses",
                                    data: "{'CourseID':'" + CourseID + "','regNumber':'" + regNumber + "','SemesterID':'" + SemesterID + "','Session':'" + newSession + "','Semester':'" + newSemester + "'}",
                                    dataType: "json",
                                    success: function (data) {
                                        var returnMsg = data.d

                                        if (returnMsg == 'success') {
                                            $('#successRegister').show();
                                            $('#addCourses').show();
                                        }else{
                                            $('#dangerRegister').show();
                                        }
                                        

                                    },
                                    beforeSend: function () {
                                        // Code to display spinner
                                        $('#spinnerRegister').show();
                                    },
                                    complete: function () {
                                        // Code to hide spinner.
                                        $('#spinnerRegister').hide();
                                    },
                                    error: function (result) {
                                        alert('Error Occurred, Please Chat with Admin..');
                                        GCM_Send();
                                    }
                                });

                            });
                        }); //Ending of course registration



                    },
                    beforeSend: function () {
                        // Code to display spinner
                        $('#spinner').show();
                    },
                    complete: function () {
                        // Code to hide spinner.
                        $('#spinner').hide();
                    },
                    error: function (result) {
                        alert('Error Occurred, Please Chat with Admin.');
                        GCM_Send();
                    }
                });
  

            }); 


            //handling adding course
            $('#btnSearch2').click(function () {
                //Setting Registration number
                var regNumber2 = '';
                var regNo = '<%= Request.QueryString("RegNumber").Trim%>';
                var SessionID2 = $("[id*=ddlSession2]").find("option:selected").val()
                var SemesterID2 = $("[id*=ddlSemester2]").find("option:selected").val()

                var Session2 = $("[id*=ddlSession2]").find("option:selected").text()
                var Semester2 = $("[id*=ddlSemester2]").find("option:selected").text()

                var newRegNumber = localStorage.getItem("RegNumber");

                //Checking if excel file was selected for upload



                if (SessionID2 == 0) {
                    alert('Please Select the Session to continue');
                    return false;
                }

                if (SemesterID2 == 0) {
                    alert('Please Select the Semester to continue');
                    return false;
                }

                if (regNo == '') {
                    if (newRegNumber == '') {
                        alert('Please fill the Reg. Number to continue');
                        return false;
                    } else {
                        regNumber2 = newRegNumber;
                    }
                } else {
                    regNumber2 = regNo;
                }

                //Working on session
                var splitSession2 = Session2.split("-");
                var newSession2 = splitSession2[0]

                //Working on Semester
                var splitSemester2 = Semester2.split("-");
                var newSemester2 = splitSemester2[0]

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "StudentRegisterCourse.aspx/GetAllAddCourses",
                    data: "{'regNumber':'" + regNumber2 + "','SemesterID':'" + SemesterID2 + "','Session':'" + newSession2 + "','Semester':'" + newSemester2 + "'}",
                    dataType: "json",
                    success: function (data) {

                        $('#Course2').show();
                        $('#Search2').hide();

                        for (var i = 0; i < data.d.length; i++) {
                            $('#editable2').dataTable().fnAddData([data.d[i].RegNumber, newSession2, data.d[i].SemesterName, data.d[i].CourseCode, data.d[i].CourseName, data.d[i].CreditUnit, data.d[i].LevelName, data.d[i].LecName, "<input type='checkbox' id='" + data.d[i].ID + "'/> "]);
                        }

                    },
                    beforeSend: function () {
                        // Code to display spinner
                        $('#spinnerAddLoad').show();
                    },
                    complete: function () {
                        // Code to hide spinner.
                        $('#spinnerAddLoad').hide();
                    },
                    error: function (result) {
                        alert('Error Occurred, Please Chat with Admin.');
                        GCM_Send();
                    }
                });//Ending Ajax

                //handling adding course
                $('#btnAdd').click(function () {
                    $("input:checked").each(function () {
                        var id2 = $(this).attr("id");
                        var CourseID2 = id2;


                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "StudentRegisterCourse.aspx/RegisterCourses",
                            data: "{'CourseID':'" + CourseID2 + "','regNumber':'" + regNumber2 + "','SemesterID':'" + SemesterID2 + "','Session':'" + newSession2 + "','Semester':'" + newSemester2 + "'}",
                            dataType: "json",
                            success: function (data) {
                                var returnMsg = data.d

                                if (returnMsg == 'success') {

                                    $('#successAdd').show();

                                    //For reloading table when the page is delete
                                    localStorage.setItem("addconfirm", "YES");
                                    localStorage.setItem("addRegNumber", regNumber2);
                                    localStorage.setItem("addSession", newSession2);
                                    localStorage.setItem("addSemester", newSemester2);

                                    localStorage.setItem("RegNumber", regNumber2);

                                    setTimeout(function () { location.reload(); }, 8000);

                                } else {
                                    $('#dangerRegister').show();

                                    //For reloading table when the page is delete
                                    localStorage.setItem("addconfirm", "YES");
                                    localStorage.setItem("addRegNumber", regNumber2);
                                    localStorage.setItem("addSession", newSession2);
                                    localStorage.setItem("addSemester", newSemester2);

                                    localStorage.setItem("RegNumber", regNumber2);
                                }


                            },
                            beforeSend: function () {
                                // Code to display spinner
                                $('#spinnerRegister').show();
                            },
                            complete: function () {
                                // Code to hide spinner.
                                $('#spinnerRegister').hide();
                            },
                            error: function (result) {
                                alert('Error Occurred, Please Chat with Admin..');
                                GCM_Send();
                            }
                        });



                    });//Ending input loop

                    

                });

            });


            

            //Refreashing the Fees Page
            $('#btnRefresh').click(function () {
                $('#table').hide();
                $('#search').show();
            });


        });


        //Sending GCM Function
        function GCM_Send() {

            var regNumber = '<%= Request.QueryString("RegNumber").Trim%>';

            //Fetching Carry Over Result
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "StudentResult.aspx/GCM_Send",
                data: "{'regNumber':'" + regNumber + "'}",
                dataType: "json",
                success: function (data) {

                },
                error: function (result) {
                    //alert('Error Occurred, Chat with Admin.');
                }

            });// End of Ajax
        }
    </script>


           <!-- Mainly scripts -->
        <script src="js/jquery-2.1.1.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>
        <script src="js/plugins/slimscroll/jquery.slimscroll.min.js"></script>
        <script src="js/plugins/jeditable/jquery.jeditable.js"></script>

        <script src="js/plugins/dataTables/datatables.min.js"></script>

        <!-- Custom and plugin javascript -->
        <script src="js/inspinia.js"></script>
        <script src="js/plugins/pace/pace.min.js"></script>

        <!-- Page-Level Scripts -->
        <script>
            $(document).ready(function () {
                $('.dataTables-example').DataTable({
                    dom: '<"html5buttons"B>lTfgitp',
                    buttons: [
                        { extend: 'copy' },
                        { extend: 'csv' },
                        { extend: 'excel', title: 'ExampleFile' },
                        { extend: 'pdf', title: 'ExampleFile' },

                        {
                            extend: 'print',
                            customize: function (win) {
                                $(win.document.body).addClass('white-bg');
                                $(win.document.body).css('font-size', '10px');

                                $(win.document.body).find('table')
                                        .addClass('compact')
                                        .css('font-size', 'inherit');
                            }
                        }
                    ]

                });

                /* Init DataTables */
                var oTable = $('#editable').DataTable();

                /* Apply the jEditable handlers to the table */
                oTable.$('td').editable('http://webapplayers.com/example_ajax.php', {
                    "callback": function (sValue, y) {
                        var aPos = oTable.fnGetPosition(this);
                        oTable.fnUpdate(sValue, aPos[0], aPos[1]);
                    },
                    "submitdata": function (value, settings) {
                        return {
                            "row_id": this.parentNode.getAttribute('id'),
                            "column": oTable.fnGetPosition(this)[2]
                        };
                    },

                    "width": "90%",
                    "height": "100%"
                });


            });


        </script>
</asp:Content>