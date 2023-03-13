<%@ Page Language="VB" MasterPageFile="~/Students/StudentMasterPage.master" AutoEventWireup="false" CodeFile="StudentPrintProfile.aspx.vb" Inherits="Students_StudentPrintProfile" %>

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
                    <h2>Print Student Profile</h2>
                    <ol class="breadcrumb">
                        <li>
                            <a href="Default.aspx">Dashboard</a>
                        </li>
                        
                        <li class="active">
                            <strong>Print Student Profile</strong>
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
                                        <h5>Student Profile</h5>
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
                                       
                                       <div id="table">
                                           <div class="row wrapper border-bottom white-bg page-heading">
                                                <div class="col-lg-8">
                                                    <ol class="breadcrumb">
                                                        <li>
                                                            <a href="Default.aspx">Home</a>
                                                        </li>
                                                        
                                                        <li class="active">
                                                            <strong>Student Profile</strong>
                                                        </li>
                                                    </ol>
                                                </div>
                                                <div class="col-lg-4">
                                                    <div class="title-action">
                                                        <a href="#sign_up" class="btn btn-primary"><i class="fa fa-print"></i> Print Profile </a>
                                                    </div>
                                                </div>
                                            </div>

                                           <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="wrapper wrapper-content animated fadeInRight">
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                       <h4 class="text-navy">Passport Photography</h4>
                                                                        <address>
                                                                            <%--<strong>Heritage Polytechnic</strong><br>
                                                                            Eket,<br>
                                                                            Akwa Ibom State, Nigeria<br>
                                                                            <abbr title="Phone">Phone Number: </abbr> + (234) 809 351 0308--%>
                                                                             <asp:Image ID="StudentPhotoUrl" runat="server" Width="100px" Height="100px" AlternateText="Passport Photography"/>
                                                                        </address>
                                                                        
                                                                    </div>

                                                                    <div class="col-sm-5">
                                                                       <h4 class="text-navy">Bio-Data</h4>
                                                                        <address>
                                                                            <strong>Registration Number:</strong>: <asp:Label ID="lblRegNumber" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Surname:</strong>: <asp:Label ID="lblSurname" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Firstname:</strong>: <asp:Label ID="lblFirstname" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Middle Name:</strong>: <asp:Label ID="lblMiddleName" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Mothers Maiden Name:</strong>: <asp:Label ID="lblMothersMaidenName" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Date of Birth:</strong>: <asp:Label ID="lblDateofBirth" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Sex:</strong>: <asp:Label ID="lblSex" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>State:</strong>: <asp:Label ID="lblState" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>L.G.A:</strong>: <asp:Label ID="lblLGA" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                        </address>
                                                                    </div>

                                                                    <div class="col-sm-5">
                                                                       <h4 class="text-navy">Contacts</h4>
                                                                        <address>
                                                                            <strong>Home Address:</strong> <asp:Label ID="lblHomeAddress" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Phone Number:</strong> <asp:Label ID="lblPhoneNumber" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Email Address:</strong> <asp:Label ID="lblEmailAddress" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Phone of Next of Kin:</strong> <asp:Label ID="lblPhoneOfNextOfKin" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                        </address>
                                                                    </div>

                                                                    <div class="col-sm-5">
                                                                       <h4 class="text-navy">Academic</h4>
                                                                        <address>
                                                                            <strong>Session:</strong> <asp:Label ID="lblSession" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Semester:</strong> <asp:Label ID="lblSemester" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Programme:</strong> <asp:Label ID="lblLevel" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                        </address>
                                                                    </div>

                                                                    <div class="col-sm-12">
                                                                       <h4 class="text-navy">Academic Background</h4>
                                                                        <address>
                                                                            <strong>Primary School Attended:</strong> <asp:Label ID="lblPrimarySchoolAttended" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>From:</strong> <asp:Label ID="lblPFrom" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label>
                                                                            <strong>To:</strong> <asp:Label ID="lblPTo" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                             <strong>Secondary School Attended:</strong> <asp:Label ID="lblSecondarySchoolAttended" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>From:</strong> <asp:Label ID="lblSFrom" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label>
                                                                            <strong>To:</strong> <asp:Label ID="lblSTo" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                        </address>
                                                                    </div>
                                                                </div>

                                                    </div>
                                                </div>
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

            var EID;

            $('#btnSearch').click(function () {
               
                //Fetching the values of all the feilds
                //Step One
                var SessionID = $("[id*=ddlSession]").find("option:selected").val()
                var SemesterID = $("[id*=ddlSemester]").find("option:selected").val()

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

                //Working on session
                var splitSession = Session.split("-");
                var newSession = splitSession[0]

                //Working on Semester
                var splitSemester = Semester.split("-");
                var newSemester = splitSemester[0]

                var regNumber = '<%= Request.QueryString("RegNumber").Trim%>';

                var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];


                var dt = new Date();
                //var date = dt.getDate() + '-' + dt.getMonth() + '-' + dt.getFullYear();
                var date = monthNames[dt.getMonth()] + ' ' + dt.getDate() + ', ' + dt.getFullYear();

                //Saving Student Data
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "StudentPrintReceipt.aspx/FindETransactionID",
                    data: "{'RegistrationNumber':'" + regNumber + "','SessionID':'" + SessionID + "','SemesterID':'" + SemesterID + "'}",
                    dataType: "json",
                    success: function (data) {
                       
                            var check = data.d;
                            if (check != '') {
                                if(check != "You have NOT 'PAY SCHOOL FEES' for the Session and semester you selected."){
                                    EID = check;

                                    //alert(check);
                                    //Fetching Receipt
                                    $.ajax({
                                        type: "POST",
                                        contentType: "application/json; charset=utf-8",
                                        url: "StudentPrintReceipt.aspx/FindAllReceipt",
                                        data: "{'RegistrationNumber':'" + regNumber + "','PIN':'" + check + "'}",
                                        dataType: "json",
                                        success: function (data) {

                                            $('#table').show();
                                            $('#Search').hide();

                                            //Working on session
                                            var splitRetSession = data.d[0].SessionName.split("/");
                                            var newRetSession = splitRetSession[1]


                                            $("[id*=lblReceiptNo1]").html(data.d[0].ePIN);
                                            $("[id*=lblReceiptNo2]").html(data.d[0].RegNumber);
                                            $("[id*=lblReceiptNo3]").html(newRetSession);
                                            $("[id*=lblStudentName]").html(data.d[0].StudentName);
                                            $("[id*=lblAddress]").html(data.d[0].HomeAddress);
                                            $("[id*=lblStudnetPhoneNo]").html(data.d[0].PhoneNo);
                                            $("[id*=lblReceiptDate]").html(date);
                                            $("[id*=lblSemester]").html(data.d[0].SemesterName);
                                            $("[id*=lblSession]").html(data.d[0].SessionName);
                                            $("[id*=lblUnitPrice]").html(data.d[0].Amount);
                                            $("[id*=lblTotalPrice]").html(data.d[0].Amount);
                                            $("[id*=lblSubTotal]").html(data.d[0].Amount);
                                            $("[id*=lblMainTotal]").html(data.d[0].Amount);

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


                                    } else {
                                        $('#danger').show().html(check);
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

            $('a[href="#sign_up"]').click(function () {
                var regNumberNew = '<%= Request.QueryString("RegNumber").Trim%>'
                return popitup('PrintStudentProfile.aspx?regNumber=' + regNumberNew + '&PIN=' + EID);
            });

            function popitup(url) {
                newwindow = window.open(url, 'name', 'height=1800,width=1010,scrollbars=yes,resizable=yes');
                if (window.focus) { newwindow.focus() }
                return false;
            }
            <%--$('#btnPrintResult').click(function () {
                
                var Session1 = $("[id*=ddlSession]").find("option:selected").text()
                var Semester1 = $("[id*=ddlSemester]").find("option:selected").text()

                //Working on session
                var splitSession1 = Session1.split("-");
                var newSession1 = splitSession1[0]

                //Working on Semester
                var splitSemester1 = Semester1.split("-");
                var newSemester1 = splitSemester1[0]

                var regNumber1 = '<%= Request.QueryString("RegNumber").Trim%>';

                return popitup('PrintResult/PrintStudentResult.aspx?regNo=' + regNumber1 + '&SessionName=' + newSession1 + '&SemesterName=' + newSemester1);
            })

            function popitup(url) {
                newwindow = window.open(url, 'name', 'height=1800,width=1010,scrollbars=yes,resizable=yes');
                if (window.focus) { newwindow.focus() }
                return false;
            }--%>

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
