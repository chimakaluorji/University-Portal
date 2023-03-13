Imports System.Data
Partial Class Students_PrintResult_PrintStudentExtraYearResult
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim regRetNumber As String = Request.QueryString("regNo").Trim
        Dim SessionName As String = Request.QueryString("SessionName")
        Dim SemesterName As String = Request.QueryString("SemesterName")

        Dim IEncrypt As Encryption = New Encryption
        Dim RegNumber As String = IEncrypt.Decrypt(regRetNumber, "123456789")

        'Finding Level using regnumber
        Dim stdDal As StudentProfileDAL = New StudentProfileDAL
        Dim stdData As StudentProfileData = New StudentProfileData

        stdData = stdDal.FindLevelByRegNumber(RegNumber)
        Dim LevelName As String = stdData.LevelName

        lblRegNumber.Text = regNumber
        lblSession1.Text = SessionName
        lblSemester1.Text = SemesterName
        lblLevel1.Text = LevelName


        'Intantiate objects for accessing Student Data and Business Layers
        Dim Student As StudentProfileData = New StudentProfileData
        Dim StudentDal As StudentProfileDAL = New StudentProfileDAL

        Student = StudentDal.FindAllStudentsByRegNumber(lblRegNumber.Text)

        Me.lblRegNo.Text = Student.RegNumber
        Me.lblFirstName.Text = Student.Firstname
        Me.lblSurname.Text = Student.Surname
        Me.lblProgramme.Text = Student.LevelName
        Me.lblAcademicSession.Text = Student.SessionName
        Me.lblDate.Text = System.DateTime.Now.Date
        ImgStudent.ImageUrl = Student.PhotoUrl

        'Intantiate objects for accessing Result Data and Dal
        Dim UploadResultDAL As UploadResultDAL = New UploadResultDAL
        Dim UploadResultData As UploadResultData = New UploadResultData
        Dim GPA As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL


        'Me.lblMsg.Text = lblSemester1.Text

        Dim message As String = String.Empty
        Dim RetUploadValue As DataSet = New DataSet
        Dim RetUploadValue1 As DataSet = New DataSet

        ' call Upload student credential API
        RetUploadValue = UploadResultDAL.FindAllResultByRegNumber_ExtraYear(lblSession1.Text, lblSemester1.Text, lblLevel1.Text, lblRegNumber.Text)

        gdvUploadResult.DataSource = RetUploadValue
        gdvUploadResult.DataBind()

        Dim GpaTotal() As String = {"", ""}
        Dim Remark As String = String.Empty
        Dim FinalTotalCal As Decimal

        GpaTotal = GPA.FindAllGPA(lblRegNumber.Text, lblSession1.Text, lblSemester1.Text)
        'Me.lblFirstTotal.Text = "0"

        If GpaTotal(0) <> "" Then
            'Me.lblFirstTotal.Text = GpaTotal(0)
            Dim GpaTotal_1 As Integer = CInt(GpaTotal(1))
            Dim GpaTotal_2 As Integer = CInt(GpaTotal(2))
            FinalTotalCal = GpaTotal_1 / GpaTotal_2
        End If


    End Sub
End Class
