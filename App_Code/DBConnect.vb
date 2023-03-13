
Imports System.Configuration
Imports System.Data.SqlClient

Public Class DBConnect

    Private Shared NewCon As SqlConnection
    Private Shared conStr As String = ConfigurationManager.ConnectionStrings("ResultManagerConnectionString").ConnectionString

    Public Shared Function getConnection() As SqlConnection
        NewCon = New SqlConnection(conStr)
        Return NewCon

    End Function

    Public Sub New()
    End Sub

End Class
