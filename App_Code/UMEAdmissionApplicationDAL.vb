''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Oyiri Uka
'' Date: 08-05-2009
'' This Class manages UME Admission Applications.
''''''''''''''''''''''''''''''''''''''''''''''''''

Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Public Class UMEAdmissionApplicationDAL
    Inherits DataAccessBase
    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    Public Function AppAcknowledgeNo(ByVal MothersName As String, ByVal DateofBirth As String, ByVal LGAID As String, ByVal FirstName As String, ByVal Surname As String) As String
        Dim StrAscVal As Integer
        Dim InputLength As Integer = 0
        'Remove white space and merge the input string
        Dim CatenateInput As String = Trim(MothersName) & Trim(DateofBirth) & Trim(LGAID) & Trim(FirstName) & Trim(Surname)
        'Get the length of the input string
        InputLength = CatenateInput.Length
        If InputLength > 1 Then
            Dim InputArray() As Char = CatenateInput.ToCharArray
            For i As Integer = 0 To InputArray.Length - 1
                StrAscVal = StrAscVal + (Asc(InputArray(i)) * i)
            Next
        End If
        'Return StrAscVal * InputLength
        Return StrAscVal.ToString 'AdmissionYear.Substring(0, 4) & "/" & StrAscVal.ToString
    End Function
    ''' <summary>
    ''' Creates an UME Admission Application
    ''' </summary>
    ''' <param name="AdApp"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates UMEAdmissionApplicationData using AdApp</remarks>
    Public Function CreateUMEAdmissionApplication(ByVal AdApp As UMEAdmissionApplicationData) As String()

        Dim RetVal() As String = {"", "", ""}

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
       New SqlParameter("@PhotoUrl", AdApp.PhotoUrl), _
       New SqlParameter("@SSCECopyUrl", AdApp.SSCECopyUrl), _
       New SqlParameter("@SSCECopy2Url", AdApp.SSCECopy2Url), _
       New SqlParameter("@NextOfKin", AdApp.NextOfKin), _
       New SqlParameter("@NextofKinAddress", AdApp.NextofKinAddress), _
       New SqlParameter("@SponsorName", AdApp.SponsorName), _
       New SqlParameter("@SponsorOccupation", AdApp.SponsorOccupation), _
       New SqlParameter("@SponsorAddress", AdApp.SponsorAddress), _
       New SqlParameter("@UMEScore", AdApp.UMEScore), _
       New SqlParameter("@SponsorPhone", AdApp.SponsorPhone), _
       New SqlParameter("@MothersName", AdApp.MothersName), _
       New SqlParameter("@LogTxnFlag", LogTxnFlag), _
       New SqlParameter("@LogErrorFlag", LogErrorFlag), _
       New SqlParameter("@retcode", SqlDbType.Int, 4), _
       New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
       New SqlParameter("@SessionName", PostUMESessionName), _
       New SqlParameter("@MaidenName", AdApp.MaidenName), _
       New SqlParameter("@ParentsAddress", AdApp.ParentsAddress), _
       New SqlParameter("@ExtraCurricularActivity", AdApp.ExtraCurricularActivity), _
       New SqlParameter("@SpecialApplicant", AdApp.SpecialApplicant), _
       New SqlParameter("@FathersName", AdApp.FathersName), _
       New SqlParameter("@FathersAddress", AdApp.FathersAddress), _
       New SqlParameter("@FathersPhone", AdApp.FathersPhone), _
       New SqlParameter("@FathersEmail", AdApp.FathersEmail), _
       New SqlParameter("@MothersAddress", AdApp.MothersAddress), _
       New SqlParameter("@MothersPhone", AdApp.MothersPhone), _
       New SqlParameter("@MothersEmail", AdApp.MothersEmail), _
       New SqlParameter("@NextOfKinEmail", AdApp.NextOfKinEmail), _
       New SqlParameter("@HasWorkedBefore", AdApp.HasWorkedBefore), _
       New SqlParameter("@WorkDetails", AdApp.WorkDetails), _
       New SqlParameter("@SpouseName", AdApp.SpouseName), _
       New SqlParameter("@SpouseBirthDate", AdApp.SpouseBirthDate), _
       New SqlParameter("@HasWrittenJAMB", AdApp.HasWrittenJAMB), _
       New SqlParameter("@JAMBYear", AdApp.JAMBYear), _
       New SqlParameter("@JAMBExamNo", AdApp.JAMBExamNo), _
       New SqlParameter("@AppliedToOtherSchool", AdApp.AppliedToOtherSchool), _
       New SqlParameter("@OtherAppliedToSchoolName", AdApp.OtherAppliedToSchoolName), _
       New SqlParameter("@BeenAdmittedHereBefore", AdApp.BeenAdmittedHereBefore), _
       New SqlParameter("@PreviousAdmissionDetails", AdApp.PreviousAdmissionDetails), _
       New SqlParameter("@BeenConvictedBefore", AdApp.BeenConvictedBefore), _
       New SqlParameter("@WhoPays", AdApp.WhoPays), _
       New SqlParameter("@InstitutionAttended1", AdApp.InstitutionAttended1), _
       New SqlParameter("@InstitutionAttended1FromDate", AdApp.InstitutionAttended1FromDate), _
       New SqlParameter("@InstitutionAttended1ToDate", AdApp.InstitutionAttended1ToDate), _
       New SqlParameter("@InstitutionAttended1Qualif", AdApp.InstitutionAttended1Qualif), _
       New SqlParameter("@InstitutionAttended2", AdApp.InstitutionAttended2), _
       New SqlParameter("@InstitutionAttended2FromDate", AdApp.InstitutionAttended2FromDate), _
       New SqlParameter("@InstitutionAttended2ToDate", AdApp.InstitutionAttended2ToDate), _
       New SqlParameter("@InstitutionAttended2Qualif", AdApp.InstitutionAttended2Qualif), _
       New SqlParameter("@IntroducedBy", AdApp.IntroducedBy), _
       New SqlParameter("@PreferedInterviewCenter", AdApp.PreferedInterviewCenter), _
       New SqlParameter("@JAMBResultCopyUrl", AdApp.JAMBResultCopyUrl)}

        'Assigning value to the return value
        'params(0).Direction = ParameterDirection.Output
        params(32).Direction = ParameterDirection.Output
        params(33).Direction = ParameterDirection.Output

        Try
            'Create State data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateUMEApplication", params)
            'Populate Error Code
            RetVal(0) = params(32).Value
            'Populate Error Hint
            RetVal(1) = params(33).Value

        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(32).Value
            'Populate Error Hint
            RetVal(1) = params(33).Value
        End Try
        Return RetVal
    End Function

    ''' <summary>
    ''' Update Admission Application Data
    ''' </summary>
    ''' <param name="AdApp"></param>
    ''' <remarks>It updates the database using DepartmentData</remarks>
    Public Function UpdateUMEApplication(ByVal AdApp As UMEAdmissionApplicationData) As String()

        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}
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
       New SqlParameter("@MothersName", AdApp.MothersName), _
       New SqlParameter("@AppAcknowledgeNo", AdApp.AppAcknowledgeNo), _
       New SqlParameter("@UMEScore", AdApp.UMEScore), _
       New SqlParameter("@PhotoUrl", AdApp.PhotoUrl), _
       New SqlParameter("@SSCECopy2Url", AdApp.SSCECopy2Url), _
       New SqlParameter("@SSCECopyUrl", AdApp.SSCECopyUrl), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
       New SqlParameter("@retcode", SqlDbType.Int, 4), _
       New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
       New SqlParameter("@MaidenName", AdApp.MaidenName), _
       New SqlParameter("@ParentsAddress", AdApp.ParentsAddress), _
       New SqlParameter("@ExtraCurricularActivity", AdApp.ExtraCurricularActivity), _
       New SqlParameter("@SpecialApplicant", AdApp.SpecialApplicant), _
       New SqlParameter("@FathersName", AdApp.FathersName), _
       New SqlParameter("@FathersAddress", AdApp.FathersAddress), _
       New SqlParameter("@FathersPhone", AdApp.FathersPhone), _
       New SqlParameter("@FathersEmail", AdApp.FathersEmail), _
       New SqlParameter("@MothersAddress", AdApp.MothersAddress), _
       New SqlParameter("@MothersPhone", AdApp.MothersPhone), _
       New SqlParameter("@MothersEmail", AdApp.MothersEmail), _
       New SqlParameter("@NextOfKinEmail", AdApp.NextOfKinEmail), _
       New SqlParameter("@HasWorkedBefore", AdApp.HasWorkedBefore), _
       New SqlParameter("@WorkDetails", AdApp.WorkDetails), _
       New SqlParameter("@SpouseName", AdApp.SpouseName), _
       New SqlParameter("@SpouseBirthDate", AdApp.SpouseBirthDate), _
       New SqlParameter("@HasWrittenJAMB", AdApp.HasWrittenJAMB), _
       New SqlParameter("@JAMBYear", AdApp.JAMBYear), _
       New SqlParameter("@JAMBExamNo", AdApp.JAMBExamNo), _
       New SqlParameter("@AppliedToOtherSchool", AdApp.AppliedToOtherSchool), _
       New SqlParameter("@OtherAppliedToSchoolName", AdApp.OtherAppliedToSchoolName), _
       New SqlParameter("@BeenAdmittedHereBefore", AdApp.BeenAdmittedHereBefore), _
       New SqlParameter("@PreviousAdmissionDetails", AdApp.PreviousAdmissionDetails), _
       New SqlParameter("@BeenConvictedBefore", AdApp.BeenConvictedBefore), _
       New SqlParameter("@WhoPays", AdApp.WhoPays), _
       New SqlParameter("@InstitutionAttended1", AdApp.InstitutionAttended1), _
       New SqlParameter("@InstitutionAttended1FromDate", AdApp.InstitutionAttended1FromDate), _
       New SqlParameter("@InstitutionAttended1ToDate", AdApp.InstitutionAttended1ToDate), _
       New SqlParameter("@InstitutionAttended1Qualif", AdApp.InstitutionAttended1Qualif), _
       New SqlParameter("@InstitutionAttended2", AdApp.InstitutionAttended2), _
       New SqlParameter("@InstitutionAttended2FromDate", AdApp.InstitutionAttended2FromDate), _
       New SqlParameter("@InstitutionAttended2ToDate", AdApp.InstitutionAttended2ToDate), _
       New SqlParameter("@InstitutionAttended2Qualif", AdApp.InstitutionAttended2Qualif), _
       New SqlParameter("@IntroducedBy", AdApp.IntroducedBy), _
       New SqlParameter("@PreferedInterviewCenter", AdApp.PreferedInterviewCenter)}

        'Assigning value to the return value

        params(33).Direction = ParameterDirection.Output
        params(34).Direction = ParameterDirection.Output
        Try
            'Modify Department data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateUMEApplication", params)
            'Populate Error Code
            RetVal(0) = params(33).Value
            'Populate Error Hint
            RetVal(1) = params(34).Value
            
            Return RetVal

        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(33).Value
            'Populate Error Hint
            RetVal(1) = params(34).Value
            
            Return RetVal
        End Try
    End Function

    ''' <summary>
    ''' Finds Admission Application by acknowledegement number
    ''' </summary>
    ''' <param name="AppAcknowledgeNo"></param>
    ''' <returns>AdmissionApplicationData</returns>
    ''' <remarks>It takes AppAcknowledgeNo and returns AdmissionApplicationData </remarks>
    Public Function FindUMEApplicationbyAckNo(ByVal AppAcknowledgeNo As String) As UMEAdmissionApplicationData
        Dim AdApp As UMEAdmissionApplicationData = New UMEAdmissionApplicationData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@AppAcknowledgeNo", AppAcknowledgeNo)}
        Try
            'Fetch item based on AppAcknowledgeNo
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindUMEApplicationbyAckNo", params)
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
                        AdApp.PhotoUrl = row(21)
                    End If
                    If Not IsDBNull(row(22)) Then
                        AdApp.SSCECopyUrl = row(22)
                    End If
                    If Not IsDBNull(row(23)) Then
                        AdApp.SSCECopy2Url = row(23)
                    End If
                    If Not IsDBNull(row(24)) Then
                        AdApp.NextOfKin = row(24)
                    End If
                    If Not IsDBNull(row(25)) Then
                        AdApp.NextofKinAddress = row(25)
                    End If
                    If Not IsDBNull(row(26)) Then
                        AdApp.SponsorName = row(26)
                    End If
                    If Not IsDBNull(row(27)) Then
                        AdApp.SponsorOccupation = row(27)
                    End If
                    If Not IsDBNull(row(28)) Then
                        AdApp.SponsorAddress = row(28)
                    End If
                    If Not IsDBNull(row(29)) Then
                        AdApp.SponsorPhone = row(29)
                    End If
                    If Not IsDBNull(row(30)) Then
                        AdApp.UMEScore = row(30)
                    End If
                    If Not IsDBNull(row(31)) Then
                        AdApp.PostUMEScore = row(31)
                    End If
                    If Not IsDBNull(row(32)) Then
                        AdApp.MothersName = row(32)
                    End If
                    If Not IsDBNull(row(33)) Then
                        AdApp.Status = row(33)
                    End If
                    If Not IsDBNull(row(34)) Then
                        AdApp.CreateDate = row(34)
                    End If
                    If Not IsDBNull(row(35)) Then
                        AdApp.MaidenName = row(35)
                    End If
                    If Not IsDBNull(row(36)) Then
                        AdApp.ParentsAddress = row(36)
                    End If
                    If Not IsDBNull(row(37)) Then
                        AdApp.ExtraCurricularActivity = row(37)
                    End If
                    If Not IsDBNull(row(38)) Then
                        AdApp.SpecialApplicant = row(38)
                    End If
                    If Not IsDBNull(row(39)) Then
                        AdApp.FathersName = row(39)
                    End If
                    If Not IsDBNull(row(40)) Then
                        AdApp.FathersAddress = row(40)
                    End If
                    If Not IsDBNull(row(41)) Then
                        AdApp.FathersPhone = row(41)
                    End If
                    If Not IsDBNull(row(42)) Then
                        AdApp.FathersEmail = row(42)
                    End If
                    If Not IsDBNull(row(43)) Then
                        AdApp.MothersAddress = row(43)
                    End If
                    If Not IsDBNull(row(44)) Then
                        AdApp.MothersPhone = row(44)
                    End If
                    If Not IsDBNull(row(45)) Then
                        AdApp.MothersEmail = row(45)
                    End If
                    If Not IsDBNull(row(46)) Then
                        AdApp.NextOfKinEmail = row(46)
                    End If
                    If Not IsDBNull(row(47)) Then
                        AdApp.HasWorkedBefore = row(47)
                    End If
                    If Not IsDBNull(row(48)) Then
                        AdApp.WorkDetails = row(48)
                    End If
                    If Not IsDBNull(row(49)) Then
                        AdApp.SpouseName = row(49)
                    End If
                    If Not IsDBNull(row(50)) Then
                        AdApp.SpouseBirthDate = row(50)
                    End If
                    If Not IsDBNull(row(51)) Then
                        AdApp.HasWrittenJAMB = row(51)
                    End If
                    If Not IsDBNull(row(52)) Then
                        AdApp.JAMBYear = row(52)
                    End If
                    If Not IsDBNull(row(53)) Then
                        AdApp.JAMBExamNo = row(53)
                    End If
                    If Not IsDBNull(row(54)) Then
                        AdApp.AppliedToOtherSchool = row(54)
                    End If
                    If Not IsDBNull(row(55)) Then
                        AdApp.OtherAppliedToSchoolName = row(55)
                    End If
                    If Not IsDBNull(row(56)) Then
                        AdApp.BeenAdmittedHereBefore = row(56)
                    End If
                    If Not IsDBNull(row(57)) Then
                        AdApp.PreviousAdmissionDetails = row(57)
                    End If
                    If Not IsDBNull(row(58)) Then
                        AdApp.BeenConvictedBefore = row(58)
                    End If
                    If Not IsDBNull(row(59)) Then
                        AdApp.WhoPays = row(59)
                    End If
                    If Not IsDBNull(row(60)) Then
                        AdApp.InstitutionAttended1 = row(60)
                    End If
                    If Not IsDBNull(row(61)) Then
                        AdApp.InstitutionAttended1FromDate = row(61)
                    End If
                    If Not IsDBNull(row(62)) Then
                        AdApp.InstitutionAttended1ToDate = row(62)
                    End If
                    If Not IsDBNull(row(63)) Then
                        AdApp.InstitutionAttended1Qualif = row(63)
                    End If
                    If Not IsDBNull(row(64)) Then
                        AdApp.InstitutionAttended2 = row(64)
                    End If
                    If Not IsDBNull(row(65)) Then
                        AdApp.InstitutionAttended2FromDate = row(65)
                    End If
                    If Not IsDBNull(row(66)) Then
                        AdApp.InstitutionAttended2ToDate = row(66)
                    End If
                    If Not IsDBNull(row(67)) Then
                        AdApp.InstitutionAttended2Qualif = row(67)
                    End If
                    If Not IsDBNull(row(68)) Then
                        AdApp.IntroducedBy = row(68)
                    End If
                    If Not IsDBNull(row(69)) Then
                        AdApp.PreferedInterviewCenter = row(69)
                    End If
                    If Not IsDBNull(row(70)) Then
                        AdApp.JAMBResultCopyUrl = row(70)
                    End If
                    If Not IsDBNull(row(71)) Then
                        AdApp.BirthCertCopyUrl = row(71)
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
    Public Function FindAllUMEAdmissionPending() As DataSet
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet
        Try
            'Fetch all Admission Pending.
            AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllUMEAdmissionPending")
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
    Public Function FindAllUMEAdmissionPending(ByVal QualifID As Integer) As DataSet
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet
        Dim params() As SqlParameter = {New SqlParameter("@QualifID", QualifID)}
        Try
            'Fetch all Admission Pending.
            AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllUMEAdmissionPending", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            'Return Nothing
        End Try
        'Return fetched AdmissionApplication data
        Return AdApp
    End Function

    ''' <summary>
    ''' Saves Post UME Result
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function UploadPostUMEResult(ByVal data As UMEAdmissionApplicationData) As Integer
        'Holds Department Data

        Dim params() As SqlParameter = {New SqlParameter("@AppAcknowledgeNo", data.AppAcknowledgeNo), _
        New SqlParameter("@English", data.English), _
        New SqlParameter("@Maths", data.Maths), _
        New SqlParameter("@AreaOfStudy", data.AreaOfStudy), _
        New SqlParameter("@Average", data.Average), _
        New SqlParameter("@Aggregate", data.Aggregate), _
        New SqlParameter("@SessionName", data.SessionName), _
        New SqlParameter("@UploadByID", data.UploadByID)}
        Try
            'Persist data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UploadPostUMEResult", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return 0
        End Try
        
    End Function
    ''' <summary>
    ''' Fetches all Admission Pending to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindUMEScores(ByVal FirstChoice As String) As DataSet
        Dim params() As SqlParameter = {New SqlParameter("@FirstChoice", FirstChoice)}
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet

        Try
            'Fetch all Admission Pending.
            AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindUMEScores", params)
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
    Public Function FindHasWrittenJAMB(ByVal FirstChoice As String) As DataSet
        Dim params() As SqlParameter = {New SqlParameter("@FirstChoice", FirstChoice)}
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet

        Try
            'Fetch all Admission Pending.
            AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindHasWrittenJAMB", params)
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
    Public Function FindPostUMEScore(ByVal FirstChoice As String) As DataSet
        Dim params() As SqlParameter = {New SqlParameter("@FirstChoice", FirstChoice)}
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet

        Try
            'Fetch all Admission Pending.
            AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindPostUMEScore", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched AdmissionApplication data
        Return AdApp
    End Function
    
    ''' <summary>
    ''' Updates Upload UME Application Credentials
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks>It updates the database using UMEAdmissionApplicationData</remarks>
    Public Function UploadUMEAppCredentials(ByVal data As UMEAdmissionApplicationData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@AppAcknowledgeNo", data.AppAcknowledgeNo), _
        New SqlParameter("@JAMBResultCopyUrl", data.JAMBResultCopyUrl), _
        New SqlParameter("@PhotoUrl", data.PhotoUrl), _
        New SqlParameter("@SSCECopyUrl", data.SSCECopyUrl), _
        New SqlParameter("@SSCECopy2Url", data.SSCECopy2Url), _
        New SqlParameter("@BirthCertCopyUrl", data.BirthCertCopyUrl)}

        Try
            'Upload Credentials
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UploadCredentailForPostUMEApp", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    Public Function FindPostUMECandidateBySession(ByVal SessionName As String) As DataSet
        Dim candidates As DataSet = New DataSet
        Dim params() As SqlParameter = {New SqlParameter("@SessionName", SessionName)}
        Try
            candidates = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindPostUMECandBySession", params)
            Return candidates
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Updates PostUMEFee Data
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks>It updates the database using RetData</remarks>
    Public Function UpdatePostUMEFees(ByVal data As UMEAdmissionApplicationData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@PostUMEFeeID", data.PostUMEFeeID), _
        New SqlParameter("@PostUMEFeeAmount", data.PostUMEFeeAmount), _
        New SqlParameter("@CreatedByID", data.CreatedByID)}
        Try
            'Modify PostUMEFeeAmount data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdatePostUMEFee", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function

    ''' <summary>
    ''' Updates PostUMEFee Data
    ''' </summary>
    ''' <param name="PostUMEFeeID"></param>
    ''' <remarks>It updates the database using RetData</remarks>
    Public Function DeletePostUMEFees(ByVal PostUMEFeeID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@PostUMEFeeID", PostUMEFeeID)}
        Try
            'Modify PostUMEFeeAmount data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeletePostUMEFee", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function

    ''' <summary>
    ''' Find Post UME Fee By ID
    ''' </summary>
    ''' <returns>Decimal</returns>
    ''' <remarks>it returns a Decimal</remarks>
    Public Function FindPostUMEFeeByID(ByVal PostUMEFeeID As Integer) As UMEAdmissionApplicationData
        'Declaring the parameters
        Dim RetData As UMEAdmissionApplicationData = New UMEAdmissionApplicationData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Holds PostUMEFee Data
        Dim params() As SqlParameter = _
        {New SqlParameter("@PostUMEFeeID", PostUMEFeeID)}
        Try
            'Find Post UME Fee By ID.
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindPostUMEFeeByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        RetData.PostUMEFeeID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        RetData.PostUMEFeeAmount = row(1)
                    End If
                Next
                Return RetData
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
    ''' Creates a PostUME Fees
    ''' </summary>
    ''' <param name="PostUMEAmount"></param>
    '''  <param name="CreatedByID"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates PostUMEAmount using PostUMEAmount</remarks>
    Public Function CreatePostUMEAmount(ByVal PostUMEAmount As Decimal, ByVal CreatedByID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@PostUMEFeeAmount", PostUMEAmount), _
         New SqlParameter("@PostUMESession", PostUMESessionName), _
         New SqlParameter("@CreatedByID", CreatedByID)}
        Try
            'Create PostUMEAmount data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreatePostUMEAmount", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Saves Post UME Individual Result
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a string array</remarks>
    Public Function UploadPostUMEIndividualResult(ByVal data As UMEAdmissionApplicationData) As String()

        Dim RetVal() As String = {"", ""}
        'Holds Department Data
        Dim params() As SqlParameter = {New SqlParameter("@AppAcknowledgeNo", data.AppAcknowledgeNo), _
        New SqlParameter("@English", data.English), _
        New SqlParameter("@Maths", data.Maths), _
        New SqlParameter("@AreaOfStudy", data.AreaOfStudy), _
        New SqlParameter("@Average", data.Average), _
        New SqlParameter("@Aggregate", data.Aggregate), _
        New SqlParameter("@SessionName", data.SessionName), _
        New SqlParameter("@UploadByID", data.UploadByID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}
        params(10).Direction = ParameterDirection.Output
        params(11).Direction = ParameterDirection.Output
        Try
            'Persist data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadPostUMEIndividualResult", params)
            'Return Status Code
            RetVal(0) = params(10).Value
            'Return Error Hint
            RetVal(1) = params(11).Value
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            'Return Status Code
            RetVal(0) = params(10).Value
            'Return Error Hint
            RetVal(1) = params(11).Value
        End Try
        Return RetVal
    End Function

    Public Function FindRecommendedPostUMECandForAdm() As DataSet
        'declare object to hold fetched data
        Dim Retval As DataSet = New DataSet
        'declare data access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SessionName", PostUMESessionName)}
        Try
            'fetch recommended candidates
            Retval = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindRecommendedPostUMECandidates", params)
            'return fetched data
            Return Retval
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function


    ''' <summary>
    ''' Updates UME Admission Status
    ''' </summary>
    ''' <param name="acknowledgeNo"></param>
    ''' <remarks>It updates the database using UMEAdmissionApplicationData</remarks>
    Public Function RecommendPostCandForAdm(ByVal acknowledgeNo As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = {New SqlParameter("@AppAcknowledgeNo", acknowledgeNo)}
        Try
            'Modify Qualification data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "RecommendPostCandForAdm", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function

    ''' <summary>
    ''' Fetches all Admission Pending to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllUMEAdmission(ByVal SessionName As String) As DataSet
        Dim params() As SqlParameter = {New SqlParameter("@SessionName", SessionName)}
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet
        Try
            'Fetch all Admission Pending.
            AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllUMEAdmission", params)
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
    Public Function FindAllUMEAdmissionByDept(ByVal DeptID As Integer, ByVal SessionID As Integer) As DataSet
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet
        Dim params() As SqlParameter = {New SqlParameter("@DeptID", DeptID), _
        New SqlParameter("@SessionID", SessionID)}
        'Try
        'Fetch all Admission Pending.
        AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllUMEAdmissionByDept", params)
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
    Public Function FindAllNonApproveUMEAdmissionByDept(ByVal DeptID As Integer, ByVal SessionID As Integer) As DataSet
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet
        Dim params() As SqlParameter = {New SqlParameter("@DeptID", DeptID), _
        New SqlParameter("@SessionID", SessionID)}
        'Try
        'Fetch all Admission Pending.
        AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllNonApproveUMEAdmissionByDept", params)
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
    Public Function FindAllApproveUMEAdmissionByDept(ByVal DeptID As Integer, ByVal SessionID As Integer) As DataSet
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet
        Dim params() As SqlParameter = {New SqlParameter("@DeptID", DeptID), _
        New SqlParameter("@SessionID", SessionID)}
        'Try
        'Fetch all Admission Pending.
        AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllApproveUMEAdmissionByDept", params)
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
    Public Function FindAllUMEAdmission() As DataSet
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet
        
        'Try
        'Fetch all Admission Pending.
        AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllUMEAdmission")
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
    Public Function FindAllNonApproveUMEAdmission() As DataSet
        'Holds Department Data
        Dim AdApp As DataSet = New DataSet

        'Try
        'Fetch all Admission Pending.
        AdApp = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllNonApproveUMEAdmission")
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    'Return Nothing
        'End Try
        'Return fetched AdmissionApplication data
        Return AdApp
    End Function
    ''' <summary>
    ''' Approving application form
    ''' </summary>
    ''' <param name="student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function ApproveApplication(ByVal student As UMEAdmissionApplicationData, ByVal Status As String) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@ApplicationNumber", student.AppAcknowledgeNo), _
        New SqlParameter("@Status", Status), _
        New SqlParameter("@CreatedByUID", student.UploadByID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output

        ' Try
        'Create student's profile
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_ApprovePostUMERegistration", params)
        'Populate Error Code
        RetVal(0) = params(5).Value
        'Populate Error Hint
        RetVal(1) = params(6).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(37).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(38).Value
        '    Return RetVal
        ' End Try
    End Function
End Class

