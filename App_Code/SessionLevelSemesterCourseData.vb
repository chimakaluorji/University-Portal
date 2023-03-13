Imports Microsoft.VisualBasic

Public Class SessionLevelSemesterCourseData
    Private _CourseID As Integer
    Private _CourseCode As String
    Private _CourseName As String
    Private _CreditUnit As String
    Private _CourseCodeSelective As String
    Private _CourseNameSelective As String
    Private _CreditUnitSelective As Integer
    Private _SessionNameSelective As String
    Private _SemesterSelective As String
    Private _SessionID As Integer
    Private _SessionName As String
    Private _SemesterID As Integer
    Private _SemesterName As String
    Private _LecturerID As Integer
    Private _LecturerName As String
    Private _DeptID As Integer
    Private _DeptName As String
    Private _LevelID As Integer
    Private _LevelName As String
    Private _CreatedByUserID As Integer
    Private _FirstName As String
    Private _LevelNumber As Integer
    Private _CourseDurationID As Integer
    Private _CourseDuration As String
    Private _AdmissionModeID As Integer
    Private _AdmissionMode As String
    Private _ProgrammeID As Integer
    Private _QualificationID As Integer
    Private _ProgrammeName As String
    Private _QualificationName As String
    Private _RegNumber As String
    Private _CreatedByUID As Integer
    Private _Semester As String
    Private _ResultUrl As String
    Private _CA As Decimal
    Private _Exam As Decimal
    Private _Total As Decimal
    Private _Grade As String
    Private _Remark As String
    Private _ResultUploadByID As Integer
    Private _LastName As String
    Private _Attempt As String
    Private _QualityPoint As Decimal
    Private _Year As String
    Private _SchoolFeesID As Integer
    Private _TypeSchool As String
    Private _SchoolFeesAmount As String
    Private _ResultSheetUrl As String
    Private _FacultyID As Integer
    Private _FacultyName As String
    Private _AmountInwords As String
    Private _YearName As String
    Private _Month As String
    Private _Day As String
    Private _Hour As String
    Private _Minute As String
    Private _Note As String
    Public Property LastName() As String
        Get
            Return _LastName
        End Get
        Set(ByVal value As String)
            _LastName = value
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
    Public Property CA() As Decimal
        Get
            Return _CA
        End Get
        Set(ByVal value As Decimal)
            _CA = value
        End Set
    End Property
    Public Property Exam() As Decimal
        Get
            Return _Exam
        End Get
        Set(ByVal value As Decimal)
            _Exam = value
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
    Public Property ResultUploadByID() As Integer
        Get
            Return _ResultUploadByID
        End Get
        Set(ByVal value As Integer)
            _ResultUploadByID = value
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

    Public Property CreatedByUID() As Integer
        Get
            Return _CreatedByUID
        End Get
        Set(ByVal value As Integer)
            _CreatedByUID = value
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
    Public Property QualificationName() As String
        Get
            Return _QualificationName
        End Get
        Set(ByVal value As String)
            _QualificationName = value
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

    Public Property ProgrammeID() As Integer
        Get
            Return _ProgrammeID
        End Get
        Set(ByVal value As Integer)
            _ProgrammeID = value
        End Set
    End Property


    Public Property AdmissionModeID() As Integer
        Get
            Return _AdmissionModeID
        End Get
        Set(ByVal value As Integer)
            _AdmissionModeID = value
        End Set
    End Property

    Public Property AdmissionMode() As String
        Get
            Return _AdmissionMode
        End Get
        Set(ByVal value As String)
            _AdmissionMode = value
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

    Public Property CreditUnit() As String
        Get
            Return _CreditUnit
        End Get
        Set(ByVal value As String)
            _CreditUnit = value
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

    Public Property SessionID() As Integer
        Get
            Return _SessionID
        End Get
        Set(ByVal value As Integer)
            _SessionID = value
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
    Public Property LecturerID() As Integer
        Get
            Return _LecturerID
        End Get
        Set(ByVal value As Integer)
            _LecturerID = value
        End Set
    End Property
    Public Property LecturerName() As String
        Get
            Return _LecturerName
        End Get
        Set(ByVal value As String)
            _LecturerName = value
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
    Public Property DeptName() As String
        Get
            Return _DeptName
        End Get
        Set(ByVal value As String)
            _DeptName = value
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

    Public Property CreatedByUserID() As Integer
        Get
            Return _CreatedByUserID
        End Get
        Set(ByVal value As Integer)
            _CreatedByUserID = value
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
    Public Property LevelNumber() As Integer
        Get
            Return _LevelNumber
        End Get
        Set(ByVal value As Integer)
            _LevelNumber = value
        End Set
    End Property
    Public Property CourseDurationID() As Integer
        Get
            Return _CourseDurationID
        End Get
        Set(ByVal value As Integer)
            _CourseDurationID = value
        End Set
    End Property
    Public Property CourseDuration() As String
        Get
            Return _CourseDuration
        End Get
        Set(ByVal value As String)
            _CourseDuration = value
        End Set
    End Property

    Public Property CourseCodeSelective() As String
        Get
            Return _CourseCodeSelective
        End Get
        Set(ByVal value As String)
            _CourseCodeSelective = value
        End Set
    End Property

    Public Property CourseNameSelective() As String
        Get
            Return _CourseNameSelective
        End Get
        Set(ByVal value As String)
            _CourseNameSelective = value
        End Set
    End Property

    Public Property CreditUnitSelective() As Integer
        Get
            Return _CreditUnitSelective
        End Get
        Set(ByVal value As Integer)
            _CreditUnitSelective = value
        End Set
    End Property

    Public Property SessionNameSelective() As String
        Get
            Return _SessionNameSelective
        End Get
        Set(ByVal value As String)
            _SessionNameSelective = value
        End Set
    End Property
    Public Property SemesterSelective() As String
        Get
            Return _SemesterSelective
        End Get
        Set(ByVal value As String)
            _SemesterSelective = value
        End Set
    End Property
    Public Property Attempt() As String
        Get
            Return _Attempt
        End Get
        Set(ByVal value As String)
            _Attempt = value
        End Set
    End Property
    Public Property QualityPoint() As String
        Get
            Return _QualityPoint
        End Get
        Set(ByVal value As String)
            _QualityPoint = value
        End Set
    End Property
    Public Property Year() As String
        Get
            Return _Year
        End Get
        Set(ByVal value As String)
            _Year = value
        End Set
    End Property
    Public Property SchoolFeesID() As Integer
        Get
            Return _SchoolFeesID
        End Get
        Set(ByVal value As Integer)
            _SchoolFeesID = value
        End Set
    End Property
    Public Property TypeSchool() As String
        Get
            Return _TypeSchool
        End Get
        Set(ByVal value As String)
            _TypeSchool = value
        End Set
    End Property
    Public Property SchoolFeesAmount() As String
        Get
            Return _SchoolFeesAmount
        End Get
        Set(ByVal value As String)
            _SchoolFeesAmount = value
        End Set
    End Property
    Public Property ResultSheetUrl() As String
        Get
            Return _ResultSheetUrl
        End Get
        Set(ByVal value As String)
            _ResultSheetUrl = value
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
    Public Property FacultyName() As String
        Get
            Return _FacultyName
        End Get
        Set(ByVal value As String)
            _FacultyName = value
        End Set
    End Property
    Public Property AmountInwords() As String
        Get
            Return _AmountInwords
        End Get
        Set(ByVal value As String)
            _AmountInwords = value
        End Set
    End Property
    Public Property YearName() As String
        Get
            Return _YearName
        End Get
        Set(ByVal value As String)
            _YearName = value
        End Set
    End Property
    Public Property Month() As String
        Get
            Return _Month
        End Get
        Set(ByVal value As String)
            _Month = value
        End Set
    End Property
    Public Property Day() As String
        Get
            Return _Day
        End Get
        Set(ByVal value As String)
            _Day = value
        End Set
    End Property
    Public Property Hour() As String
        Get
            Return _Hour
        End Get
        Set(ByVal value As String)
            _Hour = value
        End Set
    End Property
    Public Property Minute() As String
        Get
            Return _Minute
        End Get
        Set(ByVal value As String)
            _Minute = value
        End Set
    End Property
    Public Property Note() As String
        Get
            Return _Note
        End Get
        Set(ByVal value As String)
            _Note = value
        End Set
    End Property
End Class