''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Chima Kalu-orji
'' Date: 18-05-2009
'' This Class manages the student result.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient


Public Class UploadResultDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' FindCourseName
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindRegNumberByCourseCode(ByVal AcademicSession As String, ByVal Semester As String, ByVal CourseCode As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@CourseCode", CourseCode)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindRegNumber", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' Uploads student's credentials
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function UploadResult(ByVal Student As StudentProfileData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@StudentProfileID", Student.StudentProfileID), _
        New SqlParameter("@SSCECopyUrl", Student.SSCECopyUrl), _
        New SqlParameter("@SSCECopy2Url", Student.SSCECopy2Url), _
        New SqlParameter("@JAMBResultCopyUrl", Student.JAMBResultCopyUrl), _
        New SqlParameter("@BirthCertCopyUrl", Student.BirthCertCopyUrl), _
        New SqlParameter("@PhotoUrl", Student.PhotoUrl), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByRegNo", Student.RegNumber), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(9).Direction = ParameterDirection.Output
        params(10).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadCredentials", params)
            'Populate Error Code
            RetVal(0) = params(9).Value
            'Populate Error Hint
            RetVal(1) = params(10).Value
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
    ''' Upload Result
    ''' </summary>
    ''' <param name="Result"></param>
    ''' <remarks>It Upload Result into the database using UploadResultData</remarks>
    Public Function UploadStudentResult(ByVal Result As UploadResultData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Result.RegNum), _
        New SqlParameter("@SessionName", Result.AcademicSession), _
        New SqlParameter("@Semester", Result.Semester), _
        New SqlParameter("@CourseCode", Result.CourseCode), _
        New SqlParameter("@ContinuosAssesment", Result.ContinousAssesment), _
        New SqlParameter("@Exams", Result.Examination), _
        New SqlParameter("@Total", Result.Total), _
        New SqlParameter("@Grade", Result.Grade), _
        New SqlParameter("@Remark", Result.Remark), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByUID", Result.CreatedByUID), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}
        'Assigning value to the return value
        params(9).Direction = ParameterDirection.Output
        params(10).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadStudentResult", params)
            'Populate Error Code
            RetVal(0) = params(9).Value
            'Populate Error Hint
            RetVal(1) = params(10).Value
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
    ''' Finds Student Result by Session, Semester, Department, CourseCode
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <returns>DataSet</returns>
    ''' <remarks>It takes Session, Semester, Department, CourseCode and returns DataSet </remarks>
    Public Function FindListOfStudentResult(ByVal AcademicSession As String, ByVal Semester As String, ByVal CourseCode As String, ByVal LevelName As String) As DataSet

        Dim StudentResult As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SessionName", AcademicSession), _
                                        New SqlParameter("@Semester", Semester), _
                                        New SqlParameter("@LevelName", LevelName), _
                                        New SqlParameter("@CourseCode", CourseCode)}
        'Try
        'Fetch all item based on courses name
        StudentResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindListOfStudentResult", params)

        Return StudentResult

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    Public Function CreateCourseGrade(ByVal RetData As UploadResultData) As Integer

        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@Grade", RetData.Grade), _
                                        New SqlParameter("@UpperBound", RetData.UpperBound), _
                                        New SqlParameter("@LowerBound", RetData.LowerBound), _
                                        New SqlParameter("@Remarks", RetData.Remark), _
                                        New SqlParameter("@CreatedByUserID", RetData.CreatedByUID), _
                                        New SqlParameter("@Point", RetData.Point)}
        'Try
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateCourseGrade", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' Deletes CourseGrade from the database
    ''' </summary>
    ''' <param name="CourseGradeID"></param>
    ''' <remarks>It deletes CourseGrade record from the database </remarks>
    Public Function DeleteCourseGrade(ByVal CourseGradeID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseGradeID", CourseGradeID)}
        Try
            'Delete CourseGrade data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteCourseGrade", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Updates CourseGrade Data
    ''' </summary>
    ''' <param name="RetData"></param>
    ''' <remarks>It updates the database using CourseGrade</remarks>
    Public Function UpdateCourseGrade(ByVal RetData As UploadResultData) As Integer
        'Declare and initialize data access parameters

        Dim params() As SqlParameter = {New SqlParameter("@CourseGradeID", RetData.CourseGradeID), _
                                        New SqlParameter("@CourseGrade", RetData.CourseGrade), _
                                        New SqlParameter("@UpperBound", RetData.UpperBound), _
                                        New SqlParameter("@LowerBound", RetData.LowerBound), _
                                        New SqlParameter("@Remarks", RetData.Remark), _
                                        New SqlParameter("@CreatedByUserID", RetData.CreatedByUID), _
                                        New SqlParameter("@Point", RetData.Point)}
        'Try
        'Modify CourseGrade data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateCourseGrade", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try

    End Function
    ''' <summary>
    ''' Finds Department by CourseGradeID
    ''' </summary>
    ''' <param name="CourseGradeID"></param>
    ''' <returns>UploadResultData</returns>
    ''' <remarks>It takes DeptID and returns UploadResultData </remarks>
    Public Function FindCourseGradeByID(ByVal CourseGradeID As Integer) As UploadResultData
        Dim CourseGrade As UploadResultData = New UploadResultData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CourseGradeID", CourseGradeID)}
        'Try
        'Fetch item based on CourseGradeID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindCourseGradeByID", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    CourseGrade.CourseGradeID = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    CourseGrade.Grade = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    CourseGrade.UpperBound = row(2)
                End If

                If Not IsDBNull(row(3)) Then
                    CourseGrade.LowerBound = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    CourseGrade.Remark = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    CourseGrade.Point = row(5)
                End If
            Next
            'Return department data.
            Return CourseGrade
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
    ''' Fetches all CourseGrade to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCourseGrade() As DataSet
        'Holds CourseGrade Data
        Dim CourseGrade As DataSet = New DataSet
        Try
            'Fetch all CourseGrade.
            CourseGrade = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCourseGrade")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched CourseGrade data
        Return CourseGrade
    End Function
    ''' <summary>
    ''' FindCourseName
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindResultByCourseCode(ByVal AcademicSession As String, ByVal Semester As String, ByVal CourseCode As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@CourseCode", CourseCode)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindResultByCourseCode", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindResultByRegNumber(ByVal Semester As String, ByVal AcademicSession As String, ByVal RegNumber As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@Semester", Semester), _
        New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@RegNumber", RegNumber)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindResultByRegNumber", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindResultByRegisteredCourses(ByVal Semester As String, ByVal AcademicSession As String, ByVal RegNumber As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@Semester", Semester), _
        New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@RegNumber", RegNumber)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindResultByRegisteredCourses", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindResultByRegNumberBySemester(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal CourseCode As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@CourseCode", CourseCode)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindResultByRegNumberBySemester", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindResultByRegNumber1(ByVal AcademicSession As String, ByVal RegNumber As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@RegNumber", RegNumber)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindResultByRegNumber2", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    '' <summary>
    ''' FindStudentsRecords
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindStudentsRecords(ByVal FacultyID As Integer, ByVal DepartmentID As Integer, ByVal LevelID As Integer, ByVal SessionID As Integer) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@FacultyID", FacultyID), _
        New SqlParameter("@DepartmentID", DepartmentID), _
        New SqlParameter("@LevelID", LevelID), _
        New SqlParameter("@SessionID", SessionID)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindStudentsRecords", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    '' <summary>
    ''' 
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindStudentsRecordsByRegNo(ByVal RegNo As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNo", RegNo)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindStudentsRecordsByRegNo", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    '' <summary>
    ''' 
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindStudentsRecordsBySurname(ByVal Surname As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@Surname", Surname)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindStudentsRecordsBySurname", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    '' <summary>
    ''' FindStudentsRecords
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllStudentsThatHavePaid(ByVal FacultyID As Integer, ByVal DepartmentID As Integer, ByVal LevelID As Integer, ByVal SessionID As Integer, ByVal SemesterID As Integer) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@FacultyID", FacultyID), _
        New SqlParameter("@DepartmentID", DepartmentID), _
        New SqlParameter("@LevelID", LevelID), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@SessionID", SessionID)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStudentsThatHavePaid", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    '' <summary>
    ''' FindStudentsRecords
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllStudentsThatNotHavePaid(ByVal FacultyID As Integer, ByVal DepartmentID As Integer, ByVal LevelID As Integer, ByVal SessionID As Integer, ByVal SemesterID As Integer) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@FacultyID", FacultyID), _
        New SqlParameter("@DepartmentID", DepartmentID), _
        New SqlParameter("@LevelID", LevelID), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@SessionID", SessionID)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStudentsThatNotHavePaids", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    '' <summary>
    ''' FindStudentsRecords
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindStudentsRecordsByLGA(ByVal StateID As Integer, ByVal LGAID As Integer, ByVal LevelID As Integer, ByVal SessionID As Integer) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@StateID", StateID), _
        New SqlParameter("@LGAID", LGAID), _
        New SqlParameter("@LevelID", LevelID), _
        New SqlParameter("@SessionID", SessionID)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindStudentsRecordsByLGA", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    '' <summary>
    ''' FindStudentsRecords
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllStudentsRecords() As DataSet

        Dim UploadResult As DataSet = New DataSet
        'Dim params() As SqlParameter = _
        '{New SqlParameter("@StateID", StateID), _
        'New SqlParameter("@LGAID", LGAID), _
        'New SqlParameter("@LevelID", LevelID), _
        'New SqlParameter("@SessionID", SessionID)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStudentsRecords")

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    
    Public Function FindStudentsThatHavePaid(ByVal AcademicSessionID As Integer, ByVal LevelID As Integer) As UploadResultData
        Dim CourseGrade As UploadResultData = New UploadResultData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", AcademicSessionID), _
        New SqlParameter("@LevelID", LevelID)}
        'Try
        'Find Course Name
        'Fetch item based on CourseGradeID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStudentsThatHavePaid", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    CourseGrade.RegNum = row(0)
                End If
                
            Next
            'Return department data.
            Return CourseGrade
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
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="Semester"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindStudentResultByRegNumber(ByVal Semester As String, ByVal RegNumber As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@Semester", Semester), _
        New SqlParameter("@RegNumber", RegNumber)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindStudentResultByRegNumber", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="Semester"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllResultsByRegNumber(ByVal AcademicSession As String, ByVal LevelName As String, ByVal Semester As String, ByVal CourseCode As String, ByVal RegNumber As String, ByVal RegNumber1 As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@AcademicSession", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@CourseCode", CourseCode), _
        New SqlParameter("@RegNumber1", RegNumber1), _
        New SqlParameter("@RegNumber", RegNumber)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllResultsByRegNumber", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindCourseName
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindResultsByRegNumber(ByVal CourseCode As String, ByVal AcademicSession As String, ByVal RegNumber As String, ByVal RegNumber1 As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseCode", CourseCode), _
        New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@RegNumber1", RegNumber1)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindResultsByRegNumber", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindCourseName
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindResultsByRegNumber1(ByVal Semester As String, ByVal LevelName As String, ByVal CourseCode As String, ByVal AcademicSession As String, ByVal RegNumber As String, ByVal RegNumber1 As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@CourseCode", CourseCode), _
        New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@RegNumber1", RegNumber1)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindResultByRegNumber1", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function

    Public Function TotalNoStudentThatHavePaidByDept(ByVal FacultyID As Integer, ByVal DepartmentID As Integer, ByVal LevelID As Integer, ByVal SessionID As Integer, ByVal SemesterID As Integer) As Integer
        'instantiate object to hold user data
        Dim RetValue As Integer
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = _
        {New SqlParameter("@FacultyID", FacultyID), _
        New SqlParameter("@DepartmentID", DepartmentID), _
        New SqlParameter("@LevelID", LevelID), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@SessionID", SessionID)}


        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "TotalNoStudentThatHavePaidByDept", params)
            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows

                    If Not IsDBNull(row(0)) Then
                        RetValue = row(0)
                    End If

                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        Return RetValue
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="Semester"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllResultsByCourseCode(ByVal AcademicSession As String, ByVal LevelName As String, ByVal Semester As String, ByVal CourseCode As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@AcademicSession", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@CourseCode", CourseCode)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllResultsByCourseCode", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllResultByRegNumber(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@RegNumber", RegNumber)}
        Try
            'Find Course Name
            UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllResultByRegNumber", params)

        Catch ex As Exception
            Return Nothing
        End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllResultByRegNumber_Load(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As ArrayList

        Dim QueueList As New ArrayList
        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@RegNumber", RegNumber)}

        'QueueList.Add(New FetchResultArrayData("Empty", "Empty", "Empty", "Empty", "Empty", "Empty"))

        Try
            'Find Course Name
            UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllResultByRegNumber", params)

            Dim row4 As String = "Empty"
            Dim row5 As String = "Empty"
            Dim row6 As String = "Empty"
            Dim row9 As String = "Empty"
            Dim row10 As String = "Empty"
            Dim row11 As String = "Empty"

            If UploadResult.Tables(0).Rows.Count = 0 Then
                QueueList.Add(New FetchResultArrayData(row4, row5, row6, row9, row10, row11))
            Else
                For Each row As DataRow In UploadResult.Tables(0).Rows
                    If Not IsDBNull(row(4)) Then
                        row4 = row(4)
                    End If

                    If Not IsDBNull(row(5)) Then
                        row5 = row(5)
                    End If

                    If Not IsDBNull(row(6)) Then
                        row6 = row(6)
                    End If

                    If Not IsDBNull(row(9)) Then
                        row9 = row(9)
                    End If

                    If Not IsDBNull(row(10)) Then
                        row10 = row(10)
                    End If

                    If Not IsDBNull(row(11)) Then
                        row11 = row(11)
                    End If

                    QueueList.Add(New FetchResultArrayData(row4, row5, row6, row9, row10, row11))
                Next
            End If


            Return QueueList

        Catch ex As Exception
            QueueList.Add(New FetchResultArrayData("Empty", "Empty", "Empty", "Empty", "Empty", "Empty"))
            Return QueueList
        End Try


    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllResultByRegNumber_ExtraYear(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@RegNumber", RegNumber)}
        Try
            'Find Course Name
            UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllResultByRegNumber_ExtraYear", params)


        Catch ex As Exception
            Return Nothing
        End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllResultByRegNumber_Load_ExtraYear(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As ArrayList


        Dim QueueList As New ArrayList
        Dim UploadResult As DataSet = New DataSet

        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@RegNumber", RegNumber)}
        Try
            'Find Course Name
            UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllResultByRegNumber_ExtraYear", params)

            Dim row4 As String = "Empty"
            Dim row5 As String = "Empty"
            Dim row6 As String = "Empty"
            Dim row9 As String = "Empty"
            Dim row10 As String = "Empty"
            Dim row11 As String = "Empty"

            If UploadResult.Tables(0).Rows.Count = 0 Then
                QueueList.Add(New FetchResultArrayData(row4, row5, row6, row9, row10, row11))
            Else
                For Each row As DataRow In UploadResult.Tables(0).Rows
                    If Not IsDBNull(row(4)) Then
                        row4 = row(4)
                    End If

                    If Not IsDBNull(row(5)) Then
                        row5 = row(5)
                    End If

                    If Not IsDBNull(row(6)) Then
                        row6 = row(6)
                    End If

                    If Not IsDBNull(row(9)) Then
                        row9 = row(9)
                    End If

                    If Not IsDBNull(row(10)) Then
                        row10 = row(10)
                    End If

                    If Not IsDBNull(row(11)) Then
                        row11 = row(11)
                    End If

                    QueueList.Add(New FetchResultArrayData(row4, row5, row6, row9, row10, row11))
                Next
            End If


            Return QueueList
        Catch ex As Exception
            Return Nothing
        End Try
        Return QueueList
    End Function
    
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllResultByRegNumber_Summer(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@RegNumber", RegNumber)}
        Try
            'Find Course Name
            UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllResultByRegNumber_Summer", params)

        Catch ex As Exception
            Return Nothing
        End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllResultByRegNumber_Load_Summer(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As ArrayList

        Dim QueueList As New ArrayList
        Dim UploadResult As DataSet = New DataSet

        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@RegNumber", RegNumber)}
        Try
            'Find Course Name
            UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllResultByRegNumber_Summer", params)

            Dim row4 As String = "Empty"
            Dim row5 As String = "Empty"
            Dim row6 As String = "Empty"
            Dim row9 As String = "Empty"
            Dim row10 As String = "Empty"
            Dim row11 As String = "Empty"

            If UploadResult.Tables(0).Rows.Count = 0 Then
                QueueList.Add(New FetchResultArrayData(row4, row5, row6, row9, row10, row11))
            Else
                For Each row As DataRow In UploadResult.Tables(0).Rows
                    If Not IsDBNull(row(4)) Then
                        row4 = row(4)
                    End If

                    If Not IsDBNull(row(5)) Then
                        row5 = row(5)
                    End If

                    If Not IsDBNull(row(6)) Then
                        row6 = row(6)
                    End If

                    If Not IsDBNull(row(9)) Then
                        row9 = row(9)
                    End If

                    If Not IsDBNull(row(10)) Then
                        row10 = row(10)
                    End If

                    If Not IsDBNull(row(11)) Then
                        row11 = row(11)
                    End If

                    QueueList.Add(New FetchResultArrayData(row4, row5, row6, row9, row10, row11))
                Next
            End If


            Return QueueList
        Catch ex As Exception
            Return Nothing
        End Try
        Return QueueList
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllStudentResultByRegNumber(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@RegNumber", RegNumber)}
        Try
            'Find Course Name
            UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStudentResultByRegNumber", params)

        Catch ex As Exception
            Return Nothing
        End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllResultByRegNumber_CarryOver(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@RegNumber", RegNumber)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllResultByRegNumber_CarryOver", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllResultByRegNumber_CarryOver_Temp(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@RegNumber", RegNumber)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllResultByRegNumber_CarryOver_Temp", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllRegisteredCoursesByRegNumber(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@RegNumber", RegNumber)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllRegisteredCoursesByRegNumber", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindAllRegisteredCoursesByRegNumber_CarryOver(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName), _
        New SqlParameter("@RegNumber", RegNumber)}
        'Try
        'Find Course Name
        UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllRegisteredCoursesByRegNumber_CarryOver", params)

        'Catch ex As Exception
        '    Return Nothing
        'End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' Upload Result
    ''' </summary>
    ''' <param name="Result"></param>
    ''' <remarks>It Upload Result into the database using UploadResultData</remarks>
    Public Function LoadingResult(ByVal Result As UploadResultData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim TxnFlag As String = "N"
        Dim ErrorFlag As String = "N"

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Result.RegNum), _
        New SqlParameter("@SessionName", Result.AcademicSession), _
        New SqlParameter("@Semester", Result.Semester), _
        New SqlParameter("@LogTxnFlag", TxnFlag), _
        New SqlParameter("@LogErrorFlag", ErrorFlag), _
        New SqlParameter("@CreatedByRegNo", Result.RegNum), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}
        'Assigning value to the return value
        params(6).Direction = ParameterDirection.Output
        params(7).Direction = ParameterDirection.Output

        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_LoadingResult", params)
            'Populate Error Code
            RetVal(0) = params(6).Value
            'Populate Error Hint
            RetVal(1) = params(7).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(6).Value
            'Populate Error Hint
            RetVal(1) = params(7).Value
            Return RetVal
        End Try
    End Function
   
    ''' <summary>
    ''' Upload Result
    ''' </summary>
    ''' <param name="Result"></param>
    ''' <remarks>It Upload Result into the database using UploadResultData</remarks>
    Public Function LoadingResult_ExtraYear(ByVal Result As UploadResultData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Result.RegNum), _
        New SqlParameter("@SessionName", Result.AcademicSession), _
        New SqlParameter("@Semester", Result.Semester), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByRegNo", Result.RegNum), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(6).Direction = ParameterDirection.Output
        params(7).Direction = ParameterDirection.Output

        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_LoadingResult_ExtraYear", params)
            'Populate Error Code
            RetVal(0) = params(6).Value
            'Populate Error Hint
            RetVal(1) = params(7).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(6).Value
            'Populate Error Hint
            RetVal(1) = params(7).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Upload Result
    ''' </summary>
    ''' <param name="Result"></param>
    ''' <remarks>It Upload Result into the database using UploadResultData</remarks>
    Public Function LoadingResult_Summer(ByVal Result As UploadResultData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Result.RegNum), _
        New SqlParameter("@SessionName", Result.AcademicSession), _
        New SqlParameter("@Semester", Result.Semester), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByRegNo", Result.RegNum), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}
        'Assigning value to the return value
        params(6).Direction = ParameterDirection.Output
        params(7).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_LoadingResult_Summer", params)
            'Populate Error Code
            RetVal(0) = params(6).Value
            'Populate Error Hint
            RetVal(1) = params(7).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(6).Value
            'Populate Error Hint
            RetVal(1) = params(7).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Upload Result
    ''' </summary>
    ''' <param name="Result"></param>
    ''' <remarks>It Upload Result into the database using UploadResultData</remarks>
    Public Function LoadingResult_CarryOver(ByVal Result As UploadResultData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Result.RegNum), _
        New SqlParameter("@SessionName", Result.AcademicSession), _
        New SqlParameter("@Semester", Result.Semester), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByRegNo", Result.RegNum), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}
        'Assigning value to the return value
        params(6).Direction = ParameterDirection.Output
        params(7).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_LoadingResult_CarryOver", params)
            'Populate Error Code
            RetVal(0) = params(6).Value
            'Populate Error Hint
            RetVal(1) = params(7).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(6).Value
            'Populate Error Hint
            RetVal(1) = params(7).Value
            Return RetVal
        End Try
    End Function
    Public Function FindStudentPINByRegNumber(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As String
        'instantiate object to hold user data
        Dim RetValue As String = String.Empty
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = _
          {New SqlParameter("@SessionName", AcademicSession), _
          New SqlParameter("@Semester", Semester), _
          New SqlParameter("@LevelName", LevelName), _
          New SqlParameter("@RegNumber", RegNumber)}


        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStudentPINByRegNumber", params)
        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                If Not IsDBNull(row(0)) Then
                    RetValue = row(0)
                End If

            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        Return RetValue
    End Function
    Public Function CountCarryOverCourses(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As Integer
        'instantiate object to hold user data
        Dim RetValue As Integer
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = _
          {New SqlParameter("@SessionName", AcademicSession), _
          New SqlParameter("@Semester", Semester), _
          New SqlParameter("@LevelName", LevelName), _
          New SqlParameter("@RegNumber", RegNumber)}


        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CountCarryOverCourses", params)
        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                If Not IsDBNull(row(0)) Then
                    RetValue = row(0)
                End If

            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        Return RetValue
    End Function
    Public Function FindIncompleteRegisteredCourses(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As String
        'instantiate object to hold user data
        Dim RetValue As String = String.Empty
        
        'declare parameter to access database 
        Dim params() As SqlParameter = _
          {New SqlParameter("@SessionName", AcademicSession), _
           New SqlParameter("@Semester", Semester), _
           New SqlParameter("@LevelName", LevelName), _
           New SqlParameter("@RegNumber", RegNumber), _
           New SqlParameter("@retcode", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(4).Direction = ParameterDirection.Output

        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "FindIncompleteRegisteredCourses", params)
            'Populate Error Code
            RetValue = params(4).Value
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetValue = params(4).Value
        End Try

        Return RetValue

    End Function
    Public Function FindIncompleteRegisteredCourses_ExtraYear(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As String
        'instantiate object to hold user data
        Dim RetValue As String = String.Empty

        'declare parameter to access database 
        Dim params() As SqlParameter = _
          {New SqlParameter("@SessionName", AcademicSession), _
           New SqlParameter("@Semester", Semester), _
           New SqlParameter("@LevelName", LevelName), _
           New SqlParameter("@RegNumber", RegNumber), _
           New SqlParameter("@retcode", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(4).Direction = ParameterDirection.Output

        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "FindIncompleteRegisteredCourses_ExtraYear", params)
            'Populate Error Code
            RetValue = params(4).Value
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetValue = params(4).Value
        End Try

        Return RetValue

    End Function
    Public Function FindIncompleteRegisteredCourses_Summer(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String, ByVal RegNumber As String) As String
        'instantiate object to hold user data
        Dim RetValue As String = String.Empty

        'declare parameter to access database 
        Dim params() As SqlParameter = _
          {New SqlParameter("@SessionName", AcademicSession), _
           New SqlParameter("@Semester", Semester), _
           New SqlParameter("@LevelName", LevelName), _
           New SqlParameter("@RegNumber", RegNumber), _
           New SqlParameter("@retcode", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(4).Direction = ParameterDirection.Output

        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "FindIncompleteRegisteredCourses_Summer", params)
            'Populate Error Code
            RetValue = params(4).Value
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetValue = params(4).Value
        End Try

        Return RetValue

    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="AcademicSession"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindResultBySessionSemesterLevel(ByVal AcademicSession As String, ByVal Semester As String, ByVal LevelName As String) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionName", AcademicSession), _
        New SqlParameter("@Semester", Semester), _
        New SqlParameter("@LevelName", LevelName)}
        Try
            'Find Course Name
            UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindResultBySessionSemesterLevel", params)

        Catch ex As Exception
            Return Nothing
        End Try
        Return UploadResult
    End Function
    ''' <summary>
    ''' FindResultByRegNumber
    ''' </summary>
    ''' <param name="SessionID"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function FindStudentThatHaveCheckedResult(ByVal SessionID As Integer, ByVal SemesterID As Integer) As DataSet

        Dim UploadResult As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", SessionID), _
        New SqlParameter("@SemesterID", SemesterID)}
        Try
            'Find Course Name
            UploadResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindStudentThatHaveCheckedResult", params)

        Catch ex As Exception
            Return Nothing
        End Try
        Return UploadResult
    End Function
    Public Function CountStudentThatHaveCheckedResult(ByVal SessionID As Integer, ByVal SemesterID As Integer) As Integer
        'instantiate object to hold user data
        Dim RetValue As Integer
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = _
          {New SqlParameter("@SessionID", SessionID), _
        New SqlParameter("@SemesterID", SemesterID)}


        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CountStudentThatHaveCheckedResult", params)
        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                If Not IsDBNull(row(0)) Then
                    RetValue = row(0)
                End If

            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        Return RetValue
    End Function
End Class
