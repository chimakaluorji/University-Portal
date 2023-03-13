Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Net
Imports System.IO
Partial Class Students_StudentEditPhoneNumber
    Inherits System.Web.UI.Page
    <WebMethod()> _
    Public Shared Function InsertData(ByVal regNumber As String, ByVal PhoneNumber As String) As String
        Dim Msg As String = ""


        Dim IEncrypt As Encryption = New Encryption
        Dim newRegNumber As String = IEncrypt.Decrypt(regNumber, "123456789")

        'Intantiate objects for accessing User Data and Business Layers
        Dim PhoneNoDAL As StudentProfileDAL = New StudentProfileDAL

        ' call CreateLevel API
        Dim CreateStatus As Integer = PhoneNoDAL.EditPhoneNumber(PhoneNumber, newRegNumber)
        If CreateStatus = 1 Then
            Msg = "The Phone Number was Edited successfully."
        Else
            Msg = "The Phone Number was 'NOT' Edited successfully."
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
    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim reg As String = Request.QueryString("RegNumber").Trim
    '    GCM_Send(reg)
    'End Sub
End Class
