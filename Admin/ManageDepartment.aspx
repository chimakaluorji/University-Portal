﻿<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="ManageDepartment.aspx.vb" Inherits="Admin_ManageDepartment" %>

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
            <h2>Manage Department</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Dashboard</a>
                </li>

                <li class="active">
                    <strong>Manage Department</strong>
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
                                        <h5>Manage Department</h5>
                                        <br />
                                        <asp:Label ID="lblError" runat="server" Text="" Font-Size="15px" Font-Bold="true"></asp:Label>
                                        <div class="ibox-tools">
                                            <a class="collapse-link">
                                                <i class="fa fa-chevron-up"></i>
                                            </a>
                                            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                                <i class="fa fa-wrench"></i>
                                            </a>
                                            <ul class="dropdown-menu dropdown-user">
                                                <li><a href="#">Config option 1</a>
                                                </li>
                                                <li><a href="#">Config option 2</a>
                                                </li>
                                            </ul>
                                            <a class="close-link">
                                                <i class="fa fa-times"></i>
                                            </a>
                                        </div>
                                    </div>
                                    <div class="ibox-content">
                                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal2">
                                            Add Department
                                        </button>
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-hover dataTables-example" id="editable1">
                                                <thead>
                                                    <tr>
                                                        <th>Department(s)</th>
                                                        <th>Edit or Delete</th>
                                                    </tr>
                                                </thead>
                                                <%
                                                    Dim SSDDal As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL
                                                    Dim RetDataSet As System.Data.DataSet = New System.Data.DataSet
                        
                                                    RetDataSet = SSDDal.FindAllDepartment()
                                                %>
                                                <% For i = 0 To RetDataSet.Tables(0).Rows.Count - 1%>
                                                <tbody>
                                                    <tr class="gradeX">
                                                        <td><%= RetDataSet.Tables(0).Rows(i).Item("DeptName")%></td>
                                                        <td><a href='#myModal' data-toggle="modal" data-target="#myModal3" id='<%= RetDataSet.Tables(0).Rows(i).Item("DeptID")%>'><i class="fa fa-check text-navy"></i></a></td>

                                                    </tr>
                                                </tbody>
                                                <% Next%>

                                                <tfoot>
                                                    <tr>
                                                        <th>Department</th>
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


    <div class="modal inmodal" id="myModal2" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content animated flipInY">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Add New Department</h4>

                    <div class="sk-spinner sk-spinner-circle" id="spinner" style="display: none;">
                        <div class="sk-circle1 sk-circle"></div>
                        <div class="sk-circle2 sk-circle"></div>
                        <div class="sk-circle3 sk-circle"></div>
                        <div class="sk-circle4 sk-circle"></div>
                        <div class="sk-circle5 sk-circle"></div>
                        <div class="sk-circle6 sk-circle"></div>
                        <div class="sk-circle7 sk-circle"></div>
                        <div class="sk-circle8 sk-circle"></div>
                        <div class="sk-circle9 sk-circle"></div>
                        <div class="sk-circle10 sk-circle"></div>
                        <div class="sk-circle11 sk-circle"></div>
                        <div class="sk-circle12 sk-circle"></div>
                    </div>
                    <div>
                        <asp:Label ID="lblError1" runat="server" Text="" ForeColor="Green" Font-Size="15px" Font-Bold="true"></asp:Label>
                    </div>
                </div>


                <div class="modal-body">
                    <div class="ibox-content">
                        <div class="form-horizontal">

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Department: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control" placeholder="Department"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                    <input type="button" id="btnSave" value="Save" class="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal inmodal" id="myModal3" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content animated flipInY">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Edit Department</h4>

                    <div class="sk-spinner sk-spinner-circle" id="spinner1" style="display: none;">
                        <div class="sk-circle1 sk-circle"></div>
                        <div class="sk-circle2 sk-circle"></div>
                        <div class="sk-circle3 sk-circle"></div>
                        <div class="sk-circle4 sk-circle"></div>
                        <div class="sk-circle5 sk-circle"></div>
                        <div class="sk-circle6 sk-circle"></div>
                        <div class="sk-circle7 sk-circle"></div>
                        <div class="sk-circle8 sk-circle"></div>
                        <div class="sk-circle9 sk-circle"></div>
                        <div class="sk-circle10 sk-circle"></div>
                        <div class="sk-circle11 sk-circle"></div>
                        <div class="sk-circle12 sk-circle"></div>
                    </div>
                    <div>
                        <asp:Label ID="lblPrimaryKey" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblError2" runat="server" Text="" ForeColor="Green" Font-Size="13px" Font-Bold="true"></asp:Label>
                    </div>
                </div>


                <div class="modal-body">
                    <div class="ibox-content">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label class="col-lg-4 control-label">New Department: </label>
                                <div class="col-lg-8">
                                    <asp:TextBox ID="txtDepartment1" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                    <input type="button" id="btnEdit" value="Edit" class="btn btn-primary" />
                    <input type="button" id="btnDelete" value="Delete" class="btn btn-primary" />
                </div>


            </div>
        </div>
    </div>



    <%--New Implementation of jquery button submit--%>
    <script type="text/javascript" src="js/jquery-1.8.2.js"></script>
    <script type="text/javascript">
        //creating Semester
        $(function () {
            $('#btnSave').click(function () {
                var DeptName = $("[id*=txtDepartment]").val();

                if (DeptName != '') {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "ManageDepartment.aspx/InsertData",
                        data: "{'DeptName':'" + DeptName + "'}",
                        dataType: "json",
                        success: function (data) {
                            var obj = data.d;

                            if (obj != '') {
                                $("[id$='lblError']").html(data.d);

                                $('#editable1').dataTable().fnAddData([$("[id*=txtDepartment]").val(), ""]);
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
                            alert('The Department was NOT created successfully.');
                        }
                    });
                }
                else {
                    alert('Please fill the Department to Continue')
                    return false;
                }
            })
        });

        var essay_id;

        //Getting the primary key for deleting and updating
        $("a[data-toggle=modal]").click(function () {
            essay_id = $(this).attr('id');

            //Putting the primary in lblPrimaryKey label;
            $("[id$='lblPrimaryKey']").html(essay_id);

            //Getting session that need to be updated
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "ManageDepartment.aspx/GetDepartment",
                data: "{'PID':'" + essay_id + "'}",
                dataType: "json",
                success: function (data) {
                    var obj = data.d;

                    if (obj != '') {
                        $("[id$='txtDepartment1']").val(data.d);
                    }

                },
                error: function (result) {
                    alert('Error.');
                }
            });

        });


        //Updating Semester
        $(function () {
            $('#btnEdit').click(function () {
                var EditSemesterName = $("[id*=txtDepartment1]").val();
                var EditPID = essay_id;

                if (EditSemesterName != '') {
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "ManageDepartment.aspx/UpdateData",
                        data: "{'EDepartment':'" + EditDepartment + "','EPID':'" + EditPID + "'}",
                        dataType: "json",
                        success: function (data) {
                            var obj = data.d;

                            if (obj != '') {
                                $("[id$='lblError2']").html(data.d);

                                //$('#editable1').dataTable().fnSetColumnVis(1, false);
                                window.setTimeout(close_modal, 3000);
                                location.reload();

                            }

                        },
                        beforeSend: function () {
                            // Code to display spinner
                            $('#spinner1').show();
                        },
                        complete: function () {
                            // Code to hide spinner.
                            $('#spinner1').hide();
                        },
                        error: function (result) {
                            alert('The Department was NOT Updated successfully.');
                        }
                    });
                }
                else {
                    alert('Please fill the Department to Continue')
                    return false;
                }
            })
        });


        //Deleting Semester
        $(function () {
            $('#btnDelete').click(function () {
                var EditPID = essay_id;

                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "ManageDepartment.aspx/DeleteData",
                    data: "{'EPID':'" + EditPID + "'}",
                    dataType: "json",
                    success: function (data) {
                        var obj = data.d;

                        if (obj != '') {
                            $("[id$='lblError2']").html(data.d);

                            window.setTimeout(close_modal, 3000);
                            location.reload();

                        }

                    },
                    beforeSend: function () {
                        // Code to display spinner
                        $('#spinner1').show();
                    },
                    complete: function () {
                        // Code to hide spinner.
                        $('#spinner1').hide();
                    },
                    error: function (result) {
                        alert('The Department was NOT Deleted successfully.');
                    }
                });
            })
        });

        function close_modal() {
            $('#myModal3').hide();
        };
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


