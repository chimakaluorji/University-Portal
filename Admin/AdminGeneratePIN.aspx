<%@ Page Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="AdminGeneratePIN.aspx.vb" Inherits="Admin_AdminGeneratePIN" %>

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

     <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Generate PIN</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Dashboard</a>
                </li>

                <li class="active">
                    <strong>Generate PIN</strong>
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
                                        <h5>Generate PIN</h5>
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

                                   <div id="search">
                                                        <div class="ibox-content">
                                                        <div class="form-horizontal">
                                                            <div class="form-group">
                                                                 <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinner" >
                                                                           <img src="img/loading.gif" />
                                                                            The system is generating PINs........
                                                                          <img src="img/loader7.gif" />
                                                      
                                                                   </div> 
                                                            </div>

                                                             <div class="form-group" id="successMsg" style="display:none;">
                                                                 <div class="col-lg-10">
                                                                    <div class="alert alert-success" >
                                                                      PIN was successfully Generated.
                                                                    </div>
                                                                  </div>
                                                             </div>

                                                            <div class="form-group">
                                                                <div class="col-lg-offset-2 col-lg-10">
                                                                    <input type="button" value="Generate PIN" id="btnGeneratePIN" class="btn btn-success-primary"/>
                                                                </div>
                                                            </div>
                                                            </div>
                                                            </div>
                                                           </div>

                                        
                                                            <div id="table" style="display:none;">
                                                                <div class="ibox-content">
                                                                <input type="button" value="Refresh" id="btnRefresh" class="btn btn-success-primary"/>
                                                                <div class="table-responsive">
                                                                    <table class="table table-striped table-bordered table-hover dataTables-example" id="editable1">
                                                                        <thead>
                                                                            <tr>
                                                                                <th>Serial No</th>
                                                                                <th>PIN</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <tr class="gradeX">
                                                                                <td></td>
                                                                                <td></td>
                                                                            </tr>
                                                                        </tbody>
                                                                        <tfoot>
                                                                            <tr>
                                                                                <th>Serial No</th>
                                                                                <th>PIN</th>
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


<script type="text/javascript" src="js/jquery-1.8.2.js"></script>
  
 <script type="text/javascript">

        $(document).ready(function () {

            //Upload School Fees PIN to the database
            $('#btnGeneratePIN').click(function () {
                
                //Generating PIN
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "AdminGeneratePIN.aspx/GetePIN",
                    data: "{}",
                    dataType: "json",
                    success: function (data) {
                        $('#table').show();
                        $('#search').hide();
                        
                        //Showing success message
                        $('#successMsg').show();

                        //Looping through the returned values
                        for (var i = 0; i < data.d.length; i++) {
                            $('#editable1').dataTable().fnAddData([data.d[i].Serial, data.d[i].PIN]);
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
                        alert('Error Occurred, Please Contact Admin.');
                    }
                });


            });

            //Refreashing the Fees Page
            $('#btnRefresh').click(function () {
                $('#table').hide();
                $('#search').show();

                $('#successMsg').hide();
                $('#spinner').hide();
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
                        { extend: 'excel', title: 'Generated_PINs' },
                        { extend: 'pdf', title: 'Generated_PINs' },

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