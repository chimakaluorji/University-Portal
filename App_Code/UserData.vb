﻿Imports Microsoft.VisualBasic

Public Class UserData
    Private _UserID As Integer
    Private _Surname As String
    Private _FirstName As String
    Private _Sex As String
    Private _EmailAddress As String
    Private _PhoneNumber As String
    Private _PhotoUrl As String
    Private _UserName As String
    Private _Passwords As String
    Private _SaltKey As String
    Public Sub New()

    End Sub

    Public Property UserID() As Integer
        Get
            Return _UserID
        End Get
        Set(ByVal value As Integer)
            _UserID = value
        End Set
    End Property
    Public Property Surname() As String
        Get
            Return _Surname
        End Get
        Set(ByVal value As String)
            _Surname = value
        End Set
    End Property


    Public Property FirstName() As String
        Get
            Return _FirstName
        End Get
        Set(ByVal value As String)
            _FirstName = value
        End Set
    End Property
    Public Property Sex() As String
        Get
            Return _Sex
        End Get
        Set(ByVal value As String)
            _Sex = value
        End Set
    End Property
    Public Property EmailAddress() As String
        Get
            Return _EmailAddress
        End Get
        Set(ByVal value As String)
            _EmailAddress = value
        End Set
    End Property
    Public Property PhoneNumber() As String
        Get
            Return _PhoneNumber
        End Get
        Set(ByVal value As String)
            _PhoneNumber = value
        End Set
    End Property
    Public Property PhotoUrl() As String
        Get
            Return _PhotoUrl
        End Get
        Set(ByVal value As String)
            _PhotoUrl = value
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property
    Public Property Passwords() As String
        Get
            Return _Passwords
        End Get
        Set(ByVal value As String)
            _Passwords = value
        End Set
    End Property
    Public Property SaltKey() As String
        Get
            Return _SaltKey
        End Get
        Set(ByVal value As String)
            _SaltKey = value
        End Set
    End Property
End Class
