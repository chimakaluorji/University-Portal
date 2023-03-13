
''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Oyiri Uka
'' Date: 19-03-2009
'' This Class manages Application Programmes.
''''''''''''''''''''''''''''''''''''''''''''''''''

Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class ApplicationProgrammeDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Creates a Application Programme
    ''' </summary>
    ''' <param name="AppProg"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates ApplicationProgrammeData using AppProg</remarks>
    Public Function CreateAdmisionProgramme(ByVal AppProg As ApplicationProgrammeData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ProgrammeName", AppProg.ProgrammeName)}
        Try
            'Create Department data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateAdmisionProgramme", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes Admission Programme from the database
    ''' </summary>
    ''' <param name="AdmissionProgrammeID"></param>
    ''' <remarks>It deletes Admission Programme record from the database </remarks>
    Public Function DeleteAdmissionProgramme(ByVal AdmissionProgrammeID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@AdmissionProgrammeID", AdmissionProgrammeID)}
        Try
            'Delete Department data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteAdmissionProgramme", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Updates Admission Programme Data
    ''' </summary>
    ''' <param name="AppProg"></param>
    ''' <remarks>It updates the database using ApplicationProgrammeData</remarks>
    Public Function UpdateAdmissionProgramme(ByVal AppProg As ApplicationProgrammeData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@AdmissionProgrammeID", AppProg.AdmissionProgrammeID), _
        New SqlParameter("@ProgrammeName", AppProg.ProgrammeName)}
        Try
            'Modify Department data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateAdmissionProgramme", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Finds Admission Programme by AdmissionProgrammeID
    ''' </summary>
    ''' <param name="AdmissionProgrammeID"></param>
    ''' <returns>ApplicationProgrammeData</returns>
    ''' <remarks>It takes AdmissionProgrammeID and returns ApplicationProgrammeData </remarks>
    Public Function GetAdmissionProgrammeByID(ByVal AdmissionProgrammeID As Integer) As ApplicationProgrammeData
        Dim AppProg As ApplicationProgrammeData = New ApplicationProgrammeData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@AdmissionProgrammeID", AdmissionProgrammeID)}
        Try
            'Fetch item based on AdmissionProgrammeID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "GetAdmissionProgrammeByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        AppProg.AdmissionProgrammeID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        AppProg.ProgrammeName = row(1)
                    End If
                    
                Next
                'Return AdmissionProgramme data.
                Return AppProg
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
    ''' Fetches all Admission Programme to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllAdmissionProgramme() As DataSet
        'Holds Admission Programme Data
        Dim AppProg As DataSet = New DataSet
        Try
            'Fetch all Admission Programme.
            AppProg = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllAdmissionProgramme")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Admission Programme data
        Return AppProg
    End Function

    
End Class
