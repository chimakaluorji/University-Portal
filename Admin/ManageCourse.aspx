<%@ Page Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="ManageCourse.aspx.vb" Inherits="Admin_ManageCourse" %>

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
            <h2>Manage Course</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Dashboard</a>
                </li>

                <li class="active">
                    <strong>Manage Course</strong>
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
                                        <h5>Manage Course</h5>
                                        <br />
                                        <asp:Label ID="lblError" runat="server" Text="" Font-Size="13px" Font-Bold="true"></asp:Label>
                                        <div class="ibox-tools">
                                            <a class="collapse-link">
                                                <i class="fa fa-chevron-up"></i>
                                            </a>
                                            
                                            <a class="close-link">
                                                <i class="fa fa-times"></i>
                                            </a>
                                        </div>
                                    </div>
                                    <div class="ibox-content">
                                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal2">
                                            Add Course
                                        </button>
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-hover dataTables-example" id="editable1">
                                                <thead>
                                                    <tr>
                                                        <th>Course Code</th>
                                                        <th>Course Name</th>
                                                        <th>Credit Unit</th>
                                                        <th>Semester</th>
                                                        <th>Lecturer</th>
                                                        <th>Level</th>
                                                        <th>Edit or Delete</th>
                                                    </tr>
                                                </thead>
                                                <%
                                                    'Intantiate objects for accessing User Data and Business Layers
                                                    Dim CourseDAL As CourseDAL = New CourseDAL
                                                    Dim CourseData As System.Data.DataSet = New System.Data.DataSet
                        
                                                    CourseData = CourseDAL.FindAllCourse()
                                                %>
                                                <% For i = 0 To CourseData.Tables(0).Rows.Count - 1%>
                                                <tbody>
                                                    <tr class="gradeX">
                                                        <td><%= CourseData.Tables(0).Rows(i).Item("CourseCode")%></td>
                                                        <td><%= CourseData.Tables(0).Rows(i).Item("CourseName")%></td>
                                                        <td><%= CourseData.Tables(0).Rows(i).Item("CreditUnit")%></td>
                                                        <td><%= CourseData.Tables(0).Rows(i).Item("SemesterName")%></td>
                                                        <td><%= CourseData.Tables(0).Rows(i).Item("LecName")%></td>
                                                        <td><%= CourseData.Tables(0).Rows(i).Item("LevelName")%></td>
                                                        <td><a href='#myModal' data-toggle="modal" data-target="#myModal3" id='<%= CourseData.Tables(0).Rows(i).Item("courseID")%>'><i class="fa fa-check text-navy"></i></a></td>

                                                    </tr>
                                                </tbody>
                                                <% Next%>

                                                <tfoot>
                                                    <tr>
                                                        <th>Course Code</th>
                                                        <th>Course Name</th>
                                                        <th>Credit Unit</th>
                                                        <th>Semester</th>
                                                        <th>Lecturer</th>
                                                        <th>Level</th>
                                                        <th>Edit or Delete</th>
                                                    </tr>
                                                </tfoot>
                                            </table>
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
                    <h4 class="modal-title">Add New Course</h4>
                     <div class="form-group">
                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinner" >
                                                       <img src="img/loading.gif" />
                                                        Loading Courses, Please wait........
                                                      <img src="img/loader7.gif" />
                                                      
                                               </div>   
                                           </div>

                    <div class="form-group" id="success" style="display:none;">
                        <div class="col-lg-10">
                             <div class="alert alert-success" >
                                  Course was successfully added.
                             </div>
                        </div>
                    </div>

                    <div class="form-group" id="failed" style="display:none;">
                        <div class="col-lg-10">
                             <div class="alert alert-danger" >
                                  Course was NOT successfully added.
                             </div>
                        </div>
                    </div>
                </div>

                
                
                <div class="modal-body">
                    <div class="ibox-content">
                        <div class="form-horizontal">

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Course Code: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtCourseCode" runat="server" CssClass="form-control" placeholder="Course Code"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Course Name: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtCourseName" runat="server" CssClass="form-control" placeholder="Course Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Credit Unit: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtCreditUnit" runat="server" CssClass="form-control" placeholder="Credit Unit"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                 <label class="col-lg-3 control-label">Semester:</label>
                                     <div class="col-lg-9">
                                         <asp:DropDownList ID="ddlSemester" AppendDataBoundItems="true" runat="server" DataSourceID="odsSemester"
                                              DataTextField="SemesterName" DataValueField="SemesterID" CssClass="form-control">
                                                <asp:ListItem  Value="0">--Please Select--</asp:ListItem>
                                         </asp:DropDownList>
                                           <asp:ObjectDataSource ID="odsSemester" runat="server" SelectMethod="FindAllSemesters" TypeName="SessionSemesterDepartmentDAL" CacheDuration="Infinite">
                                            </asp:ObjectDataSource>
                                     </div>
                            </div>

                            <%--<div class="form-group">
                                <label class="col-lg-3 control-label">Department: </label>
                                <div class="col-lg-9">
                                    <asp:DropDownList ID="ddlDept" runat="server" CssClass="form-control" DataSourceID="ObjS" DataTextField="DeptName"
                                        DataValueField="DeptID" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">---Please Select---</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ObjectDataSource ID="ObjS" runat="server" SelectMethod="FindAllDepartment" TypeName="SessionSemesterDepartmentDAL"
                                        EnableCaching="true"></asp:ObjectDataSource>

                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Programme: </label>
                                <div class="col-lg-9">
                                    <asp:DropDownList ID="ddlProgramme" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                          <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                   </asp:DropDownList>
                                </div>
                            </div>--%>

                            <div class="form-group">
                               <label class="col-lg-3 control-label">Programme:</label>
                                 <div class="col-lg-9">
                                      <asp:DropDownList ID="ddlLevel" runat="server" AppendDataBoundItems="True" DataSourceID="odsLevel"
                                             DataTextField="LevelName" DataValueField="LevelID" CssClass="form-control">
                                            <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                       </asp:DropDownList>
                                      <asp:ObjectDataSource ID="odsLevel" runat="server" EnableCaching="True"
                                          SelectMethod="FindAllLevel" TypeName="SessionSemesterDepartmentDAL">
                                      </asp:ObjectDataSource>
                                 </div>
                           </div>

                            <div class="form-group">
                               <label class="col-lg-3 control-label">Lecturer:</label>
                                 <div class="col-lg-9">
                                        <asp:DropDownList AppendDataBoundItems="true" ID="ddlLecturer" runat="server" DataSourceID="obsLecturer"
                                                DataTextField="LecName" DataValueField="LecturerID" data-rel="chosen">
                                                <asp:ListItem>--Please Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="FindAllLecturers"
                                                TypeName="LecturerDAL" CacheDuration="Infinite"></asp:ObjectDataSource>
                                 </div>
                           </div>

                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                    <input type="button" id="btnSave" value="Save" class="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal inmodal" id="myModal3" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content animated flipInY">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Edit Course</h4>

                     <div class="form-group">
                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinner1" >
                                                       <img src="img/loading.gif" />
                                                        Editing Courses, Please wait........
                                                      <img src="img/loader7.gif" />
                                                      
                                               </div>   
                                           </div>
                     <div class="form-group">
                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinner2" >
                                                       <img src="img/loading.gif" />
                                                        Deleting Courses, Please wait........
                                                      <img src="img/loader7.gif" />
                                                      
                                               </div>   
                                           </div>

                    <div>
                        <asp:Label ID="lblPrimaryKey" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblError2" runat="server" Text="" ForeColor="Green" Font-Size="13px" Font-Bold="true"></asp:Label>
                    </div>

                    <div class="form-group" id="successEdit" style="display:none;">
                        <div class="col-lg-10">
                             <div class="alert alert-success" >
                                  Course was successfully Edit.
                             </div>
                        </div>
                    </div>

                    <div class="form-group" id="failedEdit" style="display:none;">
                        <div class="col-lg-10">
                             <div class="alert alert-danger" >
                                  Course was NOT successfully Edit.
                             </div>
                        </div>
                    </div>

                </div>


                <div class="modal-body">
                    <div class="ibox-content">
                        <div class="form-horizontal">

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Course Code: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtCourseCode2" runat="server" CssClass="form-control" placeholder="Course Code"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Course Name: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtCourseName2" runat="server" CssClass="form-control" placeholder="Course Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Credit Unit: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtCreditUnit2" runat="server" CssClass="form-control" placeholder="Credit Unit"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                 <label class="col-lg-3 control-label">Semester:</label>
                                    <div class="col-lg-9">
                                        <asp:Label ID="lblSemester" runat="server" Text=""></asp:Label>
                                    </div>
                                     <div class="col-lg-9">
                                         <asp:DropDownList ID="ddlSemester2" AppendDataBoundItems="true" runat="server" DataSourceID="odsSemester1"
                                              DataTextField="SemesterName" DataValueField="SemesterID" CssClass="form-control">
                                                <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                         </asp:DropDownList>
                                           <asp:ObjectDataSource ID="odsSemester1" runat="server" SelectMethod="FindAllSemesters" TypeName="SessionSemesterDepartmentDAL" CacheDuration="Infinite">
                                            </asp:ObjectDataSource>
                                     </div>
                            </div>

                        <%--    <div class="form-group">
                                <label class="col-lg-3 control-label">Lecturer: </label>
                                <div class="col-lg-9">
                                        <asp:Label ID="lblDepartment" runat="server" Text=""></asp:Label>
                                    </div>
                                <div class="col-lg-9">
                                   <asp:DropDownList AppendDataBoundItems="true" ID="DropDownList1" runat="server" DataSourceID="obsLecturer"
                                                DataTextField="LecName" DataValueField="LecturerID" data-rel="chosen">
                                                <asp:ListItem>--Please Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="FindAllLecturers"
                                                TypeName="LecturerDAL" CacheDuration="Infinite"></asp:ObjectDataSource>

                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Programme: </label>
                                <div class="col-lg-9">
                                        <asp:Label ID="lblProgramme" runat="server" Text=""></asp:Label>
                                    </div>
                                <div class="col-lg-9">
                                    <asp:DropDownList ID="ddlProgramme2" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                          <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                   </asp:DropDownList>
                                </div>
                            </div>--%>

                            <div class="form-group">
                               <label class="col-lg-3 control-label">Programme:</label>
                                <div class="col-lg-9">
                                        <asp:Label ID="lblLevel" runat="server" Text=""></asp:Label>
                                    </div>
                                 <div class="col-lg-9">
                                      <asp:DropDownList ID="ddlLevel2" runat="server" AppendDataBoundItems="True" DataSourceID="odsLeve11"
                                             DataTextField="LevelName" DataValueField="LevelID" CssClass="form-control">
                                            <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                       </asp:DropDownList>
                                      <asp:ObjectDataSource ID="odsLeve11" runat="server" EnableCaching="True"
                                          SelectMethod="FindAllLevel" TypeName="SessionSemesterDepartmentDAL">
                                      </asp:ObjectDataSource>
                                 </div>
                           </div>

                            <div class="form-group">
                               <label class="col-lg-3 control-label">Lecturer:</label>
                                <div class="col-lg-9">
                                        <asp:Label ID="lblLecturer2" runat="server" Text=""></asp:Label>
                                    </div>
                                 <div class="col-lg-9">
                                      <asp:DropDownList AppendDataBoundItems="true" ID="ddlLecturer2" runat="server" DataSourceID="obsLecturer"
                                                DataTextField="LecName" DataValueField="LecturerID" data-rel="chosen">
                                                <asp:ListItem>--Please Select--</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:ObjectDataSource ID="obsLecturer" runat="server" SelectMethod="FindAllLecturers"
                                                TypeName="LecturerDAL" CacheDuration="Infinite"></asp:ObjectDataSource>
                                 </div>
                           </div>

                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                    <input type="button" id="btnEdit" value="Edit" class="btn btn-primary" />
                    <input type="button" id="btnDelete" value="Delete" class="btn btn-primary" />
                </div>


            </div>
        </div>
    </div>



    <%--New Implementation of jquery button submit--%>
    <script type="text/javascript" src="js/jquery-1.8.2.js"></script>
    <script type="text/javascript">

        //creating Programme
        $(function () {
            $('#btnSave').click(function () {
                var CourseCode = $("[id*=txtCourseCode]").val();
                var CourseName = $("[id*=txtCourseName]").val();
                var CreditUnit = $("[id*=txtCreditUnit]").val();

                var DeptID = '1'//$("[id*=ddlDept] option:selected").val();
                var SemesterID = $("[id*=ddlSemester] option:selected").val();
                var ProgrammeID = '1'//$("[id*=ddlProgramme] option:selected").val();
                var LevelID = $("[id*=ddlLevel] option:selected").val();
                var LecturerID = $("[id*=ddlLecturer] option:selected").val();
                
               
                //Ensure something is been select
                if (CourseCode == '') {
                    alert('Please fill the Course Code to Continue')
                    return false;
                }

                if (CourseName == '') {
                    alert('Please fill the Course Name to Continue')
                    return false;
                }

                if (CreditUnit == '') {
                    alert('Please fill the Credit Unit to Continue')
                    return false;
                }


                if (SemesterID == 0) {
                    alert('Please Select the Semester to Continue')
                    return false;
                }

                if (DeptID == 0) {
                    alert('Please Select the Department to Continue')
                    return false;
                }

                if (ProgrammeID == 0) {
                    alert('Please Select the Programme to Continue')
                    return false;
                }

                if (LevelID == 0) {
                    alert('Please Select the Level to Continue')
                    return false;
                }

                if (LecturerID == 0) {
                    alert('Please Select the Lecturer to Continue')
                    return false;
                }

                $.ajax({
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                url: "ManageCourse.aspx/InsertData",
                                data: "{'ECourseCode':'" + CourseCode + "','ECourseName':'" + CourseName + "','ECourseName':'" + CourseName + "','ECreditUnit':'" + CreditUnit + "','ESemesterID':'" + SemesterID + "','EDeptID':'" + DeptID + "','EProgrammeID':'" + ProgrammeID + "','ELevelID':'" + LevelID + "','ELecturerID':'" + LecturerID + "'}",
                                dataType: "json",
                                success: function (data) {
                                    var obj = data.d;

                                    if (obj != '') {
                                        $("[id$='lblError']").html(data.d);
                                        
                                        var success = data.d;

                                        if (success == 'success') {
                                            $('#success').show();
                                        }

                                        if (success == 'failed') {
                                            $('#failed').show();
                                        }

                                        var markGood = "<i class='fa fa-check text-navy'></i>";

                                        var SemesterNameSplit = $("[id*=ddlSemester] option:selected").text();
                                        var SemesterName = SemesterNameSplit.split('--');

                                        var DeptSplit = $("[id*=ddlLecturer] option:selected").text();
                                        var Dept = DeptSplit.split('--');

                                        //var ProgrammeSplit = $("[id*=ddlProgramme] option:selected").text();
                                        //var ProgrammeName = ProgrammeSplit.split('--');

                                        var LevelSplit = $("[id*=ddlLevel] option:selected").text();
                                        var Level = LevelSplit.split('--');

                                        $('#editable1').dataTable().fnAddData([$("[id*=txtCourseCode]").val(), $("[id*=txtCourseName]").val(), $("[id*=txtCreditUnit]").val(), SemesterName[0], DeptSplit[0], Level[0], markGood]);
                                    }

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
                                    alert('The Programme was NOT created successfully.');
                                }
                            });
                })
        });

        var essay_id;
        var exSemesterID;
        var exLevelID;
        var exLecturerID;

        //Getting the primary key for deleting and updating
        $("a[data-toggle=modal]").click(function () {
            essay_id = $(this).attr('id');

            //Putting the primary in lblPrimaryKey label;
            $("[id$='lblPrimaryKey']").html(essay_id);
            
            //Getting session that need to be updated
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "ManageCourse.aspx/GetCourse",
                data: "{'PID':'" + essay_id + "'}",
                dataType: "json",
                success: function (data) {
                    var obj = data.d;

                    if (obj != '') {
                        $("[id*=txtCourseCode2]").val(data.d[0]);
                        $("[id*=txtCourseName2]").val(data.d[1]);
                        $("[id*=txtCreditUnit2]").val(data.d[2]);

                        $("[id$='lblSemester']").html(data.d[3]);
                        $("[id$='lblLecturer2']").html(data.d[4]);
                        $("[id$='lblLevel']").html(data.d[5]);

                        exSemesterID = data.d[6];
                        exLevelID = data.d[8];
                        exLecturerID = data.d[7];
                    }

                },
                error: function (result) {
                    alert('Error.');
                }
            });

        });


        //Updating Semester
        $(function () {
            $('#btnEdit').click(function () {
                var CourseCode = $("[id*=txtCourseCode2]").val();
                var CourseName = $("[id*=txtCourseName2]").val();
                var CreditUnit = $("[id*=txtCreditUnit2]").val();

                var DeptID = '1'//$("[id*=ddlDept2] option:selected").val();
                var SemesterID = $("[id*=ddlSemester2] option:selected").val();
                var ProgrammeID = '1'//$("[id*=ddlProgramme2] option:selected").val();
                var LevelID = $("[id*=ddlLevel2] option:selected").val();

                var LecturerID = $("[id*=ddlLecturer2] option:selected").val();

                if (SemesterID == 0) {
                    SemesterID = exSemesterID;
                }

                if (DeptID == 0) {
                    DeptID = exDepartmentID;
                }

                if (ProgrammeID == 0) {
                    ProgrammeID = exProgrammeID;
                }

                if (LevelID == 0) {
                    LevelID = exLevelID;
                }

                if (LecturerID == 0) {
                    LecturerID = exLecturerID;
                }

                

                var EditPID = essay_id;

                $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "ManageCourse.aspx/UpdateData",
                        data: "{'EEditPID':'" + EditPID + "','ECourseCode':'" + CourseCode + "','ECourseName':'" + CourseName + "','ECreditUnit':'" + CreditUnit + "','ESemesterID':'" + SemesterID + "','EDeptID':'" + DeptID + "','EProgrammeID':'" + ProgrammeID + "','ELevelID':'" + LevelID + "','ELecturerID':'" + LecturerID + "'}",
                        dataType: "json",
                        success: function (data) {
                            var obj = data.d;

                            if (obj != '') {
                                $("[id$='lblError2']").html(data.d);
                               
                                var success = data.d;

                                if (success == 'success') {
                                    $('#successEdit').show();
                                }

                                if (success == 'failed') {
                                    $('#failedEdit').show();
                                }

                                //$('#editable1').dataTable().fnSetColumnVis(1, false);
                                window.setTimeout(close_modal, 3000);
                                location.reload();

                            }

                        },
                        beforeSend: function () {
                            // Code to display spinner
                            $('#spinner1').show();
                        },
                        complete: function () {
                            // Code to hide spinner.
                            $('#spinner1').hide();
                        },
                        error: function (result) {
                            alert('The Course was NOT Updated successfully.');
                        }
                    });
                
            })
        });


        //Deleting Semester
        $(function () {
            $('#btnDelete').click(function () {
                var EditPID = essay_id;

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "ManageCourse.aspx/DeleteData",
                    data: "{'EPID':'" + EditPID + "'}",
                    dataType: "json",
                    success: function (data) {
                        var obj = data.d;

                        if (obj != '') {
                            $("[id$='lblError2']").html(data.d);

                            window.setTimeout(close_modal, 3000);
                            location.reload();

                        }

                    },
                    beforeSend: function () {
                        // Code to display spinner
                        $('#spinner2').show();
                    },
                    complete: function () {
                        // Code to hide spinner.
                        $('#spinner2').hide();
                    },
                    error: function (result) {
                        alert('The Course was NOT Deleted successfully.');
                    }
                });
            })
        });

        function close_modal() {
            $('#myModal3').hide();
        };


        //Loading Department dropdownlist
        $(document).on("change", "[id*=ddlDept]", function () {
            var DepartmentID = $("[id*=ddlDept]").find("option:selected").val()

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "ManageCourse.aspx/GetProgramme",
                data: "{'EDepartmentID':'" + DepartmentID + "'}",
                dataType: "json",
                success: function (data) {

                    var ddlProgramme = $("[id*=ddlProgramme]");
                    ddlProgramme.empty().append('<option selected="selected" value="0">--Please select--</option>');
                    $.each(data.d, function () {
                        ddlProgramme.append($("<option></option>").val(this['Value']).html(this['Text']));
                    });

                },
                beforeSend: function () {
                    // Code to display spinner
                    $('#spinner1').show();
                },
                complete: function () {
                    // Code to hide spinner.
                    $('#spinner1').hide();
                },
                error: function (result) {
                    alert('Error Occured.');
                }
            });

        });


        //Loading Department dropdownlist
        $(document).on("change", "[id*=ddlDept2]", function () {
            var DepartmentID = $("[id*=ddlDept2]").find("option:selected").val()

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "ManageCourse.aspx/GetProgramme",
                data: "{'EDepartmentID':'" + DepartmentID + "'}",
                dataType: "json",
                success: function (data) {

                    var ddlProgramme = $("[id*=ddlProgramme2]");
                    ddlProgramme.empty().append('<option selected="selected" value="0">--Please select--</option>');
                    $.each(data.d, function () {
                        ddlProgramme.append($("<option></option>").val(this['Value']).html(this['Text']));
                    });

                },
                beforeSend: function () {
                    // Code to display spinner
                    $('#spinner1').show();
                },
                complete: function () {
                    // Code to hide spinner.
                    $('#spinner1').hide();
                },
                error: function (result) {
                    alert('Error Occured.');
                }
            });

        });
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

            function fnClickAddRow() {
                $('#editable1').dataTable().fnAddData([
                    "Custom row",
                    "New row",
                    "New row",
                    "New row",
                    "New row"]);

            }
        </script>
</asp:Content>


