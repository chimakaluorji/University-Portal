Imports Microsoft.VisualBasic

Public Class TranLogData
    Private _TranLogID As Integer
    Private _TranCode As String
    Private _TranDate As DateTime
    Private _CreatedByUID As Integer
    Private _FirstName As String
    Public Property FirstName() As String
        Get
            Return _FirstName
        End Get
        Set(ByVal value As String)
            _FirstName = value
        End Set
    End Property

    Public Property CreatedByUID() As Integer
        Get
            Return _CreatedByUID
        End Get
        Set(ByVal value As Integer)
            _CreatedByUID = value
        End Set
    End Property

    Public Property TranDate() As DateTime
        Get
            Return _TranDate
        End Get
        Set(ByVal value As DateTime)
            _TranDate = value
        End Set
    End Property

    Public Property TranCode() As String
        Get
            Return _TranCode
        End Get
        Set(ByVal value As String)
            _TranCode = value
        End Set
    End Property

    Public Property TranLogID() As Integer
        Get
            Return _TranLogID
        End Get
        Set(ByVal value As Integer)
            _TranLogID = value
        End Set
    End Property

End Class
