Imports Microsoft.VisualBasic

<Serializable()> Public Class LoginData
    Private _UserID As Integer
    Private _Surname As String
    Private _FirstName As String
    Private _LastName As String
    Private _Sex As String
    Private _StateID As Integer
    Private _LGAID As Integer
    Private _EmailAddress As String
    Private _PhoneNumber As String
    Private _PhotoURL As String
    Private _UserName As String
    Private _Passwords As String
    Private _SaltKey As String
    Private _NewSaltKey As String
    Private _RegNumber As String
    Private _PriviledgeID As String
    Private _GuardianPhoneNumber As String

    Public Sub New()

    End Sub

    Public Property UserID() As Integer
        Get
            Return _UserID
        End Get
        Set(ByVal value As Integer)
            _UserID = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return _LastName
        End Get
        Set(ByVal value As String)
            _LastName = value
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return _FirstName
        End Get
        Set(ByVal value As String)
            _FirstName = value
        End Set
    End Property

    Public Property Surname() As String
        Get
            Return _Surname
        End Get
        Set(ByVal value As String)
            _Surname = value
        End Set
    End Property

    Public Property SaltKey() As String
        Get
            Return _SaltKey
        End Get
        Set(ByVal value As String)
            _SaltKey = value
        End Set
    End Property

    Public Property NewSaltKey() As String
        Get
            Return _NewSaltKey
        End Get
        Set(ByVal value As String)
            _NewSaltKey = value
        End Set
    End Property

    Public Property LGAID() As Integer
        Get
            Return _LGAID
        End Get
        Set(ByVal value As Integer)
            _LGAID = value
        End Set
    End Property

    Public Property EmailAddress() As String
        Get
            Return _EmailAddress
        End Get
        Set(ByVal value As String)
            _EmailAddress = value
        End Set
    End Property

    Public Property PhoneNumber() As String
        Get
            Return _PhoneNumber
        End Get
        Set(ByVal value As String)
            _PhoneNumber = value
        End Set
    End Property

    Public Property PhotoURL() As String
        Get
            Return _PhotoURL
        End Get
        Set(ByVal value As String)
            _PhotoURL = value
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

    Public Property Passwords() As String
        Get
            Return _Passwords
        End Get
        Set(ByVal value As String)
            _Passwords = value
        End Set
    End Property

    Public Property PriviledgeID() As Integer
        Get
            Return _PriviledgeID
        End Get
        Set(ByVal value As Integer)
            _PriviledgeID = value
        End Set
    End Property

    Public Property Sex() As String
        Get
            Return _Sex
        End Get
        Set(ByVal value As String)
            _Sex = value
        End Set
    End Property

    Public Property StateID() As Integer
        Get
            Return _StateID
        End Get
        Set(ByVal value As Integer)
            _StateID = value
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

    Public Property GuardianPhoneNumber() As String
        Get
            Return _GuardianPhoneNumber
        End Get
        Set(ByVal value As String)
            _GuardianPhoneNumber = value
        End Set
    End Property

End Class
