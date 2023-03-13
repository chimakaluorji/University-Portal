Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Net

Public Class CourseDAL
    Inherits DataAccessBase

    ''' <summary>
    ''' Creates a Profile
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates CountryStateLGAData using dept</remarks>
    Public Function CreateCourse(ByVal Course As CourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@SemesterID", Course.SemesterID), _
        New SqlParameter("@DepartmentID", Course.DepartmentID), _
        New SqlParameter("@ProgrammeID", Course.ProgrammeID), _
        New SqlParameter("@LevelID", Course.LevelID)}
        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateCourse", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a Profile
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates CountryStateLGAData using dept</remarks>
    Public Function UpdateCourse(ByVal Course As CourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseID", Course.CourseID), _
        New SqlParameter("@CourseCode", Course.CourseCode), _
        New SqlParameter("@CourseName", Course.CourseName), _
        New SqlParameter("@CreditUnit", Course.CreditUnit), _
        New SqlParameter("@SemesterID", Course.SemesterID), _
        New SqlParameter("@DepartmentID", Course.DepartmentID), _
        New SqlParameter("@ProgrammeID", Course.ProgrammeID), _
        New SqlParameter("@LevelID", Course.LevelID)}
        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateCourse", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a Profile
    ''' </summary>
    ''' <param name="Course"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates CountryStateLGAData using dept</remarks>
    Public Function DeleteCourse(ByVal Course As CourseData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseID", Course.CourseID)}
        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteCourse", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Finds Course by CourseID
    ''' </summary>
    ''' <param name="CourseID"></param>
    ''' <returns>SessionData</returns>
    ''' <remarks>It takes CourseID and returns CourseData </remarks>
    Public Function FindCourseByCourseID(ByVal CourseID As Integer) As CourseData
        Dim Course As CourseData = New CourseData

        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CourseID", CourseID)}
        'Try
        'Fetch item based on SessionID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindCourseByCourseID", params)
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
                    Course.CreditUnit = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    Course.SemesterID = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    Course.SemesterName = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    Course.DepartmentID = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    Course.DeptName = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    Course.LevelID = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    Course.LevelName = row(9)
                End If

            Next
            'Return Session data.
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
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCourse() As DataSet
        'Holds Sessions Data
        Dim Course As DataSet = New DataSet
        Try
            'Fetch all Sessions.
            Course = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCourses")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Sessions data
        Return Course
    End Function

End Class
