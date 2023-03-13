Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class Admin_AdminViewRegisteredStudentResult
    Inherits System.Web.UI.Page
    <WebMethod()> _
    Public Shared Function GetResult(ByVal regNumber As String, ByVal Session As String, ByVal Semester As String) As ArrayList
        'Instance declaration 
        Dim QueueList As New ArrayList

        Dim uploadResultDal As UploadResultDAL = New UploadResultDAL
        Dim RetDat As New DataSet

        'Getting the levelID
        Dim student As StudentProfileDAL = New StudentProfileDAL
        Dim studentData As StudentProfileData = New StudentProfileData

        studentData = student.FindLevelByRegNumber(regNumber)
        Dim LevelName As String = studentData.LevelName

        RetDat = uploadResultDal.FindAllResultByRegNumber(Session, Semester, LevelName, regNumber)

        Dim CourseName As String = ""
        Dim CourseCode As String = ""
        Dim CreditUnit As String = ""
        Dim Score As String = ""
        Dim Grade As String = ""
        Dim Remark As String = ""

        For Each row As DataRow In RetDat.Tables(0).Rows
            If Not IsDBNull(row(5)) Then
                CourseName = row(5)
            End If
            If Not IsDBNull(row(4)) Then
                CourseCode = row(4)
            End If
            If Not IsDBNull(row(6)) Then
                CreditUnit = row(6)
            End If
            If Not IsDBNull(row(9)) Then
                Score = row(9)
            End If
            If Not IsDBNull(row(10)) Then
                Grade = row(10)
            End If
            If Not IsDBNull(row(11)) Then
                Remark = row(11)
            End If

            QueueList.Add(New FindAllStudentResultArrayData(CourseName, CourseCode, CreditUnit, Score, Grade, Remark))
        Next

        'QueueList.Add(New FindAllStudentArrayData(intSessionID, intSessionID, intSemesterID, intSemesterID))

        Return QueueList

    End Function


    Public Class FindAllStudentResultArrayData

        Public CourseName As String
        Public CourseCode As String
        Public CreditUnit As String
        Public Score As String
        Public Grade As String
        Public Remark As String
        Public Sub New(ByVal CourseName As String, ByVal CourseCode As String, ByVal CreditUnit As String, ByVal Score As String, ByVal Grade As String, ByVal Remark As String)

            Me.CourseName = CourseName
            Me.CourseCode = CourseCode
            Me.CreditUnit = CreditUnit
            Me.Score = Score
            Me.Grade = Grade
            Me.Remark = Remark

        End Sub
    End Class

    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim ar As New ArrayList
    '    ar = GetResult("14096014", "2014/2015", "HND 1 First Semester")
    '    Label1.Text = ar.Item(0).CourseName
    'End Sub
End Class
