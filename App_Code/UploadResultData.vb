Imports Microsoft.VisualBasic

Public Class UploadResultData
    Private _AcademicSessionID As Integer
    Private _AcademicSession As String
    Private _SemesterID As Integer
    Private _Semester As String
    Private _DeptID As Integer
    Private _Department As String
    Private _LevelID As Integer
    Private _Level As String
    Private _CourseID As Integer
    Private _Course As String
    Private _CourseCode As Char
    Private _Faculty As String
    Private _FacultyID As Integer
    Private _ContinousAssesment As Decimal
    Private _Examination As Decimal
    Private _RegNum As String
    Private _Total As Decimal
    Private _Grade As String
    Private _Remark As String
    Private _CreatedByUID As Integer
    Private _ResultUrl As String
    Private _retcode As Integer
    Private _ErrorHint As Integer
    Private _UpperBound As Decimal
    Private _LowerBound As Decimal
    Private _Point As Decimal
    Private _CourseGradeID As Integer
    Private _CourseGrade As String
    Public Property AcademicSessionID() As Integer
        Get
            Return _AcademicSessionID
        End Get
        Set(ByVal value As Integer)
            _AcademicSessionID = value
        End Set
    End Property
    Public Property AcademicSession() As String
        Get
            Return _AcademicSession
        End Get
        Set(ByVal value As String)
            _AcademicSession = value
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
    Public Property Semester() As String
        Get
            Return _Semester
        End Get
        Set(ByVal value As String)
            _Semester = value
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
    Public Property Department() As String
        Get
            Return _Department
        End Get
        Set(ByVal value As String)
            _Department = value
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
    Public Property Level() As String
        Get
            Return _Level
        End Get
        Set(ByVal value As String)
            _Level = value
        End Set
    End Property
    Public Property CourseID() As Integer
        Get
            Return _CourseID
        End Get
        Set(ByVal value As Integer)
            _CourseID = value
        End Set
    End Property
    Public Property Course() As String
        Get
            Return _Course
        End Get
        Set(ByVal value As String)
            _Course = value
        End Set
    End Property
    Public Property CourseCode() As Char
        Get
            Return _CourseCode
        End Get
        Set(ByVal value As Char)
            _CourseCode = value
        End Set
    End Property
    Public Property Faculty() As String
        Get
            Return _Faculty
        End Get
        Set(ByVal value As String)
            _Faculty = value
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
    Public Property ContinousAssesment() As Decimal
        Get
            Return _ContinousAssesment
        End Get
        Set(ByVal value As Decimal)
            _ContinousAssesment = value
        End Set
    End Property
    Public Property Examination() As Decimal
        Get
            Return _Examination
        End Get
        Set(ByVal value As Decimal)
            _Examination = value
        End Set
    End Property
    Public Property RegNum() As String
        Get
            Return _RegNum
        End Get
        Set(ByVal value As String)
            _RegNum = value
        End Set
    End Property
    Public Property Total() As Decimal
        Get
            Return _Total
        End Get
        Set(ByVal value As Decimal)
            _Total = value
        End Set
    End Property
    Public Property Grade() As String
        Get
            Return _Grade
        End Get
        Set(ByVal value As String)
            _Grade = value
        End Set
    End Property
    Public Property Remark() As String
        Get
            Return _Remark
        End Get
        Set(ByVal value As String)
            _Remark = value
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
    Public Property ResultUrl() As String
        Get
            Return _ResultUrl
        End Get
        Set(ByVal value As String)
            _ResultUrl = value
        End Set
    End Property
    Public Property retcode() As Integer
        Get
            Return _retcode
        End Get
        Set(ByVal value As Integer)
            _retcode = value
        End Set
    End Property
    Public Property ErrorHint() As Integer
        Get
            Return _ErrorHint
        End Get
        Set(ByVal value As Integer)
            _ErrorHint = value
        End Set
    End Property
    Public Property UpperBound() As Decimal
        Get
            Return _UpperBound
        End Get
        Set(ByVal value As Decimal)
            _UpperBound = value
        End Set
    End Property
    Public Property LowerBound() As Decimal
        Get
            Return _LowerBound
        End Get
        Set(ByVal value As Decimal)
            _LowerBound = value
        End Set
    End Property
    Public Property Point() As Decimal
        Get
            Return _Point
        End Get
        Set(ByVal value As Decimal)
            _Point = value
        End Set
    End Property
    Public Property CourseGradeID() As Integer
        Get
            Return _CourseGradeID
        End Get
        Set(ByVal value As Integer)
            _CourseGradeID = value
        End Set
    End Property
    Public Property CourseGrade() As String
        Get
            Return _CourseGrade
        End Get
        Set(ByVal value As String)
            _CourseGrade = value
        End Set
    End Property
End Class
