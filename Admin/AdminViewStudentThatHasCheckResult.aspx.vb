Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class Admin_AdminViewStudentThatHasCheckResult
    Inherits System.Web.UI.Page
    <WebMethod()> _
    Public Shared Function GetResult(ByVal intSessionID As String, ByVal intSemesterID As String) As ArrayList
        'Instance declaration 
        Dim QueueList As New ArrayList

        Dim uploadResultDal As UploadResultDAL = New UploadResultDAL
        Dim RetDat As New DataSet

        Dim NewUploadResultDAL As UploadResultDAL = New UploadResultDAL

        Dim SessionID As Integer = CInt(intSessionID)
        Dim SemesterID As Integer = CInt(intSemesterID)


        RetDat = uploadResultDal.FindStudentThatHaveCheckedResult(SessionID, SemesterID)

        Dim RegNumber As String = ""
        Dim ResultETransactPin As String = ""
        Dim Surname As String = ""
        Dim Firstname As String = ""
        Dim SessionName As String = ""
        Dim SemesterName As String = ""
        Dim Level As String = ""
        Dim Status As String = ""
        Dim Message As String = ""

        Dim RetCount As Integer = NewUploadResultDAL.CountStudentThatHaveCheckedResult(SessionID, SemesterID)

        Dim d As Integer = RetDat.Tables(0).Rows.Count


        For Each row As DataRow In RetDat.Tables(0).Rows
            If Not IsDBNull(row(0)) Then
                RegNumber = row(0)
            End If
            If Not IsDBNull(row(1)) Then
                ResultETransactPin = row(1)
            End If
            If Not IsDBNull(row(2)) Then
                Surname = row(2)
            End If
            If Not IsDBNull(row(3)) Then
                Firstname = row(3)
            End If
            If Not IsDBNull(row(4)) Then
                SessionName = row(4)
            End If
            If Not IsDBNull(row(5)) Then
                SemesterName = row(5)
            End If
            If Not IsDBNull(row(6)) Then
                Level = row(6)
            End If
            If Not IsDBNull(row(7)) Then
                Status = row(7)
            End If

            Message = "The number of students that have checked their results for the selected session and semester are  <b class='text-navy'>" & RetCount & "</b> in number."


            QueueList.Add(New FindAllStudentThatHasCheckedResult(RegNumber, ResultETransactPin, Surname, Firstname, SessionName, SemesterName, Level, Status, Message))

        Next
        'QueueList.Add(New FindAllStudentThatHasCheckedResult(RegNumber, ResultETransactPin, Surname, Firstname, SessionName, SemesterName, Level, Status, Message))

        'For i As Integer = 0 To 246
        '    If Not IsDBNull(RetDat.Tables(0).Rows(i).Item(0)) Then
        '        RegNumber = RetDat.Tables(0).Rows(i).Item(0)
        '    End If
        '    If Not IsDBNull(RetDat.Tables(0).Rows(i).Item(1)) Then
        '        ResultETransactPin = RetDat.Tables(0).Rows(i).Item(1)
        '    End If
        '    If Not IsDBNull(RetDat.Tables(0).Rows(i).Item(2)) Then
        '        Surname = RetDat.Tables(0).Rows(i).Item(2)
        '    End If
        '    If Not IsDBNull(RetDat.Tables(0).Rows(i).Item(3)) Then
        '        Firstname = RetDat.Tables(0).Rows(i).Item(3)
        '    End If
        '    If Not IsDBNull(RetDat.Tables(0).Rows(i).Item(4)) Then
        '        SessionName = RetDat.Tables(0).Rows(i).Item(4)
        '    End If
        '    If Not IsDBNull(RetDat.Tables(0).Rows(i).Item(5)) Then
        '        SemesterName = RetDat.Tables(0).Rows(i).Item(5)
        '    End If
        '    If Not IsDBNull(RetDat.Tables(0).Rows(i).Item(6)) Then
        '        Level = RetDat.Tables(0).Rows(i).Item(6)
        '    End If
        '    If Not IsDBNull(RetDat.Tables(0).Rows(i).Item(7)) Then
        '        Status = RetDat.Tables(0).Rows(i).Item(7)
        '    End If

        '    Message = "The number of students that have checked their results for the selected session and semester are  <b class='text-navy'>" & RetCount & "</b> and " & d & " in number."

        '    QueueList.Add(New FindAllStudentThatHasCheckedResult(RegNumber, ResultETransactPin, Surname, Firstname, SessionName, SemesterName, Level, Status, Message))

        'Next

        Return QueueList

    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim ar As New ArrayList

        'ar = GetResult(7, 1)

        'lblMessage.Text = ar.Item(0).Message

        'Dim x As Integer
        'For x = 0 To 50
        '    ListBox1.Items.Add(ar.Item(x).RegNumber & " and " & ar.Item(x).ResultETransactPin)
        'Next x
    End Sub
End Class

Public Class FindAllStudentThatHasCheckedResult

    Public RegNumber As String
    Public ResultETransactPin As String
    Public Surname As String
    Public Firstname As String
    Public SessionName As String
    Public SemesterName As String
    Public LevelName As String
    Public Status As String
    Public Message As String
    Public Sub New(ByVal RegNumber As String, ByVal ResultETransactPin As String, ByVal Surname As String, ByVal Firstname As String, ByVal SessionName As String, _
                   ByVal SemesterName As String, ByVal LevelName As String, ByVal Status As String, ByVal Message As String)

        Me.RegNumber = RegNumber
        Me.ResultETransactPin = ResultETransactPin
        Me.Surname = Surname
        Me.Firstname = Firstname
        Me.SessionName = SessionName
        Me.SemesterName = SemesterName
        Me.LevelName = LevelName
        Me.Status = Status
        Me.Message = Message

    End Sub
End Class