<%@ WebHandler Language="VB" Class="excelUploader" %>

Imports System
Imports System.Web
Imports System.IO

Public Class excelUploader : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "text/plain"
        Try
            Dim dirFullPath As String = HttpContext.Current.Server.MapPath("~/ResultExcelFiles/")
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
                    pathToSave_100 = HttpContext.Current.Server.MapPath("~/ResultExcelFiles/") & str_image
                    file.SaveAs(pathToSave_100)
                End If
                
                'If Not String.IsNullOrEmpty(fileName) Then
                '    fileExtension = Path.GetExtension(fileName)
                '    str_image = "SHT_EXCEL_" + numFiles.ToString() + fileExtension
                '    Dim pathToSave As String = HttpContext.Current.Server.MapPath("~/ResultExcelFiles/") + str_image
                '    Dim bmpPostedImage As New System.Drawing.Bitmap(file.InputStream)

                '    'ResizeMyImage method call
                '    Dim objImage As System.Drawing.Image = ResizeMyImage(bmpPostedImage, 200)
                '    objImage.Save(pathToSave, System.Drawing.Imaging.ImageFormat.Jpeg)
                'End If
                
            Next
            '  database record update logic here  ()

            context.Response.Write("~/ResultExcelFiles/" & str_image)

        Catch ac As Exception
        End Try
    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
    
    Public Shared Function ResizeMyImage(image As System.Drawing.Image, maxHeight As Integer) As System.Drawing.Image
        Dim ratio = CDbl(maxHeight) / image.Height
        Dim newWidth = CInt(image.Width * ratio)
        Dim newHeight = CInt(image.Height * ratio)
        Dim newImage = New Drawing.Bitmap(newWidth, newHeight)
        Using g = Drawing.Graphics.FromImage(newImage)
            g.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function
End Class