''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Nsi Idika
'' Date: 10-03-2009
'' This Class manages O Level Result
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class OLevelResultDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Creates a O Level Subject
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates O Level Subject</remarks>
    Public Function CreateOLevelSubject(ByVal data As OLevelResultData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubjectName", data.SubjectName)}
        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateOLevelSubject", params)
            Return 1
        Catch ex As Exception
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes O Level Subject from the database
    ''' </summary>
    ''' <param name="OLevelSubjectID"></param>
    ''' <remarks>It deletes O Level Subject record from the database </remarks>
    Public Function DeleteOLevelSubject(ByVal OLevelSubjectID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@OLevelSubjectID", OLevelSubjectID)}
        Try
            'Delete Lecturer data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteOLevelSubject", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Updates O Level Subject Data
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks>It updates the database using OLevelResultData</remarks>
    Public Function UpdateOLevelSubject(ByVal data As OLevelResultData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubjectName", data.SubjectName), _
        New SqlParameter("@OLevelSubjectID", data.OLevelSubjectID)}
        Try
            'Modify Lecturer data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateOLevelSubject", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Finds OLevelSubject by SubjectID
    ''' </summary>
    ''' <param name="OLevelSubjectID"></param>
    ''' <returns>OLevelResultData</returns>
    ''' <remarks>It takes OLevelSubjectID and returns OLevelResultData </remarks>
    Public Function FindOLevelSubjectById(ByVal OLevelSubjectID As Integer) As OLevelResultData
        Dim data As OLevelResultData = New OLevelResultData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@OLevelSubjectID", OLevelSubjectID)}
        Try
            'Fetch item based on SubjectID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindOLevelSubjectByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    data.OLevelSubjectID = row(0)
                    If Not IsDBNull(row(1)) Then
                        data.SubjectName = row(1)
                    End If
                    
                Next
                'Return Subject data.
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
    ''' Fetches all O Level Subjects to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllOLevelSubjects() As DataSet
        'Holds OLevelSubjects Data
        Dim OLevelSubjects As DataSet = New DataSet
        Try
            'Fetch all OLevelSubjects.
            OLevelSubjects = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllOLevelSubject")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched OLevelSubjects data
        Return OLevelSubjects
    End Function
    ''' <summary>
    ''' Creates ExamsBody
    ''' </summary>
    ''' <param name="ExamsBodyName"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates Exams Body</remarks>
    Public Function CreateExamsBody(ByVal ExamsBodyName As String) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("ExamsBodyName", ExamsBodyName)}
        Try
            'Create ExamsBody data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateExamsBody", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Deletes Exams Body from the database
    ''' </summary>
    ''' <param name="ExamsBodyID"></param>
    ''' <remarks>It deletes Exams Body record from the database </remarks>
    Public Function DeleteExamsBody(ByVal ExamsBodyID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ExamsBodyID", ExamsBodyID)}
        Try
            'Delete Exams Body data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteExamsBody", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Updates Exams Body Data
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks>It updates the Exams Body using OLevelResultData</remarks>
    Public Function UpdateExamsBody(ByVal data As OLevelResultData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ExamsBodyID", data.ExamsBodyID), _
        New SqlParameter("@ExamsBodyName", data.ExamsBodyName)}
        Try
            'Modify Exams Body data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateExamsBody", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function

    ''' <summary>
    ''' Finds Exams Body by ID
    ''' </summary>
    ''' <param name="ExamsBodyID"></param>
    ''' <returns>OLevelResultData</returns>
    ''' <remarks>It takes ExamsBodyID and returns OLevelResultData </remarks>
    Public Function FindExamsBodyById(ByVal ExamsBodyID As Integer) As OLevelResultData
        Dim data As OLevelResultData = New OLevelResultData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@ExamsBodyID", ExamsBodyID)}
        Try
            'Fetch item based on ExamsBodyID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindExamsBodyByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    data.ExamsBodyID = row(0)
                    If Not IsDBNull(row(1)) Then
                        data.ExamsBodyName = row(1)
                    End If
                Next
                'Return Subject data.
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
    ''' Fetches all Exams Bodies to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllExamsBody() As DataSet
        'Holds Exams Bodies Data
        Dim ExamsBodies As DataSet = New DataSet
        Try
            'Fetch all Exams Bodies.
            ExamsBodies = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllExamsBody")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Exams Bodies data
        Return ExamsBodies
    End Function

    ''' <summary>
    ''' Creates O Level Grade
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates O Level Grade</remarks>
    Public Function CreateOLevelGrade(ByVal data As OLevelResultData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@ExamsBodyID", data.ExamsBodyID), _
        New SqlParameter("@Grade", data.Grade), _
        New SqlParameter("@GradeDescription", data.GradeDescription)}
        Try
            'Create O Level Grade data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateSubjectGrade", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Updates O Level Grade
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks>It updates O Level Grade using OLevelResultData</remarks>
    Public Function UpdateOLevelGrade(ByVal data As OLevelResultData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubjectGradeID", data.SubjectGradeID), _
        New SqlParameter("@ExamsBodyID", data.ExamsBodyID), _
        New SqlParameter("@Grade", data.Grade), _
        New SqlParameter("@GradeDescription", data.GradeDescription)}
        Try
            'Modify O Level Grade 
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateSubjectGrade", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function

    ''' <summary>
    ''' Deletes O Level Grade from the database
    ''' </summary>
    ''' <param name="SubjectGradeID"></param>
    ''' <remarks>It deletes O Level Grade record from the database </remarks>
    Public Function DeleteOLevelGrade(ByVal SubjectGradeID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubjectGradeID", SubjectGradeID)}
        Try
            'Delete O Level Grade
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteSubjectGrade", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Finds O Level Grade by ID
    ''' </summary>
    ''' <param name="SubjectGradeID"></param>
    ''' <returns>OLevelResultData</returns>
    ''' <remarks>It takes SubjectGradeID and returns OLevelResultData </remarks>
    Public Function FindOLevelGradeById(ByVal SubjectGradeID As Integer) As OLevelResultData
        Dim data As OLevelResultData = New OLevelResultData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SubjectGradeID", SubjectGradeID)}
        Try
            'Fetch item based on SubjectGradeID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindSubjGradeByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
               
                For Each row As DataRow In dt.Rows
                    data.SubjectGradeID = row(0)
                    If Not IsDBNull(row(1)) Then
                        data.ExamsBodyID = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        data.ExamsBodyName = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        data.Grade = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        data.GradeDescription = row(4)
                    End If
                Next
                'Return Grade data.
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
    ''' Fetches all O Level Grades to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllOLevelGrades() As DataSet
        'Holds O Level Grades Data
        Dim OLevelGrades As DataSet = New DataSet
        Try
            'Fetch all O Level Grades.
            OLevelGrades = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllSubjectGrade")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched O Level Grades
        Return OLevelGrades
    End Function

    ''' <summary>
    ''' Fetches all O Level Grades to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindOLevelGradesByExamsBody(ByVal ExamsBodyID As Integer) As DataSet
        'Holds O Level Grades Data
        Dim OLevelGrades As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@ExamsBodyID", ExamsBodyID)}
        Try
            'Fetch all O Level Grades.
            OLevelGrades = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindSubjGradeByExamsBody", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched O Level Grades
        Return OLevelGrades
    End Function
    ''' <summary>
    ''' Creates O Level Result
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates O Level Result</remarks>
    Public Function CreateOLevelResult(ByVal data As OLevelResultData) As Integer
        'Declare and initialize data access parameters
        
        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNo", data.RegNo), _
        New SqlParameter("@ExamsBodyID", data.ExamsBodyID), _
        New SqlParameter("@ExamsMonth", data.ExamsMonth), _
        New SqlParameter("@ExamsYear", data.ExamsYear), _
        New SqlParameter("@Sitting", data.Sitting), _
        New SqlParameter("@OlevelSubject1", data.OlevelSubject1), _
        New SqlParameter("@OlevelSubject2", data.OlevelSubject2), _
        New SqlParameter("@OlevelSubject3", data.OlevelSubject3), _
        New SqlParameter("@OlevelSubject4", data.OlevelSubject4), _
        New SqlParameter("@OlevelSubject5", data.OlevelSubject5), _
        New SqlParameter("@OlevelSubject6", data.OlevelSubject6), _
        New SqlParameter("@OlevelSubject7", data.OlevelSubject7), _
        New SqlParameter("@OlevelSubject8", data.OlevelSubject8), _
        New SqlParameter("@OlevelSubject9", data.OlevelSubject9), _
        New SqlParameter("@Grade1", data.Grade1), _
        New SqlParameter("@Grade2", data.Grade2), _
        New SqlParameter("@Grade3", data.Grade3), _
        New SqlParameter("@Grade4", data.Grade4), _
        New SqlParameter("@Grade5", data.Grade5), _
        New SqlParameter("@Grade6", data.Grade6), _
        New SqlParameter("@Grade7", data.Grade7), _
        New SqlParameter("@Grade8", data.Grade8), _
        New SqlParameter("@Grade9", data.Grade9)}

        Try
            'Assign Asset
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateOLevelResult", params)

            Return 1
        Catch ex As Exception
            'If error occurs, log it and return errorcode

            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Updates O Level Result
    ''' </summary>
    ''' <param name="data"></param>
    ''' <remarks>It updates O Level Result using OLevelResultData</remarks>
    Public Function UpdateOLevelResult(ByVal data As OLevelResultData) As Integer
        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@OLevelResultID", data.OLevelResultID), _
        New SqlParameter("@RegNo", data.RegNo), _
        New SqlParameter("@ExamsBodyID", data.ExamsBodyID), _
        New SqlParameter("@ExamsMonth", data.ExamsMonth), _
        New SqlParameter("@ExamsYear", data.ExamsYear), _
        New SqlParameter("@Sitting", data.Sitting), _
        New SqlParameter("@OlevelSubjectID", data.OLevelSubjectID), _
        New SqlParameter("@Grade", data.Grade)}
        Try
            'Modify O Level Result 
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateOLevelResult", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function

    ''' <summary>
    ''' Deletes O Level Result from the database
    ''' </summary>
    ''' <param name="OLevelResultID"></param>
    ''' <remarks>It deletes O Level Result record from the database </remarks>
    Public Function DeleteOLevelResult(ByVal OLevelResultID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@OLevelResultID", OLevelResultID)}
        Try
            'Delete O Level Result
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteOLevelResult", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Fetches all Student's O Level Result to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllStudentOLevelResult(ByVal RegNo As String) As DataSet
        'Holds O Level Result Data
        Dim OLevelResult As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNo", RegNo)}
        Try
            'Fetch all O Level Result.
            OLevelResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllStudentOLevelResult", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched O Level Result
        Return OLevelResult
    End Function

    ''' <summary>
    ''' Fetches all Student's First siting O Level Result to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindStudentFirstOLevelResult(ByVal RegNo As String) As DataSet
        'Holds O Level Result Data
        Dim OLevelResult As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNo", RegNo)}
        Try
            'Fetch all O Level Result.
            OLevelResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindStudentFirstOLevelResult", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched O Level Result
        Return OLevelResult
    End Function

    ''' <summary>
    ''' Fetches all Student's Second siting O Level Result to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindStudentSecondOLevelResult(ByVal RegNo As String) As DataSet
        'Holds O Level Result Data
        Dim OLevelResult As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNo", RegNo)}
        Try
            'Fetch all O Level Result.
            OLevelResult = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindStudentSecondOLevelResult", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched O Level Result
        Return OLevelResult
    End Function

    ''' <summary>
    ''' Fetches all O Level Exams Year fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllOLevelExamsYear() As DataSet
        'Holds O Level Exams Year Data
        Dim OLevelExamsYear As DataSet = New DataSet
        Try
            'Fetch all O Level Exams Year.
            OLevelExamsYear = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllOLevelExamsYear")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched O Level Exams Year
        Return OLevelExamsYear
    End Function

    ''' <summary>
    ''' Creates a O Level Exam Year
    ''' </summary>
    ''' <param name="year"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates OLevelExamYearData using year</remarks>
    Public Function CreateOLevelExamsYear(ByVal year As OLevelResultData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@OLevelExamsYear", year.OLevelExamsYear)}
        Try
            'Create OLevelExamsYear data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateOLevelExamsYear", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Deletes O Level Exam Year from the database
    ''' </summary>
    ''' <param name="OLevelExamsYearID"></param>
    ''' <remarks>It deletes OLevel Exams Year record from the database </remarks>
    Public Function DeleteOLevelExamsYear(ByVal OLevelExamsYearID As Integer) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@OLevelExamsYearID", OLevelExamsYearID)}
        Try
            'Delete OLevelExamsYear data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteOLevelExamsYear", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Updates O Level Exams Year Data
    ''' </summary>
    ''' <param name="year"></param>
    ''' <remarks>It updates the database using OLevelExamYearData</remarks>
    Public Function UpdateOLevelExamsYear(ByVal year As OLevelResultData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@OLevelExamsYearID", year.OLevelExamsYearID), _
        New SqlParameter("@OLevelExamsYear", year.OLevelExamsYear)}
        Try
            'Modify Department data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateOLevelExamsYear", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it
            AppException.LogError(ex.Message)
            Return 0
        End Try

    End Function
    ''' <summary>
    ''' Finds O Level Exams Year By ID
    ''' </summary>
    ''' <param name="OLevelExamsYearID"></param>
    ''' <returns>OLevelExamYearData</returns>
    ''' <remarks>It takes OLevelExamsYearID and returns OLevelExamYearData </remarks>
    Public Function FindOLevelExamsYearByID(ByVal OLevelExamsYearID As Integer) As OLevelResultData
        Dim year As OLevelResultData = New OLevelResultData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@OLevelExamsYearID", OLevelExamsYearID)}
        Try
            'Fetch item based on OLevelExamsYearID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindOLevelExamsYearByID", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        year.OLevelExamsYearID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        year.OLevelExamsYear = row(1)
                    End If

                Next
                'Return OLevelExamsYear data.
                Return year
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
    ''' Finds OLevelSubject by SubjectID
    ''' </summary>
    ''' <param name="RegNo"></param>
    ''' <returns>OLevelResultData</returns>
    ''' <remarks>It takes RegNo and returns OLevelResultData </remarks>
    Public Function FindStudentFirstOLevelResultbyid(ByVal RegNo As Integer) As OLevelResultData
        Dim data As OLevelResultData = New OLevelResultData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNo", RegNo)}
        Try
            'Fetch item based on SubjectID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStudentFirstOLevelResult", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    data.OLevelSubjectID = row(0)
                    If Not IsDBNull(row(1)) Then
                        data.RegNo = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        data.ExamsBodyID = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        data.ExamsBodyName = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        data.ExamsMonth = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        data.ExamsYear = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        data.Sitting = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        data.OlevelSubject1 = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        data.OlevelSubject2 = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        data.OlevelSubject3 = row(9)
                    End If
                    If Not IsDBNull(row(10)) Then
                        data.OlevelSubject4 = row(10)
                    End If
                    If Not IsDBNull(row(11)) Then
                        data.OlevelSubject5 = row(11)
                    End If
                    If Not IsDBNull(row(12)) Then
                        data.OlevelSubject6 = row(12)
                    End If
                    If Not IsDBNull(row(13)) Then
                        data.OlevelSubject7 = row(13)
                    End If
                    If Not IsDBNull(row(14)) Then
                        data.OlevelSubject8 = row(14)
                    End If
                    If Not IsDBNull(row(15)) Then
                        data.OlevelSubject9 = row(15)
                    End If
                    If Not IsDBNull(row(16)) Then
                        data.Grade1 = row(16)
                    End If
                    If Not IsDBNull(row(17)) Then
                        data.Grade2 = row(17)
                    End If
                    If Not IsDBNull(row(18)) Then
                        data.Grade3 = row(18)
                    End If
                    If Not IsDBNull(row(19)) Then
                        data.Grade4 = row(19)
                    End If
                    If Not IsDBNull(row(20)) Then
                        data.Grade5 = row(20)
                    End If
                    If Not IsDBNull(row(21)) Then
                        data.Grade6 = row(21)
                    End If
                    If Not IsDBNull(row(22)) Then
                        data.Grade7 = row(22)
                    End If
                    If Not IsDBNull(row(23)) Then
                        data.Grade8 = row(23)
                    End If
                    If Not IsDBNull(row(24)) Then
                        data.Grade9 = row(24)
                    End If

                Next
                'Return Subject data.
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
    ''' Finds OLevelSubject by SubjectID
    ''' </summary>
    ''' <param name="RegNo"></param>
    ''' <returns>OLevelResultData</returns>
    ''' <remarks>It takes RegNo and returns OLevelResultData </remarks>
    Public Function FindStudentSecondOLevelResultid(ByVal RegNo As Integer) As OLevelResultData
        Dim data As OLevelResultData = New OLevelResultData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNo", RegNo)}
        Try
            'Fetch item based on SubjectID
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindStudentSecondOLevelResult", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data
            If dt.Rows.Count > 0 Then

                For Each row As DataRow In dt.Rows
                    data.OLevelSubjectID = row(0)
                    If Not IsDBNull(row(1)) Then
                        data.RegNo = row(1)
                    End If
                    If Not IsDBNull(row(2)) Then
                        data.ExamsBodyID = row(2)
                    End If
                    If Not IsDBNull(row(3)) Then
                        data.ExamsBodyName = row(3)
                    End If
                    If Not IsDBNull(row(4)) Then
                        data.ExamsMonth = row(4)
                    End If
                    If Not IsDBNull(row(5)) Then
                        data.ExamsYear = row(5)
                    End If
                    If Not IsDBNull(row(6)) Then
                        data.Sitting = row(6)
                    End If
                    If Not IsDBNull(row(7)) Then
                        data.OlevelSubject1 = row(7)
                    End If
                    If Not IsDBNull(row(8)) Then
                        data.OlevelSubject2 = row(8)
                    End If
                    If Not IsDBNull(row(9)) Then
                        data.OlevelSubject3 = row(9)
                    End If
                    If Not IsDBNull(row(10)) Then
                        data.OlevelSubject4 = row(10)
                    End If
                    If Not IsDBNull(row(11)) Then
                        data.OlevelSubject5 = row(11)
                    End If
                    If Not IsDBNull(row(12)) Then
                        data.OlevelSubject6 = row(12)
                    End If
                    If Not IsDBNull(row(13)) Then
                        data.OlevelSubject7 = row(13)
                    End If
                    If Not IsDBNull(row(14)) Then
                        data.OlevelSubject8 = row(14)
                    End If
                    If Not IsDBNull(row(15)) Then
                        data.OlevelSubject9 = row(15)
                    End If
                    If Not IsDBNull(row(16)) Then
                        data.Grade1 = row(16)
                    End If
                    If Not IsDBNull(row(17)) Then
                        data.Grade2 = row(17)
                    End If
                    If Not IsDBNull(row(18)) Then
                        data.Grade3 = row(18)
                    End If
                    If Not IsDBNull(row(19)) Then
                        data.Grade4 = row(19)
                    End If
                    If Not IsDBNull(row(20)) Then
                        data.Grade5 = row(20)
                    End If
                    If Not IsDBNull(row(21)) Then
                        data.Grade6 = row(21)
                    End If
                    If Not IsDBNull(row(22)) Then
                        data.Grade7 = row(22)
                    End If
                    If Not IsDBNull(row(23)) Then
                        data.Grade8 = row(23)
                    End If
                    If Not IsDBNull(row(24)) Then
                        data.Grade9 = row(24)
                    End If

                Next
                'Return Subject data.
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


End Class
