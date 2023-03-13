Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Partial Class Admin_ManageTransactionLog
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function InsertData(ByVal TransactionCode As Integer, ByVal Activity As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim ProgrammeDAL As TransactionLogDAL = New TransactionLogDAL
        Dim ProgrammeData As TransactionLogData = New TransactionLogData

        ProgrammeData.TransactionCode = TransactionCode
        ProgrammeData.Activity = Activity

        'call CreateTransactionLog API
        Dim CreateStatus As Integer = ProgrammeDAL.CreateTransactionCode(ProgrammeData)
        If CreateStatus = 1 Then
            msg = "Transaction Code was created successfully."
        Else
            msg = "Transaction Code was NOT created successfully."
        End If
        Return msg
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function UpdateData(ByVal TransactionCode As String, ByVal Activity As String, ByVal EPID As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim TransactionLogData As TransactionLogData = New TransactionLogData
        Dim TransactionLogDal As TransactionLogDAL = New TransactionLogDAL

        'Populate Session data
        TransactionLogData.TransactionCodeID = CInt(EPID)
        TransactionLogData.TransactionCode = TransactionCode
        TransactionLogData.Activity = Activity

        ' call UpdateDeptById API
        Dim EditStatus As Integer = TransactionLogDal.UpdateTransactionCode(TransactionLogData)
        If EditStatus = 1 Then
            msg = "Transaction Code was Updated successfully."
        End If

        If EditStatus = 0 Then
            msg = "Transaction Code was NOT Updated successfully."
        End If
        Return msg
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function DeleteData(ByVal EPID As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim TransactionLogData As TransactionLogData = New TransactionLogData
        Dim TransactionLogDal As TransactionLogDAL = New TransactionLogDAL

        'Populate Session data
        TransactionLogData.TransactionCodeID = CInt(EPID)

        ' call UpdateSessionById API
        Dim DeleteStatus As Integer = TransactionLogDal.DeleteTransactionCode(TransactionLogData.TransactionCodeID)
        If DeleteStatus = 1 Then
            msg = "Transaction Code was Deleted successfully."
        End If

        If DeleteStatus = 0 Then
            msg = "Transaction Code was NOT Deleted successfully."
        End If
        Return msg
    End Function
    <WebMethod()> _
 <ScriptMethod()> _
    Public Shared Function GetTransactionCode(ByVal PID As String) As Array
        Dim msg As String() = {"", ""}

        'Intantiate objects for accessing User Data and Business Layers
        Dim TransactionLogDAL As TransactionLogDAL = New TransactionLogDAL
        Dim TransactionLogData As TransactionLogData = New TransactionLogData

        Dim TransactionCodeID As Integer = CInt(PID)
        TransactionLogData = TransactionLogDAL.FindTransactionCodeByID(TransactionCodeID)

        'fetching array values
        msg(0) = TransactionLogData.TransactionCode
        msg(1) = TransactionLogData.Activity
        Return msg
    End Function
End Class
