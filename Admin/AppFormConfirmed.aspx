<%@ Page Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="AppFormConfirmed.aspx.vb" Inherits="Admin_AppFormConfirmed" %>

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
            <h2>Manage Application Form</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Dashboard</a>
                </li>

                <li class="active">
                    <strong>Manage Application Form</strong>
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
                                        <h5>Manage Application Form</h5>

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
                                        <div class="form-horizontal">
                                            <div class="form-group">
                                                <div class="col-lg-12" style="color: #F25926; font-size: 15px; display: none; text-align: center;" id="spinner">
                                                    <img src="img/loading.gif" />
                                                    Please wait, the system is process........
                                                      <img src="img/loader7.gif" />

                                                </div>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div class="form-group">
                                                <label class="col-lg-3 control-label">Session:</label>
                                                <div class="col-lg-9">
                                                    <asp:DropDownList ID="ddlSession" runat="server" AppendDataBoundItems="True" CssClass="form-control"
                                                        DataSourceID="OdsSession" DataTextField="SessionName" DataValueField="SessionID">
                                                    </asp:DropDownList>
                                                    <asp:ObjectDataSource ID="OdsSession" runat="server" EnableCaching="True"
                                                        SelectMethod="FindAllSessions" TypeName="SessionLevelSemesterCourseDAL"></asp:ObjectDataSource>
                                                </div>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div class="form-group">
                                                <label class="col-lg-3 control-label">Application Confirmed?: </label>
                                                <div class="col-lg-9" style="text-align: left;">
                                                    <asp:DropDownList ID="ddlConfirmed" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                                        <asp:ListItem Text="NO">NO</asp:ListItem>
                                                        <asp:ListItem Text="YES">YES</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div class="form-group">
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
    </div>


    <script type="text/javascript" src="js/jquery-1.8.2.js"></script>

    <script type="text/javascript">
        $(function () {


            //Form Load
            var SessionID = $("[id*=ddlSession]").find("option:selected").val()
            var Confirmed = $("[id*=ddlConfirmed]").find("option:selected").text()

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "AppFormConfirmed.aspx/FindAppFormConfirmedBySessionID",
                data: "{'SessionID':'" + SessionID + "','Confirmed':'" + Confirmed + "'}",
                dataType: "json",
                success: function (data) {

                    $('#table').empty();

                    var table = '<table class="table table-striped table-bordered table-hover dataTables-example" id="editable">';
                    table += '<thead>';
                    table += '<tr>';
                    table += '<th>Application Number</th><th>Surname</th><th>FirstName</th><th>Programme</th><th>Confirmed</th><th>View Application Form Details</th>';
                    table += '</tr>';
                    table += '</thead>';
                    table += '<tbody>';
                    table += '<tr class="gradeX">';
                    table += '<td>' + data.d[0].ApplicationNumber + '</td><td>' + data.d[0].Surname + '</td><td>' + data.d[0].FirstName + '</td><td>' + data.d[0].Programme + '</td><td>' + data.d[0].Confirmed + '</td><td><a href="AppFormDetails.aspx?Username=<%=Request.QueryString("Username")%>&ApNo=' + data.d[0].ApplicationNumber + '">Manage Application <i class="fa fa-check text-navy"></i></a></td>';
                    table += '</tr>';
                    table += '</tbody>';
                    table += '<tfoot>';
                    table += '<tr>';
                    table += '<th>Application Number</th><th>Surname</th><th>FirstName</th><th>Programme</th><th>Confirmed</th><th>View Application Form Details</th>';
                    table += '</tr>';
                    table += '</tfoot>';
                    table += '</table>';

                    $('#table').append(table);


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
                    alert('The Department was NOT created successfully.');
                }
            });


            $(document).on("change", "[id*=ddlConfirmed]", function () {


                //Form Load
                var SessionID = $("[id*=ddlSession]").find("option:selected").val()
                var Confirmed = $("[id*=ddlConfirmed]").find("option:selected").text()

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "AppFormConfirmed.aspx/FindAppFormConfirmedBySessionID",
                    data: "{'SessionID':'" + SessionID + "','Confirmed':'" + Confirmed + "'}",
                    dataType: "json",
                    success: function (data) {

                        $('#table').empty();

                        var table = '<table class="table table-striped table-bordered table-hover dataTables-example" id="editable">';
                        table += '<thead>';
                        table += '<tr>';
                        table += '<th>Application Number</th><th>Surname</th><th>FirstName</th><th>Programme</th><th>Confirmed</th><th>View Application Form Details</th>';
                        table += '</tr>';
                        table += '</thead>';
                        table += '<tbody>';
                        table += '<tr class="gradeX">';
                        table += '<td>' + data.d[0].ApplicationNumber + '</td><td>' + data.d[0].Surname + '</td><td>' + data.d[0].FirstName + '</td><td>' + data.d[0].Programme + '</td><td>' + data.d[0].Confirmed + '</td><td><a href="AppFormDetails.aspx?Username=<%=Request.QueryString("Username")%>&ApNo=' + data.d[0].ApplicationNumber + '">Manage Application <i class="fa fa-check text-navy"></i></a></td>';
                        table += '</tr>';
                        table += '</tbody>';
                        table += '<tfoot>';
                        table += '<tr>';
                        table += '<th>Application Number</th><th>Surname</th><th>FirstName</th><th>Programme</th><th>Confirmed</th><th>View Application Form Details</th>';
                        table += '</tr>';
                        table += '</tfoot>';
                        table += '</table>';

                        $('#table').append(table);


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
                        alert('The Department was NOT created successfully.');
                    }
                });

            });


            $(document).on("change", "[id*=ddlSession]", function () {
                //Form Load
                var SessionID = $("[id*=ddlSession]").find("option:selected").val()
                var Confirmed = $("[id*=ddlConfirmed]").find("option:selected").text()

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "AppFormConfirmed.aspx/FindAppFormConfirmedBySessionID",
                    data: "{'SessionID':'" + SessionID + "','Confirmed':'" + Confirmed + "'}",
                    dataType: "json",
                    success: function (data) {

                        $('#table').empty();

                        var table = '<table class="table table-striped table-bordered table-hover dataTables-example" id="editable">';
                        table += '<thead>';
                        table += '<tr>';
                        table += '<th>Application Number</th><th>Surname</th><th>FirstName</th><th>Programme</th><th>Confirmed</th><th>View Application Form Details</th>';
                        table += '</tr>';
                        table += '</thead>';
                        table += '<tbody>';
                        table += '<tr class="gradeX">';
                        table += '<td>' + data.d[0].ApplicationNumber + '</td><td>' + data.d[0].Surname + '</td><td>' + data.d[0].FirstName + '</td><td>' + data.d[0].Programme + '</td><td>' + data.d[0].Confirmed + '</td><td><a href="AppFormDetails.aspx?Username=<%=Request.QueryString("Username")%>&ApNo=' + data.d[0].ApplicationNumber + '">Manage Application <i class="fa fa-check text-navy"></i></a></td>';
                        table += '</tr>';
                        table += '</tbody>';
                        table += '<tfoot>';
                        table += '<tr>';
                        table += '<th>Application Number</th><th>Surname</th><th>FirstName</th><th>Programme</th><th>Confirmed</th><th>View Application Form Details</th>';
                        table += '</tr>';
                        table += '</tfoot>';
                        table += '</table>';

                        $('#table').append(table);


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
                        alert('The Department was NOT created successfully.');
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
