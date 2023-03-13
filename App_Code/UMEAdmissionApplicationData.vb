Imports Microsoft.VisualBasic

Public Class UMEAdmissionApplicationData
    Private _AppAcknowledgeNo As String
    Private _Surname As String
    Private _FirstName As String
    Private _MiddleName As String
    Private _FacultyID As Integer
    Private _DeptID As Integer
    Private _QualifID As Integer
    Private _FirstChoice As String
    Private _SecondChoice As String
    Private _JAMBRegNo As String
    Private _DateofBirth As DateTime
    Private _Gender As String
    Private _MaritalStatus As String
    Private _Address As String
    Private _Email As String
    Private _PhoneNo As String
    Private _CountryID As Integer
    Private _StateID As Integer
    Private _LGAID As Integer
    Private _PlaceOfWork As String
    Private _Religion As String
    Private _PhotoUrl As String
    Private _SSCECopyUrl As String
    Private _SSCECopy2Url As String
    Private _NextOfKin As String
    Private _NextofKinAddress As String
    Private _SponsorName As String
    Private _SponsorOccupation As String
    Private _SponsorAddress As String
    Private _SponsorPhone As String
    Private _UMEScore As String
    Private _PostUMEScore As String
    Private _Status As String
    Private _CreateDate As DateTime
    Private _MothersName As String
    Private _PostUmeResultID As Integer
    Private _English As Decimal
    Private _Maths As Decimal
    Private _AreaOfStudy As Decimal
    Private _Average As Decimal
    Private _SessionName As String
    Private _Aggregate As Decimal
    Private _UploadByID As Integer
    Private _MaidenName As String
    Private _ParentsAddress As String
    Private _ExtraCurricularActivity As String
    Private _SpecialApplicant As String
    Private _FathersName As String
    Private _FathersAddress As String
    Private _FathersPhone As String
    Private _FathersEmail As String
    Private _MothersAddress As String
    Private _MothersPhone As String
    Private _MothersEmail As String
    Private _NextOfKinEmail As String
    Private _HasWorkedBefore As Char
    Private _WorkDetails As String
    Private _SpouseName As String
    Private _SpouseBirthDate As DateTime
    Private _HasWrittenJAMB As Char
    Private _JAMBYear As String
    Private _JAMBExamNo As String
    Private _AppliedToOtherSchool As Char
    Private _OtherAppliedToSchoolName As String
    Private _BeenAdmittedHereBefore As Char
    Private _PreviousAdmissionDetails As String
    Private _BeenConvictedBefore As Char
    Private _WhoPays As String
    Private _InstitutionAttended1 As String
    Private _InstitutionAttended1FromDate As DateTime
    Private _InstitutionAttended1ToDate As DateTime
    Private _InstitutionAttended1Qualif As String
    Private _InstitutionAttended2 As String
    Private _InstitutionAttended2FromDate As DateTime
    Private _InstitutionAttended2ToDate As DateTime
    Private _InstitutionAttended2Qualif As String
    Private _IntroducedBy As String
    Private _PreferedInterviewCenter As String
    Private _JAMBResultCopyUrl As String
    Private _BirthCertCopyUrl As String
    Private _PostUMEFeeID As Integer
    Private _PostUMEFeeAmount As Decimal
    Private _CreatedByID As Integer
    Private _DeptName As String
    Public Property DeptName() As String
        Get
            Return _DeptName
        End Get
        Set(ByVal value As String)
            _DeptName = value
        End Set
    End Property
    Public Property PostUMEFeeID() As Integer
        Get
            Return _PostUMEFeeID
        End Get
        Set(ByVal value As Integer)
            _PostUMEFeeID = value
        End Set
    End Property
    Public Property PostUMEFeeAmount() As Decimal
        Get
            Return _PostUMEFeeAmount
        End Get
        Set(ByVal value As Decimal)
            _PostUMEFeeAmount = value
        End Set
    End Property
    Public Property CreatedByID() As Integer
        Get
            Return _CreatedByID
        End Get
        Set(ByVal value As Integer)
            _CreatedByID = value
        End Set
    End Property

   
    Public Property BirthCertCopyUrl() As String
        Get
            Return _BirthCertCopyUrl
        End Get
        Set(ByVal value As String)
            _BirthCertCopyUrl = value
        End Set
    End Property

    Public Property JAMBResultCopyUrl() As String
        Get
            Return _JAMBResultCopyUrl
        End Get
        Set(ByVal value As String)
            _JAMBResultCopyUrl = value
        End Set
    End Property

    Public Property PreferedInterviewCenter() As String
        Get
            Return _PreferedInterviewCenter
        End Get
        Set(ByVal value As String)
            _PreferedInterviewCenter = value
        End Set
    End Property

    Public Property IntroducedBy() As String
        Get
            Return _IntroducedBy
        End Get
        Set(ByVal value As String)
            _IntroducedBy = value
        End Set
    End Property

    Public Property InstitutionAttended2Qualif() As String
        Get
            Return _InstitutionAttended2Qualif
        End Get
        Set(ByVal value As String)
            _InstitutionAttended2Qualif = value
        End Set
    End Property

    Public Property InstitutionAttended2ToDate() As DateTime
        Get
            Return _InstitutionAttended2ToDate
        End Get
        Set(ByVal value As DateTime)
            _InstitutionAttended2ToDate = value
        End Set
    End Property

    Public Property InstitutionAttended2FromDate() As DateTime
        Get
            Return _InstitutionAttended2FromDate
        End Get
        Set(ByVal value As DateTime)
            _InstitutionAttended2FromDate = value
        End Set
    End Property

    Public Property InstitutionAttended2() As String
        Get
            Return _InstitutionAttended2
        End Get
        Set(ByVal value As String)
            _InstitutionAttended2 = value
        End Set
    End Property


    Public Property InstitutionAttended1Qualif() As String
        Get
            Return _InstitutionAttended1Qualif
        End Get
        Set(ByVal value As String)
            _InstitutionAttended1Qualif = value
        End Set
    End Property


    Public Property InstitutionAttended1ToDate() As DateTime
        Get
            Return _InstitutionAttended1ToDate
        End Get
        Set(ByVal value As DateTime)
            _InstitutionAttended1ToDate = value
        End Set
    End Property


    Public Property InstitutionAttended1FromDate() As DateTime
        Get
            Return _InstitutionAttended1FromDate
        End Get
        Set(ByVal value As DateTime)
            _InstitutionAttended1FromDate = value
        End Set
    End Property

    Public Property InstitutionAttended1() As String
        Get
            Return _InstitutionAttended1
        End Get
        Set(ByVal value As String)
            _InstitutionAttended1 = value
        End Set
    End Property

    Public Property WhoPays() As String
        Get
            Return _WhoPays
        End Get
        Set(ByVal value As String)
            _WhoPays = value
        End Set
    End Property


    Public Property BeenConvictedBefore() As Char
        Get
            Return _BeenConvictedBefore
        End Get
        Set(ByVal value As Char)
            _BeenConvictedBefore = value
        End Set
    End Property

    Public Property PreviousAdmissionDetails() As String
        Get
            Return _PreviousAdmissionDetails
        End Get
        Set(ByVal value As String)
            _PreviousAdmissionDetails = value
        End Set
    End Property


    Public Property BeenAdmittedHereBefore() As Char
        Get
            Return _BeenAdmittedHereBefore
        End Get
        Set(ByVal value As Char)
            _BeenAdmittedHereBefore = value
        End Set
    End Property


    Public Property OtherAppliedToSchoolName() As String
        Get
            Return _OtherAppliedToSchoolName
        End Get
        Set(ByVal value As String)
            _OtherAppliedToSchoolName = value
        End Set
    End Property

    Public Property AppliedToOtherSchool() As Char
        Get
            Return _AppliedToOtherSchool
        End Get
        Set(ByVal value As Char)
            _AppliedToOtherSchool = value
        End Set
    End Property

    Public Property JAMBExamNo() As String
        Get
            Return _JAMBExamNo
        End Get
        Set(ByVal value As String)
            _JAMBExamNo = value
        End Set
    End Property

    Public Property JAMBYear() As String
        Get
            Return _JAMBYear
        End Get
        Set(ByVal value As String)
            _JAMBYear = value
        End Set
    End Property

    Public Property HasWrittenJAMB() As Char
        Get
            Return _HasWrittenJAMB
        End Get
        Set(ByVal value As Char)
            _HasWrittenJAMB = value
        End Set
    End Property

    Public Property SpouseBirthDate() As DateTime
        Get
            Return _SpouseBirthDate
        End Get
        Set(ByVal value As DateTime)
            _SpouseBirthDate = value
        End Set
    End Property

    Public Property SpouseName() As String
        Get
            Return _SpouseName
        End Get
        Set(ByVal value As String)
            _SpouseName = value
        End Set
    End Property

    Public Property WorkDetails() As String
        Get
            Return _WorkDetails
        End Get
        Set(ByVal value As String)
            _WorkDetails = value
        End Set
    End Property


    Public Property HasWorkedBefore() As Char
        Get
            Return _HasWorkedBefore
        End Get
        Set(ByVal value As Char)
            _HasWorkedBefore = value
        End Set
    End Property


    Public Property NextOfKinEmail() As String
        Get
            Return _NextOfKinEmail
        End Get
        Set(ByVal value As String)
            _NextOfKinEmail = value
        End Set
    End Property

    Public Property MothersEmail() As String
        Get
            Return _MothersEmail
        End Get
        Set(ByVal value As String)
            _MothersEmail = value
        End Set
    End Property


    Public Property MothersPhone() As String
        Get
            Return _MothersPhone
        End Get
        Set(ByVal value As String)
            _MothersPhone = value
        End Set
    End Property


    Public Property MothersAddress() As String
        Get
            Return _MothersAddress
        End Get
        Set(ByVal value As String)
            _MothersAddress = value
        End Set
    End Property

    Public Property FathersEmail() As String
        Get
            Return _FathersEmail
        End Get
        Set(ByVal value As String)
            _FathersEmail = value
        End Set
    End Property


    Public Property FathersPhone() As String
        Get
            Return _FathersPhone
        End Get
        Set(ByVal value As String)
            _FathersPhone = value
        End Set
    End Property


    Public Property FathersAddress() As String
        Get
            Return _FathersAddress
        End Get
        Set(ByVal value As String)
            _FathersAddress = value
        End Set
    End Property

    Public Property FathersName() As String
        Get
            Return _FathersName
        End Get
        Set(ByVal value As String)
            _FathersName = value
        End Set
    End Property


    Public Property SpecialApplicant() As String
        Get
            Return _SpecialApplicant
        End Get
        Set(ByVal value As String)
            _SpecialApplicant = value
        End Set
    End Property


    Public Property ExtraCurricularActivity() As String
        Get
            Return _ExtraCurricularActivity
        End Get
        Set(ByVal value As String)
            _ExtraCurricularActivity = value
        End Set
    End Property


    Public Property ParentsAddress() As String
        Get
            Return _ParentsAddress
        End Get
        Set(ByVal value As String)
            _ParentsAddress = value
        End Set
    End Property

    Public Property MaidenName() As String
        Get
            Return _MaidenName
        End Get
        Set(ByVal value As String)
            _MaidenName = value
        End Set
    End Property


    Public Property UploadByID() As Integer
        Get
            Return _UploadByID
        End Get
        Set(ByVal value As Integer)
            _UploadByID = value
        End Set
    End Property

    Public Property Aggregate() As Decimal
        Get
            Return _Aggregate
        End Get
        Set(ByVal value As Decimal)
            _Aggregate = value
        End Set
    End Property

    Public Property SessionName() As String
        Get
            Return _SessionName
        End Get
        Set(ByVal value As String)
            _SessionName = value
        End Set
    End Property


    Public Property Average() As Decimal
        Get
            Return _Average
        End Get
        Set(ByVal value As Decimal)
            _Average = value
        End Set
    End Property

    Public Property AreaOfStudy() As Decimal
        Get
            Return _AreaOfStudy
        End Get
        Set(ByVal value As Decimal)
            _AreaOfStudy = value
        End Set
    End Property

    Public Property Maths() As Decimal
        Get
            Return _Maths
        End Get
        Set(ByVal value As Decimal)
            _Maths = value
        End Set
    End Property

    Public Property English() As Decimal
        Get
            Return _English
        End Get
        Set(ByVal value As Decimal)
            _English = value
        End Set
    End Property

    Public Property PostUmeResultID() As Integer
        Get
            Return _PostUmeResultID
        End Get
        Set(ByVal value As Integer)
            _PostUmeResultID = value
        End Set
    End Property

    Public Property MothersName() As String
        Get
            Return _MothersName
        End Get
        Set(ByVal value As String)
            _MothersName = value
        End Set
    End Property

    Public Property CreateDate() As DateTime
        Get
            Return _CreateDate
        End Get
        Set(ByVal value As DateTime)
            _CreateDate = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property

    Public Property PostUMEScore() As String
        Get
            Return _PostUMEScore
        End Get
        Set(ByVal value As String)
            _PostUMEScore = value
        End Set
    End Property

    Public Property UMEScore() As String
        Get
            Return _UMEScore
        End Get
        Set(ByVal value As String)
            _UMEScore = value
        End Set
    End Property

    Public Property SponsorPhone() As String
        Get
            Return _SponsorPhone
        End Get
        Set(ByVal value As String)
            _SponsorPhone = value
        End Set
    End Property

    Public Property SponsorAddress() As String
        Get
            Return _SponsorAddress
        End Get
        Set(ByVal value As String)
            _SponsorAddress = value
        End Set
    End Property

    Public Property SponsorOccupation() As String
        Get
            Return _SponsorOccupation
        End Get
        Set(ByVal value As String)
            _SponsorOccupation = value
        End Set
    End Property

    Public Property SponsorName() As String
        Get
            Return _SponsorName
        End Get
        Set(ByVal value As String)
            _SponsorName = value
        End Set
    End Property

    Public Property NextofKinAddress() As String
        Get
            Return _NextofKinAddress
        End Get
        Set(ByVal value As String)
            _NextofKinAddress = value
        End Set
    End Property

    Public Property NextOfKin() As String
        Get
            Return _NextOfKin
        End Get
        Set(ByVal value As String)
            _NextOfKin = value
        End Set
    End Property

    Public Property SSCECopy2Url() As String
        Get
            Return _SSCECopy2Url
        End Get
        Set(ByVal value As String)
            _SSCECopy2Url = value
        End Set
    End Property

    Public Property SSCECopyUrl() As String
        Get
            Return _SSCECopyUrl
        End Get
        Set(ByVal value As String)
            _SSCECopyUrl = value
        End Set
    End Property

    Public Property PhotoUrl() As String
        Get
            Return _PhotoUrl
        End Get
        Set(ByVal value As String)
            _PhotoUrl = value
        End Set
    End Property

    Public Property Religion() As String
        Get
            Return _Religion
        End Get
        Set(ByVal value As String)
            _Religion = value
        End Set
    End Property

    Public Property PlaceOfWork() As String
        Get
            Return _PlaceOfWork
        End Get
        Set(ByVal value As String)
            _PlaceOfWork = value
        End Set
    End Property

    Public Property LGAID() As Integer
        Get
            Return _LGAID
        End Get
        Set(ByVal value As Integer)
            _LGAID = value
        End Set
    End Property

    Public Property StateID() As Integer
        Get
            Return _StateID
        End Get
        Set(ByVal value As Integer)
            _StateID = value
        End Set
    End Property

    Public Property CountryID() As Integer
        Get
            Return _CountryID
        End Get
        Set(ByVal value As Integer)
            _CountryID = value
        End Set
    End Property

    Public Property PhoneNo() As String
        Get
            Return _PhoneNo
        End Get
        Set(ByVal value As String)
            _PhoneNo = value
        End Set
    End Property

    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal value As String)
            _Address = value
        End Set
    End Property

    Public Property MaritalStatus() As String
        Get
            Return _MaritalStatus
        End Get
        Set(ByVal value As String)
            _MaritalStatus = value
        End Set
    End Property

    Public Property Gender() As String
        Get
            Return _Gender
        End Get
        Set(ByVal value As String)
            _Gender = value
        End Set
    End Property

    Public Property DateofBirth() As DateTime
        Get
            Return _DateofBirth
        End Get
        Set(ByVal value As DateTime)
            _DateofBirth = value
        End Set
    End Property

    Public Property JAMBRegNo() As String
        Get
            Return _JAMBRegNo
        End Get
        Set(ByVal value As String)
            _JAMBRegNo = value
        End Set
    End Property

    Public Property SecondChoice() As String
        Get
            Return _SecondChoice
        End Get
        Set(ByVal value As String)
            _SecondChoice = value
        End Set
    End Property

    Public Property FirstChoice() As String
        Get
            Return _FirstChoice
        End Get
        Set(ByVal value As String)
            _FirstChoice = value
        End Set
    End Property

    Public Property QualifID() As Integer
        Get
            Return _QualifID
        End Get
        Set(ByVal value As Integer)
            _QualifID = value
        End Set
    End Property

    Public Property DeptID() As Integer
        Get
            Return _DeptID
        End Get
        Set(ByVal value As Integer)
            _DeptID = value
        End Set
    End Property

    Public Property FacultyID() As Integer
        Get
            Return _FacultyID
        End Get
        Set(ByVal value As Integer)
            _FacultyID = value
        End Set
    End Property

    Public Property MiddleName() As String
        Get
            Return _MiddleName
        End Get
        Set(ByVal value As String)
            _MiddleName = value
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return _FirstName
        End Get
        Set(ByVal value As String)
            _FirstName = value
        End Set
    End Property

    Public Property Surname() As String
        Get
            Return _Surname
        End Get
        Set(ByVal value As String)
            _Surname = value
        End Set
    End Property

    Public Property AppAcknowledgeNo() As String
        Get
            Return _AppAcknowledgeNo
        End Get
        Set(ByVal value As String)
            _AppAcknowledgeNo = value
        End Set
    End Property


End Class

