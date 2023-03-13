Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic

Partial Class Admin_Chat
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetStudentOnline() As ArrayList
        'Intantiate objects for accessing User Data and Business Layers
        Dim QueueList As New ArrayList

        'Instance declaration 
        Dim chatNow As ChatDAL = New ChatDAL

        QueueList = chatNow.FindAllStudentOnlineByRegNumber()

        Return QueueList
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetCurrentStudentOnline() As ArrayList
        'Intantiate objects for accessing User Data and Business Layers
        Dim QueueList As New ArrayList

        'Instance declaration 
        Dim chatNow As ChatDAL = New ChatDAL

        QueueList = chatNow.FindAllCurrentStudentOnlineByRegNumber()

        Return QueueList
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function InsertAminChat(ByVal Eusername As String, ByVal Eregno As String, ByVal Emsg As String, ByVal Edate As String, ByVal Etime As String) As ArrayList
        'Intantiate objects for accessing User Data and Business Layers
        Dim ChatDAL As ChatDAL = New ChatDAL
        Dim ChatData As ChatData = New ChatData

        Dim QueueList As New ArrayList

        Dim StudentDal As StudentDAL = New StudentDAL
        Dim StudentData As StudentData = New StudentData
        Dim Encrpty As EncryptionUtil = New EncryptionUtil

        Dim UserDal As LoginDAL = New LoginDAL
        Dim UserData As LoginData = New LoginData

        Dim DecryptUser As String = Encrpty.Decrypt(Eusername)
        UserData = UserDal.FindUserByUserName(DecryptUser)

        Dim RegNumber As String = Eregno
        Dim UserID As Integer = UserData.UserID

        StudentData = StudentDal.FindStudentNameByRegNo(RegNumber)

        ChatData.UserID = UserID
        ChatData.RegNumber = RegNumber
        ChatData.UserMsg = Emsg
        ChatData.StudentMsg = ""
        ChatData.UserName = DecryptUser
        ChatData.StudentName = ""
        ChatData.StudentDate = ""
        ChatData.UserDate = Edate
        ChatData.StudentTime = ""
        ChatData.UserTime = Etime

        ' call CreateSession API
        Dim CreateStatus As Integer = ChatDAL.CreateChat(ChatData)
        If CreateStatus = 1 Then
            'Instance declaration 
            Dim chatNow As ChatDAL = New ChatDAL
            QueueList = chatNow.FindAdminAllChatByRegNumberUserID(RegNumber, UserID, Edate)
        End If

        Return QueueList
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetAdminChat(ByVal Eusername As String, ByVal Eregno As String, ByVal Edate As String) As ArrayList
        'Intantiate objects for accessing User Data and Business Layers
        Dim QueueList As New ArrayList

        Dim StudentDal As StudentDAL = New StudentDAL
        Dim StudentData As StudentData = New StudentData
        Dim Encrpty As EncryptionUtil = New EncryptionUtil

        Dim UserDal As LoginDAL = New LoginDAL
        Dim UserData As LoginData = New LoginData

        Dim Regno As String = Eregno
        Dim dateNow As String = Edate
        Dim UserName As String = Eusername

        Dim DecryptUser As String = Encrpty.Decrypt(UserName)
        UserData = UserDal.FindUserByUserName(DecryptUser)

        Dim RegNumber As String = Eregno
        Dim UserID As Integer = UserData.UserID


        'Instance declaration 
        Dim chatNow As ChatDAL = New ChatDAL

        QueueList = chatNow.FindAdminAllChatByRegNumberUserID(Regno, UserID, dateNow)

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
    Public Shared Function ReadMessage(ByVal Eusername As String, ByVal Eregno As String, ByVal Edate As String) As String
        Dim St As String = ""

        Dim Encrpty As EncryptionUtil = New EncryptionUtil

        Dim UserDal As LoginDAL = New LoginDAL
        Dim UserData As LoginData = New LoginData

        Dim dateNow As String = Edate
        Dim UserName As String = Eusername

        Dim DecryptUser As String = Encrpty.Decrypt(UserName)
        UserData = UserDal.FindUserByUserName(DecryptUser)

        Dim RegNumber As String = Eregno
        Dim UserID As Integer = UserData.UserID

        Dim chatNow As ChatDAL = New ChatDAL
        St = chatNow.ReadMessageAdmin(RegNumber, UserID, dateNow)

        Return St
    End Function

    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim userName As String = Request.QueryString("Username")
    '    Dim regNumber As String = Request.QueryString("regno")
    '    'Dim ar As ArrayList = GetStudentChat("13061001", "15-6-2016")
    '    'Label1.Text = ar.Item(0).StudentMsg.ToString

    '    ' Dim ars As ArrayList = GetStudentOnline()
    '    'Label1.Text = ars.Item(0).

    '    Dim ar As New ArrayList
    '    Dim st As String = ""

    '    st = ReadMessage(userName, regNumber, "25-7-2016")
    '    Label1.Text = st
    'End Sub
End Class
