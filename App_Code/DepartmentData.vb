Imports Microsoft.VisualBasic

Public Class DepartmentData
    Private _DeptID As Integer
    Private _DeptName As String
    Private _ShortName As String
    Private _FacultyID As Integer
    Private _FacultyName As String

    Public Property DeptName() As String
        Get
            Return _DeptName
        End Get
        Set(ByVal value As String)
            _DeptName = value
        End Set
    End Property
    Public Property ShortName() As String
        Get
            Return _ShortName
        End Get
        Set(ByVal value As String)
            _ShortName = value
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
