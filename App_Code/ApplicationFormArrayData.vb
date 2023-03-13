Imports Microsoft.VisualBasic

Public Class ApplicationFormArrayData
    Public Property ApplicationFormID As Integer
    Public Property AppliedProgramme As String
    Public Property SessionID As Integer
    Public Property ProgrammeID As Integer
    Public Property Surname As String
    Public Property FirstName As String
    Public Property MiddleName As String
    Public Property MaidenName As String
    Public Property HomeAddress As String
    Public Property PhoneNumber As String
    Public Property StateID As Integer
    Public Property MaritalStatus As String
    Public Property Gender As String
    Public Property NoKName As String
    Public Property NoKRelationship As String
    Public Property NoKHomeAddress As String
    Public Property NokPhoneNumber As String
    Public Property ExamNumberOne As String
    Public Property YearOne As String
    Public Property SchoolOne As String
    Public Property ExamNumberTwo As String
    Public Property YearTwo As String
    Public Property SchoolTwo As String
    Public Property NameOfInstitution As String
    Public Property Department As String
    Public Property RegNumber As String
    Public Property YearOfAdmission As String
    Public Property DateOfGraduation As String
    Public Property ModeOfAdmission As String
    Public Property GradeOfPass As String
    Public Property FieldOfStudy As String
    Public Property ProfessionalCert As String
    Public Property Subject1 As String
    Public Property Grade1 As String
    Public Property Subject2 As String
    Public Property Grade2 As String
    Public Property Subject3 As String
    Public Property Grade3 As String
    Public Property Subject4 As String
    Public Property Grade4 As String
    Public Property Subject5 As String
    Public Property Grade5 As String
    Public Property Subject6 As String
    Public Property Grade6 As String
    Public Property Subject7 As String
    Public Property Grade7 As String
    Public Property Subject8 As String
    Public Property Grade8 As String
    Public Property Subject9 As String
    Public Property Grade9 As String
    Public Property Subject10 As String
    Public Property Grade10 As String
    Public Property Subject11 As String
    Public Property Grade11 As String
    Public Property Subject12 As String
    Public Property Grade12 As String
    Public Property Subject13 As String
    Public Property Grade13 As String
    Public Property Subject14 As String
    Public Property Grade14 As String
    Public Property Subject15 As String
    Public Property Grade15 As String
    Public Property Subject16 As String
    Public Property Grade16 As String
    Public Property Subject17 As String
    Public Property Grade17 As String
    Public Property Subject18 As String
    Public Property Grade18 As String
    Public Property AcademicDistinctions As String
    Public Property Employment As String
    Public Property NameFirstReferee As String
    Public Property PositionFirstReferee As String
    Public Property AddressFirstReferee As String
    Public Property NameSecondReferee As String
    Public Property PositionSecondReferee As String
    Public Property AddressSecondReferee As String
    Public Property NameThirdReferee As String
    Public Property PositionThirdReferee As String
    Public Property AddressThirdReferee As String
    Public Property CreatedDate As String
    Public Property PhotoUrl As String
    Public Property BankDraftUrl As String
    Public Property Confirmed As String
    Public Property DoB As String

    Public Sub New()
    End Sub
    Public Sub New(ByVal ApplicationFormID As Integer, ByVal AppliedProgramme As String, ByVal SessionID As Integer, ByVal ProgrammeID As Integer, ByVal Surname As String, _
                                       ByVal FirstName As String, ByVal MiddleName As String, ByVal MaidenName As String, ByVal HomeAddress As String, ByVal PhoneNumber As String, _
                                       ByVal StateID As Integer, ByVal MaritalStatus As String, ByVal Gender As String, ByVal NoKName As String, ByVal NoKRelationship As String, _
                                       ByVal NoKHomeAddress As String, ByVal NokPhoneNumber As String, ByVal ExamNumberOne As String, _
                                       ByVal YearOne As String, ByVal SchoolOne As String, ByVal ExamNumberTwo As String, ByVal YearTwo As String, _
                                       ByVal SchoolTwo As String, ByVal NameOfInstitution As String, ByVal Department As String, ByVal RegNumber As String, _
                                       ByVal YearOfAdmission As String, ByVal DateOfGraduation As String, ByVal ModeOfAdmission As String, ByVal GradeOfPass As String, ByVal FieldOfStudy As String, ByVal ProfessionalCert As String, _
                                       ByVal Subject1 As String, ByVal Grade1 As String, ByVal Subject2 As String, ByVal Grade2 As String, _
                                       ByVal Subject3 As String, ByVal Grade3 As String, ByVal Subject4 As String, ByVal Grade4 As String, ByVal Subject5 As String, ByVal Grade5 As String, _
                                       ByVal Subject6 As String, ByVal Grade6 As String, ByVal Subject7 As String, ByVal Grade7 As String, ByVal Subject8 As String, ByVal Grade8 As String, _
                                       ByVal Subject9 As String, ByVal Grade9 As String, ByVal Subject10 As String, ByVal Grade10 As String, ByVal Subject11 As String, ByVal Grade11 As String, _
                                       ByVal Subject12 As String, ByVal Grade12 As String, ByVal Subject13 As String, ByVal Grade13 As String, ByVal Subject14 As String, ByVal Grade14 As String, _
                                       ByVal Subject15 As String, ByVal Grade15 As String, ByVal Subject16 As String, ByVal Grade16 As String, ByVal Subject17 As String, ByVal Grade17 As String, _
                                       ByVal Subject18 As String, ByVal Grade18 As String, ByVal AcademicDistinctions As String, ByVal Employment As String, ByVal NameFirstReferee As String, ByVal PositionFirstReferee As String, _
                                       ByVal AddressFirstReferee As String, ByVal NameSecondReferee As String, ByVal PositionSecondReferee As String, ByVal AddressSecondReferee As String, _
                                       ByVal NameThirdReferee As String, ByVal PositionThirdReferee As String, ByVal AddressThirdReferee As String, ByVal CreatedDate As String, ByVal PhotoUrl As String, ByVal BankDraftUrl As String, ByVal Confirmed As String, ByVal DoB As String)

        Me.ApplicationFormID = ApplicationFormID
        Me.AppliedProgramme = AppliedProgramme
        Me.SessionID = SessionID
        Me.ProgrammeID = ProgrammeID
        Me.Surname = Surname
        Me.FirstName = FirstName
        Me.MiddleName = MiddleName
        Me.MaidenName = MaidenName
        Me.HomeAddress = HomeAddress
        Me.PhoneNumber = PhoneNumber
        Me.StateID = StateID
        Me.MaritalStatus = MaritalStatus
        Me.Gender = Gender
        Me.NoKName = NoKName
        Me.NoKRelationship = NoKRelationship
        Me.NoKHomeAddress = NoKHomeAddress
        Me.NokPhoneNumber = NokPhoneNumber
        Me.ExamNumberOne = ExamNumberOne
        Me.YearOne = YearOne
        Me.SchoolOne = SchoolOne
        Me.ExamNumberTwo = ExamNumberTwo
        Me.YearTwo = YearTwo
        Me.SchoolTwo = SchoolTwo
        Me.NameOfInstitution = NameOfInstitution
        Me.Department = Department
        Me.RegNumber = RegNumber
        Me.YearOfAdmission = YearOfAdmission
        Me.DateOfGraduation = DateOfGraduation
        Me.ModeOfAdmission = ModeOfAdmission
        Me.GradeOfPass = GradeOfPass
        Me.FieldOfStudy = FieldOfStudy
        Me.ProfessionalCert = ProfessionalCert
        Me.Subject1 = Subject1
        Me.Grade1 = Grade1
        Me.Subject2 = Subject2
        Me.Grade2 = Grade2
        Me.Subject3 = Subject3
        Me.Grade3 = Grade3
        Me.Subject4 = Subject4
        Me.Grade4 = Grade4
        Me.Subject5 = Subject5
        Me.Grade5 = Grade5
        Me.Subject6 = Subject6
        Me.Grade6 = Grade6
        Me.Subject7 = Subject7
        Me.Grade7 = Grade7
        Me.Subject8 = Subject8
        Me.Grade8 = Grade8
        Me.Subject9 = Subject9
        Me.Grade9 = Grade9
        Me.Subject10 = Subject10
        Me.Grade10 = Grade10
        Me.Subject11 = Subject11
        Me.Grade11 = Grade11
        Me.Subject12 = Subject12
        Me.Grade12 = Grade12
        Me.Subject13 = Subject13
        Me.Grade13 = Grade13
        Me.Subject14 = Subject14
        Me.Grade14 = Grade14
        Me.Subject15 = Subject15
        Me.Grade15 = Grade15
        Me.Subject16 = Subject16
        Me.Grade16 = Grade16
        Me.Subject17 = Subject17
        Me.Grade17 = Grade17
        Me.Subject18 = Subject18
        Me.Grade18 = Grade18
        Me.AcademicDistinctions = AcademicDistinctions
        Me.Employment = Employment
        Me.NameFirstReferee = NameFirstReferee
        Me.PositionFirstReferee = PositionFirstReferee
        Me.AddressFirstReferee = AddressFirstReferee
        Me.NameSecondReferee = NameSecondReferee
        Me.PositionSecondReferee = PositionSecondReferee
        Me.AddressSecondReferee = AddressSecondReferee
        Me.NameThirdReferee = NameThirdReferee
        Me.PositionThirdReferee = PositionThirdReferee
        Me.AddressThirdReferee = AddressThirdReferee
        Me.CreatedDate = CreatedDate
        Me.PhotoUrl = PhotoUrl
        Me.BankDraftUrl = BankDraftUrl
        Me.Confirmed = Confirmed
        Me.DoB = DoB

    End Sub
End Class
