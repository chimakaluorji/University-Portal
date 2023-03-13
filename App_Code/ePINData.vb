Imports Microsoft.VisualBasic

Public Class ePINData
    Private _ePINID As Integer
    Private _ePIN As String
    Private _ResultePINID As Integer
    Private _ResultePIN As String
    Private _Serial As String

    Public Sub New()

    End Sub

    Public Property ePINID() As Integer
        Get
            Return _ePINID
        End Get
        Set(ByVal value As Integer)
            _ePINID = value
        End Set
    End Property

    Public Property ePIN() As String
        Get
            Return _ePIN
        End Get
        Set(ByVal value As String)
            _ePIN = value
        End Set
    End Property

    Public Property ResultePINID() As Integer
        Get
            Return _ResultePINID
        End Get
        Set(ByVal value As Integer)
            _ResultePINID = value
        End Set
    End Property

    Public Property ResultePIN() As String
        Get
            Return _ResultePIN
        End Get
        Set(ByVal value As String)
            _ResultePIN = value
        End Set
    End Property
    Public Property Serial() As String
        Get
            Return _Serial
        End Get
        Set(ByVal value As String)
            _Serial = value
        End Set
    End Property
End Class
