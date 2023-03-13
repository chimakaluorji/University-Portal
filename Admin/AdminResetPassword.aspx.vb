Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class Admin_AdminResetPassword
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function ResetPassword(ByVal EregNumber As String) As String
        'Instance declaration 
        Dim std As StudentDAL = New StudentDAL
        Dim stdData As StudentData = New StudentData

        Dim msg As String = ""
        Dim RetValue As Integer = std.ResetPassword(EregNumber)

        If RetValue = 1 Then
            msg = "success"
        End If
        Return msg
    End Function
End Class
