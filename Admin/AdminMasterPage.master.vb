
Partial Class Admin_AdminMasterPage
    Inherits System.Web.UI.MasterPage
    Public AdminUsername As String
    Public PhotoUrl As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim userData As LoginData = New LoginData
        Dim userLogData As LoginData = New LoginData
        Dim userDal As LoginDAL = New LoginDAL

        Dim userName As String = Request.QueryString("Username").Trim
        Dim IEncrypt As EncryptionUtil = New EncryptionUtil

        Try
            Dim DecrptedPass As String = IEncrypt.Decrypt(userName)
            userData = userDal.FindUserByUserName(DecrptedPass)
            AdminUsername = DecrptedPass

            Dim photoSplit As String() = userData.PhotoURL.Split("~")
            PhotoUrl = photoSplit(1)

            Dim Dal As LoginDAL = New LoginDAL
            Dim Data As LoginData = New LoginData

            Data = Dal.FindUserByUserName(DecrptedPass)

            Dim UserID As Integer = Data.UserID

            Dim Check As LoginDAL = New LoginDAL
            userLogData = Check.FindLoginAdmin(UserID)

            If userLogData Is Nothing Then
                Response.Redirect("../Default.aspx?nps=Session Timeout, Login Again")
            End If
        Catch ex As Exception
            Response.Redirect("../Admin/Default.aspx")
        End Try


        'Handling Chat Count
        'Instance declaration 
        Dim chatNow As ChatDAL = New ChatDAL
        lblMsgCount.Text = chatNow.CountStudentOnline()
    End Sub

    Protected Sub BtnLogout_Click(sender As Object, e As EventArgs) Handles BtnLogout.Click
        Dim userName As String = Request.QueryString("Username")

        Dim IEncrypt As EncryptionUtil = New EncryptionUtil
        Dim DecrptedPass As String = IEncrypt.Decrypt(userName)

        Dim Dal As LoginDAL = New LoginDAL
        Dim Data As LoginData = New LoginData

        Data = Dal.FindUserByUserName(DecrptedPass)

        Dim UserID As Integer = Data.UserID

        Dim RetInt As Integer = Dal.LogOutAuth(UserID)

        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub lBtLogout_Click(sender As Object, e As EventArgs) Handles lBtLogout.Click
        Dim userName As String = Request.QueryString("Username")

        Dim IEncrypt As EncryptionUtil = New EncryptionUtil
        Dim DecrptedPass As String = IEncrypt.Decrypt(userName)

        Dim Dal As LoginDAL = New LoginDAL
        Dim Data As LoginData = New LoginData

        Data = Dal.FindUserByUserName(DecrptedPass)

        Dim UserID As Integer = Data.UserID

        Dim RetInt As Integer = Dal.LogOutAuth(UserID)

        Response.Redirect("Default.aspx")
    End Sub
End Class

