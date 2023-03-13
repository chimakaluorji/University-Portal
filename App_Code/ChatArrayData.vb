Imports Microsoft.VisualBasic

Public Class ChatArrayData

    Public Property ChatID As Integer
    Public Property UserID As Integer
    Public Property RegNumber As String
    Public Property UserMsg As String
    Public Property StudentMsg As String
    Public Property UserName As String
    Public Property StudentName As String
    Public Property UserDate As String
    Public Property UserTime As String
    Public Property StudentDate As String
    Public Property StudentTime As String
    Public Sub New()
    End Sub
    Public Sub New(ByVal ChatID As Integer, UserID As Integer, ByVal RegNumber As String, ByVal UserMsg As String,
                   ByVal StudentMsg As String, ByVal UserName As String, ByVal StudentName As String, ByVal UserDate As String, _
                   ByVal UserTime As String, ByVal StudentDate As String, ByVal StudentTime As String)

        Me.ChatID = ChatID
        Me.UserID = UserID
        Me.RegNumber = RegNumber
        Me.UserMsg = UserMsg
        Me.StudentMsg = StudentMsg
        Me.UserName = UserName
        Me.StudentName = StudentName
        Me.UserDate = UserDate
        Me.UserTime = UserTime
        Me.StudentDate = StudentDate
        Me.StudentTime = StudentTime

    End Sub
End Class
