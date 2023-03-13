Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class DigitalLibraryDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Populates Digital Library
    ''' </summary>
    ''' <param name="eBook"></param>
    ''' <returns>String()</returns>
    ''' <remarks>It takes LibraryData and returns RetCode and ErrorHint</remarks>
    Public Function UploadeBook(ByVal eBook As DigitalLibraryData) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@LibSubjID", eBook.LibSubjID), _
        New SqlParameter("@LibSubjAreaID", eBook.LibSubjAreaID), _
        New SqlParameter("@Title", eBook.Title), _
        New SqlParameter("@eBookUrl", eBook.eBookUrl), _
        New SqlParameter("@Keywords", eBook.Keywords), _
        New SqlParameter("@Author", eBook.Author), _
        New SqlParameter("@MaterialTypeID", eBook.MaterialTypeID), _
        New SqlParameter("CreatedByUID", eBook.CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 80)}

        'Assigning value to the return value
        params(10).Direction = ParameterDirection.Output
        params(11).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_PopulateLibrary", params)
            'Populate Return Code
            RetVal(0) = params(10).Value
            'Populate Error Hint
            RetVal(1) = params(11).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(10).Value
            'Populate Error Hint
            RetVal(1) = params(11).Value
            Return RetVal
        End Try

    End Function

    ''' <summary>
    ''' Populates Digital Library
    ''' </summary>
    ''' <param name="eBook"></param>
    ''' <returns>String()</returns>
    ''' <remarks>It takes LibraryData and returns RetCode and ErrorHint</remarks>
    Public Function UpdateUploadedeBook(ByVal eBook As DigitalLibraryData, ByVal DigitalLibraryID As Integer) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@DigitalLibraryID", DigitalLibraryID), _
        New SqlParameter("@LibSubjID", eBook.LibSubjID), _
        New SqlParameter("@LibSubjAreaID", eBook.LibSubjAreaID), _
        New SqlParameter("@Title", eBook.Title), _
        New SqlParameter("@eBookUrl", eBook.eBookUrl), _
        New SqlParameter("@Keywords", eBook.Keywords), _
        New SqlParameter("@Author", eBook.Author), _
        New SqlParameter("@MaterialTypeID", eBook.MaterialTypeID), _
        New SqlParameter("CreatedByUID", eBook.CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 80)}

        'Assigning value to the return value
        params(11).Direction = ParameterDirection.Output
        params(12).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UpdateUploadedBook", params)
            'Populate Return Code
            RetVal(0) = params(11).Value
            'Populate Error Hint
            RetVal(1) = params(12).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(11).Value
            'Populate Error Hint
            RetVal(1) = params(12).Value
            Return RetVal
        End Try

    End Function

    ''' <summary>
    ''' Populates Digital Library
    ''' </summary>
    ''' <param name="eBook"></param>
    ''' <returns>String()</returns>
    ''' <remarks>It takes LibraryData and returns RetCode and ErrorHint</remarks>
    Public Function DeleteUploadedeBook(ByVal eBook As DigitalLibraryData, ByVal DigitalLibraryID As Integer) As String()
        Dim RetVal() As String = {"", ""}

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@DigitalLibraryID", DigitalLibraryID), _
        New SqlParameter("CreatedByUID", eBook.CreatedByUID), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 80)}

        'Assigning value to the return value
        params(4).Direction = ParameterDirection.Output
        params(5).Direction = ParameterDirection.Output
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_DeleteUploadedBook", params)
            'Populate Return Code
            RetVal(0) = params(4).Value
            'Populate Error Hint
            RetVal(1) = params(5).Value
            Return RetVal
        Catch ex As Exception
            'If error occurs, log it and return errorcode
            RetVal(0) = params(4).Value
            'Populate Error Hint
            RetVal(1) = params(5).Value
            Return RetVal
        End Try

    End Function
    ''' <summary>
    ''' Fetches all Library Subject Area to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllLibSubjectArea() As DataSet
        'Holds Lib Subject Area Data
        Dim data As DataSet = New DataSet
        Try
            'Fetch all departments.
            data = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllSubjectArea")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Subject Area data
        Return data
    End Function

    ''' <summary>
    ''' Fetches all Library Subjects by subject area to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindLibSubjectsByArea(ByVal LibSubjAreaID As Integer) As DataSet
        'Holds Lib Subject Area Data
        Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@LibSubjAreaID", LibSubjAreaID)}
        Try
            'Fetch all departments.
            data = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindLibSubjectsByArea", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Subject Area data
        Return data
    End Function

    ''' <summary>
    ''' Fetches eBooks by subject area to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindeBookBySubjArea(ByVal LibSubjAreaID As Integer, ByVal MaterialTypeID As Integer) As DataSet
        'Holds Lib Subject Area Data
        Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@LibSubjAreaID", LibSubjAreaID), _
        New SqlParameter("@MaterialTypeID", MaterialTypeID)}
        Try
            'Fetch all departments.
            data = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindeBookBySubjArea", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Subject Area data
        Return data
    End Function

    ''' <summary>
    ''' Fetches eBooks by subject area to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindeBookBySubjMaterialType(ByVal MaterialTypeID As Integer) As DataSet
        'Holds Lib Subject Area Data
        Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@MaterialTypeID", MaterialTypeID)}
        Try
            'Fetch all departments.
            data = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindeBookBySubjMaterialType", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Subject Area data
        Return data
    End Function
    ''' <summary>
    ''' Fetches eBooks by subject area to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindeAllBooks() As DataSet
        'Holds Lib Subject Area Data
        Dim data As DataSet = New DataSet
        Try
            'Fetch all departments.
            data = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "SP_ListAllBook")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Subject Area data
        Return data
    End Function

    ''' <summary>
    ''' Fetches eBooks by subject to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindeBookBySubject(ByVal LibSubjAreaID As Integer, ByVal LibSubjID As Integer) As DataSet
        'Holds Lib Subject Area Data
        Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@LibSubjAreaID", LibSubjAreaID), _
        New SqlParameter("@LibSubjID", LibSubjID)}
        Try
            'Fetch all departments.
            data = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "SP_ListBookBySubject", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Subject Area data
        Return data
    End Function

    ''' <summary>
    ''' Fetches eBooks by subject to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindeBookByKeywords(ByVal LibSubjAreaID As Integer, ByVal LibSubjID As Integer, ByVal MaterialTypeID As Integer, ByVal Keywords As String) As DataSet
        'Holds Lib Subject Area Data
        Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@LibSubjAreaID", LibSubjAreaID), _
        New SqlParameter("@LibSubjID", LibSubjID), _
        New SqlParameter("@MaterialTypeID", MaterialTypeID), _
        New SqlParameter("@Keywords", Keywords)}
        Try
            'Fetch all departments.
            data = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "SP_ListBookByTitle", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Subject Area data
        Return data
    End Function

    ''' <summary>
    ''' Fetches PhysicalBooks by subject area to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindeAllPhysicalBooks() As DataSet
        'Holds Lib Subject Area Data
        Dim data As DataSet = New DataSet
        Try
            'Fetch all departments.
            data = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "SP_ListAllPhysicalBooks")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Subject Area data
        Return data
    End Function

    ''' <summary>
    ''' Fetches eBooks by subject to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindPhysicalBookByCat(ByVal PhyLibCatID As Integer) As DataSet
        'Holds Lib Subject Area Data
        Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@PhyLibCatID", PhyLibCatID)}
        Try
            'Fetch all departments.
            data = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "SP_ListPhysicalBooksByCat", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Subject Area data
        Return data
    End Function

    ''' <summary>
    ''' Fetches eBooks by subject to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindPhysicalBookByTitle(ByVal Title As String) As DataSet
        'Holds Lib Subject Area Data
        Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@Title", Title)}
        Try
            'Fetch all departments.
            data = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "SP_FindPhysicalBooksByTitle", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Subject Area data
        Return data
    End Function


    ''' <summary>
    ''' Create Library Subject Area
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>it returns a Integer</remarks>
    Public Function CreateLibrarySubjectArea(ByVal MaterialTypeID As Integer, ByVal LibrarySubjectArea As String) As Integer
        'Holds Lib Subject Area Data
        'Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@MaterialTypeID", MaterialTypeID), _
        New SqlParameter("@LibrarySubjectArea", LibrarySubjectArea)}
        Try
            'Create Library Subject Area.
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateLibrarySubjectArea", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return 0
        End Try
        'Return Integer
        Return 1
    End Function

    ''' <summary>
    ''' Create Material Type
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>it returns a Integer</remarks>
    Public Function CreateMaterialType(ByVal MaterialType As String) As Integer
        'Holds Material Type Data
        'Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@MaterialType", MaterialType)}
        Try
            'Create Material Type.
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateMaterialType", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return 0
        End Try
        ' Return Integer
        Return 1
    End Function


    ''' <summary>
    ''' Create Library Subject
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>it returns a Integer</remarks>
    Public Function CreateLibrarySubject(ByVal MaterialTypeID As Integer, ByVal LibrarySubject As String, ByVal LibrarySubjectAreaID As Integer) As Integer
        'Holds Lib Subject Data
        'Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@MaterialTypeID", MaterialTypeID), _
        New SqlParameter("@LibrarySubject", LibrarySubject), _
        New SqlParameter("@LibrarySubjectAreaID", LibrarySubjectAreaID)}
        Try
            'Create Library Subject.
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateLibrarySubject", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return 0
        End Try
        'Return Integer
        Return 1
    End Function

    ''' <summary>
    ''' Fetches Library Subject Area
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindLibrarySubjectArea() As DataSet
        'Holds Lib Subject Area Data
        Dim data As DataSet = New DataSet
        Try
            'Fetch all Library Subject Area.
            data = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindLibrarySubjectArea")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Subject Area data
        Return data
    End Function
    ''' <summary>
    ''' Fetches Library Material Type
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindMaterialType() As DataSet
        'Holds Lib Subject Area Data
        Dim data As DataSet = New DataSet
        Try
            'Fetch all Material Type.
            data = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindMaterialType")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Subject Area data
        Return data
    End Function
    ''' <summary>
    ''' Fetches Library Subject
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindLibrarySubject() As DataSet
        'Holds Lib Subject Data
        Dim data As DataSet = New DataSet
        Try
            'Fetch all Library Subject .
            data = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindLibrarySubject")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Subject data
        Return data
    End Function

    ''' <summary>
    ''' Fetches Uploaded Books
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindUploadedBooks() As DataSet
        'Holds Lib Uploaded Books Data
        Dim data As DataSet = New DataSet
        Try
            'Fetch all Uploaded Books Subject .
            data = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindUploadedBooks")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Uploaded Books data
        Return data
    End Function
    ''' <summary>
    ''' Finds Library Subject Area by ID
    ''' </summary>
    ''' <param name="LibrarySubjectAreaID"></param>
    ''' <returns>DigitalLibraryData</returns>
    ''' <remarks>It takes LibrarySubjectAreaID and returns DigitalLibraryData </remarks>
    Public Function FindLibrarySubjectAreaById(ByVal LibrarySubjectAreaID As Integer) As DigitalLibraryData
        Dim DigitalLibrary As DigitalLibraryData = New DigitalLibraryData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@LibrarySubjectAreaID", LibrarySubjectAreaID)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindLibrarySubjectAreaByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        DigitalLibrary.LibSubjAreaID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        DigitalLibrary.MaterialTypeID = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        DigitalLibrary.SubjectAreaName = row(2)
                    End If
                Next
                'Return DigitalLibrary data.
                Return DigitalLibrary
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
    ''' Edit Library Subject Area
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>it returns a Integer</remarks>
    Public Function UpdateLibrarySubjectArea(ByVal LibrarySubjectArea As String, ByVal MaterialTypeID As Integer, ByVal LibrarySubjectAreaID As Integer) As Integer
        'Holds Lib Subject Area Data
        'Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@LibrarySubjectArea", LibrarySubjectArea), _
        New SqlParameter("@MaterialTypeID", MaterialTypeID), _
        New SqlParameter("@LibrarySubjectAreaID", LibrarySubjectAreaID)}
        Try
            'Create Library Subject Area.
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateLibrarySubjectArea", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return 0
        End Try
        'Return Integer
        Return 1
    End Function

    ''' <summary>
    ''' Edit Material Type
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>it returns a Integer</remarks>
    Public Function UpdateMaterialType(ByVal MaterialType As String, ByVal MaterialTypeID As Integer) As Integer
        'Holds Lib Subject Area Data
        'Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@MaterialType", MaterialType), _
        New SqlParameter("@MaterialTypeID", MaterialTypeID)}
        Try
            'Create Library Subject Area.
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateMaterialType", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return 0
        End Try
        'Return Integer
        Return 1
    End Function
    ''' <summary>
    ''' Finds Library Subject by ID
    ''' </summary>
    ''' <param name="LibrarySubjectID"></param>
    ''' <returns>DigitalLibraryData</returns>
    ''' <remarks>It takes LibrarySubjectAreaID and returns DigitalLibraryData </remarks>
    Public Function FindLibrarySubjectById(ByVal LibrarySubjectID As Integer) As DigitalLibraryData
        Dim DigitalLibrary As DigitalLibraryData = New DigitalLibraryData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@LibrarySubjectID", LibrarySubjectID)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindLibrarySubjectByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        DigitalLibrary.LibSubjID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        DigitalLibrary.LibSubjAreaID = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        DigitalLibrary.MaterialTypeID = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        DigitalLibrary.LibSubjName = row(3)
                    End If
                Next
                'Return DigitalLibrary data.
                Return DigitalLibrary
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
    ''' Edit Library Subject
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>it returns a Integer</remarks>
    Public Function UpdateLibrarySubject(ByVal LibrarySubject As String, ByVal LibrarySubjectAreaID As Integer, ByVal LibrarySubjectID As Integer, ByVal MaterialTypeID As Integer) As Integer
        'Holds Lib Subject Data
        'Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@LibrarySubjectID", LibrarySubjectID), _
        New SqlParameter("@LibrarySubject", LibrarySubject), _
        New SqlParameter("@MaterialTypeID", MaterialTypeID), _
        New SqlParameter("@LibrarySubjectAreaID", LibrarySubjectAreaID)}
        Try
            'Edit Library Subject.
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateLibrarySubject", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return 0
        End Try
        'Return Integer
        Return 1
    End Function
    ''' <summary>
    ''' Finds Uploaded Book by ID
    ''' </summary>
    ''' <param name="UploadedBookID"></param>
    ''' <returns>DigitalLibraryData</returns>
    ''' <remarks>It takes UploadedBookID and returns DigitalLibraryData </remarks>
    Public Function FindUploadedBookById(ByVal UploadedBookID As Integer) As DigitalLibraryData
        Dim DigitalLibrary As DigitalLibraryData = New DigitalLibraryData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@DigitalLibraryID", UploadedBookID)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindUpoladeBookByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        DigitalLibrary.LibSubjID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        DigitalLibrary.LibSubjAreaID = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        DigitalLibrary.Title = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        DigitalLibrary.eBookUrl = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        DigitalLibrary.Keywords = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        DigitalLibrary.Author = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        DigitalLibrary.MaterialTypeID = row(6)
                    End If
                Next
                'Return DigitalLibrary data.
                Return DigitalLibrary
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
    ''' Delete Library Subject Area
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>it returns a Integer</remarks>
    Public Function DeleteLibrarySubjectArea(ByVal LibrarySubjectAreaID As Integer) As Integer
        'Holds Lib Subject Area Data
        'Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@LibrarySubjectAreaID", LibrarySubjectAreaID)}
        Try
            'Delete Library Subject Area.
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteLibrarySubjectArea", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return 0
        End Try
        'Return Integer
        Return 1
    End Function
    ''' <summary>
    ''' Delete Material Type
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>it returns a Integer</remarks>
    Public Function DeleteMaterialType(ByVal MaterialTypeID As Integer) As Integer
        'Holds Lib Subject Area Data
        'Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@MaterialTypeID", MaterialTypeID)}
        Try
            'Delete Material Type.
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteMaterialType", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return 0
        End Try
        'Return Integer
        Return 1
    End Function


    ''' <summary>
    ''' Delete Library Subject
    ''' </summary>
    ''' <returns>Integer</returns>
    ''' <remarks>it returns a Integer</remarks>
    Public Function DeleteLibrarySubject(ByVal LibrarySubjectID As Integer) As Integer
        'Holds Lib Subject Data
        'Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@LibrarySubjectID", LibrarySubjectID)}
        Try
            'Delete Library Subject.
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteLibrarySubject", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return 0
        End Try
        'Return Integer
        Return 1
    End Function
    ''' <summary>
    ''' Fetches Digital Library By Sub Lib Sub Lib Area to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindDigitalLibraryBySubLibIDSubLibAreaID(ByVal SubjectAreaID As Integer, ByVal SubjNameID As Integer, ByVal MaterialTypeID As Integer) As DataSet
        'Holds Lib Digital Library Data
        Dim data As DataSet = New DataSet
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubjectAreaID", SubjectAreaID), _
        New SqlParameter("@MaterialTypeID", MaterialTypeID), _
        New SqlParameter("@SubjNameID", SubjNameID)}
        Try
            'Fetch all Digital Library.
            data = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindDigitalLibraryBySubLibIDSubLibAreaID", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Digital Library
        Return data
    End Function
    ''' <summary>
    ''' Finds Material Type by ID
    ''' </summary>
    ''' <param name="MaterialTypeID"></param>
    ''' <returns>DigitalLibraryData</returns>
    ''' <remarks>It takes MaterialTypeById and returns DigitalLibraryData </remarks>
    Public Function FindMaterialTypeById(ByVal MaterialTypeID As Integer) As DigitalLibraryData
        Dim DigitalLibrary As DigitalLibraryData = New DigitalLibraryData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@MaterialTypeID", MaterialTypeID)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindMaterialTypeById", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        DigitalLibrary.MaterialTypeID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        DigitalLibrary.MaterialType = row(1)
                    End If
                Next
                'Return DigitalLibrary data.
                Return DigitalLibrary
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
    ''' Finds DigitalLibrary by ID
    ''' </summary>
    ''' <param name="DigitalLibraryID"></param>
    ''' <returns>DigitalLibraryData</returns>
    ''' <remarks>It takes LibrarySubjectAreaID and returns DigitalLibraryData </remarks>
    Public Function FindAllDigitalLibraryById(ByVal DigitalLibraryID As Integer) As DigitalLibraryData
        Dim DigitalLibrary As DigitalLibraryData = New DigitalLibraryData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@DigitalLibraryID", DigitalLibraryID)}
        Try
            'Fetch item based on ID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllDigitalLibraryById", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        DigitalLibrary.DigitalLibraryID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        DigitalLibrary.eBookUrl = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        DigitalLibrary.Title = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        DigitalLibrary.Author = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        DigitalLibrary.LibSubjName = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        DigitalLibrary.MaterialType = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        DigitalLibrary.SubjectAreaName = row(6)
                    End If
                Next
                'Return DigitalLibrary data.
                Return DigitalLibrary
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
