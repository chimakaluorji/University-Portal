Imports Microsoft.VisualBasic

Imports System.Data
Imports System.Data.SqlClient

Public Class ServiceAPI
    Implements IServiceAPI
    Private dbConnection As SqlConnection

    Public Sub New()
        dbConnection = DBConnect.getConnection()
    End Sub

    Public Sub CreateNewAccount(firstName As String, lastName As String, userName As String, password As String) Implements IServiceAPI.CreateNewAccount
        If dbConnection.State.ToString() = "Closed" Then
            dbConnection.Open()
        End If

        Dim query As String = (Convert.ToString((Convert.ToString((Convert.ToString((Convert.ToString("INSERT INTO UserDetails VALUES ('") & firstName) + "','") & lastName) + "','") & userName) + "','") & password) + "');"

        Dim command As New SqlCommand(query, dbConnection)
        command.ExecuteNonQuery()

        dbConnection.Close()
    End Sub

    Public Function GetUserDetails(userName As String) As DataTable Implements IServiceAPI.GetUserDetails
        Dim userDetailsTable As New DataTable()
        userDetailsTable.Columns.Add(New DataColumn("firstName", GetType([String])))
        userDetailsTable.Columns.Add(New DataColumn("lastName", GetType([String])))

        If dbConnection.State.ToString() = "Closed" Then
            dbConnection.Open()
        End If

        Dim query As String = (Convert.ToString("SELECT firstName,lastName FROM UserDetails WHERE userName='") & userName) + "';"

        Dim command As New SqlCommand(query, dbConnection)
        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then
            While reader.Read()
                userDetailsTable.Rows.Add(reader("firstName"), reader("lastName"))
            End While
        End If

        reader.Close()
        dbConnection.Close()
        Return userDetailsTable

    End Function

    Public Function UserAuthentication(userName As String, passsword As String) As Boolean Implements IServiceAPI.UserAuthentication
        Dim auth As Boolean = False

        If dbConnection.State.ToString() = "Closed" Then
            dbConnection.Open()
        End If

        Dim query As String = (Convert.ToString((Convert.ToString("SELECT id FROM UserDetails WHERE userName='") & userName) + "' AND password='") & passsword) + "';"

        Dim command As New SqlCommand(query, dbConnection)
        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then
            auth = True
        End If

        reader.Close()
        dbConnection.Close()

        Return auth

    End Function
    '
    '        public DataTable GetPaymentDetails()
    '        {
    '            DataTable paymentDetails = new DataTable();
    '            
    '            paymentDetails.Columns.Add("no", typeof(String));
    '            paymentDetails.Columns.Add("name", typeof(String));
    '            if (dbConnection.State.ToString() == "Closed")
    '            {
    '                dbConnection.Open();
    '            }
    '            string query = "SELECT no,name FROM Payment;";
    '            SqlCommand command = new SqlCommand(query, dbConnection);
    '            SqlDataReader reader = command.ExecuteReader();
    '            if (reader.HasRows)
    '            {
    '                while (reader.Read())
    '                {
    '                    paymentDetails.Rows.Add(reader["no"], reader["name"]);
    '                }
    '            }
    '            reader.Close();
    '            dbConnection.Close();
    '            return paymentDetails;
    '        } 

End Class
