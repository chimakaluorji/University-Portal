Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic

Imports System
Imports System.Web
Imports System.IO
Partial Class Admin_AdminUploadStudentProfile
    Inherits System.Web.UI.Page
    <WebMethod()> _
  <ScriptMethod()> _
    Public Shared Function InsertStudentProfileData(ByVal EExcelUrl As String, ByVal ESessionID As String, ByVal ESemesterID As String, ByVal ELevelID As String) As String

        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim StudentDal As StudentDAL = New StudentDAL
        Dim StudentData As StudentData = New StudentData

        Dim EncryptDAL As EncryptionUtil = New EncryptionUtil

        Dim strConn1 As String

        Dim SerialNo As String = String.Empty
        Dim PIN As String = String.Empty

        Dim FileExtension As String = String.Empty
        Dim UrlStringArray As String() = {"", ""}

        UrlStringArray = EExcelUrl.Split(".")
        FileExtension = UrlStringArray(1)


        If FileExtension = "xls" Then
            strConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.Server.MapPath(EExcelUrl) + "; Extended Properties='Excel 8.0;HDR=YES'"

        Else
            strConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.Server.MapPath(EExcelUrl) + "; Extended Properties='Excel 12.0 Xml;HDR=YES'"
        End If


        Dim conn As New OleDb.OleDbConnection(strConn1)
        conn.Open()
        Dim OledbImportRecommend As New OleDb.OleDbDataAdapter(" SELECT * FROM [Sheet1$] ", conn)

        Dim myDataSet = New DataSet
        OledbImportRecommend.Fill(myDataSet, "Sheet1")

        For Each dr As DataRow In myDataSet.Tables(0).Rows

            StudentData.RegNumber = dr(0).ToString()
            StudentData.Surname = dr(1).ToString
            StudentData.FirstName = dr(2).ToString
            StudentData.SessionID = CInt(ESessionID)
            StudentData.SemesterID = CInt(ESemesterID)
            StudentData.LevelID = CInt(ELevelID)

            Dim Sucesses As Integer = StudentDal.UploadStudentProfiles(StudentData)
        Next

        msg = "Success"
        Return msg
    End Function
   
End Class
