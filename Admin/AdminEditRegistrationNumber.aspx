<%@ Page Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="AdminEditRegistrationNumber.aspx.vb" Inherits="Admin_AdminEditRegistrationNumber" %>

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
            <h2>Update Reg. Number</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Dashboard</a>
                </li>

                <li class="active">
                    <strong>Update Reg. Number</strong>
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
                                        <h5>Update Reg. Number</h5>
                                        <br />
                                        <asp:Label ID="lblError" runat="server" Text="" Font-Size="13px" Font-Bold="true"></asp:Label>
                                        
                                                             <div class="form-group" id="successMsg" style="display:none;">
                                                                 <div class="col-lg-10">
                                                                    <div class="alert alert-success" >
                                                                        Reg. Number was successfully Updated.
                                                                    </div>
                                                                  </div>
                                                             </div>

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
                                   <div id="search">
                                                       
                                                        <div class="form-horizontal">
                                                           
                                                            <div class="form-group">
                                                                  <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinner" >
                                                                          <img src="img/loading.gif" />
                                                                             Working, Please wait ........
                                                                          <img src="img/loader7.gif" />
                                                      
                                                                  </div>   
                                                            </div>

                                                            <div>&nbsp;</div>
                                                              <div class="form-group">
                                                                    <label class="col-lg-2 control-label">Reg. Number: </label>
                                                                     <div class="col-lg-10">
                                                                         <asp:TextBox ID="txtRegNo" runat="server" CssClass="form-control" placeholder="Reg. Number"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                           
                                                                <div>&nbsp;</div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-offset-2 col-lg-10">
                                                                        <input type="button" value="Search" id="btnSearch" class="btn btn-success-primary"/>
                                                                    </div>
                                                                </div>
                                                              </div>
                                                           </div>
                                                 

                                        
                                                            <div id="table" style="display:none;">
                                                               
                                                                    
                                                                <div>&nbsp;</div>
                                                                <div class="form-group">
                                                                    <label class="col-lg-12 control-label"><b style="color:green;">Are you sure you want to update the Reg. Number below? If so, put the new Reg. Number</b></label>
                                                                </div>
                                                                <div>&nbsp;</div>
                                                                <div class="form-group">
                                                                    <label class="col-lg-2 control-label">Reg. Number: </label>
                                                                     <div class="col-lg-10">
                                                                         <asp:Label ID="lblRegNo" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                                    </div>
                                                                </div>
                                                                <div>&nbsp;</div>
                                                                  <div class="form-group">
                                                                        <label class="col-lg-2 control-label">New Reg. Number: </label>
                                                                         <div class="col-lg-10">
                                                                             <asp:TextBox ID="txtNewRegNumber" runat="server" CssClass="form-control" placeholder="New Reg. Number"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                 <div>&nbsp;</div>
                                                                <div class="form-group">
                                                                        <div class="col-lg-offset-2 col-lg-10">
                                                                            <input type="button" value="Update Reg. Number" id="btnUpdate" class="btn btn-success-primary"/>
                                                                            <input type="button" value="Cancel" id="btnRefresh" class="btn  btn-white"/>
                                                                        </div>
                                                                 </div>
                                                                 <div>&nbsp;</div>

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
            $('#btnSearch').click(function () {

                var regNumber = $("[id*=txtRegNo]").val();

                //Generating PIN
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "AdminEditRegistrationNumber.aspx/GetRegNumber",
                    data: "{'EregNumber':'"+ regNumber +"'}",
                    dataType: "json",
                    success: function (data) {
                        $('#table').show();
                        $('#search').hide();

                        $("[id*=lblRegNo]").text(data.d);

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


            //Upload School Fees PIN to the database
            $('#btnUpdate').click(function () {

                var regNumber = $("[id*=txtRegNo]").val();
                var newRegNumber = $("[id*=txtNewRegNumber]").val();
                

                //Generating PIN
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "AdminEditRegistrationNumber.aspx/UpdateRegNumber",
                    data: "{'EregNumber':'" + regNumber + "','EnewRegNumber':'" + newRegNumber + "'}",
                    dataType: "json",
                    success: function (data) {
                        $('#table').show();
                        $('#search').hide();
                        
                        var successMsg = data.d

                        if (successMsg == 'success') {
                            //Showing success message
                            $('#successMsg').show();
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
       
</asp:Content>