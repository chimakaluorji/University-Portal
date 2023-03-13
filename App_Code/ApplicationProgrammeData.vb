Imports Microsoft.VisualBasic

Public Class ApplicationProgrammeData
    Private _AdmissionProgrammeID As Integer
    Private _ProgrammeName As String
    Public Property ProgrammeName() As String
        Get
            Return _ProgrammeName
        End Get
        Set(ByVal value As String)
            _ProgrammeName = value
        End Set
    End Property

    Public Property AdmissionProgrammeID() As Integer
        Get
            Return _AdmissionProgrammeID
        End Get
        Set(ByVal value As Integer)
            _AdmissionProgrammeID = value
        End Set
    End Property

End Class
