<%@ WebHandler Language="VB" Class="excelStudentProfileUploader" %>

Imports System
Imports System.Web
Imports System.IO

Public Class excelStudentProfileUploader : Implements IHttpHandler
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "text/plain"
        Try
            Dim dirFullPath As String = HttpContext.Current.Server.MapPath("~/StudentProfileExcelFiles/")
            Dim files As String()
            Dim numFiles As Integer
            files = System.IO.Directory.GetFiles(dirFullPath)
            numFiles = files.Length
            numFiles = numFiles + 1
            Dim str_image As String = ""
            Dim pathToSave_100 As String = ""

            For Each s As String In context.Request.Files
                Dim file As HttpPostedFile = context.Request.Files(s)
                Dim fileName As String = file.FileName
                Dim fileExtension As String = file.ContentType

                If Not String.IsNullOrEmpty(fileName) Then
                    fileExtension = Path.GetExtension(fileName)
                    str_image = Convert.ToString("SHT_EXCEL_" + numFiles.ToString()) & fileExtension
                    pathToSave_100 = HttpContext.Current.Server.MapPath("~/StudentProfileExcelFiles/") & str_image
                    file.SaveAs(pathToSave_100)
                End If
            Next
            
            context.Response.Write("~/StudentProfileExcelFiles/" & str_image)

        Catch ac As Exception
        End Try
    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class