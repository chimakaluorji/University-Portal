<%@ Page Language="VB" MasterPageFile="~/Students/StudentMasterPage.master" AutoEventWireup="false" CodeFile="StudentResult.aspx.vb" Inherits="Students_StudentResult" %>

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
                    <h2>Check Result</h2>
                    <ol class="breadcrumb">
                        <li>
                            <a href="Default.aspx">Dashboard</a>
                        </li>
                        
                        <li class="active">
                            <strong>Student's Result</strong>
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
                                    <div class="ibox-title">
                                        <h5>Student Result</h5>
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
                                        <div class="alert alert-success" id="success" style="display:none;">
                                              
                                         </div>
                                         <div class="alert alert-danger" id="danger" style="display:none;">
                                                  
                                         </div>
                                        <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinner" >
                                                       <img src="img/loading.gif" />
                                                        Please wait, the system is searching for your result ........
                                                      <img src="img/loader7.gif" />
                                                      
                                        </div>

                                         <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerLoad" >
                                                       <img src="img/loading.gif" />
                                                        Please wait, the system is loading your result ........
                                                      <img src="img/loader7.gif" />
                                                      
                                        </div>
                                    </div>

                                   <div class="ibox-content">
                                       
                                        <div class="form-horizontal" id="Search">
                                            <div class="form-group"><label class="col-lg-2 control-label">Session: </label>
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

                                             <div class="form-group"><label class="col-lg-2 control-label">Semester: </label>
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

                                            <div class="form-group"><label class="col-lg-2 control-label">PIN: </label>
                                                 <div class="col-lg-10">
                                                    <asp:TextBox ID="txtPIN" runat="server" CssClass="form-control" placeholder="PIN" style="width:450px;"></asp:TextBox>
                                                </div>
                                            </div>
                                        
                                            <div class="form-group">
                                                <div class="col-lg-offset-2 col-lg-10">
                                                   <input type="button" id="btnSearch" value="Search For Result" class="btn btn-primary" />
                                                    <%--<asp:Button ID="Button1" runat="server" Text="Button" class="btn btn-primary" />
                                                    <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>--%>
                                                </div>
                                            </div>

                                        </div>

                                       <div id="table" style="display:none;">
                                           <div class="table-responsive">
                                                                            <table class="table table-striped table-bordered table-hover dataTables-example" id="editable">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>Course Code</th>
                                                                                        <th>Course Name</th>
                                                                                        <th>Credit Unit</th>
                                                                                        <th>Total</th>
                                                                                        <th>Grade</th>
                                                                                        <th>Remark</th>
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
                                                                                    </tr>
                                                                                    </tbody>

                                                                                    <tfoot>
                                                                                    <tr>
                                                                                        <th>Course Code</th>
                                                                                        <th>Course Name</th>
                                                                                        <th>Credit Unit</th>
                                                                                        <th>Total</th>
                                                                                        <th>Grade</th>
                                                                                        <th>Remark</th>
                                                                                    </tr>
                                                                                    </tfoot>
                                                                            </table>        
                                                                        </div>

                                       </div>


                                       <div id="CarryOvertable" style="display:none;">
                                           <div class="table-responsive">
                                                                            <table class="table table-striped table-bordered table-hover dataTables-example" id="CarryOvereditable">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>Course Code</th>
                                                                                        <th>Course Name</th>
                                                                                        <th>Credit Unit</th>
                                                                                        <th>Total</th>
                                                                                        <th>Grade</th>
                                                                                        <th>Remark</th>
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
                                                                                    </tr>
                                                                                    </tbody>

                                                                                    <tfoot>
                                                                                    <tr>
                                                                                        <th>Course Code</th>
                                                                                        <th>Course Name</th>
                                                                                        <th>Credit Unit</th>
                                                                                        <th>Total</th>
                                                                                        <th>Grade</th>
                                                                                        <th>Remark</th>
                                                                                    </tr>
                                                                                    </tfoot>
                                                                            </table>        
                                                                        </div>
                                             </div>

                                            <div id="Print" style="display:none;">
                                                 <input type="button" id="btnPrintResult" value="Print Result" class="btn btn-primary"/>
                                            </div>

                                    </div>
                                </div>
                            </div>
                    </div>
            </div>

  <%--New Implementation of jquery button submit--%>
    <script type="text/javascript" src="js/jquery-1.8.2.js"></script>
    <script type="text/javascript">

        //Saving the data
        $(function () {

            $('#btnSearch').click(function () {
               
                //Fetching the values of all the feilds
                //Step One
                var SessionID = $("[id*=ddlSession]").find("option:selected").val()
                var SemesterID = $("[id*=ddlSemester]").find("option:selected").val()
                var PIN = $("[id*=txtPIN]").val();

                var Session = $("[id*=ddlSession]").find("option:selected").text()
                var Semester = $("[id*=ddlSemester]").find("option:selected").text()

                //Checking if is filled
                if (SessionID == 0) {
                    alert('Please Select the Session to continue');
                    return false;
                }

                if (SemesterID == 0) {
                    alert('Please Select the Semester to continue');
                    return false;
                }

                if (PIN == '') {
                    alert('Please fill PIN to Continue')
                    return false;
                }

                //Working on session
                var splitSession = Session.split("-");
                var newSession = splitSession[0]

                //Working on Semester
                var splitSemester = Semester.split("-");
                var newSemester = splitSemester[0]

                var regNumber = '<%= Request.QueryString("RegNumber").Trim%>';

                //Saving Student Data
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "StudentResult.aspx/InsertData",
                    data: "{'RegistrationNumber':'" + regNumber + "','PIN':'" + PIN + "','SessionID':'" + SessionID + "','SemesterID':'" + SemesterID + "'}",
                    dataType: "json",
                    success: function (data) {
                        var obj = data.d;
                        if (obj != '') {

                            var check = data.d;
                            if (check != '') {

                                var studentMsg = check.split("and");
                                var retMsg = studentMsg[0]
                                var usedSession = studentMsg[1];
                                var usedSemester = studentMsg[2];


                                if (retMsg == 'NOTPAID') {
                                    $('#danger').show().html(usedSession);
                                    return false
                                }


                                if (retMsg != 'Active') {
                                    if (retMsg != 'USEDPIN') {
                                        $('#danger').show().html(retMsg);
                                        return  false
                                    }
                                }

                                if (retMsg == 'Active') {

                                    //Fetching Result
                                    $.ajax({
                                        type: "POST",
                                        contentType: "application/json; charset=utf-8",
                                        url: "StudentResult.aspx/FindAllResult",
                                        data: "{'RegistrationNumber':'" + regNumber + "','PIN':'" + PIN + "','SessionName':'" + newSession + "','SemesterName':'" + newSemester + "','SessionID':'" + SessionID + "','SemesterID':'" + SemesterID + "'}",
                                        dataType: "json",
                                        success: function (data) {
                                            var code = data.d[0].CourseCode;
                                            var errorMsg = data.d[0].CourseName;

                                            if (code == 'Empty') {
                                                $('#danger').show().html("YOU HAVE NOT REGISTER YOUR COURSES. GO TO 'REGISTER COURSES' TAB AND REGISTER YOUR COURSES.");
                                            } else {

                                                if (code == 'ERROR') {
                                                    $('#danger').show().html(errorMsg);
                                                    return false
                                                }

                                                $('#table').show()
                                                $('#Print').show()
                                                $('#Search').hide()
                                                $('#danger').hide()

                                                for (var i = 0; i < data.d.length; i++) {
                                                    $('#editable').dataTable().fnAddData([data.d[i].CourseCode, data.d[i].CourseName, data.d[i].CreditUnit, data.d[i].Total, data.d[i].Grade, data.d[i].Remark]);
                                                }
                                            }

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
                                            alert('Error Occurred, Chat with Admin.');
                                            GCM_Send();
                                        }
                                    });// End of Ajax


                                    //Fetching Carry Over Result
                                    $.ajax({
                                        type: "POST",
                                        contentType: "application/json; charset=utf-8",
                                        url: "StudentResult.aspx/FindAllCarryOverResult",
                                        data: "{'RegistrationNumber':'" + regNumber + "','PIN':'" + PIN + "','SessionName':'" + newSession + "','SemesterName':'" + newSemester + "','SessionID':'" + SessionID + "','SemesterID':'" + SemesterID + "'}",
                                        dataType: "json",
                                        success: function (data) {
                                            var code = data.d[0].CourseCode;

                                            if (code != 'Empty') {
                                                $('#CarryOvertable').show()
                                                $('#table').hide()
                                                $('#Search').hide()
                                                $('#danger').hide()
                                                $('#Print').show()

                                                for (var i = 0; i < data.d.length; i++) {
                                                    $('#CarryOvereditable').dataTable().fnAddData([data.d[i].CourseCode, data.d[i].CourseName, data.d[i].CreditUnit, data.d[i].Total, data.d[i].Grade, data.d[i].Remark]);
                                                }
                                            }

                                        },
                                        beforeSend: function () {
                                            // Code to display spinner
                                            //$('#spinnerLoad').show();
                                        },
                                        complete: function () {
                                            // Code to hide spinner.
                                            //$('#spinnerLoad').hide();
                                        },
                                        error: function (result) {
                                            alert('Error Occurred, Chat with Admin.');
                                            GCM_Send();
                                        }
                                    });// End of Ajax
                                }//End if statment

                               

                                if (retMsg == 'USEDPIN') {
                                    
                                    SessionID = '0';
                                   
                                    //Fetching Result
                                    $.ajax({
                                        type: "POST",
                                        contentType: "application/json; charset=utf-8",
                                        url: "StudentResult.aspx/FindAllResult",
                                        data: "{'RegistrationNumber':'" + regNumber + "','PIN':'" + PIN + "','SessionName':'" + usedSession + "','SemesterName':'" + usedSemester + "','SessionID':'" + SessionID + "','SemesterID':'" + SemesterID + "'}",
                                        dataType: "json",
                                        success: function (data) {
                                            var code = data.d[0].CourseCode;
                                            var errorMsg = data.d[0].CourseName;
                                            
                                            if (code == 'Empty') {
                                                $('#danger').show().html("YOU HAVE NOT REGISTER YOUR COURSES. GO TO 'REGISTER COURSES' TAB AND REGISTER YOUR COURSES.");
                                            } else {

                                                if (code == 'ERROR') {
                                                    $('#danger').show().html(errorMsg);
                                                    return false
                                                }

                                                $('#table').show()
                                                $('#Print').show()
                                                $('#Search').hide()
                                                $('#danger').hide()
                                                

                                                for (var i = 0; i < data.d.length; i++) {
                                                    $('#editable').dataTable().fnAddData([data.d[i].CourseCode, data.d[i].CourseName, data.d[i].CreditUnit, data.d[i].Total, data.d[i].Grade, data.d[i].Remark]);
                                                }
                                            }

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
                                            alert('Error Occurred, Chat with Admin.');
                                            GCM_Send();
                                        }
                                    });// End of Ajax



                                    //Fetching Carry Over Result
                                    $.ajax({
                                        type: "POST",
                                        contentType: "application/json; charset=utf-8",
                                        url: "StudentResult.aspx/FindAllCarryOverResult",
                                        data: "{'RegistrationNumber':'" + regNumber + "','PIN':'" + PIN + "','SessionName':'" + usedSession + "','SemesterName':'" + usedSemester + "','SessionID':'" + SessionID + "','SemesterID':'" + SemesterID + "'}",
                                        dataType: "json",
                                        success: function (data) {
                                            var code = data.d[0].CourseCode;

                                            if (code != 'Empty') {
                                                $('#CarryOvertable').show()
                                                $('#table').hide()
                                                $('#Search').hide()
                                                $('#danger').hide()
                                                $('#Print').show()

                                                for (var i = 0; i < data.d.length; i++) {
                                                    $('#CarryOvereditable').dataTable().fnAddData([data.d[i].CourseCode, data.d[i].CourseName, data.d[i].CreditUnit, data.d[i].Total, data.d[i].Grade, data.d[i].Remark]);
                                                }
                                            }

                                        },
                                        beforeSend: function () {
                                            // Code to display spinner
                                            //$('#spinnerLoad').show();
                                        },
                                        complete: function () {
                                            // Code to hide spinner.
                                            //$('#spinnerLoad').hide();
                                        },
                                        error: function (result) {
                                            alert('Error Occurred, Chat with Admin.');
                                            GCM_Send();
                                        }
                                    });// End of Ajax


                                }//End if statment
                                
                            } else {
                                $('#danger').show().html(check);
                            }

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
                        alert('Error Occurred, Chat with Admin.');
                        GCM_Send();
                    }
                });// End of Ajax

            })


            $('#btnPrintResult').click(function () {
                
                var Session1 = $("[id*=ddlSession]").find("option:selected").text()
                var Semester1 = $("[id*=ddlSemester]").find("option:selected").text()

                //Working on session
                var splitSession1 = Session1.split("-");
                var newSession1 = splitSession1[0]

                //Working on Semester
                var splitSemester1 = Semester1.split("-");
                var newSemester1 = splitSemester1[0]

                var regNumber1 = '<%= Request.QueryString("RegNumber")%>';

                return popitup('PrintResult/PrintStudentResult.aspx?regNo=' + regNumber1 + '&SessionName=' + newSession1 + '&SemesterName=' + newSemester1);
            })

            function popitup(url) {
                newwindow = window.open(url, 'name', 'height=1800,width=1010,scrollbars=yes,resizable=yes');
                if (window.focus) { newwindow.focus() }
                return false;
            }

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
                        { extend: 'excel', title: 'Student_Result' },
                        { extend: 'pdf', title: 'Student_Result' },

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