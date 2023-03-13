''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Chima kalu-orji
'' Date: 01-02-2009
'' This Class manages Students Profile.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class StudentProfileDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub

    Public Function GenerateRegNumber(ByVal maiden As String, ByVal DOB As String, ByVal LGA As String, ByVal FirstName As String, ByVal Surname As String, ByVal AdmissionYear As String) As String
        Dim StrAscVal As Integer
        Dim InputLength As Integer = 0
        'Remove white space and merge the input string
        Dim CatenateInput As String = Trim(maiden) & Trim(DOB) & Trim(LGA) & Trim(FirstName) & Trim(Surname)
        'Get the length of the input string
        InputLength = CatenateInput.Length
        If InputLength > 1 Then
            Dim InputArray() As Char = CatenateInput.ToCharArray
            For i As Integer = 0 To InputArray.Length - 1
                StrAscVal = StrAscVal + (Asc(InputArray(i)) * i)
            Next
        End If
        'Return StrAscVal * InputLength
        Return AdmissionYear.Substring(0, 4) & "/" & StrAscVal.ToString
    End Function
    Public Function GenerateRegistrationNumber1(ByVal MiddleName As String, ByVal maiden As String, ByVal DOB As String, ByVal LGA As String, ByVal NextOfKin As String) As String
        Dim StrAscVal As Integer
        Dim InputLength As Integer = 0
        'Remove white space and merge the input string
        Dim CatenateInput As String = Trim(maiden) & Trim(DOB) & Trim(LGA) & Trim(MiddleName) & Trim(NextOfKin)
        'Get the length of the input string
        InputLength = CatenateInput.Length
        If InputLength > 1 Then
            Dim InputArray() As Char = CatenateInput.ToCharArray
            For i As Integer = 0 To InputArray.Length - 1
                StrAscVal = StrAscVal + (Asc(InputArray(i)) * i)
            Next
        End If
        'Return StrAscVal * InputLength
        Return StrAscVal.ToString
    End Function

    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CreateStudentProfile(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@Surname", Student.Surname), _
        New SqlParameter("@Firstname", Student.Firstname), _
        New SqlParameter("@MiddleName", Student.MiddleName), _
        New SqlParameter("@MothersMaidenName", Student.MothersMaidenName), _
        New SqlParameter("@DateOfBirth", Student.DateOfBirth), _
        New SqlParameter("@PermenentHomeAddr", Student.PermenentHomeAddr), _
        New SqlParameter("@PhoneNumber", Student.PhoneNumber), _
        New SqlParameter("@EmailAddress", Student.EmailAddress), _
        New SqlParameter("@CountryID", Student.CountryID), _
        New SqlParameter("@StateID", Student.StateID), _
        New SqlParameter("@LGAID", Student.LGAID), _
        New SqlParameter("@QualificationID", Student.QualificationID), _
        New SqlParameter("@ProgrammeID", Student.ProgrammeID), _
        New SqlParameter("@EntryLevelID", Student.EntryLevelID), _
        New SqlParameter("@SessionID", Student.AdmissionSessionID), _
        New SqlParameter("@Gender", Student.Gender), _
        New SqlParameter("@CourseDurationID", Student.CourseDurationID), _
        New SqlParameter("@NextOfKin", Student.NextOfKin), _
        New SqlParameter("@AdmissionModeID", Student.AdmissionModeID), _
        New SqlParameter("@TI2", Student.TI2), _
        New SqlParameter("@TI2FromDate", Student.TI2FromDate), _
        New SqlParameter("@TI2ToDate", Student.TI2ToDate), _
        New SqlParameter("@TI1", Student.TI1), _
        New SqlParameter("@TI1FromDate", Student.TI1FromDate), _
        New SqlParameter("@TI1ToDate", Student.TI1ToDate), _
        New SqlParameter("@PPI2", Student.PPI2), _
        New SqlParameter("@PPI2FromDate", Student.PPI2FromDate), _
        New SqlParameter("@PPI2ToDate", Student.PPI2ToDate), _
        New SqlParameter("@PPI1", Student.PPI1), _
        New SqlParameter("@PPI1FromDate", Student.PPI1FromDate), _
        New SqlParameter("@PPI1ToDate", Student.PPI1ToDate), _
        New SqlParameter("@PS2", Student.PS2), _
        New SqlParameter("@PS2FromDate", Student.PS2FromDate), _
        New SqlParameter("@PS2ToDate", Student.PPI2ToDate), _
        New SqlParameter("@PS1", Student.PS1), _
        New SqlParameter("@PS1FromDate", Student.PS1FromDate), _
        New SqlParameter("@PS1ToDate", Student.PS1ToDate), _
        New SqlParameter("@UMEScore", Student.UMEScore), _
        New SqlParameter("@ExamsBodyID", Student.ExamsBodyID), _
        New SqlParameter("@ExamsMonth", Student.ExamsMonth), _
        New SqlParameter("@ExamsYear", Student.ExamsYear), _
        New SqlParameter("@Sitting", Student.Sitting), _
        New SqlParameter("@OlevelSubject1", Student.OlevelSubject1), _
        New SqlParameter("@OlevelSubject2", Student.OlevelSubject2), _
        New SqlParameter("@OlevelSubject3", Student.OlevelSubject3), _
        New SqlParameter("@OlevelSubject4", Student.OlevelSubject4), _
        New SqlParameter("@OlevelSubject5", Student.OlevelSubject5), _
        New SqlParameter("@OlevelSubject6", Student.OlevelSubject6), _
        New SqlParameter("@OlevelSubject7", Student.OlevelSubject7), _
        New SqlParameter("@OlevelSubject8", Student.OlevelSubject8), _
        New SqlParameter("@OlevelSubject9", Student.OlevelSubject9), _
        New SqlParameter("@Grade1", Student.Grade1), _
        New SqlParameter("@Grade2", Student.Grade2), _
        New SqlParameter("@Grade3", Student.Grade3), _
        New SqlParameter("@Grade4", Student.Grade4), _
        New SqlParameter("@Grade5", Student.Grade5), _
        New SqlParameter("@Grade6", Student.Grade6), _
        New SqlParameter("@Grade7", Student.Grade7), _
        New SqlParameter("@Grade8", Student.Grade8), _
        New SqlParameter("@Grade9", Student.Grade9), _
        New SqlParameter("@SSCECopyUrl", Student.SSCECopyUrl), _
        New SqlParameter("@SSCECopy2Url", Student.SSCECopy2Url), _
        New SqlParameter("@JAMBResultCopyUrl", Student.JAMBResultCopyUrl), _
        New SqlParameter("@BirthCertCopyUrl", Student.BirthCertCopyUrl), _
        New SqlParameter("@PhotoUrl", Student.PhotoUrl), _
        New SqlParameter("@CreatedByRegNo", Student.CreatedByRegNo), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(69).Direction = ParameterDirection.Output
        params(70).Direction = ParameterDirection.Output

        Try
            'Create student's profile
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UpdateStudentProfiles", params)
            'Populate Error Code
            RetVal(0) = params(69).Value
            'Populate Error Hint
            RetVal(1) = params(70).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(4).Value
            'Populate Error Hint
            RetVal(1) = params(5).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Uploads student's credentials
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function UploadCredentials(ByVal Student As StudentProfileData) As Integer
        'Declare and initialize data access parameters
        
        Dim params() As SqlParameter = _
        {New SqlParameter("@StudentProfileID", Student.StudentProfileID), _
        New SqlParameter("@SSCECopyUrl", Student.SSCECopyUrl), _
        New SqlParameter("@SSCECopy2Url", Student.SSCECopy2Url), _
        New SqlParameter("@JAMBResultCopyUrl", Student.JAMBResultCopyUrl), _
        New SqlParameter("@BirthCertCopyUrl", Student.BirthCertCopyUrl), _
        New SqlParameter("@PhotoUrl", Student.PhotoUrl)}

        Try
            'upload student profile
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UploadCredentials", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Finds Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindStudentByRegNo(ByVal RegNumber As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStudentByRegNo", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows

                    studentData.RegNumber = row(0)
                    studentData.LevelID = row(1)
                    If Not IsDBNull(row(2)) Then
                        studentData.LevelName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        studentData.DeptID = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        studentData.DeptName = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        studentData.ProgrammeID = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        studentData.ProgrammeName = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        studentData.QualificationID = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        studentData.QualificationName = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        studentData.SessionID = row(9)
                    End If
                    If Not IsDBNull(row(10)) Then
                        studentData.SessionName = row(10)
                    End If
                    If Not IsDBNull(row(11)) Then
                        studentData.Firstname = row(11)
                    End If
                    If Not IsDBNull(row(12)) Then
                        studentData.MiddleName = row(12)
                    End If
                    If Not IsDBNull(row(13)) Then
                        studentData.Surname = row(13)
                    End If
                    If Not IsDBNull(row(14)) Then
                        studentData.Password = row(14)
                    End If
                    If Not IsDBNull(row(15)) Then
                        studentData.SaltKey = row(15)
                    End If
                   
                    If Not IsDBNull(row(16)) Then
                        studentData.CountryID = row(16)
                    End If
                    If Not IsDBNull(row(17)) Then
                        studentData.StateID = row(17)
                    End If
                    If Not IsDBNull(row(18)) Then
                        studentData.CountryName = row(18)
                    End If
                    If Not IsDBNull(row(19)) Then
                        studentData.StateName = row(19)
                    End If
                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)

        End Try
        Return studentData
    End Function

    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindAllStudentsByRegNumber(ByVal RegNumber As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllStudentsByRegNumber", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                studentData.RegNumber = row(0)
                studentData.Surname = row(1)
                If Not IsDBNull(row(2)) Then
                    studentData.Firstname = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    studentData.MiddleName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    studentData.MothersMaidenName = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    studentData.DateOfBirth = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    studentData.PermenentHomeAddr = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    studentData.PhoneNumber = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    studentData.EmailAddress = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    studentData.CountryID = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    studentData.CountryName = row(10)
                End If
                If Not IsDBNull(row(11)) Then
                    studentData.StateID = row(11)
                End If
                If Not IsDBNull(row(12)) Then
                    studentData.StateName = row(12)
                End If
                If Not IsDBNull(row(13)) Then
                    studentData.LGAID = row(13)
                End If
                If Not IsDBNull(row(14)) Then
                    studentData.LGAName = row(14)
                End If
               
                If Not IsDBNull(row(15)) Then
                    studentData.Gender = row(15)
                End If

                If Not IsDBNull(row(16)) Then
                    studentData.NextOfKin = row(16)
                End If
                If Not IsDBNull(row(17)) Then
                    studentData.TI2 = row(17)
                End If
                If Not IsDBNull(row(18)) Then
                    studentData.StringTI2FromDate = row(18)
                End If
                If Not IsDBNull(row(19)) Then
                    studentData.StringTI2ToDate = row(19)
                End If
                If Not IsDBNull(row(20)) Then
                    studentData.TI1 = row(20)
                End If
                If Not IsDBNull(row(21)) Then
                    studentData.StringTI1FromDate = row(21)
                End If
                If Not IsDBNull(row(22)) Then
                    studentData.StringTI1ToDate = row(22)
                End If
                If Not IsDBNull(row(23)) Then
                    studentData.PPI2 = row(23)
                End If
                If Not IsDBNull(row(24)) Then
                    studentData.StringPPI2FromDate = row(24)
                End If
                If Not IsDBNull(row(25)) Then
                    studentData.StringPPI2ToDate = row(25)
                End If
                If Not IsDBNull(row(26)) Then
                    studentData.PPI1 = row(26)
                End If
                If Not IsDBNull(row(27)) Then
                    studentData.StringPPI1FromDate = row(27)
                End If
                If Not IsDBNull(row(28)) Then
                    studentData.StringPPI1ToDate = row(28)
                End If
                If Not IsDBNull(row(29)) Then
                    studentData.PS2 = row(29)
                End If
                If Not IsDBNull(row(30)) Then
                    studentData.StringPS2FromDate = row(30)
                End If
                If Not IsDBNull(row(31)) Then
                    studentData.StringPS2ToDate = row(31)
                End If
                If Not IsDBNull(row(32)) Then
                    studentData.PS1 = row(32)
                End If
                If Not IsDBNull(row(33)) Then
                    studentData.StringPS1FromDate = row(33)
                End If
                If Not IsDBNull(row(34)) Then
                    studentData.StringPS1ToDate = row(34)
                End If
                If Not IsDBNull(row(35)) Then
                    studentData.LevelID = row(35)
                End If
                If Not IsDBNull(row(36)) Then
                    studentData.LevelName = row(36)
                End If
                If Not IsDBNull(row(37)) Then
                    studentData.SessionID = row(37)
                End If
                If Not IsDBNull(row(38)) Then
                    studentData.SessionName = row(38)
                End If
                If Not IsDBNull(row(39)) Then
                    studentData.SemesterID = row(39)
                End If
                If Not IsDBNull(row(40)) Then
                    studentData.Semester = row(40)
                End If
                If Not IsDBNull(row(41)) Then
                    studentData.PhotoUrl = row(41)
                End If
                If Not IsDBNull(row(42)) Then
                    studentData.CreateDate = row(42)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return studentData
    End Function
    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindAllApplicationByApplicationNumber(ByVal RegNumber As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllApplicationByApplicationNumber", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows

                    studentData.RegNumber = row(0)
                    studentData.Surname = row(1)
                    If Not IsDBNull(row(2)) Then
                        studentData.Firstname = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        studentData.MiddleName = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        studentData.MothersMaidenName = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        studentData.DateOfBirth = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        studentData.PermenentHomeAddr = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        studentData.PhoneNumber = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        studentData.EmailAddress = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        studentData.CountryID = row(9)
                    End If
                    If Not IsDBNull(row(10)) Then
                        studentData.CountryName = row(10)
                    End If
                    If Not IsDBNull(row(11)) Then
                        studentData.StateID = row(11)
                    End If
                    If Not IsDBNull(row(12)) Then
                        studentData.StateName = row(12)
                    End If
                    If Not IsDBNull(row(13)) Then
                        studentData.LGAID = row(13)
                    End If
                    If Not IsDBNull(row(14)) Then
                        studentData.LGAName = row(14)
                    End If
                    If Not IsDBNull(row(15)) Then
                        studentData.Gender = row(15)
                    End If

                    If Not IsDBNull(row(16)) Then
                        studentData.NextOfKin = row(16)
                    End If
                    If Not IsDBNull(row(17)) Then
                        studentData.TI2 = row(17)
                    End If
                    If Not IsDBNull(row(18)) Then
                        studentData.StringTI2FromDate = row(18)
                    End If
                    If Not IsDBNull(row(19)) Then
                        studentData.StringTI2ToDate = row(19)
                    End If
                    If Not IsDBNull(row(20)) Then
                        studentData.TI1 = row(20)
                    End If
                    If Not IsDBNull(row(21)) Then
                        studentData.StringTI1FromDate = row(21)
                    End If
                    If Not IsDBNull(row(22)) Then
                        studentData.StringTI1ToDate = row(22)
                    End If
                    If Not IsDBNull(row(23)) Then
                        studentData.PPI2 = row(23)
                    End If
                    If Not IsDBNull(row(24)) Then
                        studentData.StringPPI2FromDate = row(24)
                    End If
                    If Not IsDBNull(row(25)) Then
                        studentData.StringPPI2ToDate = row(25)
                    End If
                    If Not IsDBNull(row(26)) Then
                        studentData.PPI1 = row(26)
                    End If
                    If Not IsDBNull(row(27)) Then
                        studentData.StringPPI1FromDate = row(27)
                    End If
                    If Not IsDBNull(row(28)) Then
                        studentData.StringPPI1ToDate = row(28)
                    End If
                    If Not IsDBNull(row(29)) Then
                        studentData.PS2 = row(29)
                    End If
                    If Not IsDBNull(row(30)) Then
                        studentData.StringPS2FromDate = row(30)
                    End If
                    If Not IsDBNull(row(31)) Then
                        studentData.StringPS2ToDate = row(31)
                    End If
                    If Not IsDBNull(row(32)) Then
                        studentData.PS1 = row(32)
                    End If
                    If Not IsDBNull(row(33)) Then
                        studentData.StringPS1FromDate = row(33)
                    End If
                    If Not IsDBNull(row(34)) Then
                        studentData.StringPS1ToDate = row(34)
                    End If
                    If Not IsDBNull(row(35)) Then
                        studentData.FacultyID = row(35)
                    End If
                    If Not IsDBNull(row(36)) Then
                        studentData.FacultyName = row(36)
                    End If
                    If Not IsDBNull(row(37)) Then
                        studentData.DeptID = row(37)
                    End If
                    If Not IsDBNull(row(38)) Then
                        studentData.DeptName = row(38)
                    End If
                    If Not IsDBNull(row(39)) Then
                        studentData.SessionID = row(39)
                    End If
                    If Not IsDBNull(row(40)) Then
                        studentData.SessionName = row(40)
                    End If
                    If Not IsDBNull(row(41)) Then
                        studentData.PhotoUrl = row(41)
                    End If
                    If Not IsDBNull(row(42)) Then
                        studentData.CreateDate = row(42)
                    End If
                    If Not IsDBNull(row(42)) Then
                        studentData.Jamb = row(42)
                    End If
                    If Not IsDBNull(row(42)) Then
                        studentData.UMEScore = row(42)
                    End If

                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)

        End Try
        Return studentData
    End Function
    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="ApplicationNumberID"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindAllApplicationByApplicationNumberID(ByVal ApplicationNumberID As Integer) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@ApplicationNumberID", ApplicationNumberID)}

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllApplicationByApplicationNumberID", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows

                    studentData.RegNumber = row(0)
                    studentData.Surname = row(1)
                    If Not IsDBNull(row(2)) Then
                        studentData.Firstname = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        studentData.MiddleName = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        studentData.MothersMaidenName = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        studentData.DateOfBirth = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        studentData.PermenentHomeAddr = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        studentData.PhoneNumber = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        studentData.EmailAddress = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        studentData.CountryID = row(9)
                    End If
                    If Not IsDBNull(row(10)) Then
                        studentData.CountryName = row(10)
                    End If
                    If Not IsDBNull(row(11)) Then
                        studentData.StateID = row(11)
                    End If
                    If Not IsDBNull(row(12)) Then
                        studentData.StateName = row(12)
                    End If
                    If Not IsDBNull(row(13)) Then
                        studentData.LGAID = row(13)
                    End If
                    If Not IsDBNull(row(14)) Then
                        studentData.LGAName = row(14)
                    End If
                    If Not IsDBNull(row(15)) Then
                        studentData.Gender = row(15)
                    End If

                    If Not IsDBNull(row(16)) Then
                        studentData.NextOfKin = row(16)
                    End If
                    If Not IsDBNull(row(17)) Then
                        studentData.TI2 = row(17)
                    End If
                    If Not IsDBNull(row(18)) Then
                        studentData.StringTI2FromDate = row(18)
                    End If
                    If Not IsDBNull(row(19)) Then
                        studentData.StringTI2ToDate = row(19)
                    End If
                    If Not IsDBNull(row(20)) Then
                        studentData.TI1 = row(20)
                    End If
                    If Not IsDBNull(row(21)) Then
                        studentData.StringTI1FromDate = row(21)
                    End If
                    If Not IsDBNull(row(22)) Then
                        studentData.StringTI1ToDate = row(22)
                    End If
                    If Not IsDBNull(row(23)) Then
                        studentData.PPI2 = row(23)
                    End If
                    If Not IsDBNull(row(24)) Then
                        studentData.StringPPI2FromDate = row(24)
                    End If
                    If Not IsDBNull(row(25)) Then
                        studentData.StringPPI2ToDate = row(25)
                    End If
                    If Not IsDBNull(row(26)) Then
                        studentData.PPI1 = row(26)
                    End If
                    If Not IsDBNull(row(27)) Then
                        studentData.StringPPI1FromDate = row(27)
                    End If
                    If Not IsDBNull(row(28)) Then
                        studentData.StringPPI1ToDate = row(28)
                    End If
                    If Not IsDBNull(row(29)) Then
                        studentData.PS2 = row(29)
                    End If
                    If Not IsDBNull(row(30)) Then
                        studentData.StringPS2FromDate = row(30)
                    End If
                    If Not IsDBNull(row(31)) Then
                        studentData.StringPS2ToDate = row(31)
                    End If
                    If Not IsDBNull(row(32)) Then
                        studentData.PS1 = row(32)
                    End If
                    If Not IsDBNull(row(33)) Then
                        studentData.StringPS1FromDate = row(33)
                    End If
                    If Not IsDBNull(row(34)) Then
                        studentData.StringPS1ToDate = row(34)
                    End If
                    If Not IsDBNull(row(35)) Then
                        studentData.FacultyID = row(35)
                    End If
                    If Not IsDBNull(row(36)) Then
                        studentData.FacultyName = row(36)
                    End If
                    If Not IsDBNull(row(37)) Then
                        studentData.DeptID = row(37)
                    End If
                    If Not IsDBNull(row(38)) Then
                        studentData.DeptName = row(38)
                    End If
                    If Not IsDBNull(row(39)) Then
                        studentData.SessionID = row(39)
                    End If
                    If Not IsDBNull(row(40)) Then
                        studentData.SessionName = row(40)
                    End If
                    If Not IsDBNull(row(41)) Then
                        studentData.PhotoUrl = row(41)
                    End If
                    If Not IsDBNull(row(42)) Then
                        studentData.CreateDate = row(42)
                    End If
                    If Not IsDBNull(row(42)) Then
                        studentData.Jamb = row(42)
                    End If
                    If Not IsDBNull(row(42)) Then
                        studentData.UMEScore = row(42)
                    End If

                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)

        End Try
        Return studentData
    End Function
    ''' <summary>
    ''' Creates a RegistrationNumber
    ''' </summary>
    ''' <param name="RegistrationNumber"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates RegistrationNumber using RegistrationNumber</remarks>
    Public Function CreateRegistrationNumber(ByVal RegistrationNumber As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegistrationNumber", RegistrationNumber)}
        Try
            'Create RegistrationNumber data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateRegistrationNumber", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes RegistrationNumber from the database
    ''' </summary>
    ''' <param name="RegistrationNumberID"></param>
    ''' <remarks>It deletes RegistrationNumber record from the database </remarks>
    Public Function DeleteRegistrationNumber(ByVal RegistrationNumberID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegistrationNumberID", RegistrationNumberID)}
        Try
            'Delete RegistrationNumber data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteRegistrationNumber", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Fetches all RegistrationNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllRegistrationNumber() As DataSet
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllRegistrationNumber")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function
    ''' <summary>
    ''' Finds RegistrationNumber by RegistrationNumberID
    ''' </summary>
    ''' <param name="RegistrationNumberID"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>It takes CountryID and returns StudentProfileData </remarks>
    Public Function FindRegistrationNumberID(ByVal RegistrationNumberID As Integer) As StudentProfileData
        Dim RegistrationNumber As StudentProfileData = New StudentProfileData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegistrationNumberID", RegistrationNumberID)}
        Try
            'Fetch item based on RegistrationNumberID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindRegistrationNumberID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        RegistrationNumber.RegNumberID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        RegistrationNumber.RegNumber = row(1)
                    End If
                Next
                'Return RegistrationNumber data.
                Return RegistrationNumber
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
    ''' Updates RegistrationNumber Data
    ''' </summary>
    ''' <param name="RegistrationNumber"></param>
    ''' <remarks>It updates the database using StudentProfileData</remarks>
    Public Function UpdateRegistrationNumber(ByVal RegistrationNumber As StudentProfileData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegistrationNumberID", RegistrationNumber.RegNumberID), _
        New SqlParameter("@RegistrationNumber", RegistrationNumber.RegNumber)}
        Try
            'Modify RegistrationNumber data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateRegistrationNumber", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Creates a Student Login
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CreateLogin(ByVal Student As StudentProfileData, ByVal CreatedByRegNo As String) As String()
        Dim RetVal() As String = {"", "", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegistrationNumber", Student.RegNumber), _
         New SqlParameter("@ETransactPin", Student.ETransactPin), _
         New SqlParameter("@LogTxnFlag", LogTxnFlag), _
         New SqlParameter("@LogErrorFlag", LogErrorFlag), _
         New SqlParameter("@CreatedByRegNo", CreatedByRegNo), _
         New SqlParameter("@retcode", SqlDbType.Int, 4), _
          New SqlParameter("@RegNoExit", SqlDbType.Int, 4), _
         New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output
        params(7).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateLogin", params)
            'Populate Error Code
            RetVal(0) = params(5).Value
            'Populate Error Hint
            RetVal(1) = params(6).Value
            'Populate Error Hint
            RetVal(2) = params(7).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(5).Value
            'Populate Error Hint
            RetVal(1) = params(6).Value
            'Populate StudentProfileID
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Returning the registration number for quarantine
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <remarks>It returns the registration number</remarks>
    Public Function ReturnRegNumber(ByVal RegNumber As Integer) As StudentProfileData
        Dim RegistrationNumber As StudentProfileData = New StudentProfileData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegistrationNumber", RegNumber)}
        Try
            'Fetch item based on RegistrationNumberID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindRegistrationNumber", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        RegistrationNumber.RegNumber = row(0)
                    End If

                Next
                'Return RegistrationNumber data.
                Return RegistrationNumber
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
    ''' Fetches all RegistrationNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function GetAllRegistrationNumber(ByVal RegNumber As String) As DataSet
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegistrationNumber", RegNumber)}
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "GetAllRegistrationNumber", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function

    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function QuarantineStudentsRecords(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@Quarantine", Student.Quarantine), _
         New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@CreatedByUID", Student.CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output

        Try
            'Create student's profile
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_QuarantineStudentsRecords", params)
            'Populate Error Code
            RetVal(0) = params(5).Value
            'Populate Error Hint
            RetVal(1) = params(6).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(5).Value
            'Populate Error Hint
            RetVal(1) = params(6).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Returning the Quaratine Records
    ''' </summary>
    '''
    ''' <remarks>It returns the Quaratine Records</remarks>
    Public Function ReturnQuaratineRecords(ByVal RegistrationNumber As String) As StudentProfileData
        Dim QRecords As StudentProfileData = New StudentProfileData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegistrationNumber", RegistrationNumber)}
        Try
            'Fetch item based on QuaratineRecords
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllQuaratineRecords", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        QRecords.RegNumber = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        QRecords.Quarantine = row(1)
                    End If

                Next
                'Return QuaratineRecords data.
                Return QRecords
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
    ''' Returning the Activate Records
    ''' </summary>
    '''
    ''' <remarks>It returns the Activate Records</remarks>
    Public Function ReturnActivateRecords(ByVal RegistrationNumber As String) As StudentProfileData
        Dim ARecords As StudentProfileData = New StudentProfileData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegistrationNumber", RegistrationNumber)}
        Try
            'Fetch item based on ActivateRecords
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllActivateRecords", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        ARecords.RegNumber = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        ARecords.Quarantine = row(1)
                    End If

                Next
                'Return ActivateRecords data.
                Return ARecords
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
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function ActivateStudentsRecords(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@Activate", Student.Activate), _
         New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@CreatedByUID", Student.CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output

        Try
            'Create student's profile
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_ActivateStudentsRecords", params)
            'Populate Error Code
            RetVal(0) = params(5).Value
            'Populate Error Hint
            RetVal(1) = params(6).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(5).Value
            'Populate Error Hint
            RetVal(1) = params(6).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindAllOLevelResultsByRegNumber(ByVal RegNumber As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllOLevelResultsByRegNumber", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    studentData.ExamsBodyID = row(0)
                    studentData.ExamsMonth = row(1)
                    If Not IsDBNull(row(2)) Then
                        studentData.ExamsYear = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        studentData.Sitting = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        studentData.OlevelSubject1 = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        studentData.OlevelSubject2 = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        studentData.OlevelSubject3 = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        studentData.OlevelSubject4 = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        studentData.OlevelSubject5 = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        studentData.OlevelSubject6 = row(9)
                    End If
                    If Not IsDBNull(row(10)) Then
                        studentData.OlevelSubject7 = row(10)
                    End If
                    If Not IsDBNull(row(11)) Then
                        studentData.OlevelSubject8 = row(11)
                    End If
                    If Not IsDBNull(row(12)) Then
                        studentData.OlevelSubject9 = row(12)
                    End If
                    If Not IsDBNull(row(13)) Then
                        studentData.Grade1 = row(13)
                    End If
                    If Not IsDBNull(row(14)) Then
                        studentData.Grade2 = row(14)
                    End If
                    If Not IsDBNull(row(15)) Then
                        studentData.Grade3 = row(15)
                    End If
                    If Not IsDBNull(row(16)) Then
                        studentData.Grade4 = row(16)
                    End If
                    If Not IsDBNull(row(17)) Then
                        studentData.Grade5 = row(17)
                    End If
                    If Not IsDBNull(row(18)) Then
                        studentData.Grade6 = row(18)
                    End If
                    If Not IsDBNull(row(19)) Then
                        studentData.Grade7 = row(19)
                    End If
                    If Not IsDBNull(row(20)) Then
                        studentData.Grade8 = row(20)
                    End If
                    If Not IsDBNull(row(21)) Then
                        studentData.Grade9 = row(21)
                    End If
                    
                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)

        End Try
        Return studentData
    End Function
    ''' <summary>
    ''' Active Student's transaction pin
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <remarks>Active student's transaction pin</remarks>
    Public Function PaySchoolFees(ByVal Student As StudentProfileData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", "", "", "", "", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@ETransactionPinID", Student.ETransactionPinID), _
        New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@LevelID", Student.LevelID), _
        New SqlParameter("@SessionID", Student.SessionID), _
        New SqlParameter("@SemesterID", Student.SemesterID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByRegNo", Student.RegNumber), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
        New SqlParameter("@ReturnSessionID", SqlDbType.Int, 4), _
        New SqlParameter("@ReturnLevelID", SqlDbType.Int, 4), _
        New SqlParameter("@ReturnSemesterID", SqlDbType.Int, 4), _
        New SqlParameter("@ReturnTerm", SqlDbType.Int, 4)}

        'Assigning value to the return value
        params(8).Direction = ParameterDirection.Output
        params(9).Direction = ParameterDirection.Output
        params(10).Direction = ParameterDirection.Output
        params(11).Direction = ParameterDirection.Output
        params(12).Direction = ParameterDirection.Output
        params(13).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_PaySchoolFees", params)
            'Populate Error Code
            RetVal(0) = params(8).Value
            'Populate Error Hint
            RetVal(1) = params(9).Value
            'Returing session ID
            RetVal(2) = params(10).Value
            'Returing Level ID
            RetVal(3) = params(11).Value
            'Returing Semester ID
            RetVal(4) = params(12).Value
            'Returing Semester ID
            RetVal(5) = params(13).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            'Populate Error Code
            RetVal(0) = params(8).Value
            'Populate Error Code
            RetVal(1) = params(9).Value
            'Populate Error Hint
            RetVal(2) = params(10).Value
            'Returing session ID
            RetVal(3) = params(11).Value
            'Returing Level ID
            RetVal(4) = params(12).Value
            'Returing Semester ID
            RetVal(5) = params(13).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Active Student's transaction pin
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <remarks>Active student's transaction pin</remarks>
    Public Function ActiveETransPin(ByVal Student As StudentProfileData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", "", "", "", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@ETransactPin", Student.ETransactPin), _
        New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByRegNo", Student.RegNumber), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
        New SqlParameter("@SessionID", SqlDbType.Int, 4), _
        New SqlParameter("@LevelID", SqlDbType.Int, 4), _
        New SqlParameter("@SemesterID", SqlDbType.Int, 4)}

        'Assigning value to the return value
        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output
        params(7).Direction = ParameterDirection.Output
        params(8).Direction = ParameterDirection.Output
        params(9).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_ActiveETransPin", params)
            'Populate Error Code
            RetVal(0) = params(5).Value
            'Populate Error Hint
            RetVal(1) = params(6).Value
            'Return session ID
            RetVal(2) = params(7).Value
            'Return Level ID
            RetVal(3) = params(8).Value
            'Return semester ID
            RetVal(4) = params(9).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            'Populate Error Code
            RetVal(0) = params(5).Value
            'Populate Error Hint
            RetVal(1) = params(6).Value
            'Return session ID
            RetVal(2) = params(7).Value
            'Return Level ID
            RetVal(3) = params(8).Value
            'Return semester ID
            RetVal(4) = params(9).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CreateStudentProfiles(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", "", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@Surname", Student.Surname), _
        New SqlParameter("@Firstname", Student.Firstname), _
        New SqlParameter("@MiddleName", Student.MiddleName), _
        New SqlParameter("@MothersMaidenName", Student.MothersMaidenName), _
        New SqlParameter("@DateOfBirth", Student.DateOfBirth), _
        New SqlParameter("@PermenentHomeAddr", Student.PermenentHomeAddr), _
        New SqlParameter("@PhoneNumber", Student.PhoneNumber), _
        New SqlParameter("@EmailAddress", Student.EmailAddress), _
        New SqlParameter("@CountryID", Student.CountryID), _
        New SqlParameter("@StateID", Student.StateID), _
        New SqlParameter("@LGAID", Student.LGAID), _
        New SqlParameter("@EntryLevelID", Student.EntryLevelID), _
        New SqlParameter("@SessionID", Student.AdmissionSessionID), _
        New SqlParameter("@Gender", Student.Gender), _
        New SqlParameter("@NextOfKin", Student.NextOfKin), _
        New SqlParameter("@AdmissionModeID", Student.AdmissionModeID), _
        New SqlParameter("@PPI2", Student.PPI2), _
        New SqlParameter("@PPI2FromDate", Student.PPI2FromDate), _
        New SqlParameter("@PPI2ToDate", Student.PPI2ToDate), _
        New SqlParameter("@PPI1", Student.PPI1), _
        New SqlParameter("@PPI1FromDate", Student.PPI1FromDate), _
        New SqlParameter("@PPI1ToDate", Student.PPI1ToDate), _
        New SqlParameter("@PS2", Student.PS2), _
        New SqlParameter("@PS2FromDate", Student.PS2FromDate), _
        New SqlParameter("@PS2ToDate", Student.PS2ToDate), _
        New SqlParameter("@PS1", Student.PS1), _
        New SqlParameter("@PS1FromDate", Student.PS1FromDate), _
        New SqlParameter("@PS1ToDate", Student.PS1ToDate), _
        New SqlParameter("@SemesterID", Student.SemesterID), _
        New SqlParameter("@FacultyID", Student.FacultyID), _
        New SqlParameter("@DeptID", Student.DeptID), _
        New SqlParameter("@PhotoUrl", Student.PhotoUrl), _
        New SqlParameter("@CreatedByRegNo", Student.CreatedByRegNo), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(36).Direction = ParameterDirection.Output
        params(37).Direction = ParameterDirection.Output

        'Try
        'Create student's profile
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UpdateStudentProfile", params)
        'Populate Error Code
        RetVal(0) = params(36).Value
        'Populate Error Hint
        RetVal(1) = params(37).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(36).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(37).Value
        '    Return RetVal
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function UpdateStudentProfiles(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", "", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@Surname", Student.Surname), _
        New SqlParameter("@Firstname", Student.Firstname), _
        New SqlParameter("@MiddleName", Student.MiddleName), _
        New SqlParameter("@MothersMaidenName", Student.MothersMaidenName), _
        New SqlParameter("@DateOfBirth", Student.DateOfBirth), _
        New SqlParameter("@PermenentHomeAddr", Student.PermenentHomeAddr), _
        New SqlParameter("@PhoneNumber", Student.PhoneNumber), _
        New SqlParameter("@EmailAddress", Student.EmailAddress), _
        New SqlParameter("@CountryID", Student.CountryID), _
        New SqlParameter("@StateID", Student.StateID), _
        New SqlParameter("@LGAID", Student.LGAID), _
        New SqlParameter("@EntryLevelID", Student.EntryLevelID), _
        New SqlParameter("@SessionID", Student.AdmissionSessionID), _
        New SqlParameter("@Gender", Student.Gender), _
        New SqlParameter("@NextOfKin", Student.NextOfKin), _
        New SqlParameter("@AdmissionModeID", Student.AdmissionModeID), _
        New SqlParameter("@PPI2", Student.PPI2), _
        New SqlParameter("@PPI2FromDate", Student.PPI2FromDate), _
        New SqlParameter("@PPI2ToDate", Student.PPI2ToDate), _
        New SqlParameter("@PPI1", Student.PPI1), _
        New SqlParameter("@PPI1FromDate", Student.PPI1FromDate), _
        New SqlParameter("@PPI1ToDate", Student.PPI1ToDate), _
        New SqlParameter("@PS2", Student.PS2), _
        New SqlParameter("@PS2FromDate", Student.PS2FromDate), _
        New SqlParameter("@PS2ToDate", Student.PS2ToDate), _
        New SqlParameter("@PS1", Student.PS1), _
        New SqlParameter("@PS1FromDate", Student.PS1FromDate), _
        New SqlParameter("@PS1ToDate", Student.PS1ToDate), _
        New SqlParameter("@SemesterID", Student.SemesterID), _
        New SqlParameter("@FacultyID", Student.FacultyID), _
        New SqlParameter("@DeptID", Student.DeptID), _
        New SqlParameter("@PhotoUrl", Student.PhotoUrl), _
        New SqlParameter("@CreatedByRegNo", Student.CreatedByRegNo), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(36).Direction = ParameterDirection.Output
        params(37).Direction = ParameterDirection.Output

        'Try
        'Create student's profile
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UpdateStudentProfile", params)
        'Populate Error Code
        RetVal(0) = params(36).Value
        'Populate Error Hint
        RetVal(1) = params(37).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(36).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(37).Value
        '    Return RetVal
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function UploadStudentProfile(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
         New SqlParameter("@SSCECopyUrl", Student.SSCECopyUrl), _
        New SqlParameter("@SSCECopy2Url", Student.SSCECopy2Url), _
        New SqlParameter("@JAMBResultCopyUrl", Student.JAMBResultCopyUrl), _
        New SqlParameter("@BirthCertCopyUrl", Student.BirthCertCopyUrl), _
        New SqlParameter("@CreatedByRegNo", Student.CreatedByRegNo), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(8).Direction = ParameterDirection.Output
        params(9).Direction = ParameterDirection.Output

        Try
            'Create student's profile
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadStudentProfile", params)
            'Populate Error Code
            RetVal(0) = params(8).Value
            'Populate Error Hint
            RetVal(1) = params(9).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(8).Value
            'Populate Error Hint
            RetVal(1) = params(9).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function UpdateStudentDepartment(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@EntryLevelID", Student.EntryLevelID), _
        New SqlParameter("@SessionID", Student.SessionID), _
        New SqlParameter("@SemesterID", Student.SemesterID), _
        New SqlParameter("@AdmissionModeID", Student.AdmissionModeID), _
        New SqlParameter("@CreatedByRegNo", Student.CreatedByRegNo), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(8).Direction = ParameterDirection.Output
        params(9).Direction = ParameterDirection.Output

        Try
            'Create student's profile
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UpdateStudentDepartment", params)
            'Populate Error Code
            RetVal(0) = params(8).Value
            'Populate Error Hint
            RetVal(1) = params(9).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(8).Value
            'Populate Error Hint
            RetVal(1) = params(9).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindAllStudentsByRegistrationNo(ByVal RegNumber As String, ByVal SessionID As Integer, ByVal LevelID As Integer, ByVal SemesterID As Integer) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), _
                                        New SqlParameter("@SessionID", SessionID), _
                                        New SqlParameter("@LevelID", LevelID), _
                                        New SqlParameter("@SemesterID", SemesterID)}

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllStudentsByRegistrationNo", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    studentData.RegNumber = row(0)
                    studentData.Surname = row(1)
                    If Not IsDBNull(row(2)) Then
                        studentData.Firstname = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        studentData.MiddleName = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        studentData.MothersMaidenName = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        studentData.DateOfBirth = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        studentData.PermenentHomeAddr = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        studentData.PhoneNumber = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        studentData.EmailAddress = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        studentData.CountryName = row(9)
                    End If
                    If Not IsDBNull(row(10)) Then
                        studentData.StateName = row(10)
                    End If
                    If Not IsDBNull(row(11)) Then
                        studentData.LGAName = row(11)
                    End If
                    If Not IsDBNull(row(12)) Then
                        studentData.LevelName = row(12)
                    End If
                    If Not IsDBNull(row(13)) Then
                        studentData.SessionName = row(13)
                    End If
                    If Not IsDBNull(row(14)) Then
                        studentData.CreateDate = row(14)
                    End If
                    If Not IsDBNull(row(15)) Then
                        studentData.LastModifiedDate = row(15)
                    End If
                    If Not IsDBNull(row(16)) Then
                        studentData.Gender = row(16)
                    End If
                    If Not IsDBNull(row(17)) Then
                        studentData.NextOfKin = row(17)
                    End If
                    If Not IsDBNull(row(18)) Then
                        studentData.AdmissionMode = row(18)
                    End If
                    If Not IsDBNull(row(19)) Then
                        studentData.PS2 = row(19)
                    End If
                    If Not IsDBNull(row(20)) Then
                        studentData.PS2FromDate = row(20)
                    End If
                    If Not IsDBNull(row(21)) Then
                        studentData.PS2ToDate = row(21)
                    End If
                    If Not IsDBNull(row(22)) Then
                        studentData.PS1 = row(22)
                    End If
                    If Not IsDBNull(row(23)) Then
                        studentData.PS1FromDate = row(23)
                    End If
                    If Not IsDBNull(row(24)) Then
                        studentData.PS1ToDate = row(24)
                    End If
                    If Not IsDBNull(row(25)) Then
                        studentData.PPI1 = row(25)
                    End If
                    If Not IsDBNull(row(26)) Then
                        studentData.PPI1FromDate = row(26)
                    End If
                    If Not IsDBNull(row(27)) Then
                        studentData.PPI1ToDate = row(27)
                    End If
                    If Not IsDBNull(row(28)) Then
                        studentData.PPI2 = row(28)
                    End If
                    If Not IsDBNull(row(29)) Then
                        studentData.PPI2FromDate = row(29)
                    End If
                    If Not IsDBNull(row(30)) Then
                        studentData.PPI2ToDate = row(30)
                    End If
                    If Not IsDBNull(row(31)) Then
                        studentData.CountryID = row(31)
                    End If
                    If Not IsDBNull(row(32)) Then
                        studentData.StateID = row(32)
                    End If
                    If Not IsDBNull(row(33)) Then
                        studentData.LGAID = row(33)
                    End If

                    If Not IsDBNull(row(34)) Then
                        studentData.EntryLevelID = row(34)
                    End If
                    If Not IsDBNull(row(35)) Then
                        studentData.SessionID = row(35)
                    End If
                    If Not IsDBNull(row(36)) Then
                        studentData.AdmissionModeID = row(36)
                    End If
                    If Not IsDBNull(row(37)) Then
                        studentData.PhotoUrl = row(37)
                    End If
                    If Not IsDBNull(row(38)) Then
                        studentData.SemesterID = row(38)
                    End If
                    If Not IsDBNull(row(39)) Then
                        studentData.Semester = row(39)
                    End If
                    If Not IsDBNull(row(40)) Then
                        studentData.CurrentLevel = row(40)
                    End If
                    If Not IsDBNull(row(41)) Then
                        studentData.CurrentSession = row(41)
                    End If
                    If Not IsDBNull(row(42)) Then
                        studentData.CurrentSemester = row(42)
                    End If
                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
        End Try
        Return studentData
    End Function

    ''' <summary>
    ''' Find Students Profile By RegNumer
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindStudentsProfileByRegNumer(ByVal RegNumber As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStudentsProfileByRegNumer", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    studentData.RegNumber = row(0)
                    studentData.Surname = row(1)
                    If Not IsDBNull(row(2)) Then
                        studentData.Firstname = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        studentData.MiddleName = row(3)
                    End If
                Next
                Return studentData
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
        End Try
        Return studentData
    End Function
    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CreatePostUmeApplication(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", "", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@Surname", Student.Surname), _
        New SqlParameter("@Firstname", Student.Firstname), _
        New SqlParameter("@MiddleName", Student.MiddleName), _
        New SqlParameter("@MothersMaidenName", Student.MothersMaidenName), _
        New SqlParameter("@DateOfBirth", Student.DateOfBirth), _
        New SqlParameter("@PermenentHomeAddr", Student.PermenentHomeAddr), _
        New SqlParameter("@PhoneNumber", Student.PhoneNumber), _
        New SqlParameter("@EmailAddress", Student.EmailAddress), _
        New SqlParameter("@CountryID", Student.CountryID), _
        New SqlParameter("@StateID", Student.StateID), _
        New SqlParameter("@LGAID", Student.LGAID), _
        New SqlParameter("@Gender", Student.Gender), _
        New SqlParameter("@NextOfKin", Student.NextOfKin), _
        New SqlParameter("@PPI2", Student.PPI2), _
        New SqlParameter("@PPI2FromDate", Student.PPI2FromDate), _
        New SqlParameter("@PPI2ToDate", Student.PPI2ToDate), _
        New SqlParameter("@PPI1", Student.PPI1), _
        New SqlParameter("@PPI1FromDate", Student.PPI1FromDate), _
        New SqlParameter("@PPI1ToDate", Student.PPI1ToDate), _
        New SqlParameter("@PS2", Student.PS2), _
        New SqlParameter("@PS2FromDate", Student.PS2FromDate), _
        New SqlParameter("@PS2ToDate", Student.PPI2ToDate), _
        New SqlParameter("@PS1", Student.PS1), _
        New SqlParameter("@PS1FromDate", Student.PS1FromDate), _
        New SqlParameter("@PS1ToDate", Student.PS1ToDate), _
        New SqlParameter("@FacultyID", Student.FacultyID), _
        New SqlParameter("@DeptID", Student.DeptID), _
        New SqlParameter("@SecondDeptID", Student.SecondDeptID), _
        New SqlParameter("@Jamb", Student.Jamb), _
        New SqlParameter("@UMEScore", Student.UMEScore), _
        New SqlParameter("@PhotoUrl", Student.PhotoUrl), _
        New SqlParameter("@CreatedByRegNo", Student.CreatedByRegNo), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(35).Direction = ParameterDirection.Output
        params(36).Direction = ParameterDirection.Output

        Try
            'Create student's profile
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreatePostUmeApplication", params)
            'Populate Error Code
            RetVal(0) = params(35).Value
            'Populate Error Hint
            RetVal(1) = params(36).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(35).Value
            'Populate Error Hint
            RetVal(1) = params(36).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CreateApplicationForm(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", "", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@Surname", Student.Surname), _
        New SqlParameter("@Firstname", Student.Firstname), _
        New SqlParameter("@MiddleName", Student.MiddleName), _
        New SqlParameter("@MothersMaidenName", Student.MothersMaidenName), _
        New SqlParameter("@DateOfBirth", Student.DateOfBirth), _
        New SqlParameter("@PermenentHomeAddr", Student.PermenentHomeAddr), _
        New SqlParameter("@PhoneNumber", Student.PhoneNumber), _
        New SqlParameter("@EmailAddress", Student.EmailAddress), _
        New SqlParameter("@CountryID", Student.CountryID), _
        New SqlParameter("@StateID", Student.StateID), _
        New SqlParameter("@LGAID", Student.LGAID), _
        New SqlParameter("@Gender", Student.Gender), _
        New SqlParameter("@NextOfKin", Student.NextOfKin), _
        New SqlParameter("@PPI2", Student.PPI2), _
        New SqlParameter("@PPI2FromDate", Student.PPI2FromDate), _
        New SqlParameter("@PPI2ToDate", Student.PPI2ToDate), _
        New SqlParameter("@PPI1", Student.PPI1), _
        New SqlParameter("@PPI1FromDate", Student.PPI1FromDate), _
        New SqlParameter("@PPI1ToDate", Student.PPI1ToDate), _
        New SqlParameter("@PS2", Student.PS2), _
        New SqlParameter("@PS2FromDate", Student.PS2FromDate), _
        New SqlParameter("@PS2ToDate", Student.PPI2ToDate), _
        New SqlParameter("@PS1", Student.PS1), _
        New SqlParameter("@PS1FromDate", Student.PS1FromDate), _
        New SqlParameter("@PS1ToDate", Student.PS1ToDate), _
        New SqlParameter("@FacultyID", Student.FacultyID), _
        New SqlParameter("@DeptID", Student.DeptID), _
        New SqlParameter("@SecondDeptID", Student.SecondDeptID), _
        New SqlParameter("@Jamb", Student.Jamb), _
        New SqlParameter("@UMEScore", Student.UMEScore), _
        New SqlParameter("@PhotoUrl", Student.PhotoUrl), _
        New SqlParameter("@CreatedByRegNo", Student.CreatedByRegNo), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(35).Direction = ParameterDirection.Output
        params(36).Direction = ParameterDirection.Output

        Try
            'Create student's profile
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateApplicationForm", params)
            'Populate Error Code
            RetVal(0) = params(35).Value
            'Populate Error Hint
            RetVal(1) = params(36).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(35).Value
            'Populate Error Hint
            RetVal(1) = params(36).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Returning String
    ''' </summary>
    ''' <param name="ApplicationNumber"></param>
    ''' <remarks>It returns the String</remarks>
    Public Function ApproveApplicationForm(ByVal ApplicationNumber As String) As String()
        Dim RetValue As String() = {"", ""}
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        Dim params() As SqlParameter = _
                {New SqlParameter("@ApplicationNumber", ApplicationNumber)}
        Try
            'Fetch item based on RegistrationNumberID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "ApproveApplicationForm", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        RetValue(0) = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        RetValue(1) = row(1)
                    End If
                Next
                'Return RegistrationNumber data.
                Return RetValue
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
    ''' Returning String
    ''' </summary>
    ''' <param name="ApplicationNumber"></param>
    ''' <remarks>It returns the String</remarks>
    Public Function CheckApproveApplicationForm(ByVal ApplicationNumber As String) As String()
        Dim RetValue As String() = {"", ""}
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        Dim params() As SqlParameter = _
                {New SqlParameter("@ApplicationNumber", ApplicationNumber)}
        'Try
        'Fetch item based on RegistrationNumberID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CheckApproveApplicationForm", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    RetValue(0) = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    RetValue(1) = row(1)
                End If
            Next
            'Return RegistrationNumber data.
            Return RetValue
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function UploadPostUMECredentials(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
         New SqlParameter("@SSCECopyUrl", Student.SSCECopyUrl), _
        New SqlParameter("@SSCECopy2Url", Student.SSCECopy2Url), _
        New SqlParameter("@JAMBResultCopyUrl", Student.JAMBResultCopyUrl), _
        New SqlParameter("@BirthCertCopyUrl", Student.BirthCertCopyUrl), _
        New SqlParameter("@CreatedByRegNo", Student.CreatedByRegNo), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(8).Direction = ParameterDirection.Output
        params(9).Direction = ParameterDirection.Output

        ' Try
        'Create student's profile
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadPostUMECredentials", params)
        'Populate Error Code
        RetVal(0) = params(8).Value
        'Populate Error Hint
        RetVal(1) = params(9).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(8).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(9).Value
        '    Return RetVal
        ' End Try
    End Function
    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function UploadApplicationCredentials(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
         New SqlParameter("@SSCECopyUrl", Student.SSCECopyUrl), _
        New SqlParameter("@SSCECopy2Url", Student.SSCECopy2Url), _
        New SqlParameter("@JAMBResultCopyUrl", Student.JAMBResultCopyUrl), _
        New SqlParameter("@BirthCertCopyUrl", Student.BirthCertCopyUrl), _
        New SqlParameter("@CreatedByRegNo", Student.CreatedByRegNo), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(8).Direction = ParameterDirection.Output
        params(9).Direction = ParameterDirection.Output

        ' Try
        'Create student's profile
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadApplicationCredentials", params)
        'Populate Error Code
        RetVal(0) = params(8).Value
        'Populate Error Hint
        RetVal(1) = params(9).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(8).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(9).Value
        '    Return RetVal
        ' End Try
    End Function
    ''' <summary>
    ''' Approving application form
    ''' </summary>
    ''' <param name="student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function ApproveApplication(ByVal student As StudentProfileData, ByVal Status As String) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@ApplicationNumber", student.RegNumber), _
        New SqlParameter("@Status", Status), _
        New SqlParameter("@CreatedByUID", student.CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output

        ' Try
        'Create student's profile
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_ApproveApplicationForm", params)
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
    ''' <summary>
    ''' Returning String
    ''' </summary>
    ''' <param name="Year"></param>
    ''' <remarks>It returns the String</remarks>
    Public Function FindAllNoStudentApplicationByYear(ByVal Year As String) As StudentProfileData
        Dim RetValue As String() = {"", ""}
        Dim StudentData As StudentProfileData = New StudentProfileData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        Dim params() As SqlParameter = _
                {New SqlParameter("@Year", Year)}
        Try
            'Fetch item based on RegistrationNumberID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllNoStudentApplicationByYear", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        StudentData.Year = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        StudentData.Total = row(1)
                    End If
                Next
                'Return RegistrationNumber data.
                Return StudentData
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
    ''' Fetches all Find All Student Application By Year to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllStudentApplicationByYear(ByVal Year As String) As DataSet
        Dim params() As SqlParameter = _
                {New SqlParameter("@Year", Year)}
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllRegistrationNumber", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function
    ''' <summary>
    ''' Returning String
    ''' </summary>
    ''' <param name="Year"></param>
    ''' <remarks>It returns the String</remarks>
    Public Function FindAllNoStudentApplicationApprovedByYear(ByVal Year As String) As StudentProfileData
        Dim RetValue As String() = {"", ""}
        Dim StudentData As StudentProfileData = New StudentProfileData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        Dim params() As SqlParameter = _
                {New SqlParameter("@Year", Year)}
        Try
            'Fetch item based on RegistrationNumberID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllNoStudentApplicationApprovedByYear", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        StudentData.Year = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        StudentData.Total = row(1)
                    End If
                Next
                'Return RegistrationNumber data.
                Return StudentData
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
    ''' Fetches all Find All Student Application By Year to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllStudentApplicationApprovedByYear(ByVal Year As String) As DataSet
        Dim params() As SqlParameter = _
                {New SqlParameter("@Year", Year)}
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStudentApplicationApprovedByYear", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function
    ''' <summary>
    ''' Returning String
    ''' </summary>
    ''' <param name="Year"></param>
    ''' <remarks>It returns the String</remarks>
    Public Function FindAllNoStudentApplicationListByYear(ByVal Year As String) As StudentProfileData
        Dim RetValue As String() = {"", ""}
        Dim StudentData As StudentProfileData = New StudentProfileData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        Dim params() As SqlParameter = _
                {New SqlParameter("@Year", Year)}
        Try
            'Fetch item based on RegistrationNumberID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllNoStudentApplicationListByYear", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        StudentData.Year = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        StudentData.Total = row(1)
                    End If
                Next
                'Return RegistrationNumber data.
                Return StudentData
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
    ''' Fetches all Find All Student Application By Year to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllStudentApplicationListByYear(ByVal Year As String) As DataSet
        Dim params() As SqlParameter = _
                {New SqlParameter("@Year", Year)}
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStudentApplicationListByYear", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function
    ''' <summary>
    ''' Finds RegNo by RegNo
    ''' </summary>
    ''' <param name="RegNo"></param>
    ''' <returns>UsersData</returns>
    ''' <remarks>Takes UserName as parameter and return UsersData</remarks>
    Public Function FindRegNoByRegNo(ByVal RegNo As String) As StudentProfileData
        'instantiate object to hold user data
        Dim StudentProfileData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNo", RegNo), New SqlParameter("@RowNumbers", SqlDbType.Int, 4)}
        'specify output parameters.
        params(1).Direction = ParameterDirection.Output
        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindRegNoByRegNo", params)
            Dim retVal As Integer = params(1).Value
            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows

                    StudentProfileData.StudentProfileID = row(0)
                    StudentProfileData.RegNumber = row(1)
                    If Not IsDBNull(row(2)) Then
                        StudentProfileData.Surname = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        StudentProfileData.Firstname = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        StudentProfileData.MiddleName = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        StudentProfileData.Password = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        StudentProfileData.CreateDate = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        StudentProfileData.SaltKey = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        StudentProfileData.PhoneNumber = row(8)
                    End If

                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        Return StudentProfileData
    End Function
    ''' <summary>
    ''' Creates a new User 
    ''' </summary>
    ''' <param name="StudentProfileData"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>Returns the newly created User's UserID when successful and returns 0 when it fails to create a new User</remarks>
    Public Function ChangePassword(ByVal StudentProfileData As StudentProfileData) As Integer
        'declare and initialise data access parameters for creating  user details
        Dim params() As SqlParameter = _
        {New SqlParameter("@Password", StudentProfileData.NewPassword), _
        New SqlParameter("@SaltKey", StudentProfileData.NewSaltKey), _
        New SqlParameter("@RegNo", StudentProfileData.RegNumber)}
        Try
            'Create User
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "StudentChangePassword", params)
            Return 1
        Catch ex As Exception
            AppException.LogError(ex.Message)
            'Log error if it occurs and return nothing
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Active Student's transaction pin
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <remarks>Active student's transaction pin</remarks>
    Public Function PayStudentSchoolFees(ByVal Student As StudentProfileData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", "", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@ETransactionPinID", Student.ETransactPin), _
        New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@SessionID", Student.SessionID), _
        New SqlParameter("@LevelID", Student.LevelID), _
        New SqlParameter("@SemesterID", Student.SemesterID), _
        New SqlParameter("@FacultyID", Student.FacultyID), _
        New SqlParameter("@DeptID", Student.DeptID), _
        New SqlParameter("@TypeOfSchoolFees", Student.TypeOfSchoolFees), _
        New SqlParameter("@Amount", Student.Amount), _
        New SqlParameter("@AmountInWords", Student.AmountInWords), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByRegNo", Student.RegNumber), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
        New SqlParameter("@ETransactLogID", SqlDbType.Int, 4)}

        'Assigning value to the return value
        params(13).Direction = ParameterDirection.Output
        params(14).Direction = ParameterDirection.Output
        params(15).Direction = ParameterDirection.Output
        
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_New_PayStudentSchoolFees", params)
            'Populate Error Code
            RetVal(0) = params(13).Value
            'Populate Error Hint
            RetVal(1) = params(14).Value
            'Populate Error Hint
            RetVal(2) = params(15).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            'Populate Error Code
            RetVal(0) = params(13).Value
            'Populate Error Hint
            RetVal(1) = params(14).Value
            Return RetVal
            'Populate Error Hint
            RetVal(2) = params(15).Value
        End Try
    End Function
    ''' <summary>
    ''' Active Student's transaction pin
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <remarks>Active student's transaction pin</remarks>
    Public Function PayStudentSchoolFees_New(ByVal Student As StudentProfileData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", "", ""}

        Dim TxnFlag As String = "N"
        Dim ErrorFlag As String = "N"

        Dim params() As SqlParameter = _
        {New SqlParameter("@ETransactionPinID", Student.ETransactPin), _
        New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@SessionID", Student.SessionID), _
        New SqlParameter("@SemesterID", Student.SemesterID), _
        New SqlParameter("@FacultyID", Student.FacultyID), _
        New SqlParameter("@DeptID", Student.DeptID), _
        New SqlParameter("@TypeOfSchoolFees", Student.TypeOfSchoolFees), _
        New SqlParameter("@Amount", Student.Amount), _
        New SqlParameter("@AmountInWords", Student.AmountInWords), _
        New SqlParameter("@LogTxnFlag", TxnFlag), _
        New SqlParameter("@LogErrorFlag", ErrorFlag), _
        New SqlParameter("@CreatedByRegNo", Student.RegNumber), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
        New SqlParameter("@ETransactLogID", SqlDbType.Int, 4)}

        'Assigning value to the return value
        params(12).Direction = ParameterDirection.Output
        params(13).Direction = ParameterDirection.Output
        params(14).Direction = ParameterDirection.Output

        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_New_PayStudentSchoolFees_New", params)
            'Populate Error Code
            RetVal(0) = params(12).Value
            'Populate Error Hint
            RetVal(1) = params(13).Value
            'Populate Error Hint
            RetVal(2) = params(14).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            'Populate Error Code
            RetVal(0) = "101"
            'Populate Error Hint
            RetVal(1) = "Transaction Name: PAY_STUDENT_SCHOOL_FEES."
            'Populate Error Hint
            RetVal(2) = "0"
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Active Student's transaction pin
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <remarks>Active student's transaction pin</remarks>
    Public Function CheckResultPIN(ByVal Student As StudentProfileData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", "", "", "", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@ETransactionPinID", Student.ETransactPin), _
        New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByRegNo", Student.RegNumber), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
        New SqlParameter("@SessionName", SqlDbType.VarChar, 250), _
        New SqlParameter("@SemesterName", SqlDbType.VarChar, 250), _
        New SqlParameter("@LevelName", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output
        params(7).Direction = ParameterDirection.Output
        params(8).Direction = ParameterDirection.Output
        params(9).Direction = ParameterDirection.Output

        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CheckResultPIN", params)
            'Populate Error Code
            RetVal(0) = params(5).Value
            'Populate Error Hint
            RetVal(1) = params(6).Value
            'Populate Error Hint
            RetVal(2) = params(7).Value
            'Populate Error Hint
            RetVal(3) = params(8).Value
            'Populate Error Hint
            RetVal(4) = params(9).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            'Populate Error Code
            RetVal(0) = params(5).Value
            'Populate Error Hint
            RetVal(1) = params(6).Value
            'Populate Error Hint
            RetVal(2) = params(7).Value
            'Populate Error Hint
            RetVal(3) = params(8).Value
            'Populate Error Hint
            RetVal(4) = params(9).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Active Student's transaction pin
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <remarks>Active student's transaction pin</remarks>
    Public Function CheckResultPIN_New(ByVal Student As StudentProfileData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", "", "", "", ""}

        Dim TxnFlag As String = "N"
        Dim ErrorFlag As String = "N"

        Dim params() As SqlParameter = _
        {New SqlParameter("@ETransactionPinID", Student.ETransactPin), _
        New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@SessionID", Student.SessionID), _
        New SqlParameter("@SemesterID", Student.SemesterID), _
        New SqlParameter("@LogTxnFlag", TxnFlag), _
        New SqlParameter("@LogErrorFlag", ErrorFlag), _
        New SqlParameter("@CreatedByRegNo", Student.RegNumber), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
        New SqlParameter("@SessionName", SqlDbType.VarChar, 250), _
        New SqlParameter("@SemesterName", SqlDbType.VarChar, 250), _
        New SqlParameter("@LevelName", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(7).Direction = ParameterDirection.Output
        params(8).Direction = ParameterDirection.Output
        params(9).Direction = ParameterDirection.Output
        params(10).Direction = ParameterDirection.Output
        params(11).Direction = ParameterDirection.Output

        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CheckResultPIN_New", params)
            'Populate Error Code
            RetVal(0) = params(7).Value
            'Populate Error Hint
            RetVal(1) = params(8).Value
            'Populate Error Hint
            RetVal(2) = params(9).Value
            'Populate Error Hint
            RetVal(3) = params(10).Value
            'Populate Error Hint
            RetVal(4) = params(11).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            'Populate Error Code
            RetVal(0) = "101"
            'Populate Error Hint
            RetVal(1) = "Transaction Name: STUDENT_RESULT_PIN"
            'Populate Error Hint
            RetVal(2) = ""
            'Populate Error Hint
            RetVal(3) = ""
            'Populate Error Hint
            RetVal(4) = ""
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Active Student's transaction pin
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <remarks>Active student's transaction pin</remarks>
    Public Function PayStudentSchoolFeesTemp(ByVal Student As StudentProfileData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", "", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@ETransactionPinID", Student.ETransactPin), _
        New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@SessionID", Student.SessionID), _
        New SqlParameter("@LevelID", Student.LevelID), _
        New SqlParameter("@SemesterID", Student.SemesterID), _
        New SqlParameter("@FacultyID", Student.FacultyID), _
        New SqlParameter("@DeptID", Student.DeptID), _
        New SqlParameter("@TypeOfSchoolFees", Student.TypeOfSchoolFees), _
        New SqlParameter("@Amount", Student.Amount), _
        New SqlParameter("@AmountInWords", Student.AmountInWords), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByRegNo", Student.RegNumber), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
        New SqlParameter("@ETransactLogID", SqlDbType.Int, 4)}

        'Assigning value to the return value
        params(13).Direction = ParameterDirection.Output
        params(14).Direction = ParameterDirection.Output
        params(15).Direction = ParameterDirection.Output

        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_PayStudentSchoolFeesTemp", params)
            'Populate Error Code
            RetVal(0) = params(13).Value
            'Populate Error Hint
            RetVal(1) = params(14).Value
            'Populate Error Hint
            RetVal(2) = params(15).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            'Populate Error Code
            RetVal(0) = params(13).Value
            'Populate Error Hint
            RetVal(1) = params(14).Value
            Return RetVal
            'Populate Error Hint
            RetVal(2) = params(15).Value
        End Try
    End Function
    ''' <summary>
    ''' Fetches all Find All Student School fees
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllSchoolFeesByID(ByVal RegNumber As String, ByVal ETransactionLogID As Integer) As DataSet
        Dim params() As SqlParameter = _
                {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@ETransactionLogID", ETransactionLogID)}
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindstudentSchoolFeesByID", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function
    ''' <summary>
    ''' Finds RegNo by RegNo
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>UsersData</returns>
    ''' <remarks>Takes UserName as parameter and return UsersData</remarks>
    Public Function FindSchoolFessByID(ByVal RegNumber As String, ByVal ETransactionLogID As Integer) As StudentProfileData
        'instantiate object to hold user data
        Dim StudentProfileData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@ETransactionLogID", ETransactionLogID)}


        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindstudentSchoolFeesByID", params)
        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                StudentProfileData.ETransactionPinID = row(0)
                StudentProfileData.ETransactPin = row(1)
                If Not IsDBNull(row(2)) Then
                    StudentProfileData.RegNumber = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    StudentProfileData.LevelID = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    StudentProfileData.LevelName = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    StudentProfileData.SessionID = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    StudentProfileData.SessionName = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    StudentProfileData.TypeOfSchoolFees = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    StudentProfileData.Amount = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    StudentProfileData.AmountInWords = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    StudentProfileData.CreateDate = row(10)
                End If
                If Not IsDBNull(row(11)) Then
                    StudentProfileData.Firstname = row(11)
                End If
                If Not IsDBNull(row(12)) Then
                    StudentProfileData.Semester = row(12)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        Return StudentProfileData
    End Function
    ''' <summary>
    ''' Finds RegNo by RegNo
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>UsersData</returns>
    ''' <remarks>Takes UserName as parameter and return UsersData</remarks>
    Public Function FindstudentSchoolFeesByID_Portal(ByVal RegNumber As String, ByVal ETransactionLogID As Integer) As StudentProfileData
        'instantiate object to hold user data
        Dim StudentProfileData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@ETransactionLogID", ETransactionLogID)}


        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindstudentSchoolFeesByID_Portal", params)
        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                StudentProfileData.ETransactionPinID = row(0)
                StudentProfileData.ETransactPin = row(1)
                If Not IsDBNull(row(2)) Then
                    StudentProfileData.RegNumber = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    StudentProfileData.LevelID = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    StudentProfileData.LevelName = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    StudentProfileData.SessionID = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    StudentProfileData.SessionName = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    StudentProfileData.TypeOfSchoolFees = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    StudentProfileData.Amount = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    StudentProfileData.AmountInWords = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    StudentProfileData.CreateDate = row(10)
                End If
                If Not IsDBNull(row(11)) Then
                    StudentProfileData.Firstname = row(11)
                End If
                If Not IsDBNull(row(12)) Then
                    StudentProfileData.Semester = row(12)
                End If
                If Not IsDBNull(row(13)) Then
                    StudentProfileData.PermenentHomeAddr = row(13)
                End If
                If Not IsDBNull(row(14)) Then
                    StudentProfileData.PhoneNumber = row(14)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        Return StudentProfileData
    End Function
    ''' <summary>
    ''' Finds RegNo by RegNo
    ''' </summary>
    ''' <param name="StudentData"></param>
    ''' <returns>UsersData</returns>
    ''' <remarks>Takes UserName as parameter and return UsersData</remarks>
    Public Function FindPartPayment(ByVal StudentData As StudentProfileData) As StudentProfileData
        'instantiate object to hold user data
        Dim StudentProfileData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@SessionID", StudentData.SessionID), _
                                        New SqlParameter("@SemesterID", StudentData.SemesterID), _
                                        New SqlParameter("@LevelID", StudentData.LevelID), _
                                        New SqlParameter("@FacultyID", StudentData.FacultyID), _
                                        New SqlParameter("@DeptID", StudentData.DeptID), _
                                        New SqlParameter("@RegNumber", StudentData.RegNumber)}


        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindPartPayment", params)
            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows

                    StudentProfileData.ETransactionPinID = row(0)
                    StudentProfileData.ETransactPin = row(1)
                    If Not IsDBNull(row(2)) Then
                        StudentProfileData.RegNumber = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        StudentProfileData.LevelID = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        StudentProfileData.SessionID = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        StudentProfileData.TypeOfSchoolFees = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        StudentProfileData.Amount = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        StudentProfileData.AmountInWords = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        StudentProfileData.CreateDate = row(8)
                    End If
                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        Return StudentProfileData
    End Function
    ''' <summary>
    ''' Finds RegNo by RegNo
    ''' </summary>
    ''' <param name="StudentData"></param>
    ''' <returns>UsersData</returns>
    ''' <remarks>Takes UserName as parameter and return UsersData</remarks>
    Public Function FindPayment(ByVal StudentData As StudentProfileData) As StudentProfileData
        'instantiate object to hold user data
        Dim StudentProfileData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@SessionID", StudentData.SessionID), _
                                        New SqlParameter("@SemesterID", StudentData.SemesterID), _
                                        New SqlParameter("@LevelID", StudentData.LevelID), _
                                        New SqlParameter("@RegNumber", StudentData.RegNumber)}


        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindPayment", params)
            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows

                    StudentProfileData.ETransactionPinID = row(0)
                    StudentProfileData.ETransactPin = row(1)
                    If Not IsDBNull(row(2)) Then
                        StudentProfileData.RegNumber = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        StudentProfileData.LevelID = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        StudentProfileData.SessionID = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        StudentProfileData.TypeOfSchoolFees = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        StudentProfileData.Amount = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        StudentProfileData.CreateDate = row(7)
                    End If
                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        Return StudentProfileData
    End Function

    ''' <summary>
    ''' Updates Course Data
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <remarks>It updates the database using SessionLevelSemesterCourseData</remarks>
    Public Function ResetPassword(ByVal RegNumber As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber)}
        Try
            'Modify Course data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "ResetPassword", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindMovedApplicationByApplicationNumber(ByVal RegNumber As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindMovedApplicationByApplicationNumber", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    studentData.RegNumber = row(0)
                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)

        End Try
        Return studentData
    End Function

    ''' <summary>
    ''' Updates Course Data
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <remarks>It updates the database using SessionLevelSemesterCourseData</remarks>
    Public Function MovedApplicationFormToProfile(ByVal RegNumber As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber)}
        Try
            'Modify Course data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "MovedApplicationFormToProfile", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindSchoolFessPay(ByVal PIN As String) As String
        'instantiate object to hold user data
        Dim RetValue As String = String.Empty
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@PIN", PIN)}

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindSchoolFessPay", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    RetValue = row(0)
                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)

        End Try
        Return RetValue
    End Function
    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindPaidSchoolFessPay(ByVal PIN As String) As String
        'instantiate object to hold user data
        Dim RetValue As String = String.Empty
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@PIN", PIN)}

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindPaidSchoolFessPay", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    RetValue = row(0)
                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)

        End Try
        Return RetValue
    End Function
    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="PIN"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindPaidSchoolFessPayByRegNo(ByVal PIN As String, ByVal RegNo As String) As String
        'instantiate object to hold user data
        Dim RetValue As String = String.Empty
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@PIN", PIN), New SqlParameter("@RegNo", RegNo)}

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindPaidSchoolFessPayByRegNo", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    RetValue = row(0)
                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)

        End Try
        Return RetValue
    End Function
    ''' <summary>
    ''' Finds RegNo by RegNo
    ''' </summary>
    ''' <param name="StudentData"></param>
    ''' <returns>UsersData</returns>
    ''' <remarks>Takes UserName as parameter and return UsersData</remarks>
    Public Function FindSchoolFessByDeptIDFacultyID(ByVal PIN As String, ByVal StudentData As StudentProfileData) As StudentProfileData
        'instantiate object to hold user data
        Dim StudentProfileData As StudentProfileData = New StudentProfileData
        Dim Student As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@PIN", PIN), _
                                        New SqlParameter("@FacultyID", StudentData.FacultyID), _
                                        New SqlParameter("@SemesterID", StudentData.SemesterID), _
                                        New SqlParameter("@SessionID", StudentData.SessionID), _
                                        New SqlParameter("@LevelID", StudentData.LevelID), _
                                        New SqlParameter("@DeptID", StudentData.DeptID)}


        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindSchoolFessByDeptIDFacultyID", params)
        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                StudentProfileData.ETransactionPinID = row(0)
                StudentProfileData.ETransactPin = row(1)
                If Not IsDBNull(row(2)) Then
                    StudentProfileData.Sitting = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    StudentProfileData.FacultyID = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    StudentProfileData.FacultyName = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    StudentProfileData.DeptID = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    StudentProfileData.DeptName = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    StudentProfileData.LevelID = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    StudentProfileData.LevelName = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    StudentProfileData.SessionID = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    StudentProfileData.SessionName = row(10)
                End If
                If Not IsDBNull(row(11)) Then
                    StudentProfileData.SemesterID = row(11)
                End If
                If Not IsDBNull(row(12)) Then
                    StudentProfileData.Semester = row(12)
                End If
                If Not IsDBNull(row(13)) Then
                    StudentProfileData.CurrentSession = row(13)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        Return StudentProfileData
    End Function
    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindSchoolFeesByPIN(ByVal PIN As String) As String
        'instantiate object to hold user data
        Dim RetValue As String = String.Empty
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@PIN", PIN)}

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindSchoolFeesByPIN", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    RetValue = row(0)
                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)

        End Try
        Return RetValue
    End Function
    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function SP_UploadAllStudentProfile(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", "", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@Surname", Student.Surname), _
        New SqlParameter("@Firstname", Student.Firstname), _
        New SqlParameter("@EntryLevelID", Student.EntryLevelID), _
        New SqlParameter("@SessionID", Student.SessionID), _
        New SqlParameter("@AdmissionModeID", Student.AdmissionModeID), _
        New SqlParameter("@SemesterID", Student.SemesterID), _
        New SqlParameter("@FacultyID", Student.FacultyID), _
        New SqlParameter("@DeptID", Student.DeptID), _
        New SqlParameter("@CreatedByRegNo", Student.CreatedByRegNo), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
        New SqlParameter("@CheckUploadedData", SqlDbType.Int, 4)}

        'Assigning value to the return value
        params(12).Direction = ParameterDirection.Output
        params(13).Direction = ParameterDirection.Output
        params(14).Direction = ParameterDirection.Output

        Try
            'Create student's profile
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadAllStudentProfile", params)
            'Populate Error Code
            RetVal(0) = params(12).Value
            'Populate Error Hint
            RetVal(1) = params(13).Value
            'Populate Error Hint
            RetVal(2) = params(14).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(12).Value
            'Populate Error Hint
            RetVal(1) = params(13).Value
            'Populate Error Hint
            RetVal(2) = params(14).Value
            Return RetVal
        End Try
    End Function

    ''' <summary>
    ''' Fetches all RegistrationNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllUploadStudentsProfile() As DataSet
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllUploadStudentsProfile")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function

    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindAllStudentsByRegNo(ByVal RegNumber As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllStudentsByRegNo", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                studentData.RegNumber = row(0)
                studentData.Surname = row(1)
                If Not IsDBNull(row(2)) Then
                    studentData.Firstname = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    studentData.AdmissionModeID = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    studentData.AdmissionMode = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    studentData.LevelID = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    studentData.LevelName = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    studentData.SessionID = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    studentData.SessionName = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    studentData.SemesterID = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    studentData.Semester = row(10)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return studentData
    End Function
    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function UpdateStudentProfile(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", "", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@Surname", Student.Surname), _
        New SqlParameter("@Firstname", Student.Firstname), _
        New SqlParameter("@MiddleName", Student.MiddleName), _
        New SqlParameter("@MothersMaidenName", Student.MothersMaidenName), _
        New SqlParameter("@DateOfBirth", Student.DateOfBirth), _
        New SqlParameter("@PermenentHomeAddr", Student.PermenentHomeAddr), _
        New SqlParameter("@PhoneNumber", Student.PhoneNumber), _
        New SqlParameter("@EmailAddress", Student.EmailAddress), _
        New SqlParameter("@CountryID", Student.CountryID), _
        New SqlParameter("@StateID", Student.StateID), _
        New SqlParameter("@LGAID", Student.LGAID), _
        New SqlParameter("@EntryLevelID", Student.EntryLevelID), _
        New SqlParameter("@SessionID", Student.AdmissionSessionID), _
        New SqlParameter("@Gender", Student.Gender), _
        New SqlParameter("@NextOfKin", Student.NextOfKin), _
        New SqlParameter("@AdmissionModeID", Student.AdmissionModeID), _
        New SqlParameter("@PPI2", Student.PPI2), _
        New SqlParameter("@PPI2FromDate", Student.PPI2FromDate), _
        New SqlParameter("@PPI2ToDate", Student.PPI2ToDate), _
        New SqlParameter("@PPI1", Student.PPI1), _
        New SqlParameter("@PPI1FromDate", Student.PPI1FromDate), _
        New SqlParameter("@PPI1ToDate", Student.PPI1ToDate), _
        New SqlParameter("@PS2", Student.PS2), _
        New SqlParameter("@PS2FromDate", Student.PS2FromDate), _
        New SqlParameter("@PS2ToDate", Student.PPI2ToDate), _
        New SqlParameter("@PS1", Student.PS1), _
        New SqlParameter("@PS1FromDate", Student.PS1FromDate), _
        New SqlParameter("@PS1ToDate", Student.PS1ToDate), _
        New SqlParameter("@SemesterID", Student.SemesterID), _
        New SqlParameter("@FacultyID", Student.FacultyID), _
        New SqlParameter("@DeptID", Student.DeptID), _
        New SqlParameter("@PhotoUrl", Student.PhotoUrl), _
        New SqlParameter("@CreatedByRegNo", Student.CreatedByRegNo), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(36).Direction = ParameterDirection.Output
        params(37).Direction = ParameterDirection.Output

        'Try
        'Create student's profile
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UpdateStudentProfile", params)
        'Populate Error Code
        RetVal(0) = params(36).Value
        'Populate Error Hint
        RetVal(1) = params(37).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(36).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(37).Value
        '    Return RetVal
        'End Try
    End Function

    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function CheckRegisteredCourse(ByVal RegNumber As String, ByVal Level As String, ByVal Session As String, ByVal Semester As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@Level", Level), New SqlParameter("@Session", Session), New SqlParameter("@Semester", Semester)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CheckRegisteredCourse", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    studentData.RegNumber = row(0)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return studentData
    End Function

    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function CheckRegisteredCourse_ExtraYear(ByVal RegNumber As String, ByVal Level As String, ByVal Session As String, ByVal Semester As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@Level", Level), New SqlParameter("@Session", Session), New SqlParameter("@Semester", Semester)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CheckRegisteredCourse_ExtraYear", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    studentData.RegNumber = row(0)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return studentData
    End Function

    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function CheckRegisteredCourse_Summer(ByVal RegNumber As String, ByVal Level As String, ByVal Session As String, ByVal Semester As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@Level", Level), New SqlParameter("@Session", Session), New SqlParameter("@Semester", Semester)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CheckRegisteredCourse_Summer", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    studentData.RegNumber = row(0)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return studentData
    End Function
    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function CheckRegisteredCourse_CarryOver(ByVal RegNumber As String, ByVal Level As String, ByVal Session As String, ByVal Semester As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@Level", Level), New SqlParameter("@Session", Session), New SqlParameter("@Semester", Semester)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CheckRegisteredCourse_CarryOver", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    studentData.RegNumber = row(0)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return studentData
    End Function
    ''' <summary>
    ''' Finds RegNo by RegNo
    ''' </summary>
    ''' <param name="StudentData"></param>
    ''' <returns>UsersData</returns>
    ''' <remarks>Takes UserName as parameter and return UsersData</remarks>
    Public Function FindPaymentLevel(ByVal StudentData As StudentProfileData) As StudentProfileData
        'instantiate object to hold user data
        Dim StudentProfileData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@LevelID", StudentData.LevelID), _
                                        New SqlParameter("@RegNumber", StudentData.RegNumber)}


        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindPaymentLevel", params)
            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows

                    StudentProfileData.ETransactionPinID = row(0)
                    StudentProfileData.ETransactPin = row(1)
                    If Not IsDBNull(row(2)) Then
                        StudentProfileData.RegNumber = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        StudentProfileData.LevelID = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        StudentProfileData.SessionID = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        StudentProfileData.TypeOfSchoolFees = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        StudentProfileData.Amount = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        StudentProfileData.CreateDate = row(7)
                    End If
                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        Return StudentProfileData
    End Function

    ''' <summary>
    ''' Fetches all RegistrationNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllProfiles() As DataSet
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllProfiles")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function
    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function SP_UploadAllStudentProfileNotepad(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", "", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@Surname", Student.Surname), _
        New SqlParameter("@Firstname", Student.Firstname), _
        New SqlParameter("@EntryLevelID", Student.EntryLevelID), _
        New SqlParameter("@SessionID", Student.SessionID), _
        New SqlParameter("@AdmissionModeID", Student.AdmissionModeID), _
        New SqlParameter("@SemesterID", Student.SemesterID), _
        New SqlParameter("@FacultyID", Student.FacultyID), _
        New SqlParameter("@DeptID", Student.DeptID), _
        New SqlParameter("@CreatedByRegNo", Student.CreatedByRegNo), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(12).Direction = ParameterDirection.Output
        params(13).Direction = ParameterDirection.Output

        'Try
        'Create student's profile
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadAllStudentProfileNotepad", params)
        'Populate Error Code
        RetVal(0) = params(12).Value
        'Populate Error Hint
        RetVal(1) = params(13).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(12).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(13).Value
        '    Return RetVal
        'End Try
    End Function

    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="NotePad"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CreateNotePad(ByVal NotePad As String) As Integer
        Dim params() As SqlParameter = _
        {New SqlParameter("@NotePad", NotePad)}
        Try
            'Create student's profile
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateNotePad", params)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Fetches all RegistrationNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllNotepad() As DataSet
        'Holds RegistrationNumber Data
        Dim Notepad As DataSet = New DataSet
        Try
            'Fetch all RegistrationNumber.
            Notepad = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllNotepad")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return Notepad
    End Function
    ''' <summary>
    ''' Uploads student's credentials
    ''' </summary>
    ''' <param name="PictureUrl"></param>
    ''' <remarks>It uploads student's credentails </remarks>
    Public Function UploadPix(ByVal PictureUrl As String, ByVal RegNumber As String) As Integer
        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@PictureUrl", PictureUrl), _
        New SqlParameter("@RegNumber", RegNumber)}

        Try
            'upload student profile
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UploadPix", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Finds RegNo by RegNo
    ''' </summary>
    ''' <param name="RegNo"></param>
    ''' <returns>UsersData</returns>
    ''' <remarks>Takes UserName as parameter and return UsersData</remarks>
    Public Function FindPictureByRegNo(ByVal RegNo As String) As String
        'instantiate object to hold user data
        Dim Retvalues As String = String.Empty

        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNo)}
       
        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindPictureByRegNo", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                If Not IsDBNull(row(0)) Then
                    Retvalues = row(0)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        Return Retvalues
    End Function
    ''' <summary>
    ''' Finds RegNo by RegNo
    ''' </summary>
    ''' <param name="RegNo"></param>
    ''' <returns>UsersData</returns>
    ''' <remarks>Takes UserName as parameter and return UsersData</remarks>
    Public Function FindETransactSessionByRegNo(ByVal RegNo As String) As StudentProfileData
        'instantiate object to hold user data
        Dim StudentProfileData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNo", RegNo)}


        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindETransactSessionByRegNo", params)
            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows

                    If Not IsDBNull(row(0)) Then
                        StudentProfileData.ETransactionPinID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        StudentProfileData.SessionName = row(1)
                    End If

                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        Return StudentProfileData
    End Function
    ''' <summary>
    ''' Finds RegNo by RegNo
    ''' </summary>
    ''' <param name="RegNo"></param>
    ''' <returns>UsersData</returns>
    ''' <remarks>Takes UserName as parameter and return UsersData</remarks>
    Public Function FindETransactByRegNoSessionLevelSemester(ByVal RegNo As String, ByVal SessionID As Integer, ByVal LevelID As Integer, ByVal SemesterID As Integer) As StudentProfileData
        'instantiate object to hold user data
        Dim StudentProfileData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNo", RegNo), _
                                        New SqlParameter("@SessionID", SessionID), _
                                        New SqlParameter("@LevelID", LevelID), _
                                        New SqlParameter("@SemesterID", SemesterID)}


        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindETransactByRegNoSessionLevelSemester", params)
            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows

                    If Not IsDBNull(row(0)) Then
                        StudentProfileData.ETransactionPinID = row(0)
                    End If

                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        Return StudentProfileData
    End Function
    ''' <summary>
    ''' Finds RegNo by RegNo
    ''' </summary>
    ''' <param name="SessionID"></param>
    ''' <returns>UsersData</returns>
    ''' <remarks>Takes UserName as parameter and return UsersData</remarks>
    Public Function FindStudentThatHavePaidBySession(ByVal SessionID As Integer, ByVal SemesterID As Integer) As StudentProfileData
        'instantiate object to hold user data
        Dim StudentProfile As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@SessionID", SessionID), New SqlParameter("@SemesterID", SemesterID)}


        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStudentThatHavePaidBySession", params)
            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows

                    If Not IsDBNull(row(0)) Then
                        StudentProfile.SessionID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        StudentProfile.SessionName = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        StudentProfile.SemesterID = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        StudentProfile.Semester = row(3)
                    End If

                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        Return StudentProfile
    End Function
    ''' <summary>
    ''' Fetches all RegistrationNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function PrintStudentThatHavePaidBySession(ByVal SessionID As Integer, ByVal SemesterID As Integer) As DataSet
        'Holds RegistrationNumber Data
        Dim Notepad As DataSet = New DataSet

        Dim params() As SqlParameter = {New SqlParameter("@SessionID", SessionID), New SqlParameter("@SemesterID", SemesterID)}
        Try
            'Fetch all RegistrationNumber.
            Notepad = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "PrintStudentThatHavePaidBySession", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return Notepad
    End Function
    
    Public Function TotalNoStudentThatHavePaidBySession(ByVal SessionID As Integer, ByVal SemesterID As Integer) As Integer
        'instantiate object to hold user data
        Dim RetValue As Integer
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@SessionID", SessionID), New SqlParameter("@SemesterID", SemesterID)}


        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "TotalNoStudentThatHavePaidBySession", params)
            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows

                    If Not IsDBNull(row(0)) Then
                        RetValue = row(0)
                    End If

                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        Return RetValue
    End Function


    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindAllStudentsByRegNoDataSet(ByVal RegNumber As String) As DataSet
        'instantiate object to hold user data
        Dim RetValue As DataSet = New DataSet

        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}

        'Try
        'fetch user details
        RetValue = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllUploadStudentsProfileByRegNo", params)

        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        'Return Nothing
        'End Try
        Return RetValue
    End Function
    Public Function ClearCheckUploadedData() As Integer
        Try
            'Delete RegistrationNumber data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "ClearCheckUploadedData")
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function FindAllResultPINByRegNumber(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@LevelID", Student.LevelID), _
        New SqlParameter("@SessionID", Student.SessionID), _
        New SqlParameter("@SemesterID", Student.SemesterID), _
        New SqlParameter("@ResultETransactPin", Student.ETransactPin), _
        New SqlParameter("@CreatedByRegNo", Student.CreatedByRegNo), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(8).Direction = ParameterDirection.Output
        params(9).Direction = ParameterDirection.Output

        'Try
        'Create student's profile
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_FindAllResultPINByRegNumber", params)
        'Populate Error Code
        RetVal(0) = params(8).Value
        'Populate Error Hint
        RetVal(1) = params(9).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(8).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(9).Value
        '    Return RetVal
        'End Try
    End Function
    ''' <summary>
    ''' Returning String
    ''' </summary>
    ''' <param name="Value"></param>
    ''' <remarks>It returns the String</remarks>
    Public Function FindCreditUnitByCourseCode(ByVal Value As StudentProfileData) As StudentProfileData
        Dim RetValue As String() = {"", ""}
        Dim StudentData As StudentProfileData = New StudentProfileData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        Dim params() As SqlParameter = _
                {New SqlParameter("@SemesterID", Value.SemesterID), _
                New SqlParameter("@LevelID", Value.LevelID), _
                New SqlParameter("@SessionID", Value.SessionID), _
                New SqlParameter("@CourseCode", Value.CountryName)}
        Try
            'Fetch item based on RegistrationNumberID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindCreditUnitByCourseCode", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        StudentData.CountryName = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        StudentData.AmountInWords = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        StudentData.Jamb = row(2)
                    End If
                Next
                'Return RegistrationNumber data.
                Return StudentData
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
    ''' Fetches all Find All Student Application By Year to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllLecturerBySessionID(ByVal LectData As StudentProfileData) As DataSet
        Dim params() As SqlParameter = _
                {New SqlParameter("@SessionID", LectData.SessionID), _
                New SqlParameter("@SemesterID", LectData.SemesterID), _
                New SqlParameter("@LevelID", LectData.LevelID)}
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllLecturerBySessionID", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function
    ''' <summary>
    ''' Fetches all Find All Student Application By Year to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllLecturerBySessionName(ByVal LectData As StudentProfileData) As DataSet
        Dim params() As SqlParameter = _
                {New SqlParameter("@RegNumber", LectData.RegNumber), _
                New SqlParameter("@SessionName", LectData.SessionName), _
                New SqlParameter("@SemesterName", LectData.Semester), _
                New SqlParameter("@LevelName", LectData.LevelName)}
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllLecturerBySessionName", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function
    Public Function FindALLLecNameDept(ByVal CourseID As Integer) As StudentProfileData
        'instantiate object to hold user data
        Dim RetValue As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@CourseID", CourseID)}


        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindALLLecNameDept", params)
        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                If Not IsDBNull(row(0)) Then
                    RetValue.CourseDurationID = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    RetValue.SecondDeptName = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    RetValue.CountryName = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    RetValue.MiddleName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    RetValue.SessionName = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    RetValue.Semester = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    RetValue.LevelName = row(6)
                End If

            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        Return RetValue
    End Function
    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CreateLecturerAssessment(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@LectureName", Student.MiddleName), _
        New SqlParameter("@CourseName", Student.CountryName), _
        New SqlParameter("@CourseCode", Student.SecondDeptName), _
        New SqlParameter("@LevelName", Student.LevelName), _
        New SqlParameter("@SessionName", Student.SessionName), _
        New SqlParameter("@Semester", Student.Semester), _
        New SqlParameter("@PunctualToLecture", Student.OlevelSubject1), _
        New SqlParameter("@DressingManner", Student.OlevelSubject2), _
        New SqlParameter("@TeachingManner", Student.OlevelSubject3), _
        New SqlParameter("@FixesClassNotShowUp", Student.OlevelSubject4), _
        New SqlParameter("@CompleteCourseContent", Student.OlevelSubject5), _
        New SqlParameter("@AttendStudentProblem", Student.OlevelSubject6), _
        New SqlParameter("@FriendlyWithStudent", Student.OlevelSubject7), _
        New SqlParameter("@SexaullyAssaulted", Student.OlevelSubject8), _
        New SqlParameter("@MoneyToPassTest", Student.OlevelSubject9), _
        New SqlParameter("@MoneyToPassExam", Student.OlevelSubject10), _
        New SqlParameter("@MoneyToPassProject", Student.OlevelSubject11), _
        New SqlParameter("@GenerallyScore", Student.OlevelSubject12), _
        New SqlParameter("@CreatedByRegNo", Student.CreatedByRegNo), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(22).Direction = ParameterDirection.Output
        params(23).Direction = ParameterDirection.Output

        'Try
        'Create student's profile
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateLecturerAssessment", params)
        'Populate Error Code
        RetVal(0) = params(22).Value
        'Populate Error Hint
        RetVal(1) = params(23).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(22).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(23).Value
        '    Return RetVal
        'End Try
    End Function
    ''' <summary>
    ''' Fetches all Find All Student Application By Year to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllAssessLecturer(ByVal LectData As StudentProfileData) As DataSet
        Dim params() As SqlParameter = _
                {New SqlParameter("@SessionName", LectData.SessionName), _
                New SqlParameter("@Semester", LectData.Semester), _
                New SqlParameter("@LevelName", LectData.LevelName), _
                New SqlParameter("@CourseCode", LectData.CountryName)}
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        'Try
        'Fetch all RegistrationNumber.
        RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllAssessLecturer", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function
    ''' <summary>
    ''' Fetches all Find All Student Application By Year to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllAssessLecturerNO(ByVal LectData As StudentProfileData) As DataSet
        Dim params() As SqlParameter = _
                {New SqlParameter("@SessionName", LectData.SessionName), _
                New SqlParameter("@Semester", LectData.Semester), _
                New SqlParameter("@LevelName", LectData.LevelName), _
                New SqlParameter("@CourseCode", LectData.CountryName)}
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        'Try
        'Fetch all RegistrationNumber.
        RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllAssessLecturerNO", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function
    ''' <summary>
    '''Create Lecturer AssessmentNO
    ''' </summary>
    ''' <param name=""></param>
    ''' <remarks>It deletes Country record from the database </remarks>
    Public Function CreateLecturerAssessmentNO() As Integer
        'Declare and initialize data access parameters

        Try
            'Delete Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateLecturerAssessmentNO")
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    Public Function FindAllLecturerDetailsByCourseCode(ByVal CourseCode As String) As StudentProfileData
        'instantiate object to hold user data
        Dim RetValue As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@CourseCode", CourseCode)}


        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllLecturerDetailsByCourseID", params)
        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                If Not IsDBNull(row(0)) Then
                    RetValue.NextOfKin = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    RetValue.Year = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    RetValue.Total = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    RetValue.SessionName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    RetValue.LevelName = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    RetValue.Semester = row(5)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        Return RetValue
    End Function
    Public Function FindAllLecturerAssessmentByCourseDetails(ByVal RegNo As StudentProfileData) As StudentProfileData
        'instantiate object to hold user data
        Dim RetValue As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@LecturerName", RegNo.NextOfKin), _
                                        New SqlParameter("@CourseName", RegNo.Year), _
                                        New SqlParameter("@CourseCode", RegNo.Total), _
                                        New SqlParameter("@SessionName", RegNo.SessionName), _
                                        New SqlParameter("@LevelName", RegNo.LevelName), _
                                        New SqlParameter("@Semester", RegNo.Semester)}


        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllLecturerAssessmentByCourseDetails", params)
        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                If Not IsDBNull(row(0)) Then
                    RetValue.OlevelSubject1 = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    RetValue.OlevelSubject2 = row(1)
                End If

                If Not IsDBNull(row(2)) Then
                    RetValue.OlevelSubject3 = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    RetValue.OlevelSubject4 = row(3)
                End If

                If Not IsDBNull(row(4)) Then
                    RetValue.OlevelSubject5 = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    RetValue.OlevelSubject6 = row(5)
                End If

                If Not IsDBNull(row(6)) Then
                    RetValue.OlevelSubject7 = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    RetValue.OlevelSubject8 = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    RetValue.OlevelSubject9 = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    RetValue.OlevelSubject10 = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    RetValue.OlevelSubject11 = row(10)
                End If
                If Not IsDBNull(row(11)) Then
                    RetValue.OlevelSubject12 = row(11)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        Return RetValue
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCoursesBySessionID(ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal LevelID As Integer, ByVal FacultyID As Integer, ByVal DeptID As Integer, ByVal RegNo As String) As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet

        Dim params() As SqlParameter = _
       {New SqlParameter("@RegNo", RegNo), _
       New SqlParameter("@SessionID", SessionID), _
       New SqlParameter("@SemesterID", SemesterID), _
       New SqlParameter("@LevelID", LevelID), _
       New SqlParameter("@FacultyID", FacultyID), _
       New SqlParameter("@DeptID", DeptID)}

        'Try
        'Fetch all SchoolFees.
        SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesBySessionID", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCoursesBySessionID_ExtraYear(ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal LevelID As Integer, ByVal FacultyID As Integer, ByVal DeptID As Integer, ByVal RegNo As String) As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet

        Dim params() As SqlParameter = _
       {New SqlParameter("@RegNo", RegNo), _
       New SqlParameter("@SessionID", SessionID), _
       New SqlParameter("@SemesterID", SemesterID), _
       New SqlParameter("@LevelID", LevelID), _
       New SqlParameter("@FacultyID", FacultyID), _
       New SqlParameter("@DeptID", DeptID)}

        'Try
        'Fetch all SchoolFees.
        SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesBySessionID_ExtraYear", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCoursesBySessionID_Summer(ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal LevelID As Integer, ByVal FacultyID As Integer, ByVal DeptID As Integer, ByVal RegNo As String) As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet

        Dim params() As SqlParameter = _
       {New SqlParameter("@RegNo", RegNo), _
       New SqlParameter("@SessionID", SessionID), _
       New SqlParameter("@SemesterID", SemesterID), _
       New SqlParameter("@LevelID", LevelID), _
       New SqlParameter("@FacultyID", FacultyID), _
       New SqlParameter("@DeptID", DeptID)}

        'Try
        'Fetch all SchoolFees.
        SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesBySessionID_Summer", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCarryOverCoursesBySemester(ByVal RegNo As String, ByVal Semester As String) As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet

        Dim params() As SqlParameter = _
       {New SqlParameter("@RegNo", RegNo), _
       New SqlParameter("@Semester", Semester)}

        'Try
        'Fetch all SchoolFees.
        SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCarryOverCoursesBySemester", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    Public Function FindFacultyDeptByRegNo(ByVal RegNo As StudentProfileData) As StudentProfileData
        'instantiate object to hold user data
        Dim RetValue As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNo.RegNumber), _
                                        New SqlParameter("@SessionID", RegNo.SessionID), _
                                        New SqlParameter("@SemesterID", RegNo.SemesterID), _
                                        New SqlParameter("@LevelID", RegNo.LevelID)}


        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindFacultyDeptByRegNo", params)
        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                If Not IsDBNull(row(0)) Then
                    RetValue.FacultyID = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    RetValue.DeptID = row(1)
                End If

            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        Return RetValue
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCoursesByRegNoSession(ByVal RegNumber As String, ByVal Session As String, ByVal Semester As String, ByVal Level As String) As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet

        Dim params() As SqlParameter = _
       {New SqlParameter("@RegNumber", RegNumber), _
       New SqlParameter("@Session", Session), _
       New SqlParameter("@Semester", Semester), _
       New SqlParameter("@Level", Level)}

        'Try
        'Fetch all SchoolFees.
        SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByRegNoSession", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCoursesByRegNoSession_ExtraYear(ByVal RegNumber As String, ByVal Session As String, ByVal Semester As String, ByVal Level As String) As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet

        Dim params() As SqlParameter = _
       {New SqlParameter("@RegNumber", RegNumber), _
       New SqlParameter("@Session", Session), _
       New SqlParameter("@Semester", Semester), _
       New SqlParameter("@Level", Level)}

        'Try
        'Fetch all SchoolFees.
        SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByRegNoSession_ExtraYear", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCoursesByRegNoSession_Summer(ByVal RegNumber As String, ByVal Session As String, ByVal Semester As String, ByVal Level As String) As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet

        Dim params() As SqlParameter = _
       {New SqlParameter("@RegNumber", RegNumber), _
       New SqlParameter("@Session", Session), _
       New SqlParameter("@Semester", Semester), _
       New SqlParameter("@Level", Level)}

        'Try
        'Fetch all SchoolFees.
        SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByRegNoSession_Summer", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Fetches all FindAllSchoolFees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCoursesByRegNoSession_CarryOver(ByVal RegNumber As String, ByVal Session As String, ByVal Semester As String, ByVal Level As String) As DataSet
        'Holds PostUMEFee Data
        Dim SchoolFees As DataSet = New DataSet

        Dim params() As SqlParameter = _
       {New SqlParameter("@RegNumber", RegNumber), _
       New SqlParameter("@Session", Session), _
       New SqlParameter("@Semester", Semester), _
       New SqlParameter("@Level", Level)}

        'Try
        'Fetch all SchoolFees.
        SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCoursesByRegNoSession_CarryOver", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched SchoolFees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function CheckAddedCourse(ByVal RegNumber As String, ByVal Level As String, ByVal Session As String, ByVal Semester As String, ByVal CourseCode As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@Level", Level), New SqlParameter("@Session", Session), New SqlParameter("@Semester", Semester), New SqlParameter("@CourseCode", CourseCode)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CheckAddedCourse", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    studentData.RegNumber = row(0)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return studentData
    End Function
    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function CheckAddedCourse_ExtraYear(ByVal RegNumber As String, ByVal Level As String, ByVal Session As String, ByVal Semester As String, ByVal CourseCode As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@Level", Level), New SqlParameter("@Session", Session), New SqlParameter("@Semester", Semester), New SqlParameter("@CourseCode", CourseCode)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CheckAddedCourse_ExtraYear", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    studentData.RegNumber = row(0)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return studentData
    End Function
    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function CheckAddedCourse_Summer(ByVal RegNumber As String, ByVal Level As String, ByVal Session As String, ByVal Semester As String, ByVal CourseCode As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@Level", Level), New SqlParameter("@Session", Session), New SqlParameter("@Semester", Semester), New SqlParameter("@CourseCode", CourseCode)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CheckAddedCourse_Summer", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    studentData.RegNumber = row(0)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return studentData
    End Function
    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function CheckAddedCourse_CarryOver(ByVal RegNumber As String, ByVal Level As String, ByVal Session As String, ByVal Semester As String, ByVal CourseCode As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@Level", Level), New SqlParameter("@Session", Session), New SqlParameter("@Semester", Semester), New SqlParameter("@CourseCode", CourseCode)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CheckAddedCourse_CarryOver", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    studentData.RegNumber = row(0)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return studentData
    End Function
    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CheckIfLecturerHaveBeenAssess(ByVal Student As StudentProfileData) As String()

        'Declare and initialize data access parameters

        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@LevelName", Student.LevelName), _
        New SqlParameter("@SessionName", Student.SessionName), _
        New SqlParameter("@Semester", Student.Semester), _
        New SqlParameter("@CreatedByRegNo", Student.CreatedByRegNo), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(7).Direction = ParameterDirection.Output
        params(8).Direction = ParameterDirection.Output

        Try
            'Create student's profile
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CheckIfLecturerHaveBeenAssess", params)
            'Populate Error Code
            RetVal(0) = params(7).Value
            'Populate Error Hint
            RetVal(1) = params(8).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(7).Value
            'Populate Error Hint
            RetVal(1) = params(8).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Fetches all Find All Student Application By Year to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllRegNoByFacutlyIDDeptID(ByVal FacultyID As Integer, ByVal DeptID As Integer) As DataSet
        Dim params() As SqlParameter = _
                {New SqlParameter("@FacultyID", FacultyID), _
                New SqlParameter("@DeptID", DeptID)}
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllRegNoByFacutlyIDDeptID", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function
    ''' <summary>
    ''' Updates RegistrationNumber Data
    ''' </summary>
    ''' <param name="RegistrationNumber"></param>
    ''' <remarks>It updates the database using StudentProfileData</remarks>
    Public Function UpdateRegNumber(ByVal OldRegistrationNumber As String, ByVal RegistrationNumber As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@OldRegistrationNumber", OldRegistrationNumber), _
        New SqlParameter("@RegistrationNumber", RegistrationNumber)}
        Try
            'Modify RegistrationNumber data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateRegNumber", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Updates RegistrationNumber Data
    ''' </summary>
    ''' <param name="StudentProfile"></param>
    ''' <remarks>It updates the database using StudentProfileData</remarks>
    Public Function LoadRegNumber(ByVal StudentProfile As StudentProfileData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", StudentProfile.SessionID), _
        New SqlParameter("@SemesterID", StudentProfile.SemesterID), _
        New SqlParameter("@LevelID", StudentProfile.LevelID), _
        New SqlParameter("@FacultyID", StudentProfile.FacultyID), _
        New SqlParameter("@DeptID", StudentProfile.DeptID)}
        Try
            'Modify RegistrationNumber data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "LoadRegNumber", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Updates RegistrationNumber Data
    ''' </summary>
    ''' <param name="StudentProfile"></param>
    ''' <remarks>It updates the database using StudentProfileData</remarks>
    Public Function LoadResultRegNumber(ByVal StudentProfile As StudentProfileData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", StudentProfile.SessionID), _
        New SqlParameter("@SemesterID", StudentProfile.SemesterID), _
        New SqlParameter("@LevelID", StudentProfile.LevelID), _
        New SqlParameter("@FacultyID", StudentProfile.FacultyID), _
        New SqlParameter("@DeptID", StudentProfile.DeptID)}
        Try
            'Modify RegistrationNumber data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "LoadResultRegNumber", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Updates RegistrationNumber Data
    ''' </summary>
    ''' <param name="StudentProfile"></param>
    ''' <remarks>It updates the database using StudentProfileData</remarks>
    Public Function LoadResulRegNumber(ByVal StudentProfile As StudentProfileData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", StudentProfile.SessionID), _
        New SqlParameter("@SemesterID", StudentProfile.SemesterID), _
        New SqlParameter("@LevelID", StudentProfile.LevelID), _
        New SqlParameter("@FacultyID", StudentProfile.FacultyID), _
        New SqlParameter("@DeptID", StudentProfile.DeptID)}
        Try
            'Modify RegistrationNumber data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "LoadResulRegNumber", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Fetches all RegistrationNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllRegNos() As DataSet
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllRegNos")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function

    ''' <summary>
    ''' Fetches all RegistrationNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllResultRegNos() As DataSet
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllResultRegNos")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function
    ''' <summary>
    ''' Updates RegistrationNumber Data
    ''' </summary>
    ''' <param name="StdData"></param>
    ''' <remarks>It updates the database using StudentProfileData</remarks>
    Public Function UploadPINRegNumber(ByVal StdData As StudentProfileData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", StdData.SessionID), _
        New SqlParameter("@SemesterID", StdData.SemesterID), _
        New SqlParameter("@LevelID", StdData.LevelID), _
        New SqlParameter("@DeptID", StdData.DeptID), _
        New SqlParameter("@FacultyID", StdData.FacultyID), _
        New SqlParameter("@Password", StdData.Password), _
        New SqlParameter("@RegNumber", StdData.RegNumber)}
        Try
            'Modify RegistrationNumber data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UploadPINRegNumber", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Updates RegistrationNumber Data
    ''' </summary>
    ''' <param name="StdData"></param>
    ''' <remarks>It updates the database using StudentProfileData</remarks>
    Public Function UploadResultPINRegNumber(ByVal StdData As StudentProfileData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", StdData.SessionID), _
        New SqlParameter("@SemesterID", StdData.SemesterID), _
        New SqlParameter("@LevelID", StdData.LevelID), _
        New SqlParameter("@DeptID", StdData.DeptID), _
        New SqlParameter("@FacultyID", StdData.FacultyID), _
        New SqlParameter("@Password", StdData.Password), _
        New SqlParameter("@RegNumber", StdData.RegNumber)}
        Try
            'Modify RegistrationNumber data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UploadResultPINRegNumber", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Fetches all RegistrationNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindListOfPINRegNo(ByVal StdData As StudentProfileData) As DataSet
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", StdData.SessionID), _
        New SqlParameter("@SemesterID", StdData.SemesterID), _
        New SqlParameter("@LevelID", StdData.LevelID), _
        New SqlParameter("@DeptID", StdData.DeptID), _
        New SqlParameter("@FacultyID", StdData.FacultyID)}
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindListOfPINRegNo", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function
    ''' <summary>
    ''' Fetches all RegistrationNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindListOfResultPINRegNo(ByVal StdData As StudentProfileData) As DataSet
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", StdData.SessionID), _
        New SqlParameter("@SemesterID", StdData.SemesterID), _
        New SqlParameter("@LevelID", StdData.LevelID), _
        New SqlParameter("@DeptID", StdData.DeptID), _
        New SqlParameter("@FacultyID", StdData.FacultyID)}
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindListOfResultPINRegNo", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function
    Public Function FindSchoolFeesByPINRegNo(ByVal RegNo As StudentProfileData) As StudentProfileData
        'instantiate object to hold user data
        Dim RetValue As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNo.RegNumber), _
                                        New SqlParameter("@PIN", RegNo.Password)}


        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindSchoolFeesByPINRegNo", params)
        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                If Not IsDBNull(row(0)) Then
                    RetValue.RegNumber = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    RetValue.Password = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    RetValue.Semester = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    RetValue.SessionName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    RetValue.LevelName = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    RetValue.DeptName = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    RetValue.FacultyName = row(6)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        Return RetValue
    End Function
    Public Function FindResultSchoolFeesByPINRegNo(ByVal RegNo As StudentProfileData) As StudentProfileData
        'instantiate object to hold user data
        Dim RetValue As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNo.RegNumber), _
                                        New SqlParameter("@PIN", RegNo.Password)}


        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindResultSchoolFeesByPINRegNo", params)
        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                If Not IsDBNull(row(0)) Then
                    RetValue.RegNumber = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    RetValue.Password = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    RetValue.Semester = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    RetValue.SessionName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    RetValue.LevelName = row(4)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        Return RetValue
    End Function
    ''' <summary>
    ''' Finds RegNo by RegNo
    ''' </summary>
    ''' <param name="StudentData"></param>
    ''' <returns>UsersData</returns>
    ''' <remarks>Takes UserName as parameter and return UsersData</remarks>
    Public Function FindResultPayment(ByVal StudentData As StudentProfileData) As StudentProfileData
        'instantiate object to hold user data
        Dim StudentProfileData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@SessionID", StudentData.SessionID), _
                                        New SqlParameter("@SemesterID", StudentData.SemesterID), _
                                        New SqlParameter("@LevelID", StudentData.LevelID), _
                                        New SqlParameter("@RegNumber", StudentData.RegNumber)}


        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindResultPayment", params)
        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                StudentProfileData.ETransactionPinID = row(0)
                StudentProfileData.ETransactPin = row(1)
                If Not IsDBNull(row(2)) Then
                    StudentProfileData.RegNumber = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    StudentProfileData.LevelID = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    StudentProfileData.SessionID = row(4)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        Return StudentProfileData
    End Function

    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="PIN"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindAllPINByPIN(ByVal PIN As String, ByVal RegNumber As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@PIN", PIN), New SqlParameter("@RegNumber", RegNumber)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindPINByPIN", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                studentData.ETransactPin = row(0)
                studentData.Activate = row(1)
                If Not IsDBNull(row(2)) Then
                    studentData.SessionID = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    studentData.SessionName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    studentData.LevelID = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    studentData.LevelName = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    studentData.SemesterID = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    studentData.Semester = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    studentData.FacultyID = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    studentData.FacultyName = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    studentData.DeptID = row(10)
                End If
                If Not IsDBNull(row(11)) Then
                    studentData.DeptName = row(11)
                End If
                If Not IsDBNull(row(12)) Then
                    studentData.NewSaltKey = row(12)
                End If
                If Not IsDBNull(row(13)) Then
                    studentData.RegNumber = row(13)
                End If

            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return studentData
    End Function
    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="PIN"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindResultPINByPIN(ByVal PIN As String, ByVal RegNumber As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@PIN", PIN), New SqlParameter("@RegNumber", RegNumber)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindResultPINByPIN", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                studentData.ETransactPin = row(0)
                studentData.Activate = row(1)
                If Not IsDBNull(row(2)) Then
                    studentData.SessionID = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    studentData.SessionName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    studentData.LevelID = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    studentData.LevelName = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    studentData.SemesterID = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    studentData.Semester = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    studentData.FacultyID = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    studentData.FacultyName = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    studentData.DeptID = row(10)
                End If
                If Not IsDBNull(row(11)) Then
                    studentData.DeptName = row(11)
                End If
                If Not IsDBNull(row(12)) Then
                    studentData.NewSaltKey = row(12)
                End If
                If Not IsDBNull(row(13)) Then
                    studentData.RegNumber = row(13)
                End If

            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return studentData
    End Function

    ''' <summary>
    ''' Generate Pin
    ''' </summary>
    ''' <param name="SessionID"></param>
    ''' <returns>Student</returns>
    ''' <remarks>Generate Pin</remarks>
    Public Function UploadPin(ByVal UploadedPIN As String, ByVal RegNumber As String, ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal FacultyID As Integer, ByVal DeptID As Integer, ByVal LevelID As Integer, ByVal CreatedByUID As Integer) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@UploadedPIN", UploadedPIN), _
        New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@SessionID", SessionID), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@FacultyID", FacultyID), _
        New SqlParameter("@DeptID", DeptID), _
        New SqlParameter("@LevelID", LevelID), _
        New SqlParameter("@CreatedByUID", CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(10).Direction = ParameterDirection.Output
        params(11).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadNewPinNumber", params)
        'Populate Error Code
        RetVal(0) = params(10).Value
        'Populate Error Hint
        RetVal(1) = params(11).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(7).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(8).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Generate Pin
    ''' </summary>
    ''' <param name="UploadedPIN"></param>
    ''' <returns>Student</returns>
    ''' <remarks>Generate Pin</remarks>
    Public Function UploadPin_New(ByVal UploadedPIN As String, ByVal SerialNo As String, ByVal CreatedByUID As Integer) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim TxnFlag As String = "N"
        Dim ErrorFlag As String = "N"

        Dim params() As SqlParameter = _
        {New SqlParameter("@UploadedPIN", UploadedPIN), _
         New SqlParameter("@SerialNo", SerialNo), _
        New SqlParameter("@CreatedByUID", CreatedByUID), _
        New SqlParameter("@LogTxnFlag", TxnFlag), _
        New SqlParameter("@LogErrorFlag", ErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadNewPinNumber_New", params)
        'Populate Error Code
        RetVal(0) = params(5).Value
        'Populate Error Hint
        RetVal(1) = params(6).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = "101"
        '    'Populate Error Hint
        '    RetVal(1) = "Table Name: ETransactPin"

        '    Return RetVal
        'End Try
    End Function
    ''' <summary>
    ''' Generate Pin
    ''' </summary>
    ''' <param name="SessionID"></param>
    ''' <returns>Student</returns>
    ''' <remarks>Generate Pin</remarks>
    Public Function UploadResultPin(ByVal UploadedResultPIN As String, ByVal RegNumber As String, ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal FacultyID As Integer, ByVal DeptID As Integer, ByVal LevelID As Integer, ByVal CreatedByUID As Integer) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@UploadedResultPIN", UploadedResultPIN), _
        New SqlParameter("@RegNumber", RegNumber), _
        New SqlParameter("@SessionID", SessionID), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@FacultyID", FacultyID), _
        New SqlParameter("@DeptID", DeptID), _
        New SqlParameter("@LevelID", LevelID), _
        New SqlParameter("@CreatedByUID", CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(10).Direction = ParameterDirection.Output
        params(11).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadNewResultPinNumber", params)
        'Populate Error Code
        RetVal(0) = params(10).Value
        'Populate Error Hint
        RetVal(1) = params(11).Value

        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(7).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(8).Value
        '    'Populate StudentProfileID
        'End Try
    End Function
    ''' <summary>
    ''' Generate Pin
    ''' </summary>
    ''' <param name="UploadedResultPIN"></param>
    ''' <returns>Student</returns>
    ''' <remarks>Generate Pin</remarks>
    Public Function UploadResultPin_New(ByVal UploadedResultPIN As String, ByVal SerialNo As String, ByVal CreatedByUID As Integer) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters
        Dim TxnFlag As String = "N"
        Dim ErrorFlag As String = "N"

        Dim params() As SqlParameter = _
        {New SqlParameter("@UploadedResultPIN", UploadedResultPIN), _
        New SqlParameter("@SerialNo", SerialNo), _
        New SqlParameter("@CreatedByUID", CreatedByUID), _
        New SqlParameter("@LogTxnFlag", TxnFlag), _
        New SqlParameter("@LogErrorFlag", ErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UploadNewResultPinNumber_New", params)
            'Populate Error Code
            RetVal(0) = params(5).Value
            'Populate Error Hint
            RetVal(1) = params(6).Value

            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = "101"
            'Populate Error Hint
            RetVal(1) = "Table Name: ResultETransactPin"
            'Populate StudentProfileID

            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="RegNo"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllNonUsePINByRegNoPIN(ByVal RegNo As String, ByVal PIN As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNo", RegNo), New SqlParameter("@PIN", PIN)}
        'Try
        'Fetch all item based on LevelID and SemesterID
        DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllNonUsePINByRegNoPIN", params)

        Return DeptReultDataSet

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Finds Course code with levelid and semesterid
    ''' </summary>
    ''' <param name="RegNo"></param>
    ''' <returns>SessionLevelSemesterCourseData</returns>
    ''' <remarks>It takes Course LevelID, SemesterID, then returns SessionLevelSemesterCourseData </remarks>
    Public Function FindAllNonUseResultPINByRegNoPIN(ByVal RegNo As String, ByVal PIN As String) As DataSet
        'Declaring the dataset
        Dim DeptReultDataSet As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNo", RegNo), New SqlParameter("@PIN", PIN)}
        'Try
        'Fetch all item based on LevelID and SemesterID
        DeptReultDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllNonUseResultPINByRegNoPIN", params)

        Return DeptReultDataSet

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Session
    ''' </summary>
    ''' <param name="PhoneNumber"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SessionLevelSemesterCourseData using Session</remarks>
    Public Function EditPhoneNumber(ByVal PhoneNumber As String, ByVal OldPhoneNumber As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@PhoneNumber", PhoneNumber), New SqlParameter("@OldPhoneNumber", OldPhoneNumber)}
        Try
            'Create Session data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "EditPhoneNumber", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="LevelID"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CreateCourseCode(ByVal CourseCode As String, ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal LevelID As Integer) As Integer
        Dim params() As SqlParameter = _
        {New SqlParameter("@CourseCode", CourseCode), _
         New SqlParameter("@SessionID", SessionID), _
         New SqlParameter("@SemesterID", SemesterID), _
         New SqlParameter("@LevelID", LevelID)}
        Try
            'Create student's profile
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateCourseCode", params)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Fetches all RegistrationNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllPhonePIN(ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal LevelID As Integer) As DataSet
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SessionID", SessionID), _
                                        New SqlParameter("@SemesterID", SemesterID), _
                                        New SqlParameter("@LevelID", LevelID)}
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllPhonePIN", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function

    ''' <summary>
    ''' Fetches all RegistrationNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllPhoneResultPIN(ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal LevelID As Integer) As DataSet
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SessionID", SessionID), _
                                        New SqlParameter("@SemesterID", SemesterID), _
                                        New SqlParameter("@LevelID", LevelID)}
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllPhoneResultPIN", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function

    ''' <summary>
    ''' Fetches all RegistrationNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllStudentsBySessionIDSemesterIDLevelID(ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal LevelID As Integer) As DataSet
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SessionID", SessionID), _
                                        New SqlParameter("@SemesterID", SemesterID), _
                                        New SqlParameter("@LevelID", LevelID)}
        ' Try
        'Fetch all RegistrationNumber.
        RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStudentsBySessionIDSemesterIDLevelID", params)
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function
    ''' <summary>
    ''' Fetches all Find All Student Application By Year to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllRegNoBySessionIDSemesterIDLevelID(ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal LevelID As Integer) As DataSet
        Dim params() As SqlParameter = _
                {New SqlParameter("@SessionID", SessionID), _
                 New SqlParameter("@SemesterID", SemesterID), _
                New SqlParameter("@LevelID", LevelID)}
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllRegNoBySessionIDSemesterIDLevelID", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return RegistrationNumber
    End Function

    ''' <summary>
    ''' Creates a Student Profile
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <returns>Student</returns>
    ''' <remarks>It creates StudentProfileData using Student</remarks>
    Public Function CreateCheckMoveStudentData(ByVal Student As StudentProfileData) As Integer

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@Surname", Student.Surname), _
        New SqlParameter("@Firstname", Student.Firstname), _
        New SqlParameter("@LevelID", Student.LevelID), _
        New SqlParameter("@SessionID", Student.SessionID), _
        New SqlParameter("@SemesterID", Student.SemesterID), _
        New SqlParameter("@Ticked", Student.Sitting)}

        Try
            'Create student's profile
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateCheckMoveStudentData", params)
            Return 1
        Catch ex As Exception
            Return 0
        End Try

    End Function

    ''' <summary>
    ''' Generate Pin
    ''' </summary>
    ''' <param name="SessionID"></param>
    ''' <returns>Student</returns>
    ''' <remarks>Generate Pin</remarks>
    Public Function MovedStudentData(ByVal SessionID As Integer, ByVal SemesterID As Integer, ByVal LevelID As Integer) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@SessionID", SessionID), _
        New SqlParameter("@SemesterID", SemesterID), _
        New SqlParameter("@LevelID", LevelID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output
        ' Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_MovedStudentData", params)
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
    ''' Updates Course Data
    ''' </summary>
    ''' <param name="StudentData"></param>
    ''' <remarks>It updates the database using SessionLevelSemesterCourseData</remarks>
    Public Function UpdateResultPIN(ByVal StudentData As StudentProfileData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ETransactionPinID", StudentData.ETransactPin), _
         New SqlParameter("@RegNumber", StudentData.RegNumber), _
         New SqlParameter("@SessionID", StudentData.SessionID), _
         New SqlParameter("@SemesterID", StudentData.SemesterID)}
        Try
            'Modify Course data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateResultPIN", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Active Student's transaction pin
    ''' </summary>
    ''' <param name="Student"></param>
    ''' <remarks>Active student's transaction pin</remarks>
    Public Function CheckSchoolFeesPIN_New(ByVal Student As StudentProfileData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", "", "", "", ""}

        Dim TxnFlag As String = "N"
        Dim ErrorFlag As String = "N"

        Dim params() As SqlParameter = _
        {New SqlParameter("@ETransactionPinID", Student.ETransactPin), _
        New SqlParameter("@RegNumber", Student.RegNumber), _
        New SqlParameter("@SessionID", Student.SessionID), _
        New SqlParameter("@SemesterID", Student.SemesterID), _
        New SqlParameter("@LogTxnFlag", TxnFlag), _
        New SqlParameter("@LogErrorFlag", ErrorFlag), _
        New SqlParameter("@CreatedByRegNo", Student.RegNumber), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
        New SqlParameter("@SessionName", SqlDbType.VarChar, 250), _
        New SqlParameter("@SemesterName", SqlDbType.VarChar, 250), _
        New SqlParameter("@LevelName", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(7).Direction = ParameterDirection.Output
        params(8).Direction = ParameterDirection.Output
        params(9).Direction = ParameterDirection.Output
        params(10).Direction = ParameterDirection.Output
        params(11).Direction = ParameterDirection.Output

        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CheckSchoolFeesPIN_New", params)
            'Populate Error Code
            RetVal(0) = params(7).Value
            'Populate Error Hint
            RetVal(1) = params(8).Value
            'Populate Error Hint
            RetVal(2) = params(9).Value
            'Populate Error Hint
            RetVal(3) = params(10).Value
            'Populate Error Hint
            RetVal(4) = params(11).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            'Populate Error Code
            RetVal(0) = "101"
            'Populate Error Hint
            RetVal(1) = "Transaction Name: STUDENT_PIN"
            'Populate Error Hint
            RetVal(2) = ""
            'Populate Error Hint
            RetVal(3) = ""
            'Populate Error Hint
            RetVal(4) = ""
            Return RetVal
        End Try
    End Function

    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindLevelByRegNumber(ByVal RegNumber As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindLevelByRegNumber", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    studentData.LevelID = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    studentData.LevelName = row(1)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return studentData
    End Function

    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function CheckForSchoolFeesPayment(ByVal RegNumber As String, ByVal SessionID As Integer, ByVal SemesterID As Integer) As String
        'instantiate object to hold user data
        Dim CheckPayment As String = ""

        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@SessionID", SessionID), New SqlParameter("@SemesterID", SemesterID)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CheckForSchoolFeesPayment", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    CheckPayment = row(0)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return CheckPayment
    End Function

    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="regNumber"></param>
    ''' <returns>regNumber</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindPhoneNobyRegNumber(ByVal regNumber As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@regNumber", regNumber)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindPhoneNobyRegNumber", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    studentData.PhoneNumber = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    studentData.Surname = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    studentData.Firstname = row(2)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return studentData
    End Function

    ''' <summary>
    ''' Search For Student by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindStudentByRegNumberForHomePage(ByVal RegNumber As String) As StudentProfileData
        'instantiate object to hold user data
        Dim studentData As StudentProfileData = New StudentProfileData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStudentByRegNumberForHomePage", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                If Not IsDBNull(row(0)) Then
                    studentData.RegNumber = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    studentData.Surname = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    studentData.Firstname = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    studentData.PhotoUrl = row(3)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)

        'End Try
        Return studentData
    End Function
End Class
