Imports Microsoft.VisualBasic

Public Class CourseData
    Private _CourseID As Integer
    Private _RegNumber As String
    Private _CourseCode As String
    Private _CourseName As String
    Private _CreditUnit As String
    Private _SemesterID As Integer
    Private _SemesterName As String
    Private _DepartmentID As Integer
    Private _DeptName As String
    Private _ProgrammeID As Integer
    Private _ProgrammeName As String
    Private _LevelID As Integer
    Private _LevelName As String

    Public Sub New()

    End Sub

    Public Property CourseID() As Integer
        Get
            Return _CourseID
        End Get
        Set(ByVal value As Integer)
            _CourseID = value
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

    Public Property CourseCode() As String
        Get
            Return _CourseCode
        End Get
        Set(ByVal value As String)
            _CourseCode = value
        End Set
    End Property

    Public Property CourseName() As String
        Get
            Return _CourseName
        End Get
        Set(ByVal value As String)
            _CourseName = value
        End Set
    End Property

    Public Property CreditUnit() As String
        Get
            Return _CreditUnit
        End Get
        Set(ByVal value As String)
            _CreditUnit = value
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
    Public Property SemesterName() As String
        Get
            Return _SemesterName
        End Get
        Set(ByVal value As String)
            _SemesterName = value
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
    Public Property DeptName() As String
        Get
            Return _DeptName
        End Get
        Set(ByVal value As String)
            _DeptName = value
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
    Public Property ProgrammeName() As String
        Get
            Return _ProgrammeName
        End Get
        Set(ByVal value As String)
            _ProgrammeName = value
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
    Public Property LevelName() As String
        Get
            Return _LevelName
        End Get
        Set(ByVal value As String)
            _LevelName = value
        End Set
    End Property
End Class