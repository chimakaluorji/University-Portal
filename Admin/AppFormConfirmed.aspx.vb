Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports System
Imports System.Web
Imports System.IO
Partial Class Admin_AppFormConfirmed
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function FindAppFormConfirmedBySessionID(ByVal SessionID As Integer, ByVal Confirmed As String) As ArrayList
        Dim success As String = ""
        Dim GetSectionArray As ArrayList = New ArrayList

        Dim SSDDal As ApplicationFormDAL = New ApplicationFormDAL
        Dim RetDataSet As System.Data.DataSet = New System.Data.DataSet

        RetDataSet = SSDDal.FindAppFormConfirmedBySessionID(SessionID, Confirmed)
        If RetDataSet.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In RetDataSet.Tables(0).Rows
                GetSectionArray.Add(New Fetch_Details(row(0), row(1), row(2), row(3), row(4), row(5)))
            Next
        Else
            GetSectionArray.Add(New Fetch_Details("", "", "", "", "", ""))
        End If

        Return GetSectionArray
    End Function
End Class
Public Class Fetch_Details
    Public ApplicationNumber As String
    Public Surname As String
    Public FirstName As String
    Public MiddleName As String
    Public Programme As String
    Public Confirmed As String

    Public Sub New(ByVal ApplicationNumber As String, ByVal Surname As String, ByVal FirstName As String, ByVal MiddleName As String, ByVal Programme As String, ByVal Confirmed As String)
        Me.ApplicationNumber = ApplicationNumber
        Me.Surname = Surname
        Me.FirstName = FirstName
        Me.MiddleName = MiddleName
        Me.Programme = Programme
        Me.Confirmed = Confirmed
    End Sub

End Class