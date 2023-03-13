''''''''''''''''''''''''''''''''''''''''''''''''''
'' Author: Chima kalu-orji
'' Date: 18-09-2008
'' The Class is a utility that handles data encryption and decryption.
''''''''''''''''''''''''''''''''''''''''''''''''''
Imports Microsoft.VisualBasic
Imports Persephone.Security.Utilities.Cryptography
Imports System.Security.Cryptography
Imports System.IO

Public Class EncryptionUtil

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'This method encrypts data and generates a key for for decrypting it. 
    'It accepts the data to be encrypted as a parameter and returns a sring array containg the encrypted data and the key for decrypting it.
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Function EncryptData(ByVal DataToEncrypt As String) As String()
        Dim RetArr() As String = {"", ""}
        Dim IEncrypt As ICryptoHelper = CryptoFactory.Create(CryptographyAlgorithm.Rijndael)
        'Encrypt data and save the encrypted data into the first position of the array.
        RetArr(0) = IEncrypt.Encrypt(DataToEncrypt, StringEncodingType.Base64)
        'Generate the Key for decrypting the data and save it into the second position of the array.
        RetArr(1) = IEncrypt.Entropy  ' Note: This may be null if using the DPAPI
        Return RetArr
    End Function

    ''' <summary>
    '''This method decrypts Encrypted Data.
    '''It accepts EncryptedData and Key for decrypting it as parameters and      '''returns the decrypted data as string
    ''' </summary>
    ''' <param name="EncryptedData"></param>
    ''' <param name="Key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DecryptData(ByVal EncryptedData As String, ByVal Key As String) As String
        ' decrypt the data using the Key string
        Dim IDecrypt As ICryptoHelper = CryptoFactory.Create(CryptographyAlgorithm.Rijndael, Key)
        Dim decryptedData As String = IDecrypt.Decrypt(EncryptedData, StringEncodingType.Base64)
        Return decryptedData

    End Function
    ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''This method encrypts data and generates a key for for decrypting it. 
    ''It accepts the data to be encrypted as a parameter and returns a sring array containg the encrypted data and the key for decrypting it.
    ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Public Function Encrypt(ByVal DataToEncrypt As String) As String
    '    Dim RetArr As String = ""
    '    Dim IEncrypt As ICryptoHelper = CryptoFactory.Create(CryptographyAlgorithm.Rijndael)
    '    'Encrypt data and save the encrypted data into the first position of the array.
    '    RetArr = IEncrypt.Encrypt(DataToEncrypt, StringEncodingType.Base64)
    '    Return RetArr
    'End Function

    ' ''' <summary>
    ' '''This method decrypts Encrypted Data.
    ' '''It accepts EncryptedData and Key for decrypting it as parameters and      '''returns the decrypted data as string
    ' ''' </summary>
    ' ''' <param name="EncryptedData"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function Decrypt(ByVal EncryptedData As String) As String
    '    ' decrypt the data using the Key string
    '    Dim IDecrypt As ICryptoHelper = CryptoFactory.Create(CryptographyAlgorithm.Rijndael)
    '    Dim decryptedData As String = IDecrypt.Decrypt(EncryptedData, StringEncodingType.Base64)
    '    Return decryptedData

    'End Function

    'Public Function Encrypt(ByVal clearText As String) As String
    '    Dim EncryptionKey As String = "MAKV2SPBNI99212"
    '    Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
    '    Using encryptor As Aes = Aes.Create()
    '        Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
    '         &H65, &H64, &H76, &H65, &H64, &H65, _
    '         &H76})
    '        encryptor.Key = pdb.GetBytes(32)
    '        encryptor.IV = pdb.GetBytes(16)
    '        Using ms As New MemoryStream()
    '            Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
    '                cs.Write(clearBytes, 0, clearBytes.Length)
    '                cs.Close()
    '            End Using
    '            clearText = Convert.ToBase64String(ms.ToArray())
    '        End Using
    '    End Using
    '    Return clearText
    'End Function

    'Public Function Decrypt(ByVal cipherText As String) As String
    '    Dim EncryptionKey As String = "MAKV2SPBNI99212"
    '    cipherText = cipherText.Replace(" ", "+")
    '    Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
    '    Using encryptor As Aes = Aes.Create()
    '        Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
    '         &H65, &H64, &H76, &H65, &H64, &H65, _
    '         &H76})
    '        encryptor.Key = pdb.GetBytes(32)
    '        encryptor.IV = pdb.GetBytes(16)
    '        Using ms As New MemoryStream()
    '            Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
    '                cs.Write(cipherBytes, 0, cipherBytes.Length)
    '                cs.Close()
    '            End Using
    '            cipherText = Encoding.Unicode.GetString(ms.ToArray())
    '        End Using
    '    End Using
    '    Return cipherText
    'End Function

    Public Function Encrypt(ByVal clearText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        'Dim clearBytes As Byte() = Encoding.Unicode.GetBytes(clearText)
        'Using encryptor As Aes = Aes.Create()
        '    Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
        '     &H65, &H64, &H76, &H65, &H64, &H65, _
        '     &H76})
        '    encryptor.Key = pdb.GetBytes(32)
        '    encryptor.IV = pdb.GetBytes(16)
        '    Using ms As New MemoryStream()
        '        Using cs As New CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)
        '            cs.Write(clearBytes, 0, clearBytes.Length)
        '            cs.Close()
        '        End Using
        '        clearText = Convert.ToBase64String(ms.ToArray())
        '    End Using
        'End Using
        'Return clearText

        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String = ""

        Dim hash(31) As Byte
        Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(EncryptionKey))
        Array.Copy(temp, 0, hash, 0, 16)
        Array.Copy(temp, 0, hash, 15, 16)
        AES.Key = hash
        AES.Mode = System.Security.Cryptography.CipherMode.ECB
        Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
        Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(clearText)

        encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
        Return encrypted
    End Function

    Public Function Decrypt(ByVal cipherText As String) As String
        Dim EncryptionKey As String = "MAKV2SPBNI99212"
        'cipherText = cipherText.Replace(" ", "+")
        'Dim cipherBytes As Byte() = Convert.FromBase64String(cipherText)
        'Using encryptor As Aes = Aes.Create()
        '    Dim pdb As New Rfc2898DeriveBytes(EncryptionKey, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D, _
        '     &H65, &H64, &H76, &H65, &H64, &H65, _
        '     &H76})
        '    encryptor.Key = pdb.GetBytes(32)
        '    encryptor.IV = pdb.GetBytes(16)
        '    Using ms As New MemoryStream()
        '        Using cs As New CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write)
        '            cs.Write(cipherBytes, 0, cipherBytes.Length)
        '            cs.Close()
        '        End Using
        '        cipherText = Encoding.Unicode.GetString(ms.ToArray())
        '    End Using
        'End Using
        'Return cipherText

        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String = ""

        Dim hash(31) As Byte
        Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(EncryptionKey))
        Array.Copy(temp, 0, hash, 0, 16)
        Array.Copy(temp, 0, hash, 15, 16)
        AES.Key = hash
        AES.Mode = System.Security.Cryptography.CipherMode.ECB
        Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor

        Dim s As String = cipherText.Trim().Replace(" ", "+")
        s = cipherText.Trim().Replace(" ", "/")
        s = cipherText.Trim().Replace(" ", "-")

        If s.Length Mod 4 > 0 Then
            s = s.PadRight(s.Length + 4 - s.Length Mod 4, "="c)
        End If


        Dim Buffer As Byte() = Convert.FromBase64String(s)
        decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
        Return decrypted
    End Function
End Class
