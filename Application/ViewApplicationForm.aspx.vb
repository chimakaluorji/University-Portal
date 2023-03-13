Imports System.Data.SqlClient
Imports System.Data
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports System
Imports System.Web
Imports System.IO
Partial Class Application_ViewApplicationForm
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function FindAllApplicationByApplicationNumber(ByVal ApplicationNumber As String) As ArrayList

        'instantiate object to hold user data
        Dim StudentData As DataSet = New DataSet

        Dim QueueList As New ArrayList
        Dim QPDal As ApplicationFormDAL = New ApplicationFormDAL

        StudentData = QPDal.ApplicationFormByApplicationNumber(ApplicationNumber)

        If StudentData.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In StudentData.Tables(0).Rows
                QueueList.Add(New ApplicationFormArrayData(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), _
                                                           row(9), row(10), row(11), row(12), row(13), row(14), row(15), row(16), row(17), _
                                                           row(18), row(19), row(20), row(21), row(22), row(23), row(24), row(25), row(26), _
                                                           row(27), row(28), row(29), row(30), row(31), row(32), row(33), row(34), row(35), _
                                                           row(36), row(37), row(38), row(39), row(40), row(41), row(42), row(43), row(44), _
                                                           row(45), row(46), row(47), row(48), row(49), row(50), row(51), row(52), row(53), _
                                                           row(54), row(55), row(56), row(57), row(58), row(59), row(60), row(61), row(62), _
                                                           row(63), row(64), row(65), row(66), row(67), row(68), row(69), row(70), row(71), _
                                                           row(72), row(73), row(74), row(75), row(76), row(77), row(78), row(79), row(80), _
                                                           row(81), row(82), row(83)))
            Next
        Else
            QueueList.Add(New ApplicationFormArrayData("0", "", "0", "0", "", "", "", "", "", _
                                                       "", "0", "", "", "", "", "", "", "", _
                                                       "", "", "", "", "", "", "", "", "", _
                                                       "", "", "", "", "", "", "", "", "", _
                                                       "", "", "", "", "", "", "", "", "", _
                                                       "", "", "", "", "", "", "", "", "", _
                                                       "", "", "", "", "", "", "", "", "", _
                                                       "", "", "", "", "", "", "", "", "", _
                                                       "", "", "", "", "", "", "", "", "", "", "", ""))
        End If

        Return QueueList
    End Function
End Class
