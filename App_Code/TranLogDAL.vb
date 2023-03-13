'''''''''''''''''''''''''
''''Handles Data Access for Transaction Logging
''''Author: Oyiri Uka
''''on 17-02-2009
'''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic

Public Class TranLogDAL
    Inherits DataAccessBase

    ''' <summary>
    ''' Constructor for UsersDAL Class
    ''' </summary>
    ''' <remarks>
    ''' 
    ''' </remarks>
    Public Sub New()
        ' Initialize the connection string for accessing DB
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Creates a Transaction Log
    ''' </summary>
    ''' <param name="tranCode"></param>
    ''' <param name="RegNumber"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates TranLogData using translog</remarks>
    Public Function LogStudentTran(ByVal tranCode As String, ByVal RegNumber As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CreatedByRegNo", RegNumber), _
        New SqlParameter("@TranCode", tranCode)}
        'Try
        'Create Transaction Log data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateStudentLogTran", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return 0
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function

    ''' <summary>
    ''' Creates a Transaction Log
    ''' </summary>
    ''' <param name="tranCode"></param>
    ''' <param name="CreatedByUID"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates TranLogData using translog</remarks>
    Public Function LogTran(ByVal tranCode As String, ByVal CreatedByUID As Integer) As Integer

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CreatedByUID", CreatedByUID), _
        New SqlParameter("@TranCode", tranCode)}
        Try
            'Create Transaction Log data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateLogTran", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Fetches all transaction log to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllTransLog() As DataSet
        'Holds Department Data
        Dim TransLog As DataSet = New DataSet
        Try
            'Fetch all departments.
            TransLog = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllTransLog")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched department data
        Return TransLog
    End Function

    ''' <summary>
    ''' Finds Find Transaction Code By Code
    ''' </summary>
    ''' <param name="TranCode"></param>
    ''' <returns>TranLogData</returns>
    ''' <remarks>It takes TranCode and returns TranLogData </remarks>
    Public Function FindTransLogByCode(ByVal TranCode As String) As DataSet
        Dim Log As DataSet = New DataSet

        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@TranCode", TranCode)}
        Try
            'Fetch all item based on department name
            Log = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindTransLogByCode", params)
            'Load record into datatable
            
            Return Log

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Finds Find Transaction Code By CreatedByUID
    ''' </summary>
    ''' <param name="CreatedByUID"></param>
    ''' <returns>TranLogData</returns>
    ''' <remarks>It takes CreatedByUID and returns TranLogData </remarks>
    Public Function FindTransLogByUser(ByVal CreatedByUID As String) As TranLogData
        Dim Log As TranLogData = New TranLogData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CreatedByUID", CreatedByUID)}
        Try
            'Fetch all item based on department name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTransLogByUser", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    Log.TranCode = row(0)
                    Log.TranDate = row(1)
                    If Not IsDBNull(row(2)) Then
                        Log.CreatedByUID = row(2)
                    End If
                Next
                Return Log
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
    ''' Finds Find Transaction Code By TranDate
    ''' </summary>
    ''' <param name="TranDate"></param>
    ''' <returns>TranLogData</returns>
    ''' <remarks>It takes TranDate and returns TranLogData </remarks>
    Public Function FindTransLogByDate(ByVal TranDate As String) As DataSet
        Dim Log As DataSet = New DataSet
        Dim StartToDate As Date = CType(TranDate & " 0:00:00 AM", Date)
        Dim EndToDate As Date = CType(TranDate & " 23:59:59 PM", Date)
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@TranDate", TranDate)}
        Try
            'Fetch all item based on department name
            Log = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindTransLogByDate", params)

            Return Log


        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Finds Find Transaction Code By TranDate
    ''' </summary>
    ''' <param name="StartDate"></param>
    '''<param name="EndDate"></param>
    ''' <returns>TranLogData</returns>
    ''' <remarks>It takes TranDate and returns TranLogData </remarks>
    Public Function FindTranLogByDateRange(ByVal StartDate As String, ByVal EndDate As String) As DataSet
        Dim Log As DataSet = New DataSet
        Dim StartToDate As Date = CType(StartDate & " 0:00:00 AM", Date)
        Dim EndToDate As Date = CType(EndDate & " 23:59:59 PM", Date)
       
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@StartDate", StartToDate), _
        New SqlParameter("@EndDate", EndToDate)}
        Try
            'Fetch all item based on department name
            Log = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindTranLogByDateRange", params)
           
            Return Log

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Fetches all transaction log to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllStudTransLog() As DataSet
        'Holds Department Data
        Dim TransLog As DataSet = New DataSet
        Try
            'Fetch all departments.
            TransLog = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStudTransLog")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched department data
        Return TransLog
    End Function

    ''' <summary>
    ''' Finds Find Transaction Code By Code
    ''' </summary>
    ''' <param name="TranCode"></param>
    ''' <returns>TranLogData</returns>
    ''' <remarks>It takes TranCode and returns TranLogData </remarks>
    Public Function FindStudTransLogByCode(ByVal TranCode As String) As DataSet
        Dim Log As DataSet = New DataSet
        
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@TranCode", TranCode)}
        Try
            'Fetch all item based on department name
            Log = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindStudTransLogByCode", params)
            'Load record into datatable
            
            Return Log

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Finds Find Transaction Code By CreatedByUID
    ''' </summary>
    ''' <param name="CreatedByUID"></param>
    ''' <returns>TranLogData</returns>
    ''' <remarks>It takes CreatedByUID and returns TranLogData </remarks>
    Public Function FindStudTransLogByUser(ByVal CreatedByUID As String) As TranLogData
        Dim Log As TranLogData = New TranLogData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CreatedByUID", CreatedByUID)}
        Try
            'Fetch all item based on department name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStudTransLogByUser", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    Log.TranCode = row(0)
                    Log.TranDate = row(1)
                    If Not IsDBNull(row(2)) Then
                        Log.CreatedByUID = row(2)
                    End If
                Next
                Return Log
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
    ''' Finds Find Transaction Code By TranDate
    ''' </summary>
    ''' <param name="TranDate"></param>
    ''' <returns>TranLogData</returns>
    ''' <remarks>It takes TranDate and returns TranLogData </remarks>
    Public Function FindStudTransLogByDate(ByVal TranDate As String) As DataSet
        Dim Log As DataSet = New DataSet
        Dim StartToDate As Date = CType(TranDate & " 0:00:00 AM", Date)
        Dim EndToDate As Date = CType(TranDate & " 23:59:59 PM", Date)
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@TranDate", TranDate)}
        Try
            'Fetch all item based on department name
            Log = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindStudTransLogByDate", params)
            'Load record into datatable
            
            Return Log
            

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Finds Find Transaction Code By TranDate
    ''' </summary>
    ''' <param name="StartDate"></param>
    '''<param name="EndDate"></param>
    ''' <returns>TranLogData</returns>
    ''' <remarks>It takes TranDate and returns TranLogData </remarks>
    Public Function FindStudTranLogByDateRange(ByVal StartDate As String, ByVal EndDate As String) As DataSet
        Dim Log As DataSet = New DataSet
        Dim StartToDate As Date = CType(StartDate & " 0:00:00 AM", Date)
        Dim EndToDate As Date = CType(EndDate & " 23:59:59 PM", Date)

        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@StartDate", StartToDate), _
        New SqlParameter("@EndDate", EndToDate)}
        'Fetch all item based on department name
        Log = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindStudTranLogByDateRange", params)

        'Load record into datatable
        Try
            Return Log

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
End Class
