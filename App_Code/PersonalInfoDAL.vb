''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Chima Kalu-orji
'' Date: 18-05-2009
'' This Class manages the student result.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class PersonalInfoDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Create Personal Information
    ''' </summary>
    ''' <param name="PersonalInformation"></param>
    ''' <remarks>This create Personal Information </remarks>
    Public Function CreatePersonalInformation(ByVal PersonalInformation As PersonalInfoData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", "", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@Surname", PersonalInformation.Surname), _
        New SqlParameter("@FirstName", PersonalInformation.FirstName), _
        New SqlParameter("@MiddleName", PersonalInformation.MiddleName), _
        New SqlParameter("@MaidenName", PersonalInformation.MaidenName), _
        New SqlParameter("@Gender", PersonalInformation.Gender), _
        New SqlParameter("@DateOfBirth", PersonalInformation.DateOfBirth), _
        New SqlParameter("@StateOfOriginID", PersonalInformation.StateOfOriginID), _
        New SqlParameter("@LGAID", PersonalInformation.LGAID), _
        New SqlParameter("@ZoneOfOriginID", PersonalInformation.ZoneOfOriginID), _
        New SqlParameter("@ReligionID", PersonalInformation.ReligionID), _
        New SqlParameter("@PhoneNumber", PersonalInformation.PhoneNumber), _
        New SqlParameter("@Email", PersonalInformation.Email), _
        New SqlParameter("@PermanentAddress", PersonalInformation.PermanentAddress), _
        New SqlParameter("@CreatedByUID", PersonalInformation.CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
        New SqlParameter("@PersonalInformationID", SqlDbType.Int, 4)}

        'Assigning value to the return value
        params(16).Direction = ParameterDirection.Output
        params(17).Direction = ParameterDirection.Output
        params(18).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreatePersonalInformation", params)
        'Returning the primary key
        RetVal(0) = params(16).Value
        'Populate Error Code
        RetVal(1) = params(17).Value
        'Populate Error Hint
        RetVal(2) = params(18).Value
        Return RetVal
        'Catch ex As Exception
        '    'Returning the primary key
        '    RetVal(0) = params(0).Value
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(17).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(18).Value
        '    Return RetVal
        'End Try
    End Function
    ''' <summary>
    ''' Updating Personal Information
    ''' </summary>
    ''' <param name="PersonalInformation"></param>
    ''' <remarks>This Updating Personal Information </remarks>
    Public Function UpdatePersonalInformation(ByVal PersonalInformation As PersonalInfoData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@PersonalInfo", PersonalInformation.PersonalInfoID), _
        New SqlParameter("@Surname", PersonalInformation.Surname), _
        New SqlParameter("@FirstName", PersonalInformation.FirstName), _
        New SqlParameter("@MiddleName", PersonalInformation.MiddleName), _
        New SqlParameter("@MaidenName", PersonalInformation.MaidenName), _
        New SqlParameter("@Gender", PersonalInformation.Gender), _
        New SqlParameter("@DateOfBirth", PersonalInformation.DateOfBirth), _
        New SqlParameter("@StateOfOriginID", PersonalInformation.StateOfOriginID), _
        New SqlParameter("@LGAID", PersonalInformation.LGAID), _
        New SqlParameter("@ZoneOfOriginID", PersonalInformation.ZoneOfOriginID), _
        New SqlParameter("@ReligionID", PersonalInformation.ReligionID), _
        New SqlParameter("@PhoneNumber", PersonalInformation.PhoneNumber), _
        New SqlParameter("@Email", PersonalInformation.Email), _
        New SqlParameter("@PermanentAddress", PersonalInformation.PermanentAddress), _
        New SqlParameter("@Status", PersonalInformation.Status), _
        New SqlParameter("@CreatedByUID", PersonalInformation.CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(18).Direction = ParameterDirection.Output
        params(19).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UpdatePersonalInformation", params)
            'Populate Error Code
            RetVal(0) = params(18).Value
            'Populate Error Hint
            RetVal(1) = params(19).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(18).Value
            'Populate Error Hint
            RetVal(1) = params(19).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Returns a Personal Information
    ''' </summary>
    ''' <param name="PersonalInformationID"></param>
    ''' <returns>PersonalInfoData</returns>
    ''' <remarks>It takes PersonalInformationID and returns PersonalInfoData </remarks>
    Public Function FindPersonalInformationByID(ByVal PersonalInformationID As Integer) As PersonalInfoData
        Dim PersonalInfo As PersonalInfoData = New PersonalInfoData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@PersonalInformationID", PersonalInformationID)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindPersonalInformationByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        PersonalInfo.PersonalInfoID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        PersonalInfo.Surname = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        PersonalInfo.FirstName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        PersonalInfo.MiddleName = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        PersonalInfo.MaidenName = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        PersonalInfo.Gender = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        PersonalInfo.DateOfBirth = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        PersonalInfo.StateOfOriginID = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        PersonalInfo.LGAID = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        PersonalInfo.ZoneOfOriginID = row(9)
                    End If
                    If Not IsDBNull(row(10)) Then
                        PersonalInfo.ReligionID = row(10)
                    End If
                    If Not IsDBNull(row(11)) Then
                        PersonalInfo.PhoneNumber = row(11)
                    End If
                    If Not IsDBNull(row(12)) Then
                        PersonalInfo.Email = row(12)
                    End If
                    If Not IsDBNull(row(13)) Then
                        PersonalInfo.PermanentAddress = row(13)
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
        Return PersonalInfo
    End Function

    ''' <summary>
    ''' Fetches all Admission Pending to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllStaffByDept(ByVal DeptID As Integer, ByVal SessionYear As String) As DataSet
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet
        Dim params() As SqlParameter = {New SqlParameter("@DeptID", DeptID), _
        New SqlParameter("@SessionYear", SessionYear)}
        'Try
        'Fetch all Admission Pending.
        AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStaffByDept", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    'Return Nothing
        'End Try
        'Return fetched AdmissionApplication data
        Return AdApp
    End Function
    ''' <summary>
    ''' Fetches all Admission Pending to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllStaff() As DataSet
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet

        'Try
        'Fetch all Admission Pending.
        AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStaff")
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    'Return Nothing
        'End Try
        'Return fetched AdmissionApplication data
        Return AdApp
    End Function
    ''' <summary>
    ''' Fetches all Admission Pending to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllStaffByLGA(ByVal LAGID As Integer) As DataSet
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet
        Dim params() As SqlParameter = {New SqlParameter("@LAGID", LAGID)}
        'Try
        'Fetch all Admission Pending.
        AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStaffByLGA", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    'Return Nothing
        'End Try
        'Return fetched AdmissionApplication data
        Return AdApp
    End Function
End Class
