Imports Microsoft.VisualBasic

Public Class TranPinData
    Private _TRANSACTION_ID As Integer
    Private _CONFIRMATION_NO As String
    Private _REG_NO As String
    Private _RECEIPT_NO As String
    Private _SUCCESS As Integer
    Private _AMOUNT As Double
    Private _TRAN_ST_TIME As Date
    Private _TRAN_END_TIME As Date
    Private _SESSION_NAME As String


    Public Property TRANSACTION_ID() As Integer
        Get
            Return _TRANSACTION_ID
        End Get
        Set(ByVal value As Integer)
            _TRANSACTION_ID = value
        End Set
    End Property
    Public Property SESSION_NAME() As String
        Get
            Return _SESSION_NAME
        End Get
        Set(ByVal value As String)
            _SESSION_NAME = value
        End Set
    End Property

    Public Property CONFIRMATION_NO() As String
        Get
            Return _CONFIRMATION_NO
        End Get
        Set(ByVal value As String)
            _CONFIRMATION_NO = value
        End Set
    End Property

    Public Property REG_NO() As String
        Get
            Return _REG_NO
        End Get
        Set(ByVal value As String)
            _REG_NO = value
        End Set
    End Property

    Public Property RECEIPT_NO() As String
        Get
            Return _RECEIPT_NO
        End Get
        Set(ByVal value As String)
            _RECEIPT_NO = value
        End Set
    End Property

    Public Property SUCCESS() As Integer
        Get
            Return _SUCCESS
        End Get
        Set(ByVal value As Integer)
            _SUCCESS = value
        End Set
    End Property

    Public Property AMOUNT() As Double
        Get
            Return _AMOUNT
        End Get
        Set(ByVal value As Double)
            _AMOUNT = value
        End Set
    End Property

    Public Property TRAN_ST_TIME() As Date
        Get
            Return _TRAN_ST_TIME
        End Get
        Set(ByVal value As Date)
            _TRAN_ST_TIME = value
        End Set
    End Property

    Public Property TRAN_END_TIME() As Date
        Get
            Return _TRAN_END_TIME
        End Get
        Set(ByVal value As Date)
            _TRAN_END_TIME = value
        End Set
    End Property
End Class
