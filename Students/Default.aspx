<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Students_Default" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>Heritage Poly | Login </title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">

    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">

    <link rel="shortcut icon" href="img/favicon.ico">
</head>

<body class="gray-bg">

    <form id="Form1" runat="server">
       
        <div class="loginColumns animated fadeInDown">
            <div class="row">
                <div class="col-md-6">
                    <h2 class="font-bold">Welcome to Heritage Polytechnic, Eket</h2>
                    <p>
                        <strong>SINGLE SIGN-ON</strong><br />
						Sign in once and have access to all privileged content from one spot.			.
                    </p>
                    <p>
                        <small><strong>NEW STUDENT REGISTRATION</strong><br />
						If you are a new student, <a href="StudentProfileCreation.aspx" target="_blank">click here </a>to completely your registration</small>
                    </p>
                </div>
                <div class="col-md-6">
                    <div class="ibox-content">
                        <h2>STUDENTS LOGIN</h2>
                        <asp:Label ID="lblError" runat="server" Font-Size="13px"></asp:Label>
                        <asp:Label ID="lblError2" runat="server" Font-Size="13px"></asp:Label>
                        <div>
                            <%--<div class="alert alert-dismissable alert-success col-md-12" id="pnlError1" runat="server" visible="false">
                                <strong><i class="fa fa-check"></i></strong>
                                
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            </div>
                            <div class="alert alert-dismissable alert-danger col-md-12" id="pnlError2" runat="server" visible="false">
                                <strong><i class="fa fa-times"></i></strong>
                                
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            </div>--%>
                            <div class="form-group">
                                <asp:TextBox ID="txtRegNumber" runat="server" class="form-control" placeholder="Reg Number" required=""></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password" required="" TextMode="Password"></asp:TextBox>
                            </div>
                            <asp:Button ID="BtnLogin" runat="server" class="btn btn-primary block full-width m-b" Text="Login" />

                            <a href="#">
                                <small>Forgot password?</small>
                            </a>

                            <%-- <p class="text-muted text-center">
                            <small>Do not have an account?</small>
                        </p>
                        <a class="btn btn-sm btn-white btn-block" href="register.html">Create an account</a>
                    </div>
                    <p class="m-t">
                        <small style="color: red;">RESTRICTED ENTRY</small>
                    </p>--%>
                        </div>
                    </div>
                </div>
                <hr />
                <%-- <div class="row">
                    <div class="col-md-6">
                        SHT, Ezzangbo
                    </div>
                    <div class="col-md-6 text-right">
                        <small>&copy; <%=Today.Year%></small>
                    </div>
                </div>--%>
            </div>
        </div>
    </form>
</body>
</html>
