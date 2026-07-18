Imports System.Diagnostics
Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Win32

Module RdpSigner
    Sub Main()
        'SignRdpWithRegistryPfx(rdpFilePath)
    End Sub


    Public Sub SignRdpWithRegistryPfx(rdpFilePath As String, zDecryptedPassword As String, zLogfile As String, zErrorLogfile As String)
        ' 1. Validate the RDP file exists first
        If Not File.Exists(rdpFilePath) Then
            My.Computer.FileSystem.WriteAllText(zErrorLogfile, "errors occured during signing on following file(s), " & $"Error: RDP file not found at {rdpFilePath}" & vbCrLf, True)
            Console.WriteLine($"Error: RDP file not found at {rdpFilePath}")
            Return
        End If

        Dim pfxPath As String = ""
        Dim pfxPassword As String = ""
        Dim registryKeyPath As String = "SOFTWARE\Lanstar\SigningTool"

        ' 2. Read the PFX path and password from the registry
        Try
            Using key As RegistryKey = Registry.CurrentUser.OpenSubKey(registryKeyPath)
                If key IsNot Nothing Then
                    pfxPath = Convert.ToString(key.GetValue("rkCertFileName"))
                    pfxPassword = zDecryptedPassword
                Else
                    My.Computer.FileSystem.WriteAllText(zErrorLogfile, "errors occured during signing on following file(s), " & $"Error: Registry key 'HKCU\{registryKeyPath}' not found." & vbCrLf, True)
                    Console.WriteLine($"Error: Registry key 'HKCU\{registryKeyPath}' not found.")
                    Return
                End If
            End Using
        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText(zErrorLogfile, "errors occured during signing on following file(s), " & $"Failed to read registry: {ex.Message}" & vbCrLf, True)
            Console.WriteLine($"Failed to read registry: {ex.Message}")
            Return
        End Try

        ' Validate registry data
        If String.IsNullOrEmpty(pfxPath) OrElse Not File.Exists(pfxPath) Then
            My.Computer.FileSystem.WriteAllText(zErrorLogfile, "errors occured during signing on following file(s), " & $"Error: PFX file path is invalid or file missing: '{pfxPath}'" & vbCrLf, True)
            Console.WriteLine($"Error: PFX file path is invalid or file missing: '{pfxPath}'")
            Return
        End If

        ' 3. Load the PFX file into an X509Certificate2 object
        Dim cert As X509Certificate2 = Nothing
        Dim store As New X509Store(StoreName.My, StoreLocation.CurrentUser)

        Try
            ' Explicitly allow the private key to be exported/used by the subsystem
            Dim flags As X509KeyStorageFlags = X509KeyStorageFlags.UserKeySet Or X509KeyStorageFlags.Exportable
            cert = New X509Certificate2(pfxPath, pfxPassword, flags)

            ' 4. Temporarily open the Current User's Personal store and add the cert
            store.Open(OpenFlags.ReadWrite)
            store.Add(cert)

            ' Extract the thumbprint required by rdpsign.exe
            Dim thumbprint As String = cert.Thumbprint
            My.Computer.FileSystem.WriteAllText(zLogfile, Date.Now & ":" & $"Successfully loaded certificate. Thumbprint: {thumbprint}" & vbCrLf, True)
            Console.WriteLine($"Successfully loaded certificate. Thumbprint: {thumbprint}")

            ' 5. Call rdpsign.exe using the thumbprint
            RunRdpSignTool(rdpFilePath, thumbprint, zLogfile, zErrorLogfile)

        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText(zErrorLogfile, "errors occured during signing on following file(s), " & $"An error occurred during the signing process: {ex.Message}" & vbCrLf, True)
            Console.WriteLine($"An error occurred during the signing process: {ex.Message}")
        Finally
            ' 6. CLEANUP: Compatible with older .NET Framework versions
            If cert IsNot Nothing Then
                Try
                    ' In older .NET, we re-open the store to ensure we can remove it, 
                    ' or just call Remove if it's already open.
                    store.Open(OpenFlags.ReadWrite)
                    store.Remove(cert)
                    Console.WriteLine("Temporary certificate successfully removed from the store.")
                    My.Computer.FileSystem.WriteAllText(zLogfile, Date.Now & ":" & "Temporary certificate successfully removed from the store." & vbCrLf, True)

                Catch ex As Exception
                    My.Computer.FileSystem.WriteAllText(zErrorLogfile, "errors occured during signing on following file(s), " & $"Warning: Failed to remove temp cert from store: {ex.Message}" & vbCrLf, True)
                    Console.WriteLine($"Warning: Failed to remove temp cert from store: {ex.Message}")
                End Try
            End If

            ' Close the store safely
            store.Close()

            ' In older .NET Framework, X509Certificate2 uses Reset() instead of Dispose()
            If cert IsNot Nothing Then
                cert.Reset()
            End If
        End Try
    End Sub

    Private Sub RunRdpSignTool(filePath As String, thumbprint As String, zLogfile As String, zErrorLogfile As String)
        Dim rdpSignPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "rdpsign.exe")
        Dim arguments As String = $"/sha256 {thumbprint} ""{filePath}"""

        Dim startInfo As New ProcessStartInfo() With {
            .FileName = rdpSignPath,
            .Arguments = arguments,
            .UseShellExecute = False,
            .RedirectStandardOutput = True,
            .RedirectStandardError = True,
            .CreateNoWindow = True
        }

        Using process As Process = Process.Start(startInfo)
            Dim output As String = process.StandardOutput.ReadToEnd()
            Dim errors As String = process.StandardError.ReadToEnd()

            process.WaitForExit()

            If process.ExitCode = 0 Then
                My.Computer.FileSystem.WriteAllText(zLogfile, Date.Now & ":" & filePath & " successfully signed" & vbCrLf, True)
                Console.WriteLine("RDP file signed successfully!")
                Console.WriteLine(output)
            Else
                Console.WriteLine($"rdpsign.exe failed with exit code: {process.ExitCode}")
                If Not String.IsNullOrEmpty(errors) Then
                    My.Computer.FileSystem.WriteAllText(zErrorLogfile, "errors occured during signing on following file(s), " & $"Error Details: {errors}" & vbCrLf, True)
                    Console.WriteLine($"Error Details: {errors}")
                Else
                    My.Computer.FileSystem.WriteAllText(zErrorLogfile, "errors occured during signing on following file(s), " & $"Error Details: " & output & vbCrLf, True)
                    Console.WriteLine(output)
                End If
            End If
        End Using
    End Sub
End Module