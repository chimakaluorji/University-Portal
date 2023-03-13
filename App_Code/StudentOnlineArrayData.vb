Imports Microsoft.VisualBasic

Public Class StudentOnlineArrayData
    Public Property StudentOnlineTempID As String
    Public Property RegNumber As String
    Public Property RegID As String
    Public Property StudentName As String
    Public Property MsgCount As String
    Public Property PhotoUrl As String
    Public Property PhoneNumber As String

    Public Sub New()
    End Sub
    Public Sub New(ByVal StudentOnlineTempID As String, ByVal RegNumber As String, ByVal RegID As String, ByVal StudentName As String, ByVal MsgCount As String, ByVal PhotoUrl As String, ByVal PhoneNumber As String)
        Me.StudentOnlineTempID = StudentOnlineTempID
        Me.RegNumber = RegNumber
        Me.RegID = RegID
        Me.StudentName = StudentName
        Me.MsgCount = MsgCount
        Me.PhotoUrl = PhotoUrl
        Me.PhoneNumber = PhoneNumber
    End Sub
End Class
