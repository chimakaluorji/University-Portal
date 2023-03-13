Imports Microsoft.VisualBasic

Public Class ComplainData
    Private _RegNum As String
    Private _Complain As String
    Private _CreatedByUID As Integer
    Public Property RegNum() As String
        Get
            Return _RegNum
        End Get
        Set(ByVal value As String)
            _RegNum = value
        End Set
    End Property

    Public Property Complain() As String
        Get
            Return _Complain
        End Get
        Set(ByVal value As String)
            _Complain = value
        End Set
    End Property
    Public Property CreatedByUID() As Integer
        Get
            Return _CreatedByUID
        End Get
        Set(ByVal value As Integer)
            _CreatedByUID = value
        End Set
    End Property
End Class
