Imports Microsoft.VisualBasic

Public Class ProgrammeData
    Private _ProgrammeID As Integer
    Private _ProgrammeName As String
    

    Public Property ProgrammeID() As Integer
        Get
            Return _ProgrammeID
        End Get
        Set(ByVal value As Integer)
            _ProgrammeID = value
        End Set
    End Property
    Public Property ProgrammeName() As String
        Get
            Return _ProgrammeName
        End Get
        Set(ByVal value As String)
            _ProgrammeName = value
        End Set
    End Property

    
End Class
