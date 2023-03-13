Imports Microsoft.VisualBasic

Public Class ChatAdminArrayData
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
    Private _UserPhotoUrl As String
    Private _StudentPhotoUrl As String

    Public Sub New(ByVal ChatID As Integer, ByVal UserID As Integer, ByVal RegNumber As String, ByVal UserMsg As String, _
                   ByVal StudentMsg As String, ByVal UserName As String, ByVal StudentName As String, ByVal UserDate As String, _
                   ByVal UserTime As String, ByVal StudentDate As String, ByVal StudentTime As String, ByVal UserPhotoUrl As String, _
                   ByVal StudentPhotoUrl As String)

        Me.ChatID = ChatID
        Me.UserID = UserID
        Me.RegNumber = RegNumber
        Me.UserMsg = UserMsg
        Me.StudentMsg = StudentMsg
        Me.UserName = UserName
        Me.StudentName = StudentName
        Me.UserDate = UserDate
        Me.UserTime = UserTime
        Me.StudentDate = StudentDate
        Me.StudentTime = StudentTime
        Me.UserPhotoUrl = UserPhotoUrl
        Me.StudentPhotoUrl = StudentPhotoUrl

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
    Public Property UserPhotoUrl() As String
        Get
            Return _UserPhotoUrl
        End Get
        Set(ByVal value As String)
            _UserPhotoUrl = value
        End Set
    End Property
    Public Property StudentPhotoUrl() As String
        Get
            Return _StudentPhotoUrl
        End Get
        Set(ByVal value As String)
            _StudentPhotoUrl = value
        End Set
    End Property
End Class
