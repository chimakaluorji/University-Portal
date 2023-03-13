Imports Microsoft.VisualBasic

Public Class QualificationData
    Private _QualificationID As Integer
    Private _QualificationName As String
    Private _ShortName As String
    Private _ProgrammeName As String
    Private _AdmissionProgrammeID As Integer
    Private _ModeOfAdmissionID As Integer
    Private _ModeOfAdmission As String

    Public Property AdmissionProgrammeID() As Integer
        Get
            Return _AdmissionProgrammeID
        End Get
        Set(ByVal value As Integer)
            _AdmissionProgrammeID = value
        End Set
    End Property

    Public Property ProgrammeName() As String
        Get
            Return _ProgrammeName
        End Get
        Set(ByVal value As String)
            _ProgrammeName = value
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
    Public Property QualificationName() As String
        Get
            Return _QualificationName
        End Get
        Set(ByVal value As String)
            _QualificationName = value
        End Set
    End Property

    Public Property ShortName() As String
        Get
            Return _ShortName
        End Get
        Set(ByVal value As String)
            _ShortName = value
        End Set
    End Property
    Public Property ModeOfAdmissionID() As Integer
        Get
            Return _ModeOfAdmissionID
        End Get
        Set(ByVal value As Integer)
            _ModeOfAdmissionID = value
        End Set
    End Property

    Public Property ModeOfAdmission() As String
        Get
            Return _ModeOfAdmission
        End Get
        Set(ByVal value As String)
            _ModeOfAdmission = value
        End Set
    End Property
End Class
