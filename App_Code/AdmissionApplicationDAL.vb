''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Oyiri Uka
'' Date: 04-03-2009
'' This Class manages Admission Applications.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Public Class AdmissionApplicationDAL
    Inherits DataAccessBase
    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    Public Function AppAcknowledgeNo(ByVal MothersMaidenName As String, ByVal DateofBirth As String, ByVal LGAID As String, ByVal FirstName As String, ByVal Surname As String) As String
        Dim StrAscVal As Integer
        Dim InputLength As Integer = 0
        'Remove white space and merge the input string
        Dim CatenateInput As String = Trim(MothersMaidenName) & Trim(DateofBirth) & Trim(LGAID) & Trim(FirstName) & Trim(Surname)
        'Get the length of the input string
        InputLength = CatenateInput.Length
        If InputLength > 1 Then
            Dim InputArray() As Char = CatenateInput.ToCharArray
            For i As Integer = 0 To InputArray.Length - 1
                StrAscVal = StrAscVal + (Asc(InputArray(i)) * i)
            Next
        End If
        'Return StrAscVal * InputLength
        Return StrAscVal 'AdmissionYear.Substring(0, 4) & "/" & StrAscVal.ToString
    End Function
    ''' <summary>
    ''' Creates an Admission Application
    ''' </summary>
    ''' <param name="AdApp"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates CountryStateLGAData using State</remarks>
    Public Function CreateAdmissionApplication(ByVal AdApp As AdmissionApplicationData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
       {New SqlParameter("@AppAcknowledgeNo", AdApp.AppAcknowledgeNo), _
       New SqlParameter("@Surname", AdApp.Surname), _
       New SqlParameter("@FirstName", AdApp.FirstName), _
       New SqlParameter("@MiddleName", AdApp.MiddleName), _
       New SqlParameter("@FacultyID", AdApp.FacultyID), _
       New SqlParameter("@DeptID", AdApp.DeptID), _
       New SqlParameter("@QualifID", AdApp.QualifID), _
       New SqlParameter("@FirstChoice", AdApp.FirstChoice), _
       New SqlParameter("@SecondChoice", AdApp.SecondChoice), _
       New SqlParameter("@JAMBRegNo", AdApp.JAMBRegNo), _
       New SqlParameter("@DateofBirth", AdApp.DateofBirth), _
       New SqlParameter("@Gender", AdApp.Gender), _
       New SqlParameter("@MaritalStatus", AdApp.MaritalStatus), _
       New SqlParameter("@Address", AdApp.Address), _
       New SqlParameter("@Email", AdApp.Email), _
       New SqlParameter("@PhoneNo", AdApp.PhoneNo), _
       New SqlParameter("@CountryID", AdApp.CountryID), _
       New SqlParameter("@StateID", AdApp.StateID), _
       New SqlParameter("@LGAID", AdApp.LGAID), _
       New SqlParameter("@PlaceOfWork", AdApp.PlaceOfWork), _
       New SqlParameter("@Religion", AdApp.Religion), _
       New SqlParameter("@NextOfKin", AdApp.NextOfKin), _
       New SqlParameter("@NextofKinAddress", AdApp.NextofKinAddress), _
       New SqlParameter("@SponsorName", AdApp.SponsorName), _
       New SqlParameter("@SponsorOccupation", AdApp.SponsorOccupation), _
       New SqlParameter("@SponsorAddress", AdApp.SponsorAddress), _
       New SqlParameter("@SponsorPhone", AdApp.SponsorPhone), _
       New SqlParameter("@MothersMaidenName", AdApp.MothersMaidenName)}
        Try
            'Create State data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateAdmissionApplication", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Creates an Admission Application
    ''' </summary>
    ''' <param name="AdApp"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates CountryStateLGAData using State</remarks>
    Public Function CreateAdmissionApplicationPerm(ByVal AdApp As AdmissionApplicationData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
       {New SqlParameter("@AppAcknowledgeNo", AdApp.AppAcknowledgeNo), _
       New SqlParameter("@Surname", AdApp.Surname), _
       New SqlParameter("@FirstName", AdApp.FirstName), _
       New SqlParameter("@MiddleName", AdApp.MiddleName), _
       New SqlParameter("@FacultyID", AdApp.FacultyID), _
       New SqlParameter("@DeptID", AdApp.DeptID), _
       New SqlParameter("@QualifID", AdApp.QualifID), _
       New SqlParameter("@FirstChoice", AdApp.FirstChoice), _
       New SqlParameter("@SecondChoice", AdApp.SecondChoice), _
       New SqlParameter("@JAMBRegNo", AdApp.JAMBRegNo), _
       New SqlParameter("@DateofBirth", AdApp.DateofBirth), _
       New SqlParameter("@Gender", AdApp.Gender), _
       New SqlParameter("@MaritalStatus", AdApp.MaritalStatus), _
       New SqlParameter("@Address", AdApp.Address), _
       New SqlParameter("@Email", AdApp.Email), _
       New SqlParameter("@PhoneNo", AdApp.PhoneNo), _
       New SqlParameter("@CountryID", AdApp.CountryID), _
       New SqlParameter("@StateID", AdApp.StateID), _
       New SqlParameter("@LGAID", AdApp.LGAID), _
       New SqlParameter("@PlaceOfWork", AdApp.PlaceOfWork), _
       New SqlParameter("@Religion", AdApp.Religion), _
       New SqlParameter("@NextOfKin", AdApp.NextOfKin), _
       New SqlParameter("@NextofKinAddress", AdApp.NextofKinAddress), _
       New SqlParameter("@SponsorName", AdApp.SponsorName), _
       New SqlParameter("@SponsorOccupation", AdApp.SponsorOccupation), _
       New SqlParameter("@SponsorAddress", AdApp.SponsorAddress), _
       New SqlParameter("@SponsorPhone", AdApp.SponsorPhone), _
       New SqlParameter("@MothersMaidenName", AdApp.MothersMaidenName)}
        Try
            'Create State data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateAdmissionApplicationPerm", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Update Admission Application Data
    ''' </summary>
    ''' <param name="AdApp"></param>
    ''' <remarks>It updates the database using DepartmentData</remarks>
    Public Function UpdateAdmissionApplication(ByVal AdApp As AdmissionApplicationData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@Surname", AdApp.Surname), _
       New SqlParameter("@FirstName", AdApp.FirstName), _
       New SqlParameter("@MiddleName", AdApp.MiddleName), _
       New SqlParameter("@FacultyID", AdApp.FacultyID), _
       New SqlParameter("@DeptID", AdApp.DeptID), _
       New SqlParameter("@FirstChoice", AdApp.FirstChoice), _
       New SqlParameter("@SecondChoice", AdApp.SecondChoice), _
       New SqlParameter("@JAMBRegNo", AdApp.JAMBRegNo), _
       New SqlParameter("@DateofBirth", AdApp.DateofBirth), _
       New SqlParameter("@Gender", AdApp.Gender), _
       New SqlParameter("@MaritalStatus", AdApp.MaritalStatus), _
       New SqlParameter("@Address", AdApp.Address), _
       New SqlParameter("@Email", AdApp.Email), _
       New SqlParameter("@PhoneNo", AdApp.PhoneNo), _
       New SqlParameter("@CountryID", AdApp.CountryID), _
       New SqlParameter("@StateID", AdApp.StateID), _
       New SqlParameter("@LGAID", AdApp.LGAID), _
       New SqlParameter("@PlaceOfWork", AdApp.PlaceOfWork), _
       New SqlParameter("@Religion", AdApp.Religion), _
       New SqlParameter("@NextOfKin", AdApp.NextOfKin), _
       New SqlParameter("@NextofKinAddress", AdApp.NextofKinAddress), _
       New SqlParameter("@SponsorName", AdApp.SponsorName), _
       New SqlParameter("@SponsorOccupation", AdApp.SponsorOccupation), _
       New SqlParameter("@SponsorAddress", AdApp.SponsorAddress), _
       New SqlParameter("@SponsorPhone", AdApp.SponsorPhone), _
       New SqlParameter("@MothersMaidenName", AdApp.MothersMaidenName), _
       New SqlParameter("@AppAcknowledgeNo", AdApp.AppAcknowledgeNo)}
        Try
            'Modify Department data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateAdmissionApplication", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function

    ''' <summary>
    ''' Finds Admission Application by acknowledegement number
    ''' </summary>
    ''' <param name="AdmissionApplicationID"></param>
    ''' <returns>AdmissionApplicationData</returns>
    ''' <remarks>It takes AppAcknowledgeNo and returns AdmissionApplicationData </remarks>
    Public Function FindApplicationbyAckNo(ByVal AdmissionApplicationID As Integer) As AdmissionApplicationData
        Dim AdApp As AdmissionApplicationData = New AdmissionApplicationData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@AdmissionApplicationID", AdmissionApplicationID)}
        Try
            'Fetch item based on AppAcknowledgeNo
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindApplicationbyAckNo", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        AdApp.AppAcknowledgeNo = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        AdApp.Surname = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        AdApp.FirstName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        AdApp.MiddleName = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        AdApp.FacultyID = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        AdApp.DeptID = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        AdApp.QualifID = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        AdApp.FirstChoice = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        AdApp.SecondChoice = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        AdApp.JAMBRegNo = row(9)
                    End If
                    If Not IsDBNull(row(10)) Then
                        AdApp.DateofBirth = row(10)
                    End If
                    If Not IsDBNull(row(11)) Then
                        AdApp.Gender = row(11)
                    End If
                    If Not IsDBNull(row(12)) Then
                        AdApp.MaritalStatus = row(12)
                    End If
                    If Not IsDBNull(row(13)) Then
                        AdApp.Address = row(13)
                    End If
                    If Not IsDBNull(row(14)) Then
                        AdApp.Email = row(14)
                    End If
                    If Not IsDBNull(row(15)) Then
                        AdApp.PhoneNo = row(15)
                    End If
                    If Not IsDBNull(row(16)) Then
                        AdApp.CountryID = row(16)
                    End If
                    If Not IsDBNull(row(17)) Then
                        AdApp.StateID = row(17)
                    End If
                    If Not IsDBNull(row(18)) Then
                        AdApp.LGAID = row(18)
                    End If
                    If Not IsDBNull(row(19)) Then
                        AdApp.PlaceOfWork = row(19)
                    End If
                    If Not IsDBNull(row(20)) Then
                        AdApp.Religion = row(20)
                    End If
                    If Not IsDBNull(row(21)) Then
                        AdApp.NextOfKin = row(21)
                    End If
                    If Not IsDBNull(row(22)) Then
                        AdApp.NextofKinAddress = row(22)
                    End If
                    If Not IsDBNull(row(23)) Then
                        AdApp.SponsorName = row(23)
                    End If
                    If Not IsDBNull(row(24)) Then
                        AdApp.SponsorOccupation = row(24)
                    End If
                    If Not IsDBNull(row(25)) Then
                        AdApp.SponsorAddress = row(25)
                    End If
                    If Not IsDBNull(row(26)) Then
                        AdApp.SponsorPhone = row(26)
                    End If
                    If Not IsDBNull(row(27)) Then
                        AdApp.Status = row(27)
                    End If
                    If Not IsDBNull(row(28)) Then
                        AdApp.MothersMaidenName = row(28)
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
    ''' Fetches all Admission Pending to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllAdmissionPending() As DataSet
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet
        Try
            'Fetch all Admission Pending.
            AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllAdmissionPending")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched AdmissionApplication data
        Return AdApp
    End Function

    ''' <summary>
    ''' Fetches all Admission Pending to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllAdmissionPending(ByVal QualifID As Integer) As DataSet
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet
        Dim params() As SqlParameter = {New SqlParameter("@QualifID", QualifID)}
        Try
            'Fetch all Admission Pending.
            AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllAdmissionPending", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            'Return Nothing
        End Try
        'Return fetched AdmissionApplication data
        Return AdApp
    End Function

End Class

