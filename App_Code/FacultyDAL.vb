''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Nsi Idika
'' Date: 21-01-2009
'' This Class handles Faculty Data Access Logic
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class FacultyDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Creates a faculty
    ''' </summary>
    ''' <param name="FacultyName"></param>
    ''' <returns>FacultyData</returns>
    ''' <remarks>It creates Faculty Data </remarks>
    Public Function CreateFaculty(ByVal FacultyName As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@FacultyName", FacultyName)}
        Try
            'Create faculty data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateFaculty", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Deletes faculty from the database
    ''' </summary>
    ''' <param name="FacultyID"></param>
    ''' <remarks>It deletes faculty from the database </remarks>
    Public Function DeleteFaculty(ByVal FacultyID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@FacultyID", FacultyID)}
        Try
            'Delete Department data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteFaculty", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Updates Faculty data in the database
    ''' </summary>
    ''' <param name="faculty"></param>
    ''' <remarks>It updates FacultyData</remarks>
    Public Function UdpateFaculty(ByVal faculty As FacultyData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@FacultyName", faculty.FacultyName), _
        New SqlParameter("@FacultyID", faculty.FacultyID)}
        Try
            'Modify faculty data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateFaculty", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Returns a faculty
    ''' </summary>
    ''' <param name="FacultyID"></param>
    ''' <returns>FacultyData</returns>
    ''' <remarks>It takes FacultyID and returns FacultyData </remarks>
    Public Function FindFacultyByID(ByVal FacultyID As Integer) As FacultyData
        Dim Faculty As FacultyData = New FacultyData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@FacultyID", FacultyID)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindFacultyByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Faculty.FacultyID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Faculty.FacultyName = row(1)
                    End If
                Next
            Else
                Return Nothing
            End If

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return Faculty Details.
        Return Faculty
    End Function

    ''' <summary>
    ''' Returns a faculty
    ''' </summary>
    ''' <param name="FacultyName"></param>
    ''' <returns>FacultyData</returns>
    ''' <remarks>It takes FacultyName and returns FacultyData </remarks>
    Public Function FindFacultyByName(ByVal FacultyName As String) As FacultyData
        Dim Faculty As FacultyData = New FacultyData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@FacultyName", FacultyName)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindFacultyByName", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Faculty.FacultyID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Faculty.FacultyName = row(1)
                    End If
                Next
            Else
                Return Nothing
            End If

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return Faculty Details.
        Return Faculty
    End Function
    ''' <summary>
    ''' Returns all Faculties
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllFaculties() As DataSet
        'Holds Department Data
        Dim Faculty As DataSet = New DataSet
        Try
            'Fetch all Knowledge Domain.
            Faculty = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllFaculty")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched data
        Return Faculty
    End Function
End Class
