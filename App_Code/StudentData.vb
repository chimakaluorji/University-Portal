Imports Microsoft.VisualBasic

Public Class StudentData
    Private _StudentProfileID As Integer
    Private _RegNumber As String
    Private _Surname As String
    Private _FirstName As String
    Private _MiddleName As String
    Private _MothersMaidenName As String
    Private _DOB As String
    Private _Sex As String
    Private _StateName As String
    Private _LGAName As String
    Private _StateID As Integer
    Private _LGAID As Integer
    Private _HomeAddress As String
    Private _PhoneNumber As String
    Private _Email As String
    Private _NOKName As String
    Private _NOKPhoneNumber As String
    Private _NOKAddress As String
    Private _SessionName As String
    Private _Semester As String
    Private _Department As String
    Private _Programme As String
    Private _Level As String
    Private _SessionID As Integer
    Private _SemesterID As Integer
    Private _DepartmentID As Integer
    Private _ProgrammeID As Integer
    Private _LevelID As Integer
    Private _PhotoUrl As String
    Private _Passwords As String
    Private _SaltKey As String
    Private _LPS As String
    Private _LPSTo As String
    Private _LPSFrom As String
    Private _LSA As String
    Private _LSATo As String
    Private _LSAFrom As String

    Public Sub New()

    End Sub

    Public Property StudentProfileID() As Integer
        Get
            Return _StudentProfileID
        End Get
        Set(ByVal value As Integer)
            _StudentProfileID = value
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

    Public Property Surname() As String
        Get
            Return _Surname
        End Get
        Set(ByVal value As String)
            _Surname = value
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

    Public Property DOB() As String
        Get
            Return _DOB
        End Get
        Set(ByVal value As String)
            _DOB = value
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

    Public Property StateName() As String
        Get
            Return _StateName
        End Get
        Set(ByVal value As String)
            _StateName = value
        End Set
    End Property

    Public Property LGAName() As String
        Get
            Return _LGAName
        End Get
        Set(ByVal value As String)
            _LGAName = value
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

    Public Property LGAID() As Integer
        Get
            Return _LGAID
        End Get
        Set(ByVal value As Integer)
            _LGAID = value
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
            Return _PhotoUrl
        End Get
        Set(ByVal value As String)
            _PhotoUrl = value
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

    Public Property SaltKey() As String
        Get
            Return _SaltKey
        End Get
        Set(ByVal value As String)
            _SaltKey = value
        End Set
    End Property

    Public Property MothersMaidenName() As String
        Get
            Return _MothersMaidenName
        End Get
        Set(ByVal value As String)
            _MothersMaidenName = value
        End Set
    End Property

    Public Property HomeAddress() As String
        Get
            Return _HomeAddress
        End Get
        Set(ByVal value As String)
            _HomeAddress = value
        End Set
    End Property

    Public Property NOKName() As String
        Get
            Return _NOKName
        End Get
        Set(ByVal value As String)
            _NOKName = value
        End Set
    End Property

    Public Property NOKPhoneNumber() As String
        Get
            Return _NOKPhoneNumber
        End Get
        Set(ByVal value As String)
            _NOKPhoneNumber = value
        End Set
    End Property

    Public Property NOKAddress() As String
        Get
            Return _NOKAddress
        End Get
        Set(ByVal value As String)
            _NOKAddress = value
        End Set
    End Property

    Public Property SessionName() As String
        Get
            Return _SessionName
        End Get
        Set(ByVal value As String)
            _SessionName = value
        End Set
    End Property
    Public Property Semester() As String
        Get
            Return _Semester
        End Get
        Set(ByVal value As String)
            _Semester = value
        End Set
    End Property
    Public Property Department() As String
        Get
            Return _Department
        End Get
        Set(ByVal value As String)
            _Department = value
        End Set
    End Property

    Public Property Programme() As String
        Get
            Return _Programme
        End Get
        Set(ByVal value As String)
            _Programme = value
        End Set
    End Property

    Public Property Level() As String
        Get
            Return _Level
        End Get
        Set(ByVal value As String)
            _Level = value
        End Set
    End Property

    Public Property SessionID() As Integer
        Get
            Return _SessionID
        End Get
        Set(ByVal value As Integer)
            _SessionID = value
        End Set
    End Property
    Public Property SemesterID() As Integer
        Get
            Return _SemesterID
        End Get
        Set(ByVal value As Integer)
            _SemesterID = value
        End Set
    End Property
    Public Property DepartmentID() As Integer
        Get
            Return _DepartmentID
        End Get
        Set(ByVal value As Integer)
            _DepartmentID = value
        End Set
    End Property

    Public Property ProgrammeID() As Integer
        Get
            Return _ProgrammeID
        End Get
        Set(ByVal value As Integer)
            _ProgrammeID = value
        End Set
    End Property

    Public Property LevelID() As Integer
        Get
            Return _LevelID
        End Get
        Set(ByVal value As Integer)
            _LevelID = value
        End Set
    End Property

    Public Property LPS() As String
        Get
            Return _LPS
        End Get
        Set(ByVal value As String)
            _LPS = value
        End Set
    End Property

    Public Property LPSTo() As String
        Get
            Return _LPSTo
        End Get
        Set(ByVal value As String)
            _LPSTo = value
        End Set
    End Property

    Public Property LPSFrom() As String
        Get
            Return _LPSFrom
        End Get
        Set(ByVal value As String)
            _LPSFrom = value
        End Set
    End Property

    Public Property LSA() As String
        Get
            Return _LSA
        End Get
        Set(ByVal value As String)
            _LSA = value
        End Set
    End Property

    Public Property LSATo() As String
        Get
            Return _LSATo
        End Get
        Set(ByVal value As String)
            _LSATo = value
        End Set
    End Property

    Public Property LSAFrom() As String
        Get
            Return _LSAFrom
        End Get
        Set(ByVal value As String)
            _LSAFrom = value
        End Set
    End Property
End Class
