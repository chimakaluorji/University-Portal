''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Chima kalu-orji
'' Date: 10-06-2009
'' This Class manages Academic Courses.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient

Public Class HostelApplicationFormDAL
    Inherits DataAccessBase

    Public Sub New()
        'Initialise the connection string
        MyBase.New()
    End Sub
    ''' <summary>
    ''' Upload Result
    ''' </summary>
    ''' <param name="HostelApplication"></param>
    ''' <remarks>It Upload Result into the database using UploadResultData</remarks>
    Public Function CreateHostelApplication(ByVal HostelApplication As HostelApplicationFormData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", HostelApplication.RegNumber), _
        New SqlParameter("@LevelID", HostelApplication.LevelID), _
        New SqlParameter("@SemesterID", HostelApplication.SemesterID), _
        New SqlParameter("@SessionID", HostelApplication.SessionID), _
        New SqlParameter("@RoomNameID", HostelApplication.RoomNameID), _
        New SqlParameter("@CBoxInclusive", HostelApplication.CBoxInclusive), _
        New SqlParameter("@CBoxRoommate", HostelApplication.CBoxRoommate), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByRegNo", HostelApplication.CreatedByRegNo), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}
        'Assigning value to the return value
        params(10).Direction = ParameterDirection.Output
        params(11).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_CreateHostelReservationApplication", params)
        'Populate Error Code
        RetVal(0) = params(10).Value
        'Populate Error Hint
        RetVal(1) = params(11).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(10).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(11).Value
        '    Return RetVal
        'End Try
    End Function
    ''' <summary>
    ''' Finds Hostel Application Details by RegNum
    ''' </summary>
    ''' <param name="RegNum"></param>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes RegNum and returns HostelApplicationFormData </remarks>
    Public Function FindAllHostelApplicationByRegNum(ByVal RegNum As String) As HostelApplicationFormData
        Dim HostelApplication As HostelApplicationFormData = New HostelApplicationFormData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNum)}
        'Try
        'Fetch item based on CourseID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllHostelApplicationByRegNum", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    HostelApplication.RegNumber = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    HostelApplication.Surname = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    HostelApplication.FirstName = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    HostelApplication.MiddleName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    HostelApplication.Gender = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    HostelApplication.NationalityID = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    HostelApplication.StateID = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    HostelApplication.LGAID = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    HostelApplication.HomeAddress = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    HostelApplication.PhoneNumber = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    HostelApplication.Email = row(10)
                End If
                If Not IsDBNull(row(11)) Then
                    HostelApplication.DeptID = row(11)
                End If
                If Not IsDBNull(row(12)) Then
                    HostelApplication.ProgrammeID = row(12)
                End If
                If Not IsDBNull(row(13)) Then
                    HostelApplication.LevelID = row(13)
                End If
                If Not IsDBNull(row(14)) Then
                    HostelApplication.SessionID = row(14)
                End If
                If Not IsDBNull(row(15)) Then
                    HostelApplication.Accomodation = row(15)
                End If
                If Not IsDBNull(row(16)) Then
                    HostelApplication.TypeOfAccomodation = row(16)
                End If
                If Not IsDBNull(row(17)) Then
                    HostelApplication.NameOfHostel = row(17)
                End If
                If Not IsDBNull(row(18)) Then
                    HostelApplication.DescriptionOfRoom = row(18)
                End If
                If Not IsDBNull(row(19)) Then
                    HostelApplication.FloorName = row(19)
                End If
                If Not IsDBNull(row(20)) Then
                    HostelApplication.SubscriptionPlan = row(20)
                End If
                If Not IsDBNull(row(21)) Then
                    HostelApplication.Amount = row(21)
                End If
                If Not IsDBNull(row(22)) Then
                    HostelApplication.HostelSubscriptionID = row(22)
                End If
                If Not IsDBNull(row(23)) Then
                    HostelApplication.DateTime = row(23)
                End If
                If Not IsDBNull(row(24)) Then
                    HostelApplication.Message = row(24)
                End If
                If Not IsDBNull(row(25)) Then
                    HostelApplication.Dept = row(25)
                End If
                If Not IsDBNull(row(26)) Then
                    HostelApplication.Programme = row(26)
                End If
                If Not IsDBNull(row(27)) Then
                    HostelApplication.Session = row(27)
                End If
                If Not IsDBNull(row(28)) Then
                    HostelApplication.Level = row(28)
                End If
                If Not IsDBNull(row(29)) Then
                    HostelApplication.Nationality = row(29)
                End If
                If Not IsDBNull(row(30)) Then
                    HostelApplication.State = row(30)
                End If
                If Not IsDBNull(row(31)) Then
                    HostelApplication.LGA = row(31)
                End If
                If Not IsDBNull(row(32)) Then
                    HostelApplication.Approved = row(32)
                End If
                If Not IsDBNull(row(33)) Then
                    HostelApplication.Comment = row(33)
                End If
            Next
            'Return HostelApplication data.
            Return HostelApplication
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
    ''' Upload Result
    ''' </summary>
    ''' <param name="HostelApplication"></param>
    ''' <remarks>It Upload Result into the database using UploadResultData</remarks>
    Public Function UpdateHostelApplication(ByVal HostelApplication As HostelApplicationFormData) As String()
        'Declare and initialize data access parameters
        Dim RetVal() As String = {"", ""}

        Dim params() As SqlParameter = _
        {New SqlParameter("@RegNumber", HostelApplication.RegNumber), _
        New SqlParameter("@LevelID", HostelApplication.LevelID), _
        New SqlParameter("@SemesterID", HostelApplication.SemesterID), _
        New SqlParameter("@SessionID", HostelApplication.SessionID), _
        New SqlParameter("@RoomNameID", HostelApplication.RoomNameID), _
        New SqlParameter("@CBoxInclusive", HostelApplication.CBoxInclusive), _
        New SqlParameter("@CBoxRoommate", HostelApplication.CBoxRoommate), _
        New SqlParameter("@LogTxnFlag", LogTxnFlag), _
        New SqlParameter("@LogErrorFlag", LogErrorFlag), _
        New SqlParameter("@CreatedByRegNo", HostelApplication.CreatedByRegNo), _
        New SqlParameter("@retcode", SqlDbType.Int, 4), _
        New SqlParameter("@ErrorHint", SqlDbType.VarChar, 250)}
        'Assigning value to the return value
        params(10).Direction = ParameterDirection.Output
        params(11).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "SP_UpdateHostelReservationApplication", params)
        'Populate Error Code
        RetVal(0) = params(10).Value
        'Populate Error Hint
        RetVal(1) = params(11).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(21).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(22).Value
        '    Return RetVal
        'End Try
    End Function
    ''' <summary>
    ''' Finds Hostel Application Details by RegNum
    ''' </summary>
    ''' <param name="RegNum"></param>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes RegNum and returns HostelApplicationFormData </remarks>
    Public Function FindAllHostelApplicationByRegNumber(ByVal RegNum As String) As HostelApplicationFormData
        Dim HostelApplication As HostelApplicationFormData = New HostelApplicationFormData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNum)}
        'Try
        'Fetch item based on CourseID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllHostelApplicationByRegNumber", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    HostelApplication.RegNumber = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    HostelApplication.LevelID = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    HostelApplication.SemesterID = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    HostelApplication.SessionID = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    HostelApplication.RoomNameID = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    HostelApplication.DateTime = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    HostelApplication.Amount = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    HostelApplication.Message = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    HostelApplication.Session = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    HostelApplication.Level = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    HostelApplication.Approved = row(10)
                End If
                If Not IsDBNull(row(11)) Then
                    HostelApplication.Comment = row(11)
                End If
                If Not IsDBNull(row(12)) Then
                    HostelApplication.DesiredHostelResident = row(12)
                End If
                If Not IsDBNull(row(13)) Then
                    HostelApplication.HostelName = row(13)
                End If
                If Not IsDBNull(row(14)) Then
                    HostelApplication.Description = row(14)
                End If
                If Not IsDBNull(row(15)) Then
                    HostelApplication.FloorPosition = row(15)
                End If
                If Not IsDBNull(row(16)) Then
                    HostelApplication.RoomName = row(16)
                End If
                If Not IsDBNull(row(17)) Then
                    HostelApplication.SubscriptionPlan = row(17)
                End If
                If Not IsDBNull(row(18)) Then
                    HostelApplication.Semester = row(18)
                End If
            Next
            'Return HostelApplication data.
            Return HostelApplication
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
    ''' Creates a Description
    ''' </summary>
    ''' <param name="Description"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates HostelApplicationFormData using Description</remarks>
    Public Function CreateDescription(ByVal Description As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", Description.SubscriptionPlanID), _
         New SqlParameter("@DesiredHostelResidentID", Description.DesiredHostelResidentID), _
        New SqlParameter("@HostelNameID", Description.HostelNameID), _
        New SqlParameter("@Description", Description.Description)}
        Try
            'Create Description data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateDescription", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Update a Description
    ''' </summary>
    ''' <param name="Description"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It Update HostelApplicationFormData using Description</remarks>
    Public Function UpdateDescription(ByVal Description As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", Description.SubscriptionPlanID), _
        New SqlParameter("@DesiredHostelResidentID", Description.DesiredHostelResidentID), _
        New SqlParameter("@HostelNameID", Description.HostelNameID), _
        New SqlParameter("@DescriptionID", Description.DescriptionID), _
        New SqlParameter("@Description", Description.Description)}
        Try
            'Update Description data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateDescription", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Delete a Description
    ''' </summary>
    ''' <param name="Description"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It Delete HostelApplicationFormData using Description</remarks>
    Public Function DeleteDescription(ByVal Description As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", Description.SubscriptionPlanID)}
        Try
            'Delete Description data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteDescription", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a FloorPosition
    ''' </summary>
    ''' <param name="FloorPosition"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates HostelApplicationFormData using FloorPosition</remarks>
    Public Function CreateFloorPosition(ByVal FloorPosition As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", FloorPosition.SubscriptionPlanID), _
         New SqlParameter("@DesiredHostelResidentID", FloorPosition.DesiredHostelResidentID), _
        New SqlParameter("@HostelNameID", FloorPosition.HostelNameID), _
        New SqlParameter("@DescriptionID", FloorPosition.DescriptionID), _
        New SqlParameter("@FloorPosition", FloorPosition.FloorPosition)}
        Try
            'Create FloorPosition data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateFloorPosition", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Update a FloorPosition
    ''' </summary>
    ''' <param name="FloorPosition"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It Update HostelApplicationFormData using FloorPosition</remarks>
    Public Function UpdateFloorPosition(ByVal FloorPosition As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", FloorPosition.SubscriptionPlanID), _
        New SqlParameter("@DesiredHostelResidentID", FloorPosition.DesiredHostelResidentID), _
        New SqlParameter("@HostelNameID", FloorPosition.HostelNameID), _
        New SqlParameter("@DescriptionID", FloorPosition.DescriptionID), _
        New SqlParameter("@FloorPositionID", FloorPosition.FloorPositionID), _
        New SqlParameter("@FloorPosition", FloorPosition.FloorPosition)}
        Try
            'Update FloorPosition data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateFloorPosition", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Delete a FloorPosition
    ''' </summary>
    ''' <param name="FloorPosition"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It Delete HostelApplicationFormData using FloorPosition</remarks>
    Public Function DeleteFloorPosition(ByVal FloorPosition As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", FloorPosition.SubscriptionPlanID)}
        Try
            'Delete FloorPosition data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteFloorPosition", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a RoomName
    ''' </summary>
    ''' <param name="RoomName"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates HostelApplicationFormData using RoomName</remarks>
    Public Function CreateRoomName(ByVal RoomName As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", RoomName.SubscriptionPlanID), _
         New SqlParameter("@DesiredHostelResidentID", RoomName.DesiredHostelResidentID), _
        New SqlParameter("@HostelNameID", RoomName.HostelNameID), _
        New SqlParameter("@DescriptionID", RoomName.DescriptionID), _
        New SqlParameter("@FloorPositionID", RoomName.FloorPositionID), _
        New SqlParameter("@RoomName", RoomName.RoomName), _
        New SqlParameter("@Amount", RoomName.Amount)}
        Try
            'Create RoomName data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateRoomName", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Update a RoomName
    ''' </summary>
    ''' <param name="RoomName"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates HostelApplicationFormData using RoomName</remarks>
    Public Function UpdateRoomName(ByVal RoomName As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", RoomName.SubscriptionPlanID), _
        New SqlParameter("@DesiredHostelResidentID", RoomName.DesiredHostelResidentID), _
        New SqlParameter("@HostelNameID", RoomName.HostelNameID), _
        New SqlParameter("@DescriptionID", RoomName.DescriptionID), _
        New SqlParameter("@FloorPositionID", RoomName.FloorPositionID), _
        New SqlParameter("@RoomNameID", RoomName.RoomNameID), _
        New SqlParameter("@RoomName", RoomName.RoomName), _
        New SqlParameter("@Amount", RoomName.Amount)}
        Try
            'Update RoomName data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateRoomName", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Delete a RoomName
    ''' </summary>
    ''' <param name="RoomName"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It Delete HostelApplicationFormData using RoomName</remarks>
    Public Function DeleteRoomName(ByVal RoomName As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", RoomName.SubscriptionPlanID)}
        Try
            'Delete RoomName data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteRoomName", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a HostelName
    ''' </summary>
    ''' <param name="HostelName"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates HostelApplicationFormData using DesiredHostelResident</remarks>
    Public Function CreateHostelName(ByVal HostelName As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", HostelName.SubscriptionPlanID), _
         New SqlParameter("@DesiredHostelResidentID", HostelName.DesiredHostelResidentID), _
         New SqlParameter("@HostelName", HostelName.HostelName)}
        Try
            'Create DesiredHostelResident data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateHostelName", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Update a HostelName
    ''' </summary>
    ''' <param name="HostelName"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It Update HostelApplicationFormData using DesiredHostelResident</remarks>
    Public Function UpdateHostelName(ByVal HostelName As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", HostelName.SubscriptionPlanID), _
         New SqlParameter("@DesiredHostelResidentID", HostelName.DesiredHostelResidentID), _
         New SqlParameter("@HostelNameID", HostelName.HostelNameID), _
         New SqlParameter("@HostelName", HostelName.HostelName)}
        Try
            'Update DesiredHostelResident data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateHostelName", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Delete a HostelName
    ''' </summary>
    ''' <param name="HostelName"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It Update HostelApplicationFormData using DesiredHostelResident</remarks>
    Public Function DeleteHostelName(ByVal HostelName As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", HostelName.SubscriptionPlanID)}
        Try
            'Delete DesiredHostelResident data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteHostelName", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a Desired Hostel Resident
    ''' </summary>
    ''' <param name="DesiredHostelResident"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates HostelApplicationFormData using DesiredHostelResident</remarks>
    Public Function CreateDesiredHostelResident(ByVal DesiredHostelResident As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", DesiredHostelResident.SubscriptionPlanID), _
        New SqlParameter("@DesiredHostelResident", DesiredHostelResident.DesiredHostelResident)}
        Try
            'Create DesiredHostelResident data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateDesiredHostelResident", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Update a Desired Hostel Resident
    ''' </summary>
    ''' <param name="DesiredHostelResident"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It Update HostelApplicationFormData using DesiredHostelResident</remarks>
    Public Function UpdateDesiredHostelResident(ByVal DesiredHostelResident As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", DesiredHostelResident.SubscriptionPlanID), _
         New SqlParameter("@DesiredHostelResidentID", DesiredHostelResident.DesiredHostelResidentID), _
        New SqlParameter("@DesiredHostelResident", DesiredHostelResident.DesiredHostelResident)}
        Try
            'Update DesiredHostelResident data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateDesiredHostelResident", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Delete a Desired Hostel Resident
    ''' </summary>
    ''' <param name="DesiredHostelResident"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It Delete HostelApplicationFormData using DesiredHostelResident</remarks>
    Public Function DeleteDesiredHostelResident(ByVal DesiredHostelResident As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", DesiredHostelResident.SubscriptionPlanID)}
        Try
            'Delete DesiredHostelResident data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteDesiredHostelResident", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Creates a Subscription Plan
    ''' </summary>
    ''' <param name="SubscriptionPlan"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It creates HostelApplicationFormData using SubscriptionPlan</remarks>
    Public Function CreateSubscriptionPlan(ByVal SubscriptionPlan As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlan", SubscriptionPlan.SubscriptionPlan)}
        Try
            'Create SubscriptionPlan data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "CreateSubscriptionPlan", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Update a Subscription Plan
    ''' </summary>
    ''' <param name="SubscriptionPlan"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It update HostelApplicationFormData using SubscriptionPlan</remarks>
    Public Function UpdateSubscriptionPlan(ByVal SubscriptionPlan As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", SubscriptionPlan.SubscriptionPlanID), _
        New SqlParameter("@SubscriptionPlan", SubscriptionPlan.SubscriptionPlan)}
        Try
            'update SubscriptionPlan data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "UpdateSubscriptionPlan", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Delete a Subscription Plan
    ''' </summary>
    ''' <param name="SubscriptionPlan"></param>
    ''' <returns>Integer</returns>
    ''' <remarks>It Delete HostelApplicationFormData using SubscriptionPlan</remarks>
    Public Function DeleteSubscriptionPlan(ByVal SubscriptionPlan As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", SubscriptionPlan.SubscriptionPlanID)}
        Try
            'Delete SubscriptionPlan data
            SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "DeleteSubscriptionPlan", params)
            Return 1
        Catch ex As Exception
            'If error occurs, log it and return 0
            AppException.LogError(ex.Message)
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Fetches all DesiredHostelResident to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllDesiredHostelResident() As DataSet
        'Holds DesiredHostelResident Data
        Dim DesiredHostelResident As DataSet = New DataSet
        Try
            'Fetch all DesiredHostelResident.
            DesiredHostelResident = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllDesiredHostelResident")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched DesiredHostelResident data
        Return DesiredHostelResident
    End Function
    ''' <summary>
    ''' Fetches all Description to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllDescription() As DataSet
        'Holds Description Data
        Dim Description As DataSet = New DataSet
        Try
            'Fetch all Description.
            Description = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllDescription")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Description data
        Return Description
    End Function
    ''' <summary>
    ''' Fetches all SubscriptionPlan to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllSubscriptionPlan() As DataSet
        'Holds SubscriptionPlan Data
        Dim SubscriptionPlan As DataSet = New DataSet
        Try
            'Fetch all SubscriptionPlan.
            SubscriptionPlan = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllSubscriptionPlan")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched SubscriptionPlan data
        Return SubscriptionPlan
    End Function
    ''' <summary>
    ''' Fetches all SubscriptionPlan to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllDesiredHostelResidentBySubscriptionPlanID(ByVal SubscriptionPlanID As Integer) As DataSet
        'Holds SubscriptionPlan Data
        Dim SubscriptionPlan As DataSet = New DataSet
        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlanID", SubscriptionPlanID)}
        Try
            'Fetch all SubscriptionPlan.
            SubscriptionPlan = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllDesiredHostelResidentBySubscriptionPlanID", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched SubscriptionPlan data
        Return SubscriptionPlan
    End Function
    ''' <summary>
    ''' Fetches all Description to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllDescriptionByDesiredHostelResidentID(ByVal DesiredHostelResidentID As Integer) As DataSet
        'Holds Description Data
        Dim Description As DataSet = New DataSet

        'Declare and initialize data access parameters
        Dim params() As SqlParameter = _
        {New SqlParameter("@DesiredHostelResidentID", DesiredHostelResidentID)}

        Try
            'Fetch all Description.
            Description = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllDescriptionByDesiredHostelResidentID", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched Description data
        Return Description
    End Function
    ''' <summary>
    ''' Finds Hostel Application Details by RegNum
    ''' </summary>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes RegNum and returns HostelApplicationFormData </remarks>
    Public Function GetAllSubscription() As HostelApplicationFormData
        Dim HostelApplication As HostelApplicationFormData = New HostelApplicationFormData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        'Try
        'Fetch item based on CourseID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "GetAllSubscription")
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    HostelApplication.SubscriptionPlan = row(0)
                End If
            Next
            'Return HostelApplication data.
            Return HostelApplication
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
    ''' Finds Hostel Application Details by RegNum
    ''' </summary>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes RegNum and returns HostelApplicationFormData </remarks>
    Public Function FindAllHostelApplicationSubscription() As HostelApplicationFormData
        Dim HostelApplication As HostelApplicationFormData = New HostelApplicationFormData
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        'Try
        'Fetch item based on CourseID
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllHostelApplicationSubscription")
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    HostelApplication.RegNumber = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    HostelApplication.Surname = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    HostelApplication.FirstName = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    HostelApplication.MiddleName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    HostelApplication.Gender = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    HostelApplication.NationalityID = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    HostelApplication.StateID = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    HostelApplication.LGAID = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    HostelApplication.HomeAddress = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    HostelApplication.PhoneNumber = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    HostelApplication.Email = row(10)
                End If
                If Not IsDBNull(row(11)) Then
                    HostelApplication.DeptID = row(11)
                End If
                If Not IsDBNull(row(12)) Then
                    HostelApplication.ProgrammeID = row(12)
                End If
                If Not IsDBNull(row(13)) Then
                    HostelApplication.LevelID = row(13)
                End If
                If Not IsDBNull(row(14)) Then
                    HostelApplication.SessionID = row(14)
                End If
                If Not IsDBNull(row(15)) Then
                    HostelApplication.Accomodation = row(15)
                End If
                If Not IsDBNull(row(16)) Then
                    HostelApplication.TypeOfAccomodation = row(16)
                End If
                If Not IsDBNull(row(17)) Then
                    HostelApplication.NameOfHostel = row(17)
                End If
                If Not IsDBNull(row(18)) Then
                    HostelApplication.DescriptionOfRoom = row(18)
                End If
                If Not IsDBNull(row(19)) Then
                    HostelApplication.FloorName = row(19)
                End If
                If Not IsDBNull(row(20)) Then
                    HostelApplication.SubscriptionPlan = row(20)
                End If
                If Not IsDBNull(row(21)) Then
                    HostelApplication.Amount = row(21)
                End If
                If Not IsDBNull(row(22)) Then
                    HostelApplication.HostelSubscriptionID = row(22)
                End If
                If Not IsDBNull(row(23)) Then
                    HostelApplication.DateTime = row(23)
                End If
            Next

            'Return HostelApplication data.
            Return HostelApplication
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
    ''' Fetches all HostelApplication to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllHostelApplication() As DataSet
        'Holds HostelApplication Data
        Dim HostelApplication As DataSet = New DataSet
        Try
            'Fetch all HostelApplication.
            HostelApplication = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllHostelApplication")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched HostelApplication data
        Return HostelApplication
    End Function
    ''' <summary>
    ''' Fetches all ApprovedAccomodation to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllApprovedAccomodationSpecification() As DataSet
        'Holds HostelApplication Data
        Dim ApprovedAccomodation As DataSet = New DataSet
        Try
            'Fetch all ApprovedAccomodation.
            ApprovedAccomodation = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllApprovedAccomodationSpecification")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched ApprovedAccomodation data
        Return ApprovedAccomodation
    End Function
    ''' <summary>
    ''' Fetches all ApprovedAccomodation to fill a dataset
    ''' </summary>
    ''' <returns>dataset</returns>
    ''' <remarks>it returns a dataset</remarks>
    Public Function FindAllNonApprovedAccomodationSpecification() As DataSet
        'Holds HostelApplication Data
        Dim ApprovedAccomodation As DataSet = New DataSet
        Try
            'Fetch all ApprovedAccomodation.
            ApprovedAccomodation = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllNonApprovedAccomodationSpecification")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched ApprovedAccomodation data
        Return ApprovedAccomodation
    End Function
    ''' <summary>
    ''' Approve Hostel Application
    ''' </summary>
    ''' <remarks>This store proc Approve Hostel Application</remarks>
    Public Function ApproveHostelApplication(ByVal CTextApprove As String, ByVal CTextComment As String, ByVal RegNumber As String) As Integer
        'Declare and initialize data access parameters

        Dim params() As SqlParameter = _
        {New SqlParameter("@CTextComment", CTextComment), _
        New SqlParameter("@CTextApprove", CTextApprove), _
        New SqlParameter("@RegNumber", RegNumber)}

        'Try
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "ApproveHostelApplication", params)

        Return 1
        'Catch ex As Exception
        '    Return 0
        'End Try


    End Function
    ''' <summary>
    ''' Finds Hostel Application Details by RegNum
    ''' </summary>
    ''' <param name="RegNum"></param>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes RegNum and returns HostelApplicationFormData </remarks>
    Public Function GetAllHostelApplicationByRegNum(ByVal RegNum As String) As DataSet
        'Holds HostelApplication Data
        Dim ApprovedAccomodation As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNum)}

        Try
            'Fetch all ApprovedAccomodation.
            ApprovedAccomodation = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllHostelApplicationByRegNumber", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched ApprovedAccomodation data
        Return ApprovedAccomodation
    End Function
    Public Function FindAllTreeView() As DataSet
        'Holds HostelApplication Data
        Dim HostelApplication As DataSet = New DataSet
        Try
            'Fetch all HostelApplication.
            HostelApplication = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindAllTreeViewForHostel")
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched HostelApplication data
        Return HostelApplication

    End Function
    Public Function PopulateTreeView() As DataSet
        'Declaring the dataset
        Dim TreeViewData As DataSet
        TreeViewData = FindAllTreeView()

        'Add Realation using Relation Attribute
        TreeViewData.Relations.Add(0, TreeViewData.Tables(0).Columns("SubscriptionPlanID"), TreeViewData.Tables(1).Columns("SubscriptionPlanID"))
        TreeViewData.Relations.Add(1, TreeViewData.Tables(1).Columns("DesiredHostelResidentID"), TreeViewData.Tables(2).Columns("DesiredHostelResidentID"))
        TreeViewData.Relations.Add(2, TreeViewData.Tables(2).Columns("HostelNameID"), TreeViewData.Tables(3).Columns("HostelNameID"))
        TreeViewData.Relations.Add(3, TreeViewData.Tables(3).Columns("DescriptionID"), TreeViewData.Tables(4).Columns("DescriptionID"))
        TreeViewData.Relations.Add(4, TreeViewData.Tables(4).Columns("FloorPositionID"), TreeViewData.Tables(5).Columns("FloorPositionID"))
        Return TreeViewData
    End Function
    ''' <summary>
    ''' Finds SelectedNode Details by SelectedNode
    ''' </summary>
    ''' <returns>StringArray</returns>
    ''' <remarks>It takes SelectedNode and returns StringArray </remarks>
    Public Function FindSelectedNodeBySelectedNode(ByVal SelectedNode As String) As String
        'Holds StringArray Data
        Dim RetValue As String

        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SelectedNode", SelectedNode), _
                                        New SqlParameter("@Subscription", SqlDbType.VarChar, 250)}
        params(1).Direction = ParameterDirection.Output
        
        'Try
        'Fetch item based on SelectedNode
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "FindSelectedNodeBySelectedNode", params)
        RetValue = params(1).Value

        'Return StringArray data.
        Return RetValue

        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return Nothing
        'End Try
    End Function
    ''' <summary>
    ''' Finds Hostel Subscription by SelectedNode
    ''' </summary>
    ''' <param name="SelectedNode"></param>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes SelectedNode and returns HostelApplicationFormData </remarks>
    Public Function FindHostelSubscriptionBySelectedNode(ByVal SelectedNode As String) As HostelApplicationFormData 'String()
        'Dim HostelApplication As String() = {"", ""}
        Dim HostelApplication As HostelApplicationFormData = New HostelApplicationFormData
        HostelApplication.ReturnedValue = ""
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SelectedNode", SelectedNode)}
        Try
            'Fetch item based on SubscriptionPlan
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindHostelSubscriptionBySelectedNode", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        HostelApplication.SubscriptionPlanID = row(0)
                    End If
                    If Not IsDBNull(row(1)) Then
                        HostelApplication.SubscriptionPlan = row(1)
                    End If
                Next
                'Return HostelApplication data.
                Return HostelApplication
            Else
                Return HostelApplication
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return HostelApplication
        End Try
    End Function
    ''' <summary>
    ''' Finds Hostel DesiredHostel by SelectedNode
    ''' </summary>
    ''' <param name="SelectedNode"></param>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes SelectedNode and returns HostelApplicationFormData </remarks>
    Public Function FindDesiredHostelBySelectedNode(ByVal SelectedNode As String) As HostelApplicationFormData
        Dim HostelApplication As HostelApplicationFormData = New HostelApplicationFormData
        'HostelApplication.ReturnedValue = ""
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SelectedNode", SelectedNode)}
        'Try
        'Fetch item based on DesiredHostel
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindDesiredHostelBySelectedNode", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    HostelApplication.DesiredHostelResidentID = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    HostelApplication.DesiredHostelResident = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    HostelApplication.SubscriptionPlanID = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    HostelApplication.SubscriptionPlan = row(3)
                End If


            Next
            'Return HostelApplication data.
            Return HostelApplication
        Else
            Return HostelApplication
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return HostelApplication
        'End Try
    End Function
    ''' <summary>
    ''' Finds Hostel HostelName by SelectedNode
    ''' </summary>
    ''' <param name="SelectedNode"></param>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes SelectedNode and returns HostelApplicationFormData </remarks>
    Public Function FindHostelNameBySelectedNode(ByVal SelectedNode As String) As HostelApplicationFormData
        Dim HostelApplication As HostelApplicationFormData = New HostelApplicationFormData
        HostelApplication.ReturnedValue = ""
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SelectedNode", SelectedNode)}
        'Try
        'Fetch item based on HostelName
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindHostelNameBySelectedNode", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    HostelApplication.HostelNameID = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    HostelApplication.HostelName = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    HostelApplication.DesiredHostelResidentID = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    HostelApplication.DesiredHostelResident = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    HostelApplication.SubscriptionPlanID = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    HostelApplication.SubscriptionPlan = row(5)
                End If

            Next
            'Return HostelApplication data.
            Return HostelApplication
        Else
            Return HostelApplication
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return HostelApplication
        'End Try
    End Function
    ''' <summary>
    ''' Finds Hostel HostelName by SelectedNode
    ''' </summary>
    ''' <param name="SelectedNode"></param>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes SelectedNode and returns HostelApplicationFormData </remarks>
    Public Function FindAllDescriptionBySelectedNodeAndHostelNameData(ByVal SelectedNode As String, ByVal SubscriptionID As Integer, ByVal DesiredHostelID As Integer, ByVal HostelNameSecondID As Integer) As HostelApplicationFormData
        Dim HostelApplication As HostelApplicationFormData = New HostelApplicationFormData
        'HostelApplication.ReturnedValue = ""
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SelectedNode", SelectedNode), _
                                        New SqlParameter("@HostelNameID", SubscriptionID), _
                                        New SqlParameter("@DesiredHostelResidentID", DesiredHostelID), _
                                        New SqlParameter("@SubscriptionPlanID", HostelNameSecondID)}
        'Try
        'Fetch item based on Description
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllDescriptionBySelectedNodeAndHostelNameData", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    HostelApplication.DescriptionID = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    HostelApplication.Description = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    HostelApplication.HostelNameID = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    HostelApplication.HostelName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    HostelApplication.DesiredHostelResidentID = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    HostelApplication.DesiredHostelResident = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    HostelApplication.SubscriptionPlanID = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    HostelApplication.SubscriptionPlan = row(7)
                End If

            Next
            'Return HostelApplication data.

            Return HostelApplication
        Else

            Return HostelApplication
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return HostelApplication
        'End Try
    End Function
    ''' <summary>
    ''' Finds Hostel HostelName by SelectedNode
    ''' </summary>
    ''' <param name="SelectedNode"></param>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes SelectedNode and returns HostelApplicationFormData </remarks>
    Public Function FindAllDescriptionBySelectedNode(ByVal SelectedNode As String) As HostelApplicationFormData
        Dim HostelApplication As HostelApplicationFormData = New HostelApplicationFormData
        'HostelApplication.ReturnedValue = ""
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SelectedNode", SelectedNode)}
        'Try
        'Fetch item based on Description
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindAllDescriptionBySelectedNode", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    HostelApplication.Description = row(0)
                End If
            Next
            'Return HostelApplication data.
            Return HostelApplication
        Else
            Return HostelApplication
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return HostelApplication
        'End Try
    End Function
    ''' <summary>
    ''' Finds Hostel HostelName by SelectedNode
    ''' </summary>
    ''' <param name="SelectedNode"></param>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes SelectedNode and returns HostelApplicationFormData </remarks>
    Public Function FindDescriptionBySelectedNode(ByVal SelectedNode As String, ByVal HostelNameData As HostelApplicationFormData) As HostelApplicationFormData
        Dim HostelApplication As HostelApplicationFormData = New HostelApplicationFormData
        HostelApplication.ReturnedValue = ""
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SelectedNode", SelectedNode), _
                                        New SqlParameter("@SubscriptionPlanID", HostelNameData.SubscriptionPlanID), _
                                        New SqlParameter("@DesiredHostelResidentID", HostelNameData.DesiredHostelResidentID), _
                                        New SqlParameter("@HostelNameID", HostelNameData.HostelNameID)}
        'Try
        'Fetch item based on Description
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindDescriptionBySelectedNode", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    HostelApplication.DescriptionID = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    HostelApplication.Description = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    HostelApplication.HostelNameID = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    HostelApplication.HostelName = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    HostelApplication.DesiredHostelResidentID = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    HostelApplication.DesiredHostelResident = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    HostelApplication.SubscriptionPlanID = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    HostelApplication.SubscriptionPlan = row(7)
                End If

            Next
            'Return HostelApplication data.
            Return HostelApplication
        Else
            Return HostelApplication
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return HostelApplication
        'End Try
    End Function
    ''' <summary>
    ''' Finds Hostel HostelName by SelectedNode
    ''' </summary>
    ''' <param name="SelectedNode"></param>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes SelectedNode and returns HostelApplicationFormData </remarks>
    Public Function FindFloorPositionBySelectedNodeAndHostelData(ByVal SelectedNode As String, ByVal AccomodationDescriptionSecondID As Integer, ByVal AccomodationNameID As Integer, ByVal DesiredAccomodationID As Integer, ByVal AccomodationDescriptionID As Integer) As HostelApplicationFormData
        Dim HostelApplication As HostelApplicationFormData = New HostelApplicationFormData
        'HostelApplication.ReturnedValue = ""
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SelectedNode", SelectedNode), _
                                        New SqlParameter("@DescriptionID", AccomodationDescriptionSecondID), _
                                        New SqlParameter("@HostelNameID", AccomodationNameID), _
                                        New SqlParameter("@DesiredHostelResidentID", DesiredAccomodationID), _
                                        New SqlParameter("@SubscriptionPlanID", AccomodationDescriptionID)}
        'Try
        'Fetch item based on Description
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindFloorPositionBySelectedNodeAndHostelData", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    HostelApplication.FloorPositionID = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    HostelApplication.FloorPosition = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    HostelApplication.DescriptionID = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    HostelApplication.Description = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    HostelApplication.HostelNameID = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    HostelApplication.HostelName = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    HostelApplication.DesiredHostelResidentID = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    HostelApplication.DesiredHostelResident = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    HostelApplication.SubscriptionPlanID = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    HostelApplication.SubscriptionPlan = row(9)
                End If

            Next
            'Return HostelApplication data.

            Return HostelApplication
        Else
            Return HostelApplication
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return HostelApplication
        'End Try
    End Function
    ''' <summary>
    ''' Finds Hostel HostelName by SelectedNode
    ''' </summary>
    ''' <param name="SelectedNode"></param>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes SelectedNode and returns HostelApplicationFormData </remarks>
    Public Function FindFloorPositionBySelectedNode(ByVal SelectedNode As String) As HostelApplicationFormData
        Dim HostelApplication As HostelApplicationFormData = New HostelApplicationFormData
        'HostelApplication.ReturnedValue = ""
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SelectedNode", SelectedNode)}
        'Try
        'Fetch item based on Description
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindFloorPositionBySelectedNode", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    HostelApplication.FloorPosition = row(0)
                End If
            Next
            'Return HostelApplication data.

            Return HostelApplication
        Else
            Return HostelApplication

        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return HostelApplication
        'End Try
    End Function
    ''' <summary>
    ''' Finds Hostel HostelName by SelectedNode
    ''' </summary>
    ''' <param name="SelectedNode"></param>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes SelectedNode and returns HostelApplicationFormData </remarks>
    Public Function FindRoomNameBySelectedNodeAndHosetData(ByVal SelectedNode As String, ByVal FloorPositionID As Integer, ByVal AccomodationDescriptionSecondID As Integer, ByVal AccomodationNameID As Integer, ByVal DesiredAccomodationID As Integer, ByVal AccomodationDescriptionID As Integer) As HostelApplicationFormData
        Dim HostelApplication As HostelApplicationFormData = New HostelApplicationFormData
        HostelApplication.ReturnedValue = ""
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SelectedNode", SelectedNode), _
                                        New SqlParameter("@FloorPositionID", FloorPositionID), _
                                        New SqlParameter("@DescriptionID", AccomodationDescriptionSecondID), _
                                        New SqlParameter("@HostelNameID", AccomodationNameID), _
                                        New SqlParameter("@DesiredHostelResidentID", DesiredAccomodationID), _
                                        New SqlParameter("@SubscriptionPlanID", AccomodationDescriptionID)}
        'Try
        'Fetch item based on Description
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindRoomNameBySelectedNodeAndHosetData", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data

        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    HostelApplication.RoomNameID = row(0)
                End If
                If Not IsDBNull(row(1)) Then
                    HostelApplication.RoomName = row(1)
                End If
                If Not IsDBNull(row(2)) Then
                    HostelApplication.FloorPositionID = row(2)
                End If
                If Not IsDBNull(row(3)) Then
                    HostelApplication.FloorPosition = row(3)
                End If
                If Not IsDBNull(row(4)) Then
                    HostelApplication.DescriptionID = row(4)
                End If
                If Not IsDBNull(row(5)) Then
                    HostelApplication.Description = row(5)
                End If
                If Not IsDBNull(row(6)) Then
                    HostelApplication.HostelNameID = row(6)
                End If
                If Not IsDBNull(row(7)) Then
                    HostelApplication.HostelName = row(7)
                End If
                If Not IsDBNull(row(8)) Then
                    HostelApplication.DesiredHostelResidentID = row(8)
                End If
                If Not IsDBNull(row(9)) Then
                    HostelApplication.DesiredHostelResident = row(9)
                End If
                If Not IsDBNull(row(10)) Then
                    HostelApplication.SubscriptionPlanID = row(10)
                End If
                If Not IsDBNull(row(11)) Then
                    HostelApplication.SubscriptionPlan = row(11)
                End If
                If Not IsDBNull(row(12)) Then
                    HostelApplication.Amount = row(12)
                End If

            Next
            'Return HostelApplication data.
            Return HostelApplication
        Else
            Return HostelApplication
        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return HostelApplication
        'End Try
    End Function
    ''' <summary>
    ''' Finds Hostel HostelName by SelectedNode
    ''' </summary>
    ''' <param name="SelectedNode"></param>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes SelectedNode and returns HostelApplicationFormData </remarks>
    Public Function FindRoomNameBySelectedNode(ByVal SelectedNode As String) As HostelApplicationFormData
        Dim HostelApplication As HostelApplicationFormData = New HostelApplicationFormData
        'HostelApplication.ReturnedValue = ""
        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable

        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@SelectedNode", SelectedNode)}
        'Try
        'Fetch item based on Description
        reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindRoomNameBySelectedNode", params)
        'Load record into datatable
        dt.Load(reader)
        'check if row actually has data and return the data
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                If Not IsDBNull(row(0)) Then
                    HostelApplication.RoomName = row(0)
                End If
            Next
            'Return HostelApplication data.

            Return HostelApplication
        Else
            Return HostelApplication

        End If
        'Catch ex As Exception
        '    'If error occurs, log it and return nothing.
        '    AppException.LogError(ex.Message)
        '    Return HostelApplication
        'End Try
    End Function
    ''' <summary>
    ''' Find Room Name By HostelApplicationformData
    ''' </summary>
    ''' <param name="HostelApplication"></param>
    ''' <remarks>It Upload Result into the database using UploadResultData</remarks>
    Public Function FindRoomNameByHostelApplicationData(ByVal HostelApplication As HostelApplicationFormData) As Integer
        'Declare and initialize data access parameters
        Dim RetVal As Integer

        Dim params() As SqlParameter = _
        {New SqlParameter("@SubscriptionPlan", HostelApplication.SubscriptionPlan), _
        New SqlParameter("@DesiredHostelResident", HostelApplication.DesiredHostelResident), _
        New SqlParameter("@HostelName", HostelApplication.HostelName), _
        New SqlParameter("@Description", HostelApplication.Description), _
        New SqlParameter("@FloorPosition", HostelApplication.FloorPosition), _
        New SqlParameter("@RoomName", HostelApplication.RoomName), _
        New SqlParameter("@RoomNameID", SqlDbType.Int, 4)}
        'Assigning value to the return value
        params(6).Direction = ParameterDirection.Output
        'Try
        'Assign Asset
        SqlHelper.ExecuteNonQuery(ConStr, CommandType.StoredProcedure, "FindRoomNameByHostelApplicationData", params)
        'Populate Error Code
        RetVal = params(6).Value
        Return RetVal
        'Catch ex As Exception
        '    'If error occurs, log it and return errorcode
        '    RetVal(0) = params(21).Value
        '    'Populate Error Hint
        '    RetVal(1) = params(22).Value
        '    Return RetVal
        'End Try
    End Function
    ''' <summary>
    ''' Finds Hostel Comment by RegNumber
    ''' </summary>
    ''' <param name="RegNumber"></param>
    ''' <returns>String</returns>
    ''' <remarks>It takes RegNumber and returns String </remarks>
    Public Function FindCommentByRegNumber(ByVal RegNumber As String, ByVal SessionID As Integer, ByVal LevelID As Integer, ByVal SemesterID As Integer) As String
        'Dim HostelApplication As String() = {"", ""}
        Dim RetValue As String = String.Empty

        Dim reader As SqlDataReader
        Dim dt As DataTable = New DataTable
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNumber), _
                                        New SqlParameter("@SessionID", SessionID), _
                                        New SqlParameter("@LevelID", LevelID), _
                                        New SqlParameter("@SemesterID", SemesterID)}
        Try
            'Fetch item based on Comment
            reader = SqlHelper.ExecuteReader(ConStr, CommandType.StoredProcedure, "FindCommentByRegNumber", params)
            'Load record into datatable
            dt.Load(reader)
            'check if row actually has data and return the data

            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    If Not IsDBNull(row(0)) Then
                        RetValue = row(0)
                    End If

                Next
                'Return String.
                Return RetValue
            Else
                Return RetValue
            End If
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return RetValue
        End Try
    End Function
    ''' <summary>
    ''' Finds Hostel Application Details by RegNum
    ''' </summary>
    ''' <param name="RegNum"></param>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes RegNum and returns HostelApplicationFormData </remarks>
    Public Function FindApproveHostelApplicationByRegNum(ByVal RegNum As String, ByVal SessionID As Integer, ByVal LevelID As Integer, ByVal SemesterID As Integer) As DataSet
        'Holds HostelApplication Data
        Dim ApprovedAccomodation As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNum), _
                                        New SqlParameter("@SessionID", SessionID), _
                                        New SqlParameter("@LevelID", LevelID), _
                                        New SqlParameter("@SemesterID", SemesterID)}

        Try
            'Fetch all ApprovedAccomodation.
            ApprovedAccomodation = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindApproveHostelApplicationByRegNum", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched ApprovedAccomodation data
        Return ApprovedAccomodation
    End Function
    ''' <summary>
    ''' Finds Hostel Application Details by RegNum
    ''' </summary>
    ''' <param name="RegNum"></param>
    ''' <returns>HostelApplicationFormData</returns>
    ''' <remarks>It takes RegNum and returns HostelApplicationFormData </remarks>
    Public Function FindCommentHostelApplicationByRegNum(ByVal RegNum As String, ByVal SessionID As Integer, ByVal LevelID As Integer, ByVal SemesterID As Integer) As DataSet
        'Holds HostelApplication Data
        Dim ApprovedAccomodation As DataSet = New DataSet
        'Declare and instantiate datasource access parameters
        Dim params() As SqlParameter = {New SqlParameter("@RegNumber", RegNum), _
                                        New SqlParameter("@SessionID", SessionID), _
                                        New SqlParameter("@LevelID", LevelID), _
                                        New SqlParameter("@SemesterID", SemesterID)}

        Try
            'Fetch all ApprovedAccomodation.
            ApprovedAccomodation = SqlHelper.ExecuteDataset(ConStr, CommandType.StoredProcedure, "FindCommentHostelApplicationByRegNum", params)
        Catch ex As Exception
            'If error occurs, log it and return nothing.
            AppException.LogError(ex.Message)
            Return Nothing
        End Try
        'Return fetched ApprovedAccomodation data
        Return ApprovedAccomodation
    End Function
End Class
