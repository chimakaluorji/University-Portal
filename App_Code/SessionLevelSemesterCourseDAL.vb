''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Chima kalu-orji
'' Date: 29-01-2009
'' This Class manages Academic Courses.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Public Class SessionLevelSemesterCourseDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Creates a Course
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Course</remarks>
    Public Function CreateCourse(ByVal Course As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@SemesterID", Course.SemesterID), _
        New SqlParameter("@SessionID", Course.SessionID), _
        New SqlParameter("@LecturerID", Course.LecturerID), _
        New SqlParameter("@LevelID", Course.LevelID), _
        New SqlParameter("@ProgrammeID", Course.ProgrammeID), _
        New SqlParameter("@QualificationID", Course.QualificationID), _
        New SqlParameter("@CreatedByUserID", Course.CreatedByUserID), _
        New SqlParameter("@CreditUnit", Course.CreditUnit)}
        Try
            'Create Course data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateCourse", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a Course
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Course</remarks>
    Public Function CreateSeletiveCourse(ByVal Course As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@SemesterID", Course.SemesterID), _
        New SqlParameter("@SessionID", Course.SessionID), _
        New SqlParameter("@LecturerID", Course.LecturerID), _
        New SqlParameter("@LevelID", Course.LevelID), _
        New SqlParameter("@ProgrammeID", Course.ProgrammeID), _
        New SqlParameter("@QualificationID", Course.QualificationID), _
        New SqlParameter("@CreatedByUserID", Course.CreatedByUserID), _
        New SqlParameter("@CreditUnit", Course.CreditUnit)}
        Try
            'Create Course data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateSelectiveCourse", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Creates Course Registration
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Course</remarks>
    Public Function CreateCourseRegistration(ByVal Course As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit)}

        'Try
        'Create Course data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateCourseRegistration", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return 0
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function

    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CreateCourseRegistrations(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@LecturerName", Course.LecturerName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(11).Direction = ParameterDirection.Output
        params(12).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateCourseRegistration", params)
        'Populate Error Code
        RetVal(0) = params(11).Value
        'Populate Error Hint
        RetVal(1) = params(12).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(10).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(11).Value
        '    'Populate StudentProfileID
        'End Try
    End Function

    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CreateCourseRegistrationsTemp(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(11).Direction = ParameterDirection.Output
        params(12).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateCourseRegistrationTemp", params)
        'Populate Error Code
        RetVal(0) = params(11).Value
        'Populate Error Hint
        RetVal(1) = params(12).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(11).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(12).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Creates Course Registration
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Course</remarks>
    Public Function CreateSelectiveCourseRegistration(ByVal Course As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionNameSelective", Course.SessionNameSelective), _
        New SqlParameter("@SemesterSelective", Course.SemesterSelective), _
        New SqlParameter("@CourseCodeSelective", Course.CourseCodeSelective), _
        New SqlParameter("@CourseNameSelective", Course.CourseNameSelective), _
        New SqlParameter("@CreditUnitSelective", Course.CreditUnitSelective)}

        Try
            'Create Course data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateSelectiveCourseRegistration", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a Level
    ''' </summary>
    ''' <param name="Level"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Level</remarks>
    Public Function CreateLevel(ByVal Level As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@LevelName", Level.LevelName), _
        New SqlParameter("@LevelNumber", Level.LevelNumber)}
        Try
            'Create Level data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateLevel", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a Semester
    ''' </summary>
    ''' <param name="Semester"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Semester</remarks>
    Public Function CreateSemester(ByVal Semester As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SemesterName", Semester.SemesterName)}
        Try
            'Create Semester data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateSemester", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a Session
    ''' </summary>
    ''' <param name="Session"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Session</remarks>
    Public Function CreateSession(ByVal Session As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", Session.SessionName)}
        Try
            'Create Session data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateSession", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a CourseDuration
    ''' </summary>
    ''' <param name="CourseDuration"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using CourseDuration</remarks>
    Public Function CreateCourseDuration(ByVal CourseDuration As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@Duration", CourseDuration.CourseDuration)}
        Try
            'Create CourseDuration data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateCourseDuration", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes Course from the database
    ''' </summary>
    ''' <param name="CourseID"></param>
    ''' <remarks>It deletes Course record from the database </remarks>
    Public Function DeleteCourse(ByVal CourseID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseID", CourseID)}
        Try
            'Delete Course data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteCourse", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes Level from the database
    ''' </summary>
    ''' <param name="LevelID"></param>
    ''' <remarks>It deletes Level record from the database </remarks>
    Public Function DeleteLevel(ByVal LevelID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@LevelID", LevelID)}
        Try
            'Delete Level data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteLevel", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes CourseDuration from the database
    ''' </summary>
    ''' <param name="DurationID"></param>
    ''' <remarks>It deletes CourseDuration record from the database </remarks>
    Public Function DeleteCourseDuration(ByVal DurationID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@DurationID", DurationID)}
        Try
            'Delete CourseDuration data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteCourseDuration", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Deletes Semester from the database
    ''' </summary>
    ''' <param name="SemesterID"></param>
    ''' <remarks>It deletes Semester record from the database </remarks>
    Public Function DeleteSemester(ByVal SemesterID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SemesterID", SemesterID)}
        Try
            'Delete Semester data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteSemester", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Deletes Session from the database
    ''' </summary>
    ''' <param name="SessionID"></param>
    ''' <remarks>It deletes Session record from the database </remarks>
    Public Function DeleteSession(ByVal SessionID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", SessionID)}
        Try
            'Delete Session data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteSession", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function


    ''' <summary>
    ''' Updates Course Data
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <remarks>It updates the database using SessionLevelSemesterCourseData</remarks>
    Public Function UpdateCourse(ByVal Course As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseID", Course.CourseID), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@SemesterID", Course.SemesterID), _
        New SqlParameter("@SessionID", Course.SessionID), _
        New SqlParameter("@LecturerID", Course.LecturerID), _
        New SqlParameter("@LevelID", Course.LevelID), _
        New SqlParameter("@ProgrammeID", Course.ProgrammeID), _
        New SqlParameter("@QualificationID", Course.QualificationID), _
        New SqlParameter("@CreditUnit", Course.CreditUnit)}
        Try
            'Modify Course data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateCourse", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Updates Level Data
    ''' </summary>
    ''' <param name="Level"></param>
    ''' <remarks>It updates the database using SessionLevelSemesterCourseData</remarks>
    Public Function UpdateLevel(ByVal Level As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@LevelID", Level.LevelID), _
        New SqlParameter("@LevelName", Level.LevelName)}
        Try
            'Modify Level data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateLevel", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Updates Semester Data
    ''' </summary>
    ''' <param name="Semester"></param>
    ''' <remarks>It updates the database using SessionLevelSemesterCourseData</remarks>
    Public Function UpdateSemester(ByVal Semester As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SemesterID", Semester.SemesterID), _
        New SqlParameter("@SemesterName", Semester.SemesterName)}
        Try
            'Modify Semester data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateSemester", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Updates CourseDuration Data
    ''' </summary>
    ''' <param name="CourseDuration"></param>
    ''' <remarks>It updates the database using SessionLevelSemesterCourseData</remarks>
    Public Function UpdateCourseDuration(ByVal CourseDuration As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseDurationID", CourseDuration.CourseDurationID), _
        New SqlParameter("@Duration", CourseDuration.CourseDuration)}
        Try
            'Modify CourseDuration data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateCourseDuration", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Updates Session Data
    ''' </summary>
    ''' <param name="Session"></param>
    ''' <remarks>It updates the database using SessionLevelSemesterCourseData</remarks>
    Public Function UpdateSession(ByVal Session As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", Session.SessionID), _
        New SqlParameter("@SessionName", Session.SessionName)}
        Try
            'Modify Session data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateSession", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Finds Course by CourseID
    ''' </summary>
    ''' <param name="CourseID"></param>
    ''' <returns>CourseData</returns>
    ''' <remarks>It takes CourseID and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindCourseByID(ByVal CourseID As Integer) As SessionLevelSemesterCourseData
        Dim Course As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CourseID", CourseID)}
        'Try
        'Fetch item based on CourseID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindCourseByID", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    Course.CourseID = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    Course.CourseCode = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    Course.CourseName = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    Course.SemesterID = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    Course.SemesterName = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    Course.SessionID = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    Course.SessionName = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    Course.LecturerID = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    Course.LecturerName = row(8)
                End If
                
                If Not IsDBNull(row(9)) Then
                    Course.LevelID = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    Course.LevelName = row(10)
                End If
                If Not IsDBNull(row(11)) Then
                    Course.CreatedByUserID = row(11)
                End If
                If Not IsDBNull(row(12)) Then
                    Course.FirstName = row(12)
                End If
                If Not IsDBNull(row(13)) Then
                    Course.CreditUnit = row(13)
                End If
                If Not IsDBNull(row(14)) Then
                    Course.ProgrammeID = row(14)
                End If
                If Not IsDBNull(row(15)) Then
                    Course.QualificationID = row(15)
                End If
                If Not IsDBNull(row(16)) Then
                    Course.ProgrammeName = row(16)
                End If
                If Not IsDBNull(row(17)) Then
                    Course.QualificationName = row(17)
                End If
            Next
            'Return Course data.
            Return Course
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try

    End Function
    ''' <summary>
    ''' Finds Level by LevelID
    ''' </summary>
    ''' <param name="LevelID"></param>
    ''' <returns>LevelData</returns>
    ''' <remarks>It takes LevelID and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindLevelByID(ByVal LevelID As Integer) As SessionLevelSemesterCourseData
        Dim Level As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@LevelID", LevelID)}
        Try
            'Fetch item based on LevelID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindLevelByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Level.LevelID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Level.LevelName = row(1)
                    End If
                    'If Not IsDBNull(row(2)) Then
                    '    Level.LevelNumber = row(2)
                    'End If
                    
                Next
                'Return Level data.
                Return Level
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds Semester by SemesterID
    ''' </summary>
    ''' <param name="SemesterID"></param>
    ''' <returns>SemesterData</returns>
    ''' <remarks>It takes SemesterID and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindSemesterByID(ByVal SemesterID As Integer) As SessionLevelSemesterCourseData
        Dim Semester As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SemesterID", SemesterID)}
        Try
            'Fetch item based on SemesterID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindSemesterByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Semester.SemesterID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Semester.SemesterName = row(1)
                    End If

                Next
                'Return Semester data.
                Return Semester
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds Semester by SemesterID
    ''' </summary>
    ''' <param name="CourseDurationID"></param>
    ''' <returns>CourseDurationData</returns>
    ''' <remarks>It takes SemesterID and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindCourseDurationByID(ByVal CourseDurationID As Integer) As SessionLevelSemesterCourseData
        Dim CourseDuration As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CourseDurationID", CourseDurationID)}
        Try
            'Fetch item based on CourseDurationID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindCourseDurationByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        CourseDuration.CourseDurationID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        CourseDuration.CourseDuration = row(1)
                    End If

                Next
                'Return CourseDuration data.
                Return CourseDuration
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds Session by SessionID
    ''' </summary>
    ''' <param name="SessionID"></param>
    ''' <returns>SessionData</returns>
    ''' <remarks>It takes SessionID and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindSessionByID(ByVal SessionID As Integer) As SessionLevelSemesterCourseData
        Dim Session As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SessionID", SessionID)}
        Try
            'Fetch item based on SessionID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindSessionByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Session.SessionID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Session.SessionName = row(1)
                    End If

                Next
                'Return Session data.
                Return Session
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Fetches all Courses to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCourses() As DataSet
        'Holds Courses Data
        Dim Courses As DataSet = New DataSet
        Try
            'Fetch all Courses.
            Courses = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCourses")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Courses data
        Return Courses
    End Function
    ''' <summary>
    ''' Fetches all Levels to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllLevels() As DataSet
        'Holds Levels Data
        Dim Levels As DataSet = New DataSet
        Try
            'Fetch all Levels.
            Levels = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllLevels")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Levels data
        Return Levels
    End Function
    ''' <summary>
    ''' Fetches all CourseDurations to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCourseDurations() As DataSet
        'Holds CourseDurations Data
        Dim CourseDurations As DataSet = New DataSet
        Try
            'Fetch all CourseDurations.
            CourseDurations = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCourseDurations")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched CourseDurations data
        Return CourseDurations
    End Function
    ''' <summary>
    ''' Fetches all Semesters to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllSemesters() As DataSet
        'Holds Semesters Data
        Dim Semesters As DataSet = New DataSet
        Try
            'Fetch all Semesters.
            Semesters = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllSemesters")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Semesters data
        Return Semesters
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllSessions() As DataSet
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Try
            'Fetch all Sessions.
            Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllSessions")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Sessions data
        Return Sessions
    End Function

    
    ''' <summary>
    ''' Finds Course by Course name
    ''' </summary>
    ''' <param name="CourseName"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes CourseName and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindCourseByName(ByVal CourseName As String) As SessionLevelSemesterCourseData
        Dim data As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CourseName", CourseName)}
        Try
            'Fetch all item based on Course name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindCourseByName", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    data.CourseID = row(0)
                    data.CourseCode = row(1)
                    If Not IsDBNull(row(2)) Then
                        data.CourseName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        data.SemesterID = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        data.SemesterName = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        data.SessionID = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        data.SessionName = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        data.LecturerID = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        data.LecturerName = row(8)
                    End If
                    
                    If Not IsDBNull(row(9)) Then
                        data.LevelID = row(9)
                    End If
                    If Not IsDBNull(row(10)) Then
                        data.LevelName = row(10)
                    End If
                    If Not IsDBNull(row(11)) Then
                        data.CreatedByUserID = row(11)
                    End If
                    If Not IsDBNull(row(12)) Then
                        data.FirstName = row(12)
                    End If
                    If Not IsDBNull(row(13)) Then
                        data.CreditUnit = row(13)
                    End If
                    If Not IsDBNull(row(14)) Then
                        data.ProgrammeID = row(14)
                    End If
                    If Not IsDBNull(row(15)) Then
                        data.QualificationID = row(15)
                    End If
                    If Not IsDBNull(row(16)) Then
                        data.ProgrammeName = row(16)
                    End If
                    If Not IsDBNull(row(17)) Then
                        data.QualificationName = row(17)
                    End If
                    
                Next
                Return data
            Else
                Return Nothing
            End If

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Finds Level by Level name
    ''' </summary>
    ''' <param name="LevelName"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes LevelName and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindLevelByName(ByVal LevelName As String) As SessionLevelSemesterCourseData
        Dim data As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@LevelName", LevelName)}
        Try
            'Fetch all item based on Level name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindLevelByName", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        data.LevelID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        data.LevelName = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        data.LevelNumber = row(2)
                    End If
                    
                Next
                Return data
            Else
                Return Nothing
            End If

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds Semester by Semester name
    ''' </summary>
    ''' <param name="SemesterName"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes SemesterName and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindSemesterByName(ByVal SemesterName As String) As SessionLevelSemesterCourseData
        Dim data As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SemesterName", SemesterName)}
        Try
            'Fetch all item based on Semester name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindSemesterByName", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        data.SemesterID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        data.SemesterName = row(1)
                    End If

                Next
                Return data
            Else
                Return Nothing
            End If

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds CourseDuration by CourseDuration name
    ''' </summary>
    ''' <param name="CourseDuration"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes SemesterName and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindCourseDurationByName(ByVal CourseDuration As String) As SessionLevelSemesterCourseData
        Dim data As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@Duration", CourseDuration)}
        Try
            'Fetch all item based on CourseDuration name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindCourseDurationByName", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        data.CourseDurationID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        data.CourseDuration = row(1)
                    End If

                Next
                Return data
            Else
                Return Nothing
            End If

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds Session by Session name
    ''' </summary>
    ''' <param name="SessionName"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes SessionName and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindSessionByName(ByVal SessionName As String) As SessionLevelSemesterCourseData
        Dim data As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SessionName", SessionName)}
        Try
            'Fetch all item based on Session name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindSessionByName", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        data.SessionID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        data.SessionName = row(1)
                    End If

                Next
                Return data
            Else
                Return Nothing
            End If

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Fetches all ModeOfAdmission to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllModeOfAdmissions() As DataSet
        'Holds AdmissionMode Data
        Dim AdmissionMode As DataSet = New DataSet
        Try
            'Fetch all AdmissionMode.
            AdmissionMode = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllAdmissionModes")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched AdmissionMode data
        Return AdmissionMode
    End Function

    ''' <summary>
    ''' Fetches all GetProgrammes to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function GetProgrammes() As DataSet
        'Holds AdmissionMode Data
        Dim Get_Programmes As DataSet = New DataSet
        Try
            'Fetch all AdmissionMode.
            Get_Programmes = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "GetProgrammes")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched AdmissionMode data
        Return Get_Programmes
    End Function

    ''' <summary>
    ''' Fetches all GetQualifications to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function GetQualifications() As DataSet
        'Holds AdmissionMode Data
        Dim Get_Qualifications As DataSet = New DataSet
        Try
            'Fetch all AdmissionMode.
            Get_Qualifications = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "GetQualifications")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched AdmissionMode data
        Return Get_Qualifications
    End Function



    ''' <summary>
    ''' Finds Courses by RegNumber name
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes RegNumber and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllCoursesByRegNo(ByVal RegNumber As String, ByVal SessionName As String) As DataSet

        Dim courses As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@SessionName", SessionName)}
        Try
            'Fetch all item based on courses name
            courses = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByRegNoBySession", params)

            Return courses

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Returns dataset via a reader
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <param name="Semester"></param>
    ''' <param name="CourseCode"></param>
    ''' <param name="SessionName"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes EmployeeNo and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindCoursebyRegSemCodeCdt(ByVal RegNumber As String, ByVal Semester As String, ByVal CourseCode As String, ByVal SessionName As String) As SessionLevelSemesterCourseData
        Dim data As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@CourseCode", CourseCode), _
        New SqlParameter("@SessionName", SessionName)}
        Try
            'Fetch all item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindCoursebyRegSemCodeCdt", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        data.RegNumber = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        data.Semester = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        data.CourseCode = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        data.SessionName = row(3)
                    End If

                Next
                Return data
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function

    '''' <summary>
    '''' Fetches ModeOfAdmission by IDto fill a dataset
    '''' </summary>
    '''' <returns>dataset</returns>
    '''' <remarks>it returns a dataset</remarks>
    'Public Function FindModeOfAdmissionByID() As DataSet
    '    'Holds AdmissionMode Data
    '    Dim AdmissionMode As DataSet = New DataSet
    '    Try
    '        'Fetch all AdmissionMode.
    '        AdmissionMode = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllAdmissionModes")
    '    Catch ex As Exception
    '        'If error occurs, log it and return nothing.
    '        AppException.LogError(ex.Message)
    '        Return Nothing
    '    End Try
    '    'Return fetched AdmissionMode data
    '    Return AdmissionMode
    'End Function

    ''' <summary>
    ''' Upload Result
    ''' </summary>
    ''' <param name="Result"></param>
    ''' <remarks>It Upload Result into the database using UploadResultData</remarks>
    Public Function UploadStudentResult(ByVal Result As SessionLevelSemesterCourseData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Result.RegNumber), _
        New SqlParameter("@SessionName", Result.SessionName), _
        New SqlParameter("@Semester", Result.Semester), _
        New SqlParameter("@CourseCode", Result.CourseCode), _
        New SqlParameter("@LevelName", Result.LevelName), _
        New SqlParameter("@ContinuosAssesment", Result.CA), _
        New SqlParameter("@Exams", Result.Exam), _
        New SqlParameter("@Total", Result.Total), _
        New SqlParameter("@Grade", Result.Grade), _
        New SqlParameter("@Remark", Result.Remark), _
        New SqlParameter("@ResultSheetUrl", Result.ResultSheetUrl), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByUID", Result.CreatedByUID), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}
        'Assigning value to the return value
        params(14).Direction = ParameterDirection.Output
        params(15).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadStudentResult", params)
            'Populate Error Code
            'RetVal(0) = params(14).Value
            'RetVal(1) = params(15).Value

            If Not IsDBNull(params(14).Value) Then
                RetVal(0) = params(14).Value
            End If
            'Populate Error Hint
            If Not IsDBNull(params(15).Value) Then
                RetVal(1) = params(15).Value
            End If
            Return RetVal
        Catch ex As Exception
            'Populate Error Code
            If Not IsDBNull(params(14).Value) Then
                RetVal(0) = params(14).Value
            End If
            'Populate Error Hint
            If Not IsDBNull(params(15).Value) Then
                RetVal(1) = params(15).Value
            End If
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Upload Result
    ''' </summary>
    ''' <param name="Result"></param>
    ''' <remarks>It Upload Result into the database using UploadResultData</remarks>
    Public Function EditStudentResult(ByVal Result As SessionLevelSemesterCourseData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Result.RegNumber), _
        New SqlParameter("@SessionName", Result.SessionName), _
        New SqlParameter("@Semester", Result.Semester), _
        New SqlParameter("@CourseCode", Result.CourseCode), _
        New SqlParameter("@LevelName", Result.LevelName), _
        New SqlParameter("@ContinuosAssesment", Result.CA), _
        New SqlParameter("@Exams", Result.Exam), _
        New SqlParameter("@Total", Result.Total), _
        New SqlParameter("@Grade", Result.Grade), _
        New SqlParameter("@Remark", Result.Remark), _
        New SqlParameter("@ResultSheetUrl", Result.ResultSheetUrl), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByUID", Result.CreatedByUID), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}
        'Assigning value to the return value
        params(14).Direction = ParameterDirection.Output
        params(15).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadAllStudentResultTemp", params)
            'Populate Error Code
            RetVal(0) = params(14).Value
            'Populate Error Hint
            RetVal(1) = params(15).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(14).Value
            'Populate Error Hint
            RetVal(1) = params(15).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Upload Result
    ''' </summary>
    ''' <param name="Result"></param>
    ''' <remarks>It Upload Result into the database using SessionLevelSemesterCourseData</remarks>
    Public Function UploadStudentResult1(ByVal Result As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Result.RegNumber), _
        New SqlParameter("@CourseCode", Result.CourseCode), _
        New SqlParameter("@ContinuosAssesment", Result.CA), _
        New SqlParameter("@Semester", Result.Semester), _
        New SqlParameter("@SessionName", Result.SessionName), _
        New SqlParameter("@Exams", Result.Exam), _
        New SqlParameter("@Total", Result.Total), _
        New SqlParameter("@Grade", Result.Grade), _
        New SqlParameter("@Remark", Result.Remark), _
        New SqlParameter("@Attempt", Result.Attempt), _
        New SqlParameter("@ResultUploadByID", Result.ResultUploadByID), _
        New SqlParameter("@ResultSheetUrl", Result.ResultUrl)}
        'Try
        'Modify Upload Result data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UploadResultRas1", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try

    End Function
    ''' <summary>
    ''' Finds Grade and Remark by Total name
    ''' </summary>
    ''' <param name="Total"></param>
    ''' <returns>String</returns>
    ''' <remarks>It takes Total and returns Grade and Remark </remarks>
    Public Function FindGradeAndRemarkByTotal(ByVal Total As String) As String()
        Dim GradeMark() As String = {"", ""}
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@Total", Total), _
        New SqlParameter("@Grade", SqlDbType.Char, 10), _
        New SqlParameter("@Remarks", SqlDbType.VarChar, 100)}
        params(1).Direction = ParameterDirection.Output
        params(2).Direction = ParameterDirection.Output
        Try
            'Fetch all item based on courses name
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "FindGradeAndRemarkByTotal", params)
            If Not IsDBNull(params(1).Value) Then
                'Fetch Grade
                GradeMark(0) = params(1).Value
            End If
            If Not IsDBNull(params(2).Value) Then
                'Fetch Remark
                GradeMark(1) = params(2).Value
            End If
            Return GradeMark
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Finds RegNum, Continuos Assesment, Exams score, Total Score and Remarks by Coursecode, Dept, Semester and Session
    ''' </summary>
    ''' <param name="CourseCode"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course code, Dept, Semester and session, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindDepartmentalResult(ByVal CourseCode As String, ByVal SessionName As String, ByVal Semester As String, ByVal DeptID As Integer) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CourseCode", CourseCode), _
                                        New SqlParameter("@SessionName", SessionName), _
                                        New SqlParameter("@Semester", Semester), _
                                        New SqlParameter("@DeptID", DeptID)}
        Try
            'Fetch all item based on Course code, Dept, Semester and session
            DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindDeptResult", params)

            Return DeptReultDataSet

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds RegNum, Continuos Assesment, Exams score, Total Score and Remarks by Coursecode, Dept, Semester and Session
    ''' </summary>
    ''' <param name="CourseCode"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course code, Dept, Semester and session, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindDepartmentalResultInfo(ByVal CourseCode As String, ByVal SessionName As String, ByVal Semester As String) As SessionLevelSemesterCourseData
        'Declaring the variables
        Dim data As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CourseCode", CourseCode), _
                                        New SqlParameter("@SessionName", SessionName), _
                                        New SqlParameter("@Semester", Semester)}
        'Try
        'Fetch all item based on Course code, Dept, Semester and session
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindDepartmentalResultInfo", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then

            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    data.CourseCode = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    data.CourseName = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    data.LecturerName = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    data.Semester = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    data.SessionName = row(4)
                End If

            Next
            Return data
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Finds RegNum, Continuos Assesment, Exams score, Total Score and Remarks by Coursecode, Dept, Semester and Session
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course code, Dept, Semester and session, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindStudentSessionResult(ByVal RegNumber As String, ByVal SessionName As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), _
                                        New SqlParameter("@SessionName", SessionName)}
        Try
            'Fetch all item based on Registration Number, Session Name
            DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindStudentSessionResult", params)

            Return DeptReultDataSet

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds RegNum, Continuos Assesment, Exams score, Total Score and Remarks by Coursecode, Dept, Semester and Session
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course code, Dept, Semester and session, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindStudentSessionResultInfo(ByVal RegNumber As String, ByVal SessionName As String) As SessionLevelSemesterCourseData
        'Declaring the variables
        Dim data As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), _
                                        New SqlParameter("@SessionName", SessionName)}
        'Try
        'Fetch all item based on Student, Registration Number, Department, Academic Session
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStudentSessionResultInfo", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then

            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    data.FirstName = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    data.LastName = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    data.RegNumber = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    data.DeptName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    data.SessionName = row(4)
                End If


            Next
            Return data
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Finds RegNum, Continuos Assesment, Exams score, Total Score and Remarks by Coursecode, Dept, Semester and Session
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course code, Dept, Semester and session, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindStudentSemesterResult(ByVal RegNumber As String, ByVal SessionName As String, ByVal Semester As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), _
                                        New SqlParameter("@SessionName", SessionName), _
                                        New SqlParameter("@Semester", Semester)}
        Try
            'Fetch all item based on Registration Number, Session Name, Semester
            DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindStudentSemesterResult", params)

            Return DeptReultDataSet

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds RegNum, Continuos Assesment, Exams score, Total Score and Remarks by Coursecode, Dept, Semester and Session
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course code, Dept, Semester and session, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindStudentSemesterResultInfo(ByVal RegNumber As String, ByVal SessionName As String) As SessionLevelSemesterCourseData
        'Declaring the variables
        Dim data As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), _
                                        New SqlParameter("@SessionName", SessionName)}
        'Try
        'Fetch all item based on Student, Registration Number, SessionName, Semester
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStudentSemesterResultInfo", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then

            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    data.FirstName = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    data.LastName = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    data.RegNumber = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    data.DeptName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    data.SessionName = row(4)
                End If


            Next
            Return data
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function

    ''' <summary>
    ''' Fetches Dept by Faculty to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindDeptByFacultyId(ByVal FacultyId As Integer) As DataSet
        'Holds Dept Data
        Dim Dept As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@FacultyID", FacultyId)}
        Try
            'Fetch all Dept based on the Faculty.
            Dept = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindDeptByFacultyId", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Dept data
        Return Dept
    End Function
    ''' <summary>
    ''' Upload Result
    ''' </summary>
    ''' <param name="Result"></param>
    ''' <remarks>It Upload Result into the database using UploadResultData</remarks>
    Public Function UploadStudentIndividualResult(ByVal Result As SessionLevelSemesterCourseData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Result.RegNumber), _
        New SqlParameter("@SessionName", Result.SessionName), _
        New SqlParameter("@Semester", Result.Semester), _
        New SqlParameter("@CourseCode", Result.CourseCode), _
        New SqlParameter("@ContinuosAssesment", Result.CA), _
        New SqlParameter("@Exams", Result.Exam), _
        New SqlParameter("@Total", Result.Total), _
        New SqlParameter("@Grade", Result.Grade), _
        New SqlParameter("@Remark", Result.Remark), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByUID", Result.CreatedByUID), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}
        'Assigning value to the return value
        params(12).Direction = ParameterDirection.Output
        params(13).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateStudentIndividualProfile", params)
            'Populate Error Code
            RetVal(0) = params(12).Value
            'Populate Error Hint
            RetVal(1) = params(13).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(9).Value
            'Populate Error Hint
            RetVal(1) = params(10).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Finds RegNum, Continuos Assesment, Exams score
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>UploadResultData</returns>
    ''' <remarks>It takes Course code, Dept, Semester and session, then returns UploadResultData </remarks>
    Public Function FindContinuosAssesmentExams(ByVal RegNumber As String, ByVal SessionName As String, ByVal Semester As String, ByVal CourseCode As Char) As SessionLevelSemesterCourseData
        'Declaring the variables
        Dim data As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), _
                                        New SqlParameter("@SessionName", SessionName), _
                                        New SqlParameter("@Semester", Semester), _
                                        New SqlParameter("@CourseCode", CourseCode)}
        'Try
        'Fetch all item based on Student, Registration Number, SessionName, Semester
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindContinuosAssesmentExams", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then

            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    data.CA = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    data.Exam = row(1)
                End If

            Next
            Return data
        Else
            Return Nothing
        End If

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Creates a PostUME Amount
    ''' </summary>
    ''' <param name="PostUMEAmount"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates PostUMEAmount using PostUMEAmount</remarks>
    Public Function CreatePostUMEAmount(ByVal PostUMEAmount As Decimal, ByVal HiddenFieldPostUMEFee As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@PostUMEAmount", PostUMEAmount), _
         New SqlParameter("@PostUMESession", PostUMESessionName), _
         New SqlParameter("@CreatedByUID", HiddenFieldPostUMEFee)}
        Try
            'Create PostUMEAmount data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreatePostUMEAmount", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Fetches all PostUMEFee to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllPostUMEFee() As DataSet
        'Holds PostUMEFee Data
        Dim PostUMEFee As DataSet = New DataSet
        Try
            'Fetch all PostUMEFee.
            PostUMEFee = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllPostUMEFee")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched PostUMEFee data
        Return PostUMEFee
    End Function
    ''' <summary>
    ''' Find Post UME Fee By ID
    ''' </summary>
    ''' <returns>Decimal</returns>
    ''' <remarks>it returns a Decimal</remarks>
    Public Function FindPostUMEFeeByID(ByVal PostUMEFeeID As Integer) As Decimal
        'Declaring the parameters
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Holds PostUMEFee Data
        Dim PostUMEFee As Decimal
        Dim params() As SqlParameter = _
        {New SqlParameter("@PostUMEFeeID", PostUMEFeeID)}
        Try
            'Find Post UME Fee By ID.
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindPostUMEFeeByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        PostUMEFee = row(0)
                    End If
                Next
                Return PostUMEFee
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Updates PostUMEFee Data
    ''' </summary>
    ''' <param name="PostUMEFee"></param>
    ''' <remarks>It updates the database using PostUMEFee</remarks>
    Public Function UpdatePostUMEFee(ByVal PostUMEFeeID As Integer, ByVal PostUMEFee As Decimal, ByVal CreatedByUID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@PostUMEFeeID", PostUMEFeeID), _
        New SqlParameter("@PostUMEFeeAmount", PostUMEFee), _
        New SqlParameter("@CreatedByID", CreatedByUID)}
        Try
            'Modify PostUMEFeeAmount data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdatePostUMEFee", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function

    ''' <summary>
    ''' Fetches Courses by RegNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCoursesBySessionIDLevelID(ByVal SessionID As Integer, ByVal LevelID As Integer) As DataSet
        'Holds Courses Data
        Dim Courses As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", SessionID), _
        New SqlParameter("@LevelID", LevelID)}
        'Try
        'Fetch all Courses based on the RegNumber.
        Courses = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesBySessionIDLevelID", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched Courses data
        Return Courses
    End Function

    ''' <summary>
    ''' Fetches Courses by RegNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCoursesBySessionIDLevelID1(ByVal SessionID As Integer, ByVal LevelID As Integer) As DataSet
        'Holds Courses Data
        Dim Courses As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", SessionID), _
        New SqlParameter("@LevelID", LevelID)}
        'Try
        'Fetch all Courses based on the RegNumber.
        Courses = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesBySessionIDLevelID1", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched Courses data
        Return Courses
    End Function
    ''' <summary>
    ''' Fetches Courses by RegNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCoursesByLevelID1(ByVal LevelID As Integer) As DataSet
        'Holds Courses Data
        Dim Courses As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@LevelID", LevelID)}
        'Try
        'Fetch all Courses based on the RegNumber.
        Courses = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByLevelID1", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched Courses data
        Return Courses
    End Function
    ''' <summary>
    ''' Fetches Selective Courses by RegNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllSelectiveCoursesByRegNumber(ByVal RegNumber As String) As DataSet
        'Holds Selective Courses Data
        Dim Courses As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber)}
        Try
            'Fetch all Selective Courses based on the RegNumber.
            Courses = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllSelectiveCoursesByRegNumber", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Selective Courses data
        Return Courses
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="LevelID"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllCoursesBySemesterIDLevelID(ByVal LevelID As Integer, ByVal SemesterID As Integer) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@LevelID", LevelID), _
                                        New SqlParameter("@SemesterID", SemesterID)}
        Try
            'Fetch all item based on LevelID and SemesterID
            DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesBySemesterIDLevelID", params)

            Return DeptReultDataSet

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="LevelID"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllLecturerBySemesterIDLevelID(ByVal LevelID As Integer, ByVal SemesterID As Integer) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@LevelID", LevelID), _
                                        New SqlParameter("@SemesterID", SemesterID)}
        Try
            'Fetch all item based on LevelID and SemesterID
            DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllLecturerBySemesterIDLevelID", params)

            Return DeptReultDataSet

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="LevelID"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindLecturerCoursesBySemesterIDLevelIDSessionID(ByVal LevelID As Integer, ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal Lecturer As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@LevelID", LevelID), _
                                        New SqlParameter("@SessionID", SessionID), _
                                        New SqlParameter("@Lecturer", Lecturer), _
                                        New SqlParameter("@SemesterID", SemesterID)}
        'Try
        'Fetch all item based on LevelID and SemesterID
        DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindLecturerCoursesBySemesterIDLevelIDSessionID", params)

        Return DeptReultDataSet

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="LevelID"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllCoursesByLevelID(ByVal LevelID As Integer) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@LevelID", LevelID)}
        Try
            'Fetch all item based on LevelID and SemesterID
            DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByLevelID", params)

            Return DeptReultDataSet

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllCoursesByRegNo2(ByVal RegNumber As String, ByVal LevelName As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@LevelName", LevelName)}
        Try
            'Fetch all item based on LevelID and SemesterID
            DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByRegNo", params)

            Return DeptReultDataSet

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllCoursesByRegNo1(ByVal RegNumber As String, ByVal LevelName As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@LevelName", LevelName)}
        Try
            'Fetch all item based on LevelID and SemesterID
            DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByRegNo1", params)

            Return DeptReultDataSet

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllCoursesByRegNos1(ByVal RegNumber As String, ByVal LevelName As String, ByVal Session As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@LevelName", LevelName), New SqlParameter("@Session", Session)}
        'Try
        'Fetch all item based on LevelID and SemesterID
        DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByRegNos1", params)

        Return DeptReultDataSet

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllCoursesByRegNos2(ByVal RegNumber As String, ByVal LevelName As String, ByVal Session As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@LevelName", LevelName), New SqlParameter("@Session", Session)}
        ' Try
        'Fetch all item based on LevelID and SemesterID
        DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByRegNos2", params)

        Return DeptReultDataSet

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllCoursesByRegNoLevel(ByVal RegNumber As String, ByVal LevelName As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@LevelName", LevelName)}
        Try
            'Fetch all item based on LevelID and SemesterID
            DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByRegNoLevel", params)

            Return DeptReultDataSet

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllCoursesByRegNoLevel1(ByVal RegNumber As String, ByVal LevelName As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@LevelName", LevelName)}
        Try
            'Fetch all item based on LevelID and SemesterID
            DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByRegNoLevel1", params)

            Return DeptReultDataSet

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Fetches RegNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllRegNumberBySessionID(ByVal SessionID As Integer) As DataSet
        'Holds Selective Courses Data
        Dim Courses As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", SessionID)}
        Try
            'Fetch all Selective Courses based on the RegNumber.
            Courses = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllRegNumberBySessionID", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Selective Courses data
        Return Courses
    End Function
    ''' <summary>
    ''' Find All GPA
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>String</returns>
    ''' <remarks>It takes RegNumber and session and returns Grade and Remark </remarks>
    Public Function FindAllGPA(ByVal RegNumber As String, ByVal SessionName As String, ByVal Semester As String) As String()
        Dim GradeMark() As String = {"", "", ""}
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@SessionName", SessionName), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@Total", SqlDbType.Decimal, 18), _
        New SqlParameter("@SumTotalQualityPoint", SqlDbType.Decimal, 18), _
        New SqlParameter("@TotalCreditLoad", SqlDbType.Decimal, 18)}
        params(3).Direction = ParameterDirection.Output
        params(4).Direction = ParameterDirection.Output
        params(5).Direction = ParameterDirection.Output
        'Try
        'Fetch all item based on courses name
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "FindAllGPA", params)
        If Not IsDBNull(params(3).Value) Then
            'Fetch Grade
            GradeMark(0) = params(3).Value
        End If
        If Not IsDBNull(params(4).Value) Then
            'Fetch Remark
            GradeMark(1) = params(4).Value
        End If
        If Not IsDBNull(params(5).Value) Then
            'Fetch Remark
            GradeMark(2) = params(5).Value
        End If
        Return GradeMark
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Find All GPA
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>String</returns>
    ''' <remarks>It takes RegNumber and session and returns Grade and Remark </remarks>
    Public Function FindAllGPA1(ByVal RegNumber As String, ByVal SessionName As String) As String()
        Dim GradeMark() As String = {"", "", ""}
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@SessionName", SessionName), _
        New SqlParameter("@Total", SqlDbType.Decimal, 18), _
        New SqlParameter("@SumTotalQualityPoint", SqlDbType.Decimal, 18), _
        New SqlParameter("@TotalCreditLoad", SqlDbType.Decimal, 18)}
        params(2).Direction = ParameterDirection.Output
        params(3).Direction = ParameterDirection.Output
        params(4).Direction = ParameterDirection.Output
        'Try
        'Fetch all item based on courses name
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "FindAllGPA1", params)
        If Not IsDBNull(params(2).Value) Then
            'Fetch Grade
            GradeMark(0) = params(2).Value
        End If
        If Not IsDBNull(params(3).Value) Then
            'Fetch Remark
            GradeMark(1) = params(3).Value
        End If
        If Not IsDBNull(params(4).Value) Then
            'Fetch Remark
            GradeMark(2) = params(4).Value
        End If
        Return GradeMark
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Find SessionName By SessionID
    ''' </summary>
    ''' <param name="SessionID"></param>
    ''' <returns>String</returns>
    ''' <remarks>It takes SessionID and session and returns SessionName </remarks>
    Public Function FindSessionNameBySessionID(ByVal SessionID As Integer) As String
        Dim SessionName As String = String.Empty
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SessionID", SessionID), _
        New SqlParameter("@SessionName", SqlDbType.VarChar, 250)}
        params(1).Direction = ParameterDirection.Output

        'Try
        'Fetch all item based on courses name
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "FindSessionNameBySessionID", params)
        If Not IsDBNull(params(1).Value) Then
            'Fetch Grade
            SessionName = params(1).Value
        End If

        Return SessionName
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Fetches all Year to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllYear() As DataSet
        'Holds PostUMEFee Data
        Dim Year As DataSet = New DataSet
        Try
            'Fetch all PostUMEFee.
            Year = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllYear")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Year data
        Return Year
    End Function
    ''' <summary>
    ''' Creates a SchoolFees
    ''' </summary>
    ''' <param name="SchoolFees"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Semester</remarks>
    Public Function CreateSchoolFees(ByVal SchoolFees As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@TypeSchool", SchoolFees.TypeSchool), _
        New SqlParameter("@SchoolFeesAmount", SchoolFees.SchoolFeesAmount), _
        New SqlParameter("@DeptID", SchoolFees.DeptID), _
        New SqlParameter("@FacultyID", SchoolFees.FacultyID), _
        New SqlParameter("@SessionID", SchoolFees.SessionID), _
        New SqlParameter("@SemesterID", SchoolFees.SemesterID), _
        New SqlParameter("@LevelID", SchoolFees.LevelID), _
        New SqlParameter("@AmountInwords", SchoolFees.AmountInwords)}
        'Try
        'Create SchoolFees data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateSchoolFees", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return 0
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllSchoolFees() As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet
        Try
            'Fetch all SchoolFees.
            SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllSchoolFees")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllSchoolFeesBySessionFaculty(ByVal FacultyID As Integer, ByVal DeptID As Integer, ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal LevelID As Integer) As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@FacultyID", FacultyID), _
        New SqlParameter("@DeptID", DeptID), _
        New SqlParameter("@LevelID", LevelID), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@SessionID", SessionID)}
        'Try
        'Fetch all SchoolFees.
        SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllSchoolFeesBySessionFaculty", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Find SchoolFees By ID
    ''' </summary>
    ''' <returns>Decimal</returns>
    ''' <remarks>it returns a Decimal</remarks>
    Public Function FindSchoolFeesByID(ByVal SchoolFeesID As Integer) As SessionLevelSemesterCourseData
        'Declaring the parameters
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Holds PostUMEFee Data
        Dim SchoolFeesData As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim params() As SqlParameter = _
        {New SqlParameter("@SchoolFeesID", SchoolFeesID)}
        'Try
        'Find Post UME Fee By ID.
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindSchoolFeesByID", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then

            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    SchoolFeesData.SchoolFeesID = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    SchoolFeesData.TypeSchool = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    SchoolFeesData.SchoolFeesAmount = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    SchoolFeesData.FacultyID = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    SchoolFeesData.FacultyName = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    SchoolFeesData.DeptID = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    SchoolFeesData.DeptName = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    SchoolFeesData.AmountInwords = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    SchoolFeesData.SessionID = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    SchoolFeesData.SessionName = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    SchoolFeesData.LevelID = row(10)
                End If
                If Not IsDBNull(row(11)) Then
                    SchoolFeesData.LevelName = row(11)
                End If
                If Not IsDBNull(row(12)) Then
                    SchoolFeesData.SemesterID = row(12)
                End If
                If Not IsDBNull(row(13)) Then
                    SchoolFeesData.SemesterName = row(13)
                End If
            Next
            Return SchoolFeesData
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Edit a SchoolFees
    ''' </summary>
    ''' <param name="SchoolFees"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Semester</remarks>
    Public Function EditSchoolFees(ByVal SchoolFees As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SchoolFeesID", SchoolFees.SchoolFeesID), _
        New SqlParameter("@TypeSchool", SchoolFees.TypeSchool), _
        New SqlParameter("@SchoolFeesAmount", SchoolFees.SchoolFeesAmount), _
        New SqlParameter("@FacultyID", SchoolFees.FacultyID), _
        New SqlParameter("@LevelID", SchoolFees.LevelID), _
        New SqlParameter("@DeptID", SchoolFees.DeptID), _
        New SqlParameter("@SessionID", SchoolFees.SessionID), _
        New SqlParameter("@SemesterID", SchoolFees.SemesterID), _
        New SqlParameter("@AmountInwords", SchoolFees.AmountInwords)}
        'Try
        'Edit SchoolFees data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "EditSchoolFees", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return 0
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' Delete a SchoolFees
    ''' </summary>
    ''' <param name="SchoolFees"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Semester</remarks>
    Public Function DeleteSchoolFees(ByVal SchoolFees As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SchoolFeesID", SchoolFees.SchoolFeesID)}
        Try
            'Edit SchoolFees data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteSchoolFees", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes Level from the database
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <remarks>It deletes Level record from the database </remarks>
    Public Function DeleteTempCourses(ByVal RegNumber As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber)}
        Try
            'Delete Level data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteTempCourses", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes Level from the database
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <remarks>It deletes Level record from the database </remarks>
    Public Function DeleteRegisteredCourses(ByVal RegNumber As String, ByVal LevelName As String, ByVal SessionName As String, ByVal Semester As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), _
         New SqlParameter("@LevelName", LevelName), _
         New SqlParameter("@SessionName", SessionName), _
         New SqlParameter("@Semester", Semester)}
        ' Try
        'Delete Level data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteRegisteredCourses", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' Deletes Level from the database
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <remarks>It deletes Level record from the database </remarks>
    Public Function DeleteRegisteredCourses_CarryOver(ByVal RegNumber As String, ByVal LevelName As String, ByVal SessionName As String, ByVal Semester As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), _
         New SqlParameter("@LevelName", LevelName), _
         New SqlParameter("@SessionName", SessionName), _
         New SqlParameter("@Semester", Semester)}
        ' Try
        'Delete Level data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteRegisteredCourses_CarryOver", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllGeneratedSchoolFees() As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet
        Try
            'Fetch all SchoolFees.
            SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllGeneratedSchoolFees")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllResultGeneratedSchoolFees() As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet
        Try
            'Fetch all SchoolFees.
            SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllResultGeneratedSchoolFees")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function

    ''' <summary>
    ''' Generate Pin
    ''' </summary>
    ''' <param name="SessionID"></param>
    ''' <returns>Student</returns>
    ''' <remarks>Generate Pin</remarks>
    Public Function GeneratePin(ByVal ETransactPin As String, ByVal NoOfGenNo As String, ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal FacultyID As Integer, ByVal DeptID As Integer, ByVal LevelID As Integer, ByVal CreatedByUID As Integer) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@NoOfGenNo", NoOfGenNo), _
        New SqlParameter("@SessionID", SessionID), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@FacultyID", FacultyID), _
        New SqlParameter("@DeptID", DeptID), _
        New SqlParameter("@LevelID", LevelID), _
        New SqlParameter("@CreatedByUID", CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(9).Direction = ParameterDirection.Output
        params(10).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_GeneratePinNumber", params)
        'Populate Error Code
        RetVal(0) = params(9).Value
        'Populate Error Hint
        RetVal(1) = params(10).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(7).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(8).Value
        '    'Populate StudentProfileID
        'End Try
    End Function

    ''' <summary>
    ''' Generate Pin
    ''' </summary>
    ''' <param name="SessionID"></param>
    ''' <returns>Student</returns>
    ''' <remarks>Generate Pin</remarks>
    Public Function GenerateResultPin(ByVal ETransactPin As String, ByVal NoOfGenNo As String, ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal FacultyID As Integer, ByVal DeptID As Integer, ByVal LevelID As Integer, ByVal CreatedByUID As Integer) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@NoOfGenNo", NoOfGenNo), _
        New SqlParameter("@SessionID", SessionID), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@FacultyID", FacultyID), _
        New SqlParameter("@DeptID", DeptID), _
        New SqlParameter("@LevelID", LevelID), _
        New SqlParameter("@CreatedByUID", CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(9).Direction = ParameterDirection.Output
        params(10).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_GenerateResultPinNumber", params)
        'Populate Error Code
        RetVal(0) = params(9).Value
        'Populate Error Hint
        RetVal(1) = params(10).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(7).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(8).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    Public Function ClearGeneratedPin() As Integer
        'Declare and initialize data access parameters
        'Dim params() As SqlParameter = _
        '{New SqlParameter("@LevelName", Level.LevelName), _
        'New SqlParameter("@LevelNumber", Level.LevelNumber)}
        Try
            'Create Level data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "ClearGeneratedPin")
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    Public Function ClearResultGeneratedPin() As Integer
        'Declare and initialize data access parameters
        'Dim params() As SqlParameter = _
        '{New SqlParameter("@LevelName", Level.LevelName), _
        'New SqlParameter("@LevelNumber", Level.LevelNumber)}
        Try
            'Create Level data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "ClearResultGeneratedPin")
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Fetches all CourseDurations to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllClearedGenerated(ByVal SessionID As Integer, ByVal LevelID As Integer, ByVal SemesterID As Integer) As DataSet
        'Holds CourseDurations Data
        Dim CourseDurations As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", SessionID), _
         New SqlParameter("@LevelID", LevelID), _
         New SqlParameter("@SemesterID", SemesterID)}
        Try
            'Fetch all CourseDurations.
            CourseDurations = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllClearedGenerated", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched CourseDurations data
        Return CourseDurations
    End Function
    ''' <summary>
    ''' Fetches all CourseDurations to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllClearedResultGenerated(ByVal SessionID As Integer, ByVal LevelID As Integer, ByVal SemesterID As Integer) As DataSet
        'Holds CourseDurations Data
        Dim CourseDurations As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", SessionID), _
         New SqlParameter("@LevelID", LevelID), _
         New SqlParameter("@SemesterID", SemesterID)}
        Try
            'Fetch all CourseDurations.
            CourseDurations = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllClearedResultGenerated", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched CourseDurations data
        Return CourseDurations
    End Function
    ''' <summary>
    ''' Creates a Course
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Course</remarks>
    Public Function CreateTime(ByVal Time As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@YearName", Time.YearName), _
        New SqlParameter("@Month", Time.Month), _
        New SqlParameter("@Day", Time.Day), _
        New SqlParameter("@Hour", Time.Hour), _
        New SqlParameter("@Minute", Time.Minute), _
        New SqlParameter("@Note", Time.Note)}
        Try
            'Create Course data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateTime", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Find Post UME Fee By ID
    ''' </summary>
    ''' <returns>Decimal</returns>
    ''' <remarks>it returns a Decimal</remarks>
    Public Function FindTime() As SessionLevelSemesterCourseData
        'Declaring the parameters
        Dim RetData As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Holds PostUMEFee Data
        Try
            'Find Post UME Fee By ID.
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTime")
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        RetData.YearName = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        RetData.Month = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        RetData.Day = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        RetData.Hour = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        RetData.Minute = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        RetData.Note = row(5)
                    End If
                Next
                Return RetData
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Creates a Course
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Course</remarks>
    Public Function UploadAdmissionList(ByVal RegNumber As String, ByVal ExamNo As String, ByVal SerialNo As String, ByVal Names As String, ByVal Gender As String, ByVal Department As String, ByVal AGG As String, ByVal PhoneNumer As String, ByVal Batch As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@ExamNo", ExamNo), _
        New SqlParameter("@SerialNo", SerialNo), _
        New SqlParameter("@Names", Names), _
        New SqlParameter("@Gender", Gender), _
        New SqlParameter("@Department", Department), _
        New SqlParameter("@AGG", AGG), _
        New SqlParameter("@Batch", Batch), _
        New SqlParameter("@PhoneNumer", PhoneNumer)}
        Try
            'Create Course data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UploadAdmissionList", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a Course
    ''' </summary>
    ''' <param name="Surname"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Course</remarks>
    Public Function UploadGraduateList(ByVal Surname As String, ByVal FirstName As String, ByVal Level As String, ByVal Dept As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@Surname", Surname), _
        New SqlParameter("@FirstName", FirstName), _
        New SqlParameter("@Level", Level), _
        New SqlParameter("@Dept", Dept)}
        Try
            'Create Course data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UploadGraduateList", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllAdmissionList() As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet
        Try
            'Fetch all SchoolFees.
            SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllAdmissionList")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllAdmissionListB() As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet
        Try
            'Fetch all SchoolFees.
            SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllAdmissionListB")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllGraduationList() As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet
        Try
            'Fetch all SchoolFees.
            SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllGraduationList")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Find SchoolFees By ID
    ''' </summary>
    ''' <returns>Decimal</returns>
    ''' <remarks>it returns a Decimal</remarks>
    Public Function FindSchoolFeesByFacultyDeptSession(ByVal DataValue As SessionLevelSemesterCourseData) As SessionLevelSemesterCourseData
        'Declaring the parameters
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Holds PostUMEFee Data
        Dim SchoolFeesData As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", DataValue.SessionID), _
        New SqlParameter("@FacultyID", DataValue.FacultyID), _
        New SqlParameter("@DeptID", DataValue.DeptID), _
        New SqlParameter("@SemesterID", DataValue.SemesterID), _
        New SqlParameter("@LevelID", DataValue.LevelID), _
        New SqlParameter("@TypeSchool", DataValue.TypeSchool)}
        'Try
        'Find Post UME Fee By ID.
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindSchoolFeesByFacultyDeptSession", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then

            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    SchoolFeesData.SchoolFeesID = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    SchoolFeesData.TypeSchool = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    SchoolFeesData.SchoolFeesAmount = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    SchoolFeesData.FacultyID = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    SchoolFeesData.FacultyName = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    SchoolFeesData.DeptID = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    SchoolFeesData.DeptName = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    SchoolFeesData.AmountInwords = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    SchoolFeesData.SessionID = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    SchoolFeesData.SessionName = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    SchoolFeesData.LevelID = row(10)
                End If
                If Not IsDBNull(row(11)) Then
                    SchoolFeesData.LevelName = row(11)
                End If
                If Not IsDBNull(row(12)) Then
                    SchoolFeesData.SemesterID = row(12)
                End If
                If Not IsDBNull(row(13)) Then
                    SchoolFeesData.SemesterName = row(13)
                End If
            Next
            Return SchoolFeesData
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllGeneratedSchoolFeesByFacultyDept(ByVal RetData As SessionLevelSemesterCourseData) As DataSet
        'Holds PostUMEFee Data
        Dim params() As SqlParameter = _
                {New SqlParameter("@SessionID", RetData.SessionID), _
                New SqlParameter("@FacultyID", RetData.FacultyID), _
                New SqlParameter("@DeptID", RetData.DeptID), _
                New SqlParameter("@SemesterID", RetData.SemesterID), _
                New SqlParameter("@LevelID", RetData.LevelID)}

        Dim SchoolFees As DataSet = New DataSet
        'Try
        'Fetch all SchoolFees.
        SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllGeneratedSchoolFeesByFacultyDept", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllResultGeneratedSchoolFeesByFacultyDept(ByVal RetData As SessionLevelSemesterCourseData) As DataSet
        'Holds PostUMEFee Data
        Dim params() As SqlParameter = _
                {New SqlParameter("@SessionID", RetData.SessionID), _
                New SqlParameter("@FacultyID", RetData.FacultyID), _
                New SqlParameter("@DeptID", RetData.DeptID), _
                New SqlParameter("@SemesterID", RetData.SemesterID), _
                New SqlParameter("@LevelID", RetData.LevelID)}

        Dim SchoolFees As DataSet = New DataSet
        'Try
        'Fetch all SchoolFees.
        SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllResultGeneratedSchoolFeesByFacultyDept", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function RemoveCourseRegistrations(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(11).Direction = ParameterDirection.Output
        params(12).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_RemoveCourseRegistrations", params)
        'Populate Error Code
        RetVal(0) = params(11).Value
        'Populate Error Hint
        RetVal(1) = params(12).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(11).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(12).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function RemoveCourseRegistrations_ExtraYear(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(11).Direction = ParameterDirection.Output
        params(12).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_RemoveCourseRegistrations_ExtraYear", params)
        'Populate Error Code
        RetVal(0) = params(11).Value
        'Populate Error Hint
        RetVal(1) = params(12).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(11).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(12).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function RemoveCourseRegistrations_Summer(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(11).Direction = ParameterDirection.Output
        params(12).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_RemoveCourseRegistrations_Summer", params)
        'Populate Error Code
        RetVal(0) = params(11).Value
        'Populate Error Hint
        RetVal(1) = params(12).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(11).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(12).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function RemoveCourseRegistrations_CarryOver(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(11).Direction = ParameterDirection.Output
        params(12).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_RemoveCourseRegistrations_CarryOver", params)
        'Populate Error Code
        RetVal(0) = params(11).Value
        'Populate Error Hint
        RetVal(1) = params(12).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(11).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(12).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function RemoveAllCourseRegistrations(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(11).Direction = ParameterDirection.Output
        params(12).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_RemoveAllCourseRegistrations", params)
        'Populate Error Code
        RetVal(0) = params(11).Value
        'Populate Error Hint
        RetVal(1) = params(12).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(11).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(12).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function RemoveAllCourseRegistrations_ExtraYear(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(11).Direction = ParameterDirection.Output
        params(12).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_RemoveAllCourseRegistrations_ExtraYear", params)
        'Populate Error Code
        RetVal(0) = params(11).Value
        'Populate Error Hint
        RetVal(1) = params(12).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(11).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(12).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function RemoveAllCourseRegistrations_Summer(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(11).Direction = ParameterDirection.Output
        params(12).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_RemoveAllCourseRegistrations_Summer", params)
        'Populate Error Code
        RetVal(0) = params(11).Value
        'Populate Error Hint
        RetVal(1) = params(12).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(11).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(12).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function RemoveAllCourseRegistrations_CarryOver(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(11).Direction = ParameterDirection.Output
        params(12).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_RemoveAllCourseRegistrations_CarryOver", params)
        'Populate Error Code
        RetVal(0) = params(11).Value
        'Populate Error Hint
        RetVal(1) = params(12).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(11).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(12).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function AddCourseRegistrations(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@LecturerName", Course.LecturerName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(12).Direction = ParameterDirection.Output
        params(13).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_AddCourseRegistrations", params)
        'Populate Error Code
        RetVal(0) = params(12).Value
        'Populate Error Hint
        RetVal(1) = params(13).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(12).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(13).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function AddCourseRegistrations_ExtraYear(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@LecturerName", Course.LecturerName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(12).Direction = ParameterDirection.Output
        params(13).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_AddCourseRegistrations_ExtraYear", params)
        'Populate Error Code
        RetVal(0) = params(12).Value
        'Populate Error Hint
        RetVal(1) = params(13).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(12).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(13).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function AddCourseRegistrations_Summer(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@LecturerName", Course.LecturerName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(12).Direction = ParameterDirection.Output
        params(13).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_AddCourseRegistrations_Summer", params)
        'Populate Error Code
        RetVal(0) = params(12).Value
        'Populate Error Hint
        RetVal(1) = params(13).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(12).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(13).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function AddCourseRegistrations_CarryOver(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@LecturerName", Course.LecturerName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(12).Direction = ParameterDirection.Output
        params(13).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_AddCourseRegistrations_CarryOver", params)
        'Populate Error Code
        RetVal(0) = params(12).Value
        'Populate Error Hint
        RetVal(1) = params(13).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(12).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(13).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CreateCourseRegistrationTemp(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@LecturerName", Course.LecturerName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(12).Direction = ParameterDirection.Output
        params(13).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateCourseRegistrationTemp", params)
        'Populate Error Code
        RetVal(0) = params(12).Value
        'Populate Error Hint
        RetVal(1) = params(13).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(12).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(13).Value
        '    'Populate StudentProfileID
        'End Try
    End Function

    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CreateCourseRegistrationTemp_ExtraYear(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@LecturerName", Course.LecturerName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(12).Direction = ParameterDirection.Output
        params(13).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateCourseRegistrationTemp_ExtraYear", params)
        'Populate Error Code
        RetVal(0) = params(12).Value
        'Populate Error Hint
        RetVal(1) = params(13).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(12).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(13).Value
        '    'Populate StudentProfileID
        'End Try
    End Function

    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CreateCourseRegistrationTemp_Summer(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@LecturerName", Course.LecturerName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(12).Direction = ParameterDirection.Output
        params(13).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateCourseRegistrationTemp_Summer", params)
        'Populate Error Code
        RetVal(0) = params(12).Value
        'Populate Error Hint
        RetVal(1) = params(13).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(12).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(13).Value
        '    'Populate StudentProfileID
        'End Try
    End Function

    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CreateCourseRegistrationTemp_CarryOver(ByVal Course As SessionLevelSemesterCourseData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Course.RegNumber), _
        New SqlParameter("@SessionName", Course.SessionName), _
        New SqlParameter("@Semester", Course.Semester), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@YES", Course.Attempt), _
        New SqlParameter("@LevelName", Course.LevelName), _
        New SqlParameter("@LecturerName", Course.LecturerName), _
        New SqlParameter("@CreatedByRegNo", Course.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(12).Direction = ParameterDirection.Output
        params(13).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateCourseRegistrationTemp_CarryOver", params)
        'Populate Error Code
        RetVal(0) = params(12).Value
        'Populate Error Hint
        RetVal(1) = params(13).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(12).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(13).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Deletes Course from the database
    ''' </summary>
    ''' <remarks>It deletes Course record from the database </remarks>
    Public Function DeleteTempCourse() As Integer
        'Declare and initialize data access parameters
        'Try
        'Delete Course data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteTempCourse")
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' Deletes Course from the database
    ''' </summary>
    ''' <remarks>It deletes Course record from the database </remarks>
    Public Function DeleteTempCourse_ExtraYear() As Integer
        'Declare and initialize data access parameters
        'Try
        'Delete Course data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteTempCourse_ExtraYear")
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' Deletes Course from the database
    ''' </summary>
    ''' <remarks>It deletes Course record from the database </remarks>
    Public Function DeleteTempCourse_Summer() As Integer
        'Declare and initialize data access parameters
        'Try
        'Delete Course data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteTempCourse_Summer")
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' Deletes Course from the database
    ''' </summary>
    ''' <remarks>It deletes Course record from the database </remarks>
    Public Function DeleteTempCourse_CarryOver() As Integer
        'Declare and initialize data access parameters
        'Try
        'Delete Course data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteTempCourse_CarryOver")
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' Generate Pin
    ''' </summary>
    ''' <param name="SessionID"></param>
    ''' <returns>Student</returns>
    ''' <remarks>Generate Pin</remarks>
    Public Function UploadPin(ByVal UploadedPIN As String, ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal FacultyID As Integer, ByVal DeptID As Integer, ByVal LevelID As Integer, ByVal CreatedByUID As Integer) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@UploadedPIN", UploadedPIN), _
        New SqlParameter("@SessionID", SessionID), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@FacultyID", FacultyID), _
        New SqlParameter("@DeptID", DeptID), _
        New SqlParameter("@LevelID", LevelID), _
        New SqlParameter("@CreatedByUID", CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(9).Direction = ParameterDirection.Output
        params(10).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadPinNumber", params)
        'Populate Error Code
        RetVal(0) = params(9).Value
        'Populate Error Hint
        RetVal(1) = params(10).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(7).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(8).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Find SchoolFees By ID
    ''' </summary>
    ''' <returns>Decimal</returns>
    ''' <remarks>it returns a Decimal</remarks>
    Public Function FindAllPINByPINNumber(ByVal PINNumber As String) As Integer
        'Declaring the parameters
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Holds PostUMEFee Data
        Dim VerifyPINNumber As Integer
        Dim params() As SqlParameter = _
        {New SqlParameter("@PINNumber", PINNumber)}
        'Try
        'Find Post UME Fee By ID.
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllPINByPINNumber", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then

            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    VerifyPINNumber = row(0)
                End If
            Next
            Return VerifyPINNumber
        Else
            Return Nothing
        End If
    End Function
    ''' <summary>
    ''' Find SchoolFees By ID
    ''' </summary>
    ''' <returns>Decimal</returns>
    ''' <remarks>it returns a Decimal</remarks>
    Public Function CheckPINForRegNo(ByVal PINNumber As String) As SessionLevelSemesterCourseData
        'Declaring the parameters
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Holds PostUMEFee Data
        Dim Data As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim params() As SqlParameter = _
        {New SqlParameter("@PINNumber", PINNumber)}
        'Try
        'Find Post UME Fee By ID.
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CheckPINForRegNo", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then

            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    Data.AmountInwords = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    Data.SessionName = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    Data.SemesterName = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    Data.FacultyName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    Data.DeptName = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    Data.LevelName = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    Data.RegNumber = row(6)
                End If
            Next
            Return Data
        Else
            Return Nothing
        End If
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCoursesByCourseCode(ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal LevelID As Integer, ByVal FacultyID As Integer, ByVal DeptID As Integer, ByVal CourseCode As String) As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet

        Dim params() As SqlParameter = _
       {New SqlParameter("@SessionID", SessionID), _
       New SqlParameter("@SemesterID", SemesterID), _
       New SqlParameter("@LevelID", LevelID), _
       New SqlParameter("@FacultyID", FacultyID), _
       New SqlParameter("@DeptID", DeptID), _
       New SqlParameter("@CourseCode", CourseCode)}

        'Try
        'Fetch all SchoolFees.
        SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByCourseCode", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllDepartmentResultByDeptID(ByVal SessionName As String, ByVal FacultyID As Integer, ByVal DeptID As Integer, ByVal Semester As String, ByVal LevelName As String) As DataSet
        'Holds PostUMEFee Data
        Dim params() As SqlParameter = _
                {New SqlParameter("@SessionName", SessionName), _
                New SqlParameter("@FacultyID", FacultyID), _
                New SqlParameter("@DeptID", DeptID), _
                New SqlParameter("@Semester", Semester), _
                New SqlParameter("@LevelName", LevelName)}

        Dim SchoolFees As DataSet = New DataSet

        ''Try
        ''Fetch all SchoolFees.
        'SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "SP_StudDeptResult", params)
        ''Catch ex As Exception
        ''    'If error occurs, log it and return nothing.
        ''    AppException.LogError(ex.Message)
        ''    Return Nothing
        ''End Try
        ''Return fetched SchoolFees data
        'Return SchoolFees



        Dim adapterString As New SqlDataAdapter("SP_StudDeptResult", ConStr)

        With adapterString.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 2000
            .Parameters.AddRange(params)
        End With

        Dim data As New DataSet

        adapterString.Fill(data)

        Return data

    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllDepartmentResultByDeptIDForStudent(ByVal SessionName As String, ByVal FacultyID As Integer, ByVal DeptID As Integer, ByVal Semester As String, ByVal LevelName As String) As DataSet
        'Holds PostUMEFee Data
        Dim params() As SqlParameter = _
                {New SqlParameter("@SessionName", SessionName), _
                New SqlParameter("@FacultyID", FacultyID), _
                New SqlParameter("@DeptID", DeptID), _
                New SqlParameter("@Semester", Semester), _
                New SqlParameter("@LevelName", LevelName)}

        Dim SchoolFees As DataSet = New DataSet

        ''Try
        ''Fetch all SchoolFees.
        'SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "SP_StudDeptResult", params)
        ''Catch ex As Exception
        ''    'If error occurs, log it and return nothing.
        ''    AppException.LogError(ex.Message)
        ''    Return Nothing
        ''End Try
        ''Return fetched SchoolFees data
        'Return SchoolFees



        Dim adapterString As New SqlDataAdapter("SP_StudDeptResultForStudent", ConStr)

        With adapterString.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 2000
            .Parameters.AddRange(params)
        End With

        Dim data As New DataSet

        adapterString.Fill(data)

        Return data

    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindResultTemplate(ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal LevelID As Integer) As DataSet
        'Holds PostUMEFee Data
        Dim params() As SqlParameter = _
                {New SqlParameter("@SessionID", SessionID), _
                New SqlParameter("@SemesterID", SemesterID), _
                New SqlParameter("@LevelID", LevelID)}

        Dim SchoolFees As DataSet = New DataSet

        Dim adapterString As New SqlDataAdapter("SP_TemplateResult", ConStr)

        With adapterString.SelectCommand
            .CommandType = CommandType.StoredProcedure
            .CommandTimeout = 2000
            .Parameters.AddRange(params)
        End With

        Dim data As New DataSet

        adapterString.Fill(data)

        Return data

    End Function
    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function FindAllIssuePINByRegNumber(ByVal RegNumber As String, ByVal SessionID As Integer, ByVal FacultyID As Integer, ByVal DeptID As Integer, ByVal SemesterID As Integer, ByVal LevelID As Integer, ByVal CreatedByUID As Integer) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@SessionID", SessionID), _
        New SqlParameter("@FacultyID", FacultyID), _
        New SqlParameter("@DeptID", DeptID), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@LevelID", LevelID), _
        New SqlParameter("@CreatedByUID", CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(9).Direction = ParameterDirection.Output
        params(10).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_FindAllIssuePINByRegNumber", params)
        'Populate Error Code
        RetVal(0) = params(9).Value
        'Populate Error Hint
        RetVal(1) = params(10).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(10).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(11).Value
        '    'Populate StudentProfileID
        'End Try
    End Function

    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function FindAllSchoolFeesByRegNumber(ByVal RegNumber As String, ByVal SessionID As Integer, ByVal FacultyID As Integer, ByVal DeptID As Integer, ByVal SemesterID As Integer, ByVal LevelID As Integer, ByVal CreatedByUID As Integer) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@SessionID", SessionID), _
        New SqlParameter("@FacultyID", FacultyID), _
        New SqlParameter("@DeptID", DeptID), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@LevelID", LevelID), _
        New SqlParameter("@CreatedByUID", CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(9).Direction = ParameterDirection.Output
        params(10).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_FindAllSchoolFeesByRegNumber", params)
        'Populate Error Code
        RetVal(0) = params(9).Value
        'Populate Error Hint
        RetVal(1) = params(10).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(10).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(11).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Finds Level by LevelID
    ''' </summary>
    ''' <param name="LevelID"></param>
    ''' <returns>LevelData</returns>
    ''' <remarks>It takes LevelID and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllResultGeneratedSchoolFeesByID(ByVal ResultETransactPinID As Integer) As SessionLevelSemesterCourseData
        Dim RetVal As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@ResultETransactPinID", ResultETransactPinID)}
        Try
            'Fetch item based on LevelID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllResultGeneratedSchoolFeesByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        RetVal.SchoolFeesID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        RetVal.LevelName = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        RetVal.SessionName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        RetVal.SemesterName = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        RetVal.FacultyName = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        RetVal.DeptName = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        RetVal.SchoolFeesAmount = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        RetVal.LevelID = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        RetVal.SessionID = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        RetVal.SemesterID = row(9)
                    End If
                    If Not IsDBNull(row(10)) Then
                        RetVal.FacultyID = row(10)
                    End If
                    If Not IsDBNull(row(11)) Then
                        RetVal.DeptID = row(11)
                    End If
                Next
                'Return Level data.
                Return RetVal
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds Level by LevelID
    ''' </summary>
    ''' <param name="LevelID"></param>
    ''' <returns>LevelData</returns>
    ''' <remarks>It takes LevelID and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllGeneratedSchoolFeesByID(ByVal ETransactPinID As Integer) As SessionLevelSemesterCourseData
        Dim RetVal As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@ETransactPinID", ETransactPinID)}
        Try
            'Fetch item based on LevelID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllGeneratedSchoolFeesByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        RetVal.SchoolFeesID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        RetVal.LevelName = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        RetVal.SessionName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        RetVal.SemesterName = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        RetVal.FacultyName = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        RetVal.DeptName = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        RetVal.SchoolFeesAmount = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        RetVal.LevelID = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        RetVal.SessionID = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        RetVal.SemesterID = row(9)
                    End If
                    If Not IsDBNull(row(10)) Then
                        RetVal.FacultyID = row(10)
                    End If
                    If Not IsDBNull(row(11)) Then
                        RetVal.DeptID = row(11)
                    End If
                Next
                'Return Level data.
                Return RetVal
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Updates Level Data
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <remarks>It updates the database using SessionLevelSemesterCourseData</remarks>
    Public Function IssuePIN(ByVal ID As Integer, ByVal RegNo As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ID", ID), _
        New SqlParameter("@RegNo", RegNo)}
        Try
            'Issue Pin
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "IssuePIN", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    Public Function IssueSchoolFeesPIN(ByVal ID As Integer, ByVal RegNo As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ID", ID), _
        New SqlParameter("@RegNo", RegNo)}
        Try
            'Issue Pin
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "IssueSchoolFeesPIN", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Updates Level Data
    ''' </summary>
    ''' <param name="RetData"></param>
    ''' <remarks>It updates the database using SessionLevelSemesterCourseData</remarks>
    Public Function AssignPINToRegNo(ByVal RetData As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", RetData.SessionID), _
                New SqlParameter("@FacultyID", RetData.FacultyID), _
                New SqlParameter("@DeptID", RetData.DeptID), _
                New SqlParameter("@SemesterID", RetData.SemesterID), _
                New SqlParameter("@LevelID", RetData.LevelID)}
        'Try
        'Issue Pin
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "AssignPINToRegNo", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try

    End Function
    ''' <summary>
    ''' Updates Level Data
    ''' </summary>
    ''' <param name="RetData"></param>
    ''' <remarks>It updates the database using SessionLevelSemesterCourseData</remarks>
    Public Function AssignResultPINToRegNo(ByVal RetData As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", RetData.SessionID), _
                New SqlParameter("@FacultyID", RetData.FacultyID), _
                New SqlParameter("@DeptID", RetData.DeptID), _
                New SqlParameter("@SemesterID", RetData.SemesterID), _
                New SqlParameter("@LevelID", RetData.LevelID)}
        'Try
        'Issue Pin
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "AssignResultPINToRegNo", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try

    End Function

    ''' <summary>
    ''' Creates a Course
    ''' </summary>
    ''' <param name="Result"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Course</remarks>
    Public Function UploadAllStudentResult(ByVal Result As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Result.RegNumber), _
        New SqlParameter("@SessionName", Result.SessionName), _
        New SqlParameter("@Semester", Result.Semester), _
        New SqlParameter("@CourseCode", Result.CourseCode), _
        New SqlParameter("@LevelName", Result.LevelName), _
        New SqlParameter("@ContinuosAssesment", Result.CA), _
        New SqlParameter("@Exams", Result.Exam), _
        New SqlParameter("@Total", Result.Total), _
        New SqlParameter("@Grade", Result.Grade), _
        New SqlParameter("@Remark", Result.Remark), _
        New SqlParameter("@ResultSheetUrl", Result.ResultSheetUrl)}
        Try
            'Create Course data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadAllStudentResult", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Creates a Course
    ''' </summary>
    ''' <param name="Result"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Course</remarks>
    Public Function UploadAllStudentResult_ExtraYear(ByVal Result As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Result.RegNumber), _
        New SqlParameter("@SessionName", Result.SessionName), _
        New SqlParameter("@Semester", Result.Semester), _
        New SqlParameter("@CourseCode", Result.CourseCode), _
        New SqlParameter("@LevelName", Result.LevelName), _
        New SqlParameter("@ContinuosAssesment", Result.CA), _
        New SqlParameter("@Exams", Result.Exam), _
        New SqlParameter("@Total", Result.Total), _
        New SqlParameter("@Grade", Result.Grade), _
        New SqlParameter("@Remark", Result.Remark), _
        New SqlParameter("@ResultSheetUrl", Result.ResultSheetUrl)}
        'Try
        'Create Course data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadAllStudentResult_ExtraYear", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return 0
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function

    ''' <summary>
    ''' Creates a Course
    ''' </summary>
    ''' <param name="Result"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Course</remarks>
    Public Function UploadAllStudentResult_Summer(ByVal Result As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Result.RegNumber), _
        New SqlParameter("@SessionName", Result.SessionName), _
        New SqlParameter("@Semester", Result.Semester), _
        New SqlParameter("@CourseCode", Result.CourseCode), _
        New SqlParameter("@LevelName", Result.LevelName), _
        New SqlParameter("@ContinuosAssesment", Result.CA), _
        New SqlParameter("@Exams", Result.Exam), _
        New SqlParameter("@Total", Result.Total), _
        New SqlParameter("@Grade", Result.Grade), _
        New SqlParameter("@Remark", Result.Remark), _
        New SqlParameter("@ResultSheetUrl", Result.ResultSheetUrl)}
        'Try
        'Create Course data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadAllStudentResult_Summer", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return 0
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Course
    ''' </summary>
    ''' <param name="Result"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Course</remarks>
    Public Function UploadAllStudentResult_CarryOver(ByVal Result As SessionLevelSemesterCourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Result.RegNumber), _
        New SqlParameter("@SessionName", Result.SessionName), _
        New SqlParameter("@Semester", Result.Semester), _
        New SqlParameter("@CourseCode", Result.CourseCode), _
        New SqlParameter("@LevelName", Result.LevelName), _
        New SqlParameter("@ContinuosAssesment", Result.CA), _
        New SqlParameter("@Exams", Result.Exam), _
        New SqlParameter("@Total", Result.Total), _
        New SqlParameter("@Grade", Result.Grade), _
        New SqlParameter("@Remark", Result.Remark), _
        New SqlParameter("@ResultSheetUrl", Result.ResultSheetUrl)}
        Try
            'Create Course data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadAllStudentResult_CarryOver", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a Course
    ''' </summary>
    ''' <param name=""></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Course</remarks>
    Public Function UploadResultFromTempTable() As Integer
        'Declare and initialize data access parameters

        Try
            'Create Course data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadResultFromTempTable")
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="CheckPIN"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllUsePINByPIN(ByVal CheckPIN As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CheckPIN", CheckPIN)}
        'Try
        'Fetch all item based on LevelID and SemesterID
        DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllUsePINByPIN", params)

        Return DeptReultDataSet

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="CheckPIN"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllNonUsePINByPIN(ByVal CheckPIN As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CheckPIN", CheckPIN)}
        'Try
        'Fetch all item based on LevelID and SemesterID
        DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllNonUsePINByPIN", params)

        Return DeptReultDataSet

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="CheckPIN"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllNonUseResultPINByPIN(ByVal CheckPIN As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CheckPIN", CheckPIN)}
        'Try
        'Fetch all item based on LevelID and SemesterID
        DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllNonUseResultPINByPIN", params)

        Return DeptReultDataSet

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="RegNo"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllNonUsePINByRegNo(ByVal RegNo As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNo", RegNo)}
        'Try
        'Fetch all item based on LevelID and SemesterID
        DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllNonUsePINByRegNo", params)

        Return DeptReultDataSet

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="RegNo"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllNonUseResultPINByRegNo(ByVal RegNo As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNo", RegNo)}
        'Try
        'Fetch all item based on LevelID and SemesterID
        DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllNonUseResultPINByRegNo", params)

        Return DeptReultDataSet

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    Public Function FindAllCoursesBySessionIDLevelIDSemesterID(ByVal LevelID As Integer, ByVal SessionID As Integer, ByVal SemesterID As Integer) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@LevelID", LevelID), _
                                        New SqlParameter("@SessionID", SessionID), _
                                        New SqlParameter("@SemesterID", SemesterID)}
        'Try
        'Fetch all item based on LevelID and SemesterID
        DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesBySessionIDLevelIDSemesterID", params)

        Return DeptReultDataSet

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="SessionID"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllCoursesForUpload(ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal LevelID As Integer) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SessionID", SessionID), _
                                        New SqlParameter("@SemesterID", SemesterID), _
                                        New SqlParameter("@LevelID", LevelID)}
        Try
            'Fetch all item based on LevelID and SemesterID
            DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesForUpload", params)

            Return DeptReultDataSet

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="SessionID"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllStudentBySessionIDSemesterID(ByVal SessionID As Integer, ByVal LevelID As Integer) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SessionID", SessionID), _
                                        New SqlParameter("@LevelID", LevelID)}
        'Try
        'Fetch all item based on LevelID and SemesterID
        DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStudentBySessionIDSemesterID", params)

        Return DeptReultDataSet

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="SessionName"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllStudentForResultBySessionIDSemesterIDLevelID(ByVal SessionName As String, ByVal SemesterName As String, ByVal LevelName As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SessionName", SessionName), _
                                        New SqlParameter("@LevelName", SemesterName), _
                                        New SqlParameter("@SemesterName", LevelName)}
        'Try
        'Fetch all item based on LevelID and SemesterID
        DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStudentForResultBySessionIDSemesterIDLevelID", params)

        Return DeptReultDataSet

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="SessionName"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllStudentForResultBySessionIDSemesterIDLevelID_ExtraYear(ByVal SessionName As String, ByVal SemesterName As String, ByVal LevelName As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SessionName", SessionName), _
                                        New SqlParameter("@LevelName", LevelName), _
                                        New SqlParameter("@SemesterName", SemesterName)}
        'Try
        'Fetch all item based on LevelID and SemesterID
        DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStudentForResultBySessionIDSemesterIDLevelID_ExtraYear", params)

        Return DeptReultDataSet

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="SessionName"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllStudentForResultBySessionIDSemesterIDLevelID_Summer(ByVal SessionName As String, ByVal SemesterName As String, ByVal LevelName As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SessionName", SessionName), _
                                        New SqlParameter("@LevelName", LevelName), _
                                        New SqlParameter("@SemesterName", SemesterName)}
        'Try
        'Fetch all item based on LevelID and SemesterID
        DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStudentForResultBySessionIDSemesterIDLevelID_Summer", params)

        Return DeptReultDataSet

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Fetches all Semesters to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllSemestersBySessionIDLevelID(ByVal SessionID As Integer, ByVal LevelID As Integer) As DataSet
        'Holds Semesters Data
        Dim Semesters As DataSet = New DataSet
        Dim params() As SqlParameter = {New SqlParameter("@SessionID", SessionID), _
                                        New SqlParameter("@LevelID", LevelID)}
        Try
            'Fetch all Semesters.
            Semesters = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllSemestersBySessionIDLevelID", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Semesters data
        Return Semesters
    End Function
    ''' <summary>
    '
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns></returns>
    ''' <remarks> </remarks>
    Public Function FindPhoneNoByRegNO(ByVal RegNumber As String) As String
        Dim RetVal As String = String.Empty
        Dim reader As SqlDataReader

        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}
        Try
            'Fetch item based on LevelID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindPhoneNoByRegNO", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        RetVal = row(0)
                    End If
                Next
                'Return Level data.
                Return RetVal
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCoursesBySessionID(ByVal RegNumber As String, ByVal SemesterID As Integer, ByVal LevelID As Integer) As ArrayList
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNo", RegNumber), _
        New SqlParameter("@SessionID", 0), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@LevelID", LevelID), _
        New SqlParameter("@FacultyID", 0), _
        New SqlParameter("@DeptID", 0)}


        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesBySessionID", params)

        For Each row As DataRow In Sessions.Tables(0).Rows
            QueueList.Add(New CourseArrayData(row(0), row(1), "noSession", row(2), row(3), row(4), row(5), row(6), row(7)))
        Next

        Return QueueList
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCoursesByRegNoSession(ByVal RegNumber As String, ByVal Session As String, ByVal Semester As String, ByVal Level As String) As ArrayList
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@Session", Session), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@Level", Level)}


        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByRegNoSession", params)

        For Each row As DataRow In Sessions.Tables(0).Rows
            QueueList.Add(New CourseArrayData(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8)))
        Next

        Return QueueList
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCoursesByRegNoSession_ExtraYear(ByVal RegNumber As String, ByVal Session As String, ByVal Semester As String, ByVal Level As String) As ArrayList
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@Session", Session), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@Level", Level)}


        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByRegNoSession_ExtraYear", params)

        For Each row As DataRow In Sessions.Tables(0).Rows
            QueueList.Add(New CourseArrayData(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8)))
        Next

        Return QueueList
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCoursesByRegNoSession_Summer(ByVal RegNumber As String, ByVal Session As String, ByVal Semester As String, ByVal Level As String) As ArrayList
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@Session", Session), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@Level", Level)}


        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByRegNoSession_Summer", params)

        For Each row As DataRow In Sessions.Tables(0).Rows
            QueueList.Add(New CourseArrayData(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8)))
        Next

        Return QueueList
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function CreateCourseRegistration_Portal(ByVal CourseID As Integer, ByVal RegNumber As String, ByVal Session As String, ByVal Semester As String, ByVal Level As String) As Integer
        'Holds Sessions Data

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseID", CourseID), _
        New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@SessionName", Session), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", Level)}

        Try
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateCourseRegistration_Portal", params)
            Return 1
        Catch ex As Exception
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function CreateCourseRegistration_Portal_ExtraYear(ByVal CourseID As Integer, ByVal RegNumber As String, ByVal Session As String, ByVal Semester As String, ByVal Level As String) As Integer
        'Holds Sessions Data

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseID", CourseID), _
        New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@SessionName", Session), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", Level)}

        Try
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateCourseRegistration_Portal_ExtraYear", params)
            Return 1
        Catch ex As Exception
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function CreateCourseRegistration_Portal_Summer(ByVal CourseID As Integer, ByVal RegNumber As String, ByVal Session As String, ByVal Semester As String, ByVal Level As String) As Integer
        'Holds Sessions Data

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseID", CourseID), _
        New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@SessionName", Session), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", Level)}

        Try
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateCourseRegistration_Portal_Summer", params)
            Return 1
        Catch ex As Exception
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function DeletCourses_Portal(ByVal CourseID As Integer) As Integer
        'Holds Sessions Data

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseID", CourseID)}

        Try
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeletCourses_Portal", params)
            Return 1
        Catch ex As Exception
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function DeletCourses_Portal_ExtraYear(ByVal CourseID As Integer) As Integer
        'Holds Sessions Data

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseID", CourseID)}

        Try
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeletCourses_Portal_ExtraYear", params)
            Return 1
        Catch ex As Exception
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function DeletCourses_Portal_Summer(ByVal CourseID As Integer) As Integer
        'Holds Sessions Data

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseID", CourseID)}

        Try
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeletCourses_Portal_Summer", params)
            Return 1
        Catch ex As Exception
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllAddCoursesBySessionID_Portal(ByVal RegNumber As String, ByVal Session As String, ByVal Semester As String, ByVal Level As String, ByVal SemesterID As Integer, ByVal LevelID As Integer) As ArrayList
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@SessionName", Session), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", Level), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@LevelID", LevelID)}


        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllAddCoursesBySessionID_Portal", params)

        For Each row As DataRow In Sessions.Tables(0).Rows
            QueueList.Add(New CourseArrayData(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8)))
        Next

        Return QueueList
    End Function

    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllAddCoursesBySessionID_Portal_ExtraYear(ByVal RegNumber As String, ByVal Session As String, ByVal Semester As String, ByVal Level As String, ByVal SemesterID As Integer, ByVal LevelID As Integer) As ArrayList
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@SessionName", Session), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", Level), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@LevelID", LevelID)}


        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllAddCoursesBySessionID_Portal_ExtraYear", params)

        For Each row As DataRow In Sessions.Tables(0).Rows
            QueueList.Add(New CourseArrayData(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8)))
        Next

        Return QueueList
    End Function


    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllAddCoursesBySessionID_Portal_Summer(ByVal RegNumber As String, ByVal Session As String, ByVal Semester As String, ByVal Level As String, ByVal SemesterID As Integer, ByVal LevelID As Integer) As ArrayList
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@SessionName", Session), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", Level), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@LevelID", LevelID)}


        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllAddCoursesBySessionID_Portal_Summer", params)

        For Each row As DataRow In Sessions.Tables(0).Rows
            QueueList.Add(New CourseArrayData(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8)))
        Next

        Return QueueList
    End Function

    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function UploadDepartmentalResult_Portal(ByVal CourseCode As String, ByVal SessionName As String, ByVal SemesterName As String, ByVal LevelName As String, ByVal RegNumber As String, ByVal Total As String) As Integer
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseCode", CourseCode), _
        New SqlParameter("@SessionName", SessionName), _
        New SqlParameter("@SemesterName", SemesterName), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@Total", Total)}


        Try
            Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "UploadDepartmentalResult_Portal", params)
            Return 1
        Catch ex As Exception
            Return 0
        End Try

    End Function


    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function UploadDepartmentalResult_Portal_ExtraYear(ByVal CourseCode As String, ByVal SessionName As String, ByVal SemesterName As String, ByVal LevelName As String, ByVal RegNumber As String, ByVal Total As String) As Integer
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseCode", CourseCode), _
        New SqlParameter("@SessionName", SessionName), _
        New SqlParameter("@SemesterName", SemesterName), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@Total", Total)}


        'Try
        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "UploadDepartmentalResult_Portal_ExtraYear", params)
        Return 1
        'Catch ex As Exception
        '    Return 0
        'End Try

    End Function


    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function UploadDepartmentalResult_Portal_Summer(ByVal CourseCode As String, ByVal SessionName As String, ByVal SemesterName As String, ByVal LevelName As String, ByVal RegNumber As String, ByVal Total As String) As Integer
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseCode", CourseCode), _
        New SqlParameter("@SessionName", SessionName), _
        New SqlParameter("@SemesterName", SemesterName), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@Total", Total)}


        'Try
        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "UploadDepartmentalResult_Portal_Summer", params)
        Return 1
        'Catch ex As Exception
        '    Return 0
        'End Try

    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindDepartmentalResult_Portal(ByVal SessionName As String, ByVal SemesterName As String, ByVal LevelName As String) As ArrayList
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", SessionName), _
        New SqlParameter("@SemesterName", SemesterName), _
        New SqlParameter("@LevelName", LevelName)}


        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindDepartmentalResult_Portal", params)


        Dim row1 As String = "Empty"
        Dim row2 As String = "Empty"
        Dim row3 As String = "Empty"
        Dim row4 As String = "Empty"
        Dim row5 As String = "Empty"
        Dim row6 As String = "Empty"
        Dim row7 As String = "Empty"
        Dim row8 As String = "Empty"
        Dim row9 As String = "Empty"
        Dim row10 As String = "Empty"
        Dim row11 As String = "Empty"
        Dim row12 As String = "Empty"
        Dim row13 As String = "Empty"
        Dim row14 As String = "Empty"
        Dim row15 As String = "Empty"
        Dim row16 As String = "Empty"
        Dim row17 As String = "Empty"
        Dim row18 As String = "Empty"
        Dim row19 As String = "Empty"
        Dim row20 As String = "Empty"

        For Each rows As DataRow In Sessions.Tables(0).Rows

            Dim Count As Integer = Sessions.Tables(0).Columns.Count

            If Count >= 1 Then
                If Not IsDBNull(rows(0)) Then
                    row1 = rows(0)
                End If
            End If

            If Count >= 2 Then
                If Not IsDBNull(rows(1)) Then
                    row2 = rows(1)
                End If
            End If

            If Count >= 3 Then
                If Not IsDBNull(rows(2)) Then
                    row3 = rows(2)
                End If
            End If

            If Count >= 4 Then
                If Not IsDBNull(rows(3)) Then
                    row4 = rows(3)
                End If
            End If

            If Count >= 5 Then
                If Not IsDBNull(rows(4)) Then
                    row5 = rows(4)
                End If
            End If

            If Count >= 6 Then
                If Not IsDBNull(rows(5)) Then
                    row6 = rows(5)
                End If
            End If

            If Count >= 7 Then
                If Not IsDBNull(rows(6)) Then
                    row7 = rows(6)
                End If
            End If

            If Count >= 8 Then
                If Not IsDBNull(rows(7)) Then
                    row8 = rows(7)
                End If
            End If

            If Count >= 9 Then
                If Not IsDBNull(rows(8)) Then
                    row9 = rows(8)
                End If
            End If

            If Count >= 10 Then
                If Not IsDBNull(rows(9)) Then
                    row10 = rows(9)
                End If
            End If

            If Count >= 11 Then
                If Not IsDBNull(rows(10)) Then
                    row11 = rows(10)
                End If
            End If

            If Count >= 12 Then
                If Not IsDBNull(rows(11)) Then
                    row12 = rows(11)
                End If
            End If

            If Count >= 13 Then
                If Not IsDBNull(rows(12)) Then
                    row13 = rows(12)
                End If
            End If

            If Count >= 14 Then
                If Not IsDBNull(rows(13)) Then
                    row14 = rows(13)
                End If
            End If

            If Count >= 15 Then
                If Not IsDBNull(rows(14)) Then
                    row15 = rows(14)
                End If
            End If

            If Count >= 16 Then
                If Not IsDBNull(rows(15)) Then
                    row16 = rows(15)
                End If
            End If

            If Count >= 17 Then
                If Not IsDBNull(rows(16)) Then
                    row17 = rows(16)
                End If
            End If

            If Count >= 18 Then
                If Not IsDBNull(rows(17)) Then
                    row18 = rows(17)
                End If
            End If

            If Count >= 19 Then
                If Not IsDBNull(rows(18)) Then
                    row19 = rows(18)
                End If
            End If

            If Count >= 20 Then
                If Not IsDBNull(rows(19)) Then
                    row20 = rows(19)
                End If
            End If

            QueueList.Add(New ResultArrayData(row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, row12, row13, row14, row15, row16, row17, row18, row19, row20))

        Next

        Return QueueList
    End Function



    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindDepartmentalResult_Portal_ExtraYear(ByVal SessionName As String, ByVal SemesterName As String, ByVal LevelName As String) As ArrayList
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", SessionName), _
        New SqlParameter("@SemesterName", SemesterName), _
        New SqlParameter("@LevelName", LevelName)}


        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindDepartmentalResult_Portal_ExtraYear", params)


        Dim row1 As String = "Empty"
        Dim row2 As String = "Empty"
        Dim row3 As String = "Empty"
        Dim row4 As String = "Empty"
        Dim row5 As String = "Empty"
        Dim row6 As String = "Empty"
        Dim row7 As String = "Empty"
        Dim row8 As String = "Empty"
        Dim row9 As String = "Empty"
        Dim row10 As String = "Empty"
        Dim row11 As String = "Empty"
        Dim row12 As String = "Empty"
        Dim row13 As String = "Empty"
        Dim row14 As String = "Empty"
        Dim row15 As String = "Empty"
        Dim row16 As String = "Empty"
        Dim row17 As String = "Empty"
        Dim row18 As String = "Empty"
        Dim row19 As String = "Empty"
        Dim row20 As String = "Empty"

        For Each rows As DataRow In Sessions.Tables(0).Rows

            Dim Count As Integer = Sessions.Tables(0).Columns.Count

            If Count >= 1 Then
                If Not IsDBNull(rows(0)) Then
                    row1 = rows(0)
                End If
            End If

            If Count >= 2 Then
                If Not IsDBNull(rows(1)) Then
                    row2 = rows(1)
                End If
            End If

            If Count >= 3 Then
                If Not IsDBNull(rows(2)) Then
                    row3 = rows(2)
                End If
            End If

            If Count >= 4 Then
                If Not IsDBNull(rows(3)) Then
                    row4 = rows(3)
                End If
            End If

            If Count >= 5 Then
                If Not IsDBNull(rows(4)) Then
                    row5 = rows(4)
                End If
            End If

            If Count >= 6 Then
                If Not IsDBNull(rows(5)) Then
                    row6 = rows(5)
                End If
            End If

            If Count >= 7 Then
                If Not IsDBNull(rows(6)) Then
                    row7 = rows(6)
                End If
            End If

            If Count >= 8 Then
                If Not IsDBNull(rows(7)) Then
                    row8 = rows(7)
                End If
            End If

            If Count >= 9 Then
                If Not IsDBNull(rows(8)) Then
                    row9 = rows(8)
                End If
            End If

            If Count >= 10 Then
                If Not IsDBNull(rows(9)) Then
                    row10 = rows(9)
                End If
            End If

            If Count >= 11 Then
                If Not IsDBNull(rows(10)) Then
                    row11 = rows(10)
                End If
            End If

            If Count >= 12 Then
                If Not IsDBNull(rows(11)) Then
                    row12 = rows(11)
                End If
            End If

            If Count >= 13 Then
                If Not IsDBNull(rows(12)) Then
                    row13 = rows(12)
                End If
            End If

            If Count >= 14 Then
                If Not IsDBNull(rows(13)) Then
                    row14 = rows(13)
                End If
            End If

            If Count >= 15 Then
                If Not IsDBNull(rows(14)) Then
                    row15 = rows(14)
                End If
            End If

            If Count >= 16 Then
                If Not IsDBNull(rows(15)) Then
                    row16 = rows(15)
                End If
            End If

            If Count >= 17 Then
                If Not IsDBNull(rows(16)) Then
                    row17 = rows(16)
                End If
            End If

            If Count >= 18 Then
                If Not IsDBNull(rows(17)) Then
                    row18 = rows(17)
                End If
            End If

            If Count >= 19 Then
                If Not IsDBNull(rows(18)) Then
                    row19 = rows(18)
                End If
            End If

            If Count >= 20 Then
                If Not IsDBNull(rows(19)) Then
                    row20 = rows(19)
                End If
            End If

            QueueList.Add(New ResultArrayData(row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, row12, row13, row14, row15, row16, row17, row18, row19, row20))

        Next

        Return QueueList
    End Function

    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindDepartmentalResult_Portal_Summer(ByVal SessionName As String, ByVal SemesterName As String, ByVal LevelName As String) As ArrayList
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", SessionName), _
        New SqlParameter("@SemesterName", SemesterName), _
        New SqlParameter("@LevelName", LevelName)}


        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindDepartmentalResult_Portal_Summer", params)


        Dim row1 As String = "Empty"
        Dim row2 As String = "Empty"
        Dim row3 As String = "Empty"
        Dim row4 As String = "Empty"
        Dim row5 As String = "Empty"
        Dim row6 As String = "Empty"
        Dim row7 As String = "Empty"
        Dim row8 As String = "Empty"
        Dim row9 As String = "Empty"
        Dim row10 As String = "Empty"
        Dim row11 As String = "Empty"
        Dim row12 As String = "Empty"
        Dim row13 As String = "Empty"
        Dim row14 As String = "Empty"
        Dim row15 As String = "Empty"
        Dim row16 As String = "Empty"
        Dim row17 As String = "Empty"
        Dim row18 As String = "Empty"
        Dim row19 As String = "Empty"
        Dim row20 As String = "Empty"

        For Each rows As DataRow In Sessions.Tables(0).Rows

            Dim Count As Integer = Sessions.Tables(0).Columns.Count

            If Count >= 1 Then
                If Not IsDBNull(rows(0)) Then
                    row1 = rows(0)
                End If
            End If

            If Count >= 2 Then
                If Not IsDBNull(rows(1)) Then
                    row2 = rows(1)
                End If
            End If

            If Count >= 3 Then
                If Not IsDBNull(rows(2)) Then
                    row3 = rows(2)
                End If
            End If

            If Count >= 4 Then
                If Not IsDBNull(rows(3)) Then
                    row4 = rows(3)
                End If
            End If

            If Count >= 5 Then
                If Not IsDBNull(rows(4)) Then
                    row5 = rows(4)
                End If
            End If

            If Count >= 6 Then
                If Not IsDBNull(rows(5)) Then
                    row6 = rows(5)
                End If
            End If

            If Count >= 7 Then
                If Not IsDBNull(rows(6)) Then
                    row7 = rows(6)
                End If
            End If

            If Count >= 8 Then
                If Not IsDBNull(rows(7)) Then
                    row8 = rows(7)
                End If
            End If

            If Count >= 9 Then
                If Not IsDBNull(rows(8)) Then
                    row9 = rows(8)
                End If
            End If

            If Count >= 10 Then
                If Not IsDBNull(rows(9)) Then
                    row10 = rows(9)
                End If
            End If

            If Count >= 11 Then
                If Not IsDBNull(rows(10)) Then
                    row11 = rows(10)
                End If
            End If

            If Count >= 12 Then
                If Not IsDBNull(rows(11)) Then
                    row12 = rows(11)
                End If
            End If

            If Count >= 13 Then
                If Not IsDBNull(rows(12)) Then
                    row13 = rows(12)
                End If
            End If

            If Count >= 14 Then
                If Not IsDBNull(rows(13)) Then
                    row14 = rows(13)
                End If
            End If

            If Count >= 15 Then
                If Not IsDBNull(rows(14)) Then
                    row15 = rows(14)
                End If
            End If

            If Count >= 16 Then
                If Not IsDBNull(rows(15)) Then
                    row16 = rows(15)
                End If
            End If

            If Count >= 17 Then
                If Not IsDBNull(rows(16)) Then
                    row17 = rows(16)
                End If
            End If

            If Count >= 18 Then
                If Not IsDBNull(rows(17)) Then
                    row18 = rows(17)
                End If
            End If

            If Count >= 19 Then
                If Not IsDBNull(rows(18)) Then
                    row19 = rows(18)
                End If
            End If

            If Count >= 20 Then
                If Not IsDBNull(rows(19)) Then
                    row20 = rows(19)
                End If
            End If

            QueueList.Add(New ResultArrayData(row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, row12, row13, row14, row15, row16, row17, row18, row19, row20))

        Next

        Return QueueList
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindDepartmentalResultHeader_Portal_ExtraYear(ByVal SessionName As String, ByVal SemesterName As String, ByVal LevelName As String) As ArrayList
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", SessionName), _
        New SqlParameter("@SemesterName", SemesterName), _
        New SqlParameter("@LevelName", LevelName)}


        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindDepartmentalResultHeader_Portal_ExtraYear", params)


        Dim row1 As String = "Empty"
        Dim row2 As String = "Empty"
        Dim row3 As String = "Empty"
        Dim row4 As String = "Empty"
        Dim row5 As String = "Empty"
        Dim row6 As String = "Empty"
        Dim row7 As String = "Empty"
        Dim row8 As String = "Empty"
        Dim row9 As String = "Empty"
        Dim row10 As String = "Empty"
        Dim row11 As String = "Empty"
        Dim row12 As String = "Empty"
        Dim row13 As String = "Empty"
        Dim row14 As String = "Empty"
        Dim row15 As String = "Empty"
        Dim row16 As String = "Empty"
        Dim row17 As String = "Empty"
        Dim row18 As String = "Empty"
        Dim row19 As String = "Empty"
        Dim row20 As String = "Empty"

        ' For Each rows As DataRow In Sessions.Tables(0).Rows
        For i As Integer = 0 To Sessions.Tables(0).Rows.Count - 1

            Dim Count As Integer = Sessions.Tables(0).Rows.Count

            If Count >= 1 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(0).Item(0)) Then
                    row1 = Sessions.Tables(0).Rows(0).Item(0)
                End If
            End If

            If Count >= 2 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(1).Item(0)) Then
                    row2 = Sessions.Tables(0).Rows(1).Item(0)
                End If
            End If

            If Count >= 3 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(2).Item(0)) Then
                    row3 = Sessions.Tables(0).Rows(2).Item(0)
                End If
            End If

            If Count >= 4 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(3).Item(0)) Then
                    row4 = Sessions.Tables(0).Rows(3).Item(0)
                End If
            End If

            If Count >= 5 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(4).Item(0)) Then
                    row5 = Sessions.Tables(0).Rows(4).Item(0)
                End If
            End If

            If Count >= 6 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(5).Item(0)) Then
                    row6 = Sessions.Tables(0).Rows(5).Item(0)
                End If
            End If

            If Count >= 7 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(6).Item(0)) Then
                    row7 = Sessions.Tables(0).Rows(6).Item(0)
                End If
            End If

            If Count >= 8 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(7).Item(0)) Then
                    row8 = Sessions.Tables(0).Rows(7).Item(0)
                End If
            End If

            If Count >= 9 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(8).Item(0)) Then
                    row9 = Sessions.Tables(0).Rows(8).Item(0)
                End If
            End If

            If Count >= 10 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(9).Item(0)) Then
                    row10 = Sessions.Tables(0).Rows(9).Item(0)
                End If
            End If

            If Count >= 11 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(10).Item(0)) Then
                    row11 = Sessions.Tables(0).Rows(10).Item(0)
                End If
            End If

            If Count >= 12 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(11).Item(0)) Then
                    row12 = Sessions.Tables(0).Rows(11).Item(0)
                End If
            End If

            If Count >= 13 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(12).Item(0)) Then
                    row13 = Sessions.Tables(0).Rows(12).Item(0)
                End If
            End If

            If Count >= 14 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(13).Item(0)) Then
                    row14 = Sessions.Tables(0).Rows(13).Item(0)
                End If
            End If

            If Count >= 15 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(14).Item(0)) Then
                    row15 = Sessions.Tables(0).Rows(14).Item(0)
                End If
            End If

            If Count >= 16 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(15).Item(0)) Then
                    row16 = Sessions.Tables(0).Rows(15).Item(0)
                End If
            End If

            If Count >= 17 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(16).Item(0)) Then
                    row17 = Sessions.Tables(0).Rows(16).Item(0)
                End If
            End If

            If Count >= 18 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(17).Item(0)) Then
                    row18 = Sessions.Tables(0).Rows(17).Item(0)
                End If
            End If

            If Count >= 19 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(18).Item(0)) Then
                    row19 = Sessions.Tables(0).Rows(18).Item(0)
                End If
            End If

            If Count >= 20 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(19).Item(0)) Then
                    row20 = Sessions.Tables(0).Rows(19).Item(0)
                End If
            End If

            QueueList.Add(New ResultArrayData(row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, row12, row13, row14, row15, row16, row17, row18, row19, row20))

        Next

        Return QueueList
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindDepartmentalResultHeader_Portal_Summer(ByVal SessionName As String, ByVal SemesterName As String, ByVal LevelName As String) As ArrayList
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", SessionName), _
        New SqlParameter("@SemesterName", SemesterName), _
        New SqlParameter("@LevelName", LevelName)}


        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindDepartmentalResultHeader_Portal_Summer", params)


        Dim row1 As String = "Empty"
        Dim row2 As String = "Empty"
        Dim row3 As String = "Empty"
        Dim row4 As String = "Empty"
        Dim row5 As String = "Empty"
        Dim row6 As String = "Empty"
        Dim row7 As String = "Empty"
        Dim row8 As String = "Empty"
        Dim row9 As String = "Empty"
        Dim row10 As String = "Empty"
        Dim row11 As String = "Empty"
        Dim row12 As String = "Empty"
        Dim row13 As String = "Empty"
        Dim row14 As String = "Empty"
        Dim row15 As String = "Empty"
        Dim row16 As String = "Empty"
        Dim row17 As String = "Empty"
        Dim row18 As String = "Empty"
        Dim row19 As String = "Empty"
        Dim row20 As String = "Empty"

        ' For Each rows As DataRow In Sessions.Tables(0).Rows
        For i As Integer = 0 To Sessions.Tables(0).Rows.Count - 1

            Dim Count As Integer = Sessions.Tables(0).Rows.Count

            If Count >= 1 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(0).Item(0)) Then
                    row1 = Sessions.Tables(0).Rows(0).Item(0)
                End If
            End If

            If Count >= 2 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(1).Item(0)) Then
                    row2 = Sessions.Tables(0).Rows(1).Item(0)
                End If
            End If

            If Count >= 3 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(2).Item(0)) Then
                    row3 = Sessions.Tables(0).Rows(2).Item(0)
                End If
            End If

            If Count >= 4 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(3).Item(0)) Then
                    row4 = Sessions.Tables(0).Rows(3).Item(0)
                End If
            End If

            If Count >= 5 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(4).Item(0)) Then
                    row5 = Sessions.Tables(0).Rows(4).Item(0)
                End If
            End If

            If Count >= 6 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(5).Item(0)) Then
                    row6 = Sessions.Tables(0).Rows(5).Item(0)
                End If
            End If

            If Count >= 7 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(6).Item(0)) Then
                    row7 = Sessions.Tables(0).Rows(6).Item(0)
                End If
            End If

            If Count >= 8 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(7).Item(0)) Then
                    row8 = Sessions.Tables(0).Rows(7).Item(0)
                End If
            End If

            If Count >= 9 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(8).Item(0)) Then
                    row9 = Sessions.Tables(0).Rows(8).Item(0)
                End If
            End If

            If Count >= 10 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(9).Item(0)) Then
                    row10 = Sessions.Tables(0).Rows(9).Item(0)
                End If
            End If

            If Count >= 11 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(10).Item(0)) Then
                    row11 = Sessions.Tables(0).Rows(10).Item(0)
                End If
            End If

            If Count >= 12 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(11).Item(0)) Then
                    row12 = Sessions.Tables(0).Rows(11).Item(0)
                End If
            End If

            If Count >= 13 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(12).Item(0)) Then
                    row13 = Sessions.Tables(0).Rows(12).Item(0)
                End If
            End If

            If Count >= 14 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(13).Item(0)) Then
                    row14 = Sessions.Tables(0).Rows(13).Item(0)
                End If
            End If

            If Count >= 15 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(14).Item(0)) Then
                    row15 = Sessions.Tables(0).Rows(14).Item(0)
                End If
            End If

            If Count >= 16 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(15).Item(0)) Then
                    row16 = Sessions.Tables(0).Rows(15).Item(0)
                End If
            End If

            If Count >= 17 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(16).Item(0)) Then
                    row17 = Sessions.Tables(0).Rows(16).Item(0)
                End If
            End If

            If Count >= 18 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(17).Item(0)) Then
                    row18 = Sessions.Tables(0).Rows(17).Item(0)
                End If
            End If

            If Count >= 19 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(18).Item(0)) Then
                    row19 = Sessions.Tables(0).Rows(18).Item(0)
                End If
            End If

            If Count >= 20 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(19).Item(0)) Then
                    row20 = Sessions.Tables(0).Rows(19).Item(0)
                End If
            End If

            QueueList.Add(New ResultArrayData(row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, row12, row13, row14, row15, row16, row17, row18, row19, row20))

        Next

        Return QueueList
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindDepartmentalResultHeader_Portal(ByVal SessionName As String, ByVal SemesterName As String, ByVal LevelName As String) As ArrayList
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", SessionName), _
        New SqlParameter("@SemesterName", SemesterName), _
        New SqlParameter("@LevelName", LevelName)}


        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindDepartmentalResultHeader_Portal", params)


        Dim row1 As String = "Empty"
        Dim row2 As String = "Empty"
        Dim row3 As String = "Empty"
        Dim row4 As String = "Empty"
        Dim row5 As String = "Empty"
        Dim row6 As String = "Empty"
        Dim row7 As String = "Empty"
        Dim row8 As String = "Empty"
        Dim row9 As String = "Empty"
        Dim row10 As String = "Empty"
        Dim row11 As String = "Empty"
        Dim row12 As String = "Empty"
        Dim row13 As String = "Empty"
        Dim row14 As String = "Empty"
        Dim row15 As String = "Empty"
        Dim row16 As String = "Empty"
        Dim row17 As String = "Empty"
        Dim row18 As String = "Empty"
        Dim row19 As String = "Empty"
        Dim row20 As String = "Empty"

        ' For Each rows As DataRow In Sessions.Tables(0).Rows
        For i As Integer = 0 To Sessions.Tables(0).Rows.Count - 1

            Dim Count As Integer = Sessions.Tables(0).Rows.Count

            If Count >= 1 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(0).Item(0)) Then
                    row1 = Sessions.Tables(0).Rows(0).Item(0)
                End If
            End If

            If Count >= 2 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(1).Item(0)) Then
                    row2 = Sessions.Tables(0).Rows(1).Item(0)
                End If
            End If

            If Count >= 3 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(2).Item(0)) Then
                    row3 = Sessions.Tables(0).Rows(2).Item(0)
                End If
            End If

            If Count >= 4 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(3).Item(0)) Then
                    row4 = Sessions.Tables(0).Rows(3).Item(0)
                End If
            End If

            If Count >= 5 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(4).Item(0)) Then
                    row5 = Sessions.Tables(0).Rows(4).Item(0)
                End If
            End If

            If Count >= 6 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(5).Item(0)) Then
                    row6 = Sessions.Tables(0).Rows(5).Item(0)
                End If
            End If

            If Count >= 7 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(6).Item(0)) Then
                    row7 = Sessions.Tables(0).Rows(6).Item(0)
                End If
            End If

            If Count >= 8 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(7).Item(0)) Then
                    row8 = Sessions.Tables(0).Rows(7).Item(0)
                End If
            End If

            If Count >= 9 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(8).Item(0)) Then
                    row9 = Sessions.Tables(0).Rows(8).Item(0)
                End If
            End If

            If Count >= 10 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(9).Item(0)) Then
                    row10 = Sessions.Tables(0).Rows(9).Item(0)
                End If
            End If

            If Count >= 11 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(10).Item(0)) Then
                    row11 = Sessions.Tables(0).Rows(10).Item(0)
                End If
            End If

            If Count >= 12 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(11).Item(0)) Then
                    row12 = Sessions.Tables(0).Rows(11).Item(0)
                End If
            End If

            If Count >= 13 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(12).Item(0)) Then
                    row13 = Sessions.Tables(0).Rows(12).Item(0)
                End If
            End If

            If Count >= 14 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(13).Item(0)) Then
                    row14 = Sessions.Tables(0).Rows(13).Item(0)
                End If
            End If

            If Count >= 15 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(14).Item(0)) Then
                    row15 = Sessions.Tables(0).Rows(14).Item(0)
                End If
            End If

            If Count >= 16 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(15).Item(0)) Then
                    row16 = Sessions.Tables(0).Rows(15).Item(0)
                End If
            End If

            If Count >= 17 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(16).Item(0)) Then
                    row17 = Sessions.Tables(0).Rows(16).Item(0)
                End If
            End If

            If Count >= 18 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(17).Item(0)) Then
                    row18 = Sessions.Tables(0).Rows(17).Item(0)
                End If
            End If

            If Count >= 19 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(18).Item(0)) Then
                    row19 = Sessions.Tables(0).Rows(18).Item(0)
                End If
            End If

            If Count >= 20 Then
                If Not IsDBNull(Sessions.Tables(0).Rows(19).Item(0)) Then
                    row20 = Sessions.Tables(0).Rows(19).Item(0)
                End If
            End If

            QueueList.Add(New ResultArrayData(row1, row2, row3, row4, row5, row6, row7, row8, row9, row10, row11, row12, row13, row14, row15, row16, row17, row18, row19, row20))

        Next

        Return QueueList
    End Function
End Class
