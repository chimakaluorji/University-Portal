Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient

Imports System.Net
Imports System.IO

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class chat
     Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function getUserByRegID(ByVal RegID As String) As DataSet
        Dim RetData As New DataSet

        Try
            'Saving user data
            Dim Conn As SqlConnection = New SqlConnection

            Conn.ConnectionString = ConfigurationManager.ConnectionStrings("ResultManagerConnectionString").ConnectionString

            Conn.Open()
            Dim cmd As SqlCommand

            cmd = New SqlCommand
            cmd.Connection = Conn

            cmd.CommandText = "Select Name,Phone from PushChat where RegID = '" & RegID & "'"

            cmd.CommandType = Data.CommandType.Text
            'cmd.ExecuteNonQuery()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            da.Fill(RetData)
            Conn.Close()


            Return RetData
        Catch ex As Exception
            'Declare Dataset for return success mesage
            Dim table_1 As DataTable = New DataTable("Table")
            table_1.Columns.Add("medication")
            table_1.Rows.Add("The Comment was NOT successfully Made.", "")

            RetData.Tables.Add(table_1)
            Return RetData
        End Try

        'Return RetData
    End Function

    <WebMethod()> _
    Public Function deleteUserByRegID(ByVal RegID As String) As DataSet
        Dim RetData As New DataSet

        Try
            'Saving user data
            Dim Conn As SqlConnection = New SqlConnection

            Conn.ConnectionString = ConfigurationManager.ConnectionStrings("ResultManagerConnectionString").ConnectionString

            Conn.Open()
            Dim cmd As SqlCommand

            cmd = New SqlCommand
            cmd.Connection = Conn

            cmd.CommandText = "DELETE FROM PushChat  WHERE RegID = '" & RegID & "'"

            cmd.CommandType = Data.CommandType.Text
            cmd.ExecuteNonQuery()


            'Declare Dataset for return success mesage
            Dim table_1 As DataTable = New DataTable("Table")
            table_1.Columns.Add("msg")
            table_1.Rows.Add("Removed Sucessfully")

            RetData.Tables.Add(table_1)

            Return RetData
        Catch ex As Exception
            'Declare Dataset for return success mesage
            Dim table_1 As DataTable = New DataTable("Table")
            table_1.Columns.Add("msg")
            table_1.Rows.Add("Cannot Removed User Sucessfully.")

            RetData.Tables.Add(table_1)
            Return RetData
        End Try


        'Return RetData
    End Function

    <WebMethod()> _
    Public Function loginUserByRegIDNamePhoneNo(ByVal RegID As String, ByVal Name As String, ByVal PhoneNo As String) As DataSet

        Dim RetData As New DataSet
        Dim CheckRetData As New DataSet

        Try
            'Fetching User Data
            Dim Conn As SqlConnection = New SqlConnection

            Conn.ConnectionString = ConfigurationManager.ConnectionStrings("ResultManagerConnectionString").ConnectionString

            Conn.Open()
            Dim cmd As SqlCommand

            cmd = New SqlCommand
            cmd.Connection = Conn

            cmd.CommandText = "Select Name from PushChat where Phone = '" & PhoneNo & "'"

            cmd.CommandType = Data.CommandType.Text
            'cmd.ExecuteNonQuery()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            da.Fill(CheckRetData)


            Dim retValue As Integer = 0

            retValue = CheckRetData.Tables(0).Rows.Count

            If retValue = 0 Then
                'Saving user data


                Dim cmd_1 As SqlCommand

                cmd_1 = New SqlCommand
                cmd_1.Connection = Conn

                cmd_1.CommandText = "INSERT INTO PushChat (RegID, Name, Phone) values " _
                    & "('" & RegID & "','" & Name & "','" & PhoneNo & "')"

                cmd_1.CommandType = Data.CommandType.Text
                cmd_1.ExecuteNonQuery()


                'Declare Dataset for return success mesage
                Dim table_1 As DataTable = New DataTable("Table_1")
                table_1.Columns.Add("msg")
                table_1.Rows.Add("Sucessfully Registered")

                RetData.Tables.Add(table_1)

                Return RetData
            Else
                'Declare Dataset for return success mesage
                Dim table_2 As DataTable = New DataTable("Table_2")
                table_2.Columns.Add("msg")
                table_2.Rows.Add("User already Registered")

                RetData.Tables.Add(table_2)

                Return RetData
            End If

            Conn.Close()

        Catch ex As Exception
            'Declare Dataset for return success mesage
            Dim table_1 As DataTable = New DataTable("Table")
            table_1.Columns.Add("msg")
            table_1.Rows.Add("Cannot Register User Sucessfully.")

            RetData.Tables.Add(table_1)
            Return RetData
        End Try

        'Return RetData
    End Function

    <WebMethod()> _
    Public Function sendMsg(ByVal phoneNo As String, ByVal sendMsgs As String) As DataSet
        Dim RetData As New DataSet
        Dim AllData As New DataSet

        Try
            'Saving user data
            Dim Conn As SqlConnection = New SqlConnection

            Conn.ConnectionString = ConfigurationManager.ConnectionStrings("ResultManagerConnectionString").ConnectionString

            Conn.Open()
            Dim cmd As SqlCommand

            cmd = New SqlCommand
            cmd.Connection = Conn

            cmd.CommandText = "Select RegID,Name,Phone from PushChat where Phone = '" & phoneNo & "'"

            cmd.CommandType = Data.CommandType.Text
            'cmd.ExecuteNonQuery()
            Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
            da.Fill(AllData)
            Conn.Close()

            Dim RegID As String = AllData.Tables(0).Rows(0).Item(0)
            Dim PhoneNumber As String = AllData.Tables(0).Rows(0).Item(1)
            Dim FullName As String = AllData.Tables(0).Rows(0).Item(2)
            Dim Msg As String = sendMsgs

            AndroidPush(RegID, Msg, PhoneNumber, FullName)

            'Declare Dataset for return success mesage
            Dim table_1 As DataTable = New DataTable("Table_1")
            table_1.Columns.Add("msg")
            table_1.Rows.Add("Sent")

            RetData.Tables.Add(table_1)
            Return RetData
        Catch ex As Exception
            'Declare Dataset for return success mesage
            Dim table_1 As DataTable = New DataTable("Table")
            table_1.Columns.Add("msg")
            table_1.Rows.Add("Failure")

            RetData.Tables.Add(table_1)
            Return RetData
        End Try

    End Function


    'Android push message to GCM server method                                                                                       
    Private Sub AndroidPush(ByVal regId As String, ByVal msg As String, ByVal PhoneNumber As String, ByVal FullName As String)
        ' your RegistrationID paste here which is received from GCM server.                                                               
        'Dim regId As String = "APA91bGsh6Z-SXieTKgv72thAtnou6aYWFRtqjVjKa48OunF_YBZZAs2DtCNDyiOl0GOmnSXBXCjqwxDmoNxLUKu_h71XppvVmLNujdf_aapiQz5uCYgTIvcqb-27JFO9DppiBHJBC9G"

        Dim applicationID = "AIzaSyDHL-nvNTpMeUpBM7DIO8bC0oggK-RKoPU"

        Dim SENDER_ID = "731860461443"

        Dim value = msg 'txtMsg.Text
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
    End Sub
End Class