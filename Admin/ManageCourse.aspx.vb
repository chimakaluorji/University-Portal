Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Partial Class Admin_ManageCourse
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function InsertData(ByVal ECourseCode As String, ByVal ECourseName As String, ByVal ECreditUnit As String, ESemesterID As String, EDeptID As String, ByVal EProgrammeID As String, ByVal ELevelID As String, ByVal ELecturerID As String) As String
        Dim msg As String = String.Empty

        Dim CourseDAL As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL
        Dim CourseData As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim errorDal As ErrorDAL = New ErrorDAL

        Dim SemesterID As Integer = CInt(ESemesterID)
        Dim LevelID As Integer = CInt(ELevelID)
        Dim LecturerID As Integer = CInt(ELecturerID)

        'Populate Course data
        CourseData.SemesterID = SemesterID
        CourseData.SessionID = 6 'Me.ddlSession.SelectedValue
        CourseData.LevelID = LevelID
        CourseData.LecturerID = LecturerID 'Me.ddlLecturer.SelectedValue
        CourseData.ProgrammeID = EProgrammeID 'Me.ddlProgrammes.SelectedValue
        CourseData.QualificationID = EDeptID 'Me.ddlQualification.SelectedValue
        CourseData.CourseCode = ECourseCode
        CourseData.CourseName = ECourseName
        CourseData.CreditUnit = ECreditUnit
        CourseData.CreatedByUserID = 1 'CType(Session("UData"), UsersData).UserId

        Dim CreateStatus As Integer = CourseDAL.CreateCourse(CourseData)

        If CreateStatus = 1 Then
            msg = "success"
        Else
            msg = "failed"
        End If
        Return msg
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function UpdateData(ByVal EEditPID As String, ByVal ECourseCode As String, ByVal ECourseName As String, ByVal ECreditUnit As String, ESemesterID As String, EDeptID As String, ByVal EProgrammeID As String, ByVal ELevelID As String, ByVal ELecturerID As String) As String
        Dim msg As String = String.Empty


        'Intantiate objects for accessing User Data and Business Layers
        Dim CourseData As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim CourseDal As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL
        Dim errorDal As ErrorDAL = New ErrorDAL

        Dim EditPID As Integer = CInt(EEditPID)
        Dim SemesterID As Integer = CInt(ESemesterID)
        Dim LevelID As Integer = CInt(ELevelID)
        Dim LecturerID As Integer = CInt(ELecturerID)

        'Populate Course data
        CourseData.SemesterID = SemesterID 'Me.ddlSemester.SelectedValue
        CourseData.SessionID = 6 'Me.ddlSession.SelectedValue
        CourseData.LecturerID = LecturerID
        CourseData.LevelID = LevelID
        CourseData.ProgrammeID = 1 'Me.ddlProgrammes.SelectedValue
        CourseData.QualificationID = 1 'Me.ddlQualification.SelectedValue

        CourseData.CreditUnit = ECreditUnit
        CourseData.CourseCode = ECourseCode
        CourseData.CourseName = ECourseName
        CourseData.CourseID = EditPID

        ' call UpdateCourseById API
        Dim EditStatus As Integer = CourseDal.UpdateCourse(CourseData)

        If EditStatus = 1 Then
            msg = "success"
        End If

        If EditStatus = 0 Then
            msg = "failed"
        End If
        Return msg
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function DeleteData(ByVal EPID As String) As String
        Dim msg As String = String.Empty


        'Intantiate objects for accessing User Data and Business Layers
        Dim CourseDAL As CourseDAL = New CourseDAL
        Dim CourseData As CourseData = New CourseData

        'Populate Session data
        CourseData.CourseID = CInt(EPID)

        ' call UpdateSessionById API
        Dim DeleteStatus As Integer = CourseDAL.DeleteCourse(CourseData)
        If DeleteStatus = 1 Then
            msg = "The Course was Deleted successfully."
        End If

        If DeleteStatus = 0 Then
            msg = "The Course was NOT Deleted successfully."
        End If
        Return msg
    End Function
    <WebMethod()> _
 <ScriptMethod()> _
    Public Shared Function GetCourse(ByVal PID As String) As Array
        Dim msg As String() = {"", "", "", "", "", "", "", "", ""}



        'Intantiate objects for accessing User Data and Business Layers
        Dim CourseDAL As CourseDAL = New CourseDAL
        Dim CourseData As CourseData = New CourseData

        Dim DeptID As Integer = CInt(PID)
        CourseData = CourseDAL.FindCourseByCourseID(DeptID)
        msg(0) = CourseData.CourseCode
        msg(1) = CourseData.CourseName
        msg(2) = CourseData.CreditUnit
        msg(3) = CourseData.SemesterName
        msg(4) = CourseData.DeptName
        msg(5) = CourseData.LevelName
        msg(6) = CourseData.SemesterID
        msg(7) = CourseData.DepartmentID
        msg(8) = CourseData.LevelID



        Return msg
    End Function
    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim ar As Array

    '    ar = GetCourse(1)
    '    lblError.Text = "Yes " & ar.GetValue(0).ToString
    'End Sub
End Class
