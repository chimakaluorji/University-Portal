<%@ Page Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="AdminUploadDepartmentalResult.aspx.vb" Inherits="Admin_AdminUploadDepartmentalResult" %>

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

    <link href="DropzoneJs_scripts/dropzone.css" rel="stylesheet" />

    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Manage Result</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Dashboard</a>
                </li>

                <li class="active">
                    <strong>Manage Result</strong>
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
                                        <h5>Manage Result</h5>
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
                                                <div class="col-lg-12" style="color: #F25926; font-size: 15px; display: none; text-align: center;" id="spinner">
                                                    <img src="img/loading.gif" />
                                                    Searching for Semester........
                                                      <img src="img/loader7.gif" />

                                                </div>
                                            </div>



                                            <div>&nbsp;</div>

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
                                                <label class="col-lg-2 control-label">Programme: </label>
                                                <div class="col-lg-10">
                                                    <asp:DropDownList ID="ddlEntryLevel" runat="server" AppendDataBoundItems="True" DataSourceID="odsEntryLevel" DataTextField="LevelName" DataValueField="LevelID" CssClass="form-control">
                                                        <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="odsEntryLevel" runat="server" EnableCaching="True" SelectMethod="FindAllLevels" TypeName="SessionLevelSemesterCourseDAL"></asp:ObjectDataSource>
                                                </div>
                                            </div>

                                            <div>&nbsp;</div>
                                        </div>

                                        <div id="Course" style="display: none;">
                                            <div class="form-group">
                                                <div class="col-lg-12" style="color: #F25926; font-size: 15px; display: none; text-align: center;" id="spinnerRegister">
                                                    <img src="img/loading.gif" />
                                                    Searching for Course Code........
                                                      <img src="img/loader7.gif" />

                                                </div>
                                            </div>

                                            <div>&nbsp;</div>

                                            <div class="form-group">
                                                <label class="col-lg-2 control-label">Select Semester: </label>
                                                <div class="col-lg-10">
                                                    <div id="chkboxlistCourse"></div>
                                                </div>
                                            </div>

                                            <div>&nbsp;</div>


                                        </div>

                                        <div id="CourseCode" style="display: none;">
                                            <div class="form-group">
                                                <div class="col-lg-12" style="color: #F25926; font-size: 15px; display: none; text-align: center;" id="spinnerCourseCode">
                                                    <img src="img/loading.gif" />
                                                    Uploading Result........
                                                      <img src="img/loader7.gif" />

                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label class="col-lg-2 control-label">Select Course Code: </label>
                                                <div class="col-lg-10">
                                                    <div id="chkboxlistCourseCode"></div>
                                                </div>
                                            </div>

                                            <div>&nbsp;</div>

                                            <div class="form-group">
                                                <label class="col-lg-2 control-label">Select Excel File: </label>
                                                <div class="col-lg-10">
                                                    <div id="dZUploadResult" class="dropzone">
                                                        <div class="dz-default dz-message">
                                                            Browse or Drop an excel file here. 
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div>&nbsp;</div>

                                            <div class="modal-footer">
                                                <input type="button" id="btnUploadResult" value="Upload Result" class="btn btn-primary" />
                                            </div>

                                            <div>&nbsp;</div>
                                        </div>

                                        <div id="Result" style="display: none;">
                                            <div class="alert alert-success" id="success" style="display: none;">
                                                The Result was successfully Uploaded.
                                            </div>

                                            <div class="alert alert-danger" id="danger" style="display: none;">
                                                The Result was NOT successfully Uploaded.
                                            </div>

                                            <div class="form-group">
                                                <div class="col-lg-12" style="color: #F25926; font-size: 15px; display: none; text-align: center;" id="spinnerLoadingResult">
                                                    <img src="img/loading.gif" />
                                                    Please wait, the system is loading the results ....
                                                      <img src="img/loader7.gif" />

                                                </div>
                                            </div>

                                            <div>&nbsp;</div>

                                            <div class="table-responsive" id="table">
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
            console.log("Hello");
            Dropzone.autoDiscover = false;

            var imgNameResult = '';

            //Upload Result PIN
            $("#dZUploadResult").dropzone({
                url: "excelUploader.ashx",
                maxFiles: 5,
                addRemoveLinks: true,
                success: function (file, response) {
                    imgNameResult = response;

                    file.previewElement.classList.add("dz-success");
                    console.log("Successfully uploaded :" + imgNameResult);
                },
                error: function (file, response) {
                    file.previewElement.classList.add("dz-error");
                }
            });



            //Upload School Fees PIN to the database
            $(document).on("change", "[id*=ddlEntryLevel]", function () {
                //Setting Registration number
                var SessionID = $("[id*=ddlSession]").find("option:selected").val()
                var LevelID = $("[id*=ddlEntryLevel]").find("option:selected").val()

                var Session = $("[id*=ddlSession]").find("option:selected").text()
                var Level = $("[id*=ddlEntryLevel]").find("option:selected").text()

                //Checking if excel file was selected for upload



                if (SessionID == 0) {
                    alert('Please Select the Session to continue');
                    return false;
                }

                if (LevelID == 0) {
                    alert('Please Select the Programme to continue');
                    return false;
                }


                //Working on session
                var splitSession = Session.split("-");
                var newSession = splitSession[0]

                //Working on Semester
                var splitLevel = Level.split("-");
                var newLevel = splitLevel[0]

                //Uploading School Fees Data
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "AdminUploadDepartmentalResult.aspx/GetCourse",
                    data: "{'SessionID':'" + SessionID + "','LevelID':'" + LevelID + "'}",
                    dataType: "json",
                    success: function (data) {
                        $('#Course').show();
                        $('#Search').hide();

                        for (var i = 0; i < data.d.length; i++) {
                            $('#chkboxlistCourse').append('<label> <input class="icheckbox_square-green" value="' + data.d[i].SemesterName + '" type="checkbox" id="' + data.d[i].SemesterID + '"/> <i></i> ' + data.d[i].SemesterName + ' </label>&nbsp;&nbsp;');
                        }//End For


                        //Registering Courses
                        $('input[type=checkbox]').click(function () {
                            $("input:checked").each(function () {
                                var id = $(this).attr("id");
                                var value = $(this).attr("value");
                                var SemesterID = id;
                                var SemesterName = value;
                                $(this).attr("value", "0");

                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "AdminUploadDepartmentalResult.aspx/GetCourseCode",
                                    data: "{'SessionID':'" + SessionID + "','SemesterID':'" + SemesterID + "','SemesterID':'" + SemesterID + "','LevelID':'" + LevelID + "'}",
                                    dataType: "json",
                                    success: function (data) {
                                        $('#Course').hide();
                                        $('#Search').hide();
                                        $('#CourseCode').show();

                                        for (var i = 0; i < data.d.length; i++) {
                                            $('#chkboxlistCourseCode').append('<label> <input class="icheckbox_square-green" value="' + data.d[i].CourseCode + '" type="checkbox" id="' + data.d[i].CourseCode + '"/> <i></i> ' + data.d[i].CourseCode + ' </label>&nbsp;');
                                        }//End of For




                                        //Upload School Fees PIN to the database
                                        $('#btnUploadResult').click(function () {

                                            var count = 0;
                                            var dataRowCount = 0;

                                            $("input:checked").each(function () {

                                                var myID = $(this).attr("value");
                                                var courseCode = '';
                                                courseCode = myID;

                                                count = count + 1


                                                //Checking if excel file was selected for upload
                                                if (imgNameResult == '') {
                                                    alert('Please select an excel file to continue');
                                                    return false;
                                                }

                                                if (courseCode != '0') {

                                                    dataRowCount = dataRowCount + 1

                                                    //Uploading School Fees Data
                                                    $.ajax({
                                                        type: "POST",
                                                        contentType: "application/json; charset=utf-8",
                                                        url: "AdminUploadDepartmentalResult.aspx/UploadResult",
                                                        data: "{'courseCode':'" + courseCode + "','excelUrl':'" + imgNameResult + "','Session':'" + newSession + "','Semester':'" + SemesterName + "','Level':'" + Level + "','dataRowCount':" + dataRowCount + "}",
                                                        dataType: "json",
                                                        success: function (data) {

                                                            //Declaring returning variable message
                                                            var returnMsg = data.d

                                                            if (returnMsg == "success") {
                                                                $('#Result').show();
                                                                $('#Course').hide();
                                                                $('#Search').hide();
                                                                $('#CourseCode').hide();

                                                            }


                                                        },
                                                        beforeSend: function () {
                                                            // Code to display spinner
                                                            $('#spinnerCourseCode').show();
                                                        },
                                                        complete: function () {
                                                            // Code to hide spinner.
                                                            $('#spinnerCourseCode').hide();
                                                        },
                                                        error: function (result) {
                                                            alert('Error Occurred While uploading the result, Please Contact Admin. Error Detials: ' + result);
                                                        }
                                                    });// Ajax Ends here

                                                }


                                            });//Course Code looping ends here

                                            if (count == 1) {
                                                alert('Please Check at list one course code to continue');
                                            }

                                            $('#success').show();
                                        });//Uploade Button ends here


                                    },
                                    beforeSend: function () {
                                        // Code to display spinner
                                        $('#spinnerRegister').show();
                                    },
                                    complete: function () {
                                        // Code to hide spinner.
                                        $('#spinnerRegister').hide();
                                    },
                                    error: function (result) {
                                        alert('Error Occurred While Looping through courses, Please Chat with Admin. Error Detials: ' + result);
                                    }
                                });

                            }); //Looping through course code
                        }); //Ending of search course code



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
                        alert('Error Occurred, Please Chat with Admin. Error Detials: ' + result);
                    }
                });//End Ajax


            }); //End Level Select

        });

    </script>


    <!-- Mainly scripts -->
    <script src="js/bootstrap.min.js"></script>
    <script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="js/plugins/slimscroll/jquery.slimscroll.min.js"></script>

    <!-- Custom and plugin javascript -->
    <script src="js/inspinia.js"></script>
    <script src="js/plugins/pace/pace.min.js"></script>

    <script src="js/plugins/jeditable/jquery.jeditable.js"></script>
    <script src="js/plugins/dataTables/datatables.min.js"></script>

    <!-- Page-Level Scripts -->
    <script>
        $(document).ready(function () {
            //    $('.dataTables-example').DataTable({
            //        dom: '<"html5buttons"B>lTfgitp',
            //        buttons: [
            //            { extend: 'copy' },
            //            { extend: 'csv' },
            //            { extend: 'excel', title: 'ExampleFile' },
            //            { extend: 'pdf', title: 'ExampleFile' },

            //            {
            //                extend: 'print',
            //                customize: function (win) {
            //                    $(win.document.body).addClass('white-bg');
            //                    $(win.document.body).css('font-size', '10px');

            //                    $(win.document.body).find('table')
            //                            .addClass('compact')
            //                            .css('font-size', 'inherit');
            //                }
            //            }
            //        ]

            //    });

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
