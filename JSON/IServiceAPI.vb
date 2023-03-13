Imports Microsoft.VisualBasic

Imports System.Data


'''
''' This interface declare the methods need to be implement.
'''
Public Interface IServiceAPI
    Sub CreateNewAccount(firstName As String, lastName As String, userName As String, password As String)
    Function GetUserDetails(userName As String) As DataTable
    Function UserAuthentication(userName As String, passsword As String) As Boolean
    ' will be used for payment db
    ' DataTable GetPaymentDetails();
End Interface