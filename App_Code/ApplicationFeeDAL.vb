''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Oyiri Uka
'' Date: 16-03-2009
'' This Class manages Application Fees.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class ApplicationFeeDAL
    Inherits DataAccessBase
    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub

    ''' <summary>
    '''Creates an Application Fee
    ''' </summary>
    ''' <param name="AdFee"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates ApplicationFeeData using AdFee</remarks>
    Public Function CreateApplicationFee(ByVal AdFee As ApplicationFeeData) As Integer

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
       {New SqlParameter("@AppProgID", AdFee.AppProgID), _
       New SqlParameter("@Amount", AdFee.Amount)}
        Try
            'Create State data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateApplicationFee", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Finds Application Fee By Application Progrommae ID
    ''' </summary>
    ''' <param name="AppProgID"></param>
    ''' <returns>ApplicationFeeData</returns>
    ''' <remarks>It takes AppProgID and returns ApplicationFeeData </remarks>
    Public Function FindApplicationFeeByAppProgID(ByVal AppProgID As String) As ApplicationFeeData
        Dim AdFee As ApplicationFeeData = New ApplicationFeeData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@AppProgID", AppProgID)}
        Try
            'Fetch item based on AppAcknowledgeNo
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindApplicationFeeByAppProgID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        AdFee.ApplicationFeeID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        AdFee.AppProgID = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        AdFee.Amount = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        AdFee.ProgrammeName = row(3)
                    End If
                Next
                'Return application data.
                Return AdFee
            Else
                Return Nothing
            End If
        Catch ex As Exception
            '    'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Fetches all Application Fees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllApplicationFee() As DataSet
        'Holds Department Data
        Dim AdFee As DataSet = New DataSet
        Try
            'Fetch all departments.
            AdFee = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "GetAllApplicationFee")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched department data
        Return AdFee
    End Function

    ''' <summary>
    ''' Updates Application Fee Data
    ''' </summary>
    ''' <param name="AdFee"></param>
    ''' <remarks>It updates the database using ApplicationFeeData</remarks>
    Public Function UpdateApplicationFee(ByVal AdFee As ApplicationFeeData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@AppProgID", AdFee.AppProgID), _
        New SqlParameter("@Amount", AdFee.Amount), _
        New SqlParameter("@ApplicationFeeID", AdFee.ApplicationFeeID)}
        'Try
        'Modify Department data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateApplicationFee", params)
        Return 1
        'Catch ex As Exception
        'If error occurs, log it
        'AppException.LogError(ex.Message)
        Return 0
        'End Try

    End Function

    ''' <summary>
    ''' Deletes Application Fee from the database
    ''' </summary>
    ''' <param name="ApplicationFeeID"></param>
    ''' <remarks>It deletes Application Fee record from the database </remarks>
    Public Function DeleteApplicationFee(ByVal ApplicationFeeID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ApplicationFeeID", ApplicationFeeID)}
        Try
            'Delete Department data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteApplicationFee", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
End Class
