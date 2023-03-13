<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PrintStudentProfile.aspx.vb" Inherits="Students_PrintStudentProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>Heritage Poly | Student's Profile</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">

    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
</head>
<body class="white-bg" style="background-image:url(img/bg_new.png);">
    <form id="form1" runat="server">
                                    <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="wrapper wrapper-content animated fadeInRight">
                                                                <div class="row">
                                                                    <div class="col-sm-12">
                                                                       <h4 class="text-navy">Passport Photography</h4>
                                                                        <address>
                                                                            <asp:Image ID="StudentPhotoUrl" runat="server" Width="100px" Height="100px" AlternateText="Passport Photography"/>
                                                                        </address>
                                                                        
                                                                    </div>

                                                                    <div class="col-sm-5">
                                                                       <h4 class="text-navy">Bio-Data</h4>
                                                                        <address>
                                                                            <strong>Registration Number:</strong>: <asp:Label ID="lblRegNumber" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Surname:</strong>: <asp:Label ID="lblSurname" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Firstname:</strong>: <asp:Label ID="lblFirstname" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Middle Name:</strong>: <asp:Label ID="lblMiddleName" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Mothers Maiden Name:</strong>: <asp:Label ID="lblMothersMaidenName" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Date of Birth:</strong>: <asp:Label ID="lblDateofBirth" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Sex:</strong>: <asp:Label ID="lblSex" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>State:</strong>: <asp:Label ID="lblState" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>L.G.A:</strong>: <asp:Label ID="lblLGA" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                        </address>
                                                                    </div>

                                                                    <div class="col-sm-5">
                                                                       <h4 class="text-navy">Contacts</h4>
                                                                        <address>
                                                                            <strong>Home Address:</strong> <asp:Label ID="lblHomeAddress" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Phone Number:</strong> <asp:Label ID="lblPhoneNumber" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Email Address:</strong> <asp:Label ID="lblEmailAddress" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Phone of Next of Kin:</strong> <asp:Label ID="lblPhoneOfNextOfKin" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                        </address>
                                                                    </div>

                                                                    <div class="col-sm-5">
                                                                       <h4 class="text-navy">Academic</h4>
                                                                        <address>
                                                                            <strong>Session:</strong> <asp:Label ID="lblSession" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Semester:</strong> <asp:Label ID="lblSemester" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>Programme:</strong> <asp:Label ID="lblLevel" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                        </address>
                                                                    </div>

                                                                    <div class="col-sm-12">
                                                                       <h4 class="text-navy">Academic Background</h4>
                                                                        <address>
                                                                            <strong>Primary School Attended:</strong> <asp:Label ID="lblPrimarySchoolAttended" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>From:</strong> <asp:Label ID="lblPFrom" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label>
                                                                            <strong>To:</strong> <asp:Label ID="lblPTo" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                             <strong>Secondary School Attended:</strong> <asp:Label ID="lblSecondarySchoolAttended" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                            <strong>From:</strong> <asp:Label ID="lblSFrom" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label>
                                                                            <strong>To:</strong> <asp:Label ID="lblSTo" runat="server" Text="" Font-Bold="true" Font-Size="15px" CssClass="form-control"></asp:Label><br />
                                                                        </address>
                                                                    </div>
                                                                </div>

                                                    </div>
                                                </div>
                                            </div>                        
                                
    </form>

    
                <!-- Mainly scripts -->
                <script src="js/jquery-2.1.1.js"></script>
                <script src="js/bootstrap.min.js"></script>
                <script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>

                <!-- Custom and plugin javascript -->
                <script src="js/inspinia.js"></script>

                <script type="text/javascript">
                    window.print();
                </script>

</body>
</html>
