Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class Admin_AdminViewStudentProfile
    Inherits System.Web.UI.Page
    <WebMethod()> _
    Public Shared Function GetStudent(ByVal SessionID As String, ByVal LevelID As String) As ArrayList
        'Instance declaration 
        Dim QueueList As New ArrayList


        Dim intSessionID As Integer = CInt(SessionID)
        Dim intLevelID As Integer = CInt(LevelID)

        Dim SeDal As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL
        Dim RetDat As DataSet = SeDal.FindAllStudentBySessionIDSemesterID(intSessionID, intLevelID)

        Dim row1 As String = ""
        Dim row2 As String = ""
        Dim row3 As String = ""
        Dim row4 As String = ""

        For Each row As DataRow In RetDat.Tables(0).Rows
            If Not IsDBNull(row(0)) Then
                row1 = row(0)
            End If
            If Not IsDBNull(row(1)) Then
                row2 = row(1)
            End If
            If Not IsDBNull(row(2)) Then
                row3 = row(2)
            End If
            If Not IsDBNull(row(3)) Then
                row4 = row(3)
            End If

            QueueList.Add(New FindAllStudentArrayData(row1, row2, row3, row4))
        Next

        Return QueueList

    End Function

    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim ar As New ArrayList
    '    ar = GetStudent("6", "1")

    '    Label1.Text = ar.Item(0).MoveStudentDataID & ar.Item(0).RegNumber & ar.Item(0).Surname & ar.Item(0).Firstname
    'End Sub

    <WebMethod()> _
    <ScriptMethod()> _
    Public Shared Function GetStudentRegNo(ByVal ERegNumberSearch As String) As Array
        Dim msg As String() = {"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}

        'Intantiate objects for accessing User Data and Business Layers
        Dim StudentDal As StudentDAL = New StudentDAL
        Dim StudentData As StudentData = New StudentData

        StudentData = StudentDal.FindStudentByRegNo(ERegNumberSearch)
        If StudentData IsNot Nothing Then
            msg(0) = StudentData.RegNumber
            msg(1) = StudentData.Surname
            msg(2) = StudentData.FirstName
            msg(3) = StudentData.MiddleName
            msg(4) = StudentData.MothersMaidenName
            msg(5) = StudentData.DOB
            msg(6) = StudentData.Sex
            msg(7) = StudentData.StateName
            msg(8) = StudentData.LGAName
            msg(9) = StudentData.HomeAddress
            msg(10) = StudentData.PhoneNumber
            msg(11) = StudentData.Email
            msg(12) = StudentData.NOKName
            msg(13) = StudentData.SessionName
            msg(14) = StudentData.Semester
            msg(15) = StudentData.Level
            msg(16) = StudentData.LPS
            msg(17) = StudentData.LPSFrom
            msg(18) = StudentData.LPSTo
            msg(19) = StudentData.LSA
            msg(20) = StudentData.LSAFrom
            msg(21) = StudentData.LSATo
            msg(22) = StudentData.PhotoURL
        Else
            msg(0) = "Nothing"
            msg(1) = ""
            msg(2) = ""
            msg(3) = ""
            msg(4) = ""
            msg(5) = ""
            msg(6) = ""
            msg(7) = ""
            msg(8) = ""
            msg(9) = ""
            msg(10) = ""
            msg(11) = ""
            msg(12) = ""
            msg(13) = ""
            msg(14) = ""
            msg(15) = ""
            msg(16) = ""
            msg(17) = ""
            msg(18) = ""
            msg(19) = ""
            msg(20) = ""
            msg(21) = ""
            msg(22) = ""
        End If


        Return msg
    End Function
End Class
Public Class FindAllStudentArrayData

    Public MoveStudentDataID As Integer
    Public RegNumber As String
    Public Surname As String
    Public Firstname As String
    Public Sub New(ByVal MoveStudentDataID As Integer, ByVal RegNumber As String, ByVal Surname As String, ByVal Firstname As String)

        Me.MoveStudentDataID = MoveStudentDataID
        Me.RegNumber = RegNumber
        Me.Surname = Surname
        Me.Firstname = Firstname

    End Sub
End Class