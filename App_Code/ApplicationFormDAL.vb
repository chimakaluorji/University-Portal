Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Net

Public Class ApplicationFormDAL
    Inherits DataAccessBase
    ''' <summary>
    ''' Creates a StudentData
    ''' </summary>
    ''' <param name="StudentData"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates CountryStateLGAData using dept</remarks>
    Public Function CreateApplicationForm(ByVal StudentData As ApplicationFormData) As String
        Dim RetValue As String = ""
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
       {New SqlParameter("@AppliedProgramme", StudentData.AppliedProgramme), _
       New SqlParameter("@SessionID", StudentData.SessionID), _
       New SqlParameter("@ProgrammeID", StudentData.ProgrammeID), _
       New SqlParameter("@Surname", StudentData.Surname), _
       New SqlParameter("@FirstName", StudentData.FirstName), _
       New SqlParameter("@MiddleName", StudentData.MiddleName), _
       New SqlParameter("@MaidenName", StudentData.MaidenName), _
       New SqlParameter("@HomeAddress", StudentData.HomeAddress), _
       New SqlParameter("@PhoneNumber", StudentData.PhoneNumber), _
       New SqlParameter("@StateID", StudentData.StateID), _
       New SqlParameter("@MaritalStatus", StudentData.MaritalStatus), _
       New SqlParameter("@Gender", StudentData.Gender), _
       New SqlParameter("@NoKName", StudentData.NoKName), _
       New SqlParameter("@NoKRelationship", StudentData.NoKRelationship), _
       New SqlParameter("@ENoKHomeAddress", StudentData.NoKHomeAddress), _
       New SqlParameter("@ENokPhoneNumber", StudentData.NokPhoneNumber), _
       New SqlParameter("@ExamNumberOne", StudentData.ExamNumberOne), _
       New SqlParameter("@YearOne", StudentData.YearOne), _
       New SqlParameter("@SchoolOne", StudentData.SchoolOne), _
       New SqlParameter("@ExamNumberTwo", StudentData.ExamNumberTwo), _
       New SqlParameter("@YearTwo", StudentData.YearTwo), _
       New SqlParameter("@SchoolTwo", StudentData.SchoolTwo), _
       New SqlParameter("@NameOfInstitution", StudentData.NameOfInstitution), _
       New SqlParameter("@Department", StudentData.Department), _
       New SqlParameter("@RegNumber", StudentData.RegNumber), _
       New SqlParameter("@YearOfAdmission", StudentData.YearOfAdmission), _
       New SqlParameter("@DateOfGraduation", StudentData.DateOfGraduation), _
       New SqlParameter("@ModeOfAdmission", StudentData.ModeOfAdmission), _
       New SqlParameter("@GradeOfPass", StudentData.GradeOfPass), _
       New SqlParameter("@FieldOfStudy", StudentData.FieldOfStudy), _
       New SqlParameter("@ProfessionalCert", StudentData.ProfessionalCert), _
       New SqlParameter("@Subject1", StudentData.Subject1), _
       New SqlParameter("@Grade1", StudentData.Grade1), _
       New SqlParameter("@Subject2", StudentData.Subject2), _
       New SqlParameter("@Grade2", StudentData.Grade2), _
       New SqlParameter("@Subject3", StudentData.Subject3), _
       New SqlParameter("@Grade3", StudentData.Grade3), _
       New SqlParameter("@Subject4", StudentData.Subject4), _
       New SqlParameter("@Grade4", StudentData.Grade4), _
       New SqlParameter("@Subject5", StudentData.Subject5), _
       New SqlParameter("@Grade5", StudentData.Grade5), _
       New SqlParameter("@Subject6", StudentData.Subject6), _
       New SqlParameter("@Grade6", StudentData.Grade6), _
       New SqlParameter("@Subject7", StudentData.Subject7), _
       New SqlParameter("@Grade7", StudentData.Grade7), _
       New SqlParameter("@Subject8", StudentData.Subject8), _
       New SqlParameter("@Grade8", StudentData.Grade8), _
       New SqlParameter("@Subject9", StudentData.Subject9), _
       New SqlParameter("@Grade9", StudentData.Grade9), _
       New SqlParameter("@Subject10", StudentData.Subject10), _
       New SqlParameter("@Grade10", StudentData.Grade10), _
       New SqlParameter("@Subject11", StudentData.Subject11), _
       New SqlParameter("@Grade11", StudentData.Grade11), _
       New SqlParameter("@Subject12", StudentData.Subject12), _
       New SqlParameter("@Grade12", StudentData.Grade12), _
       New SqlParameter("@Subject13", StudentData.Subject13), _
       New SqlParameter("@Grade13", StudentData.Grade13), _
       New SqlParameter("@Subject14", StudentData.Subject14), _
       New SqlParameter("@Grade14", StudentData.Grade14), _
       New SqlParameter("@Subject15", StudentData.Subject15), _
       New SqlParameter("@Grade15", StudentData.Grade15), _
       New SqlParameter("@Subject16", StudentData.Subject16), _
       New SqlParameter("@Grade16", StudentData.Grade16), _
       New SqlParameter("@Subject17", StudentData.Subject17), _
       New SqlParameter("@Grade17", StudentData.Grade17), _
       New SqlParameter("@Subject18", StudentData.Subject18), _
       New SqlParameter("@Grade18", StudentData.Grade18), _
       New SqlParameter("@AcademicDistinctions", StudentData.AcademicDistinctions), _
       New SqlParameter("@Employment", StudentData.Employment), _
       New SqlParameter("@NameFirstReferee", StudentData.NameFirstReferee), _
       New SqlParameter("@PositionFirstReferee", StudentData.PositionFirstReferee), _
       New SqlParameter("@AddressFirstReferee", StudentData.AddressFirstReferee), _
       New SqlParameter("@NameSecondReferee", StudentData.NameSecondReferee), _
       New SqlParameter("@PositionSecondReferee", StudentData.PositionSecondReferee), _
       New SqlParameter("@AddressSecondReferee", StudentData.AddressSecondReferee), _
       New SqlParameter("@NameThirdReferee", StudentData.NameThirdReferee), _
       New SqlParameter("@PositionThirdReferee", StudentData.PositionThirdReferee), _
       New SqlParameter("@AddressThirdReferee", StudentData.AddressThirdReferee), _
       New SqlParameter("@DoB", StudentData.DoB), _
       New SqlParameter("@RetApplicationNumber", SqlDbType.VarChar, 250)}


        params(79).Direction = ParameterDirection.Output


        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateApplicationForm", params)

            RetValue = params(79).Value
            Return RetValue
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return RetValue
        End Try
    End Function
    ''' <summary>
    ''' Fetches all Find All Student Application By Year to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function ApplicationFormByApplicationNumber(ByVal ApplicationNumber As String) As DataSet
        Dim params() As SqlParameter = _
                {New SqlParameter("@ApplicationNumber", ApplicationNumber)}
        'Holds RegistrationNumber Data
        Dim RegistrationNumber As DataSet = New DataSet
        Try
            'Fetch all RegistrationNumber.
            RegistrationNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "ApplicationFormByApplicationNumber", params)
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
    ''' <param name="AppNo"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>Takes RegNumber as parameter and return StudentProfileData</remarks>
    Public Function FindApplicationByAppNo(ByVal AppNo As String) As ApplicationFormData
        'instantiate object to hold user data
        Dim studentData As ApplicationFormData = New ApplicationFormData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@AppNo", AppNo)}

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindApplicationByAppNo", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                If Not IsDBNull(row(0)) Then
                    studentData.ApplicationNumber = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    studentData.Surname = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    studentData.FirstName = row(2)
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
    ''' <summary>
    ''' Fetches all Find All Student Application By Year to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAppFormConfirmedBySessionID(ByVal SessionID As Integer, ByVal Confirmed As String) As DataSet
        Dim params() As SqlParameter = _
                {New SqlParameter("@SessionID", SessionID), New SqlParameter("@Confirmed", Confirmed)}
        'Holds RegistrationNumber Data
        Dim Value As DataSet = New DataSet

        Try
            'Fetch all RegistrationNumber.
            Value = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAppFormConfirmedBySessionID", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegistrationNumber data
        Return Value
    End Function
    Public Function ConfirmedAppForm(ByVal ApplicationNumber As String) As String
        Dim RetValue As String = ""
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
       {New SqlParameter("@ApplicationNumber", ApplicationNumber)}


        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "ConfirmedAppForm", params)

            RetValue = "success"
            Return RetValue
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return RetValue
        End Try
    End Function
    ''' <summary>
    ''' Creates a StudentData
    ''' </summary>
    ''' <param name="StudentData"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates CountryStateLGAData using dept</remarks>
    Public Function EditApplicationForm(ByVal StudentData As ApplicationFormData) As String
        Dim RetValue As String = ""
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
       {New SqlParameter("@AppliedProgramme", StudentData.AppliedProgramme), _
       New SqlParameter("@SessionID", StudentData.SessionID), _
       New SqlParameter("@ProgrammeID", StudentData.ProgrammeID), _
       New SqlParameter("@Surname", StudentData.Surname), _
       New SqlParameter("@FirstName", StudentData.FirstName), _
       New SqlParameter("@MiddleName", StudentData.MiddleName), _
       New SqlParameter("@MaidenName", StudentData.MaidenName), _
       New SqlParameter("@HomeAddress", StudentData.HomeAddress), _
       New SqlParameter("@PhoneNumber", StudentData.PhoneNumber), _
       New SqlParameter("@StateID", StudentData.StateID), _
       New SqlParameter("@MaritalStatus", StudentData.MaritalStatus), _
       New SqlParameter("@Gender", StudentData.Gender), _
       New SqlParameter("@NoKName", StudentData.NoKName), _
       New SqlParameter("@NoKRelationship", StudentData.NoKRelationship), _
       New SqlParameter("@ENoKHomeAddress", StudentData.NoKHomeAddress), _
       New SqlParameter("@ENokPhoneNumber", StudentData.NokPhoneNumber), _
       New SqlParameter("@ExamNumberOne", StudentData.ExamNumberOne), _
       New SqlParameter("@YearOne", StudentData.YearOne), _
       New SqlParameter("@SchoolOne", StudentData.SchoolOne), _
       New SqlParameter("@ExamNumberTwo", StudentData.ExamNumberTwo), _
       New SqlParameter("@YearTwo", StudentData.YearTwo), _
       New SqlParameter("@SchoolTwo", StudentData.SchoolTwo), _
       New SqlParameter("@NameOfInstitution", StudentData.NameOfInstitution), _
       New SqlParameter("@Department", StudentData.Department), _
       New SqlParameter("@RegNumber", StudentData.RegNumber), _
       New SqlParameter("@YearOfAdmission", StudentData.YearOfAdmission), _
       New SqlParameter("@DateOfGraduation", StudentData.DateOfGraduation), _
       New SqlParameter("@ModeOfAdmission", StudentData.ModeOfAdmission), _
       New SqlParameter("@GradeOfPass", StudentData.GradeOfPass), _
       New SqlParameter("@FieldOfStudy", StudentData.FieldOfStudy), _
       New SqlParameter("@ProfessionalCert", StudentData.ProfessionalCert), _
       New SqlParameter("@Subject1", StudentData.Subject1), _
       New SqlParameter("@Grade1", StudentData.Grade1), _
       New SqlParameter("@Subject2", StudentData.Subject2), _
       New SqlParameter("@Grade2", StudentData.Grade2), _
       New SqlParameter("@Subject3", StudentData.Subject3), _
       New SqlParameter("@Grade3", StudentData.Grade3), _
       New SqlParameter("@Subject4", StudentData.Subject4), _
       New SqlParameter("@Grade4", StudentData.Grade4), _
       New SqlParameter("@Subject5", StudentData.Subject5), _
       New SqlParameter("@Grade5", StudentData.Grade5), _
       New SqlParameter("@Subject6", StudentData.Subject6), _
       New SqlParameter("@Grade6", StudentData.Grade6), _
       New SqlParameter("@Subject7", StudentData.Subject7), _
       New SqlParameter("@Grade7", StudentData.Grade7), _
       New SqlParameter("@Subject8", StudentData.Subject8), _
       New SqlParameter("@Grade8", StudentData.Grade8), _
       New SqlParameter("@Subject9", StudentData.Subject9), _
       New SqlParameter("@Grade9", StudentData.Grade9), _
       New SqlParameter("@Subject10", StudentData.Subject10), _
       New SqlParameter("@Grade10", StudentData.Grade10), _
       New SqlParameter("@Subject11", StudentData.Subject11), _
       New SqlParameter("@Grade11", StudentData.Grade11), _
       New SqlParameter("@Subject12", StudentData.Subject12), _
       New SqlParameter("@Grade12", StudentData.Grade12), _
       New SqlParameter("@Subject13", StudentData.Subject13), _
       New SqlParameter("@Grade13", StudentData.Grade13), _
       New SqlParameter("@Subject14", StudentData.Subject14), _
       New SqlParameter("@Grade14", StudentData.Grade14), _
       New SqlParameter("@Subject15", StudentData.Subject15), _
       New SqlParameter("@Grade15", StudentData.Grade15), _
       New SqlParameter("@Subject16", StudentData.Subject16), _
       New SqlParameter("@Grade16", StudentData.Grade16), _
       New SqlParameter("@Subject17", StudentData.Subject17), _
       New SqlParameter("@Grade17", StudentData.Grade17), _
       New SqlParameter("@Subject18", StudentData.Subject18), _
       New SqlParameter("@Grade18", StudentData.Grade18), _
       New SqlParameter("@AcademicDistinctions", StudentData.AcademicDistinctions), _
       New SqlParameter("@Employment", StudentData.Employment), _
       New SqlParameter("@NameFirstReferee", StudentData.NameFirstReferee), _
       New SqlParameter("@PositionFirstReferee", StudentData.PositionFirstReferee), _
       New SqlParameter("@AddressFirstReferee", StudentData.AddressFirstReferee), _
       New SqlParameter("@NameSecondReferee", StudentData.NameSecondReferee), _
       New SqlParameter("@PositionSecondReferee", StudentData.PositionSecondReferee), _
       New SqlParameter("@AddressSecondReferee", StudentData.AddressSecondReferee), _
       New SqlParameter("@NameThirdReferee", StudentData.NameThirdReferee), _
       New SqlParameter("@PositionThirdReferee", StudentData.PositionThirdReferee), _
       New SqlParameter("@AddressThirdReferee", StudentData.AddressThirdReferee), _
       New SqlParameter("@DoB", StudentData.DoB), _
       New SqlParameter("@ApplicationNumber", StudentData.ApplicationNumber)}


       

        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "EditApplicationForm", params)

            RetValue = "success"
            Return RetValue
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return RetValue
        End Try
    End Function
End Class
