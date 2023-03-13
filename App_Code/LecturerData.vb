Imports Microsoft.VisualBasic

Public Class LecturerData

    Private _LecturerID As Integer
    Private _LecName As String
    Private _EmployeeNo As String
    Private _DeptID As Integer
    Private _DeptName As String
    Private _QualificationID As Integer
    Private _QualifShortName As String
    Private _Specialization As String

    Public Property LecturerID() As Integer
        Get
            Return _LecturerID
        End Get
        Set(ByVal value As Integer)
            _LecturerID = value
        End Set
    End Property
    Public Property LecName() As String
        Get
            Return _LecName
        End Get
        Set(ByVal value As String)
            _LecName = value
        End Set
    End Property

    Public Property EmployeeNo() As String
        Get
            Return _EmployeeNo
        End Get
        Set(ByVal value As String)
            _EmployeeNo = value
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

    Public Property DeptName() As String
        Get
            Return _DeptName
        End Get
        Set(ByVal value As String)
            _DeptName = value
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

    Public Property QualifShortName() As String
        Get
            Return _QualifShortName
        End Get
        Set(ByVal value As String)
            _QualifShortName = value
        End Set
    End Property

    Public Property Specialization() As String
        Get
            Return _Specialization
        End Get
        Set(ByVal value As String)
            _Specialization = value
        End Set
    End Property
End Class
