Imports Microsoft.VisualBasic

Public Class FacultyData

    Private _FacultyID As Integer
    Private _FacultyName As String
    Public Property FacultyID() As Integer
        Get
            Return _FacultyID
        End Get
        Set(ByVal value As Integer)
            _FacultyID = value
        End Set
    End Property

    Public Property FacultyName() As String
        Get
            Return _FacultyName
        End Get
        Set(ByVal value As String)
            _FacultyName = value
        End Set
    End Property
End Class
