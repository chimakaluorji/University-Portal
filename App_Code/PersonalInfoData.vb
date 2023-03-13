Imports Microsoft.VisualBasic

Public Class PersonalInfoData
    Private _PersonalInfoID As Integer
    Private _Surname As String
    Private _FirstName As String
    Private _MiddleName As String
    Private _MaidenName As String
    Private _Gender As String
    Private _DateOfBirth As String
    Private _StateOfOriginID As Integer
    Private _LGAID As Integer
    Private _ZoneOfOriginID As Integer
    Private _ReligionID As Integer
    Private _PhoneNumber As String
    Private _Email As String
    Private _PermanentAddress As String
    Private _Status As Char
    Private _CreatedByUID As Integer

    Public Property PersonalInfoID() As Integer
        Get
            Return _PersonalInfoID
        End Get
        Set(ByVal value As Integer)
            _PersonalInfoID = value
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
    Public Property FirstName() As String
        Get
            Return _FirstName
        End Get
        Set(ByVal value As String)
            _FirstName = value
        End Set
    End Property
    Public Property MiddleName() As String
        Get
            Return _MiddleName
        End Get
        Set(ByVal value As String)
            _MiddleName = value
        End Set
    End Property
    Public Property MaidenName() As String
        Get
            Return _MaidenName
        End Get
        Set(ByVal value As String)
            _MaidenName = value
        End Set
    End Property
    Public Property Gender() As String
        Get
            Return _Gender
        End Get
        Set(ByVal value As String)
            _Gender = value
        End Set
    End Property
    Public Property DateOfBirth() As String
        Get
            Return _DateOfBirth
        End Get
        Set(ByVal value As String)
            _DateOfBirth = value
        End Set
    End Property
    Public Property StateOfOriginID() As Integer
        Get
            Return _StateOfOriginID
        End Get
        Set(ByVal value As Integer)
            _StateOfOriginID = value
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
    Public Property ZoneOfOriginID() As Integer
        Get
            Return _ZoneOfOriginID
        End Get
        Set(ByVal value As Integer)
            _ZoneOfOriginID = value
        End Set
    End Property
    Public Property ReligionID() As Integer
        Get
            Return _ReligionID
        End Get
        Set(ByVal value As Integer)
            _ReligionID = value
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
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property
    Public Property PermanentAddress() As String
        Get
            Return _PermanentAddress
        End Get
        Set(ByVal value As String)
            _PermanentAddress = value
        End Set
    End Property
    Public Property Status() As Char
        Get
            Return _Status
        End Get
        Set(ByVal value As Char)
            _Status = value
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
End Class
