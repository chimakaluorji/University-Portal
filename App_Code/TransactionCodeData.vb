Imports Microsoft.VisualBasic

Public Class TransactionCodeData

    Private _TransCodeID As Integer
    Private _TransCode As String
    Private _Description As String

    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Public Property TransCode() As String
        Get
            Return _TransCode
        End Get
        Set(ByVal value As String)
            _TransCode = value
        End Set
    End Property

    Public Property TransCodeID() As Integer
        Get
            Return _TransCodeID
        End Get
        Set(ByVal value As Integer)
            _TransCodeID = value
        End Set
    End Property

End Class
