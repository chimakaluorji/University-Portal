''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Chima kalu-orji
'' Date: 31-01-2009
'' This Class manages Academic Programme.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic
Public Class ProgrammeDAL
    Inherits DataAccessBase
    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Creates a Programme
    ''' </summary>
    ''' <param name="Programme"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates ProgrammeData using Programme</remarks>
    Public Function CreateProgramme(ByVal Programme As ProgrammeData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ProgrammeName", Programme.ProgrammeName)}
        Try
            'Create Department data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateProgramme", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes Programme from the database
    ''' </summary>
    ''' <param name="ProgrammeID"></param>
    ''' <remarks>It deletes Programme record from the database </remarks>
    Public Function DeleteProgramme(ByVal ProgrammeID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ProgrammeID", ProgrammeID)}
        Try
            'Delete Programme data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteProgramme", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Updates Programme Data
    ''' </summary>
    ''' <param name="Programme"></param>
    ''' <remarks>It updates the database using ProgrammeData</remarks>
    Public Function UpdateProgramme(ByVal Programme As ProgrammeData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ProgrammeID", Programme.ProgrammeID), _
        New SqlParameter("@ProgrammeName", Programme.ProgrammeName)}
        Try
            'Modify Programme data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateProgramme", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Finds Programme by DeptID
    ''' </summary>
    ''' <param name="ProgrammeID"></param>
    ''' <returns>ProgrammeData</returns>
    ''' <remarks>It takes ProgrammeID and returns ProgrammeData </remarks>
    Public Function FindProgrammeByID(ByVal ProgrammeID As Integer) As ProgrammeData
        Dim Programme As ProgrammeData = New ProgrammeData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@ProgrammeID", ProgrammeID)}
        Try
            'Fetch item based on ProgrammeID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindProgrammeByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Programme.ProgrammeID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Programme.ProgrammeName = row(1)
                    End If
                Next
                'Return Programme data.
                Return Programme
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
    ''' Fetches all Programme to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllProgrammes() As DataSet
        'Holds Programme Data
        Dim Programme As DataSet = New DataSet
        Try
            'Fetch all Programme.
            Programme = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllProgrammes")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Programme data
        Return Programme
    End Function
    ''' <summary>
    ''' Finds Programme by Programme name
    ''' </summary>
    ''' <param name="ProgrammeName"></param>
    ''' <returns>ProgrammeData</returns>
    ''' <remarks>It takes ProgrammeName and returns ProgrammeData </remarks>
    Public Function FindProgrammeByName(ByVal ProgrammeName As String) As ProgrammeData
        Dim data As ProgrammeData = New ProgrammeData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@ProgrammeName", ProgrammeName)}
        Try
            'Fetch all item based on Programme name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindProgrammeByName", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        data.ProgrammeID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        data.ProgrammeName = row(1)
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
    ''' Finds Programme by Programme name
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>RegNumber</returns>
    ''' <remarks>It takes ProgrammeName and returns RegNumber </remarks>
    Public Function FindProgrammeIDByRegNumber(ByVal RegNumber As String) As ProgrammeData
        Dim data As ProgrammeData = New ProgrammeData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}
        Try
            'Fetch all item based on Programme name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindProgrammeIDByRegNumber", params)
            'Load record into datatable
            dt.Load(reader)

            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        data.ProgrammeID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        data.ProgrammeName = row(1)
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
