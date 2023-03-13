''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Chima kalu-orji
'' Date: 06-23-2016
'' This Class manages Academic Courses.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class SessionSemesterDepartmentDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Creates a Session
    ''' </summary>
    ''' <param name="Session"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Session</remarks>
    Public Function CreateSession(ByVal Session As SessionSemesterDepartmentData) As Integer
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
    ''' Updates Session Data
    ''' </summary>
    ''' <param name="Session"></param>
    ''' <remarks>It updates the database using SessionLevelSemesterCourseData</remarks>
    Public Function UpdateSession(ByVal Session As SessionSemesterDepartmentData) As Integer
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

    Public Function UpdateDepartment(ByVal Session As SessionSemesterDepartmentData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@DeptID", Session.DeptID), _
        New SqlParameter("@DeptName", Session.DeptName)}
        Try
            'Modify Session data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateDepartment", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function

    Public Function UpdateLevel(ByVal Session As SessionSemesterDepartmentData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@LevelID", Session.LevelID), _
        New SqlParameter("@LevelName", Session.LevelName)}
        Try
            'Modify Session data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateLevel", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function


    ''' <summary>
    ''' Finds Session by SessionID
    ''' </summary>
    ''' <param name="SessionID"></param>
    ''' <returns>SessionData</returns>
    ''' <remarks>It takes SessionID and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindSessionByID(ByVal SessionID As Integer) As SessionSemesterDepartmentData
        Dim Session As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
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
    ''' Finds Session by Session name
    ''' </summary>
    ''' <param name="SessionName"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes SessionName and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindSessionByName(ByVal SessionName As String) As SessionSemesterDepartmentData
        Dim data As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
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
    ''' Creates a Semester
    ''' </summary>
    ''' <param name="Semester"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Semester</remarks>
    Public Function CreateSemester(ByVal Semester As SessionSemesterDepartmentData) As Integer
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

    Public Function CreateDepartment(ByVal Dept As SessionSemesterDepartmentData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@DeptName", Dept.DeptName)}
        Try
            'Create Semester data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateDepartment", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    Public Function CreateLevel(ByVal Dept As SessionSemesterDepartmentData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@LevelName", Dept.LevelName)}
        Try
            'Create Semester data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateLevel", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    Public Function CreateProgramme(ByVal Dept As SessionSemesterDepartmentData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@DeptID", Dept.DeptID), _
         New SqlParameter("@ProgrammeName", Dept.ProgrammeName)}
        Try
            'Create Semester data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateProgramme", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    Public Function DeleteLevel(ByVal LevelID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@LevelID", LevelID)}
        Try
            'Delete Semester data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteLevel", params)
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

    Public Function DeleteDepartment(ByVal DeptID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@DeptID", DeptID)}
        Try
            'Delete Semester data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteDepartment", params)
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
    Public Function UpdateSemester(ByVal Semester As SessionSemesterDepartmentData) As Integer
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
    ''' Finds Semester by SemesterID
    ''' </summary>
    ''' <param name="SemesterID"></param>
    ''' <returns>SemesterData</returns>
    ''' <remarks>It takes SemesterID and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindSemesterByID(ByVal SemesterID As Integer) As SessionSemesterDepartmentData
        Dim Semester As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
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

    Public Function FindDepartmentByID(ByVal DeptID As Integer) As SessionSemesterDepartmentData
        Dim Semester As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@DeptID", DeptID)}
        Try
            'Fetch item based on SemesterID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindDepartmentByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Semester.DeptID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Semester.DeptName = row(1)
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

    Public Function FindLevelByID(ByVal LevelID As Integer) As SessionSemesterDepartmentData
        Dim Semester As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@LevelID", LevelID)}
        Try
            'Fetch item based on SemesterID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindLevelByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Semester.LevelID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Semester.LevelName = row(1)
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

    Public Function FindProgrammeByID(ByVal ProgrammeID As Integer) As SessionSemesterDepartmentData
        Dim Semester As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@ProgrammeID", ProgrammeID)}
        Try
            'Fetch item based on SemesterID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindProgrammeByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Semester.ProgrammeID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Semester.ProgrammeName = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        Semester.DeptName = row(2)
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

    Public Function FindAllDepartment() As DataSet
        'Holds Semesters Data
        Dim Semesters As DataSet = New DataSet
        'Try
        'Fetch all Semesters.
        Semesters = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllDepartment")
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched Semesters data
        Return Semesters
    End Function

    Public Function FindAllLevel() As DataSet
        'Holds Semesters Data
        Dim Semesters As DataSet = New DataSet
        'Try
        'Fetch all Semesters.
        Semesters = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllLevel")
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched Semesters data
        Return Semesters
    End Function

    Public Function FindAllProgramme() As DataSet
        'Holds Semesters Data
        Dim Semesters As DataSet = New DataSet
        Try
            'Fetch all Semesters.
            Semesters = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllProgramme")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Semesters data
        Return Semesters
    End Function

    Public Function FindAllTransactonLog() As DataSet
        'Holds Semesters Data
        Dim Semesters As DataSet = New DataSet
        Try
            'Fetch all Semesters.
            Semesters = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllTransactonLog")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Semesters data
        Return Semesters
    End Function

    ''' <summary>
    ''' Finds Semester by Semester name
    ''' </summary>
    ''' <param name="SemesterName"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes SemesterName and returns SessionLevelSemesterCourseData </remarks>
    Public Function FindSemesterByName(ByVal SemesterName As String) As SessionSemesterDepartmentData
        Dim data As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
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
End Class
