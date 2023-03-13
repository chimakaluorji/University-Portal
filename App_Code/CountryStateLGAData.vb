Imports Microsoft.VisualBasic

Public Class CountryStateLGAData
    Private _CountryID As Integer
    Private _StateID As Integer
    Private _LGAID As Integer
    Private _DeptName As String
    Private _CountryName As String
    Private _StateName As String
    Private _LGAName As String

    Public Property CountryID() As Integer
        Get
            Return _CountryID
        End Get
        Set(ByVal value As Integer)
            _CountryID = value
        End Set
    End Property
    Public Property StateID() As Integer
        Get
            Return _StateID
        End Get
        Set(ByVal value As Integer)
            _StateID = value
        End Set
    End Property

    Public Property LGAID() As Integer
        Get
            Return _LGAID
        End Get
        Set(ByVal value As Integer)
            _LGAID = value
        End Set
    End Property

    Public Property CountryName() As String
        Get
            Return _CountryName
        End Get
        Set(ByVal value As String)
            _CountryName = value
        End Set
    End Property
    Public Property StateName() As String
        Get
            Return _StateName
        End Get
        Set(ByVal value As String)
            _StateName = value
        End Set
    End Property
    Public Property LGAName() As String
        Get
            Return _LGAName
        End Get
        Set(ByVal value As String)
            _LGAName = value
        End Set
    End Property
End Class
