Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Partial Class Application_ApplicationForm
    Inherits System.Web.UI.Page

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
                                       ByVal NameThirdReferee As String, ByVal PositionThirdReferee As String, ByVal AddressThirdReferee As String, ByVal DoB As String) As String

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

        ' call CreateSession API
        Dim CreateStatus As String = StudentDAL.CreateApplicationForm(studentData)

        Return CreateStatus
    End Function
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'txtSurname.Text = InsertData("sgf", "0", "0", "0", "sdfg", "dsfg", "dsfg", "dsfg", "dsfg", _
        '           "0", "0", "dfg", "", "", "", "", "sdfg", "", _
        '           "", "", "sfg", "sdfg", "", "", "dfg", "", "", _
        '           "", "", "dsf", "", "", "", "", "", "", _
        '           "", "dsfdfg", "", "", "", "", "dfsg", "dsfg", "", _
        '           "", "", "", "", "", "", "", "", "", _
        '           "dsf", "dsfg", "", "", "", "fdsg", "dsfg", "", "", _
        '           "", "dfg", "dsf", "", "", "", "", "", "", "", "", "", "", "", "fdfgs")


        'Intantiate objects for accessing User Data and Business Layers
        'Dim StudentDAL As ApplicationFormDAL = New ApplicationFormDAL
        'Dim studentData As ApplicationFormData = New ApplicationFormData

        'studentData.AppliedProgramme = ""
        'studentData.SessionID = 0
        'studentData.ProgrammeID = 0
        'studentData.Surname = ""
        'studentData.FirstName = ""
        'studentData.MiddleName = ""
        'studentData.MaidenName = ""
        'studentData.HomeAddress = ""
        'studentData.PhoneNumber = ""
        'studentData.StateID = 0
        'studentData.MaritalStatus = ""
        'studentData.NoKName = ""
        'studentData.NoKRelationship = ""
        'studentData.NoKHomeAddress = ""
        'studentData.NokPhoneNumber = ""
        'studentData.ExamNumberOne = ""
        'studentData.YearOne = ""
        'studentData.SchoolOne = ""
        'studentData.ExamNumberTwo = ""
        'studentData.YearTwo = ""
        'studentData.SchoolTwo = ""
        'studentData.NameOfInstitution = ""
        'studentData.Department = ""
        'studentData.RegNumber = ""
        'studentData.YearOfAdmission = ""
        'studentData.Subject1 = ""
        'studentData.Grade1 = ""
        'studentData.Subject2 = ""
        'studentData.Grade2 = ""
        'studentData.Subject3 = ""
        'studentData.Grade3 = ""
        'studentData.Subject4 = ""
        'studentData.Grade4 = ""
        'studentData.Subject5 = ""
        'studentData.Grade5 = ""
        'studentData.Subject6 = ""
        'studentData.Grade6 = ""
        'studentData.Subject7 = ""
        'studentData.Grade7 = ""
        'studentData.Subject8 = ""
        'studentData.Grade8 = ""
        'studentData.Subject9 = ""
        'studentData.Grade9 = ""
        'studentData.Subject10 = ""
        'studentData.Grade10 = ""
        'studentData.Subject11 = ""
        'studentData.Grade11 = ""
        'studentData.Subject12 = ""
        'studentData.Grade12 = ""
        'studentData.Subject13 = ""
        'studentData.Grade13 = ""
        'studentData.Subject14 = ""
        'studentData.Grade14 = ""
        'studentData.Subject15 = ""
        'studentData.Grade15 = ""
        'studentData.Subject16 = ""
        'studentData.Grade16 = ""
        'studentData.Subject17 = ""
        'studentData.Grade17 = ""
        'studentData.Subject18 = ""
        'studentData.Grade18 = ""
        'studentData.AcademicDistinctions = ""
        'studentData.Employment = ""
        'studentData.NameFirstReferee = ""
        'studentData.PositionFirstReferee = ""
        'studentData.AddressFirstReferee = ""
        'studentData.NameSecondReferee = ""
        'studentData.PositionSecondReferee = ""
        'studentData.AddressSecondReferee = ""
        'studentData.NameThirdReferee = ""
        'studentData.PositionThirdReferee = ""
        'studentData.AddressThirdReferee = ""
        'studentData.DoB = ""

        '' call CreateSession API
        'Dim CreateStatus As String = StudentDAL.CreateApplicationForm(studentData)
        'txtSurname.Text = CreateStatus
    End Sub
End Class
