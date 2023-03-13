'''''''''''''''''''''''''
''''Handles Data Access for Transaction Code
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


Public Class TransactionCodeDAL
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
    ''' Fetches all transaction code to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllTranCode() As DataSet
        'Holds TransCode Data
        Dim TransCode As DataSet = New DataSet
        Try
            'Fetch all TransCode.
            TransCode = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllTranCode")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched department data
        Return TransCode
    End Function

    ''' <summary>
    ''' Finds Find Transaction Code By Code
    ''' </summary>
    ''' <param name="TransCode"></param>
    ''' <returns>TransactionCodeData</returns>
    ''' <remarks>It takes TransCode and returns TransactionCodeData </remarks>
    Public Function FindTranCodeByCode(ByVal TransCode As String) As TransactionCodeData
        Dim Code As TransactionCodeData = New TransactionCodeData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@TransCode", TransCode)}
        Try
            'Fetch all item based on department name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTranCodeByCode", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    Code.TransCode = row(0)
                    Code.Description = row(1)

                Next
                Return Code
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
