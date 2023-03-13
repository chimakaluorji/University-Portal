Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Partial Class Students_StudentEditPassport
    Inherits System.Web.UI.Page

    <WebMethod()> _
  <ScriptMethod()> _
    Public Shared Function UploadPicture(ByVal RegNumber As String, ByVal PhotoUrl As String) As String
        Dim Student As StudentProfileData = New StudentProfileData
        Dim StudentDal As StudentProfileDAL = New StudentProfileDAL

        Dim StudentProfile As StudentProfileDAL = New StudentProfileDAL

        Dim IEncrypt As Encryption = New Encryption
        Dim newRegNumber As String = IEncrypt.Decrypt(RegNumber, "123456789")

        'Upload(Photo)
        Dim Msg As String = ""

        Student = StudentDal.FindStudentByRegNumberForHomePage(newRegNumber)

        If Student IsNot Nothing Then

            Dim RetValue As Integer = StudentProfile.UploadPix(PhotoUrl, newRegNumber)

            If RetValue = 1 Then
                Msg = "The picture was successfully uploaded."
            Else
                Msg = "The picture was not successfully uploaded."
            End If
        Else
            Msg = Student.AdmissionMode '"Invalid Registration Number"
            Return Msg
            Exit Function
        End If

        Return Msg
    End Function
End Class
