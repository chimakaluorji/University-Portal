<%@ WebHandler Language="VB" Class="Handler" %>

Imports JsonServices
Imports JsonServices.Web

Public Class Handler
    Inherits JsonHandler
    Public Sub New()
        Me.service.Name = "JSONWebAPI"
        Me.service.Description = "JSON API for android appliation"
        Dim IConfig As New InterfaceConfiguration("RestAPI", GetType(IServiceAPI), GetType(ServiceAPI))
        Me.service.Interfaces.Add(IConfig)
    End Sub

End Class
