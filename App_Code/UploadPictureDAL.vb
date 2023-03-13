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

Public Class UploadPictureDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Upload Picture
    ''' </summary>
    ''' <param name="Upload"></param>
    ''' <remarks>This UploadPicture </remarks>
    Public Function UploadPicture(ByVal Upload As UploadPictureData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@PersonalInformationID", Upload.PersonalInformationID), _
        New SqlParameter("@UploadBigPicture", Upload.UploadBigPicture), _
        New SqlParameter("@UploadSmallPicture", Upload.UploadSmallPicture), _
        New SqlParameter("@CreatedByUID", Upload.CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(6).Direction = ParameterDirection.Output
        params(7).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadPicture", params)
            'Populate Error Code
            RetVal(0) = params(6).Value
            'Populate Error Hint
            RetVal(1) = params(7).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            'Populate Error Code
            RetVal(0) = params(6).Value
            'Populate Error Hint
            RetVal(1) = params(7).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Update Uploaded Picture
    ''' </summary>
    ''' <param name="Upload"></param>
    ''' <remarks>This UploadPicture </remarks>
    Public Function UpdateUploadedPicture(ByVal Upload As UploadPictureData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@PersonalInformationID", Upload.PersonalInformationID), _
        New SqlParameter("@PersonalInformationID", Upload.PersonalInformationID), _
        New SqlParameter("@UploadBigPicture", Upload.UploadBigPicture), _
        New SqlParameter("@UploadSmallPicture", Upload.UploadSmallPicture), _
        New SqlParameter("@CreatedByUID", Upload.CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(7).Direction = ParameterDirection.Output
        params(8).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UpdateUploadedPicture", params)
            'Populate Error Code
            RetVal(0) = params(7).Value
            'Populate Error Hint
            RetVal(1) = params(8).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            'Populate Error Code
            RetVal(0) = params(7).Value
            'Populate Error Hint
            RetVal(1) = params(8).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Returns a uploaded picture
    ''' </summary>
    ''' <param name="UploadPictureID"></param>
    ''' <returns>UploadPictureData</returns>
    ''' <remarks>It takes UploadPictureID and returns UploadPictureData </remarks>
    Public Function FindUploadedPictureByID(ByVal UploadPictureID As Integer) As UploadPictureData
        Dim UploadPicture As UploadPictureData = New UploadPictureData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@UploadPictureID", UploadPictureID)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindUploadedPictureByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        UploadPicture.UploadPictureID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        UploadPicture.UploadBigPicture = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        UploadPicture.UploadSmallPicture = row(2)
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
        Return UploadPicture
    End Function
End Class
