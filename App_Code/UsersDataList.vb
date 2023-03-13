Imports Microsoft.VisualBasic

Public Class UsersDataList
    Inherits UsersData

    Private _UserCreator As String
    Private _RoleName As String

    Sub New()
        MyBase.New()
    End Sub

    Public Property RoleName() As String
        Get
            Return _RoleName
        End Get
        Set(ByVal value As String)
            _RoleName = value
        End Set
    End Property

    Public Property UserCreator() As String
        Get
            Return _UserCreator
        End Get
        Set(ByVal value As String)
            _UserCreator = value
        End Set
    End Property

End Class
