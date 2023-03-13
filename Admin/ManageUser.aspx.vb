Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Partial Class Admin_ManageUser
    Inherits System.Web.UI.Page
    <WebMethod()> _
  <ScriptMethod()> _
    Public Shared Function InsertData(ByVal UserName As String, ByVal Surname As String, ByVal Firstname As String, ByVal Password As String, _
                                      ByVal Phone As String, ByVal Email As String, ByVal PhotoUrl As String) As String

        Dim msg As String = String.Empty

        Dim userData As UsersData = New UsersData
        Dim LoginDal As LoginDAL = New LoginDAL
        Dim Encrypt As EncryptionUtil = New EncryptionUtil

        Dim EncryptData As String() = {"", ""}
        EncryptData = Encrypt.EncryptData(Password)

        userData.UserName = UserName
        userData.FirstName = Firstname
        userData.LastName = Surname
        userData.Password = EncryptData(0)
        userData.Phone = Phone
        userData.Email = Email
        userData.PhotoUrl = PhotoUrl
        userData.SaltKey = EncryptData(1)


        ' call CreateSession API
        Dim CreateStatus As Integer = LoginDal.CreateUser(userData)
        If CreateStatus = 1 Then
            msg = "success"
        Else
            msg = "danger"
        End If

        Return msg
    End Function
    <WebMethod()> _
 <ScriptMethod()> _
    Public Shared Function UpdateData(ByVal EditPID As String, ByVal UserNames As String, ByVal Surname As String, ByVal Firstname As String, ByVal Password As String, _
                                      ByVal Phone As String, ByVal Email As String, ByVal PhotoUrl As String, ByVal SaltKey As String) As String

        Dim msg As String = String.Empty

        Dim userData As UsersData = New UsersData
        Dim LoginDal As LoginDAL = New LoginDAL
        Dim Encrypt As EncryptionUtil = New EncryptionUtil

        Dim countPassword As Integer = Password.Length

        If countPassword < 50 Then
            Dim EncryptData As String() = {"", ""}
            EncryptData = Encrypt.EncryptData(Password)
            userData.Password = EncryptData(0)
            userData.SaltKey = EncryptData(1)
        Else
            userData.Password = Password
            userData.SaltKey = SaltKey
        End If

        userData.UserId = EditPID
        userData.UserName = UserNames
        userData.FirstName = Firstname
        userData.LastName = Surname
        userData.Phone = Phone
        userData.Email = Email
        userData.PhotoUrl = PhotoUrl



        ' call CreateSession API
        Dim CreateStatus As Integer = LoginDal.UpdateUser(userData)
        If CreateStatus = 1 Then
            msg = "success"
        Else
            msg = "danger"
        End If

        Return msg
    End Function
    <WebMethod()> _
 <ScriptMethod()> _
    Public Shared Function GetUsers(ByVal PID As String) As String()

        Dim msg As String() = {"", "", "", "", "", "", "", ""}

        Dim userData As UsersData = New UsersData
        Dim LoginDal As LoginDAL = New LoginDAL

        Dim UserID As Integer = CInt(PID)

        ' call CreateSession API
        userData = LoginDal.FindUserByUserId(UserID)
        msg(0) = userData.UserName
        msg(1) = userData.LastName
        msg(2) = userData.FirstName
        msg(3) = userData.Password
        msg(4) = userData.Phone
        msg(5) = userData.Email
        msg(6) = userData.PhotoUrl
        msg(7) = userData.SaltKey

        Return msg
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function DeleteData(ByVal EPID As String) As String
        Dim msg As String = String.Empty


        'Intantiate objects for accessing User Data and Business Layers
        Dim DepartmentData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData
        Dim LoginDAL As LoginDAL = New LoginDAL

        'Populate Session data
        Dim UserID As Integer = CInt(EPID)

        ' call UpdateSessionById API
        Dim DeleteStatus As Integer = LoginDAL.DeleteUser(UserID)
        If DeleteStatus = 1 Then
            msg = "success"
        End If

        If DeleteStatus = 0 Then
            msg = "danger"
        End If
        Return msg
    End Function
End Class
