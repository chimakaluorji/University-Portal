''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Nsi Idika
'' Date: 24-01-2009
'' This Class manages Academic Departments.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class DepartmentDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Creates a department
    ''' </summary>
    ''' <param name="dept"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates DepartmentData using dept</remarks>
    Public Function CreateDepartment(ByVal dept As DepartmentData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@DeptName", dept.DeptName), _
        New SqlParameter("@ShortName", dept.ShortName), _
        New SqlParameter("@FacultyID", dept.FacultyID)}
        Try
            'Create Department data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateDepartment", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes department from the database
    ''' </summary>
    ''' <param name="DeptID"></param>
    ''' <remarks>It deletes department record from the database </remarks>
    Public Function DeleteDepartment(ByVal DeptID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@DeptID", DeptID)}
        Try
            'Delete Department data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteDepartment", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Updates Department Data
    ''' </summary>
    ''' <param name="dept"></param>
    ''' <remarks>It updates the database using DepartmentData</remarks>
    Public Function UpdateDepartment(ByVal dept As DepartmentData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@DeptID", dept.DeptID), _
        New SqlParameter("@DeptName", dept.DeptName), _
        New SqlParameter("@ShortName", dept.ShortName), _
        New SqlParameter("@FacultyID", dept.FacultyID)}
        Try
            'Modify Department data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateDepartment", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Finds Department by DeptID
    ''' </summary>
    ''' <param name="DeptID"></param>
    ''' <returns>DepartmentData</returns>
    ''' <remarks>It takes DeptID and returns DepartmentData </remarks>
    Public Function FindDepartmentById(ByVal DeptID As Integer) As DepartmentData
        Dim Dept As DepartmentData = New DepartmentData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@DeptID", DeptID)}
        Try
            'Fetch item based on DeptID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "GetDepartmentByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        Dept.DeptName = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        Dept.ShortName = row(1)
                    End If
                    Dept.DeptID = row(2)
                    If Not IsDBNull(row(3)) Then
                        Dept.FacultyName = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        Dept.FacultyID = row(4)
                    End If
                Next
                'Return department data.
                Return Dept
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
    ''' Fetches all department to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllDepartments() As DataSet
        'Holds Department Data
        Dim Dept As DataSet = New DataSet
        Try
            'Fetch all departments.
            Dept = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "GetAllDepartments")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched department data
        Return Dept
    End Function

    ''' <summary>
    ''' Finds department by department name
    ''' </summary>
    ''' <param name="DeptName"></param>
    ''' <returns>DepartmentData</returns>
    ''' <remarks>It takes DeptName and returns DepartmentData </remarks>
    Public Function FindDepartmentByName(ByVal DeptName As String) As DepartmentData
        Dim data As DepartmentData = New DepartmentData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@DeptName", DeptName)}
        Try
            'Fetch all item based on department name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "GetdepartmentBydeptname", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    data.DeptID = row(0)
                    data.DeptName = row(1)
                    If Not IsDBNull(row(2)) Then
                        data.ShortName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        data.FacultyName = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        data.FacultyID = row(4)
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
    ''' Finds department by department shortname
    ''' </summary>
    ''' <param name="shortname"></param>
    ''' <returns>DepartmentData</returns>
    ''' <remarks>It takes shortname and returns DepartmentData </remarks>
    Public Function FindDepartmentByShortname(ByVal shortname As String) As DepartmentData
        Dim data As DepartmentData = New DepartmentData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@ShortName", shortname)}
        Try
            'Fetch all item based on department name
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindDepartmentByShortname", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    data.DeptID = row(0)
                    data.DeptName = row(1)
                    If Not IsDBNull(row(2)) Then
                        data.ShortName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        data.FacultyName = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        data.FacultyID = row(4)
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
    '''  Finds Department by FacultyID
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindDeptByFacultyId(ByVal FacultyID As Integer) As DataSet
        'Holds States Data
        Dim Dept As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@FacultyID", FacultyID)}
        Try
            'Fetch all States based on the country.
            Dept = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindDeptByFacultyId", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched States data
        Return Dept
    End Function
End Class
