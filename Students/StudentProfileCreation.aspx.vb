Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Partial Class Students_StudentProfileCreation
    Inherits System.Web.UI.Page
     <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetStudentRegNo(ByVal ERegNumberSearch As String) As ArrayList
        'Intantiate objects for accessing User Data and Business Layers
        Dim QueueList As New ArrayList

        'Instance declaration 
        Dim StudentDal As StudentDAL = New StudentDAL

        QueueList = StudentDal.FindStudentNameByRegNoUsingArray(ERegNumberSearch)

        Return QueueList
    End Function
    <WebMethod()> _
    Public Shared Function GetLGA(ByVal EStateID As String) As List(Of ListItem)
        Dim customers As New List(Of ListItem)()

        Dim query As String = "select a.LGAID,a.LGAName,a.StateID,b.StateName from LGA a, State b where a.StateID = b.StateID and a.StateID = " & EStateID & ""
        Dim constr As String = ConfigurationManager.ConnectionStrings("ResultManagerConnectionString").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query)

                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                con.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    While sdr.Read()
                        customers.Add(New ListItem() With { _
                          .Value = sdr("LGAID").ToString(), _
                          .Text = sdr("LGAName").ToString() _
                        })
                    End While
                End Using
                con.Close()

            End Using
        End Using

        Return customers
    End Function
    <WebMethod()> _
    Public Shared Function GetProgramme(ByVal EDepartmentID As String) As List(Of ListItem)
        Dim customers As New List(Of ListItem)()

        Dim query As String = "select a.ProgrammeID, a.ProgrammeName from Programme a, Department b where a.DeptID = b.DeptID and a.DeptID = " & EDepartmentID & ""
        Dim constr As String = ConfigurationManager.ConnectionStrings("ResultManagerConnectionString").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query)

                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                con.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    While sdr.Read()
                        customers.Add(New ListItem() With { _
                          .Value = sdr("ProgrammeID").ToString(), _
                          .Text = sdr("ProgrammeName").ToString() _
                        })
                    End While
                End Using
                con.Close()

            End Using
        End Using

        Return customers
    End Function
    <WebMethod()> _
<ScriptMethod()> _
    Public Shared Function GetSessionName(ByVal PID As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim SessionDAL As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL
        Dim SessionData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData

        Dim SessionID As Integer = CInt(PID)
        SessionData = SessionDAL.FindSessionByID(SessionID)
        msg = SessionData.SessionName

        Return msg
    End Function
    <WebMethod()> _
 <ScriptMethod()> _
    Public Shared Function GetSemesterName(ByVal PID As String) As String
        Dim msg As String = String.Empty

        'Intantiate objects for accessing User Data and Business Layers
        Dim SemesterDAL As SessionSemesterDepartmentDAL = New SessionSemesterDepartmentDAL
        Dim SemesterData As SessionSemesterDepartmentData = New SessionSemesterDepartmentData

        Dim SemesterID As Integer = CInt(PID)
        SemesterData = SemesterDAL.FindSemesterByID(SemesterID)
        msg = SemesterData.SemesterName

        Return msg
    End Function
    <WebMethod()> _
  <ScriptMethod()> _
    Public Shared Function InsertData(ByVal ERegNumber As String, ByVal EMidleName As String, ByVal ESurname As String, ByVal EFirstname As String, _
                                      ByVal EMotherMaidenName As String, ByVal EStateID As String, ByVal ELGAID As String, ByVal EDoB As String, ByVal ESex As String, _
                                      ByVal EHomeAddress As String, ByVal EPhoneNumber As String, ByVal EEmailAddress As String, ByVal ENoKName As String, _
                                      ByVal ENoKHomeAddress As String, ByVal ENokPhoneNumber As String, ByVal ESessionID As String, ByVal ESemesterID As String, _
                                      ByVal EDepartmentID As String, ByVal EProgrammeID As String, ByVal ELevelID As String, ByVal EPs As String, ByVal ESs As String, _
                                      ByVal EDPsFrom As String, ByVal EDPsTo As String, ByVal DSsFrom As String, ByVal EDSsTo As String, ByVal EPhotoUrl As String, _
                                      ByVal Epass As String, ByVal EsaltKey As String) As Array

        Dim msg As String() = {"", "", "", ""}



        'Intantiate objects for accessing User Data and Business Layers
        Dim StudentDAL As StudentDAL = New StudentDAL
        Dim studentData As StudentData = New StudentData

        'Checking if the reg number have been uploaded before
        Dim a As Integer = StudentDAL.CheckIfStudentExist(ERegNumber)

        If a > 0 Then
            msg(0) = "Error101"
            Return msg
            Exit Function
        End If


        'Loading Data to StudentData
        studentData.RegNumber = ERegNumber
        studentData.Surname = ESurname
        studentData.FirstName = EFirstname
        studentData.MiddleName = EMidleName
        studentData.MothersMaidenName = EMotherMaidenName
        studentData.DOB = EDoB
        studentData.Sex = ESex
        studentData.StateID = CInt(EStateID)
        studentData.LGAID = CInt(ELGAID)
        studentData.HomeAddress = EHomeAddress
        studentData.PhoneNumber = EPhoneNumber
        studentData.Email = EEmailAddress
        studentData.NOKName = ENoKName
        studentData.NOKPhoneNumber = ENokPhoneNumber
        studentData.NOKAddress = ENoKHomeAddress
        studentData.SessionID = CInt(ESessionID)
        studentData.SemesterID = CInt(ESemesterID)
        'studentData.DepartmentID = CInt(EDepartmentID)
        'studentData.ProgrammeID = CInt(EProgrammeID)
        studentData.LevelID = CInt(EProgrammeID)
        studentData.LPS = EPs
        studentData.LPSFrom = EDPsFrom
        studentData.LPSTo = EDPsTo
        studentData.LSA = ESs
        studentData.LSAFrom = DSsFrom
        studentData.LSATo = EDSsTo
        studentData.PhotoURL = EPhotoUrl
        studentData.Passwords = Epass
        studentData.SaltKey = EsaltKey

        'Dim IEncrypt As EncryptionUtil = New EncryptionUtil
        'Dim EncryptRegNumber As String = IEncrypt.Encrypt(ERegNumber)

        Dim Encrypt1 As Encryption = New Encryption
        Dim EncryptRegNumber As String = Encrypt1.Encrypt(ERegNumber, "123456789")

        Dim Dal As LoginDAL = New LoginDAL
        Dim Data As LoginData = New LoginData

        Dim RetInt As Integer = Dal.LoginStudentAuth(ERegNumber)

        ' call CreateSession API
        Dim CreateStatus As Integer = StudentDAL.CreateStudentProfiles(studentData)
        If CreateStatus = 1 Then
            msg(0) = "success"
            msg(1) = EncryptRegNumber
            msg(2) = Epass
            msg(3) = EsaltKey
        Else
            msg(0) = "danger"
        End If

        Return msg
    End Function

    'Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    InsertData("16165001", "Chima", "Chima", "Chima", "Chima", "1", "1", "Chima", "Chima", "Chima", "Chima", "Chima", "Chima", "Chima", "Chima", "1", "1", "1", "1", "1", "Chima", "Chima", "Chima", "Chima", "Chima", "Chima", "Chima", "Chima", "Chima")
    'End Sub
End Class
