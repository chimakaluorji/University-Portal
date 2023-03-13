Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class Students_StudentChangePassword
    Inherits System.Web.UI.Page
    <WebMethod()> _
    Public Shared Function InsertData(ByVal regNumber As String, ByVal NewPassword As String, ByVal OldPassword As String) As String
        Dim Msg As String = ""

        Dim IEncrypt As Encryption = New Encryption
        Dim newRegNumber As String = IEncrypt.Decrypt(regNumber, "123456789")


        'declare object that as encryption tool
        Dim IEncrypt1 As EncryptionUtil = New EncryptionUtil
        Dim OldIEncrypt As EncryptionUtil = New EncryptionUtil

        Dim studentData As StudentProfileData = New StudentProfileData
        Dim StudentDal As StudentProfileDAL = New StudentProfileDAL

        studentData = StudentDal.FindRegNoByRegNo(newRegNumber)

        If studentData Is Nothing Then
            Msg = "Password " & OldPassword & " does not exist. Please type your Old password correctly and try again."
            Return Msg
            Exit Function
        Else
            Dim DecrptedPass As String = IEncrypt1.DecryptData(studentData.Password, studentData.SaltKey)
            If DecrptedPass = OldPassword Then

                ' Encrypt password and generate Salt Key for the password decryption
                Dim PassSaltKey() As String = IEncrypt1.EncryptData(NewPassword)
                'Assign the encrypted password to the password property 
                studentData.NewPassword = PassSaltKey(0)
                'Assign the decryption salt key to saltkey property
                studentData.NewSaltKey = PassSaltKey(1)

                ' call CreateUser API
                Dim CreateStatus As Integer = StudentDal.ChangePassword(studentData)
                If CreateStatus = 1 Then
                    'Response.Redirect("Default.aspx?msg=The User password was changed successfully. Please login with your new password")
                    Msg = "success"
                Else
                    'Publish error message if it fails to create User Information.
                    Msg = "The User password was not changed successfully."
                End If
            Else
                'Publish error message if it fails to create User Information.
               Msg = "The password you supplied do not match with the old password"
            End If
        End If

        Return Msg
    End Function
    <WebMethod()> _
    Public Shared Function GCM_Send(ByVal regNumber As String) As String
        Dim retNothing As String = ""
        Dim IEncrypt As Encryption = New Encryption
        Dim newRegNumber As String = IEncrypt.Decrypt(regNumber, "123456789")

        Dim ds As StudentProfileData = New StudentProfileData
        Dim stdDal As StudentProfileDAL = New StudentProfileDAL

        ds = stdDal.FindPhoneNobyRegNumber(newRegNumber)

        Dim PhoneNumber As String = ds.PhoneNumber
        Dim FullName As String = ds.Firstname & ", " & ds.Surname

        Dim msg As String = FullName & " with Reg. Number " & newRegNumber & " have a problem while editing his/her phone number. Call him/her with this Phone Number " & PhoneNumber

        Dim GCM As GCM = New GCM
        retNothing = GCM.GCM_Sender(regNumber, msg, PhoneNumber, FullName)

        Return retNothing
    End Function
End Class
