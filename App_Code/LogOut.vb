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
Public Class LogOut
    Inherits System.Web.Services.WebService

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

            cmd.CommandText = "DELETE FROM PushChat  WHERE RegID = '" & RegID & "'"

            cmd.CommandType = Data.CommandType.Text
            cmd.ExecuteNonQuery()


            'Declare Dataset for return success mesage
            Dim table_1 As DataTable = New DataTable("Table")
            table_1.Columns.Add("medication")
            table_1.Rows.Add("Removed Sucessfully", "")

            RetData.Tables.Add(table_1)

            Return RetData
        Catch ex As Exception
            'Declare Dataset for return success mesage
            Dim table_1 As DataTable = New DataTable("Table")
            table_1.Columns.Add("medication")
            table_1.Rows.Add("Cannot Removed Sucessfully.", "")

            RetData.Tables.Add(table_1)
            Return RetData
        End Try

        'Return RetData
    End Function

End Class