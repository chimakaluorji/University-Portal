Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Partial Class Admin_ManageSession
    Inherits System.Web.UI.Page
    <WebMethod()> _
  <ScriptMethod()> _
    Public Shared Function InsertData(ByVal SessionName As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim SessionDAL As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL
        Dim SessionData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
        
        
            SessionData.SessionName = SessionName

            ' call CreateSession API
            Dim CreateStatus As Integer = SessionDAL.CreateSession(SessionData)
            If CreateStatus = 1 Then
                msg = "The Session was created successfully."
            Else
                msg = "The Session was NOT created successfully."
            End If


        Return msg
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function UpdateData(ByVal ESessionName As String, ByVal EPID As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim SessionData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
        Dim SessionDal As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL

        'Populate Session data
        SessionData.SessionName = ESessionName
        SessionData.SessionID = CInt(EPID)

        ' call UpdateSessionById API
        Dim EditStatus As Integer = SessionDal.UpdateSession(SessionData)
        If EditStatus = 1 Then
            msg = "The Session was Updated successfully."
        End If

        If EditStatus = 0 Then
            msg = "The Session was NOT Updated successfully."
        End If


        Return msg
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function DeleteData(ByVal EPID As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim SessionData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
        Dim SessionDal As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL

        'Populate Session data
        SessionData.SessionID = CInt(EPID)

        ' call UpdateSessionById API
        Dim DeleteStatus As Integer = SessionDal.DeleteSession(SessionData.SessionID)
        If DeleteStatus = 1 Then
            msg = "The Session was Deleted successfully."
        End If

        If DeleteStatus = 0 Then
            msg = "The Session was NOT Deleted successfully."
        End If


        Return msg
    End Function
    <WebMethod()> _
 <ScriptMethod()> _
    Public Shared Function GetSessionName(ByVal PID As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim SessionDAL As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL
        Dim SessionData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData

        Dim SessionID As Integer = CInt(PID)
        SessionData = SessionDAL.FindSessionByID(SessionID)
        msg = SessionData.SessionName

        Return msg
    End Function
    
    'Protected Sub lbtnEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnEdit.Click
    '    'Intantiate objects for accessing User Data and Business Layers
    '    Dim SessionData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
    '    Dim SessionDal As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL

    '    'Populate Session data
    '    SessionData.SessionName = Me.txtSession1.Text
    '    SessionData.SessionID = CInt(Me.lblPrimaryKey.Text)

    '    ' call UpdateSessionById API
    '    Dim EditStatus As Integer = SessionDal.UpdateSession(SessionData)
    '    If EditStatus = 1 Then
    '        lblError.ForeColor = Drawing.Color.Green
    '        lblError.Text = "The Session was modified successfully."
    '        'Return to the SessionList Page.
    '        'Response.Redirect("PageSession.aspx")
    '    Else
    '        lblError.ForeColor = Drawing.Color.Red
    '        lblError.Text = "Error occured while Editing the Session."
    '    End If
    'End Sub

    'Protected Sub lbtnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtnDelete.Click
    '    Dim SessionData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
    '    Dim SessionDal As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL

    '    ' call deleteUser API
    '    Dim DeleteStatus As Integer = SessionDal.DeleteSession(Me.lblPrimaryKey.Text)
    '    If DeleteStatus = 1 Then
    '        lblError.ForeColor = Drawing.Color.Green
    '        lblError.Text = "The Session was deleted successfully."
    '        'Return to the SessionList Page.
    '        'Response.Redirect("PageSession.aspx")
    '    Else
    '        lblError.ForeColor = Drawing.Color.Red
    '        lblError.Text = "Error occured while Deleting the Session."
    '    End If
    'End Sub
End Class
