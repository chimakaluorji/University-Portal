Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic

Imports System
Imports System.Web
Partial Class Admin_AdminUploadStudentIndividualProfile
    Inherits System.Web.UI.Page
    <WebMethod()> _
  <ScriptMethod()> _
    Public Shared Function InsertStudentProfileData(ByVal ERegNumber As String, ByVal ESurname As String, ByVal EFristName As String, ByVal EExcelUrl As String, ByVal ESessionID As String, ByVal ESemesterID As String, ByVal EDepartmentID As String, ByVal EProgrammeID As String, ByVal ELevelID As String) As String

        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim StudentDal As StudentDAL = New StudentDAL
        Dim StudentData As StudentData = New StudentData

        StudentData.RegNumber = ERegNumber
        StudentData.Surname = ESurname
        StudentData.FirstName = EFristName
        StudentData.SessionID = CInt(ESessionID)
        StudentData.SemesterID = CInt(ESemesterID)
        'DepartmentID = CInt(EDepartmentID)
        'StudentData.ProgrammeID = CInt(EProgrammeID)
        StudentData.LevelID = CInt(ELevelID)

        Dim Sucesses As Integer = StudentDal.UploadStudentProfiles(StudentData)

        msg = "Success"
        Return msg
    End Function
   
End Class
