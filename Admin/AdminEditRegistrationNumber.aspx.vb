Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class Admin_AdminEditRegistrationNumber
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetRegNumber(ByVal EregNumber As String) As String
        'Instance declaration 
        Dim std As StudentDAL = New StudentDAL
        Dim stdData As StudentData = New StudentData
        
        Dim RegNumber As String = ""
        stdData = std.FindStudentNameByRegNo(EregNumber)
        RegNumber = stdData.RegNumber

        Return RegNumber
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function UpdateRegNumber(ByVal EregNumber As String, ByVal EnewRegNumber As String) As String
        'Instance declaration 
        Dim std As StudentDAL = New StudentDAL
        Dim stdData As StudentData = New StudentData

        Dim RetValue As Integer = 0
        Dim msg As String = ""
        RetValue = std.UpdateRegNumber(EregNumber, EnewRegNumber)

        If RetValue = 1 Then
            msg = "success"
        End If

        Return msg
    End Function
End Class
