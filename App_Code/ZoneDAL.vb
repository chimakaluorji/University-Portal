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


Public Class ZoneDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Creates a ZoneName
    ''' </summary>
    ''' <param name="ZoneName"></param>
    ''' <returns>ZoneData</returns>
    ''' <remarks>It creates Zone Data </remarks>
    Public Function CreateZone(ByVal ZoneName As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ZoneName", ZoneName)}
        Try
            'Create Zone data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateZone", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Deletes Zone from the database
    ''' </summary>
    ''' <param name="ZoneID"></param>
    ''' <remarks>It deletes ZoneID from the database </remarks>
    Public Function DeleteZone(ByVal ZoneID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ZoneID", ZoneID)}
        Try
            'Delete Zone data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteZone", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Updates Zone data in the database
    ''' </summary>
    ''' <param name="Zone"></param>
    ''' <remarks>It updates ZoneData</remarks>
    Public Function UpdateZone(ByVal Zone As ZoneData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ZoneName", Zone.ZoneName), _
        New SqlParameter("@ZoneID", Zone.ZoneID)}
        Try
            'Modify Zone data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateZone", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Returns a Zone
    ''' </summary>
    ''' <param name="ZoneID"></param>
    ''' <returns>ZoneData</returns>
    ''' <remarks>It takes ZoneID and returns ZoneData </remarks>
    Public Function FindZoneByID(ByVal ZoneID As Integer) As ZoneData
        Dim Zone As ZoneData = New ZoneData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@ZoneID", ZoneID)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindZoneByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Zone.ZoneID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Zone.ZoneName = row(1)
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
        'Return Zone Details.
        Return Zone
    End Function

    ''' <summary>
    ''' Returns all Zone
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllZone() As DataSet
        'Holds Zone Data
        Dim Zone As DataSet = New DataSet
        Try
            'Fetch all Knowledge Domain.
            Zone = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllZone")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched data
        Return Zone
    End Function
End Class
