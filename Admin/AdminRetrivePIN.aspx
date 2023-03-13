<%@ Page Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="AdminRetrivePIN.aspx.vb" Inherits="Admin_AdminRetrivePIN" %>

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
                    <h2>Retrive PIN</h2>
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
                                                    <h5>Retrive School Fees PIN</h5><br />
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
                                              

                                                   <div id="search">
                                                        <div class="ibox-content">
                                                        <div class="form-horizontal">
                                                            <div class="form-group">
                                                               
                                                                 <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerFees" >
                                                                           <img src="img/loading.gif" />
                                                                             Searching for School Fees PIN........
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
                                                                <label class="col-lg-2 control-label">Reg. Number: </label>
                                                                 <div class="col-lg-10">
                                                                     <asp:TextBox ID="txtRegNoFees" runat="server" CssClass="form-control" placeholder="Reg. Number"></asp:TextBox>
                                                                </div>
                                                            </div>
                                        
                                                            <div class="form-group">
                                                                <div class="col-lg-offset-2 col-lg-10">
                                                                    <input type="button" value="Search For Fees PIN" id="btnSearchFess" class="btn btn-success-primary"/>
                                                                </div>
                                                            </div>
                                                            </div>
                                                            </div>
                                                           </div>

                                                            <div id="table" style="display:none;">
                                                             <div class="ibox-content">
                                                              <div class="form-horizontal">
                                                                <div class="form-group">
                                                                <div class="col-lg-12">
                                                                    <input type="button" value="Refresh" id="btnRefresh" class="btn btn-success-primary"/>
                                                                        <div class="table-responsive">
                                                                            <table class="table table-striped table-bordered table-hover dataTables-example" id="editable1">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>ePIN</th>
                                                                                        <th>Reg. Number</th>
                                                                                        <th>Session</th>
                                                                                        <th>Semester</th>
                                                                                        <th>Level</th>
                                                                                        <th>Status</th>
                                                                                        <th>Serial No</th>
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
                                                                                    </tr>
                                                                                    </tbody>

                                                                                    <tfoot>
                                                                                    <tr>
                                                                                        <th>ePIN</th>
                                                                                        <th>Reg. Number</th>
                                                                                        <th>Session</th>
                                                                                        <th>Semester</th>
                                                                                        <th>Level</th>
                                                                                        <th>Status</th>
                                                                                        <th>Serial No</th>
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
                            </div>
                       <%-- </div>--%>

                            <div class="col-lg-6">
                                <div class="ibox float-e-margins">
                                    <div class="wrapper wrapper-content animated fadeInRight">
                                             
                                        <div class="row">
                                            <div class="col-lg-12">
                                            <div class="ibox float-e-margins">
                                                <div class="ibox-title">
                                                    <h5>Retrive Result PIN</h5><br />
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
                                              

                                                   <div id="searchResult">
                                                        <div class="ibox-content">
                                                        <div class="form-horizontal">
                                                            <div class="form-group">
                                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerResult" >
                                                                       <img src="img/loading.gif" />
                                                                        Searching for Result PIN........
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
                                                                <label class="col-lg-2 control-label">Reg. Number: </label>
                                                                 <div class="col-lg-10">
                                                                     <asp:TextBox ID="txtRegNoResult" runat="server" CssClass="form-control" placeholder="Reg. Number"></asp:TextBox>
                                                                </div>
                                                            </div>
                                        
                                                            <div class="form-group">
                                                                <div class="col-lg-offset-2 col-lg-10">
                                                                    <input type="button" value="Search For Result PIN" id="btnSearchResult" class="btn btn-success-primary"/>
                                                                    
                                                                </div>
                                                            </div>
                                                            </div>
                                                            </div>
                                                           </div>

                                                            <div id="tableResult" style="display:none;">
                                                             <div class="ibox-content">
                                                              <div class="form-horizontal">
                                                                <div class="form-group">
                                                                <div class="col-lg-12">
                                                                    <input type="button" value="Refresh" id="btnRefreshResult" class="btn btn-success-primary"/>
                                                                        <div class="table-responsive">
                                                                            <table class="table table-striped table-bordered table-hover dataTables-example" id="editableResult">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>Result ePIN</th>
                                                                                        <th>Reg. Number</th>
                                                                                        <th>Session</th>
                                                                                        <th>Semester</th>
                                                                                        <th>Level</th>
                                                                                        <th>Status</th>
                                                                                        <th>Serial No</th>
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
                                                                                    </tr>
                                                                                    </tbody>

                                                                                    <tfoot>
                                                                                    <tr>
                                                                                        <th>Result ePIN</th>
                                                                                        <th>Reg. Number</th>
                                                                                        <th>Session</th>
                                                                                        <th>Semester</th>
                                                                                        <th>Level</th>
                                                                                        <th>Status</th>
                                                                                        <th>Serial No</th>
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
                            </div>
                    
                </div>
