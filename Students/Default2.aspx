<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default2.aspx.vb" Inherits="Students_Default2" %>

<!DOCTYPE html>
<html>

<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>INSPINIA | Wizards</title>

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
     
     <style>
        .wizard > .content > .body position: relative;
        }
    </style>

</head>

<body>
<form runat="server" id="form1" data-toggle="validator" role="form">
    <div id="wrapper">
        <nav class="navbar-default navbar-static-side" role="navigation">
                <div class="sidebar-collapse">
                    <ul class="nav metismenu" id="side-menu">
                        <li class="nav-header">
                            <div class="dropdown profile-element">
                                <span>
                                    <asp:Image ID="ImgStudent" runat="server" class="img-circle" />
                                </span>
                                <a data-toggle="dropdown" class="dropdown-toggle" href="#">
                                   <%-- <span class="clear"><span class="block m-t-xs"><strong class="font-bold"><%=StudentUsername%></strong>
                                    </span><span class="text-muted text-xs block"><%=RegNumber%><b class="caret"></b></span></span></a>--%>
                                <ul class="dropdown-menu animated fadeInRight m-t-xs">
                                    <li><a href="profile.html">Profile</a></li>
                                    <li><a href="mailbox.html">Mailbox</a></li>
                                    <li class="divider"></li>
                                    <li><a href="login.html">Logout</a></li>
                                </ul>
                            </div>
                            <div class="logo-element">
                                SHT
                            </div>
                        </li>
                        <li>
                            <a href="Home.aspx?Username=<%=Request.QueryString("Username")%>""><i class="fa fa-th-large"></i><span class="nav-label">Dashboards</span></a>
                        </li>
                        <li>
                            <a href="StudentResult.aspx?Username=<%=Request.QueryString("Username")%>""><i class="fa fa-diamond"></i><span class="nav-label">Check Result</span></a>
                        </li>
                        <li>
                            <a href="StudentFeesPayment.aspx?Username=<%=Request.QueryString("Username")%>""><i class="fa fa-pie-chart"></i><span class="nav-label">Pay School Fees</span>  </a>
                        </li>
                        <li>
                            <a href="#"><i class="fa fa-bar-chart-o"></i><span class="nav-label">Register Courses</span><span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level collapse">
                                <li><a href="graph_flot.html">Register Courses</a></li>
                                <li><a href="graph_morris.html">Add Course</a></li>
                                <li><a href="graph_rickshaw.html">View Courses</a></li>
                                <li><a href="graph_chartjs.html">Remove Courses</a></li>
                                <li><a href="graph_chartist.html">Delete Courses</a></li>
                            </ul>
                        </li>
                        <li>
                            <a href="mailbox.html"><i class="fa fa-envelope"></i><span class="nav-label">Mailbox </span><span class="label label-warning pull-right">16/24</span></a>
                            <ul class="nav nav-second-level collapse">
                                <li><a href="mailbox.html">Inbox</a></li>
                                <li><a href="mail_detail.html">Email view</a></li>
                                <li><a href="mail_compose.html">Compose email</a></li>
                                <li><a href="email_template.html">Email templates</a></li>
                            </ul>
                        </li>

                        <li>
                            <a href="layouts.html"><i class="fa fa-diamond"></i><span class="nav-label">Print Fees Receipt</span></a>
                        </li>
                        <li>
                            <a href="metrics.html"><i class="fa fa-pie-chart"></i><span class="nav-label">Print Student Profile</span>  </a>
                        </li>
                        <li>
                            <a href="layouts.html"><i class="fa fa-diamond"></i><span class="nav-label">Edit Phone Number</span></a>
                        </li>
                        <li>
                            <a href="metrics.html"><i class="fa fa-pie-chart"></i><span class="nav-label">Change Password</span>  </a>
                        </li>

                    </ul>

                </div>
            </nav>

        <div id="page-wrapper" class="gray-bg">
            <div class="row border-bottom">
                    <nav class="navbar navbar-static-top" role="navigation" style="margin-bottom: 0; background-color: #283847;">
                        <div class="navbar-header">
                            <a class="navbar-minimalize minimalize-styl-2 btn btn-primary " href="#"><i class="fa fa-bars"></i></a>

                        </div>
                        <ul class="nav navbar-top-links navbar-right">
                            <li>
                                <strong style="color: White; font-size: 15px;">SCHOOL OF HEALTH TECHNOLOGY, EZZANGBO</strong>
                                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </li>

                            <li>
                                <asp:LinkButton ID="BtnLogout" runat="server">
                                    <i class="fa fa-sign-out"></i>
                                    Log out&nbsp;&nbsp;&nbsp;
                                    <i class="fa fa-tasks"></i></asp:LinkButton>
                            </li>
                        </ul>

                    </nav>
                </div>
            
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Create Student Profile</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="index.html">Home</a>
                </li>
                <li class="active">
                    <strong>Student Data</strong>
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
                        <h5>Student Profile Creation</h5>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblErroSuccess" runat="server" Text="" Font-Bold="true" Font-Size="15px" ForeColor="Green"></asp:Label>
                        <asp:Label ID="lblPhotoUrl" runat="server" Text=""></asp:Label>
                        <asp:Label ID="lblError1" runat="server" Text=""></asp:Label>
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
                        <%--<div id="wizard">--%>
                            <%--<h1>Bio Data  </h1>--%> 
                            <input type="button" value="1. Bio Data" id="BioData1" class="btn btn-success-primary" style="width:200px; text-align:left"/>
                            <input type="button" value="2. Contact" id="BioData2" class="btn btn-next-primary" style="width:200px; text-align:left"/>
                            <input type="button" value="3. Academic Program" id="BioData3" class="btn btn-next-primary" style="width:200px; text-align:left"/>
                            <input type="button" value="4. Academic History" id="BioData4" class="btn btn-next-primary" style="width:200px; text-align:left"/>
                            <input type="button" value="5. Upload Passport" id="BioData5" class="btn btn-next-primary" style="width:200px; text-align:left"/>
                            <div class="new_step-content" id="Step1">
                                <div class="text-center m-t-md">
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <div class="col-lg-12" style=" color:#18A689; font-size:15px; display: none;" id="spinnerSave">
                                           <div class="sk-spinner sk-spinner-circle">
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
                                                   Saving Student Profile.......
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Registration No: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtRegNumber" runat="server" CssClass="form-control"  Text="20161230001" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Surname: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" Text="Kaluorji" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Firstname: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control" Text="Chima" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Midle Name: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtmidleName" runat="server" CssClass="form-control" placeholder="Middle Name" required></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Mothers Maiden Name: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtMotherMaidenName" runat="server" CssClass="form-control" placeholder="Mothers Maiden Name" required=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                     <div class="form-group" id="data_1">
                                        <label class="col-lg-2 control-label">Date of Birth: </label>
                                        <div class="input-group date">
                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span><input type="text" class="form-control" value="01/10/1980" id="DoB">
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Sex: </label>
                                        <div class="col-lg-10">
                                            <asp:RadioButtonList ID="rdoGender" runat="server" RepeatDirection="Horizontal" Width="100px">
                                                  <asp:ListItem Selected="True">Male</asp:ListItem>
                                                  <asp:ListItem>Female</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <div class="col-lg-12" style=" color:#18A689; font-size:15px; display: none;" id="spinner">
                                           <div class="sk-spinner sk-spinner-circle">
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
                                                   Loading LGA.....
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">State:</label>
                                        <div class="col-lg-10">
                                             <asp:DropDownList ID="ddlState" runat="server" AppendDataBoundItems="True" DataSourceID="odsState"
                                                            DataTextField="StateName" DataValueField="StateID" CssClass="form-control">
                                                          <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                      </asp:DropDownList>
                                                      <asp:ObjectDataSource ID="odsState" runat="server" EnableCaching="True"
                                                           SelectMethod="FindAllStates" TypeName="CountryStateLGADAL">
                                                      </asp:ObjectDataSource>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">LGA: </label>
                                        <div class="col-lg-10">
                                             <asp:DropDownList ID="ddlLGA" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                                          <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                      </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                </div>
                            </div>

                            <div class="new_step-content" id="Step2" style="display:none;">
                                <div class="text-center m-t-md">
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Home Address: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtHomeAddress" runat="server" CssClass="form-control" placeholder="Home Address" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Phone Number: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" placeholder="Phone Number"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Email Address: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control" placeholder="Email Address"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Next of Kin Full Name: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtNoKName" runat="server" CssClass="form-control" placeholder="Next of Kin Full Name"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Next of Kin Home Address: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtNoKHomeAddress" runat="server" CssClass="form-control" placeholder="Next of Kin Home Address"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Next of Kin Phone Number: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtNokPhoneNumber" runat="server" CssClass="form-control" placeholder="Next of Kin Phone Number"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                </div>
                            </div>
                               
                            <div class="new_step-content" id="Step3" style="display:none;">
                                <div class="text-center m-t-md">
                                    <div class="form-group">
                                         <div class="col-lg-12" style=" color:#18A689; font-size:15px; display: none;" id="spinner1">
                                           <div class="sk-spinner sk-spinner-circle">
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
                                                   Loading Programme ........
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Session:</label>
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
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Semester:</label>
                                        <div class="col-lg-10">
                                             <asp:DropDownList ID="ddlSemester" AppendDataBoundItems="true" runat="server" DataSourceID="odsSemester"
                                                         DataTextField="SemesterName" DataValueField="SemesterID" CssClass="form-control">
                                                        <asp:ListItem>--Please Select--</asp:ListItem>
                                                     </asp:DropDownList>
                                                     <asp:ObjectDataSource ID="odsSemester" runat="server" SelectMethod="FindAllSemesters"
                                                          TypeName="SessionSemesterDepartmentDAL" CacheDuration="Infinite">
                                                     </asp:ObjectDataSource>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Department:</label>
                                        <div class="col-lg-10">
                                             <asp:DropDownList ID="ddlDepartment" runat="server" AppendDataBoundItems="True" DataSourceID="odsDepartment"
                                                            DataTextField="DeptName" DataValueField="DeptID" CssClass="form-control">
                                                          <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                      </asp:DropDownList>
                                                      <asp:ObjectDataSource ID="odsDepartment" runat="server" EnableCaching="True"
                                                           SelectMethod="FindAllDepartment" TypeName="SessionSemesterDepartmentDAL">
                                                      </asp:ObjectDataSource>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Programme: </label>
                                        <div class="col-lg-10">
                                             <asp:DropDownList ID="ddlProgramme" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                                          <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                      </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Level:</label>
                                        <div class="col-lg-10">
                                             <asp:DropDownList ID="ddlLevel" runat="server" AppendDataBoundItems="True" DataSourceID="odsLevel"
                                                            DataTextField="LevelName" DataValueField="LevelID" CssClass="form-control">
                                                          <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                      </asp:DropDownList>
                                                      <asp:ObjectDataSource ID="odsLevel" runat="server" EnableCaching="True"
                                                           SelectMethod="FindAllLevel" TypeName="SessionSemesterDepartmentDAL">
                                                      </asp:ObjectDataSource>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                </div>
                            </div>

                            <div class="new_step-content" id="Step4" style="display:none;">
                                <div class="text-center m-t-md">
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Last Primary School Attended: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtPs" runat="server" CssClass="form-control" placeholder="Last Primary School Attended" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div> 
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Select Duration:</label>
                                        <div class="col-lg-10">
                                              <div class="form-group" id="data_5">
                                                    <div class="input-daterange input-group" id="datepicker">
                                                        <input type="text" class="input-sm form-control" name="start" value="01/10/1980" id="DPsFrom"/>
                                                        <span class="input-group-addon">to</span>
                                                        <input type="text" class="input-sm form-control" name="end" value="01/10/2010" id="DPsTo"/>
                                                    </div>
                                                </div>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Last Secondary School Attended: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtSs" runat="server" CssClass="form-control" placeholder="Last Secondary School Attended" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Select Duration:</label>
                                        <div class="col-lg-10">
                                              <div class="form-group" id="data_5">
                                                    <div class="input-daterange input-group" id="datepicker">
                                                        <input type="text" class="input-sm form-control" name="start" value="01/10/1980" id="DSsFrom"/>
                                                        <span class="input-group-addon">to</span>
                                                        <input type="text" class="input-sm form-control" name="end" value="01/10/2010" id="DSsTo"/>
                                                    </div>
                                                </div>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                </div>
                            </div>

                            <div class="new_step-content" id="Step5" style="display:none;">
                                <div class="text-center m-t-md">

                                    <div class="panel panel-success" menuitemname="Client Shortcuts">
                                        <div class="panel-heading">
                                            <h3 class="panel-title"><i class="fa fa-bookmark"></i>&nbsp;Image Capturing</h3>
                                        </div>
                                        <div>&nbsp;</div>
                                        <div style="padding: 0 10px 0 10px;">
                                            <div class="fileinput fileinput-new" data-provides="fileinput">
                                                <div class="fileinput-preview thumbnail" data-trigger="fileinput" style="width: 200px; height: 150px;"></div>
                                                <div>
                                                    <span class="btn btn-success btn-file"><span class="fileinput-new">Select Student Passport</span>
                                                        <span class="fileinput-exists">Change</span>
                                                        <asp:FileUpload ID="fileupload1" runat="server" required /></span>
                                                    <a href="#" class="btn btn-default fileinput-exists" data-dismiss="fileinput">Remove</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                     
                      <div style="float:right;">
                            <input type="button" value="Previous" id="btnPrevious" class="btn btn-next-primary"/>
                            <input type="button" value="Next" id="btnNext" class="btn btn-success-primary"/>
                            <input type="button" value="Save" id="btnSave" class="btn btn-success-primary" style="display:none;"/>
                            <%--<input type="button" value="Save" id="btnSave" class="btn btn-success-primary"/>--%>
                            <input type="button" value="Cancel" id="btnCancel" class="btn btn-next-primary"/>

                         
                      </div>
                    </div>
                    
                </div>
            </div>
        </div>
    </div>

            <div class="footer">
                    <div class="pull-right">
                        All rights reserved.
                    </div>
                    <div>
                        <strong>SHT Ezzamgbo</strong> &copy; <%=Today.Year%>
                    </div>
                </div>

        </div>

         <div>
                   
                </div>
    </div>

