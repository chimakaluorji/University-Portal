''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Chima kalu-orji
'' Date: 21-08-2009
'' This Class handles Faculty Data Access Logic
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Public Class ReligionDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Creates a Religion
    ''' </summary>
    ''' <param name="ReligionName"></param>
    ''' <returns>ReligionData</returns>
    ''' <remarks>It creates Religion Data </remarks>
    Public Function CreateReligion(ByVal ReligionName As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ReligionName", ReligionName)}
        Try
            'Create Religion data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateReligion", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Deletes Religion from the database
    ''' </summary>
    ''' <param name="ReligionID"></param>
    ''' <remarks>It deletes Religion from the database </remarks>
    Public Function DeleteReligion(ByVal ReligionID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ReligionID", ReligionID)}
        Try
            'Delete Religion data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteReligion", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Updates Religion data in the database
    ''' </summary>
    ''' <param name="Religion"></param>
    ''' <remarks>It updates ReligionData</remarks>
    Public Function UpdateReligion(ByVal Religion As ReligionData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@Religion", Religion.ReligionName), _
        New SqlParameter("@ReligionID", Religion.ReligionID)}
        Try
            'Modify Religion data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateReligion", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Returns a Religion
    ''' </summary>
    ''' <param name="ReligionID"></param>
    ''' <returns>ReligionData</returns>
    ''' <remarks>It takes ReligionID and returns ReligionData </remarks>
    Public Function FindReligionByID(ByVal ReligionID As Integer) As ReligionData
        Dim Religion As ReligionData = New ReligionData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@ReligionID", ReligionID)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindReligionByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Religion.ReligionID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Religion.ReligionName = row(1)
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
        Return Religion
    End Function

    ''' <summary>
    ''' Returns all Religion
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllReligion() As DataSet
        'Holds Religion Data
        Dim Religion As DataSet = New DataSet
        Try
            'Fetch all Knowledge Domain.
            Religion = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllReligion")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched data
        Return Religion
    End Function
End Class
