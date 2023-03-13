'''''''''''''''''''''''''
''''Handles Data Access for Users
''''Author: Kalu Nsi Idika
''''on 06-08-2008
'''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic

Public Class UsersDAL
    Inherits DataAccessBase

    ''' <summary>
    ''' Constructor for UsersDAL Class
    ''' </summary>
    ''' <remarks>
    ''' 
    ''' </remarks>
    Public Sub New()
        ' Initialize the connection string for accessing DB
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Finds User by UserName
    ''' </summary>
    ''' <param name="userName"></param>
    ''' <returns>UsersData</returns>
    ''' <remarks>Takes UserName as parameter and return UsersData</remarks>
    Public Function FindUserByUserName(ByVal userName As String) As UsersData
        'instantiate object to hold user data
        Dim userData As UsersData = New UsersData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@UserName", userName), New SqlParameter("@RowNumbers", SqlDbType.Int, 4)}
        'specify output parameters.
        params(1).Direction = ParameterDirection.Output
        'Try
        'fetch user details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindUsersByUserName", params)
        Dim retVal As Integer = params(1).Value
        dt.Load(reader)
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
                    userData.Address = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    userData.SaltKey = row(9)
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
                        userData.UserCreator = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        userData.Address = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        userData.CreateDate = row(9)
                    End If
                    If Not IsDBNull(row(10)) Then
                        userData.SaltKey = row(10)
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
        New SqlParameter("@CreatedByUID", users.CretedUserId), _
        New SqlParameter("@Address", users.Address)}
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
        {New SqlParameter("@UserId", SqlDbType.Int, 4), _
        New SqlParameter("@UserName", userData.UserName), _
        New SqlParameter("@FirstName", userData.FirstName), _
        New SqlParameter("@LastName", userData.LastName), _
        New SqlParameter("@Password", userData.Password), _
        New SqlParameter("@Phone", userData.Phone), _
        New SqlParameter("@Email", userData.Email), _
        New SqlParameter("@CreatedByUID", userData.CretedUserId), _
        New SqlParameter("@Address", userData.Address), _
        New SqlParameter("@SaltKey", userData.SaltKey)}
        params(0).Direction = ParameterDirection.Output
        Try
            'Create User
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
        'Try
        'delete user
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteUser", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return 0.
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
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
