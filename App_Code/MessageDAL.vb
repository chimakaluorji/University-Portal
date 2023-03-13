'''''''''''''''''''''''''
''''Handles Messaging
''''Author: Chima kalu-orji
''''on 02-09-2008
'''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections
Imports System.Collections.Generic

Public Class MessageDAL
    Inherits DataAccessBase

    Public Sub New()
        ' Initialize the connection string for accessing DB
        MyBase.New()
    End Sub
    Public Function GenerateDistributionListID(ByVal DistListName As String) As Integer
        Dim StrAscVal As Integer
        Dim InputLength As Integer = 0
        'Remove white space and merge the input string
        Dim CatenateInput As String = Trim(DistListName)
        'Get the length of the input string
        InputLength = CatenateInput.Length
        If InputLength > 1 Then
            Dim InputArray() As Char = CatenateInput.ToCharArray
            For i As Integer = 0 To InputArray.Length - 1
                StrAscVal = StrAscVal + (Asc(InputArray(i)) * i)
            Next
        End If
        'Return StrAscVal * InputLength
        Return StrAscVal
    End Function
    ''' <summary>
    ''' Compose message
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <remarks>Compose message </remarks>
    Public Function ComposeMessage(ByVal Message As MessageData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@MessageBody", Message.MessageBody), _
        New SqlParameter("@RecipientID", Message.Recipient), _
        New SqlParameter("@InOutFlag", Message.InOutFlag), _
        New SqlParameter("@DocUrl", Message.DocUrl), _
        New SqlParameter("@DocUrl1", Message.DocUrl1), _
        New SqlParameter("@DocUrl2", Message.DocUrl2), _
        New SqlParameter("@DocUrl3", Message.DocUrl3), _
        New SqlParameter("@ReadStatus", Message.ReadStatus), _
        New SqlParameter("@Subject", Message.Subject), _
        New SqlParameter("@MessageType", Message.MessageType), _
        New SqlParameter("@SenderID", Message.SenderID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByUID", Message.CreatedByUID), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(14).Direction = ParameterDirection.Output
        params(15).Direction = ParameterDirection.Output
        'Try
        'Get Registration Number
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_ComposeMessage", params)
        'Populate Error Code
        RetVal(0) = params(14).Value
        'Populate Error Hint
        RetVal(1) = params(15).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(14).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(15).Value
        '    Return RetVal
        'End Try
    End Function
    ''' <summary>
    ''' Compose message
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <remarks>Compose message </remarks>
    Public Function ComposeMessageStudent(ByVal Message As MessageData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@MessageBody", Message.MessageBody), _
        New SqlParameter("@RecipientID", Message.Recipient), _
        New SqlParameter("@InOutFlag", Message.InOutFlag), _
        New SqlParameter("@DocUrl", Message.DocUrl), _
        New SqlParameter("@DocUrl1", Message.DocUrl1), _
        New SqlParameter("@DocUrl2", Message.DocUrl2), _
        New SqlParameter("@DocUrl3", Message.DocUrl3), _
        New SqlParameter("@ReadStatus", Message.ReadStatus), _
        New SqlParameter("@Subject", Message.Subject), _
        New SqlParameter("@MessageType", Message.MessageType), _
        New SqlParameter("@SenderID", Message.SenderID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByRegNo", Message.RegNumber), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(14).Direction = ParameterDirection.Output
        params(15).Direction = ParameterDirection.Output
        'Try
        'Get Registration Number
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_ComposeMessageStudent", params)
        'Populate Error Code
        RetVal(0) = params(14).Value
        'Populate Error Hint
        RetVal(1) = params(15).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(14).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(15).Value
        '    Return RetVal
        'End Try
    End Function
    ''' <summary>
    ''' Gets All Message Type in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns Message Type as a dataset object</remarks>

    Public Function FindAllMessageType() As DataSet
        'holds a list of Message data 
        Dim MessageDataSet As DataSet = New DataSet
        Try
            'Fetch Message
            MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllMessageType", Nothing)
            Return MessageDataSet
        Catch ex As Exception
            'log error
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Gets All Inbox Message in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all In Message as a dataset object</remarks>

    Public Function FindAllInboxMessage(ByVal MessageData As MessageData) As DataSet
        'holds a list of In Message data 
        Dim MessageDataSet As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@CreatedByUID", MessageData.CreatedByUID)}

        'Try
        'Fetch Inbox Message
        MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllInboxMessage", params)
        Return MessageDataSet
        'Catch ex As Exception
        '    'log error
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Gets All Inbox Message in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all In Message as a dataset object</remarks>

    Public Function FindAllInboxMessageByRegNumber(ByVal MessageData As MessageData) As DataSet
        'holds a list of In Message data 
        Dim MessageDataSet As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", MessageData.RegNumber)}

        'Try
        'Fetch Inbox Message
        MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllInboxMessageByRegNumber", params)
        Return MessageDataSet
        'Catch ex As Exception
        '    'log error
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Gets All Inbox Message in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all In Message as a dataset object</remarks>

    Public Function FindAllMessage(ByVal MessageData As MessageData) As DataSet
        'holds a list of In Message data 
        Dim MessageDataSet As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@CreatedByUID", MessageData.CreatedByUID)}

        'Try
        'Fetch Inbox Message
        MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllMessage", params)
        Return MessageDataSet
        'Catch ex As Exception
        '    'log error
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Gets All Inbox Message in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all In Message as a dataset object</remarks>

    Public Function FindAllMessageByRegNumber(ByVal MessageData As MessageData) As DataSet
        'holds a list of In Message data 
        Dim MessageDataSet As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", MessageData.RegNumber)}

        'Try
        'Fetch Inbox Message
        MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllMessageByRegNumber", params)
        Return MessageDataSet
        'Catch ex As Exception
        '    'log error
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Gets All Outbox Message in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all Out Message as a dataset object</remarks>

    Public Function FindAllOutBoxMessage(ByVal MessageData As MessageData) As DataSet
        'holds a list of Out Message data 
        Dim MessageDataSet As DataSet = New DataSet
        Dim params() As SqlParameter = _
       {New SqlParameter("@CreatedByUID", MessageData.CreatedByUID)}

        Try
            'Fetch Inbox Message
            MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllSentMessage", params)
            Return MessageDataSet
        Catch ex As Exception
            'log error
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Gets All Outbox Message in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all Out Message as a dataset object</remarks>

    Public Function FindAllOutBoxMessageByRegNumber(ByVal MessageData As MessageData) As DataSet
        'holds a list of Out Message data 
        Dim MessageDataSet As DataSet = New DataSet
        Dim params() As SqlParameter = _
       {New SqlParameter("@RegNumber", MessageData.RegNumber)}

        Try
            'Fetch Inbox Message
            MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllSentMessageByRegNumber", params)
            Return MessageDataSet
        Catch ex As Exception
            'log error
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Gets All Message in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all Message as a dataset object</remarks>

    Public Function FindAllMessages() As DataSet
        'holds a list of all Message data 
        Dim MessageDataSet As DataSet = New DataSet
        Try
            'Fetch All Message
            MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllMessages", Nothing)
            Return MessageDataSet
        Catch ex As Exception
            'log error
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Gets All Inbox Message in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all In Message as a dataset object</remarks>

    Public Function FindAllDraftMessage(ByVal MessageData As MessageData) As DataSet
        'holds a list of In Message data 
        Dim MessageDataSet As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@CreatedByUID", MessageData.CreatedByUID)}

        'Try
        'Fetch Inbox Message
        MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllDraftMessage", params)
        Return MessageDataSet
        'Catch ex As Exception
        '    'log error
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Gets All Inbox Message in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all In Message as a dataset object</remarks>

    Public Function FindAllDraftMessageByRegNumber(ByVal MessageData As MessageData) As DataSet
        'holds a list of In Message data 
        Dim MessageDataSet As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@CreatedByUID", MessageData.CreatedByUID)}

        'Try
        'Fetch Inbox Message
        MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllDraftMessageByRegNumber", params)
        Return MessageDataSet
        'Catch ex As Exception
        '    'log error
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Gets All Inbox Message in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all In Message as a dataset object</remarks>

    Public Function FindAllDeleteMessage(ByVal MessageData As MessageData) As DataSet
        'holds a list of In Message data 
        Dim MessageDataSet As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@CreatedByUID", MessageData.CreatedByUID)}

        'Try
        'Fetch Inbox Message
        MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllDeleteMessage", params)
        Return MessageDataSet
        'Catch ex As Exception
        '    'log error
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Gets All Inbox Message in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all In Message as a dataset object</remarks>

    Public Function FindAllDeleteMessageByRegNumber(ByVal MessageData As MessageData) As DataSet
        'holds a list of In Message data 
        Dim MessageDataSet As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", MessageData.RegNumber)}

        'Try
        'Fetch Inbox Message
        MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllDeleteMessageByRegNumber", params)
        Return MessageDataSet
        'Catch ex As Exception
        '    'log error
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Read All Messages
    ''' </summary>
    ''' <param name="MessageID"></param>
    ''' <returns>MessageData</returns>
    ''' <remarks>Takes MessageID as parameter and return MessageData</remarks>
    Public Function ReadMessages(ByVal MessageID As Integer, ByVal Read As String) As MessageData
        'instantiate object to hold Message data
        Dim MessageData As MessageData = New MessageData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@MessageID", MessageID), New SqlParameter("@Read", Read)}

        'Try
        'fetch Message details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "ReadMessagesAdmin", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                MessageData.MessagingID = row(0)
                MessageData.Subject = row(1)
                If Not IsDBNull(row(2)) Then
                    MessageData.MessageType = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    MessageData.UserName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    MessageData.DateTime = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    MessageData.MessageBody = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    MessageData.DocUrl = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    MessageData.DocUrl1 = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    MessageData.DocUrl2 = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    MessageData.DocUrl3 = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    MessageData.SenderID = row(10)
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
        Return MessageData
    End Function
    ''' <summary>
    ''' Read All Messages
    ''' </summary>
    ''' <param name="MessageID"></param>
    ''' <returns>MessageData</returns>
    ''' <remarks>Takes MessageID as parameter and return MessageData</remarks>
    Public Function StudentReadMessages(ByVal MessageID As Integer, ByVal Read As String) As MessageData
        'instantiate object to hold Message data
        Dim MessageData As MessageData = New MessageData
        'instantiate object to read user data
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'declare parameter to access database 
        Dim params() As SqlParameter = {New SqlParameter("@MessageID", MessageID), New SqlParameter("@Read", Read)}

        'Try
        'fetch Message details
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "ReadMessages", params)

        dt.Load(reader)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows

                MessageData.MessagingID = row(0)
                MessageData.Subject = row(1)
                If Not IsDBNull(row(2)) Then
                    MessageData.MessageType = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    MessageData.UserName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    MessageData.DateTime = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    MessageData.MessageBody = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    MessageData.DocUrl = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    MessageData.DocUrl1 = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    MessageData.DocUrl2 = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    MessageData.DocUrl3 = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    MessageData.SenderID = row(10)
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
        Return MessageData
    End Function
    ''' <summary>
    ''' Distribution message
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <remarks>Distribution message </remarks>
    Public Function MessageDistributionList(ByVal Message As MessageData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", "", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@DistributionListID", Message.DistriListID), _
        New SqlParameter("@DistListName", Message.DistListName), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByUID", Message.CreatedByUID), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
        New SqlParameter("@ReturnMessageDistID", SqlDbType.Int, 4)}

        'Assigning value to the return value
        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output
        params(7).Direction = ParameterDirection.Output
        Try
            'Get Distribution message
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_MessageDistributionList", params)
            'Populate Error Code
            RetVal(0) = params(5).Value
            'Populate Error Hint
            RetVal(1) = params(6).Value
            'Returning the Primary key
            RetVal(2) = params(7).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(5).Value
            'Populate Error Hint
            RetVal(1) = params(6).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Gets All Message in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all Message as a dataset object</remarks>

    Public Function FindAllMessageDistributionList() As DataSet
        'holds a list of all Message data 
        Dim MessageDataSet As DataSet = New DataSet
        Try
            'Fetch All Message
            MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllMessageDistributionList", Nothing)
            Return MessageDataSet
        Catch ex As Exception
            'log error
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Distribution message
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <remarks>Distribution message </remarks>
    Public Function CreateMessageDistributionList(ByVal Message As MessageData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@DistrListOwnerID", Message.DistrListOwnerID), _
        New SqlParameter("@UserID", Message.RecipientID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByUID", Message.CreatedByUID), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output

        Try
            'Get Distribution message
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateMessageDistributionList", params)
            'Populate Error Code
            RetVal(0) = params(5).Value
            'Populate Error Hint
            RetVal(1) = params(6).Value

            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(5).Value
            'Populate Error Hint
            RetVal(1) = params(6).Value
            Return RetVal
        End Try
    End Function
    ''' <summary>
    ''' Compose message
    ''' </summary>
    ''' <param name="Message"></param>
    ''' <remarks>Compose message </remarks>
    Public Function SendMessagewithDistributionList(ByVal Message As MessageData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@DistrListID", Message.RecipientID), _
        New SqlParameter("@MessageBody", Message.MessageBody), _
        New SqlParameter("@DocUrl", Message.DocUrl), _
        New SqlParameter("@SubjectMatter", Message.Subject), _
        New SqlParameter("@MessageType", Message.MessageType), _
        New SqlParameter("@SENDERID", Message.SenderID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByID", Message.CreatedByUID), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(9).Direction = ParameterDirection.Output
        params(10).Direction = ParameterDirection.Output
        'Try
        'Get Registration Number
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_SendMessagewithDistributionList", params)
        'Populate Error Code
        RetVal(0) = params(9).Value
        'Populate Error Hint
        RetVal(1) = params(10).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(9).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(10).Value
        '    Return RetVal
        'End Try
    End Function
    ''' <summary>
    ''' Finds RegistrationNumber by RegistrationNumberID
    ''' </summary>
    ''' <param name="CreatedByUID"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>It takes CountryID and returns StudentProfileData </remarks>
    Public Function FindTotalNoInboxMessage(ByVal CreatedByUID As MessageData) As String
        Dim TotalNumber As String = String.Empty
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CreatedByUID", CreatedByUID.CreatedByUID)}
        'Try
        'Fetch item based on RegistrationNumberID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTotalNoInboxMessage", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    TotalNumber = row(0)
                End If

            Next
            'Return RegistrationNumber data.
            Return TotalNumber
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try

    End Function
    ''' <summary>
    ''' Finds RegistrationNumber by RegistrationNumberID
    ''' </summary>
    ''' <param name="CreatedByUID"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>It takes CountryID and returns StudentProfileData </remarks>
    Public Function FindTotalNoInboxMessageByRegNumber(ByVal CreatedByUID As MessageData) As String
        Dim TotalNumber As String = String.Empty
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", CreatedByUID.RegNumber)}
        'Try
        'Fetch item based on RegistrationNumberID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTotalNoInboxMessageByRegNumber", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    TotalNumber = row(0)
                End If

            Next
            'Return RegistrationNumber data.
            Return TotalNumber
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try

    End Function
    ''' <summary>
    ''' Finds RegistrationNumber by RegistrationNumberID
    ''' </summary>
    ''' <param name="CreatedByUID"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>It takes CountryID and returns StudentProfileData </remarks>
    Public Function FindTotalNoSaveMessage(ByVal CreatedByUID As MessageData) As String
        Dim TotalNumber As String = String.Empty
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CreatedByUID", CreatedByUID.CreatedByUID)}
        'Try
        'Fetch item based on RegistrationNumberID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTotalNoSaveMessage", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    TotalNumber = row(0)
                End If

            Next
            'Return RegistrationNumber data.
            Return TotalNumber
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try

    End Function
    ''' <summary>
    ''' Finds RegistrationNumber by RegistrationNumberID
    ''' </summary>
    ''' <param name="CreatedByUID"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>It takes CountryID and returns StudentProfileData </remarks>
    Public Function FindTotalNoSaveMessageByRegNumber(ByVal CreatedByUID As MessageData) As String
        Dim TotalNumber As String = String.Empty
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", CreatedByUID.RegNumber)}
        'Try
        'Fetch item based on RegistrationNumberID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTotalNoSaveMessageByRegNumber", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    TotalNumber = row(0)
                End If

            Next
            'Return RegistrationNumber data.
            Return TotalNumber
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try

    End Function
    ''' <summary>
    ''' Finds RegistrationNumber by RegistrationNumberID
    ''' </summary>
    ''' <param name="CreatedByUID"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>It takes CountryID and returns StudentProfileData </remarks>
    Public Function FindTotalNoDeleteMessage(ByVal CreatedByUID As MessageData) As String
        Dim TotalNumber As String = String.Empty
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CreatedByUID", CreatedByUID.CreatedByUID)}
        'Try
        'Fetch item based on RegistrationNumberID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTotalNoDeleteMessage", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    TotalNumber = row(0)
                End If

            Next
            'Return RegistrationNumber data.
            Return TotalNumber
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try

    End Function
    ''' <summary>
    ''' Finds RegistrationNumber by RegistrationNumberID
    ''' </summary>
    ''' <param name="CreatedByUID"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>It takes CountryID and returns StudentProfileData </remarks>
    Public Function FindTotalNoDeleteMessageByRegNumber(ByVal CreatedByUID As MessageData) As String
        Dim TotalNumber As String = String.Empty
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", CreatedByUID.RegNumber)}
        'Try
        'Fetch item based on RegistrationNumberID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTotalNoDeleteMessageByRegNumber", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    TotalNumber = row(0)
                End If

            Next
            'Return RegistrationNumber data.
            Return TotalNumber
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try

    End Function
    ''' <summary>
    ''' Finds RegistrationNumber by RegistrationNumberID
    ''' </summary>
    ''' <param name="CreatedByUID"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>It takes CountryID and returns StudentProfileData </remarks>
    Public Function FindTotalNoSentMessage(ByVal CreatedByUID As MessageData) As String
        Dim TotalNumber As String = String.Empty
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CreatedByUID", CreatedByUID.CreatedByUID)}
        'Try
        'Fetch item based on RegistrationNumberID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTotalNoSentMessage", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    TotalNumber = row(0)
                End If

            Next
            'Return RegistrationNumber data.
            Return TotalNumber
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try

    End Function
    ''' <summary>
    ''' Finds RegistrationNumber by RegistrationNumberID
    ''' </summary>
    ''' <param name="CreatedByUID"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>It takes CountryID and returns StudentProfileData </remarks>
    Public Function FindTotalNoSentMessageByRegNumber(ByVal CreatedByUID As MessageData) As String
        Dim TotalNumber As String = String.Empty
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", CreatedByUID.RegNumber)}
        'Try
        'Fetch item based on RegistrationNumberID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTotalNoSentMessageByRegNumber", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    TotalNumber = row(0)
                End If

            Next
            'Return RegistrationNumber data.
            Return TotalNumber
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try

    End Function
    ''' <summary>
    ''' Gets All Message in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all Message as a dataset object</remarks>

    Public Function FindAllTeacherType() As DataSet
        'holds a list of all Message data 
        Dim MessageDataSet As DataSet = New DataSet
        'Dim params() As SqlParameter = {New SqlParameter("@CreatedByUID", CreatedByUID.CreatedByUID)}
        Try
            'Fetch All Message
            MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllTeacherType", Nothing)
            Return MessageDataSet
        Catch ex As Exception
            'log error
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Gets All Message in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all Message as a dataset object</remarks>

    Public Function FindAllTeachersByTeacherType(ByVal TeacherType As String) As DataSet
        'holds a list of all Message data 
        Dim MessageDataSet As DataSet = New DataSet
        Dim params() As SqlParameter = {New SqlParameter("@TeacherType", TeacherType)}
        Try
            'Fetch All Message
            MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllTeachersByTeacherType", params)
            Return MessageDataSet
        Catch ex As Exception
            'log error
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
    ''' <summary>
    ''' Gets All Message in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all Message as a dataset object</remarks>

    Public Function FindAllStudentsBySessionIDLevelID(ByVal SessionID As Integer, ByVal LevelID As Integer) As DataSet
        'holds a list of all Message data 
        Dim MessageDataSet As DataSet = New DataSet
        Dim params() As SqlParameter = {New SqlParameter("@SessionID", SessionID), New SqlParameter("@LevelID", LevelID)}
        'Try
        'Fetch All Message
        MessageDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStudentsBySessionIDLevelID", params)
        Return MessageDataSet
        'Catch ex As Exception
        '    'log error
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Compose message
    ''' </summary>
    ''' <param name="MessegeID"></param>
    ''' <remarks>Compose message </remarks>
    Public Function SelectedMessage(ByVal SelectMessage As String, ByVal MessegeID As Integer, ByVal CreatedByUID As Integer) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", "", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@SelectedMessage", SelectMessage), _
        New SqlParameter("@MessegeID", MessegeID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByUID", CreatedByUID), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@MessageID", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output
        params(7).Direction = ParameterDirection.Output
        'Try
        'Get Registration Number
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_SelectedMessage", params)
        'Populate Error Code
        RetVal(0) = params(5).Value
        'Populate MessageID
        RetVal(1) = params(6).Value
        'Populate Error Hint
        RetVal(2) = params(7).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(5).Value
        'Populate MessageID
        'RetVal(1) = params(6).Value
        ''Populate Error Hint
        'RetVal(2) = params(7).Value
        ''End Try
    End Function
    ''' <summary>
    ''' Delete Messages
    ''' </summary>
    ''' <param name="DeleteMessage"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It Deleting Messages</remarks>
    Public Function DeleteMessages(ByVal DeleteMessage As String, ByVal MessageID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@DeleteMessage", DeleteMessage), New SqlParameter("@MessageID", MessageID)}
        'Try
        'Create Department data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteMessage", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return 0
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' Save Messages
    ''' </summary>
    ''' <param name="SaveMessage"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It Saving Messages</remarks>
    Public Function SaveMessages(ByVal SaveMessage As String, ByVal MessageData As MessageData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SaveMessage", SaveMessage), New SqlParameter("@Message", MessageData.MessageBody), _
        New SqlParameter("@DocUrl", MessageData.DocUrl), New SqlParameter("@DocUrl1", MessageData.DocUrl1), _
        New SqlParameter("@DocUrl2", MessageData.DocUrl2), New SqlParameter("@DocUrl3", MessageData.DocUrl3), _
        New SqlParameter("@Subject", MessageData.Subject), New SqlParameter("@MessageType", MessageData.MessageType), _
        New SqlParameter("@SenderID", MessageData.SenderID)}
        Try
            'Create Department data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SaveMessages", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' FindsFindAllAttachedFile
    ''' </summary>
    ''' <param name="MessageID"></param>
    ''' <returns>StudentProfileData</returns>
    ''' <remarks>It takes MessageID and returns String </remarks>
    Public Function FindAllAttachedFile(ByVal MessageID As Integer) As String()
        Dim HasAttachment As String = String.Empty
        Dim Docurl() As String = {"", "", "", "", ""}
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@MessageID", MessageID)}
        'Try
        'Fetch item based on MessageID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllAttachedFile", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    Docurl(0) = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    Docurl(1) = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    Docurl(2) = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    Docurl(3) = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    Docurl(4) = row(4)
                End If


            Next
            'Return RegistrationNumber data.
            Return Docurl
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try

    End Function
    ''' <summary>
    ''' Delete Messages
    ''' </summary>
    ''' <param name="MessageID"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It Deleting Messages</remarks>
    Public Function DeleteMessagesFromDataBase(ByVal MessageID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@MessageID", MessageID)}
        'Try
        'Create Department data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteMessagesFromDataBase", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return 0
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' Restore Draft
    ''' </summary>
    ''' <param name="Draft"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>Draft Messages</remarks>
    Public Function RestoreDraft(ByVal Draft As String, ByVal MessageID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@Draft", Draft), New SqlParameter("@MessageID", MessageID)}
        'Try
        'Restore Draft data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "RestoreDraft", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return 0
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' Gets All Users in the System.
    ''' </summary>
    ''' <returns>DataSet</returns>
    ''' <remarks>Returns all users as a dataset object</remarks>

    Public Function FindAllUsers() As DataSet
        'holds a list of users data 
        'Dim ListUserData As List(Of UsersDataList) = New List(Of UsersDataList)
        'Dim userData As UsersDataList = New UsersDataList
        'Declare and instantiate object that holds users data
        Dim UserDataSet As DataSet = New DataSet
        Try
            'Fetch users
            UserDataSet = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllUsersForMessage", Nothing)
            Return UserDataSet
        Catch ex As Exception
            'log error
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
End Class
