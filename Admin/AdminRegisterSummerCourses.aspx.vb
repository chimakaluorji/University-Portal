Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class Admin_AdminRegisterSummerCourses
    Inherits System.Web.UI.Page
    <WebMethod()> _
    Public Shared Function GetCourse(ByVal regNumber As String, ByVal SemesterID As String, ByVal Session As String, ByVal Semester As String) As ArrayList
        'Instance declaration 
        Dim DataDal As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL
        Dim QueueList As New ArrayList

        Dim returnArray As New ArrayList

        'Getting the levelID
        Dim student As StudentProfileDAL = New StudentProfileDAL
        Dim studentData As StudentProfileData = New StudentProfileData

        studentData = student.FindLevelByRegNumber(regNumber)
        Dim LevelIDInt As Integer = studentData.LevelID
        Dim SemesterIDInt As Integer = CInt(SemesterID)

        returnArray = DataDal.FindAllCoursesByRegNoSession_Summer(regNumber, Session, Semester, studentData.LevelName)

        Dim checkValue As Integer = 0
        checkValue = returnArray.Count

        If checkValue = 0 Then
            QueueList = DataDal.FindAllCoursesBySessionID(regNumber, SemesterIDInt, LevelIDInt)
        Else
            QueueList = returnArray
        End If

        Return QueueList

    End Function
    <WebMethod()> _
    Public Shared Function RegisterCourses(ByVal CourseID As String, ByVal regNumber As String, ByVal Session As String, ByVal Semester As String) As String
        'Instance declaration 
        Dim DataDal As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL
        Dim ReturnValue As Integer = 0

        'Getting the levelID
        Dim student As StudentProfileDAL = New StudentProfileDAL
        Dim studentData As StudentProfileData = New StudentProfileData

        studentData = student.FindLevelByRegNumber(regNumber)
        Dim LevelIDInt As Integer = studentData.LevelID
        Dim CourseIDInt As Integer = CInt(CourseID)

        ReturnValue = DataDal.CreateCourseRegistration_Portal_Summer(CourseIDInt, regNumber, Session, Semester, studentData.LevelName)

        If ReturnValue = 1 Then
            Return "success"
        Else
            Return "danger"
        End If

    End Function
    <WebMethod()> _
    Public Shared Function DeleteCourse(ByVal CourseID As String) As String
        'Instance declaration 
        Dim DataDal As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL
        Dim ReturnValue As Integer = 0

        Dim CourseIDInt As Integer = CInt(CourseID)

        ReturnValue = DataDal.DeletCourses_Portal_Summer(CourseIDInt)

        If ReturnValue = 1 Then
            Return "success"
        Else
            Return "danger"
        End If

    End Function
    <WebMethod()> _
    Public Shared Function GetAllAddCourses(ByVal regNumber As String, ByVal SemesterID As String, ByVal Session As String, ByVal Semester As String) As ArrayList
        'Instance declaration 
        Dim DataDal As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL
        Dim QueueList As New ArrayList

        'Getting the levelID
        Dim student As StudentProfileDAL = New StudentProfileDAL
        Dim studentData As StudentProfileData = New StudentProfileData

        studentData = student.FindLevelByRegNumber(regNumber)
        Dim LevelName As String = studentData.LevelName
        Dim LevelIDInt As Integer = studentData.LevelID
        Dim SemesterIDInt As Integer = CInt(SemesterID)

        QueueList = DataDal.FindAllAddCoursesBySessionID_Portal_Summer(regNumber, Session, Semester, LevelName, SemesterIDInt, LevelIDInt)

        Return QueueList

    End Function
    <WebMethod()> _
    Public Shared Function GetAllCourses(ByVal regNumber As String, ByVal Session As String, ByVal Semester As String) As ArrayList
        'Instance declaration 
        Dim DataDal As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL
        Dim QueueList As New ArrayList

        'Getting the levelID
        Dim student As StudentProfileDAL = New StudentProfileDAL
        Dim studentData As StudentProfileData = New StudentProfileData

        studentData = student.FindLevelByRegNumber(regNumber)
        Dim LevelName As String = studentData.LevelName

        QueueList = DataDal.FindAllCoursesByRegNoSession_Summer(regNumber, Session, Semester, LevelName)

        Return QueueList

    End Function
End Class
