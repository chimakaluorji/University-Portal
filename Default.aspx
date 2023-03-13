<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<!-- Mirrored from unibujaug.mycportal.com/cportal/gc by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 09 Mar 2016 09:58:29 GMT -->
<!-- Added by HTTrack --><meta http-equiv="content-type" content="text/html;charset=UTF-8" /><!-- /Added by HTTrack -->
<head>
<title>Heritage Poly Login</title>

<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">

<link href="common/themes/gcn-default/gsilver/gsilver.css" rel="stylesheet" type="text/css" >
<link href="common/themes/gcn-default/gsilver/style.css" rel="stylesheet" type="text/css" >
<script language="javascript" src="common/cportal.js"></script>
<script language="javascript" src="common/md5.js"></script>

<link rel="shortcut icon" href="images/favicon.ico">

<!--Start of Tawk.to Script-->
<script type="text/javascript">
var Tawk_API=Tawk_API||{}, Tawk_LoadStart=new Date();
(function(){
var s1=document.createElement("script"),s0=document.getElementsByTagName("script")[0];
s1.async=true;
s1.src='https://embed.tawk.to/589c6eedff923c0ab416ca3f/default';
s1.charset='UTF-8';
s1.setAttribute('crossorigin','*');
s0.parentNode.insertBefore(s1,s0);
})();
</script>
<!--End of Tawk.to Script-->

</head>

<body>
<div id="body">
 	
		<div id="header">
			
			<div id="logo"></div>
			
		</div>

		<div id="xbody">

        <div id="menuitems">
                <div>
                    <span id="txt">
                        <strong><asp:Label ID="lblError" runat="server" Text=""></asp:Label></strong>
                    </span>
                </div>
				<div>
					<span><img src="images/circ.png" width="27" height="27" align="absmiddle"/></span>
					<span id="txt">
						<strong>APPLICATION FORM FOR ADMISSION INTO THE POLYTECHNIC</strong><br />
						 <a href="Application/" target="_blank">Click Here</a> to apply for admission into the Polytechnic.</span>				
               </div>
			    <div>
					<span><img src="images/circ.png" width="27" height="27" align="absmiddle"/></span>
					<span id="txt">
						<strong>NEW STUDENT REGISTRATION</strong><br />
						If you are a new student, <a href="Students/StudentProfileCreation.aspx" target="_blank">click here </a>to completely your registration					</span>				
               </div>
				<div>
					<span><img src="images/circ.png" width="27" height="27" align="absmiddle"/></span>
					<span id="txt">
						<strong>ALL TOGETHER</strong><br />
						Admissions, Registration, Fees Payment, Exams & Records, Student Self-Care (My School), Library...		</br></br>	</br></br>
						<Strong>Having problems? Send email to <a href="mailto:info@heritagepolyportal.com">info@heritagepolyportal.com</a></Strong>		</span>				
               </div>

		  </div>
			
			<div id="menuitems0">
                     <div id="login">
					<div id="lock"><img src="images/padlock.png" width="103" height="101" /></div>	
					<div id="regx">
					<form runat="server" id="loginForm">
                        <div class="ftitle">REG NUMBER</div>
						<div class="finput"><asp:TextBox ID="TxtRegNo" runat="server"></asp:TextBox></div>
						<div class="ftitle">PASSWORD</div>
						<div class="finput"><asp:TextBox ID="TxtPin" runat="server" TextMode="Password"></asp:TextBox></div>
						<br />
                        <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn_Login"/>
						<br /><br />
                    
                        <a href="#" class="cpBodyText">Forgot your password?</a>
                     </form>
				  </div>
				  <div id ="errormessage">
				  <div>   </div>
				  </div>
				</div>
            </div>

		</div>
		
		<div id="footer">
		  <div id="privacy"><div id="privacy1">© 2019 ::   <span class="gtBodyText"> Heritage Polytechnic</span>. All rights reserved  <br/></div>
	      <a href="admin/" target="_blank">admin</a> | <a href="#" target="_blank">Privacy</a></div>
			<div id="powered"><img src="images/swpowered.png" width="149" height="43" /></div>
		</div>
</div>

</body>


<SCRIPT language='javascript'>
    function submitOnEnterKey(e) {
        var theform = document.loginForm;
        if (!e) e = window.event;
        var keyInfo = String.fromCharCode(e.keyCode) + '\n';
        keyCodeValue = e['keyCode'];
        if (e['keyCode'] == 13 || keyCodeValue == 13) {
            doLoginSubmit();
            //loginForm.submit();
        }
    }
</SCRIPT>

<!-- Mirrored from unibujaug.mycportal.com/cportal/gc by HTTrack Website Copier/3.x [XR&CO'2014], Wed, 09 Mar 2016 09:58:42 GMT -->
</html>

