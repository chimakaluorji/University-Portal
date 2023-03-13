Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class Admin_AdminViewStudentResult
    Inherits System.Web.UI.Page


    <WebMethod()>
    Public Shared Function GetResult(ByVal regNumber As String, ByVal Session As String, ByVal Semester As String, ByVal Level As String) As ArrayList
        'Instance declaration 
        Dim QueueList As New ArrayList

        Dim uploadResultDal As UploadResultDAL = New UploadResultDAL
        Dim RetDat As New DataSet

        'Getting the levelID
        Dim student As StudentProfileDAL = New StudentProfileDAL
        Dim studentData As StudentProfileData = New StudentProfileData

        studentData = student.FindLevelByRegNumber(regNumber)
        'Dim LevelName As String = "HND Accountancy" 'studentData.LevelName

        RetDat = uploadResultDal.FindAllStudentResultByRegNumber(Session, Semester, Level, regNumber)



        Dim CourseCode As String = ""
        Dim CreditUnit As String = ""
        Dim Score As String = ""
        Dim Grade As String = ""
        Dim Remark As String = ""

        For Each row As DataRow In RetDat.Tables(0).Rows
            If Not IsDBNull(row(4)) Then
                CourseCode = row(4)
            End If
            If Not IsDBNull(row(5)) Then
                CreditUnit = row(5)
            End If
            If Not IsDBNull(row(8)) Then
                Score = row(8)
            End If
            If Not IsDBNull(row(9)) Then
                Grade = row(9)
            End If
            If Not IsDBNull(row(10)) Then
                Remark = row(10)
            End If

            QueueList.Add(New FindAllStudentResultArrayData(CourseCode, CreditUnit, Score, Grade, Remark))
        Next

        'QueueList.Add(New FindAllStudentArrayData(intSessionID, intSessionID, intSemesterID, intSemesterID))

        Return QueueList

    End Function
End Class

Public Class FindAllStudentResultArrayData

    Public CourseCode As String
    Public CreditUnit As String
    Public Score As String
    Public Grade As String
    Public Remark As String
    Public Sub New(ByVal CourseCode As String, ByVal CreditUnit As String, ByVal Score As String, ByVal Grade As String, ByVal Remark As String)

        Me.CourseCode = CourseCode
        Me.CreditUnit = CreditUnit
        Me.Score = Score
        Me.Grade = Grade
        Me.Remark = Remark

    End Sub
End Class

