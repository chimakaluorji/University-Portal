Imports Microsoft.VisualBasic

Public Class ZoneData

    Private _ZoneID As Integer
    Private _ZoneName As String
    Public Property ZoneID() As Integer
        Get
            Return _ZoneID
        End Get
        Set(ByVal value As Integer)
            _ZoneID = value
        End Set
    End Property

    Public Property ZoneName() As String
        Get
            Return _ZoneName
        End Get
        Set(ByVal value As String)
            _ZoneName = value
        End Set
    End Property
End Class
