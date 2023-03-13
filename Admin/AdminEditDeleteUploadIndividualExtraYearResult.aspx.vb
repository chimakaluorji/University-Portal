Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class Admin_AdminEditDeleteUploadIndividualExtraYearResult
    Inherits System.Web.UI.Page
    <WebMethod()> _
    Public Shared Function GetStudent(ByVal SessionName As String, ByVal SemesterName As String, ByVal LevelName As String) As ArrayList
        'Instance declaration 
        Dim QueueList As New ArrayList


        Dim SeDal As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL
        Dim RetDat As DataSet = SeDal.FindAllStudentForResultBySessionIDSemesterIDLevelID_ExtraYear(SessionName, SemesterName, LevelName)

        Dim row1 As String = ""
        Dim row2 As String = ""
        Dim row3 As String = ""

        For Each row As DataRow In RetDat.Tables(0).Rows
            If Not IsDBNull(row(0)) Then
                row1 = row(0)
            End If
            If Not IsDBNull(row(1)) Then
                row2 = row(1)
            End If
            If Not IsDBNull(row(2)) Then
                row3 = row(2)
            End If

            QueueList.Add(New FindAllStudentArrayData3(row1, row2, row3))
        Next

        Return QueueList

    End Function
End Class
Public Class FindAllStudentArrayData3

    Public RegNumber As String
    Public Surname As String
    Public Firstname As String
    Public Sub New(ByVal RegNumber As String, ByVal Surname As String, ByVal Firstname As String)

        Me.RegNumber = RegNumber
        Me.Surname = Surname
        Me.Firstname = Firstname

    End Sub
End Class
