Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Net
Public Class LoginDAL
    Inherits DataAccessBase

    Public Function FindUserByUserName(ByVal userName As String) As LoginData
        'instantiate object to hold user data
        Dim userData As LoginData = New LoginData

        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@UserName", userName)}
        'specify output parameters.

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindUsersByUserName", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        userData.UserID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        userData.UserName = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        userData.FirstName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        userData.Surname = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        userData.Passwords = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        userData.PhoneNumber = (5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        userData.EmailAddress = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        userData.SaltKey = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        userData.PhotoURL = row(8)
                    End If
                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        Return userData
    End Function


    Public Function FindLoginAdmin(ByVal UserID As Integer) As LoginData
        'instantiate object to hold user data
        Dim userData As LoginData = New LoginData

        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@UserID", UserID)}
        'specify output parameters.

        Try
            'fetch user details
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindLoginAdmin", params)

            dt.Load(reader)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        userData.Passwords = row(0)
                    End If
                Next
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error if it occutrs
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        Return userData
    End Function

    Public Function FindLoginStudent(ByVal RegNumber As Integer) As LoginData
        'instantiate object to hold user data
        Dim userData As LoginData = New LoginData

        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber)}
        'specify output parameters.

        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindLoginStudent", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    userData.Passwords = row(0)
                End If
            Next
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'log error if it occutrs
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
        Return userData
    End Function
    Public Function LoginAuth(ByVal UserID As Integer) As Integer
        'declare and initialise data access parameters for creating  user details
        Dim params() As SqlParameter = _
        {New SqlParameter("@UserID", UserID)}

        Try
            'Create User
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "LoginAuth", params)
            Return 1
        Catch ex As Exception
            AppException.LogError(ex.Message)
            '    'Log error if it occurs and return nothing
            Return 0
        End Try
    End Function

    Public Function LoginStudentAuth(ByVal RegNumber As Integer) As Integer
        'declare and initialise data access parameters for creating  user details
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber)}

        Try
            'Create User
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "LoginStudentAuth", params)
            Return 1
        Catch ex As Exception
            AppException.LogError(ex.Message)
            '    'Log error if it occurs and return nothing
            Return 0
        End Try
    End Function

    Public Function LogOutAuth(ByVal UserID As Integer) As Integer
        'declare and initialise data access parameters for creating  user details
        Dim params() As SqlParameter = _
        {New SqlParameter("@UserID", UserID)}
        Try
            'Create User
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "LogOutAuth", params)
            Return 1
        Catch ex As Exception
            AppException.LogError(ex.Message)
            'Log error if it occurs and return nothing
            Return 0
        End Try
    End Function

    Public Function LogOutStudentAuth(ByVal RegNumber As Integer) As Integer
        'declare and initialise data access parameters for creating  user details
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber)}
        Try
            'Create User
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "LogOutStudentAuth", params)
            Return 1
        Catch ex As Exception
            AppException.LogError(ex.Message)
            'Log error if it occurs and return nothing
            Return 0
        End Try
    End Function
    Public Function CheckLoginAuth(ByVal UserName As String) As String
        Dim connetionString As String
        Dim connection As SqlConnection
        Dim oledbAdapter As SqlDataAdapter
        Dim ds As New DataSet
        Dim sql As String

        connetionString = ConfigurationManager.ConnectionStrings("ResultManagerConnectionString").ConnectionString
        connection = New SqlConnection(connetionString)

        sql = "SELECT UserID from Users where UserName = '" & UserName & "'"

        connection.Open()
        oledbAdapter = New SqlDataAdapter(sql, connection)
        oledbAdapter.Fill(ds)
        connection.Close()

        Dim UserID As Integer = 0
        If ds.Tables(0).Rows.Count > 0 Then
            UserID = ds.Tables(0).Rows(0).Item(0)
        End If


        Dim connetionString1 As String
        Dim connection1 As SqlConnection
        Dim oledbAdapter1 As SqlDataAdapter
        Dim ds1 As New DataSet
        Dim sql1 As String

        connetionString1 = ConfigurationManager.ConnectionStrings("ResultManagerConnectionString").ConnectionString
        connection1 = New SqlConnection(connetionString1)

        sql1 = "SELECT isLogin from Auth where UserID = " & UserID & ""

        connection1.Open()
        oledbAdapter1 = New SqlDataAdapter(sql1, connection1)
        oledbAdapter1.Fill(ds1)
        connection1.Close()

        Dim RetVal As String = ""
        If ds.Tables(0).Rows.Count > 0 Then
            RetVal = ds.Tables(0).Rows(0).Item(0)
            Return RetVal
        Else
            Return RetVal
        End If
    End Function
    ''' <summary>
    ''' Gets All Users in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all users as a dataset object</remarks>

    Public Function FindAllUsers() As DataSet
        'holds a list of users data 
        Dim ListUserData As List(Of UsersDataList) = New List(Of UsersDataList)
        Dim userData As UsersDataList = New UsersDataList
        'Declare and instantiate object that holds users data
        Dim UserDataSet As DataSet = New DataSet
        Try
            'Fetch users
            UserDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllUsers", Nothing)
            Return UserDataSet
        Catch ex As Exception
            'log error
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Finds User by UserID
    ''' </summary>
    ''' <param name="UserId"></param>
    ''' <returns>UsersDataList</returns>
    ''' <remarks></remarks>
    Public Function FindUserByUserId(ByVal UserId As Integer) As UsersDataList
        'declare object that holds users data
        Dim userData As UsersDataList = New UsersDataList
        'declare and instantiate object that reads user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare and initialise datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@UserId", UserId)}
        Try
            'fetch user data by UserID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindUserById", params)
            'Load User details into datatable
            dt.Load(reader)
            'check if record actually contains data and populate userdata object
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    userData.UserId = row(0)
                    userData.UserName = row(1)
                    If Not IsDBNull(row(2)) Then
                        userData.FirstName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        userData.LastName = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        userData.Password = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        userData.Phone = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        userData.Email = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        userData.CreateDate = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        userData.SaltKey = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        userData.PhotoUrl = row(9)
                    End If
                Next
                Return userData
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'log error and return Nothing
            AppException.LogError(ex.Message)
            Return Nothing
        End Try

    End Function
    ''' <summary>
    ''' Modifies User information
    ''' </summary>
    ''' <param name="userData"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>Returns the UserID when Successful and returns 0 when update fails.</remarks>
    Public Function UpdateUser(ByVal userData As UsersData) As Integer
        'holds user data
        Dim users As UsersData = New UsersData
        users = userData
        'declare and initialising data access parameters for modifying  user details
        Dim params() As SqlParameter = _
        {New SqlParameter("@UserId", users.UserId), _
        New SqlParameter("@UserName", users.UserName), _
        New SqlParameter("@FirstName", users.FirstName), _
        New SqlParameter("@LastName", users.LastName), _
        New SqlParameter("@Phone", users.Phone), _
        New SqlParameter("@Email", users.Email), _
        New SqlParameter("@PhotoUrl", users.PhotoUrl), _
        New SqlParameter("@SaltKey", users.SaltKey), _
        New SqlParameter("@Password", users.Password)}
        Try
            'Modify user details
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateUsers", params)
            Return 1
        Catch ex As Exception
            'Log error if it occurs and return Nothing.
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a new User 
    ''' </summary>
    ''' <param name="userData"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>Returns the newly created User's UserID when successful and returns 0 when it fails to create a new User</remarks>
    Public Function CreateUser(ByVal userData As UsersData) As Integer
        'declare and initialise data access parameters for creating  user details
        Dim params() As SqlParameter = _
        {New SqlParameter("@UserName", userData.UserName), _
        New SqlParameter("@FirstName", userData.FirstName), _
        New SqlParameter("@LastName", userData.LastName), _
        New SqlParameter("@Password", userData.Password), _
        New SqlParameter("@Phone", userData.Phone), _
        New SqlParameter("@Email", userData.Email), _
        New SqlParameter("@PhotoUrl", userData.PhotoUrl), _
        New SqlParameter("@SaltKey", userData.SaltKey)}

        Try
            '    'Create User
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateUser", params)
            Return 1
        Catch ex As Exception
            AppException.LogError(ex.Message)
            'Log error if it occurs and return nothing
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Changes Application User's password.
    ''' </summary>
    ''' <param name="NewPassword"></param>
    ''' <param name="UserID"></param>
    ''' <param name="SaltKey"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>Returns 1 when change of password succeeds and 0 when it fails</remarks>
    Public Function ChangePassword(ByVal NewPassword As String, ByVal UserID As Integer, ByVal SaltKey As String) As Integer
        'Change Users password
        Dim params() As SqlParameter = _
        {New SqlParameter("@password", NewPassword), _
        New SqlParameter("@userID", UserID), _
        New SqlParameter("@SaltKey", SaltKey)}
        ' Try
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "changepassword", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return 0.
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' This deletes a User from the Application.
    ''' </summary>
    ''' <param name="UserId"></param>
    ''' <returns>Integer</returns>
    ''' <remarks></remarks>
    Public Function DeleteUser(ByVal UserId As Integer) As Integer
        'declare data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@UserId", UserId)}
        Try
            'delete user
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteUser", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0.
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a new User 
    ''' </summary>
    ''' <param name="userData"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>Returns the newly created User's UserID when successful and returns 0 when it fails to create a new User</remarks>
    Public Function ChangePassword(ByVal userData As UsersData) As Integer
        'declare and initialise data access parameters for creating  user details
        Dim params() As SqlParameter = _
        {New SqlParameter("@Password", userData.NewPassword), _
        New SqlParameter("@SaltKey", userData.NewSaltKey), _
        New SqlParameter("@UserId", userData.UserId)}
        Try
            'Create User
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "AdminChangePassword", params)
            Return 1
        Catch ex As Exception
            AppException.LogError(ex.Message)
            'Log error if it occurs and return nothing
            Return 0
        End Try

    End Function
End Class
