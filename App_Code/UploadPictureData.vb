Imports Microsoft.VisualBasic

Public Class UploadPictureData
    Private _UploadPictureID As Integer
    Private _PersonalInformationID As Integer
    Private _UploadBigPicture As String
    Private _UploadSmallPicture As String
    Private _CreatedByUID As Integer

    Public Property UploadPictureID() As Integer
        Get
            Return _UploadPictureID
        End Get
        Set(ByVal value As Integer)
            _UploadPictureID = value
        End Set
    End Property
    Public Property PersonalInformationID() As Integer
        Get
            Return _PersonalInformationID
        End Get
        Set(ByVal value As Integer)
            _PersonalInformationID = value
        End Set
    End Property
    Public Property UploadBigPicture() As String
        Get
            Return _UploadBigPicture
        End Get
        Set(ByVal value As String)
            _UploadBigPicture = value
        End Set
    End Property
    Public Property UploadSmallPicture() As String
        Get
            Return _UploadSmallPicture
        End Get
        Set(ByVal value As String)
            _UploadSmallPicture = value
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
End Class
