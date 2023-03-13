''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Chima Kalu-orji
'' Date: 18-05-2009
'' This Class manages the student result.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient


Public Class ComplainDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Get Registration Number
    ''' </summary>
    ''' <param name="Complain"></param>
    ''' <remarks>It Get Registration Number </remarks>
    Public Function ResolveComplain(ByVal Complain As ComplainData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNum", Complain.RegNum), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByUID", Complain.CreatedByUID), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(4).Direction = ParameterDirection.Output
        params(5).Direction = ParameterDirection.Output
        'Try
        'Get Registration Number
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_ResolveComplain", params)
        'Populate Error Code
        RetVal(0) = params(4).Value
        'Populate Error Hint
        RetVal(1) = params(5).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(4).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(5).Value
        '    Return RetVal
        'End Try
    End Function
    ''' <summary>
    ''' Create Complain
    ''' </summary>
    ''' <param name="Complain"></param>
    ''' <remarks>It Create Complain </remarks>
    Public Function CreateComplain(ByVal Complain As ComplainData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNum", Complain.RegNum), _
        New SqlParameter("@Complain", Complain.Complain), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByUID", Complain.CreatedByUID), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}

        'Assigning value to the return value
        params(5).Direction = ParameterDirection.Output
        params(6).Direction = ParameterDirection.Output
        'Try
        'Create Complain
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateComplain", params)
        'Populate Error Code
        RetVal(0) = params(5).Value
        'Populate Error Hint
        RetVal(1) = params(6).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(5).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(6).Value
        '    Return RetVal
        'End Try
    End Function
    
    ''' <summary>
    ''' Fetches all RegNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function GetRegNumberComplain(ByVal RegistrationNumber As String) As DataSet
        'Holds RegNumber Data
        Dim RegNumber As DataSet = New DataSet

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", RegistrationNumber)}

        Try
            'Fetch all RegNumber.
            RegNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "GetRegNumberComplain", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegNumber data
        Return RegNumber
    End Function
    ''' <summary>
    ''' Fetches all RegNumber to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function GetAllRegNumberComplain() As DataSet
        'Holds RegNumber Data
        Dim RegNumber As DataSet = New DataSet

        Try
            'Fetch all RegNumber.
            RegNumber = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "GetAllRegNumberComplain")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched RegNumber data
        Return RegNumber
    End Function
    ''' <summary>
    ''' Creates a Country
    ''' </summary>
    ''' <param name="Country"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates CountryStateLGAData using dept</remarks>
    Public Function CreateTest(ByVal RegNo As Integer, ByVal Exam As String, ByVal CA As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNo", RegNo), _
        New SqlParameter("@Exam", Exam), _
        New SqlParameter("@CA", CA)}
        'Try
        'Create Country data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateTest", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return 0
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
End Class
