''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Chima Kalu-orji
'' Date: 18-05-2009
'' This Class manages the Job Description.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Public Class JobDescriptionDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Create Job Description
    ''' </summary>
    ''' <param name="JobDescription"></param>
    ''' <remarks>This create Job Description </remarks>
    Public Function CreateJobDescription(ByVal JobDescription As JobDescriptionData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@PersonalInformationID", JobDescription.PersonalInformationID), _
        New SqlParameter("@YearOfService", JobDescription.YearOfService), _
        New SqlParameter("@CurrentJobTitle", JobDescription.CurrentJobTitle), _
        New SqlParameter("@GradeLevelID", JobDescription.GradeLevelID), _
        New SqlParameter("@TypeOfStaff", JobDescription.TypeOfStaff), _
        New SqlParameter("@FacultyID", JobDescription.FacultyID), _
        New SqlParameter("@DepartmentID", JobDescription.DepartmentID), _
        New SqlParameter("@InstitutionOfServiceID", JobDescription.InstitutionOfServiceID), _
        New SqlParameter("@SpecializationOfTeacher", JobDescription.SpecializationOfTeacher), _
        New SqlParameter("@CurrentCourse", JobDescription.CurrentCourse), _
        New SqlParameter("@CouldCourse", JobDescription.CouldCourse), _
        New SqlParameter("@CreatedByUID", JobDescription.CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(14).Direction = ParameterDirection.Output
        params(15).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateJobDescription", params)
            'Populate Error Code
            RetVal(0) = params(14).Value
            'Populate Error Hint
            RetVal(1) = params(15).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            'Populate Error Code
            RetVal(0) = params(14).Value
            'Populate Error Hint
            RetVal(1) = params(15).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Updating Job Description
    ''' </summary>
    ''' <param name="JobDescription"></param>
    ''' <remarks>This updating Job Description </remarks>
    Public Function UpdateJobDescription(ByVal JobDescription As JobDescriptionData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@JobDescriptionID", JobDescription.JobDescriptionID), _
        New SqlParameter("@PersonalInformationID", JobDescription.PersonalInformationID), _
        New SqlParameter("@YearOfService", JobDescription.YearOfService), _
        New SqlParameter("@CurrentJobTitle", JobDescription.CurrentJobTitle), _
        New SqlParameter("@GradeLevelID", JobDescription.GradeLevelID), _
        New SqlParameter("@TypeOfStaff", JobDescription.TypeOfStaff), _
        New SqlParameter("@FacultyID", JobDescription.FacultyID), _
        New SqlParameter("@DepartmentID", JobDescription.DepartmentID), _
        New SqlParameter("@InstitutionOfServiceID", JobDescription.InstitutionOfServiceID), _
        New SqlParameter("@SpecializationOfTeacher", JobDescription.SpecializationOfTeacher), _
        New SqlParameter("@CurrentCourse", JobDescription.CurrentCourse), _
        New SqlParameter("@CouldCourse", JobDescription.CouldCourse), _
        New SqlParameter("@CreatedByUID", JobDescription.CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(15).Direction = ParameterDirection.Output
        params(16).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UpdateJobDescription", params)
            'Populate Error Code
            RetVal(0) = params(15).Value
            'Populate Error Hint
            RetVal(1) = params(16).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            'Populate Error Code
            RetVal(0) = params(15).Value
            'Populate Error Hint
            RetVal(1) = params(16).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Returns a Job DescriptionID
    ''' </summary>
    ''' <param name="JobDescriptionID"></param>
    ''' <returns>JobDescriptionIDData</returns>
    ''' <remarks>It takes JobDescriptionID and returns JobDescriptionData </remarks>
    Public Function FindJobDescriptionByID(ByVal JobDescriptionID As Integer) As JobDescriptionData
        Dim JobDescription As JobDescriptionData = New JobDescriptionData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@JobDescriptionID", JobDescriptionID)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindJobDescriptionByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        JobDescription.JobDescriptionID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        JobDescription.YearOfService = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        JobDescription.CurrentJobTitle = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        JobDescription.GradeLevelID = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        JobDescription.TypeOfStaff = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        JobDescription.FacultyID = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        JobDescription.DepartmentID = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        JobDescription.InstitutionOfServiceID = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        JobDescription.SpecializationOfTeacher = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        JobDescription.CurrentCourse = row(9)
                    End If
                    If Not IsDBNull(row(10)) Then
                        JobDescription.CouldCourse = row(10)
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
        'Return JobDescription Details.
        Return JobDescription
    End Function
End Class
