Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports System
Imports System.Web
Imports System.IO
Partial Class Application_Default
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function Login(ByVal ApplicationNo As String) As String
        Dim StdProfile As ApplicationFormDAL = New ApplicationFormDAL
        Dim StdData As ApplicationFormData = New ApplicationFormData

        StdData = StdProfile.FindApplicationByAppNo(ApplicationNo)
        Dim appNo As String = ""
        appNo = StdData.ApplicationNumber
        Return appNo
    End Function
End Class
