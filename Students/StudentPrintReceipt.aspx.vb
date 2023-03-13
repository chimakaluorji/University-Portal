Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class Students_StudentPrintReceipt
    Inherits System.Web.UI.Page
    <WebMethod()> _
    Public Shared Function FindETransactionID(ByVal RegistrationNumber As String, ByVal SessionID As String, ByVal SemesterID As String) As String
        Dim Msg As String = ""

        Dim IEncrypt As Encryption = New Encryption
        Dim RegNumber As String = IEncrypt.Decrypt(RegistrationNumber, "123456789")


        Dim RetDal As StudentProfileDAL = New StudentProfileDAL
        Dim RetData As StudentProfileData = New StudentProfileData

        Dim ProgDal As ProgrammeDAL = New ProgrammeDAL
        Dim ProgData As ProgrammeData = New ProgrammeData

        ProgData = ProgDal.FindProgrammeIDByRegNumber(RegNumber)
        Dim LevelID As Integer = ProgData.ProgrammeID

        Dim IntSessionID As Integer = CInt(SessionID)
        Dim IntSemesterID As Integer = CInt(SemesterID)

        RetData = RetDal.FindETransactByRegNoSessionLevelSemester(RegNumber, IntSessionID, LevelID, IntSemesterID)
        If RetData IsNot Nothing Then
            Msg = RetData.ETransactionPinID
        End If

        If RetData Is Nothing Then
            Msg = "You have NOT 'PAY SCHOOL FEES' for the Session and semester you selected."
        End If

        Return Msg
    End Function
    <WebMethod()> _
    Public Shared Function FindAllReceipt(ByVal RegistrationNumber As String, ByVal PIN As String) As ArrayList
        Dim Msg As New ArrayList

        'Intantiate objects for accessing User Data and Business Layers
        Dim StudentProfileDal As StudentProfileDAL = New StudentProfileDAL
        Dim StudentProfileData As StudentProfileData = New StudentProfileData
        Dim RetValue As DataSet
        Dim ETransactionID As Integer = CInt(PIN)


        Dim IEncrypt As Encryption = New Encryption
        Dim RegNumber As String = IEncrypt.Decrypt(RegistrationNumber, "123456789")



        StudentProfileData = StudentProfileDal.FindstudentSchoolFeesByID_Portal(RegNumber, ETransactionID)
        RetValue = StudentProfileDal.FindAllSchoolFeesByID(RegNumber, ETransactionID)

        Msg.Add(New eFeesPaymentArrayData(StudentProfileData.ETransactPin, StudentProfileData.RegNumber, StudentProfileData.SessionName, StudentProfileData.Semester, _
                                               StudentProfileData.LevelName, StudentProfileData.CreateDate, StudentProfileData.Firstname, StudentProfileData.Amount, _
                                               StudentProfileData.PermenentHomeAddr, StudentProfileData.PhoneNumber))

        Return Msg
    End Function
    <WebMethod()> _
    Public Shared Function GCM_Send(ByVal regNumber As String) As String
        Dim retNothing As String = ""

        Dim IEncrypt As Encryption = New Encryption
        Dim newRegNumber As String = IEncrypt.Decrypt(regNumber, "123456789")

        Dim ds As StudentProfileData = New StudentProfileData
        Dim stdDal As StudentProfileDAL = New StudentProfileDAL

        ds = stdDal.FindPhoneNobyRegNumber(newRegNumber)

        Dim PhoneNumber As String = ds.PhoneNumber
        Dim FullName As String = ds.Firstname & ", " & ds.Surname

        Dim msg As String = FullName & " with Reg. Number " & newRegNumber & " have a problem while Printing his/her Receipt. Call him/her with this Phone Number " & PhoneNumber

        Dim GCM As GCM = New GCM
        retNothing = GCM.GCM_Sender(regNumber, msg, PhoneNumber, FullName)

        Return retNothing
    End Function
End Class

Public Class eFeesPaymentArrayData

    Public Property ePIN As String
    Public Property RegNumber As String
    Public Property SessionName As String
    Public Property SemesterName As String
    Public Property LevelName As String
    Public Property CreatedDate As String
    Public Property StudentName As String
    Public Property Amount As String
    Public Property HomeAddress As String
    Public Property PhoneNo As String
    Public Sub New()
    End Sub
    Public Sub New(ByVal ePIN As String, ByVal RegNumber As String, ByVal SessionName As String, _
                   ByVal SemesterName As String, ByVal LevelName As String, ByVal CreatedDate As String, _
                   ByVal StudentName As String, ByVal Amount As String, ByVal HomeAddress As String, ByVal PhoneNo As String)

        Me.ePIN = ePIN
        Me.RegNumber = RegNumber
        Me.SessionName = SessionName
        Me.SemesterName = SemesterName
        Me.LevelName = LevelName
        Me.CreatedDate = CreatedDate
        Me.StudentName = StudentName
        Me.Amount = Amount
        Me.HomeAddress = HomeAddress
        Me.PhoneNo = PhoneNo

    End Sub
End Class
