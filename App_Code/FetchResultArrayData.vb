Imports Microsoft.VisualBasic

Public Class FetchResultArrayData

    Public Property CourseCode As String
    Public Property CourseName As String
    Public Property CreditUnit As String
    Public Property Total As String
    Public Property Grade As String
    Public Property Remark As String
    Public Sub New()
    End Sub
    Public Sub New(ByVal CourseCode As String, ByVal CourseName As String, ByVal CreditUnit As String, _
                   ByVal Total As String, ByVal Grade As String, ByVal Remark As String)

        Me.CourseCode = CourseCode
        Me.CourseName = CourseName
        Me.CreditUnit = CreditUnit
        Me.Total = Total
        Me.Grade = Grade
        Me.Remark = Remark

    End Sub
End Class
