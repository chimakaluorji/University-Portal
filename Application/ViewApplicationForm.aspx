<%@ Page Language="VB" MasterPageFile="~/Application/StudentMasterPage.master" AutoEventWireup="false" CodeFile="ViewApplicationForm.aspx.vb" Inherits="Application_ViewApplicationForm" %>

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
            <h2>View Application Form</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">View Application Form</a>
                </li>

                <li class="active">
                    <strong>View Application Form</strong>
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
                        <h5>View Application Form</h5>
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
                        <div class="alert alert-success" id="success" style="display: none;">
                        </div>
                        <div class="alert alert-danger" id="danger" style="display: none;">
                        </div>
                        <div class="col-lg-12" style="color: #F25926; font-size: 15px; display: none; text-align: center;" id="spinner">
                            <img src="img/loading.gif" />
                            Please wait, the system is process........
                                                      <img src="img/loader7.gif" />

                        </div>
                    </div>

                    <div class="ibox-content">
                        <input type="button" value="1. Bio Data" id="BioData1" class="btn btn-success-primary" style="width: 200px; text-align: left" />
                        <input type="button" value="2. Academic Program" id="BioData2" class="btn btn-next-primary" style="width: 200px; text-align: left" />
                        <input type="button" value="3. Declaration" id="BioData3" class="btn btn-next-primary" style="width: 200px; text-align: left" />
                        <input type="button" value="4. Passport and Bank Teller" id="BioData4" class="btn btn-next-primary" style="width: 200px; text-align: left" />
                        <%--<input type="button" value="5. Upload Passport" id="BioData5" class="btn btn-next-primary" style="width:200px; text-align:left"/>--%>
                        <div class="new_step-content" id="Step1">
                            <div class="text-center m-t-md">
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Programme Applied For: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:Label ID="lblAppliedProgramme" runat="server" Text="" CssClass="form-control"></asp:Label>
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
                                    <label class="col-lg-3 control-label">Course: </label>
                                    <div class="col-lg-9">
                                        <asp:DropDownList ID="ddlProgramme" runat="server" AppendDataBoundItems="True" CssClass="form-control"
                                            DataSourceID="odsProgramme" DataTextField="LevelName" DataValueField="LevelID">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsProgramme" runat="server" EnableCaching="True"
                                            SelectMethod="FindAllLevels" TypeName="SessionLevelSemesterCourseDAL"></asp:ObjectDataSource>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Surname: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:Label ID="txtSurname" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Firstname: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:Label ID="txtFirstName" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Middle Name (If Any): </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:Label ID="txtmidleName" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Maiden Name (If Married): </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:Label ID="txtMaidenName" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Contact Address: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:Label ID="txtHomeAddress" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Phone Number: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:Label ID="txtPhoneNumber" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Marital Status: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:DropDownList ID="ddlMaritalStatus" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                            <asp:ListItem Text="Single">Single</asp:ListItem>
                                            <asp:ListItem Text="Married">Married</asp:ListItem>
                                            <asp:ListItem Text="Divorced">Divorced</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group" id="data_1">
                                    <label class="col-lg-3 control-label">Date of Birth: </label>
                                    <div class="input-group date">
                                        <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                        <input type="text" class="form-control" value="01/10/1980" id="DoB">
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Sex: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:RadioButtonList ID="rdoGender" runat="server" RepeatDirection="Horizontal" Width="150px">
                                            <asp:ListItem Selected="True">Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Home Town/Village: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:Label ID="txtHomeTown" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">State:</label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:DropDownList ID="ddlState" runat="server" AppendDataBoundItems="True" DataSourceID="odsState"
                                            DataTextField="StateName" DataValueField="StateID" CssClass="form-control">
                                            <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsState" runat="server" EnableCaching="True"
                                            SelectMethod="FindAllStates" TypeName="CountryStateLGADAL"></asp:ObjectDataSource>
                                    </div>
                                </div>

                                <%--<div>&nbsp;</div>
                                                <div class="form-group">
                                                    <label class="col-lg-2 control-label">LGA: </label>
                                                    <div class="col-lg-10">
                                                        <asp:DropDownList ID="ddlLGA" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                                            <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>--%>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Next of Kin Full Name: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:Label ID="txtNoKName" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Next of Kin Relationship: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:Label ID="txtNoKRelationship" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Next of Kin Home Address: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:Label ID="txtNoKHomeAddress" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Next of Kin Phone Number: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:Label ID="txtNokPhoneNumber" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                            </div>
                        </div>

                        <div class="new_step-content" id="Step2" style="display: none;">
                            <div class="text-center m-t-md">
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label"></label>
                                    <div class="col-lg-10">
                                        <b style="float: left;">SECONDARY SCHOOLS ATTENDED</b>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="col-lg-2 control-label"></label>
                                    <div class="col-lg-10">
                                        <b style="float: left;">FIRST SITTING</b>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">Exam Number: </label>
                                    <div class="col-lg-10" style="text-align: left;">
                                        <asp:Label ID="txtExamNumberOne" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">Year: </label>
                                    <div class="col-lg-10">
                                        <div class="input-group date">
                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                            <input type="text" class="form-control" value="01/10/1980" id="txtYearOne">
                                        </div>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">School: </label>
                                    <div class="col-lg-10" style="text-align: left;">
                                        <asp:Label ID="txtSchoolOne" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>


                                <div>&nbsp;</div>
                                <div class="ibox-content">

                                    <table class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th>S/N</th>
                                                <th>SUBJECT</th>
                                                <th>GRADES</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>1</td>
                                                <td>
                                                    <asp:Label ID="txtSubject1" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade1" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2</td>
                                                <td>
                                                    <asp:Label ID="txtSubject2" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade2" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>3</td>
                                                <td>
                                                    <asp:Label ID="txtSubject3" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade3" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>4</td>
                                                <td>
                                                    <asp:Label ID="txtSubject4" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade4" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>5</td>
                                                <td>
                                                    <asp:Label ID="txtSubject5" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade5" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>6</td>
                                                <td>
                                                    <asp:Label ID="txtSubject6" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade6" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>7</td>
                                                <td>
                                                    <asp:Label ID="txtSubject7" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade7" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>8</td>
                                                <td>
                                                    <asp:Label ID="txtSubject8" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade8" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>9</td>
                                                <td>
                                                    <asp:Label ID="txtSubject9" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade9" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                </div>

                                <div>&nbsp;</div>
                                <div>&nbsp;</div>
                                <div>&nbsp;</div>

                                <div class="form-group">
                                    <label class="col-lg-2 control-label"></label>
                                    <div class="col-lg-10">
                                        <b style="float: left;">SECOND SITTING (IF ANY)</b>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">Exam Number: </label>
                                    <div class="col-lg-10" style="text-align: left;">
                                        <asp:Label ID="txtExamNumberTwo" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">Year: </label>
                                    <div class="col-lg-10">
                                        <div class="input-group date">
                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                            <input type="text" class="form-control" value="01/10/1980" id="txtYearTwo">
                                        </div>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-2 control-label">School: </label>
                                    <div class="col-lg-10" style="text-align: left;">
                                        <asp:Label ID="txtSchoolTwo" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>


                                <div>&nbsp;</div>
                                <div class="ibox-content">

                                    <table class="table table-bordered">
                                        <thead>
                                            <tr>
                                                <th>S/N</th>
                                                <th>SUBJECT</th>
                                                <th>GRADES</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>1</td>
                                                <td>
                                                    <asp:Label ID="txtSubject10" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade10" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>2</td>
                                                <td>
                                                    <asp:Label ID="txtSubject11" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade11" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>3</td>
                                                <td>
                                                    <asp:Label ID="txtSubject12" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade12" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>4</td>
                                                <td>
                                                    <asp:Label ID="txtSubject13" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade13" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>5</td>
                                                <td>
                                                    <asp:Label ID="txtSubject14" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade14" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>6</td>
                                                <td>
                                                    <asp:Label ID="txtSubject15" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade15" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>7</td>
                                                <td>
                                                    <asp:Label ID="txtSubject16" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade16" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>8</td>
                                                <td>
                                                    <asp:Label ID="txtSubject17" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade17" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>9</td>
                                                <td>
                                                    <asp:Label ID="txtSubject18" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtGrade18" runat="server" Text="" CssClass="form-control"></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                </div>

                                <div>&nbsp;</div>
                                <div>&nbsp;</div>
                                <div>&nbsp;</div>

                                <div id="hnd" style="display: none;">
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label"></label>
                                        <div class="col-lg-10">
                                            <b style="float: left;">TERTIARY INSTITUTIONS ATTENDED</b>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Name of Institution: </label>
                                        <div class="col-lg-9" style="text-align: left;">
                                            <asp:Label ID="txtNameOfInstitution" runat="server" Text="" CssClass="form-control"></asp:Label>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Department: </label>
                                        <div class="col-lg-9" style="text-align: left;">
                                            <asp:Label ID="txtDepartment" runat="server" Text="" CssClass="form-control"></asp:Label>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Reg. Number: </label>
                                        <div class="col-lg-9" style="text-align: left;">
                                            <asp:Label ID="txtRegNumber" runat="server" Text="" CssClass="form-control"></asp:Label>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Year of Admission: </label>
                                        <div class="col-lg-9" style="text-align: left;">
                                            <div class="form-group" id="data_5">
                                                <div class="input-daterange input-group" id="datepicker">
                                                    <input type="text" class="input-sm form-control" name="start" value="01/10/2000" id="txtYearOfAdmission" />
                                                    <span class="input-group-addon">Date of Graduation</span>
                                                    <input type="text" class="input-sm form-control" name="end" value="01/10/2016" id="txtDateOfGraduation" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Mode of Admission: </label>
                                        <div class="col-lg-9" style="text-align: left;">
                                            <asp:DropDownList ID="ddlModeOfAdmission" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                                <asp:ListItem Text="Direct Entry">Direct Entry</asp:ListItem>
                                                <asp:ListItem Text="Married">Remedial</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Grade of Pass: </label>
                                        <div class="col-lg-9" style="text-align: left;">
                                            <asp:Label ID="txtGradeOfPass" runat="server" Text="" CssClass="form-control"></asp:Label>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Special Field of Study: </label>
                                        <div class="col-lg-9" style="text-align: left;">
                                            <asp:Label ID="txtFieldOfStudy" runat="server" Text="" CssClass="form-control"></asp:Label>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Professional Certificates: </label>
                                        <div class="col-lg-9" style="text-align: left;">
                                            <asp:Label ID="txtProfessionalCert" runat="server" Text="" CssClass="form-control"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>


                        <div class="new_step-content" id="Step3" style="display: none;">
                            <div class="text-center m-t-md">
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Academic Distinctions and Prizes: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:TextBox ID="txtAcademicDistinctions" runat="server" CssClass="form-control" placeholder="Academic Distinctions and Prizes" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Employments since leaving college with dates: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:TextBox ID="txtEmployment" runat="server" CssClass="form-control" placeholder="Employments since leaving college with dates" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Name of First Referee: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:TextBox ID="txtNameFirstReferee" runat="server" CssClass="form-control" placeholder="Name of First Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Position of First Referee: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:TextBox ID="txtPositionFirstReferee" runat="server" CssClass="form-control" placeholder="Position of First Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Address of First Referee: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:TextBox ID="txtAddressFirstReferee" runat="server" CssClass="form-control" placeholder="Address of First Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Name of Second Referee: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:TextBox ID="txtNameSecondReferee" runat="server" CssClass="form-control" placeholder="Name of Second Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Position of Second Referee: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:TextBox ID="txtPositionSecondReferee" runat="server" CssClass="form-control" placeholder="Position of Second Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Address of Second Referee: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:TextBox ID="txtAddressSecondReferee" runat="server" CssClass="form-control" placeholder="Address of Second Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Name of Third Referee: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:TextBox ID="txtNameThirdReferee" runat="server" CssClass="form-control" placeholder="Name of Third Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Position of Third Referee: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:TextBox ID="txtPositionThirdReferee" runat="server" CssClass="form-control" placeholder="Position of Third Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Address of Third Referee: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:TextBox ID="txtAddressThirdReferee" runat="server" CssClass="form-control" placeholder="Address of Third Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="new_step-content" id="Step4" style="display: none;">
                            <div>&nbsp;</div>
                            <div>&nbsp;</div>
                            <div class="form-group">
                                <div class="col-lg-6">
                                    <asp:Image ID="PhotoUrl" runat="server" Width="250" Height="250" title="Passport" />
                                </div>
                                <div class="col-lg-6">
                                    <asp:Image ID="BankDraftUrl" runat="server" Width="450" Height="250" title="Bank Teller" />
                                </div>
                            </div>
                            <div>&nbsp;</div>
                            <div>&nbsp;</div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--New Implementation of jquery button submit--%>
    <script type="text/javascript" src="js/jquery-1.8.2.js"></script>

    <script type="text/javascript">

        //Loading State dropdownlist
        $(function () {
            //alert(check);
            var ApplicationNumber = '<%= Request.QueryString("ApNo").Trim%>';

            //Fetching Receipt
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "ViewApplicationForm.aspx/FindAllApplicationByApplicationNumber",
                data: "{'ApplicationNumber':'" + ApplicationNumber + "'}",
                dataType: "json",
                success: function (data) {

                    $("[id*=lblAppliedProgramme]").html(data.d[0].AppliedProgramme);
                    $("[id*=ddlSession]").val(data.d[0].SessionID)
                    $("[id*=ddlProgramme]").val(data.d[0].ProgrammeID)
                    $("[id*=txtSurname]").html(data.d[0].Surname)
                    $("[id*=txtFirstName]").html(data.d[0].FirstName)
                    $("[id*=txtmidleName]").html(data.d[0].MiddleName)
                    $("[id*=txtMaidenName]").html(data.d[0].MaidenName)
                    $("[id*=txtHomeAddress]").html(data.d[0].HomeAddress)
                    $("[id*=txtPhoneNumber]").html(data.d[0].PhoneNumber)
                    $("[id*=ddlMaritalStatus]").val(data.d[0].MaritalStatus)

                    $("#DoB").html(data.d[0].DoB);
                    $('#<%=rdoGender.ClientID%>').find("input[value='" + data.d[0].Gender + "']").attr("checked", "checked");

                    $("[id*=txtHomeTown]").html(data.d[0].HomeAddress)
                    $("[id*=ddlState]").val(data.d[0].StateID)

                    $("[id*=txtNoKName]").html(data.d[0].NoKName)
                    $("[id*=txtNoKHomeAddress]").html(data.d[0].NoKHomeAddress)
                    $("[id*=txtNoKRelationship]").html(data.d[0].NoKRelationship)
                    $("[id*=txtNokPhoneNumber]").html(data.d[0].NokPhoneNumber)


                    var AppliedProgramme = data.d[0].AppliedProgramme

                    if (AppliedProgramme == 'Pre HND' || AppliedProgramme == 'HND') {
                        $('#hnd').show();
                    }

                    if (AppliedProgramme == 'Pre ND' || AppliedProgramme == 'ND') {
                        $('#hnd').hide();
                    }

                    $("[id*=txtExamNumberOne]").html(data.d[0].ExamNumberOne);
                    $("[id*=txtYearOne]").val(data.d[0].YearOne);
                    $("[id*=txtSchoolOne]").html(data.d[0].SchoolOne);

                    $("[id*=txtExamNumberTwo]").html(data.d[0].ExamNumberTwo);
                    $("[id*=txtYearTwo]").val(data.d[0].YearTwo);
                    $("[id*=txtSchoolTwo]").html(data.d[0].SchoolTwo);

                    $("[id*=txtNameOfInstitution]").html(data.d[0].NameOfInstitution);
                    $("[id*=txtDepartment]").html(data.d[0].Department);
                    $("[id*=txtRegNumber]").html(data.d[0].RegNumber);
                    $("[id*=txtYearOfAdmission]").val(data.d[0].YearOfAdmission);
                    $("[id*=txtDateOfGraduation]").val(data.d[0].DateOfGraduation);
                    $("[id*=ddlModeOfAdmission]").val(data.d[0].ModeOfAdmission);
                    $("[id*=txtGradeOfPass]").html(data.d[0].GradeOfPass);
                    $("[id*=txtFieldOfStudy]").html(data.d[0].FieldOfStudy);
                    $("[id*=txtProfessionalCert]").html(data.d[0].ProfessionalCert);

                    $("[id*=txtSubject1]").html(data.d[0].Subject1);
                    $("[id*=txtGrade1]").html(data.d[0].Grade1);

                    $("[id*=txtSubject2]").html(data.d[0].Subject2);
                    $("[id*=txtGrade2]").html(data.d[0].Grade2);

                    $("[id*=txtSubject3]").html(data.d[0].Subject3);
                    $("[id*=txtGrade3]").html(data.d[0].Grade3);

                    $("[id*=txtSubject4]").html(data.d[0].Subject4);
                    $("[id*=txtGrade4]").html(data.d[0].Grade4);

                    $("[id*=txtSubject5]").html(data.d[0].Subject5);
                    $("[id*=txtGrade5]").html(data.d[0].Grade5);

                    $("[id*=txtSubject6]").html(data.d[0].Subject6);
                    $("[id*=txtGrade6]").html(data.d[0].Grade6);

                    $("[id*=txtSubject7]").html(data.d[0].Subject7);
                    $("[id*=txtGrade7]").html(data.d[0].Grade7);

                    $("[id*=txtSubject8]").html(data.d[0].Subject8);
                    $("[id*=txtGrade8]").html(data.d[0].Grade8);

                    $("[id*=txtSubject9]").html(data.d[0].Subject9);
                    $("[id*=txtGrade9]").html(data.d[0].Grade9);

                    $("[id*=txtSubject10]").html(data.d[0].Subject10);
                    $("[id*=txtGrade10]").html(data.d[0].Grade10);

                    $("[id*=txtSubject11]").html(data.d[0].Subject11);
                    $("[id*=txtGrade11]").html(data.d[0].Grade11);

                    $("[id*=txtSubject12]").html(data.d[0].Subject12);
                    $("[id*=txtGrade12]").html(data.d[0].Grade12);

                    $("[id*=txtSubject13]").html(data.d[0].Subject13);
                    $("[id*=txtGrade13]").html(data.d[0].Grade13);

                    $("[id*=txtSubject14]").html(data.d[0].Subject14);
                    $("[id*=txtGrade14]").html(data.d[0].Grade14);

                    $("[id*=txtSubject15]").html(data.d[0].Subject15);
                    $("[id*=txtGrade15]").html(data.d[0].Grade15);

                    $("[id*=txtSubject16]").html(data.d[0].Subject16);
                    $("[id*=txtGrade16]").html(data.d[0].Grade16);

                    $("[id*=txtSubject17]").html(data.d[0].Subject17);
                    $("[id*=txtGrade17]").html(data.d[0].Grade17);

                    $("[id*=txtSubject18]").html(data.d[0].Subject18);
                    $("[id*=txtGrade18]").html(data.d[0].Grade18);

                    //Step Three
                    $("[id*=txtAcademicDistinctions]").val(data.d[0].AcademicDistinctions);
                    $("[id*=txtEmployment]").val(data.d[0].Employment);

                    $("[id*=txtNameFirstReferee]").val(data.d[0].NameFirstReferee);
                    $("[id*=txtPositionFirstReferee]").val(data.d[0].PositionFirstReferee);
                    $("[id*=txtAddressFirstReferee]").val(data.d[0].AddressFirstReferee);

                    $("[id*=txtNameSecondReferee]").val(data.d[0].NameSecondReferee);
                    $("[id*=txtPositionSecondReferee]").val(data.d[0].PositionSecondReferee);
                    $("[id*=txtAddressSecondReferee]").val(data.d[0].AddressSecondReferee);

                    $("[id*=txtNameThirdReferee]").val(data.d[0].NameThirdReferee);
                    $("[id*=txtPositionThirdReferee]").val(data.d[0].PositionThirdReferee);
                    $("[id*=txtAddressThirdReferee]").val(data.d[0].AddressThirdReferee);


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


            $('#BioData1').click(function () {

                $('#BioData1').addClass('btn btn-success-primary');

                $('#BioData2').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                $('#BioData3').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                $('#BioData4').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');

                $('#Step1').show();
                $('#Step2').hide();
                $('#Step3').hide();
                $('#Step4').hide();

            })

            $('#BioData2').click(function () {


                $('#BioData2').addClass('btn btn-success-primary');

                $('#BioData1').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                $('#BioData3').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                $('#BioData4').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');

                $('#Step1').hide();
                $('#Step2').show();
                $('#Step3').hide();
                $('#Step4').hide();
            })


            $('#BioData3').click(function () {



                $('#BioData3').addClass('btn btn-success-primary');

                $('#BioData1').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                $('#BioData2').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                $('#BioData4').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');

                $('#Step1').hide();
                $('#Step2').hide();
                $('#Step3').show();
                $('#Step4').hide();
            })


            $('#BioData4').click(function () {


                //Fetching Receipt
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "ViewApplicationForm.aspx/FindAllApplicationByApplicationNumber",
                    data: "{'ApplicationNumber':'" + ApplicationNumber + "'}",
                    dataType: "json",
                    success: function (data) {

                        var pUrl = data.d[0].PhotoUrl
                        var pUrlSplit = pUrl.split("~")
                        var PhotoUrl = ".." + pUrlSplit[1]

                        var bUrl = data.d[0].BankDraftUrl
                        var bUrlSplit = bUrl.split("~")
                        var BankDraftUrl = ".." + bUrlSplit[1]


                        $('#<%=PhotoUrl.ClientID%>').attr('src', PhotoUrl);
                        $('#<%=BankDraftUrl.ClientID%>').attr('src', BankDraftUrl);

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

                $('#BioData4').addClass('btn btn-success-primary');

                $('#BioData1').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                $('#BioData2').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                $('#BioData3').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');

                $('#Step1').hide();
                $('#Step2').hide();
                $('#Step3').hide();
                $('#Step4').show();
            })
        });
    </script>
</asp:Content>
