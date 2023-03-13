Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Public Class PostUmeSetupDAL
    Inherits DataAccessBase
    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Creates an Post Ume Admission Setup
    ''' </summary>
    ''' <param name="AdApp"></param>
    ''' <returns>String</returns>
    ''' <remarks>It creates PostUmeSetupData using AdApp</remarks>
    Public Function CreatePostUmeAdmissionSetup(ByVal AdApp As PostUmeSetupData) As String()

        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
       {New SqlParameter("@CatchmentAreaCutOff", AdApp.CatchmentAreaCutOff), _
       New SqlParameter("@FacultyID", AdApp.FacultyID), _
       New SqlParameter("@DeptID", AdApp.DeptID), _
       New SqlParameter("@MeritScore", AdApp.MeritScore), _
       New SqlParameter("@LogTxnFlag", LogTxnFlag), _
       New SqlParameter("@LogErrorFlag", LogErrorFlag), _
       New SqlParameter("@retcode", SqlDbType.Int, 4), _
       New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
       New SqlParameter("@CreatedByUID", AdApp.CreatedByUID)}

        'Assigning value to the return value

        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output

        'Try
        'Create State data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreatePostUmeAdmissionSetup", params)
        ''Populate Error Code
        'RetVal(0) = params(5).Value
        ''Populate Error Hint
        'RetVal(1) = params(6).Value

        '  Return RetVal
        ' Catch ex As Exception
        'If error occurs, log it and return errorcode
        RetVal(0) = params(5).Value
        'Populate Error Hint
        RetVal(1) = params(6).Value

        Return RetVal
        ' End Try
    End Function

    ''' <summary>
    ''' Update Admission Application Data
    ''' </summary>
    ''' <param name="AdApp"></param>
    ''' <remarks>It updates the database using DepartmentData</remarks>
    Public Function UpdateUMEApplication(ByVal AdApp As PostUmeSetupData) As String()

        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CatchmentAreaCutOff", AdApp.CatchmentAreaCutOff), _
       New SqlParameter("@FacultyRideIn", AdApp.FacultyRideIn), _
       New SqlParameter("@MeritScore", AdApp.MeritScore), _
       New SqlParameter("@LogTxnFlag", LogTxnFlag), _
       New SqlParameter("@LogErrorFlag", LogErrorFlag), _
       New SqlParameter("@retcode", SqlDbType.Int, 4), _
       New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
       New SqlParameter("@CreatedByUID", AdApp.CreatedByUID), _
       New SqlParameter("@PostUmeAdmissionSetupID", AdApp.PostUmeAdmissionSetupID)}

        'Assigning value to the return value

        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output
        'Try
        'Modify Department data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UpdatePostUmeAdmissionSetup", params)
        'Populate Error Code
        RetVal(0) = params(5).Value
        'Populate Error Hint
        RetVal(1) = params(6).Value

        Return RetVal

        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(5).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(6).Value

        '    Return RetVal
        'End Try
    End Function

    ''' <summary>
    ''' Finds Admission Application by acknowledegement number
    ''' </summary>
    ''' <param name="PostUmeAdmissionSetupID"></param>
    ''' <returns>AdmissionApplicationData</returns>
    ''' <remarks>It takes AppAcknowledgeNo and returns AdmissionApplicationData </remarks>
    Public Function FindPostUmeAdmissionSetupbyID(ByVal PostUmeAdmissionSetupID As Integer) As PostUmeSetupData
        Dim AdApp As PostUmeSetupData = New PostUmeSetupData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@PostUmeAdmissionSetupID", PostUmeAdmissionSetupID)}
        Try
            'Fetch item based on AppAcknowledgeNo
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindPostUmeAdmissionSetupbyID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        AdApp.PostUmeAdmissionSetupID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        AdApp.MeritScore = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        AdApp.CatchmentAreaCutOff = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        AdApp.FacultyRideIn = row(3)
                    End If

                Next
                'Return application data.
                Return AdApp
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
    ''' Fetches all Post Ume Admission Setup to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllPostUmeAdmissionSetup() As DataSet
        'Holds Qualification Data
        Dim AdApp As DataSet = New DataSet
        'Try
        'Fetch all Qualifications.
        AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllPostUmeAdmissionSetup")
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched Qualification data
        Return AdApp
    End Function

    ''' <summary>
    ''' Deletes Post Ume Admission Setup from the database
    ''' </summary>
    ''' <param name="PostUmeAdmissionSetupID"></param>
    ''' <remarks>It deletes Post Ume Admission Setup record from the database </remarks>
    Public Function DeletePostUmeAdmissionSetup(ByVal PostUmeAdmissionSetupID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@PostUmeAdmissionSetupID", PostUmeAdmissionSetupID)}
        Try
            'Delete Lecturer data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeletePostUmeAdmissionSetup", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

End Class