</div>

 <script src="latestJs_1.11/jquery.min.js"></script>
 <script src="DropzoneJs_scripts/dropzone.js"></script>
    
    <script type="text/javascript">

        $(document).ready(function () {

            //Upload School Fees PIN to the database
            $('#btnSearchFess').click(function () {
                //Setting Registration number
                var regNumber = $("[id*=txtRegNoFees]").val();


                //Checking if excel file was selected for upload
                if (regNumber == '') {
                    alert('Please fill the Reg. Number to continue');
                   return false;
                }

                

                //Uploading School Fees Data
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "AdminRetrivePIN.aspx/GetePIN",
                    data: "{'EregNumber':'" + regNumber + "'}",
                    dataType: "json",
                    success: function (data) {
                        $('#table').show();
                        $('#search').hide();
                        //alert(data.d);

                        //$('#editable1 tr').not(':first').not(':last').remove();
                        //var html = '';
                        //for (var i = 0; i < data.d.length; i++)
                        //    html += '<tr><td>' + data.d[i].FileID+
                        //            '</td><td>' + data.d[i].FileName + '</td></tr>';
                        //$('#editable1 tr').first().after(html);
                        
                            //var trHTML = '';
                            //$.each(data.d, function (i, item) {
                            //    trHTML += '<tr><td>' + data.d[i].FileID + '</td><td>' + data.d[i].FileName + '</td></tr>';
                            //});
                            //$('#editable1').append(trHTML);

                            //$.each(data.d, function () {
                            //    $('#editable1').append($("<td></td>").val(this['Value']).html(this['Text']));
                        //});

                        for (var i = 0; i < data.d.length; i++) {
                            $('#editable1').dataTable().fnAddData([data.d[i].ePIN, data.d[i].RegNumber, data.d[i].SessionName, data.d[i].SemesterName, data.d[i].LevelName, data.d[i].Status, data.d[i].SerialNo]);
                        }

                        //Course Registration
                        //var trHTML = ''
                        

                        //for (var i = 0; i < data.d.length; i++) {
                        //    trHTML = '<input type="checkbox" id=' + data.d[i].FileID + ' /> ';
                        //    $('#editable1').dataTable().fnAddData([data.d[i].FileID, data.d[i].FileName, trHTML]);
                        //}

                        //$('#btnFetch').click(function () {
                        //    $("input:checked").each(function () {
                        //        var id = $(this).attr("id");
                        //        //alert("Do something for: " + id);
                        //        $("[id*=txtRegNo]").val(id);
                        //    });
                        //});


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


            //Refreashing the Fees Page
            $('#btnRefresh').click(function () {
                $('#table').hide();
                $('#search').show();
                $('#spinnerFees').hide();
            });



            //Upload Result PIN to the database
            $('#btnSearchResult').click(function () {
                //Setting Registration number
                var regNumberResult = $("[id*=txtRegNoResult]").val();


                //Checking if excel file was selected for upload
                if (regNumberResult == '') {
                    alert('Please fill the Reg. Number to continue');
                    return false;
                }



                //Uploading School Fees Data
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "AdminRetrivePIN.aspx/GetResultePIN",
                    data: "{'EregNumberResult':'" + regNumberResult + "'}",
                    dataType: "json",
                    success: function (data) {
                        $('#tableResult').show();
                        $('#searchResult').hide();

                        for (var i = 0; i < data.d.length; i++) {
                            $('#editableResult').dataTable().fnAddData([data.d[i].ePIN, data.d[i].RegNumber, data.d[i].SessionName, data.d[i].SemesterName, data.d[i].LevelName, data.d[i].Status, data.d[i].SerialNo]);
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


            //Refreashing the Fees Page
            $('#btnRefreshResult').click(function () {
                $('#tableResult').hide();
                $('#searchResult').show();
                $('#spinnerResult').hide();
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