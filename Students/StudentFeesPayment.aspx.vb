Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class Students_StudentFeesPayment
    Inherits System.Web.UI.Page

    <WebMethod()>
    Public Shared Function InsertData(ByVal RegistrationNumber As String, ByVal PIN As String, ByVal SessionID As String, ByVal SemesterID As String) As String
        Dim Msg As String = ""

        Dim IEncrypt As Encryption = New Encryption
        Dim RegNumber As String = IEncrypt.Decrypt(RegistrationNumber, "123456789")

        'Intantiate objects for accessing Result information
        Dim ResultDal As StudentProfileDAL = New StudentProfileDAL
        Dim ResultData As StudentProfileData = New StudentProfileData

        Dim ErrorDal As ErrorDAL = New ErrorDAL
        Dim Edata As ErrorData = New ErrorData

        ResultData.ETransactPin = PIN.Trim
        ResultData.RegNumber = RegNumber
        ResultData.SessionID = CInt(SessionID)
        ResultData.SemesterID = CInt(SemesterID)

        Dim ReturnData As String() = ResultDal.CheckSchoolFeesPIN_New(ResultData)



        Dim Sucesses As Integer = CInt(ReturnData(0))
        If Sucesses = 104 Then
            Dim ReturnedSession As String = ReturnData(2)

            If ReturnedSession = "Active" Then
                Msg = "success"
            ElseIf ReturnedSession = "USED_BY_STUDENT" Then
                Msg = "This PIN have been used by another Student"
            Else
                Msg = "You have used this PIN for the " & ReturnData(2) & " Session, Semester " & ReturnData(3) & " and " & ReturnData(4) & " Programme. Go to Print Receipt & Profile Menu to Print your School Fees Receipt."
            End If

        ElseIf Sucesses = 400 Then
            Edata = ErrorDal.FindErrorByCode(Sucesses.ToString)
            Msg = Edata.ErrorDetails & " " & ReturnData(1)
            Return Msg
            Exit Function
        ElseIf Sucesses = 401 Then
            Edata = ErrorDal.FindErrorByCode(Sucesses.ToString)
            Msg = Edata.ErrorDetails & " " & ReturnData(1)
            Return Msg
            Exit Function
        ElseIf Sucesses = 402 Then
            Edata = ErrorDal.FindErrorByCode(Sucesses.ToString)
            Msg = Edata.ErrorDetails & " " & ReturnData(1)
            Return Msg
            Exit Function
        Else
            Edata = ErrorDal.FindErrorByCode(Sucesses.ToString)
            Msg = Edata.ErrorDetails & " " & ReturnData(1)
            Return Msg
            Exit Function
            'End If
        End If

        Return Msg
    End Function
    <WebMethod()> _
    Public Shared Function PaySchoolFees(ByVal RegistrationNumber As String, ByVal PIN As String, ByVal SessionID As String, ByVal SemesterID As String) As String

        Dim IEncrypt As Encryption = New Encryption
        Dim RegNumber As String = IEncrypt.Decrypt(RegistrationNumber, "123456789")

        Dim msg As String = ""
        Dim RegNo As String = RegNumber

        'Fetching the Faculty and Department Using Registration Number
        Dim StudentDatas As StudentProfileData = New StudentProfileData
        Dim StudentDals As StudentProfileDAL = New StudentProfileDAL


        'Intantiate objects for accessing User Data and Business Layers
        Dim StudentProfileDal1 As StudentProfileDAL = New StudentProfileDAL
        Dim StudentProfileData1 As StudentProfileData = New StudentProfileData

        Dim ErrorDal As ErrorDAL = New ErrorDAL
        Dim Edata As ErrorData = New ErrorData

        'If Not IsPostBack Then
        StudentProfileData1.RegNumber = RegNo.Trim
        StudentProfileData1.SessionID = SessionID
        StudentProfileData1.SemesterID = SemesterID
        StudentProfileData1.LevelID = 0 'ddlEntryLevel.SelectedValue
        StudentProfileData1.FacultyID = 0 'StudentDatas.FacultyID
        StudentProfileData1.DeptID = 0 'StudentDatas.DeptID
        StudentProfileData1.ETransactPin = PIN
        StudentProfileData1.TypeOfSchoolFees = "" 'ddlSchoolFees.SelectedItem.Text
        StudentProfileData1.Amount = "" 'SemesterData.SchoolFeesAmount
        StudentProfileData1.AmountInWords = "" 'SemesterData.AmountInwords


        ' call CreateStudentProfile API
        Dim RetValue As String() = StudentProfileDal1.PayStudentSchoolFees_New(StudentProfileData1)

        Dim Sucesses As Integer = CInt(RetValue(0))
        If Sucesses = 104 Then
            msg = "success"
            Return msg
            Exit Function
        ElseIf Sucesses = 400 Then
            Edata = ErrorDal.FindErrorByCode(Sucesses.ToString)
            msg = Edata.ErrorDetails & " " & RetValue(1)
            Return msg
            Exit Function
        Else
            Edata = ErrorDal.FindErrorByCode(Sucesses.ToString)
            msg = Edata.ErrorDetails & " " & RetValue(1)
            Return msg
            Exit Function
        End If
    End Function
    <WebMethod()> _
    Public Shared Function GCM_Send(ByVal regNumber As String) As String
        Dim retNothing As String = ""
        Dim IEncrypt As EncryptionUtil = New EncryptionUtil
        Dim newRegNumber As String = IEncrypt.Decrypt(regNumber)

        Dim ds As StudentProfileData = New StudentProfileData
        Dim stdDal As StudentProfileDAL = New StudentProfileDAL

        ds = stdDal.FindPhoneNobyRegNumber(newRegNumber)

        Dim PhoneNumber As String = ds.PhoneNumber
        Dim FullName As String = ds.Firstname & ", " & ds.Surname

        Dim msg As String = FullName & " with Reg. Number " & newRegNumber & " have a problem while Paying his/her School Fess. Call him/her with this Phone Number " & PhoneNumber

        Dim GCM As GCM = New GCM
        retNothing = GCM.GCM_Sender(regNumber, msg, PhoneNumber, FullName)

        Return retNothing
    End Function
    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim RegistrationNumber As String = Request.QueryString("RegNumber").Trim
    '    Dim IEncrypt As EncryptionUtil = New EncryptionUtil
    '    Dim RegNumber As String = IEncrypt.Decrypt(RegistrationNumber)

    '    Label1.Text = PaySchoolFees(RegistrationNumber, "9974683516", "7", "7")
    'End Sub
End Class
