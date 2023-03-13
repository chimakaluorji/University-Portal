Imports Microsoft.VisualBasic
Imports System.Net
Imports System.IO
Public Class GCM
   
    Public Function GCM_Sender(ByVal regNumber As String, ByVal msg As String, ByVal PhoneNumber As String, ByVal FullName As String) As String
        Dim Msgs As String = ""

        Dim regId As String = "APA91bGsh6Z-SXieTKgv72thAtnou6aYWFRtqjVjKa48OunF_YBZZAs2DtCNDyiOl0GOmnSXBXCjqwxDmoNxLUKu_h71XppvVmLNujdf_aapiQz5uCYgTIvcqb-27JFO9DppiBHJBC9G"

        Dim applicationID = "AIzaSyDHL-nvNTpMeUpBM7DIO8bC0oggK-RKoPU"

        Dim SENDER_ID = "731860461443"

        'Dim value = msg 'txtMsg.Text
        'message text box                                                                               
        Dim tRequest As WebRequest

        tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send")

        tRequest.Method = "post"

        tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8"

        tRequest.Headers.Add(String.Format("Authorization: key={0}", applicationID))

        tRequest.Headers.Add(String.Format("Sender: id={0}", SENDER_ID))

        tRequest.UseDefaultCredentials = True
        tRequest.PreAuthenticate = True
        tRequest.Credentials = CredentialCache.DefaultCredentials

        'Data post to server                                                                                                                                         
        Dim postData As String = (Convert.ToString("collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.msg=" + msg + "&data.fromu=" + PhoneNumber + "&data.name=" + FullName + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=") & regId) + ""

        Dim byteArray As [Byte]() = Encoding.UTF8.GetBytes(postData)

        tRequest.ContentLength = byteArray.Length

        Dim dataStream As Stream = tRequest.GetRequestStream()

        dataStream.Write(byteArray, 0, byteArray.Length)

        dataStream.Close()

        Dim tResponse As WebResponse = tRequest.GetResponse()

        dataStream = tResponse.GetResponseStream()

        Dim tReader As New StreamReader(dataStream)

        Dim sResponseFromServer As [String] = tReader.ReadToEnd()
        'Get response from GCM server.
        'lblDisplay.Text = sResponseFromServer
        'Assigning GCM response to Label text 
        tReader.Close()

        dataStream.Close()
        tResponse.Close()
        Return Msgs
    End Function
End Class
