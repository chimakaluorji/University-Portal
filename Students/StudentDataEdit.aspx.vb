Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Web.Services
Imports System.Configuration
Imports System.Web.Script.Services
Imports System.Collections.Generic
Partial Class Students_StudentDataEdit
    Inherits System.Web.UI.Page
    <WebMethod()> _
    Public Shared Function GetLGA(ByVal EStateID As String) As List(Of ListItem)
        Dim customers As New List(Of ListItem)()

        Dim query As String = "select a.LGAID,a.LGAName,a.StateID,b.StateName from LGA a, State b where a.StateID = b.StateID and a.StateID = " & EStateID & ""
        Dim constr As String = ConfigurationManager.ConnectionStrings("ResultManagerConnectionString").ConnectionString
        Using con As New SqlConnection(constr)
            Using cmd As New SqlCommand(query)

                cmd.CommandType = CommandType.Text
                cmd.Connection = con
                con.Open()
                Using sdr As SqlDataReader = cmd.ExecuteReader()
                    While sdr.Read()
                        customers.Add(New ListItem() With { _
                          .Value = sdr("LGAID").ToString(), _
                          .Text = sdr("LGAName").ToString() _
                        })
                    End While
                End Using
                con.Close()

            End Using
        End Using

        Return customers
    End Function
End Class
