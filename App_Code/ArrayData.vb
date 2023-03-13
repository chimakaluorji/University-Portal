Imports Microsoft.VisualBasic

Public Class ArrayData
    Public Property FileID As Integer
    Public Property FileName As String
    Public Sub New()
    End Sub
    Public Sub New(ByVal FileName As String, ByVal FileID As Integer)
        Me.FileID = FileID
        Me.FileName = FileName
    End Sub
End Class
