<%@ Page Language="VB" MasterPageFile="~/Students/StudentMasterPage.master" AutoEventWireup="false" CodeFile="StudentChangePassword.aspx.vb" Inherits="Students_StudentChangePassword" %>

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
                    <h2>Edit Phone Number</h2>
                    <ol class="breadcrumb">
                        <li>
                            <a href="Default.aspx">Dashboard</a>
                        </li>
                        
                        <li class="active">
                            <strong>Edit Phone Number</strong>
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
                                        <h5>Edit Phone Number</h5>
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
                                                        Please wait,the system is Changing your password ........
                                                      <img src="img/loader7.gif" />
                                                      
                                        </div>
                                    </div>

                                   <div class="ibox-content">
                                      
                                        <div class="form-horizontal" id="Search">
                                             <div class="form-group"><label class="col-lg-2 control-label">Old Password: </label>
                                                 <div class="col-lg-10">
                                                     <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" placeholder="Old Password" TextMode="Password"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group"><label class="col-lg-2 control-label">New Password: </label>
                                                 <div class="col-lg-10">
                                                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" placeholder="New Password" TextMode="Password"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="form-group"><label class="col-lg-2 control-label">Confirm Password: </label>
                                                 <div class="col-lg-10">
                                                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                                </div>
                                            </div>
                                        
                                            <div class="form-group">
                                                <div class="col-lg-offset-2 col-lg-10">
                                                   <input type="button" id="btnPassword" value="Change Password" class="btn btn-primary" />
                                                    <%--<asp:Button ID="Button1" runat="server" Text="Button" class="btn btn-primary" />
                                                    <asp:Label ID="lblDisplay" runat="server" Text=""></asp:Label>--%>
                                                </div>
                                            </div>

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

            $('#btnPassword').click(function () {
                //Fetching the values of all the feilds
                var OldPassword = $("[id*=txtOldPassword]").val();
                var NewPassword = $("[id*=txtNewPassword]").val();
                var ConfirmPassword = $("[id*=txtConfirmPassword]").val();

                GCM_Send();

                //Checking if is filled
                if (OldPassword == '') {
                    alert('Please fill the Old Password to Continue')
                    return false;
                }

                if (NewPassword == '') {
                    alert('Please fill the New Password to Continue')
                    return false;
                }

                if (ConfirmPassword == '') {
                    alert('Please fill the Confirm Password to Continue')
                    return false;
                }

                if (ConfirmPassword != NewPassword) {
                    alert('Your new Password does not match with confirm Password')
                    return false;
                }

                var regNumber = '<%= Request.QueryString("RegNumber").Trim%>';

                //Saving Student Data
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "StudentChangePassword.aspx/InsertData",
                    data: "{'regNumber':'" + regNumber + "','NewPassword':'" + NewPassword + "','OldPassword':'" + OldPassword + "'}",
                    dataType: "json",
                    success: function (data) {
                       
                            var check = data.d;
                            if (check != '') {
                                //$('#success').show().html(check);
                                if (check == 'success') {
                                    window.location.href = "Default.aspx?msg=The Password was Changed Successfully. Please login with your new password";
                                }
                            } else {
                                $('#danger').show().html(check);
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

            //Sending GCM Function
            function GCM_Send() {

                var regNumber = '<%= Request.QueryString("RegNumber").Trim%>';

                //Fetching Carry Over Result
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "StudentChangePassword.aspx/GCM_Send",
                    data: "{'regNumber':'" + regNumber + "'}",
                    dataType: "json",
                    success: function (data) {

                    },
                    error: function (result) {
                        //alert('Error Occurred, Chat with Admin.');
                    }

                });// End of Ajax
            }

        });
      

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