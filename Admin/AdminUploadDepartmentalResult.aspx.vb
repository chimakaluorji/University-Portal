Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class Admin_AdminUploadDepartmentalResult
    Inherits System.Web.UI.Page
    <WebMethod()> _
    Public Shared Function GetCourse(ByVal SessionID As String, ByVal LevelID As String) As ArrayList
        'Instance declaration 
        Dim QueueList As New ArrayList


        Dim intSessionID As Integer = CInt(SessionID)
        Dim intLevelID As Integer = CInt(LevelID)

        Dim SeDal As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL
        Dim RetDat As DataSet = SeDal.FindAllSemestersBySessionIDLevelID(intSessionID, intLevelID)


        For Each row As DataRow In RetDat.Tables(0).Rows
            QueueList.Add(New FindAllCoursesArrayData1(row(0), row(1)))
        Next

        Return QueueList
    End Function

    <WebMethod()> _
    Public Shared Function GetCourseCode(ByVal SessionID As String, ByVal SemesterID As String, ByVal LevelID As String) As ArrayList
        'Instance declaration 
        Dim QueueList As New ArrayList


        Dim intSessionID As Integer = CInt(SessionID)
        Dim intSemesterID As Integer = CInt(SemesterID)
        Dim intLevelID As Integer = CInt(LevelID)

        Dim SeDal As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL
        Dim RetDat As DataSet = SeDal.FindAllCoursesForUpload(intSessionID, intSemesterID, intLevelID)

        For Each row As DataRow In RetDat.Tables(0).Rows
            QueueList.Add(New FindAllCourseCodeArrayData(row(0)))
        Next

        Return QueueList
    End Function

    <WebMethod()> _
    Public Shared Function UploadResult(ByVal courseCode As String, ByVal excelUrl As String, ByVal Session As String, ByVal Semester As String, ByVal Level As String, ByVal dataRowCount As Integer) As String

        'Intantiate objects for accessing User Data and Business Layers
        Dim GradeDAL As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL
        Dim GradeData As SessionLevelSemesterCourseData = New SessionLevelSemesterCourseData


        Dim message As String = String.Empty

        Dim arlist As New ArrayList

        'Upload(Photo)
        Dim messageFace1 As String = String.Empty
        Dim RetValue1 As String = String.Empty

        Dim FileExtension As String = String.Empty
        Dim UrlStringArray As String() = {"", ""}

        Dim strConn1 As String

        UrlStringArray = excelUrl.Split(".")
        FileExtension = UrlStringArray(1)

        Dim SeDal As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL

        'Dim tempUrl As String = "~/ResultExcelFiles/SHT_EXCEL_3.xls"



        'Dim strConn1 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Context.Server.MapPath(messageFace1) + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1;';"
        If FileExtension = ".xls" Then
            strConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.Server.MapPath(excelUrl) + "; Extended Properties='Excel 8.0;HDR=YES'"

        Else
            strConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.Server.MapPath(excelUrl) + "; Extended Properties='Excel 12.0 Xml;HDR=YES'"
        End If

        Dim conn As New OleDb.OleDbConnection(strConn1)
        conn.Open()
        Dim OledbImportRecommend As New OleDb.OleDbDataAdapter("SELECT * FROM [Sheet1$]", conn)

        Dim myDataSet = New DataSet
        OledbImportRecommend.Fill(myDataSet, "Sheet1")

        Dim IntDataRowCount As Integer = 1

        For Each dr As DataRow In myDataSet.Tables(0).Rows

            'Populate Result data
            GradeData.SessionName = Session
            GradeData.Semester = Semester

            GradeData.LevelName = Level
            GradeData.ResultUploadByID = 0
            GradeData.ResultUrl = message
            GradeData.CreatedByUID = 0

            Dim RegNo As String
            Dim Examination As String
            Dim ContinueAss As String
            Dim Total As String = String.Empty

            GradeData.CourseCode = courseCode

            RegNo = dr(0).ToString()


            Examination = 0.0
            ContinueAss = 0.0

            If Examination = "" Then
                Examination = 0.0
            End If

            If ContinueAss = "" Then
                ContinueAss = 0.0
            End If

            GradeData.RegNumber = RegNo

            GradeData.Exam = Examination
            GradeData.CA = ContinueAss


            If Not IsDBNull(dr(dataRowCount)) Then
                If IsNumeric(dr(dataRowCount)) Then
                    Total = dr(dataRowCount).ToString()
                End If
            End If

            If Total = "" Then
                Total = 0.0
            End If

            GradeData.Total = Total

            Dim GradeRemark() As String = {"", ""}
            Dim Remark As String = String.Empty
            GradeRemark = GradeDAL.FindGradeAndRemarkByTotal(GradeData.Total)
            GradeData.Grade = GradeRemark(0)
            GradeData.Remark = GradeRemark(1)

            GradeData.ResultSheetUrl = message

            Dim RetInt As Integer = GradeDAL.UploadAllStudentResult(GradeData)

            'Dim UrlUploadLink As String

            If RetInt = 0 Then
                message = "fail"
                Return message
                Exit Function
            End If
            Dim ReturnInt As Integer = 0


            ''Upload New Result
            'Dim slsc As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL
            'Dim SesArray As String() = Session.Split("/")
            'Dim Ses As String = SesArray(1)
            'Dim Sem As String = Semester.Replace(" ", "_")
            'Dim lev As String = Level.Replace(" ", "_")
            'Dim TrimCourseCode As String = courseCode.Trim
            'Dim newCourseCode As String = ""
            'newCourseCode = TrimCourseCode.Replace(" ", "_")

            'ReturnInt = slsc.UploadDepartmentalResult_Portal(newCourseCode, Ses, Sem, lev, RegNo, Total)

            'If ReturnInt = 0 Then
            '    message = "fail"
            '    Return message
            '    Exit Function
            'End If

        Next

        message = "success"
        Return message

    End Function
    <WebMethod()> _
    Public Shared Function findDepartmentalResult(ByVal Session As String, ByVal Semester As String, ByVal Level As String) As ArrayList
        Dim SesArray As String() = Session.Split("/")
        Dim Ses As String = SesArray(1)
        Dim Sem As String = Semester.Replace(" ", "_")
        Dim lev As String = Level.Replace(" ", "_")

        Dim Ar As New ArrayList

        Dim sss As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL

        Ar = sss.FindDepartmentalResult_Portal(Ses, Sem, lev)
        Return Ar
    End Function
    <WebMethod()> _
    Public Shared Function FindDepartmentalResultHeader(ByVal Session As String, ByVal Semester As String, ByVal Level As String) As ArrayList
        Dim SesArray As String() = Session.Split("/")
        Dim Ses As String = SesArray(1)
        Dim Sem As String = Semester.Replace(" ", "_")
        Dim lev As String = Level.Replace(" ", "_")

        Dim Ar As New ArrayList

        Dim sss As SessionLevelSemesterCourseDAL = New SessionLevelSemesterCourseDAL

        Ar = sss.FindDepartmentalResultHeader_Portal(Ses, Sem, lev)
        Return Ar
    End Function

    'Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    'UploadResult("ACC 421", "~/ResultExcelFiles/SHT_EXCEL_415.xls", "2017/2018", "HND 2 Second Semester", "HND Accountancy", 1)
    'End Sub

End Class

Public Class FindAllCoursesArrayData1

    Public SemesterID As Integer
    Public SemesterName As String
    Public Sub New(ByVal SemesterID As Integer, ByVal SemesterName As String)

        Me.SemesterID = SemesterID
        Me.SemesterName = SemesterName

    End Sub
End Class

Public Class FindAllCourseCodeArrayData
    Public CourseCode As String
    Public Sub New(ByVal CourseCode As String)
        Me.CourseCode = CourseCode
    End Sub
End Class