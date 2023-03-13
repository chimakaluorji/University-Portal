Imports Microsoft.VisualBasic

Public Class ApplicationFeeData
    Private _ApplicationFeeID As Integer
    Private _AppProgID As Integer
    Private _Amount As String
    Private _ProgrammeName As String
    Public Property ProgrammeName() As String
        Get
            Return _ProgrammeName
        End Get
        Set(ByVal value As String)
            _ProgrammeName = value
        End Set
    End Property

    Public Property Amount() As String
        Get
            Return _Amount
        End Get
        Set(ByVal value As String)
            _Amount = value
        End Set
    End Property

    Public Property AppProgID() As Integer
        Get
            Return _AppProgID
        End Get
        Set(ByVal value As Integer)
            _AppProgID = value
        End Set
    End Property

    Public Property ApplicationFeeID() As Integer
        Get
            Return _ApplicationFeeID
        End Get
        Set(ByVal value As Integer)
            _ApplicationFeeID = value
        End Set
    End Property

End Class
