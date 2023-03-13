Imports Microsoft.VisualBasic

Public Class ePINArrayData

    Public Property ePINID As Integer
    Public Property ePIN As String
    Public Property RegNumber As String
    Public Property SessionName As String
    Public Property SemesterName As String
    Public Property LevelName As String
    Public Property Status As String
    Public Property SerialNo As String
    Public Sub New()
    End Sub
    Public Sub New(ByVal ePINID As Integer, ByVal ePIN As String, ByVal RegNumber As String, ByVal SessionName As String, _
                   ByVal SemesterName As String, ByVal LevelName As String, _
                   ByVal Status As String, ByVal SerialNo As String)

        Me.ePINID = ePINID
        Me.ePIN = ePIN
        Me.RegNumber = RegNumber
        Me.SessionName = SessionName
        Me.SemesterName = SemesterName
        Me.LevelName = LevelName
        Me.Status = Status
        Me.SerialNo = SerialNo

    End Sub
End Class
