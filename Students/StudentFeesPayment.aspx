<%@ Page Language="VB" MasterPageFile="~/Students/StudentMasterPage.master" AutoEventWireup="false" CodeFile="StudentFeesPayment.aspx.vb" Inherits="Students_StudentFeesPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
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
                    <h2>Pay School Fees</h2>
                    <ol class="breadcrumb">
                        <li>
                            <a href="Default.aspx">Dashboard</a>
                        </li>
                        
                        <li class="active">
                            <strong>School Fees Payment</strong>
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
                                        <h5>Pay School Fees</h5>
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
                                                        Please wait, the school fees payment is processing ........
                                                      <img src="img/loader7.gif" />
                                                      
                                        </div> 
                                    </div>
                                   <div class="ibox-content">
                                        <div id="Form1" class="form-horizontal" runat="server">
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

                                            <div class="form-group"><label class="col-lg-2 control-label">PIN: </label>
                                                 <div class="col-lg-10">
                                                    <asp:TextBox ID="txtPIN" runat="server" CssClass="form-control" placeholder="PIN" ></asp:TextBox>
                                                </div>
                                            </div>
                                        
                                            <div class="form-group">
                                                <div class="col-lg-offset-2 col-lg-10">
                                                    <input type="button" id="btnPay" value="PAY" class="btn btn-primary" />
                                                    <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                                    <asp:Button ID="Button1" runat="server" Text="Button" />--%>
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

            $('#btnPay').click(function () {
                
                //Fetching the values of all the feilds
                //Step One
                var SessionID = $("[id*=ddlSession]").find("option:selected").val()
                var SemesterID = $("[id*=ddlSemester]").find("option:selected").val()
                var PIN = $("[id*=txtPIN]").val();

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

                var regNumber = '<%= Request.QueryString("RegNumber").Trim%>';

                        //Saving Student Data
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "StudentFeesPayment.aspx/InsertData",
                            data: "{'RegistrationNumber':'" + regNumber + "','PIN':'" + PIN + "','SessionID':'" + SessionID + "','SemesterID':'" + SemesterID + "'}",
                            dataType: "json",
                            success: function (data) {
                                
                                var check = data.d;


                                    if (check != '') {
                                       

                                        if (check == 'success') {

                                            $('#success').show().html("...Please Wait...");

                                            $.ajax({
                                                type: "POST",
                                                contentType: "application/json; charset=utf-8",
                                                url: "StudentFeesPayment.aspx/PaySchoolFees",
                                                data: "{'RegistrationNumber':'" + regNumber + "','PIN':'" + PIN + "','SessionID':'" + SessionID + "','SemesterID':'" + SemesterID + "'}",
                                                dataType: "json",
                                                success: function (data) {

                                                    var check = data.d;
                                                    if (check != '') {
                                                        if (check == 'success') {
                                                            $('#success').show().html("The School Fees was successfully Paid.");
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
                                            });//Ajax End

                                        } else {
                                            //If Statement end
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
                        });

            })

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


   <!-- Steps -->
    <script src="js/plugins/staps/jquery.steps.min.js"></script>

    <!-- Jquery Validate -->
    <script src="js/plugins/validate/jquery.validate.min.js"></script>

    <!-- Chosen -->
    <script src="js/plugins/chosen/chosen.jquery.js"></script>

   <!-- JSKnob -->
   <script src="js/plugins/jsKnob/jquery.knob.js"></script>

   <!-- Input Mask-->
    <script src="js/plugins/jasny/jasny-bootstrap.min.js"></script>

   <!-- Data picker -->
   <script src="js/plugins/datapicker/bootstrap-datepicker.js"></script>

   <!-- NouSlider -->
   <script src="js/plugins/nouslider/jquery.nouislider.min.js"></script>

   <!-- Switchery -->
   <script src="js/plugins/switchery/switchery.js"></script>

    <!-- IonRangeSlider -->
    <script src="js/plugins/ionRangeSlider/ion.rangeSlider.min.js"></script>

    <!-- iCheck -->
    <script src="js/plugins/iCheck/icheck.min.js"></script>

    <!-- MENU -->
    <script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>

    <!-- Color picker -->
    <script src="js/plugins/colorpicker/bootstrap-colorpicker.min.js"></script>

    <!-- Clock picker -->
    <script src="js/plugins/clockpicker/clockpicker.js"></script>

    <!-- Image cropper -->
    <script src="js/plugins/cropper/cropper.min.js"></script>

    <!-- Date range use moment.js same as full calendar plugin -->
    <script src="js/plugins/fullcalendar/moment.min.js"></script>

    <!-- Date range picker -->
    <script src="js/plugins/daterangepicker/daterangepicker.js"></script>

    <!-- Select2 -->
    <script src="js/plugins/select2/select2.full.min.js"></script>

    <!-- TouchSpin -->
    <script src="js/plugins/touchspin/jquery.bootstrap-touchspin.min.js"></script>


    <script>
        $(document).ready(function () {

            var $image = $(".image-crop > img")
            $($image).cropper({
                aspectRatio: 1.618,
                preview: ".img-preview",
                done: function (data) {
                    // Output the result data for cropping image.
                }
            });

            var $inputImage = $("#inputImage");
            if (window.FileReader) {
                $inputImage.change(function () {
                    var fileReader = new FileReader(),
                            files = this.files,
                            file;

                    if (!files.length) {
                        return;
                    }

                    file = files[0];

                    if (/^image\/\w+$/.test(file.type)) {
                        fileReader.readAsDataURL(file);
                        fileReader.onload = function () {
                            $inputImage.val("");
                            $image.cropper("reset", true).cropper("replace", this.result);
                        };
                    } else {
                        showMessage("Please choose an image file.");
                    }
                });
            } else {
                $inputImage.addClass("hide");
            }

            $("#download").click(function () {
                window.open($image.cropper("getDataURL"));
            });

            $("#zoomIn").click(function () {
                $image.cropper("zoom", 0.1);
            });

            $("#zoomOut").click(function () {
                $image.cropper("zoom", -0.1);
            });

            $("#rotateLeft").click(function () {
                $image.cropper("rotate", 45);
            });

            $("#rotateRight").click(function () {
                $image.cropper("rotate", -45);
            });

            $("#setDrag").click(function () {
                $image.cropper("setDragMode", "crop");
            });
        });
</script>
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