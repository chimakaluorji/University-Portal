<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PrintStudentReceipt.aspx.vb" Inherits="Students_PrintStudentReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title>Heritage Poly | Student's Receipt</title>

    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">

    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
</head>
<body class="white-bg" style="background-image:url(img/bg_new.png);">
    <form id="form1" runat="server">
    <div>
         <div class="wrapper wrapper-content p-xl">
                                <div class="ibox-content p-xl">
                                                                <div class="row">
                                                                    <div class="col-sm-6">
                                                                        <h5>From:</h5>
                                                                        <address>
                                                                            <strong>Heritage Polytechnic</strong><br>
                                                                            Eket,<br>
                                                                            Akwa Ibom State, Nigeria<br>
                                                                            <abbr>Phone Number: </abbr> + (234) 809 351 0308
                                                                        </address>
                                                                    </div>
                                                                    
                                                                    <div class="col-sm-6 text-right">
                                                                        <h4>Receipt No.</h4>
                                                                        <h4 class="text-navy">HP-<asp:Label ID="lblReceiptNo1" runat="server" Text=""></asp:Label>F<asp:Label ID="lblReceiptNo2" runat="server" Text=""></asp:Label>-<asp:Label ID="lblReceiptNo3" runat="server" Text=""></asp:Label></h4>
                                                                        <span>To:</span>
                                                                        <address>
                                                                            <strong><asp:Label ID="lblStudentName" runat="server" Text=""></asp:Label></strong><br>
                                                                            <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label><br>
                                                                            <abbr>Phone Number:</abbr> <asp:Label ID="lblStudnetPhoneNo" runat="server" Text=""></asp:Label>
                                                                        </address>
                                                                        <p>
                                                                            <span><strong>Receipt Date: </strong><asp:Label ID="lblReceiptDate" runat="server" Text=""></asp:Label></span>
                                                                        </p>
                                                                    </div>
                                                                </div>

                                                                <div class="table-responsive m-t">
                                                                    <table class="table invoice-table">
                                                                        <thead>
                                                                        <tr>
                                                                            <th>Item List</th>
                                                                            <th>Quantity</th>
                                                                            <th>Unit Price</th>
                                                                            <th>Tax</th>
                                                                            <th>Total Price</th>
                                                                        </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                        <tr>
                                                                            <td><div><strong>School Fees Payment</strong></div>
                                                                                <small>This receipt serves as an evident of school fees payment for <asp:Label ID="lblSemester" runat="server" Text=""></asp:Label>, <asp:Label ID="lblSession" runat="server" Text=""></asp:Label> Session</small></td>
                                                                            <td>1</td>
                                                                            <td>₦ <asp:Label ID="lblUnitPrice" runat="server" Text=""></asp:Label></td>
                                                                            <td>₦ 0.00</td>
                                                                            <td>₦ <asp:Label ID="lblTotalPrice" runat="server" Text=""></asp:Label></td>
                                                                        </tr>
                                                                        <%--<tr>
                                                                            <td><div><strong>Wodpress Them customization</strong></div>
                                                                                <small>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                                                                                    Eiusmod tempor incididunt ut labore et dolore magna aliqua.
                                                                                </small></td>
                                                                            <td>2</td>
                                                                            <td>$80.00</td>
                                                                            <td>$36.80</td>
                                                                            <td>$196.80</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td><div><strong>Angular JS & Node JS Application</strong></div>
                                                                                <small>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</small></td>
                                                                            <td>3</td>
                                                                            <td>$420.00</td>
                                                                            <td>$193.20</td>
                                                                            <td>$1033.20</td>
                                                                        </tr>--%>

                                                                        </tbody>
                                                                    </table>
                                                                </div><!-- /table-responsive -->

                                                                <table class="table invoice-total">
                                                                    <tbody>
                                                                    <tr>
                                                                        <td><strong>Sub Total :</strong></td>
                                                                        <td>₦ <asp:Label ID="lblSubTotal" runat="server" Text=""></asp:Label>.00</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><strong>TAX :</strong></td>
                                                                        <td>₦ 0.00</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td><strong>TOTAL :</strong></td>
                                                                        <td>₦ <asp:Label ID="lblMainTotal" runat="server" Text=""></asp:Label>.00</td>
                                                                    </tr>
                                                                    </tbody>
                                                                </table>
                                                               <%-- <div class="text-right">
                                                                    <button class="btn btn-primary"><i class="fa fa-dollar"></i> Make A Payment</button>
                                                                </div>

                                                                <div class="well m-t"><strong>NOTE</strong>
                                                                    It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less
                                                                </div>--%>
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
