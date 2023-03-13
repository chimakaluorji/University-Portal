Imports Microsoft.VisualBasic
Public Class SchoolFeesData
    Private _SchoolFeesID As Integer
    Private _ProgrammeID As Integer
    Private _DeptID As Integer
    Private _QualificationID As Integer
    Private _LevelID As Integer
    Private _Amount As Decimal
    Private _CreatedByUID As Integer
    Private _ProgrammeName As String
    Private _DeptName As String
    Private _QualificationName As String
    Private _LevelName As String
    Private _LastUpdatedByUID As Integer
    Public Property SchoolFeesID() As Integer
        Get
            Return _SchoolFeesID
        End Get
        Set(ByVal value As Integer)
            _SchoolFeesID = value
        End Set
    End Property
    Public Property ProgrammeID() As Integer
        Get
            Return _ProgrammeID
        End Get
        Set(ByVal value As Integer)
            _ProgrammeID = value
        End Set
    End Property
    Public Property DeptID() As Integer
        Get
            Return _DeptID
        End Get
        Set(ByVal value As Integer)
            _DeptID = value
        End Set
    End Property
    Public Property QualificationID() As Integer
        Get
            Return _QualificationID
        End Get
        Set(ByVal value As Integer)
            _QualificationID = value
        End Set
    End Property
    Public Property LevelID() As Integer
        Get
            Return _LevelID
        End Get
        Set(ByVal value As Integer)
            _LevelID = value
        End Set
    End Property
    Public Property Amount() As Decimal
        Get
            Return _Amount
        End Get
        Set(ByVal value As Decimal)
            _Amount = value
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
    Public Property ProgrammeName() As String
        Get
            Return _ProgrammeName
        End Get
        Set(ByVal value As String)
            _ProgrammeName = value
        End Set
    End Property
    Public Property DeptName() As String
        Get
            Return _DeptName
        End Get
        Set(ByVal value As String)
            _DeptName = value
        End Set
    End Property
    Public Property QualificationName() As String
        Get
            Return _QualificationName
        End Get
        Set(ByVal value As String)
            _QualificationName = value
        End Set
    End Property
    Public Property LevelName() As String
        Get
            Return _LevelName
        End Get
        Set(ByVal value As String)
            _LevelName = value
        End Set
    End Property
    Public Property LastUpdatedByUID() As Integer
        Get
            Return _LastUpdatedByUID
        End Get
        Set(ByVal value As Integer)
            _LastUpdatedByUID = value
        End Set
    End Property
End Class
