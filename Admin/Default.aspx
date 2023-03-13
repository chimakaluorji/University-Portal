<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Admin_Default" %>

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
    <link href="img/favicon.ico" rel="icon"/>
</head>

<body class="gray-bg">
    <form runat="server">
        <div class="loginColumns animated fadeInDown">
            <div class="row">
                <div class="col-md-6">
                    <h2 class="font-bold">Heritage Poly Portal</h2>
                    <p>
                        Please ensure you put the correct username and password to get access to the portal.
                    </p>
                    <p>
                        <small>It is important to note that you need to always log out immediately you are done with what you are doing in the admin model. An unauthorize users can get access to the admin part with your credentials</small>
                    </p>
                </div>
                <div class="col-md-6">
                    <div class="ibox-content">
                        <div>
                             <h2>ADMIN LOGIN</h2>
                            <div class="alert alert-dismissable alert-success col-md-12" id="pnlError1" runat="server" visible="false">
                                <strong><i class="fa fa-check"></i></strong>
                                <asp:Label ID="lblError" runat="server" Font-Size="13px"></asp:Label>
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            </div>
                            <div class="alert alert-dismissable alert-danger col-md-12" id="pnlError2" runat="server" visible="false">
                                <strong><i class="fa fa-times"></i></strong>
                                <asp:Label ID="lblError2" runat="server" Font-Size="13px"></asp:Label>
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="TxtUsername" runat="server" class="form-control" placeholder="Username" required=""></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password" required="" TextMode="Password"></asp:TextBox>
                            </div>
                            <asp:Button ID="BtnLogin" runat="server" class="btn btn-primary block full-width m-b" Text="Login" />

                            <a href="#">
                                <small>Forgot password?</small>
                            </a>

                        </div>
                    </div>
                </div>
                <hr />
            </div>
        </div>
    </form>
</body>
</html>
