Imports Microsoft.VisualBasic

Public Class TransactionLogData
    Private _TransactionLogID As Integer
    Private _TransactionCodeID As Integer
    Private _TransactionCode As String
    Private _Activity As String

    Public Property TransactionLogID() As Integer
        Get
            Return _TransactionLogID
        End Get
        Set(ByVal value As Integer)
            _TransactionLogID = value
        End Set
    End Property
    Public Property TransactionCodeID() As Integer
        Get
            Return _TransactionCodeID
        End Get
        Set(ByVal value As Integer)
            _TransactionCodeID = value
        End Set
    End Property
    Public Property TransactionCode() As String
        Get
            Return _TransactionCode
        End Get
        Set(ByVal value As String)
            _TransactionCode = value
        End Set
    End Property
    Public Property Activity() As String
        Get
            Return _Activity
        End Get
        Set(ByVal value As String)
            _Activity = value
        End Set
    End Property

End Class
