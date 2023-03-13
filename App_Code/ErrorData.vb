Imports Microsoft.VisualBasic

Public Class ErrorData
    Private _ErrorCode As String
    Private _ErrorDetails As String

    Public Property ErrorCode() As String
        Get
            Return _ErrorCode
        End Get
        Set(ByVal value As String)
            _ErrorCode = value
        End Set
    End Property

    Public Property ErrorDetails() As String
        Get
            Return _ErrorDetails
        End Get
        Set(ByVal value As String)
            _ErrorDetails = value
        End Set
    End Property
End Class
