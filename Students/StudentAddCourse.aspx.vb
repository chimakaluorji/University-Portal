Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Partial Class Students_StudentAddCourse
    Inherits System.Web.UI.Page

    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function InsertChat(ByVal Emsg As String, ByVal Edate As String, ByVal Etime As String) As ArrayList
        'Intantiate objects for accessing User Data and Business Layers
        Dim ChatDAL As ChatDAL = New ChatDAL
        Dim ChatData As ChatData = New ChatData

        Dim QueueList As New ArrayList

        Dim StudentDal As StudentDAL = New StudentDAL
        Dim StudentData As StudentData = New StudentData

        Dim RegNumber As String = "13061001"
        Dim UserID As Integer = 1

        StudentData = StudentDal.FindStudentNameByRegNo(RegNumber)

        ChatData.UserID = UserID
        ChatData.RegNumber = RegNumber
        ChatData.UserMsg = ""
        ChatData.StudentMsg = Emsg
        ChatData.UserName = ""
        ChatData.StudentName = StudentData.Surname & " " & StudentData.FirstName
        ChatData.StudentDate = Edate
        ChatData.UserDate = ""
        ChatData.StudentTime = Etime
        ChatData.UserTime = ""

        ' call CreateSession API
        Dim CreateStatus As Integer = ChatDAL.CreateChat(ChatData)
        If CreateStatus = 1 Then
            'Instance declaration 
            Dim chatNow As ChatDAL = New ChatDAL
            QueueList = chatNow.FindAllChatByRegNumberUserID(RegNumber, UserID, Edate)
        End If

        Return QueueList
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetChat(ByVal Edate As String) As ArrayList
        'Intantiate objects for accessing User Data and Business Layers
        Dim QueueList As New ArrayList

        Dim RegNumber As String = "13061001"
        Dim UserID As Integer = 1

        'Instance declaration 
        Dim chatNow As ChatDAL = New ChatDAL

        QueueList = chatNow.FindAllChatByRegNumberUserID(RegNumber, UserID, Edate)

        Return QueueList
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetAdminChat(ByVal Edate As String) As ArrayList
        'Intantiate objects for accessing User Data and Business Layers
        Dim QueueList As New ArrayList

        Dim UserID As Integer = 1

        'Instance declaration 
        Dim chatNow As ChatDAL = New ChatDAL

        QueueList = chatNow.FindAdminChatByRegNumberUserID(UserID, Edate)

        Return QueueList
    End Function
End Class
