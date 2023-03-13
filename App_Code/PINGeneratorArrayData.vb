Imports Microsoft.VisualBasic

Public Class PINGeneratorArrayData
    Private _Serial As String
    Private _PIN As String
    Public Sub New()
    End Sub
    Public Sub New(ByVal Serial As String, ByVal PIN As String)
        Me.Serial = Serial
        Me.PIN = PIN
    End Sub

    Public Property Serial() As Integer
        Get
            Return _Serial
        End Get
        Set(ByVal value As Integer)
            _Serial = value
        End Set
    End Property
    Public Property PIN() As String
        Get
            Return _PIN
        End Get
        Set(ByVal value As String)
            _PIN = value
        End Set
    End Property
End Class
