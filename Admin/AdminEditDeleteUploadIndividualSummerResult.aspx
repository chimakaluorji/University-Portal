<%@ Page Language="VB"  MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="AdminEditDeleteUploadIndividualSummerResult.aspx.vb" Inherits="Admin_AdminEditDeleteUploadIndividualSummerResult" %>

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
            <h2>Edit, Detele and Upload Summer Individual Result</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="Home.aspx">Dashboard</a>
                </li>

                <li class="active">
                    <strong>Edit, Detele and Upload Summer Individual Result</strong>
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
                                        <h5>Edit, Detele and Upload Summer Individual Result</h5>
                                        <br />
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
                                        <div id="Search">

                                            <div class="form-group">
                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinner" >
                                                       <img src="img/loading.gif" />
                                                        Fetching Student's Records.........
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

                                            <div class="modal-footer">
                                                <input type="button" id="btnSearch" value="Search" class="btn btn-primary" />
                                                <%--<asp:Button ID="Button1" runat="server" Text="Button" />
                                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>--%>
                                            </div>

                                          </div>

                                      <div id="Course" style="display:none;">
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-hover dataTables-example" id="editable1">
                                                <thead>
                                                    <tr>
                                                        <th>RegNumber</th>
                                                        <th>Surname</th>
                                                        <th>Firstname</th>
                                                        <th>Upload Result</th>
                                                        <th>Edit Result</th>
                                                        <th>Delete Result</th>
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
                                                        <th>RegNumber</th>
                                                        <th>Surname</th>
                                                        <th>Firstname</th>
                                                        <th>Upload Result</th>
                                                        <th>Edit Result</th>
                                                        <th>Delete Result</th>
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
    </div>

    <div class="modal inmodal" id="myModal1" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content animated flipInY">
             <div class="ibox-content">
                    <div class="modal-header">
                        <div class="form-group">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerUpload" >
                                                       <img src="img/loading.gif" />
                                                        Loading Student's Data.........
                                                      <img src="img/loader7.gif" />
                                                      
                                               </div>   
                          </div>
                       <h4 class="modal-title">STUDENT'S RESULT</h4>
                    </div>

                    <div class="modal-body">
                            
                    <div class="modal-footer">
                           <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                           <input type="button" id="btnUpload" value="UPLOAD RESULT" class="btn btn-primary" />
                     </div>

                   </div>
                 </div>
              </div>

            </div>
        </div>
    


    <div class="modal inmodal" id="myModal2" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content animated flipInY">
             <div class="ibox-content">
                    <div class="modal-header">
                        <div class="form-group">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerEdit" >
                                                       <img src="img/loading.gif" />
                                                        Loading Student's Data.........
                                                      <img src="img/loader7.gif" />
                                                      
                                               </div>   
                          </div>
                       <h4 class="modal-title">STUDENT'S RESULT</h4>
                    </div>

                    <div class="modal-body">
                            
                    <div class="modal-footer">
                           <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                           <input type="button" id="btnEdit" value="EDIT" class="btn btn-primary" />
                     </div>

                   </div>
                 </div>
              </div>

            </div>
        </div>



    <div class="modal inmodal" id="myModal3" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content animated flipInY">
             <div class="ibox-content">
                    <div class="modal-header">
                        <div class="form-group">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerDelete" >
                                                       <img src="img/loading.gif" />
                                                        Loading Student's Data.........
                                                      <img src="img/loader7.gif" />
                                                      
                                               </div>   
                          </div>
                       <h4 class="modal-title">STUDENT'S RESULT</h4>
                    </div>

                    <div class="modal-body">
                            
                    <div class="modal-footer">
                           <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                           <input type="button" id="btnDelete" value="DELETE" class="btn btn-primary" />
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
            var LevelID = $("[id*=ddlLevel]").find("option:selected").val()

            var SessionName = '2015/2016'//$("[id*=ddlSession]").find("option:selected").text()
            var SemesterName = 'ND 1 First Semester'//$("[id*=ddlSemester]").find("option:selected").text()
            var LevelName = 'ND Electrical Electronics'//$("[id*=ddlEntryLevel]").find("option:selected").text()

            //Checking if excel file was selected for upload

            if (SessionID == 0) {
                alert('Please Select the Session to continue');
                return false;
            }

            if (SemesterID == 0) {
                alert('Please Select the Semester to continue');
                return false;
            }

            if (LevelID == 0) {
                alert('Please Select the Programme to continue');
                return false;
            }

            //Uploading School Fees Data
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "AdminEditDeleteUploadIndividualSummerResult.aspx/GetStudent",
                data: "{'SessionName':'" + SessionName + "','SemesterName':'" + SemesterName + "','LevelName':'" + LevelName + "'}",
                dataType: "json",
                success: function (data) {
                    $('#Course').show();
                    $('#Search').hide();

                    for (var i = 0; i < data.d.length; i++) {
                        $('#editable1').dataTable().fnAddData([data.d[i].RegNumber, data.d[i].Surname, data.d[i].Firstname, "<a href='#myModal' id='" + data.d[i].RegNumber + "' data-toggle='modal' data-target='#myModal1'><i class='fa fa-check text-navy'></i></a>", "<a href='#myModal' id='" + data.d[i].RegNumber + "' data-toggle='modal' data-target='#myModal2'><i class='fa fa-check text-navy'></i></a>", "<a href='#myModal' id='" + data.d[i].RegNumber + "' data-toggle='modal' data-target='#myModal3'><i class='fa fa-check text-navy'></i></a>"]);
                    }

                    var essay_id;

                    //Getting the primary key for deleting and updating
                    $("a[data-toggle=modal]").click(function () {
                        essay_id = $(this).attr('id');

                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "AdminEditDeleteUploadIndividualSummerResult.aspx/GetStudentRegNo",
                            data: "{'ERegNumberSearch':'" + essay_id + "'}",
                            dataType: "json",
                            success: function (data) {
                                
                                      ////Opening the main page
                                      // $('#Search').hide();
                                      // $('#mainPage').show();

                                    },
                                    beforeSend: function () {
                                        // Code to display spinner
                                        $('#spinnerSearch').show();
                                    },
                                    complete: function () {
                                        // Code to hide spinner.
                                        $('#spinnerSearch').hide();
                                    },
                                    error: function (result) {
                                        alert('Error Occurred, Contact Admin.');
                                    }
                                });
                            });



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
                        }
                    });

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


        </script>
</asp:Content>