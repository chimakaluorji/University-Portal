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
Partial Class Admin_UploadPIN
    Inherits System.Web.UI.Page
    <WebMethod()> _
  <ScriptMethod()> _
    Public Shared Function InsertSchoolFeesData(ByVal EimgNameFees As String) As String

        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim ePINDAL As ePINDAL = New ePINDAL
        Dim ePINData As ePINData = New ePINData
        Dim EncryptDAL As EncryptionUtil = New EncryptionUtil

        Dim strConn1 As String

        Dim SerialNo As String = String.Empty
        Dim PIN As String = String.Empty

        Dim FileExtension As String = String.Empty
        Dim UrlStringArray As String() = {"", ""}

        UrlStringArray = EimgNameFees.Split(".")
        FileExtension = UrlStringArray(1)

        Dim std As StudentProfileDAL = New StudentProfileDAL

        If FileExtension = ".xls" Then
            strConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.Server.MapPath(EimgNameFees) + "; Extended Properties='Excel 8.0;HDR=YES'"

        Else
            strConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.Server.MapPath(EimgNameFees) + "; Extended Properties='Excel 12.0 Xml;HDR=YES'"
        End If


        Dim conn As New OleDb.OleDbConnection(strConn1)
        conn.Open()
        Dim OledbImportRecommend As New OleDb.OleDbDataAdapter(" SELECT * FROM [Sheet1$] ", conn)

        Dim myDataSet = New DataSet
        OledbImportRecommend.Fill(myDataSet, "Sheet1")

        For Each dr As DataRow In myDataSet.Tables(0).Rows
            Dim Serial As String = dr(0).ToString()
            Dim PINs As String = dr(1).ToString()
            Dim userID As Integer = 1
           
            Dim retVal As String() = std.UploadPin_New(PINs, Serial, userID)
        Next

        msg = "Success"
        Return msg
    End Function

    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function InsertResultData(ByVal EimgNameResult As String) As String

        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim ePINDAL As ePINDAL = New ePINDAL
        Dim ePINData As ePINData = New ePINData
        Dim EncryptDAL As EncryptionUtil = New EncryptionUtil

        Dim strConn1 As String

        Dim SerialNo As String = String.Empty
        Dim PIN As String = String.Empty

        Dim FileExtension As String = String.Empty
        Dim UrlStringArray As String() = {"", ""}

        UrlStringArray = EimgNameResult.Split(".")
        FileExtension = UrlStringArray(1)

        Dim std As StudentProfileDAL = New StudentProfileDAL

        If FileExtension = ".xls" Then
            strConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.Server.MapPath(EimgNameResult) + "; Extended Properties='Excel 8.0;HDR=YES'"

        Else
            strConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + HttpContext.Current.Server.MapPath(EimgNameResult) + "; Extended Properties='Excel 12.0 Xml;HDR=YES'"
        End If


        Dim conn As New OleDb.OleDbConnection(strConn1)
        conn.Open()
        Dim OledbImportRecommend As New OleDb.OleDbDataAdapter(" SELECT * FROM [Sheet1$] ", conn)

        Dim myDataSet = New DataSet
        OledbImportRecommend.Fill(myDataSet, "Sheet1")

        For Each dr As DataRow In myDataSet.Tables(0).Rows
            Dim Serial As String = dr(0).ToString()
            Dim PINs As String = dr(1).ToString()
            Dim userID As Integer = 1

            Dim retVal As String() = std.UploadResultPin_New(PINs, Serial, userID)

        Next

        msg = "Success"
        Return msg
    End Function

    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim url As String = "~/PINExcelFiles/SHT_EXCEL_3.xlsx"
    '    lblDisplay.Text = InsertSchoolFeesData(url)
    'End Sub
End Class
