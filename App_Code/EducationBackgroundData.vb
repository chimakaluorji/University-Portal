Imports Microsoft.VisualBasic

Public Class EducationBackgroundData
    Private _EducationBackgroundID As Integer
    Private _PersonalInformationID As Integer
    Private _CourseMajored As String
    Private _SchoolAttend As String
    Private _QualificationID As Integer
    Private _BeginYear As String
    Private _EndYear As String
    Private _CreatedByUID As Integer

    Public Property EducationBackgroundID() As Integer
        Get
            Return _EducationBackgroundID
        End Get
        Set(ByVal value As Integer)
            _EducationBackgroundID = value
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
    Public Property CourseMajored() As String
        Get
            Return _CourseMajored
        End Get
        Set(ByVal value As String)
            _CourseMajored = value
        End Set
    End Property
    Public Property SchoolAttend() As String
        Get
            Return _SchoolAttend
        End Get
        Set(ByVal value As String)
            _SchoolAttend = value
        End Set
    End Property
    Public Property QualificationID() As Integer
        Get
            Return _QualificationID
        End Get
        Set(ByVal value As Integer)
            _QualificationID = value
        End Set
    End Property
    Public Property BeginYear() As String
        Get
            Return _BeginYear
        End Get
        Set(ByVal value As String)
            _BeginYear = value
        End Set
    End Property
    Public Property EndYear() As String
        Get
            Return _EndYear
        End Get
        Set(ByVal value As String)
            _EndYear = value
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
