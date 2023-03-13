Imports Microsoft.VisualBasic

Public Class StudentArrayData
    Public Property StudentProfileID As Integer
    Public Property RegNumber As String
    Public Property Surname As String
    Public Property FirstName As String
    Public Property SessionID As Integer
    Public Property SessionName As String
    Public Property SemesterID As Integer
    Public Property Semester As String
    Public Property LevelID As Integer
    Public Property Level As String

    Public Sub New(ByVal StudentProfileID As String, ByVal RegNumber As String, ByVal Surname As String, ByVal FirstName As String, _
                   ByVal SessionID As Integer, ByVal SessionName As String, ByVal SemesterID As Integer, _
                   ByVal Semester As String, ByVal LevelID As Integer, ByVal Level As String)

        Me.StudentProfileID = StudentProfileID
        Me.RegNumber = RegNumber
        Me.Surname = Surname
        Me.FirstName = FirstName
        Me.SessionID = SessionID
        Me.SessionName = SessionName
        Me.SemesterID = SemesterID
        Me.Semester = Semester
        Me.LevelID = LevelID
        Me.Level = Level

    End Sub
End Class
