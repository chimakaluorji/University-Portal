Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class Admin_AdminViewDepartmentalResult
    Inherits System.Web.UI.Page
    <WebMethod()> _
    Public Shared Function GetCourse(ByVal SessionID As String, ByVal LevelID As String) As ArrayList
        'Instance declaration 
        Dim QueueList As New ArrayList


        Dim intSessionID As Integer = CInt(SessionID)
        Dim intLevelID As Integer = CInt(LevelID)

        Dim SeDal As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL
        Dim RetDat As DataSet = SeDal.FindAllSemestersBySessionIDLevelID(intSessionID, intLevelID)


        For Each row As DataRow In RetDat.Tables(0).Rows
            QueueList.Add(New FindAllCoursesArrayData(row(0), row(1)))
        Next

        Return QueueList
    End Function
    <WebMethod()> _
    Public Shared Function findDepartmentalResult(ByVal Session As String, ByVal Semester As String, ByVal Level As String) As ArrayList
        Dim SesArray As String() = Session.Split("/")
        Dim Ses As String = SesArray(1)
        Dim Sem As String = Semester.Replace(" ", "_")
        Dim lev As String = Level.Replace(" ", "_")

        Dim Ar As New ArrayList

        Dim sss As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL

        Ar = sss.FindDepartmentalResult_Portal(Ses, Sem, lev)
        Return Ar
    End Function
    <WebMethod()> _
    Public Shared Function FindDepartmentalResultHeader(ByVal Session As String, ByVal Semester As String, ByVal Level As String) As ArrayList
        Dim SesArray As String() = Session.Split("/")
        Dim Ses As String = SesArray(1)
        Dim Sem As String = Semester.Replace(" ", "_")
        Dim lev As String = Level.Replace(" ", "_")

        Dim Ar As New ArrayList

        Dim sss As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL

        Ar = sss.FindDepartmentalResultHeader_Portal(Ses, Sem, lev)
        Return Ar
    End Function
End Class

Public Class FindAllCoursesArrayData

    Public SemesterID As Integer
    Public SemesterName As String
    Public Sub New(ByVal SemesterID As Integer, ByVal SemesterName As String)

        Me.SemesterID = SemesterID
        Me.SemesterName = SemesterName

    End Sub
End Class

Public Class FindAllCourseCodeArrayData
    Public CourseCode As String
    Public Sub New(ByVal CourseCode As String)
        Me.CourseCode = CourseCode
    End Sub
End Class
