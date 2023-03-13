Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Net

Public Class UserDAL
    Inherits DataAccessBase
    Public Function FindUserNameByUserID(ByVal UserID As String) As UserData
        'instantiate object to hold user data
        Dim userData As UserData = New UserData

        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@UserID", UserID)}
        'specify output parameters.

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindUserNameByUserID", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        userData.UserID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        userData.Surname = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        userData.FirstName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        userData.UserName = row(3)
                    End If
                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        Return userData
    End Function
    Public Function FindUsersByUserName(ByVal UserName As String) As UserData
        'instantiate object to hold user data
        Dim userData As UserData = New UserData

        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@UserName", UserName)}
        'specify output parameters.

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindUsersByUserName", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        userData.UserID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        userData.Surname = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        userData.FirstName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        userData.Sex = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        userData.EmailAddress = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        userData.PhoneNumber = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        userData.PhotoUrl = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        userData.UserName = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        userData.Passwords = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        userData.SaltKey = row(9)
                    End If
                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        Return userData
    End Function
End Class
