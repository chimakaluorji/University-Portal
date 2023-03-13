Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Partial Class Application_UploadDraft
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function UploadPicture(ByVal ApplicationNumber As String, ByVal BankDraftUrl As String) As String
        'Inserting it into the database
        Dim query As String = "Update ApplicationForm SET BankDraftUrl = '" & BankDraftUrl & "' Where  ApplicationNumber = '" & ApplicationNumber & "'"
        Dim constr As String = ConfigurationManager.ConnectionStrings("ResultManagerConnectionString").ConnectionString
        Dim con As New SqlConnection(constr)
        Dim cmd As New SqlCommand(Query)

        cmd.CommandType = CommandType.Text
        cmd.Connection = con
        con.Open()
        Dim sdr As SqlDataReader = cmd.ExecuteReader()
        con.Close()

        Return "success"
    End Function
End Class
