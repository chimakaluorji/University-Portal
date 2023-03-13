Imports Microsoft.VisualBasic

Public Class InstitutionData

    Private _InstitutionID As Integer
    Private _InstitutionName As String
    Public Property InstitutionID() As Integer
        Get
            Return _InstitutionID
        End Get
        Set(ByVal value As Integer)
            _InstitutionID = value
        End Set
    End Property

    Public Property InstitutionName() As String
        Get
            Return _InstitutionName
        End Get
        Set(ByVal value As String)
            _InstitutionName = value
        End Set
    End Property
End Class
