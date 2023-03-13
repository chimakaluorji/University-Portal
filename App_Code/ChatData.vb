Imports Microsoft.VisualBasic

Public Class ChatData
    Private _ChatID As Integer
    Private _UserID As Integer
    Private _RegNumber As String
    Private _UserMsg As String
    Private _StudentMsg As String
    Private _UserName As String
    Private _StudentName As String
    Private _UserDate As String
    Private _UserTime As String
    Private _StudentDate As String
    Private _StudentTime As String
    Private _HaveRead As String
    Public Sub New()

    End Sub

    Public Property ChatID() As Integer
        Get
            Return _ChatID
        End Get
        Set(ByVal value As Integer)
            _ChatID = value
        End Set
    End Property
    Public Property UserID() As Integer
        Get
            Return _UserID
        End Get
        Set(ByVal value As Integer)
            _UserID = value
        End Set
    End Property

    Public Property RegNumber() As String
        Get
            Return _RegNumber
        End Get
        Set(ByVal value As String)
            _RegNumber = value
        End Set
    End Property
    Public Property UserMsg() As String
        Get
            Return _UserMsg
        End Get
        Set(ByVal value As String)
            _UserMsg = value
        End Set
    End Property

    Public Property StudentMsg() As String
        Get
            Return _StudentMsg
        End Get
        Set(ByVal value As String)
            _StudentMsg = value
        End Set
    End Property


    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property

    Public Property StudentName() As String
        Get
            Return _StudentName
        End Get
        Set(ByVal value As String)
            _StudentName = value
        End Set
    End Property

    Public Property UserDate() As String
        Get
            Return _UserDate
        End Get
        Set(ByVal value As String)
            _UserDate = value
        End Set
    End Property

    Public Property UserTime() As String
        Get
            Return _UserTime
        End Get
        Set(ByVal value As String)
            _UserTime = value
        End Set
    End Property
    Public Property StudentDate() As String
        Get
            Return _StudentDate
        End Get
        Set(ByVal value As String)
            _StudentDate = value
        End Set
    End Property

    Public Property StudentTime() As String
        Get
            Return _StudentTime
        End Get
        Set(ByVal value As String)
            _StudentTime = value
        End Set
    End Property

    Public Property HaveRead() As String
        Get
            Return _HaveRead
        End Get
        Set(ByVal value As String)
            _HaveRead = value
        End Set
    End Property

End Class
