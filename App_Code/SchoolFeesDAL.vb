''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Chima kalu-orji
'' Date: 11-02-2009
'' This Class manages School Fees.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class SchoolFeesDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Creates a Departmental Fees
    ''' </summary>
    ''' <param name="DepartmentalFees"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SchoolFeesData using SchoolFees</remarks>
    Public Function CreateDepartmentalFees(ByVal DepartmentalFees As SchoolFeesData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ProgrammeID", DepartmentalFees.ProgrammeID), _
        New SqlParameter("@LevelID", DepartmentalFees.LevelID), _
        New SqlParameter("@Amount", DepartmentalFees.Amount), _
        New SqlParameter("@CreatedByUID", DepartmentalFees.CreatedByUID)}
        Try
            'Create School Fees data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateDepartmentalFees", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a School Fees Intl
    ''' </summary>
    ''' <param name="SchoolFees"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SchoolFeesData using SchoolFeesIntl</remarks>
    Public Function CreateSchoolFeesIntl(ByVal SchoolFees As SchoolFeesData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ProgrammeID", SchoolFees.ProgrammeID), _
        New SqlParameter("@DeptID", SchoolFees.DeptID), _
        New SqlParameter("@QualificationID", SchoolFees.QualificationID), _
        New SqlParameter("@LevelID", SchoolFees.LevelID), _
        New SqlParameter("@Amount", SchoolFees.Amount), _
        New SqlParameter("@CreatedByUID", SchoolFees.CreatedByUID)}
        Try
            'Create School Fees Intl data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateSchoolFeesIntl", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a School Fees State Indig
    ''' </summary>
    ''' <param name="SchoolFees"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates SchoolFeesData using SchoolFeestateIndig</remarks>
    Public Function CreateSchoolFeesStateIndig(ByVal SchoolFees As SchoolFeesData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ProgrammeID", SchoolFees.ProgrammeID), _
        New SqlParameter("@DeptID", SchoolFees.DeptID), _
        New SqlParameter("@QualificationID", SchoolFees.QualificationID), _
        New SqlParameter("@LevelID", SchoolFees.LevelID), _
        New SqlParameter("@Amount", SchoolFees.Amount), _
        New SqlParameter("@CreatedByUID", SchoolFees.CreatedByUID)}
        Try
            'Create School Fee state Indig data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateSchoolFeesStateIndig", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Fetches all School Fees to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function GetAllDepartmentalFees() As DataSet
        'Holds School Fees Data
        Dim SchoolFees As DataSet = New DataSet
        Try
            'Fetch all School Fees.
            SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "GetAllDepartmentalFees")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched School Fees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Fetches all School Fees For International students to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllSchoolFeesIntl() As DataSet
        'Holds School Fees Data
        Dim SchoolFees As DataSet = New DataSet
        Try
            'Fetch all School Fees For International students.
            SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllSchoolFeesIntl")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched School Fees For International students data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Fetches all School Fees For State Indigous Students to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllSchoolFeesStateIndig() As DataSet
        'Holds School Fees For State Indigous Students Data
        Dim SchoolFees As DataSet = New DataSet
        Try
            'Fetch all School Fees.
            SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllSchoolFeesStateIndig")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched School Fees For State Indigous Students data 
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Fetches all School Fees to fill a dataset (This API Display all the school fees in the table)
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllDepartmentalFees() As DataSet
        'Holds School Fees Data
        Dim SchoolFees As DataSet = New DataSet
        Try
            'Fetch all School Fees.
            SchoolFees = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllDepartmentalFees")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched School Fees data
        Return SchoolFees
    End Function
    ''' <summary>
    ''' Find SchoolFees By Level
    ''' </summary>
    ''' <param name="Level"></param>
    ''' <returns>SchoolFeesData</returns>
    ''' <remarks>It takes LevelID and returns SchoolFeesData </remarks>
    Public Function FindSchoolFeesByLevel(ByVal Level As String) As SchoolFeesData
        Dim data As SchoolFeesData = New SchoolFeesData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@Level", Level)}
        Try
            'Fetch all item based on LevelID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindSchoolFeesByLevel", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    data.SchoolFeesID = row(0)
                    data.ProgrammeID = row(1)
                    If Not IsDBNull(row(2)) Then
                        data.ProgrammeName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        data.DeptID = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        data.DeptName = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        data.QualificationID = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        data.QualificationName = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        data.LevelID = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        data.LevelName = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        data.Amount = row(9)
                    End If
                Next
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
    ''' Find SchoolFees By Dept
    ''' </summary>
    ''' <param name="Dept"></param>
    ''' <returns>SchoolFeesData</returns>
    ''' <remarks>It takes DeptID and returns SchoolFeesData </remarks>
    Public Function FindSchoolFeesByDept(ByVal Dept As String) As SchoolFeesData
        Dim data As SchoolFeesData = New SchoolFeesData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@DeptID", Dept)}
        Try
            'Fetch all item based on DeptID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindSchoolFeesByDept", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    data.SchoolFeesID = row(0)
                    data.ProgrammeID = row(1)
                    If Not IsDBNull(row(2)) Then
                        data.ProgrammeName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        data.DeptID = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        data.DeptName = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        data.QualificationID = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        data.QualificationName = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        data.LevelID = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        data.LevelName = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        data.Amount = row(9)
                    End If
                Next
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
    ''' Find SchoolFees By ID
    ''' </summary>
    ''' <param name="SchoolFeesID"></param>
    ''' <returns>SchoolFeesData</returns>
    ''' <remarks>It takes SchoolFeesID and returns SchoolFeesData </remarks>
    Public Function FindSchoolFeesByID(ByVal SchoolFeesID As String) As SchoolFeesData
        Dim data As SchoolFeesData = New SchoolFeesData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SchoolFeesID", SchoolFeesID)}
        Try
            'Fetch all item based on SchoolFeesID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindSchoolFeesByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    data.SchoolFeesID = row(0)
                    data.ProgrammeID = row(1)
                    If Not IsDBNull(row(2)) Then
                        data.ProgrammeName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        data.DeptID = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        data.DeptName = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        data.QualificationID = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        data.QualificationName = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        data.LevelID = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        data.LevelName = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        data.Amount = row(9)
                    End If
                Next
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
    ''' Find Intl Student SchoolFees Amount
    ''' </summary>
    ''' <param name="ProgrammeID"></param>
    ''' <returns>Amount</returns>
    ''' <remarks>It takes IntlStudFeesAmount and returns Amount </remarks>
    Public Function FindIntlStudFeesAmount(ByVal ProgrammeID As Integer, ByVal DeptID As Integer, ByVal LevelID As Integer, ByVal QualificationID As Integer) As Decimal
        'Declare and instantiate datasource access parameters
        Dim Amount As Decimal
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        Dim SqlParam() As SqlParameter = _
        {New SqlParameter("@ProgrammeID", ProgrammeID), _
         New SqlParameter("@DeptID", DeptID), _
         New SqlParameter("@LevelID", LevelID), _
         New SqlParameter("@QualificationID", QualificationID)}
        Try
            'Fetch International student schoolfees Amount 
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindIntlStudFeesAmount", SqlParam)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If IsDBNull(row(0)) Then
                        Amount = row(0)
                    End If
                Next
                Return Amount
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
    ''' Find Local Student SchoolFees Amount
    ''' </summary>
    ''' <param name="ProgrammeID"></param>
    ''' <returns>Amount</returns>
    ''' <remarks>It takes LocalStudFeesAmount and returns Amount </remarks>
    Public Function FindLocalStudFeesAmount(ByVal ProgrammeID As Integer, ByVal DeptID As Integer, ByVal LevelID As Integer, ByVal QualificationID As Integer) As Decimal
        'Declare and instantiate datasource access parameters
        Dim Amount As Decimal
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        Dim SqlParam() As SqlParameter = _
        {New SqlParameter("@ProgrammeID", ProgrammeID), _
         New SqlParameter("@DeptID", DeptID), _
         New SqlParameter("@LevelID", LevelID), _
         New SqlParameter("@QualificationID", QualificationID)}
        Try
            'Fetch Local student schoolfees Amount 
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindLocalStudFeesAmount", SqlParam)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If IsDBNull(row(0)) Then
                        Amount = row(0)
                    End If
                Next
                Return Amount
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
    ''' Find Student FeesAmount For State Indigene
    ''' </summary>
    ''' <param name="ProgrammeID"></param>
    ''' <returns>Amount</returns>
    ''' <remarks>It takes StudentFeesAmountForStateIndigene and returns Amount </remarks>
    Public Function FindStudFeesAmountForStateIndigene(ByVal ProgrammeID As Integer, ByVal DeptID As Integer, ByVal LevelID As Integer, ByVal QualificationID As Integer) As Decimal
        'Declare and instantiate datasource access parameters
        Dim Amount As Decimal = New Decimal
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        Dim SqlParam() As SqlParameter = _
        {New SqlParameter("@ProgrammeID", ProgrammeID), _
         New SqlParameter("@DeptID", DeptID), _
         New SqlParameter("@LevelID", LevelID), _
         New SqlParameter("@QualificationID", QualificationID)}
        Try
            'Fetch State Indigene student schoolfees Amount 
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStudFeesAmountForStateIndigene", SqlParam)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If IsDBNull(row(0)) Then
                        Amount = row(0)
                    End If
                Next
                Return Amount
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
    ''' Updates SchoolFees Data
    ''' </summary>
    ''' <param name="SchoolFees"></param>
    ''' <remarks>It updates the database using SchoolFeesData</remarks>
    Public Function UpdateDepartmentFees(ByVal SchoolFees As SchoolFeesData) As Integer
        'Declare and initialize data access parameters
        Dim SqlParam() As SqlParameter = _
        {New SqlParameter("@DepartmentalFeesID", SchoolFees.SchoolFeesID), _
         New SqlParameter("@ProgrammeID", SchoolFees.ProgrammeID), _
         New SqlParameter("@LevelID", SchoolFees.LevelID), _
         New SqlParameter("@Amount", SchoolFees.Amount), _
         New SqlParameter("@LastUpdatedByUID", SchoolFees.LastUpdatedByUID)}
        Try
            'Modify SchoolFees data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateDepartmentFees", SqlParam)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Updates SchoolFees For International Students Data
    ''' </summary>
    ''' <param name="SchoolFees"></param>
    ''' <remarks>It updates the database using SchoolFeesData</remarks>
    Public Function UpdateSchoolFeesIntl(ByVal SchoolFees As SchoolFeesData) As Integer
        'Declare and initialize data access parameters
        Dim SqlParam() As SqlParameter = _
        {New SqlParameter("@SchoolFeesID", SchoolFees.SchoolFeesID), _
         New SqlParameter("@ProgrammeID", SchoolFees.ProgrammeID), _
         New SqlParameter("@DeptID", SchoolFees.DeptID), _
         New SqlParameter("@QualificationID", SchoolFees.QualificationID), _
         New SqlParameter("@LevelID", SchoolFees.LevelID), _
         New SqlParameter("@Amount", SchoolFees.Amount), _
         New SqlParameter("@LastUpdatedByUID", SchoolFees.LastUpdatedByUID)}
        Try
            'Modify SchoolFees data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateSchoolFeesIntl", SqlParam)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Updates SchoolFees For State Indigous students Data
    ''' </summary>
    ''' <param name="SchoolFees"></param>
    ''' <remarks>It updates the database using SchoolFeesData</remarks>
    Public Function UpdateSchoolFeesStateIndig(ByVal SchoolFees As SchoolFeesData) As Integer
        'Declare and initialize data access parameters
        Dim SqlParam() As SqlParameter = _
        {New SqlParameter("@SchoolFeesID", SchoolFees.SchoolFeesID), _
         New SqlParameter("@ProgrammeID", SchoolFees.ProgrammeID), _
         New SqlParameter("@DeptID", SchoolFees.DeptID), _
         New SqlParameter("@QualificationID", SchoolFees.QualificationID), _
         New SqlParameter("@LevelID", SchoolFees.LevelID), _
         New SqlParameter("@Amount", SchoolFees.Amount), _
         New SqlParameter("@LastUpdatedByUID", SchoolFees.LastUpdatedByUID)}
        Try
            'Modify SchoolFees data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateSchoolFeesStateIndig", SqlParam)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Find SchoolFees By ID
    ''' </summary>
    ''' <param name="DepartmentalFeesID"></param>
    ''' <returns>SchoolFeesData</returns>
    ''' <remarks>It takes SchoolFeesID and returns SchoolFeesData </remarks>
    Public Function FindDepartmentalFeesByID(ByVal DepartmentalFeesID As Integer) As SchoolFeesData
        Dim SchoolFees As SchoolFeesData = New SchoolFeesData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@DepartmentalFeesID", DepartmentalFeesID)}
        'Try
        'Fetch item based on SchoolFeesID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindDepartmentalFeesByID", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    SchoolFees.SchoolFeesID = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    SchoolFees.ProgrammeID = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    SchoolFees.ProgrammeName = row(2)
                End If

                If Not IsDBNull(row(3)) Then
                    SchoolFees.LevelID = row(3)
                End If

                If Not IsDBNull(row(4)) Then
                    SchoolFees.LevelName = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    SchoolFees.Amount = row(5)
                End If

            Next
            'Return SchoolFees data.
            Return SchoolFees
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
    ''' Deletes DepartmentalFees from the database
    ''' </summary>
    ''' <param name="DepartmentalFeesID"></param>
    ''' <remarks>It deletes DepartmentalFees record from the database </remarks>
    Public Function DeleteDepartmentalFeesState(ByVal DepartmentalFeesID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@DepartmentalFeesID", DepartmentalFeesID)}
        Try
            'Delete DepartmentalFees data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteDepartmentalFeesState", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
End Class
