Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class AdminSendSMS
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function SendSMS(ByVal regNumber As String, ByVal msg As String) As Array
        'Instance declaration 

        Dim success As String() = {"", ""}

        Dim SendAllSMS As AdminSendSMS = New AdminSendSMS
        success(0) = SendAllSMS.SendAllSMS(regNumber, msg)
        success(1) = "success"

        Return success
    End Function
    Private Function SendAllSMS(ByVal RegNumber As String, ByVal msg As String) As String
        Dim ReturnUrl As String = ""
        Dim ReturnMsg As String = ""
        Dim SendID As String = "Heri Poly"

        Dim Ret As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL

        Dim PhoneNO As String = Ret.FindPhoneNoByRegNO(RegNumber)

        ReturnUrl = "http://mobileautomatedsystems.com/index.php?option=com_spc&comm=spc_api&username=chimakaluorji&password=p@ssw0rd&sender=" & SendID & "&recipient=" & PhoneNO & "&message=" & msg & ""

        Dim wc As System.Net.WebClient = New System.Net.WebClient()

        Dim webReader As System.IO.StreamReader = New System.IO.StreamReader(wc.OpenRead(ReturnUrl))

        Dim webPageData As String = webReader.ReadToEnd()
        Dim splitMsg As String() = webPageData.Split(" ")

        If splitMsg(0) = "OK" Then
            ReturnMsg = "The SMS Sent successfully. Unit Used: " & splitMsg(1)
        Else

            If splitMsg(0) = "2904" Then
                ReturnMsg = "Error Occurred. SMS Sending Failed"
            ElseIf splitMsg(0) = "2905" Then
                ReturnMsg = "Error Occurred. Invalid username/password combination"
            ElseIf splitMsg(0) = "2906" Then
                ReturnMsg = "Error Occurred. Credit exhausted"
            ElseIf splitMsg(0) = "2907" Then
                ReturnMsg = "Error Occurred. Gateway unavailable"
            ElseIf splitMsg(0) = "2908" Then
                ReturnMsg = "Error Occurred. Invalid schedule date format"
            ElseIf splitMsg(0) = "2909" Then
                ReturnMsg = "Error Occurred. Unable to schedule"
            ElseIf splitMsg(0) = "2910" Then
                ReturnMsg = "Error Occurred. Username is empty"
            ElseIf splitMsg(0) = "2911" Then
                ReturnMsg = "Error Occurred. Password is empty"
            ElseIf splitMsg(0) = "2912" Then
                ReturnMsg = "Error Occurred. Recipient is empty"
            ElseIf splitMsg(0) = "2913" Then
                ReturnMsg = "Error Occurred. Message is empty"
            ElseIf splitMsg(0) = "2914" Then
                ReturnMsg = "Error Occurred. Sender is empty"
            ElseIf splitMsg(0) = "2915" Then
                ReturnMsg = "Error Occurred.One or more required fields are emptyy"
            End If
        End If

        Return ReturnMsg
    End Function
End Class
