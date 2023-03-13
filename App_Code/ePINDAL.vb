Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Net

Public Class ePINDAL
    Inherits DataAccessBase
    ''' <summary>
    ''' Uploading Fess PIN
    ''' </summary>
    ''' <param name="ePIN"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It Uploading Fess PIN</remarks>
    Public Function UploadePIN(ByVal ePIN As ePINData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ePIN", ePIN.ePIN), _
        New SqlParameter("@SerialNo", ePIN.Serial)}
        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UploadePIN", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Uploading Fess PIN
    ''' </summary>
    ''' <param name="ResultePIN"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It Uploading Fess PIN</remarks>
    Public Function UploadResultePIN(ByVal ResultePIN As ePINData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ResultePIN", ResultePIN.ResultePIN), _
        New SqlParameter("@SerialNo", ResultePIN.Serial)}
        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UploadResultePIN", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindePINByRegNumber(ByVal RegNumber As String) As ArrayList
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber)}


        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindePINByRegNumber", params)

        Dim SerialNo As String = ""
        For Each row As DataRow In Sessions.Tables(0).Rows
            If Not IsDBNull(row(10)) Then
                SerialNo = row(10)
            End If
            QueueList.Add(New ePINArrayData(row(0), row(1), row(2), row(4), row(6), row(8), row(9), SerialNo))
        Next

        Return QueueList
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindResultePINByRegNumber(ByVal RegNumber As String) As ArrayList
        'Holds Sessions Data
        Dim Sessions As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber)}


        Sessions = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindResultePINByRegNumber", params)

        Dim SerialNo As String = ""
        For Each row As DataRow In Sessions.Tables(0).Rows
            If Not IsDBNull(row(10)) Then
                SerialNo = row(10)
            End If
            QueueList.Add(New ePINArrayData(row(0), row(1), row(2), row(4), row(6), row(8), row(9), SerialNo))
        Next

        Return QueueList
    End Function
End Class
