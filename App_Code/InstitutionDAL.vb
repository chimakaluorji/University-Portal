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

Public Class InstitutionDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Creates a Institution
    ''' </summary>
    ''' <param name="InstitutionName"></param>
    ''' <returns>InstitutionData</returns>
    ''' <remarks>It creates Institution Data </remarks>
    Public Function CreateInstitution(ByVal InstitutionName As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@InstitutionName", InstitutionName)}
        'Try
        'Create Institution data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateInstitution", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return 0
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function

    ''' <summary>
    ''' Deletes Institution from the database
    ''' </summary>
    ''' <param name="InstitutionID"></param>
    ''' <remarks>It deletes Institution from the database </remarks>
    Public Function DeleteInstitution(ByVal InstitutionID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@InstitutionID", InstitutionID)}
        Try
            'Delete Institution data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteInstitution", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Updates Institution data in the database
    ''' </summary>
    ''' <param name="Institution"></param>
    ''' <remarks>It updates InstitutionData</remarks>
    Public Function UpdateInstitution(ByVal Institution As InstitutionData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@Institution", Institution.InstitutionName), _
        New SqlParameter("@InstitutionID", Institution.InstitutionID)}
        Try
            'Modify Institution data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateInstitution", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Returns a Institution
    ''' </summary>
    ''' <param name="InstitutionID"></param>
    ''' <returns>InstitutionData</returns>
    ''' <remarks>It takes InstitutionID and returns InstitutionData </remarks>
    Public Function FindInstitutionByID(ByVal InstitutionID As Integer) As InstitutionData
        Dim Institution As InstitutionData = New InstitutionData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@InstitutionID", InstitutionID)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindInstitutionByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Institution.InstitutionID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Institution.InstitutionName = row(1)
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
        Return Institution
    End Function

    ''' <summary>
    ''' Returns all Institutions
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllInstitution() As DataSet
        'Holds Institution Data
        Dim Institution As DataSet = New DataSet
        Try
            'Fetch all Knowledge Domain.
            Institution = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllInstitution")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched data
        Return Institution
    End Function
End Class
