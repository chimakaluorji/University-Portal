Imports System.Data
Partial Class Students_PrintStudentReceipt
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim RegistrationNumber As String = Request.QueryString("regNumber")
        Dim PIN As String = Request.QueryString("PIN")

        'Intantiate objects for accessing User Data and Business Layers
        Dim StudentProfileDal As StudentProfileDAL = New StudentProfileDAL
        Dim StudentProfileData As StudentProfileData = New StudentProfileData
        Dim ETransactionID As Integer = CInt(PIN)

        Dim IEncrypt As Encryption = New Encryption
        Dim RegNumber As String = IEncrypt.Decrypt(RegistrationNumber, "123456789")

        StudentProfileData = StudentProfileDal.FindstudentSchoolFeesByID_Portal(RegNumber, ETransactionID)
       
        'Working on session
        Dim splitRetSession As String() = StudentProfileData.SessionName.Split("/")
        Dim newRetSession As String = splitRetSession(1)
        Dim newDate As New Date
        Dim myDate As String = newDate.Month & "" & newDate.Day & ", " & newDate.Year

        
        lblReceiptNo1.Text = StudentProfileData.ETransactPin
        lblReceiptNo2.Text = StudentProfileData.RegNumber
        lblReceiptNo3.Text = newRetSession
        lblStudentName.Text = StudentProfileData.Firstname
        lblAddress.Text = StudentProfileData.PermenentHomeAddr
        lblStudnetPhoneNo.Text = StudentProfileData.PhoneNumber
        lblReceiptDate.Text = myDate
        lblSemester.Text = StudentProfileData.Semester
        lblSession.Text = StudentProfileData.SessionName
        lblUnitPrice.Text = StudentProfileData.Amount
        lblTotalPrice.Text = StudentProfileData.Amount
        lblSubTotal.Text = StudentProfileData.Amount
        lblMainTotal.Text = StudentProfileData.Amount


    End Sub
End Class
