''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Nsi Idika
'' Date: 31-01-2009
'' This Class manages Pin Confirmation Transactions.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class TranPinDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Creates a TRANSACTION_ID
    ''' </summary>
    ''' <param name="CONFIRMATION_NO"></param>
    ''' <param name="REG_NO"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates TRANSACTION_ID</remarks>
    Public Function GenerateTRANSACTION_ID(ByVal CONFIRMATION_NO As String, ByVal REG_NO As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CONFIRMATION_NO", CONFIRMATION_NO), _
        New SqlParameter("@REG_NO", REG_NO), _
        New SqlParameter("@TRANSACTION_ID", SqlDbType.Int, 4)}
        'Specify output parameter
        params(2).Direction = ParameterDirection.Output
        Try
            'Persist PIN number and generate TRANSACTION_ID
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateTRANPIN", params)
            'Return the generated TRANSACTION_ID
            If Not IsDBNull(params(2).Value) Then
                Return params(2).Value
            Else
                Return 0
            End If
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    
    ''' <summary>
    ''' Logs PIN Verification Trnasaction details
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks>Logs PIN Verification Trnasaction details</remarks>
    Public Function LogPINVerification(ByVal data As TranPinData) As Integer
        'Declare and initialize data access parameters
        
        Dim params() As SqlParameter = _
        {New SqlParameter("@CONFIRMATION_NO", data.CONFIRMATION_NO), _
        New SqlParameter("@RECEIPT_NO", data.RECEIPT_NO), _
        New SqlParameter("@SUCCESS", data.SUCCESS), _
        New SqlParameter("@AMOUNT", data.AMOUNT)}
        Try
            'Modify TRANPIN data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateTRANPIN", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function

    ''' <summary>
    ''' Creates PIN Verification Trnasaction details
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks>Creates PIN Verification Trnasaction details</remarks>
    Public Function CreatePINVerification(ByVal data As TranPinData) As Integer
        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@CONFIRMATION_NO", data.CONFIRMATION_NO), _
        New SqlParameter("@REG_NO", data.REG_NO), _
        New SqlParameter("@SUCCESS", data.SUCCESS), _
        New SqlParameter("@AMOUNT", data.AMOUNT)}
        Try
            'Modify TRANPIN data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "StampTRANPIN", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Finds Tranasction PIN by Reg Number and By Session
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <param name="SessionName"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It takes Reg Number and Session to check if a student has paid for the session</remarks>
    Public Function HasPaidForThisSession(ByVal RegNumber As String, ByVal SessionName As String) As Integer
        'Dim data As TranPinData = New TranPinData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@REG_NO", RegNumber), _
        New SqlParameter("@SESSION_NAME", SessionName)}
        Try
            'Fetch item based on RegNumber and Session Name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTRANPINByREG_NOBySession", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the true

            If dt.Rows.Count > 0 Then
                
                'Return true.
                Return 1
            Else
                'Return false
                Return 0
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return 2
        End Try

    End Function

    ''' <summary>
    ''' Finds Tranasction PIN by ID
    ''' </summary>
    ''' <param name="TRANSACTION_ID"></param>
    ''' <returns>TranPinData</returns>
    ''' <remarks>It takes TRANSACTION_ID and returns TranPinData </remarks>
    Public Function FindTransPINById(ByVal TRANSACTION_ID As Integer) As TranPinData
        Dim data As TranPinData = New TranPinData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@TRANSACTION_ID", TRANSACTION_ID)}
        Try
            'Fetch item based on TRANSACTION_ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTRANPINByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        data.TRANSACTION_ID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        data.CONFIRMATION_NO = row(1)
                    End If
                    data.RECEIPT_NO = row(2)
                    If Not IsDBNull(row(3)) Then
                        data.REG_NO = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        data.SUCCESS = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        data.AMOUNT = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        data.TRAN_ST_TIME = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        data.TRAN_END_TIME = row(7)
                    End If
                Next
                'Return data.
                Return data
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Finds Tranasction PIN by CONFIRMATION_NO
    ''' </summary>
    ''' <param name="CONFIRMATION_NO"></param>
    ''' <returns>TranPinData</returns>
    ''' <remarks>It takes CONFIRMATION_NO and returns TranPinData </remarks>
    Public Function FindTransPINByCONFIRMATION_NO(ByVal CONFIRMATION_NO As String) As TranPinData
        Dim data As TranPinData = New TranPinData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CONFIRMATION_NO", CONFIRMATION_NO)}
        Try
            'Fetch item based on TRANSACTION_ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTRANPINByCONFIRMATION_NO", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        data.TRANSACTION_ID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        data.CONFIRMATION_NO = row(1)
                    End If
                    data.RECEIPT_NO = row(2)
                    If Not IsDBNull(row(3)) Then
                        data.REG_NO = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        data.SUCCESS = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        data.AMOUNT = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        data.TRAN_ST_TIME = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        data.TRAN_END_TIME = row(7)
                    End If
                Next
                'Return data.
                Return data
            Else
                Return Nothing
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' Finds Tranasction PIN by CONFIRMATION_NO
    ''' </summary>
    ''' <param name="CONFIRMATION_NO"></param>
    ''' <returns>TranPinData</returns>
    ''' <remarks>It takes CONFIRMATION_NO and returns TranPinData </remarks>
    Public Function DoesPINExist(ByVal CONFIRMATION_NO As String) As Integer
        Dim data As TranPinData = New TranPinData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CONFIRMATION_NO", CONFIRMATION_NO)}
        Try
            'Fetch item based on TRANSACTION_ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindTRANPINByCONFIRMATION_NO", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data

            If dt.Rows.Count > 0 Then
               
                'PIN already exists
                Return 1
            Else
                'PIN not yet in the local server.
                Return 0
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return 2
        End Try

    End Function
    ''' <summary>
    ''' Update the StudentNextlevelMgt Table
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It takes Reg Number and Session to check if a student has paid for the session</remarks>
    Public Function UpdateStudentLevelMgt(ByVal RegNumber As String) As String()
        'Declare and instantiate datasource access parameters
        Dim RetVal() As String = {"", "", "", ""}

        Dim params() As SqlParameter = {New SqlParameter("@SessionName", SessionName), _
                                        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
                                        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
                                        New SqlParameter("@CreatedByRegNo", RegNumber), _
                                        New SqlParameter("@retcode", SqlDbType.Int, 4), _
                                        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250), _
                                        New SqlParameter("@HasPaidFg", SqlDbType.Char, 1), _
                                        New SqlParameter("@RegCoursesFg", SqlDbType.Char, 1)}

        'Assigning value to the return value
        params(4).Direction = ParameterDirection.Output
        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output
        params(7).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UpdateStudentLevelMgt", params)
            'Populate Error Code
            RetVal(0) = params(4).Value
            'Populate Error Hint
            RetVal(1) = params(5).Value
            'Populate HasPaidFg
            RetVal(2) = params(6).Value
            'Populate RegCoursesFg
            RetVal(3) = params(7).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(4).Value
            'Populate Error Hint
            RetVal(1) = params(5).Value
            'Populate HasPaidFg
            RetVal(2) = params(6).Value
            'Populate RegCoursesFg
            RetVal(3) = params(7).Value
            Return RetVal
        End Try
    End Function
End Class
