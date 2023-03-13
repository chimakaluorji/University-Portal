Imports Microsoft.VisualBasic

Public Class JobDescriptionData
    Private _JobDescriptionID As Integer
    Private _PersonalInformationID As Integer
    Private _YearOfService As String
    Private _CurrentJobTitle As String
    Private _GradeLevelID As Integer
    Private _TypeOfStaff As String
    Private _FacultyID As Integer
    Private _DepartmentID As Integer
    Private _InstitutionOfServiceID As Integer
    Private _SpecializationOfTeacher As String
    Private _CurrentCourse As String
    Private _CouldCourse As String
    Private _CreatedByUID As Integer

    Public Property JobDescriptionID() As Integer
        Get
            Return _JobDescriptionID
        End Get
        Set(ByVal value As Integer)
            _JobDescriptionID = value
        End Set
    End Property
    Public Property PersonalInformationID() As Integer
        Get
            Return _PersonalInformationID
        End Get
        Set(ByVal value As Integer)
            _PersonalInformationID = value
        End Set
    End Property
    Public Property YearOfService() As String
        Get
            Return _YearOfService
        End Get
        Set(ByVal value As String)
            _YearOfService = value
        End Set
    End Property
    Public Property CurrentJobTitle() As String
        Get
            Return _CurrentJobTitle
        End Get
        Set(ByVal value As String)
            _CurrentJobTitle = value
        End Set
    End Property
    Public Property GradeLevelID() As Integer
        Get
            Return _GradeLevelID
        End Get
        Set(ByVal value As Integer)
            _GradeLevelID = value
        End Set
    End Property
    Public Property TypeOfStaff() As String
        Get
            Return _TypeOfStaff
        End Get
        Set(ByVal value As String)
            _TypeOfStaff = value
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
    Public Property DepartmentID() As Integer
        Get
            Return _DepartmentID
        End Get
        Set(ByVal value As Integer)
            _DepartmentID = value
        End Set
    End Property
    Public Property InstitutionOfServiceID() As Integer
        Get
            Return _InstitutionOfServiceID
        End Get
        Set(ByVal value As Integer)
            _InstitutionOfServiceID = value
        End Set
    End Property
    Public Property SpecializationOfTeacher() As String
        Get
            Return _SpecializationOfTeacher
        End Get
        Set(ByVal value As String)
            _SpecializationOfTeacher = value
        End Set
    End Property
    Public Property CurrentCourse() As String
        Get
            Return _CurrentCourse
        End Get
        Set(ByVal value As String)
            _CurrentCourse = value
        End Set
    End Property
    Public Property CouldCourse() As String
        Get
            Return _CouldCourse
        End Get
        Set(ByVal value As String)
            _CouldCourse = value
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
