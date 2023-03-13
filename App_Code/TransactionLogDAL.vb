Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Public Class TransactionLogDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub

    Public Function FindAllTransactionLog() As DataSet
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Try
            'Fetch all Sessions.
            Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllTransactionLog")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Sessions data
        Return Sessions
    End Function

    Public Function FindAllTransactionCode() As DataSet
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Try
            'Fetch all Sessions.
            Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllTransactionCode")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Sessions data
        Return Sessions
    End Function

    Public Function CreateTransactionLog(ByVal Dept As TransactionLogData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@TransactionCode", Dept.TransactionCode), _
         New SqlParameter("@Activity", Dept.Activity)}
        Try
            'Create Semester data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateTransactionLog", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    Public Function CreateTransactionCode(ByVal Dept As TransactionLogData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@TransactionCode", Dept.TransactionCode), _
         New SqlParameter("@Activity", Dept.Activity)}
        Try
            'Create Semester data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateTransactionCode", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    Public Function DeleteTransactionLog(ByVal TransactionLogID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@TransactionLogID", TransactionLogID)}
        Try
            'Delete Session data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteTransactionLog", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    Public Function DeleteTransactionCode(ByVal TransactionCodeID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@TransactionCodeID", TransactionCodeID)}
        Try
            'Delete Session data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteTransactionCode", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    Public Function UpdateTransactionLog(ByVal Session As TransactionLogData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@TransactionLogID", Session.TransactionLogID), _
         New SqlParameter("@TransactionCode", Session.TransactionCode), _
        New SqlParameter("@Activity", Session.Activity)}
        Try
            'Modify Session data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateTransactionLog", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function

    Public Function UpdateTransactionCode(ByVal Session As TransactionLogData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@TransactionCodeID", Session.TransactionCodeID), _
         New SqlParameter("@TransactionCode", Session.TransactionCode), _
        New SqlParameter("@Activity", Session.Activity)}
        Try
            'Modify Session data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateTransactionCode", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function

    Public Function FindTransactionLogByID(ByVal TransactionLogID As Integer) As TransactionLogData
        Dim Semester As TransactionLogData = New TransactionLogData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@TransactionLogID", TransactionLogID)}
        Try
            'Fetch item based on SemesterID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTransactionLogByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Semester.TransactionLogID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Semester.TransactionCode = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        Semester.Activity = row(2)
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

    Public Function FindTransactionCodeByID(ByVal TransactionCodeID As Integer) As TransactionLogData
        Dim Semester As TransactionLogData = New TransactionLogData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@TransactionCodeID", TransactionCodeID)}
        Try
            'Fetch item based on SemesterID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTransactionCodeByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Semester.TransactionCodeID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Semester.TransactionCode = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        Semester.Activity = row(2)
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
End Class