</form>


<%--New Implementation of jquery button submit--%>
<script type="text/javascript" src="js/jquery-1.8.2.js"></script>
<script type="text/javascript">
    
    //Loading State dropdownlist
    $(function () {
        $(document).on("change", "[id*=ddlState]", function () {
            //alert($("[id*=ddlState]").find("option:selected").text());
            var StateID = $("[id*=ddlState]").find("option:selected").val()

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Default2.aspx/GetLGA",
                data: "{'EStateID':'" + StateID + "'}",
                dataType: "json",
                success: function (data) {

                    var ddlLGA = $("[id*=ddlLGA]");
                    ddlLGA.empty().append('<option selected="selected" value="0">--Please select--</option>');
                    $.each(data.d, function () {
                        ddlLGA.append($("<option></option>").val(this['Value']).html(this['Text']));
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
                    alert('Error Occured.');
                }
            });

        });
    });


    //Loading Department dropdownlist
    $(function () {
        $(document).on("change", "[id*=ddlDepartment]", function () {
            //alert($("[id*=ddlState]").find("option:selected").text());
            var DepartmentID = $("[id*=ddlDepartment]").find("option:selected").val()

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Default2.aspx/GetProgramme",
                data: "{'EDepartmentID':'" + DepartmentID + "'}",
                dataType: "json",
                success: function (data) {

                    var ddlProgramme = $("[id*=ddlProgramme]");
                    ddlProgramme.empty().append('<option selected="selected" value="0">--Please select--</option>');
                    $.each(data.d, function () {
                        ddlProgramme.append($("<option></option>").val(this['Value']).html(this['Text']));
                    });

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
                    alert('Error Occured.');
                }
            });

        });
    });


    var Count = 0;

    //Handling Steps
    $(function () {
        $('#btnNext').click(function () {
            //Step One
            var midleName = $("[id*=txtmidleName]").val();
            var MotherMaidenName = $("[id*=txtMotherMaidenName]").val();
            var StateID = $("[id*=ddlState]").find("option:selected").val()
            var LGAID = $("[id*=ddlLGA]").find("option:selected").val()

            //Step Two 
            var HomeAddress = $("[id*=txtHomeAddress]").val();
            var PhoneNumber = $("[id*=txtPhoneNumber]").val();
            var EmailAddress = $("[id*=txtEmailAddress]").val();
            var NoKName = $("[id*=txtNoKName]").val();
            var NoKHomeAddress = $("[id*=txtNoKHomeAddress]").val();
            var NokPhoneNumber = $("[id*=txtNokPhoneNumber]").val();

            //Step Three
            var SessionID = $("[id*=ddlSession]").find("option:selected").val()
            var SemesterID = $("[id*=ddlSemester]").find("option:selected").val()
            var DepartmentID = $("[id*=ddlDepartment]").find("option:selected").val()
            var ProgrammeID = $("[id*=ddlProgramme]").find("option:selected").val()
            var LevelID = $("[id*=ddlLevel]").find("option:selected").val()

            //Step Four
            var Ps = $("[id*=txtPs]").val();
            var Ss = $("[id*=txtSs]").val();


            if (Count < 4) {

                Count = Count + 1

                if (Count == 1) {
                    //validating feilds
                    if (midleName == '') {
                        alert('Please fill the Midlde Name to Continue')
                        Count = 0
                        return false;
                    }

                    if (MotherMaidenName == '') {
                        alert('Please fill the Mother"s Maiden Name to Continue')
                        Count = 0
                        return false;
                    }

                    if (StateID == 0) {
                        alert('Please Select State to Continue')
                        Count = 0
                        return false;
                    }

                    if (LGAID == 0) {
                        alert('Please Select LGA to Continue')
                        Count = 0
                        return false;
                    }

                    
                    $('#Step1').hide();
                    $('#Step2').show();
                    $('#Step3').hide();
                    $('#Step4').hide();
                    $('#Step5').hide();

                    //Change Previous button class BioData2
                    $('#btnPrevious').addClass('btn btn-success-primary');
                    $('#BioData1').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData2').addClass('btn btn-success-primary');

                }

                if (Count == 2) {
                    //validating feilds      
                    if (HomeAddress == '') {
                        alert('Please fill your Home Address to Continue')
                        Count = 1
                        return false;
                    }

                    if (PhoneNumber == '') {
                        alert('Please fill your Phone Number to Continue')
                        Count = 1
                        return false;
                    }

                    if (EmailAddress == '') {
                        alert('Please fill your Email Address to Continue')
                        Count = 1
                        return false;
                    }

                    if (NoKName == '') {
                        alert('Please fill the Name of your Next Kin to Continue')
                        Count = 1
                        return false;
                    }

                    if (NoKHomeAddress == '') {
                        alert('Please fill the Address of your Next Kin to Continue')
                        Count = 1
                        return false;
                    }

                    if (NokPhoneNumber == '') {
                        alert('Please fill the Phone Number of your Next Kin to Continue')
                        Count = 1
                        return false;
                    }

                    $('#Step1').hide();
                    $('#Step2').hide();
                    $('#Step3').show();
                    $('#Step4').hide();
                    $('#Step5').hide();

                    //Change Previous button class BioData3
                    $('#btnPrevious').addClass('btn btn-success-primary');
                    $('#BioData1').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData2').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData3').addClass('btn btn-success-primary');
                }

                if (Count == 3) {
                    //validating feilds 
                    if (SessionID == 0) {
                        alert('Please Select Session to Continue')
                        Count = 2
                        return false;
                    }

                    if (SemesterID == 0) {
                        alert('Please Select Semester to Continue')
                        Count = 2
                        return false;
                    }
                    if (DepartmentID == 0) {
                        alert('Please Select Department to Continue')
                        Count = 2
                        return false;
                    }

                    if (ProgrammeID == 0) {
                        alert('Please Select Programme to Continue')
                        Count = 2
                        return false;
                    }
                    if (LevelID == 0) {
                        alert('Please Select Level to Continue')
                        Count = 2
                        return false;
                    }


                    $('#Step1').hide();
                    $('#Step2').hide();
                    $('#Step3').hide();
                    $('#Step4').show();
                    $('#Step5').hide();

                    //Change Previous button class BioData4
                    $('#btnPrevious').addClass('btn btn-success-primary');
                    $('#BioData1').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData2').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData3').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData4').addClass('btn btn-success-primary');
                }

                if (Count == 4) {
                    
                    //validating feilds      
                    if (Ps == '') {
                        alert('Please fill your Last Primary School attended to Continue')
                        Count = 3
                        return false;
                    }

                    if (Ss == '') {
                        alert('Please fill your Last Secondary School attended to Continue')
                        Count = 3
                        return false;
                    }

                    $('#Step1').hide();
                    $('#Step2').hide();
                    $('#Step3').hide();
                    $('#Step4').hide();
                    $('#Step5').show();

                    //Change Previous button class BioData5
                    $('#btnPrevious').addClass('btn btn-success-primary');
                    $('#BioData1').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData2').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData3').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData4').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData5').addClass('btn btn-success-primary');

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

                if (Count == 3) {
                    $('#Step1').hide();
                    $('#Step2').hide();
                    $('#Step3').hide();
                    $('#Step4').show();
                    $('#Step5').hide();

                    //Change Previous button class BioData2
                    $('#btnPrevious').addClass('btn btn-success-primary');
                    $('#BioData4').addClass('btn btn-next-primary').addClass('btn btn-success-primary'); ;
                    $('#BioData5').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');


                    //
                    $('#btnSave').hide();
                }

                if (Count == 2) {
                    $('#Step1').hide();
                    $('#Step2').hide();
                    $('#Step3').show();
                    $('#Step4').hide();
                    $('#Step5').hide();

                    //Change Previous button class BioData3
                    $('#btnPrevious').addClass('btn btn-success-primary');
                    $('#BioData3').removeClass('btn btn-next-primary').addClass('btn btn-success-primary');
                    $('#BioData4').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData5').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                }

                if (Count == 1) {
                    $('#Step1').hide();
                    $('#Step2').show();
                    $('#Step3').hide();
                    $('#Step4').hide();
                    $('#Step5').hide();

                    //Change Previous button class BioData4
                    $('#btnPrevious').addClass('btn btn-success-primary');
                    $('#BioData2').removeClass('btn btn-next-primary').addClass('btn btn-success-primary');
                    $('#BioData3').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData4').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData5').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                }

                if (Count == 0) {
                    $('#Step1').show();
                    $('#Step2').hide();
                    $('#Step3').hide();
                    $('#Step4').hide();
                    $('#Step5').hide();

                    //Change Previous button class BioData5
                    $('#btnPrevious').addClass('btn btn-next-primary');
                    $('#BioData1').removeClass('btn btn-next-primary').addClass('btn btn-success-primary');
                    $('#BioData2').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData3').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData4').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');
                    $('#BioData5').removeClass('btn btn-success-primary').addClass('btn btn-next-primary');

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
            //Fetching the values of all the feilds
            //Step One
            var RegNumber = $("[id*=txtRegNumber]").val();
            var Surname = $("[id*=txtSurname]").val();
            var Firstname = $("[id*=txtFirstname]").val();
            var MidleName = $("[id*=txtmidleName]").val();
            var MotherMaidenName = $("[id*=txtMotherMaidenName]").val();
            var DoB = $("#DoB").val();
            var Sex = $("[id*=rdoGender]").find(":checked").val()
            var StateID = $("[id*=ddlState]").find("option:selected").val()
            var LGAID = $("[id*=ddlLGA]").find("option:selected").val()

            //Step Two 
            var HomeAddress = $("[id*=txtHomeAddress]").val();
            var PhoneNumber = $("[id*=txtPhoneNumber]").val();
            var EmailAddress = $("[id*=txtEmailAddress]").val();
            var NoKName = $("[id*=txtNoKName]").val();
            var NoKHomeAddress = $("[id*=txtNoKHomeAddress]").val();
            var NokPhoneNumber = $("[id*=txtNokPhoneNumber]").val();

            //Step Three
            var SessionID = $("[id*=ddlSession]").find("option:selected").val()
            var SemesterID = $("[id*=ddlSemester]").find("option:selected").val()
            var DepartmentID = $("[id*=ddlDepartment]").find("option:selected").val()
            var ProgrammeID = $("[id*=ddlProgramme]").find("option:selected").val()
            var LevelID = $("[id*=ddlLevel]").find("option:selected").val()

            //Step Four
            var Ps = $("[id*=txtPs]").val();
            var DPsFrom = $("#DPsFrom").val();
            var DPsTo = $("#DPsTo").val();
            var Ss = $("[id*=txtSs]").val();
            var DSsFrom = $("#DSsFrom").val();
            var DSsTo = $("#DSsTo").val();


            //Step Five
            var PhotoUrl;
      

            //var fileUpload = $("#fileupload1").get(0);
            var fileUpload = $("[id*=fileupload1]").get(0); 
            var files = fileUpload.files;

            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }

            //Uploading passport
            $.ajax({
                url: "fileUploader.ashx",
                type: "POST",
                data: data,
                contentType: false,
                processData: false,
                success: function (result) {
                    //Getting the url of the Student's passport photography
                    PhotoUrl = result;


                    //Saving Student Data
                    $.ajax({
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "Default2.aspx/InsertData",
                        data: "{'ERegNumber':'" + RegNumber + "','ESurname':'" + Surname + "','EFirstname':'" + Firstname + "','EMidleName':'" + MidleName + "',"
                                + "'EMotherMaidenName':'" + MotherMaidenName + "','EStateID':'" + StateID + "','ELGAID':'" + LGAID + "','EDoB':'" + DoB + "','ESex':'" + Sex + "',"
                                + "'EHomeAddress':'" + HomeAddress + "','EPhoneNumber':'" + PhoneNumber + "','EEmailAddress':'" + EmailAddress + "',"
                                + "'ENoKName':'" + NoKName + "','ENoKHomeAddress':'" + NoKHomeAddress + "','ENokPhoneNumber':'" + NokPhoneNumber + "',"
                                + "'ESessionID':'" + SessionID + "','ESemesterID':'" + SemesterID + "','EDepartmentID':'" + DepartmentID + "',"
                                + "'EProgrammeID':'" + ProgrammeID + "','ELevelID':'" + LevelID + "','EPs':'" + Ps + "','ESs':'" + Ss + "',"
                                + "'EDPsFrom':'" + DPsFrom + "','EDPsTo':'" + DPsTo + "','DSsFrom':'" + DSsFrom + "','EDSsTo':'" + DSsTo + "','EPhotoUrl':'" + PhotoUrl + "'}",
                        dataType: "json",
                        success: function (data) {
                            var obj = data.d;
                            if (obj != '') {
                                $("[id$='lblErroSuccess']").html(data.d);
                                //alert(data.d);
                            }

                        },
                        beforeSend: function () {
                            // Code to display spinner
                            $('#spinnerSave').show();
                        },
                        complete: function () {
                            // Code to hide spinner.
                            $('#spinnerSave').hide();
                        },
                        error: function (result) {
                            alert('Error.');
                        }
                    });
                    


                },
                error: function (err) {
                    alert(err.statusText)
                }
            });


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
    
</body>
<script type="text/javascript" src="js/fileinput.min.js"></script>

<!-- Mirrored from webapplayers.com/inspinia_admin-v2.5/form_wizard.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 13 Jun 2016 10:59:25 GMT -->
</html>