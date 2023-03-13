<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Application_Default" %>

<!DOCTYPE html>
<html>


<!-- Mirrored from webapplayers.com/inspinia_admin-v2.5/login.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 13 Jun 2016 10:57:21 GMT -->
<head>

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>HP Application Form | Login</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">

    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
</head>

<body class="gray-bg">

    <div class="middle-box text-center loginscreen animated fadeInDown">
        <div>
            <div>

                <h1 class="logo-name">
                    <img src="img/logo.png" /></h1>

            </div>
            <h3>Welcome to Heritage Polytechnic</h3>

            <p>Login in with your Application Number.</p>
            <form class="m-t" role="form" id="form1">
                <div class="form-group">
                    <input type="text" class="form-control" placeholder="Application Number" required="" id="txtApplicationNo">
                </div>
                <%--<div class="form-group">
                    <input type="password" class="form-control" placeholder="Password" required="">
                </div>
                <button type="submit" class="btn btn-primary block full-width m-b" id="btnLogin">Login</button>--%>
                <input type="button" value="Login" id="btnLogin" class="btn btn-primary block full-width m-b"/>

                <%--<a href="#"><small>Forgot password?</small></a>--%>
                <p class="text-muted text-center"><small>I have not applied?</small></p>
                <a class="btn btn-sm btn-white btn-block" href="ApplicationForm.aspx">Apply Now</a>
            </form>
            <p class="m-t"><small>Heritage Polytechnic Portal &copy; 2017</small> </p>
        </div>
    </div>

    <!-- Mainly scripts -->
    <script src="js/jquery-2.1.1.js"></script>
    <script src="js/bootstrap.min.js"></script>

</body>

<script type="text/javascript">
    //Saving the data
    $(function () {
        $('#btnLogin').click(function () {
            var ApplicationNo = $("#txtApplicationNo").val();

            if (ApplicationNo == '') {
                alert("Please fill in your Application Number to continue.")
                return false;
            }

            //Saving Student Data
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Default.aspx/Login",
                data: "{'ApplicationNo':'" + ApplicationNo + "'}",
                dataType: "json",
                success: function (data) {

                    var check = data.d;
                    if (check != '') {
                        window.location.replace('ViewApplicationForm.aspx?ApNo=' + check);
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
                    //alert('Error Occurred, Contact Admin.');
                    alert(result.statusText)
                }
            });
        })
    });
</script>
<!-- Mirrored from webapplayers.com/inspinia_admin-v2.5/login.html by HTTrack Website Copier/3.x [XR&CO'2014], Mon, 13 Jun 2016 10:57:21 GMT -->
</html>
