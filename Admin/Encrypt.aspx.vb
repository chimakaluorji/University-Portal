
Partial Class Admin_Encrypt
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'lblUser.Text = ""
        'Dim userName As String = txtUser.Text

        'Dim IEncrypt As EncryptionUtil = New EncryptionUtil
        'Dim Encrypted As String() = IEncrypt.EncryptData(userName)
        'Dim EncryptedString As String = Encrypted(0) & Encrypted(1)
        'Dim DecrptedPass As String = IEncrypt.DecryptData(Encrypted(0), Encrypted(1))

        'lblUser.Text = Encrypted(0) & " and key is " & Encrypted(1) & " and " & DecrptedPass

        'Dim msg As String() = {"", "", ""}

        ''Intantiate objects for accessing User Data and Business Layers
        'Dim StudentDal As StudentDAL = New StudentDAL
        'Dim StudentData As StudentData = New StudentData

        'StudentData = StudentDal.FindStudentByRegNo(txtUser.Text)
        'msg(0) = StudentData.RegNumber
        'msg(1) = StudentData.FirstName
        'msg(2) = StudentData.Surname

        'lblUser.Text = msg(0) & msg(1) & msg(2)

        'Intantiate objects for accessing User Data and Business Layers
        Dim StudentDAL As StudentDAL = New StudentDAL
        Dim studentData As StudentData = New StudentData

        studentData.RegNumber = txtUser.Text
        studentData.Surname = "kaluorji"
        studentData.FirstName = "Chima"
        studentData.MiddleName = ""
        studentData.MothersMaidenName = ""
        studentData.DOB = ""
        studentData.Sex = ""
        studentData.StateID = 1
        studentData.LGAID = 1
        studentData.HomeAddress = ""
        studentData.PhoneNumber = ""
        studentData.Email = ""
        studentData.NOKName = ""
        studentData.NOKPhoneNumber = ""
        studentData.NOKAddress = ""
        studentData.SessionID = 1
        studentData.SemesterID = 1
        studentData.DepartmentID = 1
        studentData.ProgrammeID = 1
        studentData.LevelID = 1
        studentData.LPS = ""
        studentData.LPSFrom = ""
        studentData.LPSTo = ""
        studentData.LSA = ""
        studentData.LSAFrom = ""
        studentData.LSATo = ""
        studentData.PhotoURL = ""
        studentData.Passwords = "krcFAS/8yd2hQJK/KzdRr/AHUsmH9cuZIOyRvXoCVLx1GGJfz1kT3yhCRJhrjcnpBcs08tz6a2QMH3k4JYs/gA=="
        studentData.SaltKey = "NgBvOtDm8kKt5CkXuErbQycE+cqyo3lDL8BSz6f20w0="

        ' call CreateSession API
        Dim CreateStatus As Integer = StudentDAL.CreateStudentProfiles(studentData)
        If CreateStatus = 1 Then
            lblUser.Text = "The Student Profile was created successfully."
        Else
            lblUser.Text = "The Student Profile was NOT created successfully."
        End If
    End Sub
End Class
