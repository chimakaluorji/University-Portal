Imports Microsoft.VisualBasic

Public Class PostUmeSetupData
    Private _PostUmeAdmissionSetupID As Integer
    Private _MeritScore As Decimal
    Private _CatchmentAreaCutOff As Decimal
    Private _FacultyRideIn As Decimal
    Private _CreatedByUID As Integer
    Private _FacultyName As String
    Private _FacultyID As Integer
    Private _DeptName As String
    Private _DeptID As Integer
    Public Property CreatedByUID() As Integer
        Get
            Return _CreatedByUID
        End Get
        Set(ByVal value As Integer)
            _CreatedByUID = value
        End Set
    End Property

    Public Property FacultyRideIn() As Decimal
        Get
            Return _FacultyRideIn
        End Get
        Set(ByVal value As Decimal)
            _FacultyRideIn = value
        End Set
    End Property

    Public Property CatchmentAreaCutOff() As Decimal
        Get
            Return _CatchmentAreaCutOff
        End Get
        Set(ByVal value As Decimal)
            _CatchmentAreaCutOff = value
        End Set
    End Property

    Public Property MeritScore() As Decimal
        Get
            Return _MeritScore
        End Get
        Set(ByVal value As Decimal)
            _MeritScore = value
        End Set
    End Property

    Public Property PostUmeAdmissionSetupID() As Integer
        Get
            Return _PostUmeAdmissionSetupID
        End Get
        Set(ByVal value As Integer)
            _PostUmeAdmissionSetupID = value
        End Set
    End Property
    Public Property FacultyName() As String
        Get
            Return _FacultyName
        End Get
        Set(ByVal value As String)
            _FacultyName = value
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
    Public Property DeptName() As String
        Get
            Return _DeptName
        End Get
        Set(ByVal value As String)
            _DeptName = value
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
End Class

