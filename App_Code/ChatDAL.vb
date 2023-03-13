Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic
Imports System.Text
Imports System.Net
Imports System.Windows.Forms

Public Class ChatDAL
    Inherits DataAccessBase
    ''' <summary>
    ''' Creates a Profile
    ''' </summary>
    ''' <param name="Chat"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates CountryStateLGAData using dept</remarks>
    Public Function CreateChat(ByVal Chat As ChatData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@UserID", Chat.UserID), _
        New SqlParameter("@RegNumber", Chat.RegNumber), _
        New SqlParameter("@UserMsg", Chat.UserMsg), _
        New SqlParameter("@StudentMsg", Chat.StudentMsg), _
        New SqlParameter("@UserName", Chat.UserName), _
        New SqlParameter("@StudentName", Chat.StudentName), _
        New SqlParameter("@UserDate", Chat.UserDate), _
        New SqlParameter("@UserTime", Chat.UserTime), _
        New SqlParameter("@StudentDate", Chat.StudentDate), _
        New SqlParameter("@StudentTime", Chat.StudentTime)}
        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateChat", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllChatByRegNumberUserID(ByVal RegNumber As String, ByVal UserID As Integer, ByVal StudentDate As String) As ArrayList
        'Holds chat Data
        Dim chat As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@UserID", UserID), New SqlParameter("@StudentDate", StudentDate)}


        chat = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllChatByRegNumberUserID", params)

        For Each row As DataRow In chat.Tables(0).Rows
            QueueList.Add(New ChatArrayData(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9), row(10)))
        Next

        Return QueueList
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllStudentOnlineByRegNumber() As ArrayList
        'Holds chat Data
        Dim chat As DataSet = New DataSet
        Dim QueueList As New ArrayList


        chat = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStudentOnlineByRegNumber")


        Dim StudentOnlineTempID As String = ""
        Dim RegNumber As String = ""
        Dim regID As String = ""
        Dim StudentName As String = ""
        Dim MsgCount As String = ""
        Dim Photo As String = ""
        Dim PhoneNo As String = ""

        Dim count As Integer = chat.Tables(0).Rows.Count

        For Each row As DataRow In chat.Tables(0).Rows
            If count > 0 Then
                If Not IsDBNull(row(0)) Then
                    StudentOnlineTempID = row(0)
                End If

                If Not IsDBNull(row(1)) Then
                    RegNumber = row(1)
                End If

                If Not IsDBNull(row(2)) Then
                    regID = row(2)
                End If

                If Not IsDBNull(row(3)) Then
                    StudentName = row(3)
                End If

                If Not IsDBNull(row(4)) Then
                    MsgCount = row(4)
                End If

                If Not IsDBNull(row(5)) Then
                    Photo = row(5)
                End If

                If Not IsDBNull(row(6)) Then
                    PhoneNo = row(6)
                End If
            End If

            QueueList.Add(New StudentOnlineArrayData(StudentOnlineTempID, RegNumber, regID, StudentName, MsgCount, Photo, PhoneNo))
        Next

        Return QueueList
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCurrentStudentOnlineByRegNumber() As ArrayList
        'Holds chat Data
        Dim chat As DataSet = New DataSet
        Dim QueueList As New ArrayList


        chat = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCurrentStudentOnlineByRegNumber")

        Dim StudentOnlineTempID As String = ""
        Dim RegNumber As String = ""
        Dim regID As String = ""
        Dim StudentName As String = ""
        Dim MsgCount As String = ""
        Dim Photo As String = ""
        Dim PhoneNo As String = ""

        Dim count As Integer = chat.Tables(0).Rows.Count

        For Each row As DataRow In chat.Tables(0).Rows
            If count > 0 Then
                If Not IsDBNull(row(0)) Then
                    StudentOnlineTempID = row(0)
                End If

                If Not IsDBNull(row(1)) Then
                    RegNumber = row(1)
                End If

                If Not IsDBNull(row(2)) Then
                    regID = row(2)
                End If

                If Not IsDBNull(row(3)) Then
                    StudentName = row(3)
                End If

                If Not IsDBNull(row(4)) Then
                    MsgCount = row(4)
                End If

                If Not IsDBNull(row(5)) Then
                    Photo = row(5)
                End If

                If Not IsDBNull(row(6)) Then
                    PhoneNo = row(6)
                End If
            End If

            QueueList.Add(New StudentOnlineArrayData(StudentOnlineTempID, RegNumber, regID, StudentName, MsgCount, Photo, PhoneNo))
        Next

        Return QueueList
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllAdminOnlineByRegNumber() As ArrayList
        'Holds chat Data
        Dim chat As DataSet = New DataSet
        Dim QueueList As New ArrayList

        chat = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllAdminOnlineByRegNumber")

        Dim UserID As String = ""
        Dim regID As String = ""
        Dim Admin As String = ""
        Dim MsgCount As String = ""
        Dim Photo As String = ""
        Dim PhoneNo As String = ""

        Dim count As Integer = chat.Tables(0).Rows.Count

        For Each row As DataRow In chat.Tables(0).Rows
            If count > 0 Then
                If Not IsDBNull(row(0)) Then
                    UserID = row(0)
                End If

                If Not IsDBNull(row(1)) Then
                    regID = row(1)
                End If

                If Not IsDBNull(row(2)) Then
                    Admin = row(2)
                End If

                If Not IsDBNull(row(3)) Then
                    MsgCount = row(3)
                End If

                If Not IsDBNull(row(4)) Then
                    Photo = row(4)
                End If

                If Not IsDBNull(row(5)) Then
                    PhoneNo = row(5)
                End If
            End If
           
            QueueList.Add(New AdminOnlineArrayData(UserID, regID, Admin, MsgCount, Photo, PhoneNo))
        Next

        Return QueueList
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCurrentAdminOnlineByRegNumber() As ArrayList
        'Holds chat Data
        Dim chat As DataSet = New DataSet
        Dim QueueList As New ArrayList

        chat = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCurrentAdminOnlineByRegNumber")

        Dim UserID As String = ""
        Dim regID As String = ""
        Dim Admin As String = ""
        Dim MsgCount As String = ""
        Dim Photo As String = ""
        Dim PhoneNo As String = ""

        Dim count As Integer = chat.Tables(0).Rows.Count

        For Each row As DataRow In chat.Tables(0).Rows
            If count > 0 Then
                If Not IsDBNull(row(0)) Then
                    UserID = row(0)
                End If

                If Not IsDBNull(row(1)) Then
                    regID = row(1)
                End If

                If Not IsDBNull(row(2)) Then
                    Admin = row(2)
                End If

                If Not IsDBNull(row(3)) Then
                    MsgCount = row(3)
                End If

                If Not IsDBNull(row(4)) Then
                    Photo = row(4)
                End If

                If Not IsDBNull(row(5)) Then
                    PhoneNo = row(5)
                End If
            End If

            QueueList.Add(New AdminOnlineArrayData(UserID, regID, Admin, MsgCount, Photo, PhoneNo))
        Next

        Return QueueList
    End Function

    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAdminAllChatByRegNumberUserID(ByVal RegNumber As String, ByVal UserID As Integer, ByVal StudentDate As String) As ArrayList
        'Holds chat Data
        Dim chat As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@UserID", UserID), New SqlParameter("@StudentDate", StudentDate)}


        chat = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAdminAllChatByRegNumberUserID", params)

        Dim _ChatID As Integer = 0
        Dim _UserID As Integer = 0
        Dim _RegNumber As String = ""
        Dim _UserMsg As String = ""
        Dim _StudentMsg As String = ""
        Dim _UserName As String = ""
        Dim _StudentName As String = ""
        Dim _UserDate As String = ""
        Dim _UserTime As String = ""
        Dim _StudentDate As String = ""
        Dim _StudentTime As String = ""
        Dim _UserPhotoUrl As String = ""
        Dim _StudentPhotoUrl As String = ""

        Dim rowCount As Integer = chat.Tables(0).Rows.Count

        For Each row As DataRow In chat.Tables(0).Rows


            If rowCount > 0 Then
                If Not IsDBNull(row(0)) Then
                    _ChatID = row(0)
                    _UserID = row(1)
                    _RegNumber = row(2)
                    _UserMsg = row(3)
                    _StudentMsg = row(4)
                    _UserName = row(5)
                    _StudentName = row(6)
                    _UserDate = row(7)
                    _UserTime = row(8)
                    _StudentDate = row(9)
                    _StudentTime = row(10)
                    _UserPhotoUrl = row(11)
                    _StudentPhotoUrl = row(12)

                End If
            End If

            QueueList.Add(New ChatAdminArrayData(_ChatID, _UserID, _RegNumber, _UserMsg, _StudentMsg, _UserName, _StudentName, _UserDate, _UserTime, _StudentDate, _StudentTime, _UserPhotoUrl, _StudentPhotoUrl))
        Next

        Return QueueList
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAdminChatByRegNumberUserID(ByVal UserID As Integer, ByVal StudentDate As String) As ArrayList
        'Holds chat Data
        Dim chat As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@UserID", UserID), New SqlParameter("@StudentDate", StudentDate)}


        chat = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAdminChatByRegNumberUserID", params)

        Dim _ChatID As Integer = 0
        Dim _UserID As Integer = 0
        Dim _RegNumber As String = ""
        Dim _UserMsg As String = ""
        Dim _StudentMsg As String = ""
        Dim _UserName As String = ""
        Dim _StudentName As String = ""
        Dim _UserDate As String = ""
        Dim _UserTime As String = ""
        Dim _StudentDate As String = ""
        Dim _StudentTime As String = ""
        Dim _UserPhotoUrl As String = ""
        Dim _StudentPhotoUrl As String = ""

        Dim rowCount As Integer = chat.Tables(0).Rows.Count

        For Each row As DataRow In chat.Tables(0).Rows


            If rowCount > 0 Then
                If Not IsDBNull(row(0)) Then
                    _ChatID = row(0)
                    _UserID = row(1)
                    _RegNumber = row(2)
                    _UserMsg = row(3)
                    _StudentMsg = row(4)
                    _UserName = row(5)
                    _StudentName = row(6)
                    _UserDate = row(7)
                    _UserTime = row(8)
                    _StudentDate = row(9)
                    _StudentTime = row(10)
                    _UserPhotoUrl = row(11)
                    _StudentPhotoUrl = row(12)

                End If
            End If
          
            QueueList.Add(New ChatAdminArrayData(_ChatID, _UserID, _RegNumber, _UserMsg, _StudentMsg, _UserName, _StudentName, _UserDate, _UserTime, _StudentDate, _StudentTime, _UserPhotoUrl, _StudentPhotoUrl))
        Next

        Return QueueList
    End Function
    ''' <summary>
    ''' Fetches all Sessions to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindChatByRegNumberUserID(ByVal RegNumber As String, ByVal StudentDate As String) As ArrayList
        'Holds chat Data
        Dim chat As DataSet = New DataSet
        Dim QueueList As New ArrayList

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@StudentDate", StudentDate)}


        chat = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindChatByRegNumberUserID", params)

        Dim _ChatID As Integer = 0
        Dim _UserID As Integer = 0
        Dim _RegNumber As String = ""
        Dim _UserMsg As String = ""
        Dim _StudentMsg As String = ""
        Dim _UserName As String = ""
        Dim _StudentName As String = ""
        Dim _UserDate As String = ""
        Dim _UserTime As String = ""
        Dim _StudentDate As String = ""
        Dim _StudentTime As String = ""
        Dim _UserPhotoUrl As String = ""
        Dim _StudentPhotoUrl As String = ""

        Dim rowCount As Integer = chat.Tables(0).Rows.Count

        For Each row As DataRow In chat.Tables(0).Rows


            If rowCount > 0 Then
                If Not IsDBNull(row(0)) Then
                    _ChatID = row(0)
                    _UserID = row(1)
                    _RegNumber = row(2)
                    _UserMsg = row(3)
                    _StudentMsg = row(4)
                    _UserName = row(5)
                    _StudentName = row(6)
                    _UserDate = row(7)
                    _UserTime = row(8)
                    _StudentDate = row(9)
                    _StudentTime = row(10)
                    _UserPhotoUrl = row(11)
                    _StudentPhotoUrl = row(12)

                End If
            End If

            QueueList.Add(New ChatAdminArrayData(_ChatID, _UserID, _RegNumber, _UserMsg, _StudentMsg, _UserName, _StudentName, _UserDate, _UserTime, _StudentDate, _StudentTime, _UserPhotoUrl, _StudentPhotoUrl))
        Next

        Return QueueList
    End Function
    Public Function ReadMessageAdmin(ByVal RegNumber As String, ByVal UserID As Integer, ByVal StudentDate As String) As String
        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@UserID", UserID), New SqlParameter("@StudentDate", StudentDate)}


        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "ReadMessageAdmin", params)
            Return "YES"
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return "NO"
        End Try
    End Function
    Public Function ReadMessageStudent(ByVal RegNumber As String, ByVal UserID As Integer, ByVal StudentDate As String) As String
        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegNumber), New SqlParameter("@UserID", UserID), New SqlParameter("@StudentDate", StudentDate)}


        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "ReadMessageStudent", params)
            Return "YES"
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return "NO"
        End Try
    End Function
    Public Function CountStudentOnline() As Integer

        Dim Count As Integer = 0

        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Fetch item based on SessionID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CountStudentOnline")
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    Count = row(0)
                End If

            Next
            'Return Session data.
            Return Count
        Else
            Return 0
        End If
    End Function
    Public Function CountAdminOnline() As Integer

        Dim Count As Integer = 0

        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Fetch item based on SessionID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "CountAdminOnline")
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    Count = row(0)
                End If

            Next
            'Return Session data.
            Return Count
        Else
            Return 0
        End If
    End Function
End Class
