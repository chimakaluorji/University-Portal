Imports Microsoft.VisualBasic

Public Class AdminOnlineArrayData
    Public Property UserID As String
    Public Property RegID As String
    Public Property AdminName As String
    Public Property MsgCount As String
    Public Property PhotoUrl As String
    Public Property PhoneNo As String

    Public Sub New()
    End Sub
    Public Sub New(ByVal UserID As String, ByVal RegID As String, ByVal AdminName As String, ByVal MsgCount As String, ByVal PhotoUrl As String, ByVal PhoneNo As String)
        Me.UserID = UserID
        Me.RegID = RegID
        Me.AdminName = AdminName
        Me.MsgCount = MsgCount
        Me.PhotoUrl = PhotoUrl
        Me.PhoneNo = PhoneNo
    End Sub
End Class
