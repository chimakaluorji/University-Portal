Imports Microsoft.VisualBasic

Public Class ReligionData

    Private _ReligionID As Integer
    Private _ReligionName As String
    Public Property ReligionID() As Integer
        Get
            Return _ReligionID
        End Get
        Set(ByVal value As Integer)
            _ReligionID = value
        End Set
    End Property

    Public Property ReligionName() As String
        Get
            Return _ReligionName
        End Get
        Set(ByVal value As String)
            _ReligionName = value
        End Set
    End Property
End Class
