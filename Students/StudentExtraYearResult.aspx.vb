Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class Students_StudentExtraYearResult
    Inherits System.Web.UI.Page

    <WebMethod()> _
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
        ResultData.SessionID = SessionID
        ResultData.SemesterID = SemesterID

        Dim ReturnData As String() = ResultDal.CheckResultPIN_New(ResultData)

        'Checking for school fees payment
        Dim stdDal As StudentProfileDAL = New StudentProfileDAL
        Dim CheckFeesPayment As String = stdDal.CheckForSchoolFeesPayment(RegNumber, SessionID, SemesterID)
        If CheckFeesPayment = "" Then
            Msg = "NOTPAIDand YOU HAVE NOT PAY YOUR SCHOOL FEES FOR THE SELECTED SESSION & SEMESTER, PLEASE GO TO PAY SCHOOL FEES MENU TO PAY YOUR SCHOOL FEES. and nothing"
            Return Msg
            Exit Function
        End If

        Dim Sucesses As Integer = CInt(ReturnData(0))
        If Sucesses = 104 Then

            Dim ReturnedSession As String = ReturnData(2)

            If ReturnedSession = "Active" Then
                Msg = "Activeand nothing and nothing"
            ElseIf ReturnedSession = "USED_BY_STUDENT" Then
                Msg = "This PIN have been used by another Student and nothing and nothing"
            Else
                Msg = "USEDPINand" & ReturnData(2) & "and" & ReturnData(3) '"You have used this PIN for " & ReturnData(2) & " Session and " & ReturnData(3) & ". You can only view the result of the below Session, Semester and Programme. Click Continue to view your Result"
            End If

        ElseIf Sucesses = 400 Then
            Edata = ErrorDal.FindErrorByCode(Sucesses.ToString)
            Msg = Edata.ErrorDetails & " " & ReturnData(1) & "and nothing and nothing"
            Return Msg
            Exit Function
        ElseIf Sucesses = 401 Then
            Edata = ErrorDal.FindErrorByCode(Sucesses.ToString)
            Msg = Edata.ErrorDetails & " " & ReturnData(1) & "and nothing and nothing"
            Return Msg
            Exit Function
        ElseIf Sucesses = 402 Then
            Edata = ErrorDal.FindErrorByCode(Sucesses.ToString)
            Msg = Edata.ErrorDetails & " " & ReturnData(1) & "and nothing and nothing"
            Return Msg
            Exit Function
        Else
            Edata = ErrorDal.FindErrorByCode(Sucesses.ToString)
            Msg = Edata.ErrorDetails & " " & ReturnData(1) & "and nothing and nothing"
            Return Msg
            Exit Function
            'End If
        End If

        Return Msg
    End Function
    <WebMethod()> _
    Public Shared Function FindAllResult(ByVal RegistrationNumber As String, ByVal PIN As String, ByVal SessionName As String, ByVal SemesterName As String, ByVal SessionID As String, ByVal SemesterID As String) As ArrayList
        Dim Msg As New ArrayList

        Dim IEncrypt As Encryption = New Encryption
        Dim RegNumber As String = IEncrypt.Decrypt(RegistrationNumber, "123456789")

        'Intantiate objects for accessing User Data and Business Layers
        Dim StudentProfileDal1 As StudentProfileDAL = New StudentProfileDAL
        Dim StudentProfileData1 As StudentProfileData = New StudentProfileData

        Dim ErrorDal As ErrorDAL = New ErrorDAL
        Dim Edata As ErrorData = New ErrorData

        'Handling Result Loading into CourseRegistraiton Table

        'Finding Level using regnumber
        Dim stdDal As StudentProfileDAL = New StudentProfileDAL
        Dim stdData As StudentProfileData = New StudentProfileData

        stdData = stdDal.FindLevelByRegNumber(RegNumber)
        Dim LevelName As String = stdData.LevelName

        'Loading result
        Dim LoadUploadResultDAL As UploadResultDAL = New UploadResultDAL
        Dim LoadUploadResultData As UploadResultData = New UploadResultData

        LoadUploadResultData.RegNum = RegNumber
        LoadUploadResultData.AcademicSession = SessionName
        LoadUploadResultData.Semester = SemesterName


        Dim RetValue1 As String() = LoadUploadResultDAL.LoadingResult_ExtraYear(LoadUploadResultData)

        If RetValue1(0) = 104 Then
        Else
            Msg.Add(New FetchResultArrayData("ERROR", "Error occurred, Please chat with admin.", "", "", "", ""))
            Return Msg
            Exit Function
        End If

        'Intantiate objects for accessing Result Data and Dal
        Dim UploadResultDAL As UploadResultDAL = New UploadResultDAL
        Dim UploadResultData As UploadResultData = New UploadResultData
        Dim GPA As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL

        If SessionID <> "0" Then

            'Changing the status of the result table
            Dim RetDal As StudentProfileDAL = New StudentProfileDAL
            Dim RetData As StudentProfileData = New StudentProfileData

            RetData.ETransactPin = PIN
            RetData.RegNumber = RegNumber
            RetData.SessionID = SessionID
            RetData.SemesterID = SemesterID

            Dim Exec As Integer = RetDal.UpdateResultPIN(RetData)

            If Exec = 0 Then
                Msg.Add(New FetchResultArrayData("ERROR", "Error occurred, Please chat with admin.", "", "", "", ""))
                Return Msg
                Exit Function
            End If

        End If

        Msg = UploadResultDAL.FindAllResultByRegNumber_Load_ExtraYear(SessionName, SemesterName, LevelName, RegNumber)

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

        Dim msg As String = FullName & " with Reg. Number " & newRegNumber & " have a problem while checking his/her Extra Year result. Call him/her with this Phone Number " & PhoneNumber

        Dim GCM As GCM = New GCM
        retNothing = GCM.GCM_Sender(regNumber, msg, PhoneNumber, FullName)

        Return retNothing
    End Function
    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim ar As New ArrayList

    '    Dim reg As String = Request.QueryString("RegNumber").Trim
    '    Dim PIN As String = "353442862"
    '    Dim Sess As String = "2015/2016"
    '    Dim Sem As String = "HND 1 First Semester"
    '    Dim SessID As String = "6"
    '    Dim SemID As String = "5"

    '    ar = FindAllCarryOverResult(reg, PIN, Sess, Sem, SessID, SemID)
    '    lblDisplay.Text = ar.Item(0).CourseCode & ar.Item(0).CourseName & ar.Item(0).Total
    'End Sub
End Class

