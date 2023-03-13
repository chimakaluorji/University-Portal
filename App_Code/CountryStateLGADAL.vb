''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Chima Kalu-orji
'' Date: 31-01-2009
'' This Class manages Country, State and LGA.
'' Implement
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class CountryStateLGADAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Creates a Country
    ''' </summary>
    ''' <param name="Country"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates CountryStateLGAData using dept</remarks>
    Public Function CreateCountry(ByVal Country As CountryStateLGAData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CountryName", Country.CountryName)}
        Try
            'Create Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateCountry", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a State
    ''' </summary>
    ''' <param name="State"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates CountryStateLGAData using State</remarks>
    Public Function CreateState(ByVal State As CountryStateLGAData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@StateName", State.StateName), _
        New SqlParameter("@CountryID", State.CountryID)}
        Try
            'Create State data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateState", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a LGA
    ''' </summary>
    ''' <param name="LGA"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates CountryStateLGAData using LGA</remarks>
    Public Function CreateLGA(ByVal LGA As CountryStateLGAData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@LGAName", LGA.LGAName), _
        New SqlParameter("@StateID", LGA.StateID)}
        'Try
        '    'Create LGA data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateLGA", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it and return 0
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try
    End Function
    ''' <summary>
    ''' Deletes Country from the database
    ''' </summary>
    ''' <param name="CountryID"></param>
    ''' <remarks>It deletes Country record from the database </remarks>
    Public Function DeleteCountry(ByVal CountryID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CountryID", CountryID)}
        Try
            'Delete Country data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteCountry", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes State from the database
    ''' </summary>
    ''' <param name="StateID"></param>
    ''' <remarks>It deletes State record from the database </remarks>
    Public Function DeleteState(ByVal StateID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@StateID", StateID)}
        Try
            'Delete State data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteState", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes LGA from the database
    ''' </summary>
    ''' <param name="LGAID"></param>
    ''' <remarks>It deletes LGA record from the database </remarks>
    Public Function DeleteLGA(ByVal LGAID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@LGAID", LGAID)}
        Try
            'Delete LGA data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteLGA", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Updates Country Data
    ''' </summary>
    ''' <param name="Country"></param>
    ''' <remarks>It updates the database using CountryStateLGAData</remarks>
    Public Function UpdateCountry(ByVal Country As CountryStateLGAData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@CountryID", Country.CountryID), _
        New SqlParameter("@CountryName", Country.CountryName)}
        Try
            'Modify Department data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateCountry", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Updates State Data
    ''' </summary>
    ''' <param name="State"></param>
    ''' <remarks>It updates the database using CountryStateLGAData</remarks>
    Public Function UpdateState(ByVal State As CountryStateLGAData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@StateID", State.StateID), _
        New SqlParameter("@StateName", State.StateName), _
        New SqlParameter("@CountryID", State.CountryID)}
        Try
            'Modify State data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateState", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Updates LGA Data
    ''' </summary>
    ''' <param name="LGA"></param>
    ''' <remarks>It updates the database using CountryStateLGAData</remarks>
    Public Function UpdateLGA(ByVal LGA As CountryStateLGAData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@LGAID", LGA.LGAID), _
        New SqlParameter("@LGAName", LGA.LGAName), _
        New SqlParameter("@StateID", LGA.StateID)}
        'Try
        'Modify LGA data
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateLGA", params)
        Return 1
        'Catch ex As Exception
        '    'If error occurs, log it
        '    AppException.LogError(ex.Message)
        '    Return 0
        'End Try

    End Function
    ''' <summary>
    ''' Finds Country by CountryID
    ''' </summary>
    ''' <param name="CountryID"></param>
    ''' <returns>CountryStateLGAData</returns>
    ''' <remarks>It takes CountryID and returns CountryStateLGAData </remarks>
    Public Function FindCountryByID(ByVal CountryID As Integer) As CountryStateLGAData
        Dim Country As CountryStateLGAData = New CountryStateLGAData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CountryID", CountryID)}
        Try
            'Fetch item based on CountryID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindCountryByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Country.CountryID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Country.CountryName = row(1)
                    End If
                Next
                'Return Country data.
                Return Country
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
    ''' Finds LGA by LGAID
    ''' </summary>
    ''' <param name="LGAID"></param>
    ''' <returns>CountryStateLGAData</returns>
    ''' <remarks>It takes LGAID and returns CountryStateLGAData </remarks>
    Public Function FindLGAByID(ByVal LGAID As Integer) As CountryStateLGAData
        Dim LGA As CountryStateLGAData = New CountryStateLGAData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@LGAID", LGAID)}
        Try
            'Fetch item based on LGAID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindLGAByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        LGA.LGAID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        LGA.LGAName = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        LGA.StateID = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        LGA.StateName = row(3)
                    End If
                Next
                'Return Country data.
                Return LGA
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
    ''' Finds State by StateID
    ''' </summary>
    ''' <param name="StateID"></param>
    ''' <returns>CountryStateLGAData</returns>
    ''' <remarks>It takes StateID and returns CountryStateLGAData </remarks>
    Public Function FindStateByID(ByVal StateID As Integer) As CountryStateLGAData
        Dim State As CountryStateLGAData = New CountryStateLGAData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@StateID", StateID)}
        Try
            'Fetch item based on StateID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStateByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        State.StateID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        State.StateName = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        State.CountryID = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        State.CountryName = row(3)
                    End If
                Next
                'Return State data.
                Return State
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
    ''' Fetches all Countries to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllCountries() As DataSet
        'Holds Countries Data
        Dim Countries As DataSet = New DataSet
        Try
            'Fetch all Countries.
            Countries = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllCountries")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Countries data
        Return Countries
    End Function
    ''' <summary>
    ''' Fetches all States to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllStates() As DataSet
        'Holds States Data
        Dim States As DataSet = New DataSet
        Try
            'Fetch all States.
            States = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStates")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched States data
        Return States
    End Function

    ''' <summary>
    ''' Fetches States by country to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindStatesByCountry(ByVal CountryID As Integer) As DataSet
        'Holds States Data
        Dim States As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@CountryID", CountryID)}
        Try
            'Fetch all States based on the country.
            States = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindStateByCountry", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched States data
        Return States
    End Function
    ''' <summary>
    ''' Fetches all LGAs to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllLGAs() As DataSet
        'Holds LGAs Data
        Dim LGAs As DataSet = New DataSet
        Try
            'Fetch all LGAs.
            LGAs = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllLGAs")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched LGAs data
        Return LGAs
    End Function

    ''' <summary>
    ''' Fetches LGAs based on State to fill a dataset
    ''' </summary>
    ''' <param name="StateID"/>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindLGAsByState(ByVal StateID As Integer) As DataSet
        'Holds LGAs Data
        Dim LGAs As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@StateID", StateID)}
        Try
            'Fetch LGAs based on State
            LGAs = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindLGAByState", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched LGAs data
        Return LGAs
    End Function

    ''' <summary>
    ''' Finds Country by Country name
    ''' </summary>
    ''' <param name="CountryName"></param>
    ''' <returns>CountryStateLGAData</returns>
    ''' <remarks>It takes CountryName and returns CountryStateLGAData </remarks>
    Public Function FindCountryByName(ByVal CountryName As String) As CountryStateLGAData
        Dim Country As CountryStateLGAData = New CountryStateLGAData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@CountryName", CountryName)}
        Try
            'Fetch all item based on Country name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindCountryByName", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Country.CountryID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Country.CountryName = row(1)
                    End If
                Next
                Return Country
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
    ''' Finds LGA by LGA name
    ''' </summary>
    ''' <param name="LGAName"></param>
    ''' <returns>CountryStateLGAData</returns>
    ''' <remarks>It takes LGAName and returns CountryStateLGAData </remarks>
    Public Function FindLGAByName(ByVal LGAName As String) As CountryStateLGAData
        Dim LGA As CountryStateLGAData = New CountryStateLGAData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@LGAName", LGAName)}
        Try
            'Fetch all item based on LGA name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindLGAByName", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        LGA.LGAID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        LGA.LGAName = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        LGA.StateID = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        LGA.StateName = row(3)
                    End If
                Next
                Return LGA
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
    ''' Finds State by State name
    ''' </summary>
    ''' <param name="StateName"></param>
    ''' <returns>CountryStateLGAData</returns>
    ''' <remarks>It takes StateName and returns CountryStateLGAData </remarks>
    Public Function FindStateByName(ByVal StateName As String) As CountryStateLGAData
        Dim State As CountryStateLGAData = New CountryStateLGAData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@StateName", StateName)}
        Try
            'Fetch all item based on State name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStateByName", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        State.StateID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        State.StateName = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        State.CountryID = row(2)
                    End If
                Next
                Return State
            Else
                Return Nothing
            End If

        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
    End Function
End Class
