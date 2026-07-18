Option Strict On

Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports System
Imports System.Drawing

Namespace Encryption


#Region "  Symmetric"

    Public Class Symmetric

        Private Const _DefaultIntializationVector As String = "%1Az=-@qT"
        Private Const _BufferSize As Integer = 2048

        Public Enum Provider
            ''' <summary>
            ''' The Data Encryption Standard provider supports a 64 bit key only
            ''' </summary>
            DES
            ''' <summary>
            ''' The Rivest Cipher 2 provider supports keys ranging from 40 to 128 bits, default is 128 bits
            ''' </summary>
            RC2
            ''' <summary>
            ''' The Rijndael (also known as AES) provider supports keys of 128, 192, or 256 bits with a default of 256 bits
            ''' </summary>
            Rijndael
            ''' <summary>
            ''' The TripleDES provider (also known as 3DES) supports keys of 128 or 192 bits with a default of 192 bits
            ''' </summary>
            TripleDES
        End Enum

        '        Private _data As Data
        Private _key As Data
        Private _iv As Data
        Private _crypto As SymmetricAlgorithm
      

        Private Sub New()
        End Sub

        ''' <summary>
        ''' Instantiates a new symmetric encryption object using the specified provider.
        ''' </summary>
        Public Sub New(ByVal provider As Provider, Optional ByVal useDefaultInitializationVector As Boolean = True)
            Select Case provider
                Case provider.DES
                    _crypto = New DESCryptoServiceProvider
                Case provider.RC2
                    _crypto = New RC2CryptoServiceProvider
                Case provider.Rijndael
                    _crypto = New RijndaelManaged
                Case provider.TripleDES
                    _crypto = New TripleDESCryptoServiceProvider
            End Select

            '-- make sure key and IV are always set, no matter what
            Me.Key = RandomKey()
            If useDefaultInitializationVector Then
                Me.IntializationVector = New Data(_DefaultIntializationVector)
            Else
                Me.IntializationVector = RandomInitializationVector()
            End If
        End Sub

     

     
        Public Property Key() As Data
            Get
                Return _key
            End Get
            Set(ByVal Value As Data)
                _key = Value
                _key.MaxBytes = _crypto.LegalKeySizes(0).MaxSize \ 8
                _key.MinBytes = _crypto.LegalKeySizes(0).MinSize \ 8
                _key.StepBytes = _crypto.LegalKeySizes(0).SkipSize \ 8
            End Set
        End Property

      
        Public Property IntializationVector() As Data
            Get
                Return _iv
            End Get
            Set(ByVal Value As Data)
                _iv = Value
                _iv.MaxBytes = _crypto.BlockSize \ 8
                _iv.MinBytes = _crypto.BlockSize \ 8
            End Set
        End Property

      
        Public Function RandomInitializationVector() As Data
            _crypto.GenerateIV()
            Dim d As New Data(_crypto.IV)
            Return d
        End Function

       
        Public Function RandomKey() As Data
            _crypto.GenerateKey()
            Dim d As New Data(_crypto.Key)
            Return d
        End Function

      
        Private Sub ValidateKeyAndIv(ByVal isEncrypting As Boolean)
            If _key.IsEmpty Then
                If isEncrypting Then
                    _key = RandomKey()
                Else
                    Throw New CryptographicException("No key was provided for the decryption operation!")
                End If
            End If
            If _iv.IsEmpty Then
                If isEncrypting Then
                    _iv = RandomInitializationVector()
                Else
                    Throw New CryptographicException("No initialization vector was provided for the decryption operation!")
                End If
            End If
            _crypto.Key = _key.Bytes
            _crypto.IV = _iv.Bytes
        End Sub

      
        Public Function Encrypt(ByVal d As Data, ByVal key As Data) As Data
            Me.Key = key
            Return Encrypt(d)
        End Function

       
        Public Function Encrypt(ByVal d As Data) As Data
            Dim ms As New IO.MemoryStream

            ValidateKeyAndIv(True)

            Dim cs As New CryptoStream(ms, _crypto.CreateEncryptor(), CryptoStreamMode.Write)
            cs.Write(d.Bytes, 0, d.Bytes.Length)
            cs.Close()
            ms.Close()

            Return New Data(ms.ToArray)
        End Function

      
        Public Function Encrypt(ByVal s As Stream, ByVal key As Data, ByVal iv As Data) As Data
            Me.IntializationVector = iv
            Me.Key = key
            Return Encrypt(s)
        End Function

      
        Public Function Encrypt(ByVal s As Stream, ByVal key As Data) As Data
            Me.Key = key
            Return Encrypt(s)
        End Function

       
        Public Function Encrypt(ByVal s As Stream) As Data
            Dim ms As New IO.MemoryStream
            Dim b(_BufferSize) As Byte
            Dim i As Integer

            ValidateKeyAndIv(True)

            Dim cs As New CryptoStream(ms, _crypto.CreateEncryptor(), CryptoStreamMode.Write)
            i = s.Read(b, 0, _BufferSize)
            Do While i > 0
                cs.Write(b, 0, i)
                i = s.Read(b, 0, _BufferSize)
            Loop

            cs.Close()
            ms.Close()

            Return New Data(ms.ToArray)
        End Function

      
        Public Function Decrypt(ByVal encryptedData As Data, ByVal key As Data) As Data
            Me.Key = key
            Return Decrypt(encryptedData)
        End Function

       
        Public Function Decrypt(ByVal encryptedStream As Stream, ByVal key As Data) As Data
            Me.Key = key
            Return Decrypt(encryptedStream)
        End Function

      
        Public Function Decrypt(ByVal encryptedStream As Stream) As Data
            Dim ms As New System.IO.MemoryStream
            Dim b(_BufferSize) As Byte

            ValidateKeyAndIv(False)
            Dim cs As New CryptoStream(encryptedStream, _
                _crypto.CreateDecryptor(), CryptoStreamMode.Read)

            Dim i As Integer
            i = cs.Read(b, 0, _BufferSize)

            Do While i > 0
                ms.Write(b, 0, i)
                i = cs.Read(b, 0, _BufferSize)
            Loop
            cs.Close()
            ms.Close()

            Return New Data(ms.ToArray)
        End Function

      
        Public Function Decrypt(ByVal encryptedData As Data) As Data
            Try
                Dim ms As New System.IO.MemoryStream(encryptedData.Bytes, 0, encryptedData.Bytes.Length)
                Dim b() As Byte = New Byte(encryptedData.Bytes.Length - 1) {}

                ValidateKeyAndIv(False)
                Dim cs As New CryptoStream(ms, _crypto.CreateDecryptor(), CryptoStreamMode.Read)

                Try
                    cs.Read(b, 0, encryptedData.Bytes.Length - 1)
                Catch ex As CryptographicException
                    Throw New CryptographicException("Unable to decrypt data. The provided key may be invalid.", ex)
                Finally
                    cs.Close()
                End Try
                Return New Data(b)
            Catch
                Return Nothing
            End Try
        End Function

    End Class

#End Region

  
  
#Region "  Data"

   
    Public Class Data
        Private _b As Byte()
        Private _MaxBytes As Integer = 0
        Private _MinBytes As Integer = 0
        Private _StepBytes As Integer = 0

        Public Shared DefaultEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Windows-1252")

       
        Public Encoding As System.Text.Encoding = DefaultEncoding

       
      
        Public Sub New(ByVal b As Byte())
            _b = b
        End Sub



        Public Sub New(ByVal s As String)
            Me.Text = s
        End Sub


      
        Public Sub New(ByVal s As String, ByVal encoding As System.Text.Encoding)
            Me.Encoding = encoding
            Me.Text = s
        End Sub

        Sub New()
            ' TODO: Complete member initialization 
        End Sub


       
        Public ReadOnly Property IsEmpty() As Boolean
            Get
                If _b Is Nothing Then
                    Return True
                End If
                If _b.Length = 0 Then
                    Return True
                End If
                Return False
            End Get
        End Property


       
        Public Property StepBytes() As Integer
            Get
                Return _StepBytes
            End Get
            Set(ByVal Value As Integer)
                _StepBytes = Value
            End Set
        End Property



        Public Property MinBytes() As Integer
            Get
                Return _MinBytes
            End Get
            Set(ByVal Value As Integer)
                _MinBytes = Value
            End Set
        End Property

       

        Public Property MaxBytes() As Integer
            Get
                Return _MaxBytes
            End Get
            Set(ByVal Value As Integer)
                _MaxBytes = Value
            End Set
        End Property



        Public Property Bytes() As Byte()
            Get
                If _MaxBytes > 0 Then
                    If _b.Length > _MaxBytes Then
                        Dim b(_MaxBytes - 1) As Byte
                        Array.Copy(_b, b, b.Length)
                        _b = b
                    End If
                End If
                If _MinBytes > 0 Then
                    If _b.Length < _MinBytes Then
                        Dim b(_MinBytes - 1) As Byte
                        Array.Copy(_b, b, _b.Length)
                        _b = b
                    End If
                End If
                Return _b
            End Get
            Set(ByVal Value As Byte())
                _b = Value
            End Set
        End Property



        Public Property Text() As String
            Get
                If _b Is Nothing Then
                    Return ""
                Else
                    Dim i As Integer = Array.IndexOf(_b, CType(0, Byte))
                    If i >= 0 Then
                        Return Me.Encoding.GetString(_b, 0, i)
                    Else
                        Return Me.Encoding.GetString(_b)
                    End If
                End If
            End Get
            Set(ByVal Value As String)
                _b = Me.Encoding.GetBytes(Value)
            End Set
        End Property



        Public Property Hex() As String
            Get
                Return Utils.ToHex(_b)
            End Get
            Set(ByVal Value As String)
                _b = Utils.FromHex(Value)
            End Set
        End Property

       
      
        Public Function ToHex() As String
            Return Me.Hex
        End Function


    End Class

#End Region

#Region "  Utils"

 
    Friend Class Utils

       
        Friend Shared Function ToHex(ByVal ba() As Byte) As String
            If ba Is Nothing OrElse ba.Length = 0 Then
                Return ""
            End If
            Const HexFormat As String = "{0:X2}"
            Dim sb As New StringBuilder
            For Each b As Byte In ba
                sb.Append(String.Format(HexFormat, b))
            Next
            Return sb.ToString
        End Function



        Friend Shared Function FromHex(ByVal hexEncoded As String) As Byte()
            If hexEncoded Is Nothing OrElse hexEncoded.Length = 0 Then
                Return Nothing
            End If
            Try
                Dim l As Integer = Convert.ToInt32(hexEncoded.Length / 2)
                Dim b(l - 1) As Byte
                For i As Integer = 0 To l - 1
                    b(i) = Convert.ToByte(hexEncoded.Substring(i * 2, 2), 16)
                Next
                Return b
            Catch ex As Exception
                Throw New System.FormatException("The provided string does not appear to be Hex encoded:" & _
                    Environment.NewLine & hexEncoded & Environment.NewLine, ex)
            End Try
        End Function

      

    End Class

#End Region

End Namespace