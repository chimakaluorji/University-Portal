Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class getUsers
     Inherits System.Web.Services.WebService
    <WebMethod()> _
    Public Shared Function GetResultePIN(ByVal EregNumber As String) As String()
        'Instance declaration 
        Dim ePINDAL As ePINDAL = New ePINDAL
        Dim QueueList As New ArrayList

        Dim arrayString() As String = {"", ""}

        arrayString(0) = "YES"
        arrayString(1) = "NO YES"

        'QueueList = ePINDAL.FindResultePINByRegNumber(EregNumber)

        Return arrayString
    End Function
    <WebMethod()> _
    Public Function ReturnStudentComment(ByVal RegID As String) As DataSet
        Dim RetData As New DataSet

        Try
            'Saving user data
            Dim Conn As SqlConnection = New SqlConnection

            Conn.ConnectionString = ConfigurationManager.ConnectionStrings("ResultManagerConnectionString").ConnectionString

            Conn.Open()
            Dim cmd As SqlCommand

            cmd = New SqlCommand
            cmd.Connection = Conn

            'cmd.CommandText = "INSERT INTO MoblieAppRecord (AppCommentRegNumber, Comment, PhoneNumber) values " _
            '    & "('" & usersName & "','','')"

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

End Class