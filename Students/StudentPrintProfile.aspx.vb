
Partial Class Students_StudentPrintProfile
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        'Intantiate objects for accessing User Data and Business Layers
        Dim StudentDal As StudentDAL = New StudentDAL
        Dim StudentData As StudentData = New StudentData

        Dim regNumber As String = Request.QueryString("RegNumber").Trim
        Dim IEncrypt As Encryption = New Encryption
        Dim newRegNumber As String = IEncrypt.Decrypt(regNumber, "123456789")

        StudentData = StudentDal.FindStudentByRegNo(newRegNumber)
        If StudentData IsNot Nothing Then
            lblRegNumber.Text = StudentData.RegNumber
            lblSurname.Text = StudentData.Surname
            lblFirstname.Text = StudentData.FirstName
            lblMiddleName.Text = StudentData.MiddleName
            lblMothersMaidenName.Text = StudentData.MothersMaidenName
            lblDateofBirth.Text = StudentData.DOB
            lblSex.Text = StudentData.Sex
            lblState.Text = StudentData.StateName
            lblLGA.Text = StudentData.LGAName
            lblHomeAddress.Text = StudentData.HomeAddress
            lblPhoneNumber.Text = StudentData.PhoneNumber
            lblEmailAddress.Text = StudentData.Email
            lblPhoneOfNextOfKin.Text = StudentData.NOKName
            lblSession.Text = StudentData.SessionName
            lblSemester.Text = StudentData.Semester
            lblLevel.Text = StudentData.Level
            lblPrimarySchoolAttended.Text = StudentData.LPS
            lblPFrom.Text = StudentData.LPSFrom
            lblPTo.Text = StudentData.LPSTo
            lblSecondarySchoolAttended.Text = StudentData.LSA
            lblSFrom.Text = StudentData.LSAFrom
            lblSTo.Text = StudentData.LSATo
            StudentPhotoUrl.ImageUrl = StudentData.PhotoURL
        End If
    End Sub
End Class
