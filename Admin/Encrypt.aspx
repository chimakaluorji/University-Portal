<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Encrypt.aspx.vb" Inherits="Admin_Encrypt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:TextBox runat="server" ID="txtUser"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
        <br /><br />
        <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>