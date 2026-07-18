Imports System.IO
Imports System.Security.Cryptography
Imports System.Text



Public Class Crypto

    Protected key As String = Main.zRandomKey
    Private strPassword As String


    Public Sub New(ByVal Value As String)
        strPassword = Value
    End Sub



    Property Password() As String
        Get
            Return strPassword
        End Get
        Set(ByVal Value As String)
            strPassword = Value
        End Set
    End Property



    Public Function encryptString(ByVal strtext As String) As String
        Return Encrypt(strtext, key)
    End Function



    Public Function decryptString(ByVal strtext As String) As String
        If Not strtext = "" Then
            Return Decrypt(strtext, key)
        Else
            Return "0"
        End If
    End Function



    Private Function Encrypt(ByVal strText As String, ByVal strEncrKey As String) As String
        Dim byKey() As Byte = {}
        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Try
            byKey = System.Text.Encoding.UTF8.GetBytes(Left(strEncrKey, 8))
            Dim des As New DESCryptoServiceProvider()
            Dim inputByteArray() As Byte = Encoding.UTF8.GetBytes(strText)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Return Convert.ToBase64String(ms.ToArray())
        Catch ex As Exception
            Return "nix"
            Debug.WriteLine(ex.Message)
        End Try
    End Function



    Private Function Decrypt(ByVal strText As String, ByVal sDecrKey As String) As String
        Dim byKey() As Byte = {}
        Dim IV() As Byte = {&H12, &H34, &H56, &H78, &H90, &HAB, &HCD, &HEF}
        Dim inputByteArray(strText.Length) As Byte
        Try
            byKey = System.Text.Encoding.UTF8.GetBytes(Left(sDecrKey, 8))
            Dim des As New DESCryptoServiceProvider()
            inputByteArray = Convert.FromBase64String(strText)
            Dim ms As New MemoryStream()
            Dim cs As New CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write)
            cs.Write(inputByteArray, 0, inputByteArray.Length)
            cs.FlushFinalBlock()
            Dim encoding As System.Text.Encoding = System.Text.Encoding.UTF8
            Return encoding.GetString(ms.ToArray())
        Catch ex As Exception
            Return "nix"
            Debug.WriteLine(ex.Message)
        End Try
    End Function



End Class
