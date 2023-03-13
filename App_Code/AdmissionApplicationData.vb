Imports Microsoft.VisualBasic

Public Class AdmissionApplicationData
    Private _AppAcknowledgeNo As String
    Private _Surname As String
    Private _FirstName As String
    Private _MiddleName As String
    Private _FacultyID As Integer
    Private _DeptID As Integer
    Private _QualifID As Integer
    Private _FirstChoice As String
    Private _SecondChoice As String
    Private _JAMBRegNo As String
    Private _DateofBirth As DateTime
    Private _Gender As String
    Private _MaritalStatus As String
    Private _Address As String
    Private _Email As String
    Private _PhoneNo As String
    Private _CountryID As Integer
    Private _StateID As Integer
    Private _LGAID As Integer
    Private _PlaceOfWork As String
    Private _Religion As String
    Private _NextOfKin As String
    Private _NextofKinAddress As String
    Private _SponsorName As String
    Private _SponsorOccupation As String
    Private _SponsorAddress As String
    Private _SponsorPhone As String
    Private _Status As Char
    Private _MothersMaidenName As String
    Public Property MothersMaidenName() As String
        Get
            Return _MothersMaidenName
        End Get
        Set(ByVal value As String)
            _MothersMaidenName = value
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

    Public Property SponsorPhone() As String
        Get
            Return _SponsorPhone
        End Get
        Set(ByVal value As String)
            _SponsorPhone = value
        End Set
    End Property

    Public Property SponsorAddress() As String
        Get
            Return _SponsorAddress
        End Get
        Set(ByVal value As String)
            _SponsorAddress = value
        End Set
    End Property

    Public Property SponsorOccupation() As String
        Get
            Return _SponsorOccupation
        End Get
        Set(ByVal value As String)
            _SponsorOccupation = value
        End Set
    End Property

    Public Property SponsorName() As String
        Get
            Return _SponsorName
        End Get
        Set(ByVal value As String)
            _SponsorName = value
        End Set
    End Property

    Public Property NextofKinAddress() As String
        Get
            Return _NextofKinAddress
        End Get
        Set(ByVal value As String)
            _NextofKinAddress = value
        End Set
    End Property

    Public Property NextOfKin() As String
        Get
            Return _NextOfKin
        End Get
        Set(ByVal value As String)
            _NextOfKin = value
        End Set
    End Property

    Public Property Religion() As String
        Get
            Return _Religion
        End Get
        Set(ByVal value As String)
            _Religion = value
        End Set
    End Property

    Public Property PlaceOfWork() As String
        Get
            Return _PlaceOfWork
        End Get
        Set(ByVal value As String)
            _PlaceOfWork = value
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

    Public Property StateID() As Integer
        Get
            Return _StateID
        End Get
        Set(ByVal value As Integer)
            _StateID = value
        End Set
    End Property

    Public Property CountryID() As Integer
        Get
            Return _CountryID
        End Get
        Set(ByVal value As Integer)
            _CountryID = value
        End Set
    End Property

    Public Property PhoneNo() As String
        Get
            Return _PhoneNo
        End Get
        Set(ByVal value As String)
            _PhoneNo = value
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

    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property

    Public Property MaritalStatus() As String
        Get
            Return _MaritalStatus
        End Get
        Set(ByVal value As String)
            _MaritalStatus = value
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

    Public Property DateofBirth() As DateTime
        Get
            Return _DateofBirth
        End Get
        Set(ByVal value As DateTime)
            _DateofBirth = value
        End Set
    End Property

    Public Property JAMBRegNo() As String
        Get
            Return _JAMBRegNo
        End Get
        Set(ByVal value As String)
            _JAMBRegNo = value
        End Set
    End Property

    Public Property SecondChoice() As String
        Get
            Return _SecondChoice
        End Get
        Set(ByVal value As String)
            _SecondChoice = value
        End Set
    End Property

    Public Property FirstChoice() As String
        Get
            Return _FirstChoice
        End Get
        Set(ByVal value As String)
            _FirstChoice = value
        End Set
    End Property

    Public Property QualifID() As Integer
        Get
            Return _QualifID
        End Get
        Set(ByVal value As Integer)
            _QualifID = value
        End Set
    End Property

    Public Property DeptID() As Integer
        Get
            Return _DeptID
        End Get
        Set(ByVal value As Integer)
            _DeptID = value
        End Set
    End Property

    Public Property FacultyID() As Integer
        Get
            Return _FacultyID
        End Get
        Set(ByVal value As Integer)
            _FacultyID = value
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

    Public Property AppAcknowledgeNo() As String
        Get
            Return _AppAcknowledgeNo
        End Get
        Set(ByVal value As String)
            _AppAcknowledgeNo = value
        End Set
    End Property

End Class
