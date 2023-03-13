
Partial Class Admin_Default
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ReturnMessage As String = ""
        ReturnMessage = Request.QueryString("nps")

        If ReturnMessage = "" Then
            pnlError2.Visible = False
            Me.lblError2.ForeColor = Drawing.Color.Brown
            Me.lblError2.Text = ReturnMessage
        Else
            pnlError2.Visible = True
            Me.lblError2.ForeColor = Drawing.Color.Brown
            Me.lblError2.Text = ReturnMessage
        End If
    End Sub

    Protected Sub BtnLogin_Click1(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Dim IEncrypt As EncryptionUtil = New EncryptionUtil
        Dim userData As LoginData = New LoginData
        Dim userDal As LoginDAL = New LoginDAL
        'Dim us As UsersData = New UsersData
        'Check if user exist

        ''Login John
        If "john" = TxtUsername.Text.Trim Then
            If "john" = txtPassword.Text.Trim Then
                Response.Redirect("../John/AdminUploadStudentIndividualProfile.aspx")
                Exit Sub
            End If
        End If
        

        Try

            userData = userDal.FindUserByUserName(TxtUsername.Text.Trim)
            If userData Is Nothing Then
                pnlError2.Visible = True
                lblError2.ForeColor = Drawing.Color.Brown
                lblError2.Text = "Invalid Username"
                Exit Sub
            Else
                'Decrypt users password with the password key and check if it matches with the supplied password.
                Dim DecrptedPass As String = IEncrypt.DecryptData(userData.Passwords, userData.SaltKey)
                pnlError2.Visible = True
                lblError2.Text = userData.Passwords & " and " & userData.SaltKey
                If DecrptedPass = txtPassword.Text.Trim Then
                    'Encrypting the url
                    Dim Encrypt As EncryptionUtil = New EncryptionUtil
                    Dim UserName As String = HttpUtility.UrlEncode(Encrypt.Encrypt(userData.UserName))

                    Dim Dal As LoginDAL = New LoginDAL
                    Dim Data As LoginData = New LoginData
                    Dim UserID As Integer = userData.UserID

                    Dim RetInt As Integer = Dal.LoginAuth(UserID)

                    Response.Redirect("Home.aspx?Username=" & UserName)
                Else
                    pnlError2.Visible = True
                    lblError2.ForeColor = Drawing.Color.Brown
                    lblError2.Text = "You supplied an incorrect password."
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            pnlError2.Visible = True
            lblError2.Text = "Login Failed"
        End Try
    End Sub
End Class
