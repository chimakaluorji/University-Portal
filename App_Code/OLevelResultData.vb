Imports Microsoft.VisualBasic

Public Class OLevelResultData
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

End Class
