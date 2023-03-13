'This class manages file upload and download.
'@author: Chima kalu-orji
'@date: 20-11-2008
Imports System
Imports System.Web
Imports System.Diagnostics
Imports System.IO
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Public Class UploadedCAandMessage
    Inherits DataAccessBase
    Sub New()
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Uploads documemt to web server with WebControls.FileUpload control.
    ''' </summary>
    ''' <param name="file"></param>
    ''' <param name="message"></param>
    ''' <returns></returns>
    ''' <remarks>Boolean</remarks>
    Public Shared Function UploadFile(ByRef file As System.Web.UI.WebControls.FileUpload, ByRef message As String, ByRef message1 As String, ByVal RegNo As String, ByVal CredentialType As String) As Boolean
        'Check if FileUpload control has file to upload.
        If Not file.HasFile Then
            message = "No file was selected for upload."
            Return False
        End If

        Dim sessionid As String

        Dim FileFullName As String = file.FileName.ToLower
        message1 = FileFullName

        ' Get the current HTTPContext and the session ID
        Dim context As HttpContext = HttpContext.Current
        sessionid = context.Session.SessionID
        'Get the file extension
        Dim fileExtension As String = System.IO.Path.GetExtension(file.FileName).ToLower()
        Dim allowedExtensions As String() = {".jpeg", ".jpg", ".doc", ".docx", ".pdf", ".txt", ".png", ".xls"}
        Dim counter As Integer

        For counter = 0 To allowedExtensions.Length - 1 Step 1
            If fileExtension = allowedExtensions(counter) Then
                'Check the file type.
                If fileExtension = ".jpg" Or fileExtension = ".jpeg" Then
                    Dim myImage As System.Drawing.Bitmap
                    Try
                        'Specify the directory to save file to.
                        Dim path As String = context.Server.MapPath("~/UploadedCAandMessage/")
                        'Generate unique file name for the file in FileUpload control
                        Dim filename As String = sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & ".jpg"
                        Dim fullpath As String = path & filename
                        'Save file
                        file.PostedFile.SaveAs(fullpath)

                        myImage = New System.Drawing.Bitmap(fullpath)
                        'Check image size after saving and report accordingly.
                        If myImage.Width > 0 Then
                            message = "~/UploadedCAandMessage/" + filename
                            Return True
                        Else
                            message = "Invalid image size! "
                            Return False
                        End If

                    Catch ex As Exception
                        'If error occurs, log it and return false
                        AppException.LogError(ex.Message)
                        message = "Image could not be uploaded at the moment."
                        Return False
                    Finally
                        'Clean up.
                        myImage.Dispose()
                    End Try
                    Exit For
                Else
                    Try
                        'Specify the directory to save file to.
                        Dim path As String = context.Server.MapPath("~/UploadedCAandMessage/")
                        'Generate unique file name for the file in FileUpload control
                        Dim filename As String = sessionid & "_" & RegNo.Substring(5) & "_" & CredentialType & fileExtension
                        Dim fullpath As String = path & filename
                        'Save file
                        file.PostedFile.SaveAs(fullpath)
                        message = "~/UploadedCAandMessage/" + filename
                        Return True
                    Catch ex As Exception
                        'If occurs, log it and return false
                        AppException.LogError(ex.Message)
                        message = "File could not be uploaded at the moment."
                        Return False
                    End Try
                End If
            End If
        Next

        message = "Invalid Document format! Only documents with Extension: '.jpeg', '.jpg', '.doc','.docx', '.pdf', '.txt', '.xls' are allowed"
        Return False
    End Function
End Class
