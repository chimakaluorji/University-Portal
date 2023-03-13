Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Partial Class Admin_ManageSemester
    Inherits System.Web.UI.Page
    <WebMethod()> _
  <ScriptMethod()> _
    Public Shared Function InsertData(ByVal SemesterName As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim SessionDAL As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL
        Dim SessionData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData

        SessionData.SemesterName = SemesterName

        ' call CreateSession API
        Dim CreateStatus As Integer = SessionDAL.CreateSemester(SessionData)
        If CreateStatus = 1 Then
            msg = "The Semester was created successfully."
        Else
            msg = "The Semester was NOT created successfully."
        End If


        Return msg
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function UpdateData(ByVal ESemesterName As String, ByVal EPID As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim SemesterData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
        Dim SemesterDal As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL

        'Populate Session data
        SemesterData.SemesterName = ESemesterName
        SemesterData.SemesterID = CInt(EPID)

        ' call UpdateSessionById API
        Dim EditStatus As Integer = SemesterDal.UpdateSemester(SemesterData)
        If EditStatus = 1 Then
            msg = "The Session was Updated successfully."
        End If

        If EditStatus = 0 Then
            msg = "The Session was NOT Updated successfully."
        End If
        Return msg
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function DeleteData(ByVal EPID As String) As String
        Dim msg As String = String.Empty


        'Intantiate objects for accessing User Data and Business Layers
        Dim SemesterData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
        Dim SemesterDal As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL

        'Populate Session data
        SemesterData.SessionID = CInt(EPID)

        ' call UpdateSessionById API
        Dim DeleteStatus As Integer = SemesterDal.DeleteSemester(SemesterData.SemesterID)
        If DeleteStatus = 1 Then
            msg = "The Session was Deleted successfully."
        End If

        If DeleteStatus = 0 Then
            msg = "The Session was NOT Deleted successfully."
        End If
        Return msg
    End Function
    <WebMethod()> _
 <ScriptMethod()> _
    Public Shared Function GetSemesterName(ByVal PID As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim SemesterDAL As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL
        Dim SemesterData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData

        Dim SemesterID As Integer = CInt(PID)
        SemesterData = SemesterDAL.FindSemesterByID(SemesterID)
        msg = SemesterData.SemesterName

        Return msg
    End Function
End Class
