Imports Microsoft.VisualBasic

Public Class HostelApplicationFormData
    Private _RegNumber As String
    Private _Surname As String
    Private _FirstName As String
    Private _MiddleName As String
    Private _Gender As String
    Private _Nationality As String
    Private _State As String
    Private _LGA As String
    Private _HomeAddress As String
    Private _PhoneNumber As String
    Private _Email As String
    Private _Dept As String
    Private _Programme As String
    Private _Level As String
    Private _Session As String
    Private _NationalityID As Integer
    Private _StateID As Integer
    Private _LGAID As Integer
    Private _DeptID As Integer
    Private _ProgrammeID As Integer
    Private _LevelID As Integer
    Private _SessionID As Integer
    Private _CreatedByRegNo As String
    Private _DesiredHostelResidentID As Integer
    Private _SubscriptionPlanID As Integer
    Private _DescriptionID As Integer
    Private _HostelNameID As Integer
    Private _FloorPositionID As Integer
    Private _RoomNameID As Integer
    Private _HostelName As String
    Private _FloorPosition As String
    Private _RoomName As String
    Private _Description As String
    Private _SubscriptionPlan As String
    Private _DesiredHostelResident As String
    Private _HostelSubscriptionID As Integer
    Private _CBoxInclusive As Char
    Private _CBoxRoommate As Char
    Private _Accomodation As String
    Private _TypeOfAccomodation As String
    Private _NameOfHostel As String
    Private _DescriptionOfRoom As String
    Private _FloorName As String
    Private _Amount As Decimal
    Private _DateTime As String
    Private _Message As String
    Private _Approved As Char
    Private _Comment As String
    Private _CBoxInclusiveString As String
    Private _CBoxRoommateString As String
    Private _DomainID As Integer
    Private _SelectedNode As String
    Private _ReturnedValue As String
    Private _Semester As String
    Private _SemesterID As Integer

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
    Public Property Gender() As String
        Get
            Return _Gender
        End Get
        Set(ByVal value As String)
            _Gender = value
        End Set
    End Property
    Public Property Nationality() As String
        Get
            Return _Nationality
        End Get
        Set(ByVal value As String)
            _Nationality = value
        End Set
    End Property

    Public Property State() As String
        Get
            Return _State
        End Get
        Set(ByVal value As String)
            _State = value
        End Set
    End Property

    Public Property LGA() As String
        Get
            Return _LGA
        End Get
        Set(ByVal value As String)
            _LGA = value
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
    Public Property Dept() As String
        Get
            Return _Dept
        End Get
        Set(ByVal value As String)
            _Dept = value
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
    Public Property Session() As String
        Get
            Return _Session
        End Get
        Set(ByVal value As String)
            _Session = value
        End Set
    End Property
    Public Property NationalityID() As Integer
        Get
            Return _NationalityID
        End Get
        Set(ByVal value As Integer)
            _NationalityID = value
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

    Public Property DeptID() As Integer
        Get
            Return _DeptID
        End Get
        Set(ByVal value As Integer)
            _DeptID = value
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

    Public Property SessionID() As Integer
        Get
            Return _SessionID
        End Get
        Set(ByVal value As Integer)
            _SessionID = value
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
    Public Property CreatedByRegNo() As String
        Get
            Return _CreatedByRegNo
        End Get
        Set(ByVal value As String)
            _CreatedByRegNo = value
        End Set
    End Property
    Public Property DesiredHostelResidentID() As Integer
        Get
            Return _DesiredHostelResidentID
        End Get
        Set(ByVal value As Integer)
            _DesiredHostelResidentID = value
        End Set
    End Property
    Public Property DescriptionID() As Integer
        Get
            Return _DescriptionID
        End Get
        Set(ByVal value As Integer)
            _DescriptionID = value
        End Set
    End Property
    Public Property SubscriptionPlanID() As Integer
        Get
            Return _SubscriptionPlanID
        End Get
        Set(ByVal value As Integer)
            _SubscriptionPlanID = value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property
    Public Property SubscriptionPlan() As String
        Get
            Return _SubscriptionPlan
        End Get
        Set(ByVal value As String)
            _SubscriptionPlan = value
        End Set
    End Property
    Public Property DesiredHostelResident() As String
        Get
            Return _DesiredHostelResident
        End Get
        Set(ByVal value As String)
            _DesiredHostelResident = value
        End Set
    End Property
    Public Property HostelSubscriptionID() As Integer
        Get
            Return _HostelSubscriptionID
        End Get
        Set(ByVal value As Integer)
            _HostelSubscriptionID = value
        End Set
    End Property
    Public Property CBoxInclusive() As Char
        Get
            Return _CBoxInclusive
        End Get
        Set(ByVal value As Char)
            _CBoxInclusive = value
        End Set
    End Property
    Public Property CBoxRoommate() As Char
        Get
            Return _CBoxRoommate
        End Get
        Set(ByVal value As Char)
            _CBoxRoommate = value
        End Set
    End Property
    Public Property Accomodation() As String
        Get
            Return _Accomodation
        End Get
        Set(ByVal value As String)
            _Accomodation = value
        End Set
    End Property
    Public Property TypeOfAccomodation() As String
        Get
            Return _TypeOfAccomodation
        End Get
        Set(ByVal value As String)
            _TypeOfAccomodation = value
        End Set
    End Property
    Public Property NameOfHostel() As String
        Get
            Return _NameOfHostel
        End Get
        Set(ByVal value As String)
            _NameOfHostel = value
        End Set
    End Property
    Public Property DescriptionOfRoom() As String
        Get
            Return _DescriptionOfRoom
        End Get
        Set(ByVal value As String)
            _DescriptionOfRoom = value
        End Set
    End Property
    Public Property FloorName() As String
        Get
            Return _FloorName
        End Get
        Set(ByVal value As String)
            _FloorName = value
        End Set
    End Property
   
    Public Property Amount() As Decimal
        Get
            Return _Amount
        End Get
        Set(ByVal value As Decimal)
            _Amount = value
        End Set
    End Property
    Public Property DateTime() As String
        Get
            Return _DateTime
        End Get
        Set(ByVal value As String)
            _DateTime = value
        End Set
    End Property
    Public Property Message() As String
        Get
            Return _Message
        End Get
        Set(ByVal value As String)
            _Message = value
        End Set
    End Property
    Public Property Approved() As Char
        Get
            Return _Approved
        End Get
        Set(ByVal value As Char)
            _Approved = value
        End Set
    End Property
    Public Property Comment() As String
        Get
            Return _Comment
        End Get
        Set(ByVal value As String)
            _Comment = value
        End Set
    End Property
    Public Property CBoxInclusiveString() As String
        Get
            Return _CBoxInclusiveString
        End Get
        Set(ByVal value As String)
            _CBoxInclusiveString = value
        End Set
    End Property
    Public Property CBoxRoommateString() As String
        Get
            Return _CBoxRoommateString
        End Get
        Set(ByVal value As String)
            _CBoxRoommateString = value
        End Set
    End Property
    Public Property DomainID() As Integer
        Get
            Return _DomainID
        End Get
        Set(ByVal value As Integer)
            _DomainID = value
        End Set
    End Property
    Public Property SelectedNode() As String
        Get
            Return _SelectedNode
        End Get
        Set(ByVal value As String)
            _SelectedNode = value
        End Set
    End Property
    Public Property ReturnedValue() As String
        Get
            Return _ReturnedValue
        End Get
        Set(ByVal value As String)
            _ReturnedValue = value
        End Set
    End Property
    Public Property HostelNameID() As Integer
        Get
            Return _HostelNameID
        End Get
        Set(ByVal value As Integer)
            _HostelNameID = value
        End Set
    End Property
    Public Property FloorPositionID() As Integer
        Get
            Return _FloorPositionID
        End Get
        Set(ByVal value As Integer)
            _FloorPositionID = value
        End Set
    End Property
    Public Property RoomNameID() As Integer
        Get
            Return _RoomNameID
        End Get
        Set(ByVal value As Integer)
            _RoomNameID = value
        End Set
    End Property
    Public Property HostelName() As String
        Get
            Return _HostelName
        End Get
        Set(ByVal value As String)
            _HostelName = value
        End Set
    End Property
    Public Property FloorPosition() As String
        Get
            Return _FloorPosition
        End Get
        Set(ByVal value As String)
            _FloorPosition = value
        End Set
    End Property
    Public Property RoomName() As String
        Get
            Return _RoomName
        End Get
        Set(ByVal value As String)
            _RoomName = value
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
    Public Property SemesterID() As Integer
        Get
            Return _SemesterID
        End Get
        Set(ByVal value As Integer)
            _SemesterID = value
        End Set
    End Property
End Class
