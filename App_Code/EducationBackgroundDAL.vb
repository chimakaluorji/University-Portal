''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Chima Kalu-orji
'' Date: 18-05-2009
'' This Class manages the Education background.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class EducationBackgroundDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Create Education Background
    ''' </summary>
    ''' <param name="EducationBackground"></param>
    ''' <remarks>This create Education Background </remarks>
    Public Function CreateEducationBackground(ByVal EducationBackground As EducationBackgroundData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@PersonalInformationID", EducationBackground.PersonalInformationID), _
        New SqlParameter("@CourseMajored", EducationBackground.CourseMajored), _
        New SqlParameter("@SchoolAttend", EducationBackground.SchoolAttend), _
        New SqlParameter("@QualificationID", EducationBackground.QualificationID), _
        New SqlParameter("@BeginYear", EducationBackground.BeginYear), _
        New SqlParameter("@EndYear", EducationBackground.EndYear), _
        New SqlParameter("@CreatedByUID", EducationBackground.CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(9).Direction = ParameterDirection.Output
        params(10).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateEducationBackground", params)
        'Populate Error Code
        RetVal(0) = params(9).Value
        'Populate Error Hint
        RetVal(1) = params(10).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    'Populate Error Code
        '    RetVal(0) = params(9).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(10).Value
        '    Return RetVal
        'End Try
    End Function
    ''' <summary>
    ''' Update Education Background
    ''' </summary>
    ''' <param name="EducationBackground"></param>
    ''' <remarks>This Update Education Background </remarks>
    Public Function UpdateEducationBackground(ByVal EducationBackground As EducationBackgroundData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@EducationBackgroundID", EducationBackground.EducationBackgroundID), _
        New SqlParameter("@PersonalInformationID", EducationBackground.PersonalInformationID), _
        New SqlParameter("@CourseMajored", EducationBackground.CourseMajored), _
        New SqlParameter("@SchoolAttend", EducationBackground.SchoolAttend), _
        New SqlParameter("@QualificationID", EducationBackground.QualificationID), _
        New SqlParameter("@BeginYear", EducationBackground.BeginYear), _
        New SqlParameter("@EndYear", EducationBackground.EndYear), _
        New SqlParameter("@CreatedByUID", EducationBackground.CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(10).Direction = ParameterDirection.Output
        params(11).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UpdateEducationBackground", params)
            'Populate Error Code
            RetVal(0) = params(10).Value
            'Populate Error Hint
            RetVal(1) = params(11).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            'Populate Error Code
            RetVal(0) = params(10).Value
            'Populate Error Hint
            RetVal(1) = params(11).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Returns a Education Background
    ''' </summary>
    ''' <param name="EducationBackgroundID"></param>
    ''' <returns>EducationBackgroundData</returns>
    ''' <remarks>It takes EducationBackgroundID and returns EducationBackgroundData </remarks>
    Public Function FindEducationBackgroundByID(ByVal EducationBackgroundID As Integer) As EducationBackgroundData
        Dim EducationBackground As EducationBackgroundData = New EducationBackgroundData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@EducationBackgroundID", EducationBackgroundID)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindEducationBackgroundByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        EducationBackground.EducationBackgroundID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        EducationBackground.CourseMajored = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        EducationBackground.SchoolAttend = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        EducationBackground.QualificationID = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        EducationBackground.BeginYear = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        EducationBackground.EndYear = row(5)
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
        Return EducationBackground
    End Function
End Class
