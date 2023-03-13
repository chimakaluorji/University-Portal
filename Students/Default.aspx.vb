
Partial Class Students_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ReturnMessage As String = ""
        ReturnMessage = Request.QueryString("msg")

        If ReturnMessage = "" Then
            'pnlError2.Visible = False
            Me.lblError2.ForeColor = Drawing.Color.Brown
            Me.lblError2.Text = ReturnMessage
        Else
            'pnlError2.Visible = True
            Me.lblError2.ForeColor = Drawing.Color.Brown
            Me.lblError2.Text = ReturnMessage
        End If
    End Sub

    Protected Sub BtnLogin_Click1(sender As Object, e As EventArgs) Handles BtnLogin.Click

        lblError.Text = String.Empty
        Dim IEncrypt As EncryptionUtil = New EncryptionUtil
        Dim studentData As StudentProfileData = New StudentProfileData
        Dim StudentDal As StudentProfileDAL = New StudentProfileDAL

        Dim StudentDal1 As StudentProfileDAL = New StudentProfileDAL
        'Dim us As UsersData = New UsersData
        'Check if user exist
        If Me.txtPassword.Text = "" Then
            Me.lblError.Text = "Password Number is required."
            Exit Sub
        End If
        If Me.txtRegNumber.Text = "" Then
            Me.lblError.Text = "Registration Number is required."
            Exit Sub
        End If

        studentData.RegNumber = txtRegNumber.Text.Trim
        studentData.ETransactPin = txtPassword.Text.Trim




        studentData = StudentDal.FindRegNoByRegNo(txtRegNumber.Text.Trim)

        Dim RetAllValues As String = StudentDal1.FindPictureByRegNo(txtRegNumber.Text.Trim)

        
        If studentData Is Nothing Then
            lblError.ForeColor = Drawing.Color.Red
            lblError.Text = "Registration Number " & txtRegNumber.Text.Trim & " does not exist. Please type your Registration Number correctly and try again."
            Exit Sub
        Else
            'Decrypt users password with the password key and check if it matches with the supplied password.
            Dim DecrptedPass As String = IEncrypt.DecryptData(studentData.Password, studentData.SaltKey)
            If DecrptedPass = txtPassword.Text.Trim Then
                If studentData.PhoneNumber <> "" Then

                    If RetAllValues = "NoPicture" Then
                        Dim StudentRetDAL As StudentProfileDAL = New StudentProfileDAL
                        Dim StudentRetData As StudentProfileData = New StudentProfileData

                        StudentRetData = StudentRetDAL.FindAllStudentsByRegNo(Me.txtRegNumber.Text.Trim)

                        Dim TrimRegNumber As String = txtRegNumber.Text.Trim

                        Dim Encrypt As EncryptionUtil = New EncryptionUtil
                        Dim RegNumber As String = HttpUtility.UrlEncode(Encrypt.Encrypt(TrimRegNumber))

                        Dim Dal As LoginDAL = New LoginDAL
                        Dim Data As LoginData = New LoginData

                        Dim RetInt As Integer = Dal.LoginStudentAuth(TrimRegNumber)

                        If RetInt = 1 Then
                            Response.Redirect("StudentUploadPicture.aspx?RegNumber=" & RegNumber)
                        Else
                            lblError.ForeColor = Drawing.Color.Red
                            lblError.Text = "Login Failed."
                            Exit Sub
                        End If



                        Exit Sub
                    End If

                    Dim TrimRegNumber1 As String = txtRegNumber.Text.Trim

                    Dim Encrypt1 As EncryptionUtil = New EncryptionUtil
                    Dim RegNumber1 As String = HttpUtility.UrlEncode(Encrypt1.Encrypt(TrimRegNumber1))

                    Dim Dal1 As LoginDAL = New LoginDAL
                    Dim Data1 As LoginData = New LoginData

                    Dim RetInt1 As Integer = Dal1.LoginStudentAuth(TrimRegNumber1)

                    'Log user login
                    If RetInt1 = 1 Then
                        Response.Redirect("Home.aspx?RegNumber=" & RegNumber1)
                    Else
                        lblError.ForeColor = Drawing.Color.Red
                        lblError.Text = "Login Failed."
                        Exit Sub
                    End If

                Else
                    lblError.ForeColor = Drawing.Color.Red
                    lblError.Text = "You need to complete your profile registration with your PIN NUMBER. Click on New Student and follow the instruction."
                    Exit Sub

                End If
            Else
                lblError.ForeColor = Drawing.Color.Red
                lblError.Text = "You supplied an incorrect password."
                Exit Sub
            End If

            End If
    End Sub
End Class
