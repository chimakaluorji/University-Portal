Imports System.Data
Partial Class Application_Notification
    Inherits System.Web.UI.Page
    Public Url As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim AppNumber As String = Request.QueryString("ApNo")
        lblApplicationNumber.Text = AppNumber
        Url = AppNumber

        'instantiate object to hold user data
        Dim StudentData As DataSet = New DataSet

        Dim QueueList As New ArrayList
        Dim QPDal As ApplicationFormDAL = New ApplicationFormDAL

        StudentData = QPDal.ApplicationFormByApplicationNumber(AppNumber)

        Dim Conf As String = ""

        If StudentData.Tables(0).Rows.Count > 0 Then
            Conf = StudentData.Tables(0).Rows(0).Item("Confirmed")
        End If

        If Conf = "YES" Then
            lblConfirmed.ForeColor = Drawing.Color.Green
            lblConfirmed.Text = "Yes, please proceed to the Institution for details on what to do next."
        Else
            lblConfirmed.ForeColor = Drawing.Color.Red
            lblConfirmed.Text = "No, still processing it."
        End If
    End Sub
End Class
