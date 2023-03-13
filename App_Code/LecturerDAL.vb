''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Nsi Idika
'' Date: 26-01-2009
'' This Class manages Lecturer
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class LecturerDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Creates a lecturer
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates lecturer</remarks>
    Public Function CreateLecturer(ByVal data As LecturerData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@LecName", data.LecName), _
        New SqlParameter("@EmployeeNo", data.EmployeeNo), _
        New SqlParameter("@QualificationID", data.QualificationID), _
        New SqlParameter("@Specialization", data.Specialization)}
        Try
            'Create Lecturer data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateLecturer", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes lecturer from the database
    ''' </summary>
    ''' <param name="LecturerID"></param>
    ''' <remarks>It deletes lecturer record from the database </remarks>
    Public Function DeleteLecturer(ByVal LecturerID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@LecturerID", LecturerID)}
        Try
            'Delete Lecturer data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteLecturer", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Updates Lecturer Data
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks>It updates the database using LecturerData</remarks>
    Public Function UpdateLecturer(ByVal data As LecturerData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@LecturerID", data.LecturerID), _
        New SqlParameter("@LecName", data.LecName), _
        New SqlParameter("@EmployeeNo", data.EmployeeNo), _
        New SqlParameter("@QualificationID", data.QualificationID), _
        New SqlParameter("@Specialization", data.Specialization)}
        Try
            'Modify Lecturer data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateLecturer", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Finds Lecturer by LecturerID
    ''' </summary>
    ''' <param name="LecturerID"></param>
    ''' <returns>LecturerData</returns>
    ''' <remarks>It takes LecturerID and returns LecturerData </remarks>
    Public Function FindLecturerById(ByVal LecturerID As Integer) As LecturerData
        Dim data As LecturerData = New LecturerData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@LecturerID", LecturerID)}
        Try
            'Fetch item based on LecturerID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindLecturerByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                
                For Each row As DataRow In dt.Rows
                    data.LecturerID = row(0)
                    If Not IsDBNull(row(1)) Then
                        data.LecName = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        data.EmployeeNo = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        data.QualificationID = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        data.QualifShortName = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        data.Specialization = row(5)
                    End If
                Next
                'Return lecturer data.
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
    ''' Fetches all lecturers to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllLecturers() As DataSet
        'Holds Lecturer Data
        Dim lecturers As DataSet = New DataSet
        Try
            'Fetch all departments.
            lecturers = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllLecturers")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched lecturers data
        Return lecturers
    End Function

    ''' <summary>
    ''' Finds lecturer by name
    ''' </summary>
    ''' <param name="LecName"></param>
    ''' <returns>LecturerData</returns>
    ''' <remarks>It takes LecName and returns LecturerData </remarks>
    Public Function FindLecturerByName(ByVal LecName As String) As LecturerData
        Dim data As LecturerData = New LecturerData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@LecName", LecName)}
        Try
            'Fetch item based on LecturerID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindLecturerByName", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    data.LecturerID = row(0)
                    If Not IsDBNull(row(1)) Then
                        data.LecName = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        data.EmployeeNo = row(2)
                    End If
                    
                    If Not IsDBNull(row(3)) Then
                        data.QualificationID = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        data.QualifShortName = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        data.Specialization = row(5)
                    End If
                Next
                'Return lecturer data.
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
