Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Net
Public Class StudentDAL
    Inherits DataAccessBase
    
    ''' <summary>
    ''' Creates a Profile
    ''' </summary>
    ''' <param name="Profile"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates CountryStateLGAData using dept</remarks>
    Public Function CreateStudentProfiles(ByVal Profile As StudentData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", Profile.RegNumber), _
        New SqlParameter("@Surname", Profile.Surname), _
        New SqlParameter("@FirstName", Profile.FirstName), _
        New SqlParameter("@MiddleName", Profile.MiddleName), _
        New SqlParameter("@MothersMaidenName", Profile.MothersMaidenName), _
        New SqlParameter("@DateOfBirth", Profile.DOB), _
        New SqlParameter("@Sex", Profile.Sex), _
        New SqlParameter("@StateID", Profile.StateID), _
        New SqlParameter("@LGAID", Profile.LGAID), _
        New SqlParameter("@PermenentHomeAddr", Profile.HomeAddress), _
        New SqlParameter("@PhoneNumber", Profile.PhoneNumber), _
        New SqlParameter("@Email", Profile.Email), _
        New SqlParameter("@NOKName", Profile.NOKName), _
        New SqlParameter("@NOKPhoneNumber", Profile.NOKPhoneNumber), _
        New SqlParameter("@NOKAddress", Profile.NOKAddress), _
        New SqlParameter("@SessionID", Profile.SessionID), _
        New SqlParameter("@SemesterID", Profile.SemesterID), _
        New SqlParameter("@LevelID", Profile.LevelID), _
        New SqlParameter("@LPS", Profile.LPS), _
        New SqlParameter("@LPS_From", Profile.LPSFrom), _
        New SqlParameter("@LPS_To", Profile.LPSTo), _
        New SqlParameter("@LSA", Profile.LSA), _
        New SqlParameter("@LSA_From", Profile.LSAFrom), _
        New SqlParameter("@LSA_To", Profile.LSATo), _
        New SqlParameter("@PhotoUrl", Profile.PhotoURL), _
        New SqlParameter("@Passwords", Profile.Passwords), _
        New SqlParameter("@SaltKey", Profile.SaltKey)}
        'Try
        'Create Country data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateStudentProfiles", params) 
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return 0
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' Creates a Profile
    ''' </summary>
    ''' <param name="Profile"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates CountryStateLGAData using dept</remarks>
    Public Function UploadStudentProfiles(ByVal Profile As StudentData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter =
        {New SqlParameter("@RegNumber", Profile.RegNumber),
        New SqlParameter("@Surname", Profile.Surname),
        New SqlParameter("@FirstName", Profile.FirstName),
        New SqlParameter("@SessionID", Profile.SessionID),
        New SqlParameter("@SemesterID", Profile.SemesterID),
        New SqlParameter("@LevelID", Profile.LevelID)}
        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UploadStudentProfiles", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a Profile
    ''' </summary>
    ''' <param name="Profile"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates CountryStateLGAData using dept</remarks>
    Public Function UpdateStudentProgram(ByVal Profile As StudentData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter =
        {New SqlParameter("@RegNumber", Profile.RegNumber),
        New SqlParameter("@Surname", Profile.Surname),
        New SqlParameter("@FirstName", Profile.FirstName),
        New SqlParameter("@SessionID", Profile.SessionID),
        New SqlParameter("@SemesterID", Profile.SemesterID),
        New SqlParameter("@LevelID", Profile.LevelID)}
        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateStudentProgram", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    Public Function FindStudentByRegNo(ByVal RegNumber As String) As StudentData
        'instantiate object to hold user data
        Dim userData As StudentData = New StudentData

        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}
        'specify output parameters.

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStudentByRegNo", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    userData.StudentProfileID = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    userData.RegNumber = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    userData.Surname = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    userData.FirstName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    userData.MiddleName = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    userData.MothersMaidenName = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    userData.DOB = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    userData.Sex = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    userData.StateID = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    userData.StateName = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    userData.LGAID = row(10)
                End If
                If Not IsDBNull(row(11)) Then
                    userData.LGAName = row(11)
                End If
                If Not IsDBNull(row(12)) Then
                    userData.HomeAddress = row(12)
                End If
                If Not IsDBNull(row(13)) Then
                    userData.PhoneNumber = row(13)
                End If
                If Not IsDBNull(row(14)) Then
                    userData.Email = row(14)
                End If
                If Not IsDBNull(row(15)) Then
                    userData.NOKName = row(15)
                End If
                If Not IsDBNull(row(16)) Then
                    userData.SessionID = row(16)
                End If
                If Not IsDBNull(row(17)) Then
                    userData.SessionName = row(17)
                End If
                If Not IsDBNull(row(18)) Then
                    userData.SemesterID = row(18)
                End If
                If Not IsDBNull(row(19)) Then
                    userData.Semester = row(19)
                End If
               
                If Not IsDBNull(row(20)) Then
                    userData.LevelID = row(20)
                End If
                If Not IsDBNull(row(21)) Then
                    userData.Level = row(21)
                End If
                If Not IsDBNull(row(22)) Then
                    userData.LPS = row(22)
                End If
                If Not IsDBNull(row(23)) Then
                    userData.LPSFrom = row(23)
                End If
                If Not IsDBNull(row(24)) Then
                    userData.LPSTo = row(24)
                End If
                If Not IsDBNull(row(25)) Then
                    userData.LSA = row(25)
                End If
                If Not IsDBNull(row(26)) Then
                    userData.LSAFrom = row(26)
                End If
                If Not IsDBNull(row(27)) Then
                    userData.LSATo = row(27)
                End If
                If Not IsDBNull(row(28)) Then
                    userData.PhotoURL = row(28)
                End If
                If Not IsDBNull(row(29)) Then
                    userData.Passwords = row(29)
                End If
                If Not IsDBNull(row(30)) Then
                    userData.SaltKey = row(30)
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
        Return userData
    End Function
    Public Function FindStudentNameByRegNo(ByVal RegNumber As String) As StudentData
        'instantiate object to hold user data
        Dim userData As StudentData = New StudentData

        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}
        'specify output parameters.

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStudentNameByRegNo", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        userData.StudentProfileID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        userData.RegNumber = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        userData.Surname = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        userData.FirstName = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        userData.SessionID = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        userData.SessionName = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        userData.SemesterID = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        userData.Semester = row(7)
                    End If
                    
                    If Not IsDBNull(row(8)) Then
                        userData.LevelID = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        userData.Level = row(9)
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
        Return userData
    End Function

    Public Function FindStudentNameByRegNoUsingArray(ByVal RegNumber As String) As ArrayList
        'instantiate object to hold user data
        Dim StudentData As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber)}


        StudentData = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindStudentNameByRegNo", params)

        For Each row As DataRow In StudentData.Tables(0).Rows
            QueueList.Add(New StudentArrayData(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9)))
        Next

        Return QueueList
    End Function

    ''' <summary>
    ''' Creates a Profile
    ''' </summary>
    ''' <param name="NewRegNumber"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates UpdateRegNumber using dept</remarks>
    Public Function UpdateRegNumber(ByVal RegNumber As String, ByVal NewRegNumber As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@NewRegNumber", NewRegNumber), _
        New SqlParameter("@OldegNumber", RegNumber)}
        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateRegNumber", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Creates a Profile
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates UpdateRegNumber using dept</remarks>
    Public Function ResetPassword(ByVal RegNumber As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter =
        {New SqlParameter("@RegNumber", RegNumber)}
        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "ResetPassword", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    Public Function CheckIfStudentExist(ByVal RegNumber As String) As Integer
        'instantiate object to hold user data
        Dim reVal As Integer = 0

        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}
        'specify output parameters.

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CheckIfStudentExist", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        reVal = row(0)
                    End If
                Next
            Else
                Return 0
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
            Return 0
        End Try
        Return reVal
    End Function
End Class
