Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Partial Class Admin_ManageLevel
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function InsertData(ByVal LevelName As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim DepartmentDAL As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL
        Dim DepartmentData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData

        DepartmentData.LevelName = LevelName

        ' call CreateSession API
        Dim CreateStatus As Integer = DepartmentDAL.CreateLevel(DepartmentData)
        If CreateStatus = 1 Then
            msg = "The Level was created successfully."
        Else
            msg = "The Level was NOT created successfully."
        End If
        Return msg
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function UpdateData(ByVal ELevel As String, ByVal EPID As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim DepartmentData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
        Dim DepartmentDal As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL

        'Populate Session data
        DepartmentData.LevelName = ELevel
        DepartmentData.LevelID = CInt(EPID)

        ' call UpdateDeptById API
        Dim EditStatus As Integer = DepartmentDal.UpdateLevel(DepartmentData)
        If EditStatus = 1 Then
            msg = "The Level was Updated successfully."
        End If

        If EditStatus = 0 Then
            msg = "The Level was NOT Updated successfully."
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
        DepartmentData.LevelID = CInt(EPID)

        ' call UpdateSessionById API
        Dim DeleteStatus As Integer = DepartmentDal.DeleteLevel(DepartmentData.LevelID)
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
    Public Shared Function GetLevel(ByVal PID As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim DepartmentDAL As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL
        Dim DepartmentData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData

        Dim DeptID As Integer = CInt(PID)
        DepartmentData = DepartmentDAL.FindLevelByID(DeptID)
        msg = DepartmentData.LevelName

        Return msg
    End Function
End Class
