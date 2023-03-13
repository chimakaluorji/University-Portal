Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data

Partial Class Admin_AdminRetrivePIN
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetePIN(ByVal EregNumber As String) As ArrayList
        'Instance declaration 
        Dim ePINDAL As ePINDAL = New ePINDAL
        Dim QueueList As New ArrayList

        QueueList = ePINDAL.FindePINByRegNumber(EregNumber)

        Return QueueList
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetResultePIN(ByVal EregNumberResult As String) As ArrayList
        'Instance declaration 
        Dim ePINDAL As ePINDAL = New ePINDAL
        Dim QueueList As New ArrayList

        QueueList = ePINDAL.FindResultePINByRegNumber(EregNumberResult)

        Return QueueList
    End Function
End Class
