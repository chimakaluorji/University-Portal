Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports System.Timers
Partial Class Students_StudentMasterPage
    Inherits System.Web.UI.MasterPage
    Public StudentUsername As String
    Public Url As String
    Public RegNo As String
    Public PhotoUrl As String
    Public UserID As String
    Shared _timer As Timer
    Shared _list As List(Of String) = New List(Of String)
    Shared QueueList As New ArrayList
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        
        Dim userData As LoginData = New LoginData
        Dim userLogData As LoginData = New LoginData
        Dim userDal As LoginDAL = New LoginDAL

        Dim StdProfile As StudentProfileDAL = New StudentProfileDAL
        Dim StdData As StudentProfileData = New StudentProfileData

        Dim RegNumber As String = Request.QueryString("RegNumber").Trim
        'Dim IEncrypt As EncryptionUtil = New EncryptionUtil





        'Try
        'Dim DecrptedPass As String = HttpUtility.UrlEncode(IEncrypt.Decrypt(RegNumber))


        'Dim Encrypt As EncryptionUtil = New EncryptionUtil
        'Dim encrptyUrl As String = HttpUtility.UrlEncode(Encrypt.Encrypt(DecrptedPass))

        'Url = encrptyUrl

        'Label1.Text = Url
        Dim Encrypt1 As Encryption = New Encryption
        Dim Decryt As String = HttpUtility.UrlEncode(Encrypt1.Decrypt(RegNumber, "123456789"))

        Url = RegNumber

        Dim Dal As LoginDAL = New LoginDAL
        Dim Data As LoginData = New LoginData

        StdData = StdProfile.FindStudentByRegNumberForHomePage(Decryt)

        StudentUsername = StdData.Firstname
        RegNo = StdData.RegNumber

        Try
            Dim photoSplit As String() = StdData.PhotoUrl.Split("~")
            PhotoUrl = photoSplit(1)
        Catch ex As Exception
            PhotoUrl = "../StudentsPassport/User.png"
        End Try
      

        Dim Check As LoginDAL = New LoginDAL
        userLogData = Check.FindLoginStudent(Decryt)

        'If userLogData Is Nothing Then
        '    Response.Redirect("../Default.aspx?nps=Session Timeout, Login Again")
        'End If
        'Catch ex As Exception
        '    Response.Redirect("../Default.aspx")
        'End Try

        ''Counting the number of admin online
        'Dim chatNow As ChatDAL = New ChatDAL
        'lblMsgCount.Text = chatNow.CountAdminOnline()

        ''Handling Chat
        ''Intantiate objects for accessing User Data and Business Layers
        'Dim QueueList As New ArrayList

        ''Instance declaration 
        'Dim chatNow1 As ChatDAL = New ChatDAL

        'QueueList = chatNow1.FindAllAdminOnlineByRegNumber()
        'UserID = QueueList.Item(0).UserID
    End Sub
   
    Protected Sub BtnLogout_Click(sender As Object, e As EventArgs) Handles BtnLogout.Click
        Dim RegNumber As String = Request.QueryString("RegNumber")

        'Dim IEncrypt As EncryptionUtil = New EncryptionUtil
        'Dim DecrptedPass As String = IEncrypt.Decrypt(RegNumber)
        Dim Encrypt1 As Encryption = New Encryption
        Dim Decryt As String = HttpUtility.UrlEncode(Encrypt1.Decrypt(RegNumber, "123456789"))

        Dim Dal As LoginDAL = New LoginDAL
        Dim Data As LoginData = New LoginData

        Dim RetInt As Integer = Dal.LogOutStudentAuth(Decryt)

        Response.Redirect("../Default.aspx")
    End Sub
    'Shared Sub Start()
    '    _timer = New Timer(1000)
    '    AddHandler _timer.Elapsed, New ElapsedEventHandler(AddressOf Handler)
    '    _timer.Enabled = True
    'End Sub
    'Shared Sub Handler(ByVal sender As Object, ByVal e As ElapsedEventArgs)
    '    'Handling Chat
    '    'Intantiate objects for accessing User Data and Business Layers
    '    Dim QueueList As New ArrayList

    '    'Instance declaration 
    '    Dim chatNow As ChatDAL = New ChatDAL

    '    QueueList = chatNow.FindAllAdminOnlineByRegNumber()
    'End Sub
   
    ''' <summary>
    ''' Start the timer.
    ''' </summary>
    Shared Sub Start()
        _timer = New Timer(3000)
        AddHandler _timer.Elapsed, New ElapsedEventHandler(AddressOf Handler)
        _timer.Enabled = True
    End Sub

    ''' <summary>
    ''' Get timer output.
    ''' </summary>
    Shared Function GetOutput() As String
        Return String.Join("<br>", _list)
    End Function

    ''' <summary>
    ''' Timer event handler.
    ''' </summary>
    Shared Sub Handler(ByVal sender As Object, ByVal e As ElapsedEventArgs)
        _list.Add(DateTime.Now.ToString())
    End Sub
End Class

