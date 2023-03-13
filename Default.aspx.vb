
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        '    lblError.Text = String.Empty
        '    Dim IEncrypt As EncryptionUtil = New EncryptionUtil
        '    Dim studentData As StudentProfileData = New StudentProfileData
        '    Dim StudentDal As StudentProfileDAL = New StudentProfileDAL

        '    Dim StudentDal1 As StudentProfileDAL = New StudentProfileDAL
        '    'Dim us As UsersData = New UsersData
        '    'Check if user exist
        '    If Me.TxtPin.Text = "" Then
        '        Me.lblError.Text = "Password is required."
        '    End If
        '    If Me.TxtRegNo.Text = "" Then
        '        Me.lblError.Text = "Registration Number is required."
        '    End If
        '    studentData.RegNumber = TxtRegNo.Text.Trim
        '    studentData.ETransactPin = TxtPin.Text.Trim




        '    studentData = StudentDal.FindRegNoByRegNo(TxtRegNo.Text.Trim)

        '    Dim RetAllValues As String = StudentDal1.FindPictureByRegNo(TxtRegNo.Text.Trim)
        '    If studentData Is Nothing Then
        '        lblError.ForeColor = Drawing.Color.Red
        '        lblError.Text = "Registration Number " & TxtRegNo.Text.Trim & " does not exist. Please type your Registration Number correctly and try again."
        '        Exit Sub
        '    Else
        '        'Decrypt users password with the password key and check if it matches with the supplied password.
        '        Dim DecrptedPass As String = IEncrypt.DecryptData(studentData.Password, studentData.SaltKey)

        '        Dim userpassword As String = TxtPin.Text.Trim

        '        If DecrptedPass = userpassword Then
        '            If studentData.PhoneNumber <> "" Then

        '                If RetAllValues = "NoPicture" Then
        '                    Dim StudentRetDAL As StudentProfileDAL = New StudentProfileDAL
        '                    Dim StudentRetData As StudentProfileData = New StudentProfileData

        '                    StudentRetData = StudentRetDAL.FindAllStudentsByRegNo(Me.TxtRegNo.Text.Trim)

        '                    Dim TrimRegNumber As String = TxtRegNo.Text.Trim

        '                    Dim Encrypt As EncryptionUtil = New EncryptionUtil
        '                    Dim RegNumber As String = HttpUtility.UrlEncode(Encrypt.Encrypt(TrimRegNumber))

        '                    Dim Dal As LoginDAL = New LoginDAL
        '                    Dim Data As LoginData = New LoginData

        '                    Dim RetInt As Integer = Dal.LoginStudentAuth(TrimRegNumber)

        '                    If RetInt = 1 Then
        '                        Response.Redirect("Students/StudentUploadPicture.aspx?RegNumber=" & RegNumber)
        '                    Else
        '                        lblError.ForeColor = Drawing.Color.Red
        '                        lblError.Text = "Login Failed."
        '                        Exit Sub
        '                    End If

        '                    Exit Sub
        '                End If


        '                Dim TrimRegNumber1 As String = TxtRegNo.Text.Trim

        '                'Dim Encrypt1 As EncryptionUtil = New EncryptionUtil
        '                'Dim RegNumber1 As String = Encrypt1.Encrypt(TrimRegNumber1)
        '                Dim Encrypt1 As Encryption = New Encryption
        '                Dim RegNumber1 As String = Encrypt1.Encrypt(TrimRegNumber1, "123456789")


        '                Dim Dal1 As LoginDAL = New LoginDAL
        '                Dim Data1 As LoginData = New LoginData

        '                Dim RetInt1 As Integer = Dal1.LoginStudentAuth(TrimRegNumber1)

        '                'Log user login
        '                If RetInt1 = 1 Then
        '                    Response.Redirect("Students/Home.aspx?RegNumber=" & RegNumber1)
        '                Else
        '                    lblError.ForeColor = Drawing.Color.Red
        '                    lblError.Text = "Login Failed."
        '                    Exit Sub
        '                End If

        '            Else
        '                lblError.ForeColor = Drawing.Color.Red
        '                lblError.Text = "You need to complete your profile registration with your PIN NUMBER. Click on New Student and follow the instruction."
        '                Exit Sub

        '            End If
        '        Else
        '            lblError.ForeColor = Drawing.Color.Red
        '            lblError.Text = "You supplied an incorrect password."
        '            Exit Sub
        '        End If
        '    End If
    End Sub
End Class
