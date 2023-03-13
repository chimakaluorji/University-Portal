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

        Dim StdProfile As ApplicationFormDAL = New ApplicationFormDAL
        Dim StdData As ApplicationFormData = New ApplicationFormData

        Dim ApNo As String = Request.QueryString("ApNo").Trim
        Dim IEncrypt As EncryptionUtil = New EncryptionUtil





        'Try
        'Dim DecrptedPass As String = HttpUtility.UrlEncode(IEncrypt.Decrypt(RegNumber))


        'Dim Encrypt As EncryptionUtil = New EncryptionUtil
        'Dim encrptyUrl As String = HttpUtility.UrlEncode(Encrypt.Encrypt(DecrptedPass))

        Url = ApNo

        'Label1.Text = Url

        Dim Dal As LoginDAL = New LoginDAL
        Dim Data As LoginData = New LoginData

        StdData = StdProfile.FindApplicationByAppNo(ApNo)

        If StdData Is Nothing Then
            Response.Redirect("Default.aspx")
            Exit Sub
        End If
       
        StudentUsername = StdData.Firstname
        RegNo = StdData.ApplicationNumber

        Try
            Dim photoSplit As String() = StdData.PhotoUrl.Split("~")
            PhotoUrl = photoSplit(1)
        Catch ex As Exception
            PhotoUrl = "../StudentsPassport/User.png"
        End Try


        'Dim Check As LoginDAL = New LoginDAL
        'userLogData = Check.FindLoginStudent(DecrptedPass)

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
        Response.Redirect("Default.aspx")
    End Sub
End Class

