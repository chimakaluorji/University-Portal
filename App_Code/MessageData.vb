Imports Microsoft.VisualBasic

Public Class MessageData
    Private _MessagingID As Integer
    Private _MessageBody As String
    Private _InOutFlag As String
    Private _DocUrl As String
    Private _DocUrl1 As String
    Private _DocUrl2 As String
    Private _DocUrl3 As String
    Private _ReadStatus As String
    Private _Subject As String
    Private _MessageType As String
    Private _SenderID As String
    Private _CreatedByUID As Integer
    Private _RecipientID As Integer
    Private _DateTime As String
    Private _UserName As String
    Private _Recipients As String
    Private _DistListName As String
    Private _DistrListOwnerID As Integer
    Private _DistriListID As Integer
    Private _DocRepositoryID As Integer
    Private _RegNumber As String
    Private _Recipient As String

    Public Property DocRepositoryID() As Integer
        Get
            Return _DocRepositoryID
        End Get
        Set(ByVal value As Integer)
            _DocRepositoryID = value
        End Set
    End Property

    Public Property MessagingID() As Integer
        Get
            Return _MessagingID
        End Get
        Set(ByVal value As Integer)
            _MessagingID = value
        End Set
    End Property

    Public Property MessageBody() As String
        Get
            Return _MessageBody
        End Get
        Set(ByVal value As String)
            _MessageBody = value
        End Set
    End Property
    Public Property RecipientID() As Integer
        Get
            Return _RecipientID
        End Get
        Set(ByVal value As Integer)
            _RecipientID = value
        End Set
    End Property
    Public Property Recipient() As String
        Get
            Return _Recipient
        End Get
        Set(ByVal value As String)
            _Recipient = value
        End Set
    End Property
    Public Property InOutFlag() As String
        Get
            Return _InOutFlag
        End Get
        Set(ByVal value As String)
            _InOutFlag = value
        End Set
    End Property
    Public Property DocUrl() As String
        Get
            Return _DocUrl
        End Get
        Set(ByVal value As String)
            _DocUrl = value
        End Set
    End Property
    Public Property DocUrl1() As String
        Get
            Return _DocUrl1
        End Get
        Set(ByVal value As String)
            _DocUrl1 = value
        End Set
    End Property
    Public Property DocUrl2() As String
        Get
            Return _DocUrl2
        End Get
        Set(ByVal value As String)
            _DocUrl2 = value
        End Set
    End Property
    Public Property DocUrl3() As String
        Get
            Return _DocUrl3
        End Get
        Set(ByVal value As String)
            _DocUrl3 = value
        End Set
    End Property
    Public Property ReadStatus() As String
        Get
            Return _ReadStatus
        End Get
        Set(ByVal value As String)
            _ReadStatus = value
        End Set
    End Property
    Public Property Subject() As String
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            _Subject = value
        End Set
    End Property
    Public Property MessageType() As String
        Get
            Return _MessageType
        End Get
        Set(ByVal value As String)
            _MessageType = value
        End Set
    End Property
    Public Property SenderID() As String
        Get
            Return _SenderID
        End Get
        Set(ByVal value As String)
            _SenderID = value
        End Set
    End Property
    Public Property CreatedByUID() As Integer
        Get
            Return _CreatedByUID
        End Get
        Set(ByVal value As Integer)
            _CreatedByUID = value
        End Set
    End Property
    
    Public Property DateTime() As String
        Get
            Return _DateTime
        End Get
        Set(ByVal value As String)
            _DateTime = value
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property
    Public Property Recipients() As String
        Get
            Return _Recipients
        End Get
        Set(ByVal value As String)
            _Recipients = value
        End Set
    End Property
    Public Property DistListName() As String
        Get
            Return _DistListName
        End Get
        Set(ByVal value As String)
            _DistListName = value
        End Set
    End Property

    Public Property DistrListOwnerID() As Integer
        Get
            Return _DistrListOwnerID
        End Get
        Set(ByVal value As Integer)
            _DistrListOwnerID = value
        End Set
    End Property
    Public Property DistriListID() As Integer
        Get
            Return _DistriListID
        End Get
        Set(ByVal value As Integer)
            _DistriListID = value
        End Set
    End Property
    Public Property RegNumber() As String
        Get
            Return _RegNumber
        End Get
        Set(ByVal value As String)
            _RegNumber = value
        End Set
    End Property
End Class
