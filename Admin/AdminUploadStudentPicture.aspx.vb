Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Partial Class Admin_AdminUploadStudentPicture
    Inherits System.Web.UI.Page
    <WebMethod()> _
  <ScriptMethod()> _
    Public Shared Function UploadPicture(ByVal RegNumber As String, ByVal PhotoUrl As String) As String
        Dim Student As StudentProfileData = New StudentProfileData
        Dim StudentDal As StudentProfileDAL = New StudentProfileDAL

        Dim StudentProfile As StudentProfileDAL = New StudentProfileDAL

        'Upload(Photo)
        Dim Msg As String = ""

        Student = StudentDal.FindAllStudentsByRegNo(RegNumber.Trim)

        If Student IsNot Nothing Then

            Dim RetValue As Integer = StudentProfile.UploadPix(PhotoUrl, RegNumber.Trim)

            If RetValue = 1 Then
                Msg = "The picture was successfully uploaded."
            Else
                Msg = "The picture was not successfully uploaded."
            End If
        Else
            Msg = "Invalid Registration Number"
            Return Msg
            Exit Function
        End If

        Return Msg
    End Function
End Class
