''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Nsi Idika
'' Date: 24-01-2009
'' This Class manages Academic Qualification.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class QualificationDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Creates a Qualification
    ''' </summary>
    ''' <param name="qualif"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates Academic Qualification</remarks>
    Public Function CreateQualification(ByVal qualif As QualificationData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@QualificationName", qualif.QualificationName), _
        New SqlParameter("@ShortName", qualif.ShortName)}
        Try
            'Create Qualification data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateQualification", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes Qualification from the database
    ''' </summary>
    ''' <param name="QualifID"></param>
    ''' <remarks>It deletes Academic Qualification record from the database </remarks>
    Public Function DeleteQualification(ByVal QualifID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@QualificationID", QualifID)}
        Try
            'Delete Qualification data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteQualification", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Updates Qualification Data
    ''' </summary>
    ''' <param name="Qualif"></param>
    ''' <remarks>It updates the database using DepartmentData</remarks>
    Public Function UpdateQualification(ByVal Qualif As QualificationData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@QualificationName", Qualif.QualificationName), _
        New SqlParameter("@ShortName", Qualif.ShortName), _
        New SqlParameter("@QualificationID", Qualif.QualificationID)}
        Try
            'Modify Qualification data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateQualification", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Finds Qualification by ID
    ''' </summary>
    ''' <param name="QualifID"></param>
    ''' <returns>QualificationData</returns>
    ''' <remarks>It takes QualifID and returns QualificationData </remarks>
    Public Function FindQualificationById(ByVal QualifID As Integer) As QualificationData
        Dim Qualif As QualificationData = New QualificationData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@QualificationID", QualifID)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindQualificationByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
           
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Qualif.QualificationID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Qualif.QualificationName = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        Qualif.ShortName = row(2)
                    End If

                Next
                'Return Qualification data.
                Return Qualif
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
    ''' Fetches all Qualifications to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllQualifications() As DataSet
        'Holds Qualification Data
        Dim Qualif As DataSet = New DataSet
        Try
            'Fetch all Qualifications.
            Qualif = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllQualifications")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Qualification data
        Return Qualif
    End Function

    ''' <summary>
    ''' Finds Qualification by Shortname
    ''' </summary>
    ''' <param name="Shortname"></param>
    ''' <returns>QualificationData</returns>
    ''' <remarks>It takes Shortname and returns QualificationData </remarks>
    Public Function FindQualificationByShortname(ByVal Shortname As String) As QualificationData
        Dim data As QualificationData = New QualificationData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@ShortName", Shortname)}
        Try
            'Fetch all item based on department name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindQualificationByShortname", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                'QualificationID,
                'QualificationName,
                '                Shortname
                For Each row As DataRow In dt.Rows
                    data.QualificationID = row(0)
                    data.QualificationName = row(1)
                    If Not IsDBNull(row(2)) Then
                        data.ShortName = row(2)
                    End If
                    
                Next
                Return data
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
        'Holds Qualification Data
        Dim Qualif As DataSet = New DataSet
        Try
            'Fetch all Qualifications.
            Qualif = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllAdmissionProgramme")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Qualification data
        Return Qualif
    End Function

    ''' <summary>
    ''' Creates a Admission Programme
    ''' </summary>
    ''' <param name="qualif"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates Academic Qualification</remarks>
    Public Function CreateAdmissionProgramme(ByVal qualif As QualificationData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ProgrammeName", qualif.ProgrammeName)}
        Try
            'Create Qualification data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateAdmissionProgramme", params)
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
    ''' <remarks>It deletes Academic Qualification record from the database </remarks>
    Public Function DeleteAdmissionProgramme(ByVal AdmissionProgrammeID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@AdmissionProgrammeID", AdmissionProgrammeID)}
        Try
            'Delete Qualification data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteAdmissionProgramme", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Update Admission Programme Data
    ''' </summary>
    ''' <param name="Qualif"></param>
    ''' <remarks>It updates the database using DepartmentData</remarks>
    Public Function UpdateAdmissionProgramme(ByVal Qualif As QualificationData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@AdmissionProgrammeID", Qualif.QualificationName), _
        New SqlParameter("@ProgrammeName", Qualif.ShortName)}
        Try
            'Modify Qualification data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateAdmissionProgramme", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Creates a ModeOfAdmission
    ''' </summary>
    ''' <param name="Admission"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates ModeOfAdmission</remarks>
    Public Function CreateModeOfAdmission(ByVal Admission As QualificationData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@AdmissionMode", Admission.ModeOfAdmission)}
        Try
            'Create ModeOfAdmission data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateModeOfAdmission", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes AdmissionMode from the database
    ''' </summary>
    ''' <param name="AdmissionModeID"></param>
    ''' <remarks>It deletes AdmissionMode record from the database </remarks>
    Public Function DeleteAdmissionMode(ByVal AdmissionModeID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@AdmissionModeID", AdmissionModeID)}
        'Try
        'Delete AdmissionModeID data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteAdmissionMode", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function

    ''' <summary>
    ''' Fetches all AdmissionMode  to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllAdmissionMode() As DataSet
        'Holds AdmissionMode Data
        Dim AdmissionMode As DataSet = New DataSet
        Try
            'Fetch all AdmissionMode.
            AdmissionMode = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllAdmissionMode")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched AdmissionMode data
        Return AdmissionMode
    End Function
    ''' <summary>
    ''' Finds AdmissionMode by ID
    ''' </summary>
    ''' <param name="AdmissionModeID"></param>
    ''' <returns>QualificationData</returns>
    ''' <remarks>It takes AdmissionMode and returns QualificationData </remarks>
    Public Function FindAdmissionModeByID(ByVal AdmissionModeID As Integer) As QualificationData
        Dim AdmissionMode As QualificationData = New QualificationData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@AdmissionModeID", AdmissionModeID)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAdmissionModeByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        AdmissionMode.ModeOfAdmissionID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        AdmissionMode.ModeOfAdmission = row(1)
                    End If

                Next
                'Return AdmissionMode data.
                Return AdmissionMode
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
    ''' Update AdmissionMode Data
    ''' </summary>
    ''' <param name="AdmissionMode"></param>
    ''' <remarks>It updates the database using QualificationData</remarks>
    Public Function UpdateAdmissionMode(ByVal AdmissionMode As QualificationData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@AdmissionModeID", AdmissionMode.ModeOfAdmissionID), _
        New SqlParameter("@AdmissionMode", AdmissionMode.ModeOfAdmission)}
        Try
            'Modify AdmissionMode data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateAdmissionMode", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
End Class
