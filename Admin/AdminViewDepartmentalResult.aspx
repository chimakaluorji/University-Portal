<%@ Page Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="AdminViewDepartmentalResult.aspx.vb" Inherits="Admin_AdminViewDepartmentalResult" %>

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
            <h2>View Departmental Result</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Dashboard</a>
                </li>

                <li class="active">
                    <strong>View Departmental Result</strong>
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
                                        <h5>View Departmental Result</h5>
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
                                                  <asp:DropDownList ID="ddlEntryLevel" runat="server" AppendDataBoundItems="True" DataSourceID="odsEntryLevel" DataTextField="LevelName" DataValueField="LevelID"  CssClass="form-control">
                                                        <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                  </asp:DropDownList>
                                                  <asp:ObjectDataSource ID="odsEntryLevel" runat="server" EnableCaching="True" SelectMethod="FindAllLevels" TypeName="SessionLevelSemesterCourseDAL"></asp:ObjectDataSource>
                                                </div>
                                            </div>

                                            <div>&nbsp;</div>
                                      </div>

                                      <div id="Course" style="display:none;">
                                          <div class="form-group">
                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerRegister" >
                                                       <img src="img/loading.gif" />
                                                          Please wait, the system is loading the results ....
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

                                        <div id="Result" style="display:none;">
                                             <div class="form-group">
                                                <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerLoadingResult" >
                                                       <img src="img/loading.gif" />
                                                        Please wait, the system is loading the results ....
                                                      <img src="img/loader7.gif" />
                                                      
                                                </div>   
                                              </div>

                                            <div>&nbsp;</div>

                                             <div  class="table-responsive" id="table">
                                                                           
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
                    url: "AdminViewDepartmentalResult.aspx/GetCourse",
                    data: "{'SessionID':'" + SessionID + "','LevelID':'" + LevelID + "'}",
                    dataType: "json",
                    success: function (data) {
                        $('#Course').show();
                        $('#Search').hide();

                        for (var i = 0; i < data.d.length; i++) {
                            $('#chkboxlistCourse').append('<label> <input class="icheckbox_square-green" value="' + data.d[i].SemesterName +'" type="checkbox" id="' + data.d[i].SemesterID + '"/> <i></i> ' + data.d[i].SemesterName + ' </label>&nbsp;&nbsp;');
                        }//End For


                        //Registering Courses
                        $('input[type=checkbox]').click(function () {
                            $("input:checked").each(function () {

                                var id = $(this).attr("id");
                                var value = $(this).attr("value");
                                var SemesterID = id;
                                var SemesterName = value;
                                $(this).attr("value", "0");

                                $('#Course').hide();
                                $('#Search').hide();
                                $('#Result').show();

                                //Uploading School Fees Data
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "AdminViewDepartmentalResult.aspx/FindDepartmentalResultHeader",
                                    data: "{'Session':'" + newSession + "','Semester':'" + SemesterName + "','Level':'" + newLevel + "'}",
                                    dataType: "json",
                                    success: function (data) {

                                        var rowsData;

                                        var table = '<table class="table table-striped table-bordered table-hover dataTables-example" id="editable">';
                                        table += '<thead>';
                                        table += '<tr>';

                                        var tablehead = '';
                                        for (var i = 0; i < data.d.length; i++) {
                                            var rows2 = data.d[i].row2;
                                            var rows3 = data.d[i].row3;
                                            var rows4 = data.d[i].row4;
                                            var rows5 = data.d[i].row5;
                                            var rows6 = data.d[i].row6;
                                            var rows7 = data.d[i].row7;
                                            var rows8 = data.d[i].row8;
                                            var rows9 = data.d[i].row9;
                                            var rows10 = data.d[i].row10;
                                            var rows11 = data.d[i].row11;
                                            var rows12 = data.d[i].row12;
                                            var rows13 = data.d[i].row13;
                                            var rows14 = data.d[i].row14;
                                            var rows15 = data.d[i].row15;
                                            var rows16 = data.d[i].row16;
                                            var rows17 = data.d[i].row17;
                                            var rows18 = data.d[i].row18;
                                            var rows19 = data.d[i].row19;
                                            var rows20 = data.d[i].row20;

                                            //rowsData = [row2, row3, row4, row5];
                                            if (rows2 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th>';
                                            }
                                            if (rows3 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th>';
                                            }
                                            if (rows4 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th>';
                                            }
                                            if (rows5 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                            }
                                            if (rows6 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablehead += '<th>' + rows6 + '</th>';
                                            }
                                            if (rows7 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablehead += '<th>' + rows6 + '</th><th>' + rows7 + '</th>';
                                            }
                                            if (rows8 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablehead += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th>';
                                            }
                                            if (rows9 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablehead += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th>';
                                            }
                                            if (rows10 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablehead += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                            }

                                            if (rows11 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablehead += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablehead += '<th>' + rows11 + '</th>';
                                            }

                                            if (rows12 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablehead += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablehead += '<th>' + rows11 + '</th><th>' + rows12 + '</th>';
                                            }

                                            if (rows13 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablehead += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablehead += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th>';
                                            }

                                            if (rows14 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablehead += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablehead += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th><th>' + rows14 + '</th>';
                                            }

                                            if (rows15 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablehead += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablehead += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th><th>' + rows14 + '</th><th>' + rows15 + '</th>';
                                            }

                                            if (rows16 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablehead += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablehead += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th><th>' + rows14 + '</th><th>' + rows15 + '</th>';
                                                tablehead += '<th>' + rows16 + '</th>';
                                            }

                                            if (rows17 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablehead += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablehead += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th><th>' + rows14 + '</th><th>' + rows15 + '</th>';
                                                tablehead += '<th>' + rows16 + '</th><th>' + rows17 + '</th>';
                                            }

                                            if (rows18 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablehead += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablehead += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th><th>' + rows14 + '</th><th>' + rows15 + '</th>';
                                                tablehead += '<th>' + rows16 + '</th><th>' + rows17 + '</th><th>' + rows18 + '</th>';
                                            }

                                            if (rows19 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablehead += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablehead += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th><th>' + rows14 + '</th><th>' + rows15 + '</th>';
                                                tablehead += '<th>' + rows16 + '</th><th>' + rows17 + '</th><th>' + rows18 + '</th><th>' + rows19 + '</th>';
                                            }

                                            if (rows20 != 'Empty') {
                                                tablehead = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablehead += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablehead += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th><th>' + rows14 + '</th><th>' + rows15 + '</th>';
                                                tablehead += '<th>' + rows16 + '</th><th>' + rows17 + '</th><th>' + rows18 + '</th><th>' + rows19 + '</th><th>' + rows20 + '</th>';
                                            }
                                        }

                                        table += tablehead;
                                        table += '</tr>';
                                        table += '</thead>';
                                        table += '<tbody>';
                                        table += '<tr class="gradeX">';

                                        var tablebody = '';
                                        for (var i = 0; i < data.d.length; i++) {
                                            var rows2 = data.d[i].row2;
                                            var rows3 = data.d[i].row3;
                                            var rows4 = data.d[i].row4;
                                            var rows5 = data.d[i].row5;
                                            var rows6 = data.d[i].row6;
                                            var rows7 = data.d[i].row7;
                                            var rows8 = data.d[i].row8;
                                            var rows9 = data.d[i].row9;
                                            var rows10 = data.d[i].row10;
                                            var rows11 = data.d[i].row11;
                                            var rows12 = data.d[i].row12;
                                            var rows13 = data.d[i].row13;
                                            var rows14 = data.d[i].row14;
                                            var rows15 = data.d[i].row15;
                                            var rows16 = data.d[i].row16;
                                            var rows17 = data.d[i].row17;
                                            var rows18 = data.d[i].row18;
                                            var rows19 = data.d[i].row19;
                                            var rows20 = data.d[i].row20;


                                            if (rows2 != 'Empty') {
                                                tablebody = '<td></td>';
                                            }
                                            if (rows3 != 'Empty') {
                                                tablebody = '<td></td><td></td>';
                                            }
                                            if (rows4 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td>';
                                            }
                                            if (rows5 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td>';
                                            }
                                            if (rows6 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td><td></td>';
                                            }
                                            if (rows7 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td><td></td><td></td>';
                                            }
                                            if (rows8 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                            }
                                            if (rows9 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                            }
                                            if (rows10 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                            }
                                            if (rows11 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                            }
                                            if (rows12 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                                tablebody += '<td></td>';
                                            }
                                            if (rows13 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                                tablebody += '<td></td><td></td>';
                                            }
                                            if (rows14 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                                tablebody += '<td></td><td></td><td></td>';
                                            }
                                            if (rows15 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                                tablebody += '<td></td><td></td><td></td><td></td>';
                                            }
                                            if (rows16 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                                tablebody += '<td></td><td></td><td></td><td></td><td></td>';
                                            }
                                            if (rows17 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                                tablebody += '<td></td><td></td><td></td><td></td><td></td><td></td>';
                                            }
                                            if (rows18 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                                tablebody += '<td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                            }
                                            if (rows19 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                                tablebody += '<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                            }
                                            if (rows20 != 'Empty') {
                                                tablebody = '<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                                tablebody += '<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>';
                                            }
                                        }

                                        table += tablebody;
                                        table += '</tr>';
                                        table += '</tbody>';
                                        table += '<tfoot>';
                                        table += '<tr>';

                                        var tablefoot = '';
                                        for (var i = 0; i < data.d.length; i++) {
                                            var rows2 = data.d[i].row2;
                                            var rows3 = data.d[i].row3;
                                            var rows4 = data.d[i].row4;
                                            var rows5 = data.d[i].row5;
                                            var rows6 = data.d[i].row6;
                                            var rows7 = data.d[i].row7;
                                            var rows8 = data.d[i].row8;
                                            var rows9 = data.d[i].row9;
                                            var rows10 = data.d[i].row10;
                                            var rows11 = data.d[i].row11;
                                            var rows12 = data.d[i].row12;
                                            var rows13 = data.d[i].row13;
                                            var rows14 = data.d[i].row14;
                                            var rows15 = data.d[i].row15;
                                            var rows16 = data.d[i].row16;
                                            var rows17 = data.d[i].row17;
                                            var rows18 = data.d[i].row18;
                                            var rows19 = data.d[i].row19;
                                            var rows20 = data.d[i].row20;

                                            //rowsData = [row2, row3, row4, row5];
                                            if (rows2 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th>';
                                            }
                                            if (rows3 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th>';
                                            }
                                            if (rows4 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th>';
                                            }
                                            if (rows5 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                            }
                                            if (rows6 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablefoot += '<th>' + rows6 + '</th>';
                                            }
                                            if (rows7 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablefoot += '<th>' + rows6 + '</th><th>' + rows7 + '</th>';
                                            }
                                            if (rows8 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablefoot += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th>';
                                            }
                                            if (rows9 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablefoot += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th>';
                                            }
                                            if (rows10 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablefoot += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                            }

                                            if (rows11 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablefoot += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablefoot += '<th>' + rows11 + '</th>';
                                            }

                                            if (rows12 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablefoot += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablefoot += '<th>' + rows11 + '</th><th>' + rows12 + '</th>';
                                            }

                                            if (rows13 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablefoot += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablefoot += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th>';
                                            }

                                            if (rows14 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablefoot += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablefoot += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th><th>' + rows14 + '</th>';
                                            }

                                            if (rows15 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablefoot += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablefoot += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th><th>' + rows14 + '</th><th>' + rows15 + '</th>';
                                            }

                                            if (rows16 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablefoot += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablefoot += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th><th>' + rows14 + '</th><th>' + rows15 + '</th>';
                                                tablefoot += '<th>' + rows16 + '</th>';
                                            }

                                            if (rows17 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablefoot += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablefoot += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th><th>' + rows14 + '</th><th>' + rows15 + '</th>';
                                                tablefoot += '<th>' + rows16 + '</th><th>' + rows17 + '</th>';
                                            }

                                            if (rows18 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablefoot += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablefoot += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th><th>' + rows14 + '</th><th>' + rows15 + '</th>';
                                                tablefoot += '<th>' + rows16 + '</th><th>' + rows17 + '</th><th>' + rows18 + '</th>';
                                            }

                                            if (rows19 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablefoot += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablefoot += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th><th>' + rows14 + '</th><th>' + rows15 + '</th>';
                                                tablefoot += '<th>' + rows16 + '</th><th>' + rows17 + '</th><th>' + rows18 + '</th><th>' + rows19 + '</th>';
                                            }

                                            if (rows20 != 'Empty') {
                                                tablefoot = '<th>' + rows2 + '</th><th>' + rows3 + '</th><th>' + rows4 + '</th><th>' + rows5 + '</th>';
                                                tablefoot += '<th>' + rows6 + '</th><th>' + rows7 + '</th><th>' + rows8 + '</th><th>' + rows9 + '</th><th>' + rows10 + '</th>';
                                                tablefoot += '<th>' + rows11 + '</th><th>' + rows12 + '</th><th>' + rows13 + '</th><th>' + rows14 + '</th><th>' + rows15 + '</th>';
                                                tablefoot += '<th>' + rows16 + '</th><th>' + rows17 + '</th><th>' + rows18 + '</th><th>' + rows19 + '</th><th>' + rows20 + '</th>';
                                            }
                                        }

                                        table += tablefoot;
                                        table += '</tr>';
                                        table += '</tfoot>';
                                        table += '</table>';

                                        $('#table').append(table);


                                        //Script for pdf and excel sheet
                                        $('.dataTables-example').DataTable({
                                            dom: '<"html5buttons"B>lTfgitp',
                                            buttons: [
                                                { extend: 'copy' },
                                                { extend: 'csv' },
                                                { extend: 'excel', title: 'Students_Results' },
                                                { extend: 'pdf', title: 'Students_Results' },

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
                                        alert('Error Occurred, Please Contact Admin.');
                                    }
                                });


                                //Uploading School Fees Data
                                $.ajax({
                                    type: "POST",
                                    contentType: "application/json; charset=utf-8",
                                    url: "AdminViewDepartmentalResult.aspx/findDepartmentalResult",
                                    data: "{'Session':'" + newSession + "','Semester':'" + SemesterName + "','Level':'" + newLevel + "'}",
                                    dataType: "json",
                                    success: function (data) {

                                        var rowsData = '';

                                        for (var i = 0; i < data.d.length; i++) {
                                            var rows2 = data.d[i].row2;
                                            var rows3 = data.d[i].row3;
                                            var rows4 = data.d[i].row4;
                                            var rows5 = data.d[i].row5;
                                            var rows6 = data.d[i].row6;
                                            var rows7 = data.d[i].row7;
                                            var rows8 = data.d[i].row8;
                                            var rows9 = data.d[i].row9;
                                            var rows10 = data.d[i].row10;
                                            var rows11 = data.d[i].row11;
                                            var rows12 = data.d[i].row12;
                                            var rows13 = data.d[i].row13;
                                            var rows14 = data.d[i].row14;
                                            var rows15 = data.d[i].row15;
                                            var rows16 = data.d[i].row16;
                                            var rows17 = data.d[i].row17;
                                            var rows18 = data.d[i].row18;
                                            var rows19 = data.d[i].row19;
                                            var rows20 = data.d[i].row20;

                                            if (rows2 != 'Empty') {
                                                rowsData = [rows2];
                                            }
                                            if (rows3 != 'Empty') {
                                                rowsData = [rows2, rows3];
                                            }
                                            if (rows4 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4];
                                            }
                                            if (rows5 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5];
                                            }
                                            if (rows6 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5, rows6];
                                            }

                                            if (rows7 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5, rows6, rows7];
                                            }

                                            if (rows8 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5, rows6, rows7, rows8];
                                            }

                                            if (rows9 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5, rows6, rows7, rows8, rows9];
                                            }

                                            if (rows10 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5, rows6, rows7, rows8, rows9, rows10];
                                            }

                                            if (rows11 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5, rows6, rows7, rows8, rows9, rows10, rows11];
                                            }

                                            if (rows12 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5, rows6, rows7, rows8, rows9, rows10, rows11, rows12];
                                            }

                                            if (rows13 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5, rows6, rows7, rows8, rows9, rows10, rows11, rows12, rows13];
                                            }

                                            if (rows14 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5, rows6, rows7, rows8, rows9, rows10, rows11, rows12, rows13, rows14];
                                            }

                                            if (rows15 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5, rows6, rows7, rows8, rows9, rows10, rows11, rows12, rows13, rows14, rows15];
                                            }

                                            if (rows16 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5, rows6, rows7, rows8, rows9, rows10, rows11, rows12, rows13, rows14, rows15, rows16];
                                            }

                                            if (rows17 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5, rows6, rows7, rows8, rows9, rows10, rows11, rows12, rows13, rows14, rows15, rows16, rows17];
                                            }

                                            if (rows18 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5, rows6, rows7, rows8, rows9, rows10, rows11, rows12, rows13, rows14, rows15, rows16, rows17, rows18];
                                            }

                                            if (rows19 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5, rows6, rows7, rows8, rows9, rows10, rows11, rows12, rows13, rows14, rows15, rows16, rows17rows18, rows19];
                                            }

                                            if (rows20 != 'Empty') {
                                                rowsData = [rows2, rows3, rows4, rows5, rows6, rows7, rows8, rows9, rows10, rows11, rows12, rows13, rows14, rows15, rows16, rows17rows18, rows19, rows20];
                                            }


                                            $('#editable').dataTable().fnAddData(rowsData);

                                            //$('#editableResult').dataTable().fnAddData([data.d[i].row2, data.d[i].row3, data.d[i].row4, data.d[i].row5, data.d[i].row6, data.d[i].row7, data.d[i].row8, data.d[i].row9, data.d[i].row10, data.d[i].row11, data.d[i].row12]);
                                        }

                                        //Showing succes message
                                        $('#success').show();

                                    },
                                    beforeSend: function () {
                                        // Code to display spinner
                                        $('#spinnerLoadingResult').show();
                                    },
                                    complete: function () {
                                        // Code to hide spinner.
                                        $('#spinnerLoadingResult').hide();
                                    },
                                    error: function (result) {
                                        alert('Error Occurred, Please Contact Admin.');
                                    }
                                });


                            });
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
                        alert('Error Occurred, Please Chat with Admin.');
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
