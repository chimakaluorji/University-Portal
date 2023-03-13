<%@ Page Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="AdminViewStudentThatHasCheckResult.aspx.vb" Inherits="Admin_AdminViewStudentThatHasCheckResult" %>

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
            <h2>View Student That Has Checked Result</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="Home.aspx">Dashboard</a>
                </li>

                <li class="active">
                    <strong>View Student That Has Checked Result</strong>
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
                                        <h5>View Student That Has Checked Result</h5>
                                        <br />
                                        
                                        <div class="ibox-tools">
                                            <a class="collapse-link">
                                                <i class="fa fa-chevron-up"></i>
                                            </a>
                                            
                                            <a class="close-link">
                                                <i class="fa fa-times"></i>
                                            </a>
                                        </div>

                                        <asp:Label ID="lblMessage" runat="server" Text="" Font-Bold="true"></asp:Label>

                                         <div class="form-group">
                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinner" >
                                                       <img src="img/loading.gif" />
                                                        Loading Students that have checked thier result........
                                                      <img src="img/loader7.gif" />
                                                      
                                               </div>   
                                           </div>
                                    </div>


                                    <div class="ibox-content">
                                        <div id="Search">

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
                                       
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-hover dataTables-example" id="editable1">
                                                <thead>
                                                    <tr>
                                                        <th>Reg Number</th>
                                                        <th>Result Pin</th>
                                                        <th>Surname</th>
                                                        <th>First Name</th>
                                                        <th>Session</th>
                                                        <th>Semeste</th>
                                                        <th>Programme</th>
                                                        <th>Status</th>
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
                                                    </tr>
                                                </tbody>

                                                <tfoot>
                                                    <tr>
                                                        <th>Reg Number</th>
                                                        <th>Result Pin</th>
                                                        <th>Surname</th>
                                                        <th>First Name</th>
                                                        <th>Session</th>
                                                        <th>Semeste</th>
                                                        <th>Programme</th>
                                                        <th>Status</th>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>
                                       
                                       <div class="modal-footer">
                                             <input type="button" id="btnRefresh" value="Refresh" class="btn btn-primary" />
                                             
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
            
            //Upload School Fees PIN to the database
            $('#btnSearch').click(function () {
                //Setting Registration number
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
                    url: "AdminViewStudentThatHasCheckResult.aspx/GetResult",
                    data: "{'intSessionID':'" + SessionID + "','intSemesterID':'" + SemesterID + "'}",
                    dataType: "json",
                    success: function (data) {
                        $('#Course').show();
                        $('#Search').hide();
                        
                        $("[id*=lblMessage]").html(data.d[0].Message);

                        for (var i = 0; i < data.d.length; i++) {
                            $('#editable1').dataTable().fnAddData([data.d[i].RegNumber, data.d[i].ResultETransactPin, data.d[i].Surname, data.d[i].Firstname, data.d[i].SessionName, data.d[i].SemesterName, data.d[i].LevelName, data.d[i].Status]);
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
                    error: function (xhr, status, error) {
                        alert(xhr.responseText);
                    }
                });
  

            });

            $('#btnRefresh').click(function () {
                window.location.reload();
            });
        });



        //error: function (xhr, status, error) {
        //    alert(xhr.responseText);
        //}
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