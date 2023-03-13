<%@ Page Language="VB" MasterPageFile="~/Application/StudentMasterPage.master" AutoEventWireup="false" CodeFile="EditApplication.aspx.vb" Inherits="Application_EditApplication" %>

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
            <h2>Edit Application Form</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Edit Application Form</a>
                </li>

                <li class="active">
                    <strong>Edit Application Form</strong>
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
                        <h5>Edit Application Form</h5>
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

                    <div class="ibox-content" id="mainPage">
                        <input type="button" value="1. Bio Data" id="BioData1" class="btn btn-success-primary" style="width: 200px; text-align: left" />
                        <input type="button" value="2. Academic Program" id="BioData2" class="btn btn-next-primary" style="width: 200px; text-align: left" />
                        <input type="button" value="3. Declaration" id="BioData3" class="btn btn-next-primary" style="width: 200px; text-align: left" />
                        <input type="button" value="4. Notification" id="BioData4" class="btn btn-next-primary" style="width: 200px; text-align: left" />
                        <%--<input type="button" value="5. Upload Passport" id="BioData5" class="btn btn-next-primary" style="width:200px; text-align:left"/>--%>
                        <div class="new_step-content" id="Step1">
                            <div class="text-center m-t-md">
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Programme Applied For: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:DropDownList ID="ddlAppliedProgramme" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                            <asp:ListItem Text="Pre ND">Pre ND</asp:ListItem>
                                            <asp:ListItem Text="ND">ND</asp:ListItem>
                                            <asp:ListItem Text="Pre HND">Pre HND</asp:ListItem>
                                            <asp:ListItem Text="HND">HND</asp:ListItem>
                                        </asp:DropDownList>
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
                                        <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" placeholder="Surname" required></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Firstname: </label>
                                    <div class="col-lg-9" style="text-align: left;">
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First Name" required></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Middle Name (If Any): </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtmidleName" runat="server" CssClass="form-control" placeholder="Middle Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Maiden Name (If Married): </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtMaidenName" runat="server" CssClass="form-control" placeholder="Mothers Maiden Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Contact Address: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtHomeAddress" runat="server" CssClass="form-control" placeholder="Home Address" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Phone Number: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" placeholder="Phone Number"></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Marital Status: </label>
                                    <div class="col-lg-9">
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
                                    <div class="col-lg-9">
                                        <asp:RadioButtonList ID="rdoGender" runat="server" RepeatDirection="Horizontal" Width="150px">
                                            <asp:ListItem Selected="True">Male</asp:ListItem>
                                            <asp:ListItem>Female</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Home Town/Village: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtHomeTown" runat="server" CssClass="form-control" placeholder="Home Address" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">State:</label>
                                    <div class="col-lg-9">
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
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtNoKName" runat="server" CssClass="form-control" placeholder="Next of Kin Full Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Next of Kin Relationship: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtNoKRelationship" runat="server" CssClass="form-control" placeholder="Next of Kin Full Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Next of Kin Home Address: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtNoKHomeAddress" runat="server" CssClass="form-control" placeholder="Next of Kin Home Address"></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Next of Kin Phone Number: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtNokPhoneNumber" runat="server" CssClass="form-control" placeholder="Next of Kin Phone Number"></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                            </div>
                        </div>

                        <div class="new_step-content" id="Step2" style="display: none;">
                            <div class="text-center m-t-md">
                                <div>&nbsp;</div>
                                <%-- <label class="col-lg-2 control-label"><b>SECONDARY SCHOOLS ATTENDED</b></label>"
                                    <label class="col-lg-2 control-label"><b>FIRST SITTING</b></label>--%>
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
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtExamNumberOne" runat="server" CssClass="form-control" placeholder="Exam Number"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group" id="data_1">
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
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtSchoolOne" runat="server" CssClass="form-control" placeholder="School"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtSubject1" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade1" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>2</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject2" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade2" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>3</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject3" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade3" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>4</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject4" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade4" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>5</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject5" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade5" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>6</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject6" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade6" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>7</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject7" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade7" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>8</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject8" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade8" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>9</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject9" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade9" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
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
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtExamNumberTwo" runat="server" CssClass="form-control" placeholder="Exam Number"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group" id="data_1">
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
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtSchoolTwo" runat="server" CssClass="form-control" placeholder="School"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtSubject10" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade10" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>2</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject11" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade11" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>3</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject12" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade12" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>4</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject13" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade13" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>5</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject14" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade14" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>6</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject15" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade15" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>7</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject16" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade16" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>8</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject17" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade17" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
                                            </tr>
                                            <tr>
                                                <td>9</td>
                                                <td>
                                                    <asp:TextBox ID="txtSubject18" runat="server" CssClass="form-control" placeholder="Subject"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="txtGrade18" runat="server" CssClass="form-control" placeholder="Grade"></asp:TextBox></td>
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
                                        <div class="col-lg-9">
                                            <asp:TextBox ID="txtNameOfInstitution" runat="server" CssClass="form-control" placeholder="Name of Institution"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Department: </label>
                                        <div class="col-lg-9">
                                            <asp:TextBox ID="txtDepartment" runat="server" CssClass="form-control" placeholder="Department"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Reg. Number: </label>
                                        <div class="col-lg-9">
                                            <asp:TextBox ID="txtRegNumber" runat="server" CssClass="form-control" placeholder="Reg. Number"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Year of Admission: </label>
                                        <div class="col-lg-9">
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
                                        <div class="col-lg-9">
                                            <asp:DropDownList ID="ddlModeOfAdmission" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                                <asp:ListItem Text="Direct Entry">Direct Entry</asp:ListItem>
                                                <asp:ListItem Text="Married">Remedial</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Grade of Pass: </label>
                                        <div class="col-lg-9">
                                            <asp:TextBox ID="txtGradeOfPass" runat="server" CssClass="form-control" placeholder="Grade of Pass"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Special Field of Study: </label>
                                        <div class="col-lg-9">
                                            <asp:TextBox ID="txtFieldOfStudy" runat="server" CssClass="form-control" placeholder="Special Field of Study"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-3 control-label">Professional Certificates: </label>
                                        <div class="col-lg-9">
                                            <asp:TextBox ID="txtProfessionalCert" runat="server" CssClass="form-control" placeholder="Professional Certificates"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>


                        <div class="new_step-content" id="Step3" style="display: none;">
                            <div class="text-center m-t-md">

                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Academic Distinctions and Prizes: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtAcademicDistinctions" runat="server" CssClass="form-control" placeholder="Academic Distinctions and Prizes" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Employments since leaving college with dates: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtEmployment" runat="server" CssClass="form-control" placeholder="Employments since leaving college with dates" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Name of First Referee: </label>
                                    <div class="col-lg-10">
                                        <asp:TextBox ID="txtNameFirstReferee" runat="server" CssClass="form-control" placeholder="Name of First Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Position of First Referee: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtPositionFirstReferee" runat="server" CssClass="form-control" placeholder="Position of First Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Address of First Referee: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtAddressFirstReferee" runat="server" CssClass="form-control" placeholder="Address of First Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Name of Second Referee: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtNameSecondReferee" runat="server" CssClass="form-control" placeholder="Name of Second Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Position of Second Referee: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtPositionSecondReferee" runat="server" CssClass="form-control" placeholder="Position of Second Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Address of Second Referee: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtAddressSecondReferee" runat="server" CssClass="form-control" placeholder="Address of Second Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Name of Third Referee: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtNameThirdReferee" runat="server" CssClass="form-control" placeholder="Name of Third Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Position of Third Referee: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtPositionThirdReferee" runat="server" CssClass="form-control" placeholder="Position of Third Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                                <div>&nbsp;</div>
                                <div class="form-group">
                                    <label class="col-lg-3 control-label">Address of Third Referee: </label>
                                    <div class="col-lg-9">
                                        <asp:TextBox ID="txtAddressThirdReferee" runat="server" CssClass="form-control" placeholder="Address of Third Referee" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="new_step-content" id="Step4" style="display: none;">
                            <div class="form-group">
                                <div class="col-lg-12" id="successEdit" style="display: none;">
                                    <div class="alert alert-success">
                                        Your Application Form was successfully Edited.
                                    </div>
                                </div>

                                <div class="col-lg-12" id="dangerEdit" style="display: none;">
                                    <div class="alert alert-danger">
                                        The Application Form was NOT successfully Created.
                                    </div>
                                </div>
                            </div>
                            <div>&nbsp;</div>
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <b>YOU WILL NOT BE ABLE TO EDIT YOUR DATA AFTER YOUR APPLICATION HAVE BEEN ACCEPTED BY THE INSTITUTION</b>
                                </div>
                            </div>
                            <div>&nbsp;</div>
                            <div>&nbsp;</div>
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <b>PROTECT YOUR APPLICATION NUMBER TO AVOID AN UNAUTHORIZED USER HAVING ACCES TO IT.</b>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="new_step-content" style="background-color: white;">
                        <div style="float: right;">
                            <input type="button" value="Previous" id="btnPrevious" class="btn btn-next-primary" />
                            <input type="button" value="Next" id="btnNext" class="btn btn-success-primary" />
                            <input type="button" value="Save and Login" id="btnSave" class="btn btn-success-primary" style="display: none;" />
                            <%--<input type="button" value="Save" id="btnSave" class="btn btn-success-primary"  />--%>
                            <input type="button" value="Cancel" id="btnCancel" class="btn btn-next-primary" />
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
                url: "EditApplication.aspx/FindAllApplicationByApplicationNumber",
                data: "{'ApplicationNumber':'" + ApplicationNumber + "'}",
                dataType: "json",
                success: function (data) {

                    $("[id*=ddlAppliedProgramme]").find("option:selected").text(data.d[0].AppliedProgramme)
                    $("[id*=ddlSession]").val(data.d[0].SessionID)
                    $("[id*=ddlProgramme]").val(data.d[0].ProgrammeID)
                    $("[id*=txtSurname]").val(data.d[0].Surname)
                    $("[id*=txtFirstName]").val(data.d[0].FirstName)
                    $("[id*=txtmidleName]").val(data.d[0].MiddleName)
                    $("[id*=txtMaidenName]").val(data.d[0].MaidenName)
                    $("[id*=txtHomeAddress]").val(data.d[0].HomeAddress)
                    $("[id*=txtPhoneNumber]").val(data.d[0].PhoneNumber)
                    $("[id*=ddlMaritalStatus]").val(data.d[0].MaritalStatus)

                    $("#DoB").val(data.d[0].DoB);
                    $('#<%=rdoGender.ClientID%>').find("input[value='" + data.d[0].Gender + "']").attr("checked", "checked");

                    $("[id*=txtHomeTown]").val(data.d[0].HomeAddress)
                    $("[id*=ddlState]").val(data.d[0].StateID)

                    $("[id*=txtNoKName]").val(data.d[0].NoKName)
                    $("[id*=txtNoKHomeAddress]").val(data.d[0].NoKHomeAddress)
                    $("[id*=txtNoKRelationship]").val(data.d[0].NoKRelationship)
                    $("[id*=txtNokPhoneNumber]").val(data.d[0].NokPhoneNumber)



                    var AppliedProgramme = data.d[0].AppliedProgramme

                    if (AppliedProgramme == 'Pre HND' || AppliedProgramme == 'HND') {
                        $('#hnd').show();
                    }

                    if (AppliedProgramme == 'Pre ND' || AppliedProgramme == 'ND') {
                        $('#hnd').hide();
                    }

                    $("[id*=txtExamNumberOne]").val(data.d[0].ExamNumberOne);
                    $("[id*=txtYearOne]").val(data.d[0].YearOne);
                    $("[id*=txtSchoolOne]").val(data.d[0].SchoolOne);

                    $("[id*=txtExamNumberTwo]").val(data.d[0].ExamNumberTwo);
                    $("[id*=txtYearTwo]").val(data.d[0].YearTwo);
                    $("[id*=txtSchoolTwo]").val(data.d[0].SchoolTwo);

                    $("[id*=txtNameOfInstitution]").val(data.d[0].NameOfInstitution);
                    $("[id*=txtDepartment]").val(data.d[0].Department);
                    $("[id*=txtRegNumber]").val(data.d[0].RegNumber);
                    $("[id*=txtYearOfAdmission]").val(data.d[0].YearOfAdmission);
                    $("[id*=txtDateOfGraduation]").val(data.d[0].DateOfGraduation);
                    $("[id*=ddlModeOfAdmission]").val(data.d[0].ModeOfAdmission);
                    $("[id*=txtGradeOfPass]").val(data.d[0].GradeOfPass);
                    $("[id*=txtFieldOfStudy]").val(data.d[0].FieldOfStudy);
                    $("[id*=txtProfessionalCert]").val(data.d[0].ProfessionalCert);

                    $("[id*=txtSubject1]").val(data.d[0].Subject1);
                    $("[id*=txtGrade1]").val(data.d[0].Grade1);

                    $("[id*=txtSubject2]").val(data.d[0].Subject2);
                    $("[id*=txtGrade2]").val(data.d[0].Grade2);

                    $("[id*=txtSubject3]").val(data.d[0].Subject3);
                    $("[id*=txtGrade3]").val(data.d[0].Grade3);

                    $("[id*=txtSubject4]").val(data.d[0].Subject4);
                    $("[id*=txtGrade4]").val(data.d[0].Grade4);

                    $("[id*=txtSubject5]").val(data.d[0].Subject5);
                    $("[id*=txtGrade5]").val(data.d[0].Grade5);

                    $("[id*=txtSubject6]").val(data.d[0].Subject6);
                    $("[id*=txtGrade6]").val(data.d[0].Grade6);

                    $("[id*=txtSubject7]").val(data.d[0].Subject7);
                    $("[id*=txtGrade7]").val(data.d[0].Grade7);

                    $("[id*=txtSubject8]").val(data.d[0].Subject8);
                    $("[id*=txtGrade8]").val(data.d[0].Grade8);

                    $("[id*=txtSubject9]").val(data.d[0].Subject9);
                    $("[id*=txtGrade9]").val(data.d[0].Grade9);

                    $("[id*=txtSubject10]").val(data.d[0].Subject10);
                    $("[id*=txtGrade10]").val(data.d[0].Grade10);

                    $("[id*=txtSubject11]").val(data.d[0].Subject11);
                    $("[id*=txtGrade11]").val(data.d[0].Grade11);

                    $("[id*=txtSubject12]").val(data.d[0].Subject12);
                    $("[id*=txtGrade12]").val(data.d[0].Grade12);

                    $("[id*=txtSubject13]").val(data.d[0].Subject13);
                    $("[id*=txtGrade13]").val(data.d[0].Grade13);

                    $("[id*=txtSubject14]").val(data.d[0].Subject14);
                    $("[id*=txtGrade14]").val(data.d[0].Grade14);

                    $("[id*=txtSubject15]").val(data.d[0].Subject15);
                    $("[id*=txtGrade15]").val(data.d[0].Grade15);

                    $("[id*=txtSubject16]").val(data.d[0].Subject16);
                    $("[id*=txtGrade16]").val(data.d[0].Grade16);

                    $("[id*=txtSubject17]").val(data.d[0].Subject17);
                    $("[id*=txtGrade17]").val(data.d[0].Grade17);

                    $("[id*=txtSubject18]").val(data.d[0].Subject18);
                    $("[id*=txtGrade18]").val(data.d[0].Grade18);

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
                //firstData(ApplicationNumber)

                $('#BioData1').addClass('btn btn-success-primary');

                $('#BioData2').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                $('#BioData3').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                $('#BioData4').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');

                $('#Step1').show();
                $('#Step2').hide();
                $('#Step3').hide();
                $('#Step4').hide();

                $('#btnPrevious').addClass('btn btn-success-primary');

            })

            $('#BioData2').click(function () {
                //SecondData(ApplicationNumber)

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



                $('#BioData4').addClass('btn btn-success-primary');

                $('#BioData1').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                $('#BioData2').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                $('#BioData3').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');

                $('#Step1').hide();
                $('#Step2').hide();
                $('#Step3').hide();
                $('#Step4').show();

                $('#btnNext').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                $('#btnSave').show();
            })
        });

        var Count = 0;

        //Handling Steps
        $(function () {
            $('#btnNext').click(function () {

                //Step One
                var AppliedProgramme = $("[id*=ddlAppliedProgramme]").find("option:selected").text()
                var SessionID = $("[id*=ddlSession]").find("option:selected").val()
                var ProgrammeID = $("[id*=ddlProgramme]").find("option:selected").val()
                var Surname = $("[id*=txtSurname]").val();
                var FirstName = $("[id*=txtFirstName]").val();
                var MiddleName = $("[id*=txtmidleName]").val();
                var MaidenName = $("[id*=txtMaidenName]").val();
                var HomeAddress = $("[id*=txtHomeAddress]").val();
                var PhoneNumber = $("[id*=txtPhoneNumber]").val();
                var StateID = $("[id*=ddlState]").find("option:selected").val()
                var MaritalStatus = $("[id*=ddlMaritalStatus]").find("option:selected").text()
                var DoB = $("#DoB").val();
                var NoKName = $("[id*=txtNoKName]").val();
                var NoKRelationship = $("[id*=txtNoKRelationship]").val();
                var NoKHomeAddress = $("[id*=txtNoKHomeAddress]").val();
                var NokPhoneNumber = $("[id*=txtNokPhoneNumber]").val();


                ////Step Two 
                var ExamNumberOne = $("[id*=txtExamNumberOne]").val();
                var YearOne = $("[id*=txtYearOne]").val();
                var SchoolOne = $("[id*=txtSchoolOne]").val();

                var ExamNumberTwo = $("[id*=txtExamNumberTwo]").val();
                var YearTwo = $("[id*=txtYearTwo]").val();
                var SchoolTwo = $("[id*=txtSchoolTwo]").val();

                var NameOfInstitution = $("[id*=txtNameOfInstitution]").val();
                var Department = $("[id*=txtDepartment]").val();
                var RegNumber = $("[id*=txtRegNumber]").val();
                var YearOfAdmission = $("[id*=txtYearOfAdmission]").val();
                var DateOfGraduation = $("[id*=txtDateOfGraduation]").val();
                var ModeOfAdmission = $("[id*=ddlModeOfAdmission]").find("option:selected").text()
                var GradeOfPass = $("[id*=txtGradeOfPass]").val();
                var FieldOfStudy = $("[id*=txtFieldOfStudy]").val();
                var ProfessionalCert = $("[id*=txtProfessionalCert]").val();

                var Subject1 = $("[id*=txtSubject1]").val();
                var Grade1 = $("[id*=txtGrade1]").val();

                var Subject2 = $("[id*=txtSubject2]").val();
                var Grade2 = $("[id*=txtGrade2]").val();

                var Subject3 = $("[id*=txtSubject3]").val();
                var Grade3 = $("[id*=txtGrade3]").val();

                var Subject4 = $("[id*=txtSubject4]").val();
                var Grade4 = $("[id*=txtGrade4]").val();

                var Subject5 = $("[id*=txtSubject5]").val();
                var Grade5 = $("[id*=txtGrade5]").val();

                var Subject6 = $("[id*=txtSubject6]").val();
                var Grade6 = $("[id*=txtGrade6]").val();

                var Subject7 = $("[id*=txtSubject7]").val();
                var Grade7 = $("[id*=txtGrade7]").val();

                var Subject8 = $("[id*=txtSubject8]").val();
                var Grade8 = $("[id*=txtGrade8]").val();

                var Subject9 = $("[id*=txtSubject9]").val();
                var Grade9 = $("[id*=txtGrade9]").val();

                var Subject10 = $("[id*=txtSubject10]").val();
                var Grade10 = $("[id*=txtGrade10]").val();

                var Subject11 = $("[id*=txtSubject11]").val();
                var Grade11 = $("[id*=txtGrade11]").val();

                var Subject12 = $("[id*=txtSubject12]").val();
                var Grade12 = $("[id*=txtGrade12]").val();

                var Subject13 = $("[id*=txtSubject13]").val();
                var Grade13 = $("[id*=txtGrade13]").val();

                var Subject14 = $("[id*=txtSubject14]").val();
                var Grade14 = $("[id*=txtGrade14]").val();

                var Subject15 = $("[id*=txtSubject15]").val();
                var Grade15 = $("[id*=txtGrade15]").val();

                var Subject16 = $("[id*=txtSubject16]").val();
                var Grade16 = $("[id*=txtGrade16]").val();

                var Subject17 = $("[id*=txtSubject17]").val();
                var Grade17 = $("[id*=txtGrade17]").val();

                var Subject18 = $("[id*=txtSubject18]").val();
                var Grade18 = $("[id*=txtGrade18]").val();

                //Step Three
                var AcademicDistinctions = $("[id*=txtAcademicDistinctions]").val();
                var Employment = $("[id*=txtEmployment]").val();

                var NameFirstReferee = $("[id*=txtNameFirstReferee]").val();
                var PositionFirstReferee = $("[id*=txtPositionFirstReferee]").val();
                var AddressFirstReferee = $("[id*=txtAddressFirstReferee]").val();

                var NameSecondReferee = $("[id*=txtNameSecondReferee]").val();
                var PositionSecondReferee = $("[id*=txtPositionSecondReferee]").val();
                var AddressSecondReferee = $("[id*=txtAddressSecondReferee]").val();

                var NameThirdReferee = $("[id*=txtNameThirdReferee]").val();
                var PositionThirdReferee = $("[id*=txtPositionThirdReferee]").val();
                var AddressThirdReferee = $("[id*=txtAddressThirdReferee]").val();


                if (Count < 4) {

                    Count = Count + 1



                    if (Count == 1) {
                        //validating feilds
                        if (AppliedProgramme == '') {
                            alert('Please Select Applied Programme to Continue')
                            Count = 0
                            return false;
                        }

                        if (SessionID == 0) {
                            alert('Please Select Session to Continue')
                            Count = 0
                            return false;
                        }

                        if (ProgrammeID == 0) {
                            alert('Please Select Course to Continue')
                            Count = 0
                            return false;
                        }

                        if (Surname == '') {
                            alert('Please Fill Surname to Continue')
                            Count = 0
                            return false;
                        }

                        if (FirstName == '') {
                            alert('Please Fill First Name to Continue')
                            Count = 0
                            return false;
                        }

                        if (HomeAddress == '') {
                            alert('Please Fill Contact Address to Continue')
                            Count = 0
                            return false;
                        }

                        if (PhoneNumber == '') {
                            alert('Please Fill Phone Number to Continue')
                            Count = 0
                            return false;
                        }

                        if (StateID == 0) {
                            alert('Please Select State to Continue')
                            Count = 0
                            return false;
                        }

                        if (MaritalStatus == '') {
                            alert('Please Select Marital Status to Continue')
                            Count = 0
                            return false;
                        }


                        if (NoKName == '') {
                            alert('Please Fill Next of Kin Name to Continue')
                            Count = 0
                            return false;
                        }

                        if (NoKRelationship == '') {
                            alert('Please Fill Next of Kin Relationship to Continue')
                            Count = 0
                            return false;
                        }

                        if (NoKHomeAddress == '') {
                            alert('Please Fill Next of Kin Home Address to Continue')
                            Count = 0
                            return false;
                        }

                        if (NokPhoneNumber == '') {
                            alert('Please Fill Next of Kin Phone Number to Continue')
                            Count = 0
                            return false;
                        }




                        $('#Step1').hide();
                        $('#Step2').show();
                        $('#Step3').hide();
                        $('#Step4').hide();
                        //$('#Step5').hide();

                        //Change Previous button class BioData2
                        $('#btnPrevious').addClass('btn btn-success-primary');
                        $('#BioData1').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                        $('#BioData2').addClass('btn btn-success-primary');

                        SecondData(ApplicationNumber)

                    }


                    if (Count == 2) {
                        //validating feilds      
                        if (ExamNumberOne == '') {
                            alert('Please fill your Exam Number to Continue')
                            Count = 1
                            return false;
                        }

                        if (YearOne == '') {
                            alert('Please fill your YearOne to Continue')
                            Count = 1
                            return false;
                        }

                        if (SchoolOne == '') {
                            alert('Please fill your School to Continue')
                            Count = 1
                            return false;
                        }

                        var Subject1 = $("[id*=txtSubject1]").val();
                        var Grade1 = $("[id*=txtGrade1]").val();

                        if (Subject1 == '') {
                            alert('Please fill the First Subject to Continue')
                            Count = 1
                            return false;
                        }

                        if (Grade1 == '') {
                            alert('Please fill the First Grade to Continue')
                            Count = 1
                            return false;
                        }

                        if (Subject2 == '') {
                            alert('Please fill the Second Subject to Continue')
                            Count = 1
                            return false;
                        }

                        if (Grade2 == '') {
                            alert('Please fill the Second Grade to Continue')
                            Count = 1
                            return false;
                        }

                        if (Subject3 == '') {
                            alert('Please fill the Third Subject to Continue')
                            Count = 1
                            return false;
                        }

                        if (Grade3 == '') {
                            alert('Please fill the Third Grade to Continue')
                            Count = 1
                            return false;
                        }

                        if (Subject4 == '') {
                            alert('Please fill the Fourth Subject to Continue')
                            Count = 1
                            return false;
                        }

                        if (Grade4 == '') {
                            alert('Please fill the Fourth Grade to Continue')
                            Count = 1
                            return false;
                        }

                        if (Subject5 == '') {
                            alert('Please fill the Fifth Subject to Continue')
                            Count = 1
                            return false;
                        }

                        if (Grade5 == '') {
                            alert('Please fill the Fifth Grade to Continue')
                            Count = 1
                            return false;
                        }

                        if (Subject6 == '') {
                            alert('Please fill the Sixth Subject to Continue')
                            Count = 1
                            return false;
                        }

                        if (Grade6 == '') {
                            alert('Please fill the Sixth Grade to Continue')
                            Count = 1
                            return false;
                        }

                        if (Subject7 == '') {
                            alert('Please fill the Seventh Subject to Continue')
                            Count = 1
                            return false;
                        }

                        if (Grade7 == '') {
                            alert('Please fill the Seventh Grade to Continue')
                            Count = 1
                            return false;
                        }

                        if (Subject8 == '') {
                            alert('Please fill the Eighth Subject to Continue')
                            Count = 1
                            return false;
                        }

                        if (Grade8 == '') {
                            alert('Please fill the Eighth Grade to Continue')
                            Count = 1
                            return false;
                        }

                        if (Subject9 == '') {
                            alert('Please fill the Nineth Subject to Continue')
                            Count = 1
                            return false;
                        }

                        if (Grade9 == '') {
                            alert('Please fill the Nineth Grade to Continue')
                            Count = 1
                            return false;
                        }


                        $('#Step1').hide();
                        $('#Step2').hide();
                        $('#Step3').show();
                        $('#Step4').hide();
                        //$('#Step5').hide();

                        //Change Previous button class BioData3
                        $('#btnPrevious').addClass('btn btn-success-primary');
                        $('#BioData1').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                        $('#BioData2').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                        $('#BioData3').addClass('btn btn-success-primary');
                    }

                    if (Count == 3) {
                        //validating feilds 
                        var AcademicDistinctions = $("[id*=txtAcademicDistinctions]").val();
                        var Employment = $("[id*=txtEmployment]").val();

                        if (AcademicDistinctions == '') {
                            alert('Please fill the Name of your Next Kin to Continue')
                            Count = 1
                            return false;
                        }

                        if (Employment == '') {
                            alert('Please fill the Address of your Next Kin to Continue')
                            Count = 1
                            return false;
                        }

                        //if (LevelID == 0) {
                        //    alert('Please Select Level to Continue')
                        //    Count = 2
                        //    return false;
                        //}


                        $('#Step1').hide();
                        $('#Step2').hide();
                        $('#Step3').hide();
                        $('#Step4').show();
                        //$('#Step5').hide();

                        //Change Previous button class BioData4
                        $('#btnPrevious').addClass('btn btn-success-primary');
                        $('#BioData1').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                        $('#BioData2').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                        $('#BioData3').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                        $('#BioData4').addClass('btn btn-success-primary');

                        //
                        $('#btnNext').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                        $('#btnSave').show();
                    }

                }


            })
        });



        //Handling Pervoius Steps
        $(function () {
            $('#btnPrevious').click(function () {

                if (Count > 0) {
                    Count = Count - 1


                    if (Count == 2) {
                        $('#Step1').hide();
                        $('#Step2').hide();
                        $('#Step3').show();
                        $('#Step4').hide();
                        //$('#Step5').hide();

                        //Change Previous button class BioData3
                        $('#btnPrevious').addClass('btn btn-success-primary');
                        $('#BioData3').removeClass('btn btn-next-primary').addClass('btn btn-success-primary');
                        $('#BioData4').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                        //$('#BioData5').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');

                        //
                        $('#btnSave').hide();
                    }

                    if (Count == 1) {
                        $('#Step1').hide();
                        $('#Step2').show();
                        $('#Step3').hide();
                        $('#Step4').hide();
                        //$('#Step5').hide();

                        //Change Previous button class BioData4
                        $('#btnPrevious').addClass('btn btn-success-primary');
                        $('#BioData2').removeClass('btn btn-next-primary').addClass('btn btn-success-primary');
                        $('#BioData3').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                        $('#BioData4').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                        //$('#BioData5').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    }

                    if (Count == 0) {
                        $('#Step1').show();
                        $('#Step2').hide();
                        $('#Step3').hide();
                        $('#Step4').hide();
                        //$('#Step5').hide();

                        //Change Previous button class BioData5
                        $('#btnPrevious').addClass('btn btn-next-primary');
                        $('#BioData1').removeClass('btn btn-next-primary').addClass('btn btn-success-primary');
                        $('#BioData2').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                        $('#BioData3').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                        $('#BioData4').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                        //$('#BioData5').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');

                        //
                        $('#btnPrevious').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                        $('#btnNext').removeClass('btn btn-next-primary').addClass('btn btn-success-primary');
                    }

                }

            })
        });



        //Saving the data
        $(function () {
            $('#btnSave').click(function () {


                //Step One
                var AppliedProgramme = $("[id*=ddlAppliedProgramme]").find("option:selected").text()
                var SessionID = $("[id*=ddlSession]").find("option:selected").val()
                var ProgrammeID = $("[id*=ddlProgramme]").find("option:selected").val()
                var Surname = $("[id*=txtSurname]").val();
                var FirstName = $("[id*=txtFirstName]").val();
                var MiddleName = $("[id*=txtmidleName]").val();
                var MaidenName = $("[id*=txtMaidenName]").val();
                var HomeAddress = $("[id*=txtHomeAddress]").val();
                var PhoneNumber = $("[id*=txtPhoneNumber]").val();
                var StateID = $("[id*=ddlState]").find("option:selected").val()
                var MaritalStatus = $("[id*=ddlMaritalStatus]").find("option:selected").text()
                var NoKName = $("[id*=txtNoKName]").val();
                var NoKRelationship = $("[id*=txtNoKRelationship]").val();
                var NoKHomeAddress = $("[id*=txtNoKHomeAddress]").val();
                var NokPhoneNumber = $("[id*=txtNokPhoneNumber]").val();


                ////Step Two 
                var ExamNumberOne = $("[id*=txtExamNumberOne]").val();
                var YearOne = $("[id*=txtYearOne]").val();
                var SchoolOne = $("[id*=txtSchoolOne]").val();

                var ExamNumberTwo = $("[id*=txtExamNumberTwo]").val();
                var YearTwo = $("[id*=txtYearTwo]").val();
                var SchoolTwo = $("[id*=txtSchoolTwo]").val();

                var NameOfInstitution = $("[id*=txtNameOfInstitution]").val();
                var Department = $("[id*=txtDepartment]").val();
                var RegNumber = $("[id*=txtRegNumber]").val();
                var YearOfAdmission = $("[id*=txtYearOfAdmission]").val();
                var DateOfGraduation = $("[id*=txtDateOfGraduation]").val();
                var ModeOfAdmission = $("[id*=ddlModeOfAdmission]").find("option:selected").text()
                var GradeOfPass = $("[id*=txtGradeOfPass]").val();
                var FieldOfStudy = $("[id*=txtFieldOfStudy]").val();
                var ProfessionalCert = $("[id*=txtProfessionalCert]").val();

                var Subject1 = $("[id*=txtSubject1]").val();
                var Grade1 = $("[id*=txtGrade1]").val();

                var Subject2 = $("[id*=txtSubject2]").val();
                var Grade2 = $("[id*=txtGrade2]").val();

                var Subject3 = $("[id*=txtSubject3]").val();
                var Grade3 = $("[id*=txtGrade3]").val();

                var Subject4 = $("[id*=txtSubject4]").val();
                var Grade4 = $("[id*=txtGrade4]").val();

                var Subject5 = $("[id*=txtSubject5]").val();
                var Grade5 = $("[id*=txtGrade5]").val();

                var Subject6 = $("[id*=txtSubject6]").val();
                var Grade6 = $("[id*=txtGrade6]").val();

                var Subject7 = $("[id*=txtSubject7]").val();
                var Grade7 = $("[id*=txtGrade7]").val();

                var Subject8 = $("[id*=txtSubject8]").val();
                var Grade8 = $("[id*=txtGrade8]").val();

                var Subject9 = $("[id*=txtSubject9]").val();
                var Grade9 = $("[id*=txtGrade9]").val();

                var Subject10 = $("[id*=txtSubject10]").val();
                var Grade10 = $("[id*=txtGrade10]").val();

                var Subject11 = $("[id*=txtSubject11]").val();
                var Grade11 = $("[id*=txtGrade11]").val();

                var Subject12 = $("[id*=txtSubject12]").val();
                var Grade12 = $("[id*=txtGrade12]").val();

                var Subject13 = $("[id*=txtSubject13]").val();
                var Grade13 = $("[id*=txtGrade13]").val();

                var Subject14 = $("[id*=txtSubject14]").val();
                var Grade14 = $("[id*=txtGrade14]").val();

                var Subject15 = $("[id*=txtSubject15]").val();
                var Grade15 = $("[id*=txtGrade15]").val();

                var Subject16 = $("[id*=txtSubject16]").val();
                var Grade16 = $("[id*=txtGrade16]").val();

                var Subject17 = $("[id*=txtSubject17]").val();
                var Grade17 = $("[id*=txtGrade17]").val();

                var Subject18 = $("[id*=txtSubject18]").val();
                var Grade18 = $("[id*=txtGrade18]").val();

                //Step Three
                var AcademicDistinctions = $("[id*=txtAcademicDistinctions]").val();
                var Employment = $("[id*=txtEmployment]").val();

                var NameFirstReferee = $("[id*=txtNameFirstReferee]").val();
                var PositionFirstReferee = $("[id*=txtPositionFirstReferee]").val();
                var AddressFirstReferee = $("[id*=txtAddressFirstReferee]").val();

                var NameSecondReferee = $("[id*=txtNameSecondReferee]").val();
                var PositionSecondReferee = $("[id*=txtPositionSecondReferee]").val();
                var AddressSecondReferee = $("[id*=txtAddressSecondReferee]").val();

                var NameThirdReferee = $("[id*=txtNameThirdReferee]").val();
                var PositionThirdReferee = $("[id*=txtPositionThirdReferee]").val();
                var AddressThirdReferee = $("[id*=txtAddressThirdReferee]").val();



                var DoB = $("#DoB").val();
                var Gender = $("[id*=rdoGender]").find(":checked").val()

                var ApplicationNumber = '<%= Request.QueryString("ApNo").Trim%>';

                //Saving Student Data
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "EditApplication.aspx/InsertData",
                    data: "{'AppliedProgramme':'" + AppliedProgramme + "','SessionID':'" + SessionID + "','ProgrammeID':'" + ProgrammeID + "','Surname':'" + Surname + "',"
                            + "'FirstName':'" + FirstName + "','MiddleName':'" + MiddleName + "','MaidenName':'" + MaidenName + "','HomeAddress':'" + HomeAddress + "','PhoneNumber':'" + PhoneNumber + "',"
                            + "'StateID':'" + StateID + "','MaritalStatus':'" + MaritalStatus + "','Gender':'" + Gender + "','NoKName':'" + NoKName + "','NoKRelationship':'" + NoKRelationship + "',"
                            + "'NoKHomeAddress':'" + NoKHomeAddress + "','NokPhoneNumber':'" + NokPhoneNumber + "','ExamNumberOne':'" + ExamNumberOne + "',"
                            + "'YearOne':'" + YearOne + "','SchoolOne':'" + SchoolOne + "','ExamNumberTwo':'" + ExamNumberTwo + "','YearTwo':'" + YearTwo + "',"
                            + "'SchoolTwo':'" + SchoolTwo + "','NameOfInstitution':'" + NameOfInstitution + "','Department':'" + Department + "','RegNumber':'" + RegNumber + "',"
                            + "'DateOfGraduation':'" + DateOfGraduation + "','ModeOfAdmission':'" + ModeOfAdmission + "','GradeOfPass':'" + GradeOfPass + "','FieldOfStudy':'" + FieldOfStudy + "','ProfessionalCert':'" + ProfessionalCert + "',"
                            + "'YearOfAdmission':'" + YearOfAdmission + "','Subject1':'" + Subject1 + "','Grade1':'" + Grade1 + "','Subject2':'" + Subject2 + "','Grade2':'" + Grade2 + "',"
                            + "'Subject3':'" + Subject3 + "','Grade3':'" + Grade3 + "','Subject4':'" + Subject4 + "','Grade4':'" + Grade4 + "','Subject5':'" + Subject5 + "','Grade5':'" + Grade5 + "',"
                            + "'Subject6':'" + Subject6 + "','Grade6':'" + Grade6 + "','Subject7':'" + Subject7 + "','Grade7':'" + Grade7 + "','Subject8':'" + Subject8 + "','Grade8':'" + Grade8 + "',"
                            + "'Subject9':'" + Subject9 + "','Grade9':'" + Grade9 + "','Subject10':'" + Subject10 + "','Grade10':'" + Grade10 + "','Subject11':'" + Subject11 + "','Grade11':'" + Grade11 + "',"
                            + "'Subject12':'" + Subject12 + "','Grade12':'" + Grade12 + "','Subject13':'" + Subject13 + "','Grade13':'" + Grade13 + "','Subject14':'" + Subject14 + "','Grade14':'" + Grade14 + "',"
                            + "'Subject15':'" + Subject15 + "','Grade15':'" + Grade15 + "','Subject16':'" + Subject16 + "','Grade16':'" + Grade16 + "','Subject17':'" + Subject17 + "','Grade17':'" + Grade17 + "',"
                            + "'Subject18':'" + Subject18 + "','Grade18':'" + Grade18 + "','AcademicDistinctions':'" + AcademicDistinctions + "','Employment':'" + Employment + "','NameFirstReferee':'" + NameFirstReferee + "','PositionFirstReferee':'" + PositionFirstReferee + "',"
                            + "'AddressFirstReferee':'" + AddressFirstReferee + "','NameSecondReferee':'" + NameSecondReferee + "','PositionSecondReferee':'" + PositionSecondReferee + "','AddressSecondReferee':'" + AddressSecondReferee + "',"
                            + "'NameThirdReferee':'" + NameThirdReferee + "','PositionThirdReferee':'" + PositionThirdReferee + "','AddressThirdReferee':'" + AddressThirdReferee + "','DoB':'" + DoB + "','ApplicationNumber':'" + ApplicationNumber + "'}",
                    dataType: "json",
                    success: function (data) {

                        var check = data.d;

                        if (check != '') {
                            $('#successEdit').show();
                        } else {
                            $('#dangerEdit').show().html(check);
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
                        alert('Error occurred while saving the application, Please call 08027374466.');
                    }
                });


            })

        });



        //Cancelling the edit student profile
        $(function () {
            $('#btnCancel').click(function () {
                window.location.replace('Default.aspx');
            })
        });
    </script>

    
    <!-- Mainly scripts -->
    <script src="js/jquery-2.1.1.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="js/plugins/slimscroll/jquery.slimscroll.min.js"></script>

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

            $('#data_1 .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true
            });

            $('#data_2 .input-group.date').datepicker({
                startView: 1,
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                autoclose: true,
                format: "dd/mm/yyyy"
            });

            $('#data_3 .input-group.date').datepicker({
                startView: 2,
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                autoclose: true
            });

            $('#data_4 .input-group.date').datepicker({
                minViewMode: 1,
                keyboardNavigation: false,
                forceParse: false,
                autoclose: true,
                todayHighlight: true
            });

            $('#data_5 .input-daterange').datepicker({
                keyboardNavigation: false,
                forceParse: false,
                autoclose: true
            });

            var elem = document.querySelector('.js-switch');
            var switchery = new Switchery(elem, { color: '#1AB394' });

            var elem_2 = document.querySelector('.js-switch_2');
            var switchery_2 = new Switchery(elem_2, { color: '#ED5565' });

            var elem_3 = document.querySelector('.js-switch_3');
            var switchery_3 = new Switchery(elem_3, { color: '#1AB394' });

            $('.i-checks').iCheck({
                checkboxClass: 'icheckbox_square-green',
                radioClass: 'iradio_square-green'
            });

            $('.demo1').colorpicker();

            var divStyle = $('.back-change')[0].style;
            $('#demo_apidemo').colorpicker({
                color: divStyle.backgroundColor
            }).on('changeColor', function (ev) {
                divStyle.backgroundColor = ev.color.toHex();
            });

            $('.clockpicker').clockpicker();

            $('input[name="daterange"]').daterangepicker();

            $('#reportrange span').html(moment().subtract(29, 'days').format('MMMM D, YYYY') + ' - ' + moment().format('MMMM D, YYYY'));

            $('#reportrange').daterangepicker({
                format: 'MM/DD/YYYY',
                startDate: moment().subtract(29, 'days'),
                endDate: moment(),
                minDate: '01/01/2012',
                maxDate: '12/31/2015',
                dateLimit: { days: 60 },
                showDropdowns: true,
                showWeekNumbers: true,
                timePicker: false,
                timePickerIncrement: 1,
                timePicker12Hour: true,
                ranges: {
                    'Today': [moment(), moment()],
                    'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                    'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                    'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                    'This Month': [moment().startOf('month'), moment().endOf('month')],
                    'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                },
                opens: 'right',
                drops: 'down',
                buttonClasses: ['btn', 'btn-sm'],
                applyClass: 'btn-primary',
                cancelClass: 'btn-default',
                separator: ' to ',
                locale: {
                    applyLabel: 'Submit',
                    cancelLabel: 'Cancel',
                    fromLabel: 'From',
                    toLabel: 'To',
                    customRangeLabel: 'Custom',
                    daysOfWeek: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'],
                    monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                    firstDay: 1
                }
            }, function (start, end, label) {
                console.log(start.toISOString(), end.toISOString(), label);
                $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
            });

            $(".select2_demo_1").select2();
            $(".select2_demo_2").select2();
            $(".select2_demo_3").select2({
                placeholder: "Select a state",
                allowClear: true
            });


            $(".touchspin1").TouchSpin({
                buttondown_class: 'btn btn-white',
                buttonup_class: 'btn btn-white'
            });

            $(".touchspin2").TouchSpin({
                min: 0,
                max: 100,
                step: 0.1,
                decimals: 2,
                boostat: 5,
                maxboostedstep: 10,
                postfix: '%',
                buttondown_class: 'btn btn-white',
                buttonup_class: 'btn btn-white'
            });

            $(".touchspin3").TouchSpin({
                verticalbuttons: true,
                buttondown_class: 'btn btn-white',
                buttonup_class: 'btn btn-white'
            });


        });
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }
        }
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        }

        $("#ionrange_1").ionRangeSlider({
            min: 0,
            max: 5000,
            type: 'double',
            prefix: "$",
            maxPostfix: "+",
            prettify: false,
            hasGrid: true
        });

        $("#ionrange_2").ionRangeSlider({
            min: 0,
            max: 10,
            type: 'single',
            step: 0.1,
            postfix: " carats",
            prettify: false,
            hasGrid: true
        });

        $("#ionrange_3").ionRangeSlider({
            min: -50,
            max: 50,
            from: 0,
            postfix: "°",
            prettify: false,
            hasGrid: true
        });

        $("#ionrange_4").ionRangeSlider({
            values: [
                "January", "February", "March",
                "April", "May", "June",
                "July", "August", "September",
                "October", "November", "December"
            ],
            type: 'single',
            hasGrid: true
        });

        $("#ionrange_5").ionRangeSlider({
            min: 10000,
            max: 100000,
            step: 100,
            postfix: " km",
            from: 55000,
            hideMinMax: true,
            hideFromTo: false
        });

        $(".dial").knob();

        $("#basic_slider").noUiSlider({
            start: 40,
            behaviour: 'tap',
            connect: 'upper',
            range: {
                'min': 20,
                'max': 80
            }
        });

        $("#range_slider").noUiSlider({
            start: [40, 60],
            behaviour: 'drag',
            connect: true,
            range: {
                'min': 20,
                'max': 80
            }
        });

        $("#drag-fixed").noUiSlider({
            start: [40, 60],
            behaviour: 'drag-fixed',
            connect: true,
            range: {
                'min': 20,
                'max': 80
            }
        });


    </script>
</asp:Content>
