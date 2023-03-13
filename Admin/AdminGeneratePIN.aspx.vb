Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Imports Microsoft.ApplicationBlocks.Data
Partial Class Admin_AdminGeneratePIN
    Inherits System.Web.UI.Page
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetePIN() As ArrayList
        'Instance declaration 
        Dim QueueList As New ArrayList

        'Generate PIN API (Working)
        Dim KeyGen As RandomKeyGenerator
        Dim SerialNo As Integer = 1

        KeyGen = New RandomKeyGenerator
        'KeyGen.KeyLetters = "abcdefghijklmnopqrstuvwxyz"
        'KeyGen.KeyNumbers = "abcdefghijklmnopqrstuvwxyz"
        KeyGen.KeyLetters = "123456789"
        KeyGen.KeyNumbers = "987654321"
        KeyGen.KeyChars = 15


        Dim ETransactPin As New DataTable()
        ETransactPin.Columns.Add("Serial No", Type.GetType("System.String"))
        ETransactPin.Columns.Add("ETransactPin", Type.GetType("System.String"))

        Dim rng As New Random

        For i As Integer = 0 To 2500

            Dim digits As String = GenerateDigits(rng, 15)

            ETransactPin.Rows.Add()
            ETransactPin.Rows(i)(0) = SerialNo
            ETransactPin.Rows(i)(1) = digits

            SerialNo = SerialNo + 1
        Next

        Dim ds As DataSet = New DataSet
        ds.Tables.Add(ETransactPin)

        For Each row As DataRow In ds.Tables(0).Rows
            QueueList.Add(New PINGeneratorArrayData(row(0), row(1)))
        Next

        Return QueueList
    End Function
    Private Shared Function GenerateDigits(ByVal rng As Random, _
                   ByVal length As Integer) As String
        Dim chArray As Char() = New Char(length - 1) {}
        Dim i As Integer
        For i = 0 To length - 1
            chArray(i) = Convert.ToChar(rng.Next(10) + &H30)
        Next i
        Return New String(chArray)
    End Function
End Class
