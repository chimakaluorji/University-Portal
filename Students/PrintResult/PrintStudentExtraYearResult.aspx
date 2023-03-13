<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PrintStudentExtraYearResult.aspx.vb" Inherits="Students_PrintResult_PrintStudentExtraYearResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Print Student's Result</title>
<link rel="stylesheet" href="css/style.css" type="text/css"/>
    <link rel="shortcut icon" href="img/favicon.ico">
</head>
<body style="font-size:12px; background-image:url(img/bg.png)">
    <form id="form1" runat="server">
    <div>
          <table border="0" cellpadding ="4" cellspacing ="0" width ="100%">
                            <tr>
                                <td>
                                    <table width="100%">
                                           <tr>
                                                <td colspan="2">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td rowspan="2" width="7%" height="30px">
                                                            <img src="img/logo20.png" alt="logo" height="80px" width="68px"/>
                                                        </td>
                                                          <td width="93%" align="center" colspan="2" height="30px">
                                                              <%-- <div class="Mianbox">--%>
					                                                            <!-- Box Head -->
					                                                            <div class="Mianbox-head">
                                                                                    HERITAGE POLYTECHNIC <br />
                                                                                     Student's Result.
                                                                                </div>
                                                               <%-- </div>--%>
                                                          </td>  
                                                    </tr>
                                                     <tr>
                                                          <td width="80%" colspan="3" >
                                                          <asp:Label ID="lblError" runat="server" Text="" ForeColor="red" Font-Size="Large"></asp:Label>
                                                            <asp:Label ID="lblRegNumber" runat="server" Text="" Visible="false"></asp:Label>
                                                             <asp:Label ID="lblSession1" runat="server" Text="" Visible="false"></asp:Label>
                                                              <asp:Label ID="lblSemester1" runat="server" Text="" Visible="false"></asp:Label>
                                                               <asp:Label ID="lblLevel1" runat="server" Text="" Visible="false"></asp:Label>
                                                          </td>  
                                                    </tr>
                                                </table>
                                                </td>
                                           </tr>
                                        <tr>
                                           <td width="100%">
                                                <table border="0" cellpadding ="2" cellspacing ="0" width ="100%">
                                                     <tr>
                            <td align="center">
                            
                                <table cellpadding ="3" cellspacing ="3" align="center" width="100%" class="BorderLine">
                                    <tr>
                                                    <td>
                                                        <table width="100%"  class="MainBorderLine" >
                                                            <tr>
                                                                <td width="20%" align="right">
                                                                    <b>Registration Number:</b>
                                                                </td>
                                                                <td width="20%" align="left">
                                                                    <asp:Label ID="lblRegNo" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td width="20%" align="right">
                                                                    <b>Academic Session:</b>
                                                                </td>
                                                                <td width="20%" align="left">
                                                                     <asp:Label ID="lblAcademicSession" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td rowspan="4" align="right" width="20%">
                                                                    <asp:Image ID="ImgStudent" runat="server" Width="110px" Height="110px"/>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <b>Surname:</b>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblSurname" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                
                                                                <td align="right">
                                                                     <b>Programme:</b>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblProgramme" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <b>First Name:</b>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblFirstName" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td align="right">
                                                                    <b>Date:</b>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    
                                                    </td>
                                                    
                                    </tr>
                                    <tr>
                                        <td align="left" width="47%" valign="top">
                                                    <table cellpadding ="2" cellspacing ="3" align="center" width="100%" class="BorderLine">
                                                        <tr>
                                                        <td align="center">
                                                          <div id="content_Result">
				
				                                                            <!-- Box -->
				                                                            <div class="box">
					                                                            <!-- Box Head -->
					                                                            <div class="box-head">
						                                                            <h2 class="left">Extra Year Result </h2>
						                                                           
					                                                            </div>
					                                                            <!-- End Box Head -->	

					                                                            <!-- Table -->
					                                                            <div class="table">
						                                                             <asp:GridView ID="gdvUploadResult" runat="server" AutoGenerateColumns="False" Width="100%" CellPadding="3" 
                                                                                          CssClass="Grid" AlternatingRowStyle-CssClass="odd" GridLines="None" BorderStyle="None">
                                                                                                     <Columns>
                                                                                                           <asp:BoundField DataField="CourseCode" HeaderText="Course Code" SortExpression="CourseCode" />
                                                                                                           <asp:BoundField DataField="CourseName" HeaderText="Course Name" SortExpression="CourseName" />
                                                                                                           <asp:BoundField DataField="CreditUnit" HeaderText="Credit Unit" SortExpression="CreditUnit" />
                                                                                                           <asp:BoundField DataField="Total" HeaderText="Scores" SortExpression="Total" />
                                                                                                           <asp:BoundField DataField="Grade" HeaderText="Grade" SortExpression="Grade" />
                                                                                                           <asp:BoundField DataField="Remark" HeaderText="Remark" SortExpression="Remark" />
                                                                                                     </Columns>
                                                                                                   </asp:GridView>
						                                                            <!-- End Pagging -->
					                                                            </div>
					                                                            <!-- Table -->
				                                                            </div>
				
			                                                            </div>
                                                        </td>
                                                    </tr>
                                                    
                                              <%-- <tr>
                                                   <td style="font-family:Garamond; font-size:17px;">
                                                       <b>GPA:</b> <asp:Label ID="lblGPA" runat="server" Text=""></asp:Label>
                                                   </td>
                                               </tr>--%>
                                               <tr>
                                                   <td align="center">
                                                                                     
                                                            <input type="button" value=" Print" onclick="window.print();return false;" class="Printbutton"/> &nbsp; &nbsp; &nbsp;&nbsp;
                                                            <a href="#" onclick="window.close();" class="gridPrint" style="font-size:12px;">[CLOSE]</a>
                                                 </td>
                                                </tr>
                                              
                                       </table>
                                        </td>
                                        
                                    </tr>
                                
                                </table>
                           </td>
                       </tr>
                                                </table>
                                          </td>
                               
                                   </tr>
                                 
                             </table>
                                </td>
                            </tr>
                          
                        </table>
    </div>
    </form>
</body>
</html>