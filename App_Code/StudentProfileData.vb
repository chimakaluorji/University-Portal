Imports Microsoft.VisualBasic

Public Class StudentProfileData
    Private _StudentProfileID As Integer
    Private _RegNumber As String
    Private _RegNumberID As Integer
    Private _Surname As String
    Private _Firstname As String
    Private _MiddleName As String
    Private _MothersMaidenName As String
    Private _DateOfBirth As String
    Private _PermenentHomeAddr As String
    Private _PhoneNumber As String
    Private _EmailAddress As String
    Private _CountryID As Integer
    Private _CountryName As String
    Private _StateID As Integer
    Private _StateName As String
    Private _LGAID As Integer
    Private _LGAName As String
    Private _FacultyID As Integer
    Private _FacultyName As String
    Private _DeptID As Integer
    Private _DeptName As String
    Private _QualificationID As Integer
    Private _QualificationName As String
    Private _ProgrammeID As Integer
    Private _ProgrammeName As String
    Private _EntryLevelID As Integer
    Private _EntryLevelName As String
    Private _AdmissionSessionID As Integer
    Private _AdmissionSessionName As String
    Private _SSCECopyUrl As String
    Private _SSCECopy2Url As String
    Private _JAMBResultCopyUrl As String
    Private _BirthCertCopyUrl As String
    Private _PhotoUrl As String
    Private _CreateDate As DateTime
    Private _LastModifiedDate As DateTime
    Private _LastModifiedByUID As Integer
    Private _LastModifiedByUName As String
    Private _Gender As String
    Private _CourseDurationID As Integer
    Private _CourseDuration As Integer
    Private _NextOfKin As String
    Private _AdmissionModeID As Integer
    Private _AdmissionMode As String
    Private _TI2 As String
    Private _TI2FromDate As String
    Private _TI2ToDate As String
    Private _TI1 As String
    Private _TI1FromDate As String
    Private _TI1ToDate As String
    Private _PPI2 As String
    Private _PPI2FromDate As String
    Private _PPI2ToDate As String
    Private _PPI1 As String
    Private _PPI1FromDate As String
    Private _PPI1ToDate As String
    Private _PS2 As String
    Private _PS2FromDate As String
    Private _PS2ToDate As String
    Private _PS1 As String
    Private _PS1FromDate As String
    Private _PS1ToDate As String
    Private _Password As String
    Private _SaltKey As String
    Private _LevelID As Integer
    Private _LevelName As String
    Private _SessionID As Integer
    Private _SessionName As String
    Private _StringTI2FromDate As String
    Private _StringTI2ToDate As String
    Private _StringTI1FromDate As String
    Private _StringTI1ToDate As String
    Private _StringPPI2FromDate As String
    Private _StringPPI2ToDate As String
    Private _StringPPI1FromDate As String
    Private _StringPPI1ToDate As String
    Private _StringPS2FromDate As String
    Private _StringPS2ToDate As String
    Private _StringPS1FromDate As String
    Private _StringPS1ToDate As String
    Private _StringCreateDate As String
    Private _StringLastModifiedDate As String
    Private _UMEScore As String
    Private _PostUMEScore As String
    Private _ETransactPin As String
    Private _OLevelSubjectID As Integer
    Private _SubjectName As String
    Private _ExamsBodyID As Integer
    Private _ExamsBodyName As String
    Private _SubjectGradeID As String
    Private _Grade As String
    Private _GradeDescription As String
    Private _OLevelResultID As Integer
    Private _RegNo As String
    Private _ExamsMonth As String
    Private _ExamsYear As String
    Private _Sitting As String
    Private _OlevelSubject1 As String
    Private _OlevelSubject2 As String
    Private _OlevelSubject3 As String
    Private _OlevelSubject4 As String
    Private _OlevelSubject5 As String
    Private _OlevelSubject6 As String
    Private _OlevelSubject7 As String
    Private _OlevelSubject8 As String
    Private _OlevelSubject9 As String
    Private _Grade1 As String
    Private _Grade2 As String
    Private _Grade3 As String
    Private _Grade4 As String
    Private _Grade5 As String
    Private _Grade6 As String
    Private _Grade7 As String
    Private _Grade8 As String
    Private _Grade9 As String
    Private _OLevelExamsYearID As Integer
    Private _OLevelExamsYear As String
    Private _CreatedByRegNo As String
    Private _Quarantine As Char
    Private _CreatedByUID As Integer
    Private _Activate As Char
    Private _SemesterID As Integer
    Private _Semester As String
    Private _CurrentLevel As String
    Private _CurrentSession As String
    Private _CurrentSemester As String
    Private _ETransactionPinID As Integer
    Private _SecondDeptID As Integer
    Private _SecondDeptName As String
    Private _Jamb As String
    Private _Total As String
    Private _Year As String
    Private _NewPassword As String
    Private _NewSaltKey As String
    Private _TypeOfSchoolFees As String
    Private _Amount As String
    Private _AmountInWords As String
    Private _OlevelSubject10 As String
    Private _OlevelSubject11 As String
    Private _OlevelSubject12 As String


    Public Property PostUMEScore() As String
        Get
            Return _PostUMEScore
        End Get
        Set(ByVal value As String)
            _PostUMEScore = value
        End Set
    End Property

    Public Property UMEScore() As String
        Get
            Return _UMEScore
        End Get
        Set(ByVal value As String)
            _UMEScore = value
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

    Public Property SessionID() As Integer
        Get
            Return _SessionID
        End Get
        Set(ByVal value As Integer)
            _SessionID = value
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

    Public Property LevelID() As Integer
        Get
            Return _LevelID
        End Get
        Set(ByVal value As Integer)
            _LevelID = value
        End Set
    End Property

    Public Property PhotoUrl() As String
        Get
            Return _PhotoUrl
        End Get
        Set(ByVal value As String)
            _PhotoUrl = value
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
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property
    Public Property PS1() As String
        Get
            Return _PS1
        End Get
        Set(ByVal value As String)
            _PS1 = value
        End Set
    End Property
    Public Property PS1ToDate() As String
        Get
            Return _PS1ToDate
        End Get
        Set(ByVal value As String)
            _PS1ToDate = value
        End Set
    End Property
    Public Property PS1FromDate() As String
        Get
            Return _PS1FromDate
        End Get
        Set(ByVal value As String)
            _PS1FromDate = value
        End Set
    End Property
   
    Public Property PS2ToDate() As String
        Get
            Return _PS2ToDate
        End Get
        Set(ByVal value As String)
            _PS2ToDate = value
        End Set
    End Property
    Public Property PS2FromDate() As String
        Get
            Return _PS2FromDate
        End Get
        Set(ByVal value As String)
            _PS2FromDate = value
        End Set
    End Property
    Public Property PS2() As String
        Get
            Return _PS2
        End Get
        Set(ByVal value As String)
            _PS2 = value
        End Set
    End Property
    Public Property PPI1ToDate() As String
        Get
            Return _PPI1ToDate
        End Get
        Set(ByVal value As String)
            _PPI1ToDate = value
        End Set
    End Property
    Public Property PPI1FromDate() As String
        Get
            Return _PPI1FromDate
        End Get
        Set(ByVal value As String)
            _PPI1FromDate = value
        End Set
    End Property
    Public Property PPI1() As String
        Get
            Return _PPI1
        End Get
        Set(ByVal value As String)
            _PPI1 = value
        End Set
    End Property
    Public Property PPI2ToDate() As String
        Get
            Return _PPI2ToDate
        End Get
        Set(ByVal value As String)
            _PPI2ToDate = value
        End Set
    End Property
    Public Property PPI2FromDate() As String
        Get
            Return _PPI2FromDate
        End Get
        Set(ByVal value As String)
            _PPI2FromDate = value
        End Set
    End Property
    Public Property PPI2() As String
        Get
            Return _PPI2
        End Get
        Set(ByVal value As String)
            _PPI2 = value
        End Set
    End Property
    Public Property TI1ToDate() As String
        Get
            Return _TI1ToDate
        End Get
        Set(ByVal value As String)
            _TI1ToDate = value
        End Set
    End Property
    Public Property TI1FromDate() As String
        Get
            Return _TI1FromDate
        End Get
        Set(ByVal value As String)
            _TI1FromDate = value
        End Set
    End Property
    Public Property TI1() As String
        Get
            Return _TI1
        End Get
        Set(ByVal value As String)
            _TI1 = value
        End Set
    End Property
    Public Property TI2ToDate() As String
        Get
            Return _TI2ToDate
        End Get
        Set(ByVal value As String)
            _TI2ToDate = value
        End Set
    End Property
    Public Property TI2FromDate() As String
        Get
            Return _TI2FromDate
        End Get
        Set(ByVal value As String)
            _TI2FromDate = value
        End Set
    End Property
    Public Property TI2() As String
        Get
            Return _TI2
        End Get
        Set(ByVal value As String)
            _TI2 = value
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
    Public Property AdmissionModeID() As Integer
        Get
            Return _AdmissionModeID
        End Get
        Set(ByVal value As Integer)
            _AdmissionModeID = value
        End Set
    End Property
    Public Property NextOfKin() As String
        Get
            Return _NextOfKin
        End Get
        Set(ByVal value As String)
            _NextOfKin = value
        End Set
    End Property
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

    Public Property Firstname() As String
        Get
            Return _Firstname
        End Get
        Set(ByVal value As String)
            _Firstname = value
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

    Public Property MothersMaidenName() As String
        Get
            Return _MothersMaidenName
        End Get
        Set(ByVal value As String)
            _MothersMaidenName = value
        End Set
    End Property

    Public Property DateOfBirth() As String
        Get
            Return _DateOfBirth
        End Get
        Set(ByVal value As String)
            _DateOfBirth = value
        End Set
    End Property
    Public Property PermenentHomeAddr() As String
        Get
            Return _PermenentHomeAddr
        End Get
        Set(ByVal value As String)
            _PermenentHomeAddr = value
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

    Public Property EmailAddress() As String
        Get
            Return _EmailAddress
        End Get
        Set(ByVal value As String)
            _EmailAddress = value
        End Set
    End Property

    Public Property CountryID() As Integer
        Get
            Return _CountryID
        End Get
        Set(ByVal value As Integer)
            _CountryID = value
        End Set
    End Property

    Public Property CountryName() As String
        Get
            Return _CountryName
        End Get
        Set(ByVal value As String)
            _CountryName = value
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

    Public Property StateName() As String
        Get
            Return _StateName
        End Get
        Set(ByVal value As String)
            _StateName = value
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

    Public Property LGAName() As String
        Get
            Return _LGAName
        End Get
        Set(ByVal value As String)
            _LGAName = value
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

    Public Property EntryLevelID() As Integer
        Get
            Return _EntryLevelID
        End Get
        Set(ByVal value As Integer)
            _EntryLevelID = value
        End Set
    End Property

    Public Property EntryLevelName() As String
        Get
            Return _EntryLevelName
        End Get
        Set(ByVal value As String)
            _EntryLevelName = value
        End Set
    End Property

    Public Property AdmissionSessionID() As Integer
        Get
            Return _AdmissionSessionID
        End Get
        Set(ByVal value As Integer)
            _AdmissionSessionID = value
        End Set
    End Property

    Public Property AdmissionSessionName() As String
        Get
            Return _AdmissionSessionName
        End Get
        Set(ByVal value As String)
            _AdmissionSessionName = value
        End Set
    End Property

    Public Property SSCECopyUrl() As String
        Get
            Return _SSCECopyUrl
        End Get
        Set(ByVal value As String)
            _SSCECopyUrl = value
        End Set
    End Property

    Public Property SSCECopy2Url() As String
        Get
            Return _SSCECopy2Url
        End Get
        Set(ByVal value As String)
            _SSCECopy2Url = value
        End Set
    End Property

    Public Property JAMBResultCopyUrl() As String
        Get
            Return _JAMBResultCopyUrl
        End Get
        Set(ByVal value As String)
            _JAMBResultCopyUrl = value
        End Set
    End Property

    Public Property BirthCertCopyUrl() As String
        Get
            Return _BirthCertCopyUrl
        End Get
        Set(ByVal value As String)
            _BirthCertCopyUrl = value
        End Set
    End Property

    Public Property CreateDate() As DateTime
        Get
            Return _CreateDate
        End Get
        Set(ByVal value As DateTime)
            _CreateDate = value
        End Set
    End Property

    Public Property LastModifiedDate() As DateTime
        Get
            Return _LastModifiedDate
        End Get
        Set(ByVal value As DateTime)
            _LastModifiedDate = value
        End Set
    End Property

    Public Property LastModifiedByUID() As Integer
        Get
            Return _LastModifiedByUID
        End Get
        Set(ByVal value As Integer)
            _LastModifiedByUID = value
        End Set
    End Property

    Public Property LastModifiedByUName() As String
        Get
            Return _LastModifiedByUName
        End Get
        Set(ByVal value As String)
            _LastModifiedByUName = value
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

    Public Property CourseDurationID() As Integer
        Get
            Return _CourseDurationID
        End Get
        Set(ByVal value As Integer)
            _CourseDurationID = value
        End Set
    End Property

    Public Property CourseDuration() As Integer
        Get
            Return _CourseDuration
        End Get
        Set(ByVal value As Integer)
            _CourseDuration = value
        End Set
    End Property
    Public Property StringTI2FromDate() As String
        Get
            Return _StringTI2FromDate
        End Get
        Set(ByVal value As String)
            _StringTI2FromDate = value
        End Set
    End Property
    Public Property StringTI2ToDate() As String
        Get
            Return _StringTI2ToDate
        End Get
        Set(ByVal value As String)
            _StringTI2ToDate = value
        End Set
    End Property
    Public Property StringTI1FromDate() As String
        Get
            Return _StringTI1FromDate
        End Get
        Set(ByVal value As String)
            _StringTI1FromDate = value
        End Set
    End Property
    Public Property StringTI1ToDate() As String
        Get
            Return _StringTI1ToDate
        End Get
        Set(ByVal value As String)
            _StringTI1ToDate = value
        End Set
    End Property
    Public Property StringPPI2FromDate() As String
        Get
            Return _StringPPI2FromDate
        End Get
        Set(ByVal value As String)
            _StringPPI2FromDate = value
        End Set
    End Property
    Public Property StringPPI2ToDate() As String
        Get
            Return _StringPPI2ToDate
        End Get
        Set(ByVal value As String)
            _StringPPI2ToDate = value
        End Set
    End Property
    Public Property StringPPI1FromDate() As String
        Get
            Return _StringPPI1FromDate
        End Get
        Set(ByVal value As String)
            _StringPPI1FromDate = value
        End Set
    End Property
    Public Property StringPPI1ToDate() As String
        Get
            Return _StringPPI1ToDate
        End Get
        Set(ByVal value As String)
            _StringPPI1ToDate = value
        End Set
    End Property
    Public Property StringPS2FromDate() As String
        Get
            Return _StringPS2FromDate
        End Get
        Set(ByVal value As String)
            _StringPS2FromDate = value
        End Set
    End Property
    Public Property StringPS2ToDate() As String
        Get
            Return _StringPS2ToDate
        End Get
        Set(ByVal value As String)
            _StringPS2ToDate = value
        End Set
    End Property
    Public Property StringPS1FromDate() As String
        Get
            Return _StringPS1FromDate
        End Get
        Set(ByVal value As String)
            _StringPS1FromDate = value
        End Set
    End Property
    Public Property StringPS1ToDate() As String
        Get
            Return _StringPS1ToDate
        End Get
        Set(ByVal value As String)
            _StringPS1ToDate = value
        End Set
    End Property
    Public Property StringCreateDate() As String
        Get
            Return _StringCreateDate
        End Get
        Set(ByVal value As String)
            _StringCreateDate = value
        End Set
    End Property
    Public Property StringLastModifiedDate() As String
        Get
            Return _StringLastModifiedDate
        End Get
        Set(ByVal value As String)
            _StringLastModifiedDate = value
        End Set
    End Property
    Public Property RegNumberID() As Integer
        Get
            Return _RegNumberID
        End Get
        Set(ByVal value As Integer)
            _RegNumberID = value
        End Set
    End Property
    Public Property ETransactPin() As String
        Get
            Return _ETransactPin
        End Get
        Set(ByVal value As String)
            _ETransactPin = value
        End Set
    End Property
    Public Property OLevelExamsYear() As String
        Get
            Return _OLevelExamsYear
        End Get
        Set(ByVal value As String)
            _OLevelExamsYear = value
        End Set
    End Property

    Public Property OLevelExamsYearID() As Integer
        Get
            Return _OLevelExamsYearID
        End Get
        Set(ByVal value As Integer)
            _OLevelExamsYearID = value
        End Set
    End Property

    Public Property Grade9() As String
        Get
            Return _Grade9
        End Get
        Set(ByVal value As String)
            _Grade9 = value
        End Set
    End Property
    Public Property Grade8() As String
        Get
            Return _Grade8
        End Get
        Set(ByVal value As String)
            _Grade8 = value
        End Set
    End Property
    Public Property Grade7() As String
        Get
            Return _Grade7
        End Get
        Set(ByVal value As String)
            _Grade7 = value
        End Set
    End Property
    Public Property Grade6() As String
        Get
            Return _Grade6
        End Get
        Set(ByVal value As String)
            _Grade6 = value
        End Set
    End Property
    Public Property Grade5() As String
        Get
            Return _Grade5
        End Get
        Set(ByVal value As String)
            _Grade5 = value
        End Set
    End Property
    Public Property Grade4() As String
        Get
            Return _Grade4
        End Get
        Set(ByVal value As String)
            _Grade4 = value
        End Set
    End Property
    Public Property Grade3() As String
        Get
            Return _Grade3
        End Get
        Set(ByVal value As String)
            _Grade3 = value
        End Set
    End Property
    Public Property Grade2() As String
        Get
            Return _Grade2
        End Get
        Set(ByVal value As String)
            _Grade2 = value
        End Set
    End Property
    Public Property Grade1() As String
        Get
            Return _Grade1
        End Get
        Set(ByVal value As String)
            _Grade1 = value
        End Set
    End Property
    Public Property OlevelSubject9() As String
        Get
            Return _OlevelSubject9
        End Get
        Set(ByVal value As String)
            _OlevelSubject9 = value
        End Set
    End Property
    Public Property OlevelSubject8() As String
        Get
            Return _OlevelSubject8
        End Get
        Set(ByVal value As String)
            _OlevelSubject8 = value
        End Set
    End Property
    Public Property OlevelSubject7() As String
        Get
            Return _OlevelSubject7
        End Get
        Set(ByVal value As String)
            _OlevelSubject7 = value
        End Set
    End Property
    Public Property OlevelSubject6() As String
        Get
            Return _OlevelSubject6
        End Get
        Set(ByVal value As String)
            _OlevelSubject6 = value
        End Set
    End Property

    Public Property OlevelSubject5() As String
        Get
            Return _OlevelSubject5
        End Get
        Set(ByVal value As String)
            _OlevelSubject5 = value
        End Set
    End Property
    Public Property OlevelSubject4() As String
        Get
            Return _OlevelSubject4
        End Get
        Set(ByVal value As String)
            _OlevelSubject4 = value
        End Set
    End Property
    Public Property OlevelSubject3() As String
        Get
            Return _OlevelSubject3
        End Get
        Set(ByVal value As String)
            _OlevelSubject3 = value
        End Set
    End Property

    Public Property OlevelSubject2() As String
        Get
            Return _OlevelSubject2
        End Get
        Set(ByVal value As String)
            _OlevelSubject2 = value
        End Set
    End Property
    Public Property OlevelSubject1() As String
        Get
            Return _OlevelSubject1
        End Get
        Set(ByVal value As String)
            _OlevelSubject1 = value
        End Set
    End Property
    Public Property Sitting() As String
        Get
            Return _Sitting
        End Get
        Set(ByVal value As String)
            _Sitting = value
        End Set
    End Property

    Public Property ExamsYear() As String
        Get
            Return _ExamsYear
        End Get
        Set(ByVal value As String)
            _ExamsYear = value
        End Set
    End Property

    Public Property ExamsMonth() As String
        Get
            Return _ExamsMonth
        End Get
        Set(ByVal value As String)
            _ExamsMonth = value
        End Set
    End Property

    Public Property RegNo() As String
        Get
            Return _RegNo
        End Get
        Set(ByVal value As String)
            _RegNo = value
        End Set
    End Property

    Public Property OLevelResultID() As Integer
        Get
            Return _OLevelResultID
        End Get
        Set(ByVal value As Integer)
            _OLevelResultID = value
        End Set
    End Property

    Public Property GradeDescription() As String
        Get
            Return _GradeDescription
        End Get
        Set(ByVal value As String)
            _GradeDescription = value
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

    Public Property SubjectGradeID() As Integer
        Get
            Return _SubjectGradeID
        End Get
        Set(ByVal value As Integer)
            _SubjectGradeID = value
        End Set
    End Property

    Public Property ExamsBodyName() As String
        Get
            Return _ExamsBodyName
        End Get
        Set(ByVal value As String)
            _ExamsBodyName = value
        End Set
    End Property

    Public Property ExamsBodyID() As Integer
        Get
            Return _ExamsBodyID
        End Get
        Set(ByVal value As Integer)
            _ExamsBodyID = value
        End Set
    End Property

    Public Property SubjectName() As String
        Get
            Return _SubjectName
        End Get
        Set(ByVal value As String)
            _SubjectName = value
        End Set
    End Property

    Public Property OLevelSubjectID() As Integer
        Get
            Return _OLevelSubjectID
        End Get
        Set(ByVal value As Integer)
            _OLevelSubjectID = value
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

    Public Property Quarantine() As Char
        Get
            Return _Quarantine
        End Get
        Set(ByVal value As Char)
            _Quarantine = value
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

    Public Property Activate() As Char
        Get
            Return _Activate
        End Get
        Set(ByVal value As Char)
            _Activate = value
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
    Public Property CurrentLevel() As String
        Get
            Return _CurrentLevel
        End Get
        Set(ByVal value As String)
            _CurrentLevel = value
        End Set
    End Property

    Public Property CurrentSession() As String
        Get
            Return _CurrentSession
        End Get
        Set(ByVal value As String)
            _CurrentSession = value
        End Set
    End Property

    Public Property CurrentSemester() As String
        Get
            Return _CurrentSemester
        End Get
        Set(ByVal value As String)
            _CurrentSemester = value
        End Set
    End Property
    Public Property ETransactionPinID() As Integer
        Get
            Return _ETransactionPinID
        End Get
        Set(ByVal value As Integer)
            _ETransactionPinID = value
        End Set
    End Property

    Public Property SecondDeptID() As Integer
        Get
            Return _SecondDeptID
        End Get
        Set(ByVal value As Integer)
            _SecondDeptID = value
        End Set
    End Property

    Public Property SecondDeptName() As String
        Get
            Return _SecondDeptName
        End Get
        Set(ByVal value As String)
            _SecondDeptName = value
        End Set
    End Property
    Public Property Jamb() As String
        Get
            Return _Jamb
        End Get
        Set(ByVal value As String)
            _Jamb = value
        End Set
    End Property
    Public Property Total() As String
        Get
            Return _Total
        End Get
        Set(ByVal value As String)
            _Total = value
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
    Public Property NewPassword() As String
        Get
            Return _NewPassword
        End Get
        Set(ByVal value As String)
            _NewPassword = value
        End Set
    End Property
    Public Property NewSaltKey() As String
        Get
            Return _NewSaltKey
        End Get
        Set(ByVal value As String)
            _NewSaltKey = value
        End Set
    End Property
    Public Property TypeOfSchoolFees() As String
        Get
            Return _TypeOfSchoolFees
        End Get
        Set(ByVal value As String)
            _TypeOfSchoolFees = value
        End Set
    End Property
    Public Property Amount() As String
        Get
            Return _Amount
        End Get
        Set(ByVal value As String)
            _Amount = value
        End Set
    End Property
    Public Property AmountInWords() As String
        Get
            Return _AmountInWords
        End Get
        Set(ByVal value As String)
            _AmountInWords = value
        End Set
    End Property
    Public Property OlevelSubject10() As String
        Get
            Return _OlevelSubject10
        End Get
        Set(ByVal value As String)
            _OlevelSubject10 = value
        End Set
    End Property
    Public Property OlevelSubject11() As String
        Get
            Return _OlevelSubject11
        End Get
        Set(ByVal value As String)
            _OlevelSubject11 = value
        End Set
    End Property
    Public Property OlevelSubject12() As String
        Get
            Return _OlevelSubject12
        End Get
        Set(ByVal value As String)
            _OlevelSubject12 = value
        End Set
    End Property
End Class