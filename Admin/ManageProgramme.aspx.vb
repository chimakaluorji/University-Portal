Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Partial Class Admin_ManageProgramme
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function InsertData(ByVal DeptID As Integer, ByVal Programme As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim ProgrammeDAL As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL
        Dim ProgrammeData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData

        ProgrammeData.DeptID = DeptID
        ProgrammeData.ProgrammeName = Programme

        'call CreateSession API
        Dim CreateStatus As Integer = ProgrammeDAL.CreateProgramme(ProgrammeData)
        If CreateStatus = 1 Then
            msg = "The Programme was created successfully."
        Else
            msg = "The Programme was NOT created successfully."
        End If
        Return msg
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function UpdateData(ByVal EDepartment As String, ByVal EPID As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim DepartmentData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
        Dim DepartmentDal As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL

        'Populate Session data
        DepartmentData.DeptName = EDepartment
        DepartmentData.DeptID = CInt(EPID)

        ' call UpdateDeptById API
        Dim EditStatus As Integer = DepartmentDal.UpdateDepartment(DepartmentData)
        If EditStatus = 1 Then
            msg = "The Department was Updated successfully."
        End If

        If EditStatus = 0 Then
            msg = "The Department was NOT Updated successfully."
        End If
        Return msg
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function DeleteData(ByVal EPID As String) As String
        Dim msg As String = String.Empty


        'Intantiate objects for accessing User Data and Business Layers
        Dim DepartmentData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
        Dim DepartmentDal As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL

        'Populate Session data
        DepartmentData.DeptID = CInt(EPID)

        ' call UpdateSessionById API
        Dim DeleteStatus As Integer = DepartmentDal.DeleteDepartment(DepartmentData.DeptID)
        If DeleteStatus = 1 Then
            msg = "The Department was Deleted successfully."
        End If

        If DeleteStatus = 0 Then
            msg = "The Department was NOT Deleted successfully."
        End If
        Return msg
    End Function
    <WebMethod()> _
 <ScriptMethod()> _
    Public Shared Function GetProgramme(ByVal PID As String) As Array
        Dim msg As String() = {"", ""}

        'Intantiate objects for accessing User Data and Business Layers
        Dim DepartmentDAL As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL
        Dim DepartmentData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData

        Dim DeptID As Integer = CInt(PID)
        DepartmentData = DepartmentDAL.FindProgrammeByID(DeptID)
        msg(0) = DepartmentData.DeptName
        msg(1) = DepartmentData.ProgrammeName

        Return msg
    End Function
End Class
