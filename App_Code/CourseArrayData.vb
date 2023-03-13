Imports Microsoft.VisualBasic

Public Class CourseArrayData
    Private _ID As Integer
    Private _RegNumber As String
    Private _SessionName As String
    Private _SemesterName As String
    Private _CourseCode As String
    Private _CourseName As String
    Private _CreditUnit As String
    Private _LevelName As String
    Private _LecName As String
    Public Sub New(ByVal ID As Integer, RegNumber As String, ByVal SessionName As String, _
                   ByVal SemesterName As String, ByVal CourseCode As String, ByVal CourseName As String, ByVal CreditUnit As String, _
                   ByVal LevelName As String, ByVal LecName As String)

        Me.ID = ID
        Me.RegNumber = RegNumber
        Me.SessionName = SessionName
        Me.SemesterName = SemesterName
        Me.CourseCode = CourseCode
        Me.CourseName = CourseName
        Me.CreditUnit = CreditUnit
        Me.LevelName = LevelName
        Me.LecName = LecName

    End Sub
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property
    Public Property RegNumber() As Integer
        Get
            Return _RegNumber
        End Get
        Set(ByVal value As Integer)
            _RegNumber = value
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
    Public Property SemesterName() As String
        Get
            Return _SemesterName
        End Get
        Set(ByVal value As String)
            _SemesterName = value
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
    Public Property LevelName() As String
        Get
            Return _LevelName
        End Get
        Set(ByVal value As String)
            _LevelName = value
        End Set
    End Property
    Public Property LecName() As String
        Get
            Return _LecName
        End Get
        Set(ByVal value As String)
            _LecName = value
        End Set
    End Property
  
End Class
