Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic

Public Class ErrorDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Fetches all errors
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns a dataset of errors when successful or Nothing when not successful</remarks>
    Public Function GetAllErrors() As DataSet
        Dim ds As DataSet = New DataSet()
        Try
            'Fetch all errors
            ds = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "getErrorTable")
            'return the fetched record
            Return ds
        Catch ex As Exception
            'On error, log it and return nothing
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Creates Error
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>Returns 1 when successful and 0 when it fails.</remarks>
    Public Function CreateError(ByVal data As ErrorData) As Integer
        'Declare data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ErrorCode", data.ErrorCode), _
        New SqlParameter("@ErrorDetails", data.ErrorDetails)}
        Try
            'Create the new record
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateError", params)
            Return 1
        Catch ex As Exception
            'On error, log it and return nothing
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Deletes error from the system
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>Deletes error from the system</remarks>
    Public Function DeleteError(ByVal data As ErrorData) As Integer
        'Declare data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ErrorCode", data.ErrorCode)}
        Try
            'delete a error
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "ErrorDelete", params)
            Return 1
        Catch ex As Exception
            'On error, log it and return nothing
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Finds Error by code.
    ''' </summary>
    ''' <param name="ErrorCode"></param>
    ''' <returns>dataset</returns>
    ''' <remarks></remarks>
    Public Function FindErrorByCodeDS(ByVal ErrorCode As String) As DataSet
        Dim ds As DataSet = New DataSet
       
        'declare data access parameters
        Dim params() As SqlParameter = {New SqlParameter("@ErrorCode", ErrorCode)}
        Try
            'Fetch error
            ds = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindErrorByCode", params)
            Return ds
        Catch ex As Exception
            'On error, log it and return nothing
            AppException.LogError(ex.Message)
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' Finds Error by code.
    ''' </summary>
    ''' <param name="ErrorCode"></param>
    ''' <returns>ErrorData</returns>
    ''' <remarks></remarks>
    Public Function FindErrorByCode(ByVal ErrorCode As String) As ErrorData
        Dim ErrorItem As ErrorData = New ErrorData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare data access parameters
        Dim params() As SqlParameter = {New SqlParameter("@ErrorCode", ErrorCode)}
        Try
            'Fetch error
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindErrorByCode", params)
            'Load datareader object into a datatable object.
            dt.Load(reader)
            'Check if returned resultset contains data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    'populate Errordata object
                    ErrorItem.ErrorCode = row(0)
                    ErrorItem.ErrorDetails = row(1)
                Next
                Return ErrorItem
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'On error, log it and return nothing
            AppException.LogError(ex.Message)
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' Updates Error daata
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks></remarks>

    Public Function UpdateError(ByVal data As ErrorData) As Integer
        'declare data access paramters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ErrorCode", data.ErrorCode), _
        New SqlParameter("@ErrorDetails", data.ErrorDetails)}
        Try
            'Update error data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UPDATEError", params)
            Return 1
        Catch ex As Exception
            'On error, log it and return nothing
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function

End Class
