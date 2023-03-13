Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Partial Class StudentChat
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetAdminOnline() As ArrayList
        'Intantiate objects for accessing User Data and Business Layers
        Dim QueueList As New ArrayList

        'Instance declaration 
        Dim chatNow As ChatDAL = New ChatDAL

        QueueList = chatNow.FindAllAdminOnlineByRegNumber()

        Return QueueList
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetCurrentAdminOnline() As ArrayList
        'Intantiate objects for accessing User Data and Business Layers
        Dim QueueList As New ArrayList

        'Instance declaration 
        Dim chatNow As ChatDAL = New ChatDAL

        QueueList = chatNow.FindAllCurrentAdminOnlineByRegNumber()

        Return QueueList
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetStudentChat(ByVal Eregno As String, ByVal Edate As String) As ArrayList
        'Intantiate objects for accessing User Data and Business Layers
        Dim QueueList As New ArrayList

        Dim Regno As String = Eregno
        Dim dateNow As String = Edate

        'Instance declaration 
        Dim chatNow As ChatDAL = New ChatDAL

        QueueList = chatNow.FindChatByRegNumberUserID(Regno, dateNow)

        Return QueueList
    End Function

    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function InsertChat(ByVal Emsg As String, ByVal Edate As String, ByVal Etime As String, ByVal newUserID As String, ByVal regNumber As String) As ArrayList
        'Intantiate objects for accessing User Data and Business Layers
        Dim ChatDAL As ChatDAL = New ChatDAL
        Dim ChatData As ChatData = New ChatData

        Dim QueueList As New ArrayList

        Dim StudentDal As StudentProfileDAL = New StudentProfileDAL
        Dim StudentData As StudentProfileData = New StudentProfileData

        Dim IEncrypt As Encryption = New Encryption
        Dim newRegNumber As String = IEncrypt.Decrypt(regNumber, "123456789")

        Dim UserID As Integer = CInt(newUserID)

        StudentData = StudentDal.FindAllStudentsByRegNo(newRegNumber)

        ChatData.UserID = UserID
        ChatData.RegNumber = newRegNumber
        ChatData.UserMsg = ""
        ChatData.StudentMsg = Emsg
        ChatData.UserName = ""
        ChatData.StudentName = StudentData.Surname & " " & StudentData.Firstname
        ChatData.StudentDate = Edate
        ChatData.UserDate = ""
        ChatData.StudentTime = Etime
        ChatData.UserTime = ""

        ' call CreateSession API
        Dim CreateStatus As Integer = ChatDAL.CreateChat(ChatData)
        If CreateStatus = 1 Then
            'Instance declaration 
            Dim chatNow As ChatDAL = New ChatDAL
            QueueList = chatNow.FindChatByRegNumberUserID(newRegNumber, Edate)
        End If

        Return QueueList
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetAllChat(ByVal newUserID As String, ByVal Eregno As String, ByVal Edate As String) As ArrayList
        'Intantiate objects for accessing User Data and Business Layers
        Dim QueueList As New ArrayList

        Dim StudentDal As StudentDAL = New StudentDAL
        Dim StudentData As StudentData = New StudentData
        Dim Encrpty As EncryptionUtil = New EncryptionUtil

        Dim Regno As String = Eregno
        Dim dateNow As String = Edate

        Dim IEncrypt As Encryption = New Encryption
        Dim newRegNumber As String = IEncrypt.Decrypt(Eregno, "123456789")

        Dim UserID As Integer = CInt(newUserID)


        'Instance declaration 
        Dim chatNow As ChatDAL = New ChatDAL

        QueueList = chatNow.FindAdminAllChatByRegNumberUserID(newRegNumber, UserID, dateNow)

        Return QueueList
    End Function

    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetAdminChat(ByVal newUserID As String, ByVal Edate As String) As ArrayList
        'Intantiate objects for accessing User Data and Business Layers
        Dim QueueList As New ArrayList

        Dim UserID As Integer = 0
        UserID = CInt(newUserID)

        'Instance declaration 
        Dim chatNow As ChatDAL = New ChatDAL

        QueueList = chatNow.FindAdminChatByRegNumberUserID(UserID, Edate)

        Return QueueList
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function ReadMessageStudent(ByVal newUserID As String, ByVal Eregno As String, ByVal Edate As String) As String
        Dim St As String = ""

        Dim QueueList As New ArrayList

        Dim StudentDal As StudentDAL = New StudentDAL
        Dim StudentData As StudentData = New StudentData
        Dim Encrpty As Encryption = New Encryption

        Dim Regno As String = Eregno
        Dim dateNow As String = Edate

        Dim IEncrypt As EncryptionUtil = New EncryptionUtil
        Dim newRegNumber As String = IEncrypt.Decrypt(Eregno, "123456789")

        Dim UserID As Integer = CInt(newUserID)

        Dim chatNow As ChatDAL = New ChatDAL
        St = chatNow.ReadMessageStudent(newRegNumber, UserID, dateNow)

        Return St
    End Function

    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    'Dim userName As String = Request.QueryString("Username")
    '    'Dim ar As ArrayList = GetStudentChat("13061001", "15-6-2016")

    '    'Intantiate objects for accessing User Data and Business Layers
    '    Dim QueueList As New ArrayList

    '    'Instance declaration 
    '    'Dim chatNow As ChatDAL = New ChatDAL

    '    'QueueList = chatNow.FindAllAdminOnlineByRegNumber()
    '    Dim RegNo As String = Request.QueryString("RegNumber")
    '    Dim UserID As String = Request.QueryString("UserID")

    '    ' QueueList = InsertChat("How are you", "22-7-2016", "15:42:56", "1", ar)
    '    Dim use As Integer = 1
    '    Dim Edate As String = "22-7-2016"

    '    Dim chatNow As ChatDAL = New ChatDAL
    '    QueueList = GetAdminChat(UserID, "23-7-2016") 'chatNow.FindAllChatByRegNumberUserID(ar, use, Edate)

    '    Label1.Text = ReadMessageStudent(UserID, RegNo, "25-7-2016")
    'End Sub
End Class
