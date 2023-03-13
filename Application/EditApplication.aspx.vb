Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports System
Imports System.Web
Imports System.IO
Partial Class Application_EditApplication
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function FindAllApplicationByApplicationNumber(ByVal ApplicationNumber As String) As ArrayList

        'instantiate object to hold user data
        Dim StudentData As DataSet = New DataSet

        Dim QueueList As New ArrayList
        Dim QPDal As ApplicationFormDAL = New ApplicationFormDAL

        StudentData = QPDal.ApplicationFormByApplicationNumber(ApplicationNumber)

        If StudentData.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In StudentData.Tables(0).Rows
                QueueList.Add(New ApplicationFormArrayData(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), _
                                                           row(9), row(10), row(11), row(12), row(13), row(14), row(15), row(16), row(17), _
                                                           row(18), row(19), row(20), row(21), row(22), row(23), row(24), row(25), row(26), _
                                                           row(27), row(28), row(29), row(30), row(31), row(32), row(33), row(34), row(35), _
                                                           row(36), row(37), row(38), row(39), row(40), row(41), row(42), row(43), row(44), _
                                                           row(45), row(46), row(47), row(48), row(49), row(50), row(51), row(52), row(53), _
                                                           row(54), row(55), row(56), row(57), row(58), row(59), row(60), row(61), row(62), _
                                                           row(63), row(64), row(65), row(66), row(67), row(68), row(69), row(70), row(71), _
                                                           row(72), row(73), row(74), row(75), row(76), row(77), row(78), row(79), row(80), _
                                                           row(81), row(82), row(83)))
            Next
        Else
            QueueList.Add(New ApplicationFormArrayData("0", "", "0", "0", "", "", "", "", "", _
                                                       "", "0", "", "", "", "", "", "", "", _
                                                       "", "", "", "", "", "", "", "", "", _
                                                       "", "", "", "", "", "", "", "", "", _
                                                       "", "", "", "", "", "", "", "", "", _
                                                       "", "", "", "", "", "", "", "", "", _
                                                       "", "", "", "", "", "", "", "", "", _
                                                       "", "", "", "", "", "", "", "", "", _
                                                       "", "", "", "", "", "", "", "", "", "", "", ""))
        End If

        Return QueueList
    End Function

    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function InsertData(ByVal AppliedProgramme As String, ByVal SessionID As Integer, ByVal ProgrammeID As Integer, ByVal Surname As String, _
                                       ByVal FirstName As String, ByVal MiddleName As String, ByVal MaidenName As String, ByVal HomeAddress As String, ByVal PhoneNumber As String, _
                                       ByVal StateID As Integer, ByVal MaritalStatus As String, ByVal Gender As String, ByVal NoKName As String, ByVal NoKRelationship As String, _
                                       ByVal NoKHomeAddress As String, ByVal NokPhoneNumber As String, ByVal ExamNumberOne As String, _
                                       ByVal YearOne As String, ByVal SchoolOne As String, ByVal ExamNumberTwo As String, ByVal YearTwo As String, _
                                       ByVal SchoolTwo As String, ByVal NameOfInstitution As String, ByVal Department As String, ByVal RegNumber As String, _
                                       ByVal YearOfAdmission As String, ByVal Subject1 As String, ByVal Grade1 As String, ByVal Subject2 As String, ByVal Grade2 As String, _
                                       ByVal DateOfGraduation As String, ByVal ModeOfAdmission As String, ByVal GradeOfPass As String, ByVal FieldOfStudy As String, ByVal ProfessionalCert As String, _
                                       ByVal Subject3 As String, ByVal Grade3 As String, ByVal Subject4 As String, ByVal Grade4 As String, ByVal Subject5 As String, ByVal Grade5 As String, _
                                       ByVal Subject6 As String, ByVal Grade6 As String, ByVal Subject7 As String, ByVal Grade7 As String, ByVal Subject8 As String, ByVal Grade8 As String, _
                                       ByVal Subject9 As String, ByVal Grade9 As String, ByVal Subject10 As String, ByVal Grade10 As String, ByVal Subject11 As String, ByVal Grade11 As String, _
                                       ByVal Subject12 As String, ByVal Grade12 As String, ByVal Subject13 As String, ByVal Grade13 As String, ByVal Subject14 As String, ByVal Grade14 As String, _
                                       ByVal Subject15 As String, ByVal Grade15 As String, ByVal Subject16 As String, ByVal Grade16 As String, ByVal Subject17 As String, ByVal Grade17 As String, _
                                       ByVal Subject18 As String, ByVal Grade18 As String, ByVal AcademicDistinctions As String, ByVal Employment As String, ByVal NameFirstReferee As String, ByVal PositionFirstReferee As String, _
                                       ByVal AddressFirstReferee As String, ByVal NameSecondReferee As String, ByVal PositionSecondReferee As String, ByVal AddressSecondReferee As String, _
                                       ByVal NameThirdReferee As String, ByVal PositionThirdReferee As String, ByVal AddressThirdReferee As String, ByVal DoB As String, ByVal ApplicationNumber As String) As String

        Dim msg As String = ""


        'Intantiate objects for accessing User Data and Business Layers
        Dim StudentDAL As ApplicationFormDAL = New ApplicationFormDAL
        Dim studentData As ApplicationFormData = New ApplicationFormData

        studentData.AppliedProgramme = AppliedProgramme
        studentData.SessionID = SessionID
        studentData.ProgrammeID = ProgrammeID
        studentData.Surname = Surname
        studentData.FirstName = FirstName
        studentData.MiddleName = MiddleName
        studentData.MaidenName = MaidenName
        studentData.HomeAddress = HomeAddress
        studentData.PhoneNumber = PhoneNumber
        studentData.StateID = StateID
        studentData.MaritalStatus = MaritalStatus
        studentData.Gender = Gender
        studentData.NoKName = NoKName
        studentData.NoKRelationship = NoKRelationship
        studentData.NoKHomeAddress = NoKHomeAddress
        studentData.NokPhoneNumber = NokPhoneNumber
        studentData.ExamNumberOne = ExamNumberOne
        studentData.YearOne = YearOne
        studentData.SchoolOne = SchoolOne
        studentData.ExamNumberTwo = ExamNumberTwo
        studentData.YearTwo = YearTwo
        studentData.SchoolTwo = SchoolTwo
        studentData.NameOfInstitution = NameOfInstitution
        studentData.Department = Department
        studentData.RegNumber = RegNumber
        studentData.YearOfAdmission = YearOfAdmission
        studentData.DateOfGraduation = DateOfGraduation
        studentData.ModeOfAdmission = ModeOfAdmission
        studentData.GradeOfPass = GradeOfPass
        studentData.FieldOfStudy = FieldOfStudy
        studentData.ProfessionalCert = ProfessionalCert
        studentData.Subject1 = Subject1
        studentData.Grade1 = Grade1
        studentData.Subject2 = Subject2
        studentData.Grade2 = Grade2
        studentData.Subject3 = Subject3
        studentData.Grade3 = Grade3
        studentData.Subject4 = Subject4
        studentData.Grade4 = Grade4
        studentData.Subject5 = Subject5
        studentData.Grade5 = Grade5
        studentData.Subject6 = Subject6
        studentData.Grade6 = Grade6
        studentData.Subject7 = Subject7
        studentData.Grade7 = Grade7
        studentData.Subject8 = Subject8
        studentData.Grade8 = Grade8
        studentData.Subject9 = Subject9
        studentData.Grade9 = Grade9
        studentData.Subject10 = Subject10
        studentData.Grade10 = Grade10
        studentData.Subject11 = Subject11
        studentData.Grade11 = Grade11
        studentData.Subject12 = Subject12
        studentData.Grade12 = Grade12
        studentData.Subject13 = Subject13
        studentData.Grade13 = Grade13
        studentData.Subject14 = Subject14
        studentData.Grade14 = Grade14
        studentData.Subject15 = Subject15
        studentData.Grade15 = Grade15
        studentData.Subject16 = Subject16
        studentData.Grade16 = Grade16
        studentData.Subject17 = Subject17
        studentData.Grade17 = Grade17
        studentData.Subject18 = Subject18
        studentData.Grade18 = Grade18
        studentData.AcademicDistinctions = AcademicDistinctions
        studentData.Employment = Employment
        studentData.NameFirstReferee = NameFirstReferee
        studentData.PositionFirstReferee = PositionFirstReferee
        studentData.AddressFirstReferee = AddressFirstReferee
        studentData.NameSecondReferee = NameSecondReferee
        studentData.PositionSecondReferee = PositionSecondReferee
        studentData.AddressSecondReferee = AddressSecondReferee
        studentData.NameThirdReferee = NameThirdReferee
        studentData.PositionThirdReferee = PositionThirdReferee
        studentData.AddressThirdReferee = AddressThirdReferee
        studentData.DoB = DoB
        studentData.ApplicationNumber = ApplicationNumber

        ' call CreateSession API
        Dim CreateStatus As String = StudentDAL.EditApplicationForm(studentData)

        Return CreateStatus
    End Function
End Class
