'
' Name:			Digital Signatures Tool
'
' Author:		        Rainer Koch
' Date created:	     	March 12, 2013
' Date modified:     	July 17,  2026
' Version:              1.0.0.6
' Remarks:              this version does not check AD for group membership, see var zTestmode
'



Imports Microsoft.Win32
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports SignTool.Sign
Imports System.Security.Cryptography.X509Certificates
Imports System
Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.Reflection
Imports System.Net
Imports System.Net.Sockets





Public Class Main


    Public zLocVBScripts As String
    Public zLocPowerShell As String
    Public zLocApplications As String
    Public zLocMSIFiles As String
    Public zLocRDPFiles As String
    Public zLocCABFiles As String
    Public zLocPDFFiles As String
    Public zLocTimeStampURL As String
    Public zCertificateFileName As String
    Public zPassword As String
    Public zEncryptedPassword As String
    Public zDecryptedPassword As String
    Public zRandomKey As String
    Public zSubjectDN As String
    Public OptionsCalled As Boolean = False
    Public count As Integer
    Public createCertcmd As String = AppDomain.CurrentDomain.BaseDirectory & "createSelfSignedCert.cmd"


    Private zUserName As String = LCase(Environment.GetEnvironmentVariable("USERNAME"))
    Private zLogDirectory As String = "C:\logs\DigitalSignatureTool\"
    Private zSelectedFile As String
    Private zSelectedRDPFile As String
    Private zSelectedDirectory As String
    Private zTimeShowProgressLabel As Integer
    Private folderExists As Boolean
    Private fileExists As Boolean
    Private zLogfile As String = zLogDirectory & zUserName & "_DigitalSignatureTool.log"
    Private zOldLogfile As String = zLogDirectory & zUserName & "_DigitalSignatureTool.log.old"
    Private zErrorLogfile As String = zLogDirectory & zUserName & "_errors.txt"
    Private zFileExtension As String
    Private zAccessGroup As String = "SignatureToolUser"
    Private zAuthorizationFailed As Boolean = False
    Private networkready As Boolean = False
    Private m_FolderCounter As Integer = 0
    Private m_FileCounter As Integer = 0
    Private CancelLoop As Boolean = False
    Private SigninProgress As Boolean = False
    Private zErrorCount As Int16
    Private zDC As String = LCase(Mid(Environment.GetEnvironmentVariable("LOGONSERVER") & "." & Environment.GetEnvironmentVariable("USERDNSDOMAIN"), 3))
    Private zTestmode As Boolean = True  'true if test: no group in AD is used to check authorization, changed 16 July 2026
    Private zInstallKey As String = "SOFTWARE\Wow6432Node\LPS\DST"
    'Private zInetCheckURL As String = "http://timestamp.digicert.com" 'this URL can't be checked as it does not give a response to a normal web check
    Private zInetCheckURL As String = "http://www.msftconnecttest.com/connecttest.txt"
    Private zLicenseString As String = "(free version)"



    Private Function GetIPv4FromHostname(hostname As String) As String
        ' Clean up the hostname just in case it has http:// or slashes in it
        Dim cleanHost As String = hostname.Replace("http://", "").Replace("https://", "").TrimEnd("/"c)

        Try
            ' 1. Query DNS for all IP addresses associated with this host
            Dim addresses() As IPAddress = Dns.GetHostAddresses(cleanHost)

            ' 2. Loop through and find the first IPv4 address
            For Each ip As IPAddress In addresses
                If ip.AddressFamily = AddressFamily.InterNetwork Then
                    Return ip.ToString() ' Returns something like "192.168.1.5"
                End If
            Next

            ' If we get here, only IPv6 addresses were found
            If addresses.Length > 0 Then
                Return addresses(0).ToString()
            End If

            Return ""
        Catch ex As Exception
            ' DNS Resolution failed (host doesn't exist, offline, or network down)
            Return ""
        End Try
    End Function


    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Options.Show()
    End Sub


    Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        folderExists = My.Computer.FileSystem.DirectoryExists("C:\logs")
        If folderExists = False Then
            My.Computer.FileSystem.CreateDirectory("C:\logs")
        End If
        folderExists = My.Computer.FileSystem.DirectoryExists("C:\logs\DigitalSignatureTool")
        If folderExists = False Then
            My.Computer.FileSystem.CreateDirectory("C:\logs\DigitalSignatureTool")
        End If


        CreateDummyDirectory()


        fileExists = My.Computer.FileSystem.FileExists(zOldLogfile)
        If fileExists = True Then
            Try
                My.Computer.FileSystem.DeleteFile(zOldLogfile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Catch ex As Exception
                Beep()
                MsgBox(("Error: Can't delete older logfile" & vbCrLf & ex.Message), 16)
                My.Computer.FileSystem.WriteAllText(zLogfile, Date.Now & "  Error: " & ex.Message & vbCrLf, True)
            End Try
        End If
        fileExists = My.Computer.FileSystem.FileExists(zLogfile)
        If fileExists = True Then
            Try
                My.Computer.FileSystem.CopyFile(zLogfile, zOldLogfile)
            Catch ex As Exception
                Beep()
                MsgBox(("Error: Can't copy logfile" & vbCrLf & ex.Message), 16)
                My.Computer.FileSystem.WriteAllText(zLogfile, Date.Now & "  Error: " & ex.Message & vbCrLf, True)
            End Try
            Try
                My.Computer.FileSystem.DeleteFile(zLogfile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Catch ex As Exception
                Beep()
                MsgBox(("Error: Can't delete logfile" & vbCrLf & ex.Message), 16)
                My.Computer.FileSystem.WriteAllText(zLogfile, Date.Now & "  Error: " & ex.Message & vbCrLf, True)
            End Try
        End If


        fileExists = My.Computer.FileSystem.FileExists(zErrorLogfile)
        If fileExists = True Then
            Try
                My.Computer.FileSystem.DeleteFile(zErrorLogfile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            Catch ex As Exception
                Beep()
                MsgBox(("Error: Can't delete error logs" & vbCrLf & ex.Message), 16)
            End Try
        End If


        My.Computer.FileSystem.WriteAllText(zLogfile, "Digital Signature Tool, User is :" & zUserName & " " & zLicenseString & vbCrLf, True)  'add addtl' license info to the logfile
        My.Computer.FileSystem.WriteAllText(zLogfile, vbCrLf, True)
        My.Computer.FileSystem.WriteAllText(zLogfile, "Settings:" & vbCrLf, True)
        My.Computer.FileSystem.WriteAllText(zLogfile, "----------------------------------------------------------------------------------------------------------------------------" & vbCrLf, True)


        My.Computer.FileSystem.WriteAllText(zErrorLogfile, "errors occured during signing on following file(s), User is : " & zUserName & vbCrLf, True)


        If zTestmode = False Then

            Dim dcIP As String = GetIPv4FromHostname(zDC)
            Try
                If Not String.IsNullOrEmpty(dcIP) Then
                    Console.WriteLine($"The IP address for {zDC} is: {dcIP}")
                    networkready = True
                    CheckAuthorization() 'checks if the User is in this group Private zAccessGroup As String = "SignatureToolUser"
                Else
                    Console.WriteLine($"Could not resolve DNS for {zDC}")
                    MessageBox.Show("not connected to the Domain Controller " & zDC, "Digital Signature Tool", MessageBoxButtons.OK)
                    System.Diagnostics.Process.GetCurrentProcess.Kill()
                End If
            Catch ex As Exception
                MessageBox.Show("not connected to the Domain Controller " & zDC, "Digital Signature Tool", MessageBoxButtons.OK)
                System.Diagnostics.Process.GetCurrentProcess.Kill()
            End Try
        End If


        Try
            If My.Computer.Registry.CurrentUser.OpenSubKey("Software\Lanstar\SigningTool") IsNot Nothing Then
                zLocApplications = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkApplicationsPath", "Default Value")
                zCertificateFileName = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkCertFileName", "Default Value")
                zLocMSIFiles = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkMSIPath", "Default Value")
                zLocRDPFiles = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkRDPPath", "Default Value")
                zPassword = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkpfxpwd", "Default Value")
                zLocPowerShell = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkPowerShellPath", "Default Value")
                zLocVBScripts = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkVBScriptPath", "Default Value")
                zLocTimeStampURL = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkTimeStampURL", "Default Value")
                zLocCABFiles = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkCABPath", "Default Value")
                zLocPDFFiles = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkPDFPath", "Default Value")
                count = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "count", "Default Value")

            Else
                Dim newKey As RegistryKey
                newKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Lanstar\SigningTool")
                count = 0

            End If
        Finally

            count += 1
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "count", count)
            My.Computer.Registry.CurrentUser.Close()
        End Try


        Dim arrArgs() As String = Command.Split(",")
        Dim i As Integer
        Dim zReleasePath As String
        If arrArgs(0) <> Nothing Then
            For i = LBound(arrArgs) To UBound(arrArgs)
                zReleasePath = Mid(arrArgs(i), 2, arrArgs(i).Length - 3)
                lblCurrentDirectory.Text = "current:"
                btnSingleFile.Enabled = False
                btnAllFiles.Enabled = False
                zSelectedDirectory = zReleasePath
                lblCurrentDirectory.Text += " " & zReleasePath
                zFileExtension = "exe"
                listFiles()
                My.Computer.FileSystem.WriteAllText(zLogfile, "started from Visual Studio " & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "Release folder      : " & zReleasePath & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "vbScripts folder    : " & zLocVBScripts & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "Powershell folder   : " & zLocPowerShell & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "CAB files folder    : " & zLocCABFiles & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "PDF files folder    : " & zLocPDFFiles & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "Applications folder : " & zLocApplications & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "MSI Files folder    : " & zLocMSIFiles & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "RDP Files folder    : " & zLocRDPFiles & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "Certificate File    : " & zCertificateFileName & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "Timestamp URL       : " & zLocTimeStampURL & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "Version             : " & My.Application.Info.Version.ToString & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "Stats               : " & count & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, vbCrLf, True)
            Next
        Else
            My.Computer.FileSystem.WriteAllText(zLogfile, "vbScripts folder    : " & zLocVBScripts & vbCrLf, True)
            My.Computer.FileSystem.WriteAllText(zLogfile, "Powershell folder   : " & zLocPowerShell & vbCrLf, True)
            My.Computer.FileSystem.WriteAllText(zLogfile, "CAB files folder    : " & zLocCABFiles & vbCrLf, True)
            My.Computer.FileSystem.WriteAllText(zLogfile, "PDF files folder    : " & zLocPDFFiles & vbCrLf, True)
            My.Computer.FileSystem.WriteAllText(zLogfile, "Applications folder : " & zLocApplications & vbCrLf, True)
            My.Computer.FileSystem.WriteAllText(zLogfile, "MSI Files folder    : " & zLocMSIFiles & vbCrLf, True)
            My.Computer.FileSystem.WriteAllText(zLogfile, "RDP Files folder    : " & zLocRDPFiles & vbCrLf, True)
            My.Computer.FileSystem.WriteAllText(zLogfile, "Certificate File    : " & zCertificateFileName & vbCrLf, True)
            My.Computer.FileSystem.WriteAllText(zLogfile, "Timestamp URL       : " & zLocTimeStampURL & vbCrLf, True)
            My.Computer.FileSystem.WriteAllText(zLogfile, "Version             : " & My.Application.Info.Version.ToString & vbCrLf, True)
            My.Computer.FileSystem.WriteAllText(zLogfile, "Stats               : " & count & vbCrLf, True)
            My.Computer.FileSystem.WriteAllText(zLogfile, vbCrLf, True)
        End If


        btnSingleFile.Enabled = False
        btnAllFiles.Enabled = False
        lblProgress.Visible = False
        lblProgress.Text = ""
        lblProgressError.Visible = False
        lblProgressError.Text = ""
        Options.lblWarning.Text = ""
        lblFolderInfo.Text = ""
        lblPercentage.Text = ""


        Dim keyValue As Object
        keyValue = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkGUID", "Default Value")
        If InStr(keyValue, "Default") Then
            zRandomKey = (GenerateRandomPassword(18))
            Dim newGUID As RegistryKey
            newGUID = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Lanstar\SigningTool")
            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkGUID", zRandomKey)
        Else
            zRandomKey = keyValue
        End If


        Try
            Dim oCryptPassword As New Crypto(zEncryptedPassword)
            zDecryptedPassword = oCryptPassword.decryptString(zPassword)
        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText(zErrorLogfile, "decrypt password : " & ex.Message & vbCrLf, True)
        End Try


        verifyCert()


        If InternetConnection() = False Then
            My.Computer.FileSystem.WriteAllText(zErrorLogfile, "please check your settings" & vbCrLf, True)
            'MessageBox.Show("please check your settings ", "Signtool", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                lblInternetConnectionOK.Text += zLocTimeStampURL.ToString
            Catch ex As Exception
                My.Computer.FileSystem.WriteAllText(zErrorLogfile, "inet label set, first start : " & ex.Message & vbCrLf, True)
            End Try
        End If



    End Sub



    Private Function GenerateRandomPassword(ByVal length As Integer) As String
        Dim strGuid As String = System.Guid.NewGuid().ToString()
        strGuid = strGuid.Replace("-", String.Empty)
        Return strGuid.Substring(0, length)
    End Function



    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub



    Private Sub listFiles()
        lbShow.Items.Clear()
        lblFolderInfo.Text = ""
        m_FolderCounter = 0
        m_FileCounter = 0
        RecursiveSearch(zSelectedDirectory)
        ShowDefaultCursor()
        If zSelectedDirectory = "" Then
            lblFolderInfo.Text = ("empty path, select 'Scripts' or 'Applications' Menu")
        Else
            lblFolderInfo.Text = (m_FileCounter & " Files in " & m_FolderCounter & " subfolders")
        End If
    End Sub



    Private Function RecursiveSearch(ByVal path As String) As Boolean
        ShowwaitCursor()
        If path = "" Then
            Return False
            Exit Function
        End If
        Dim dirInfo As New IO.DirectoryInfo(path)
        Dim fileObject As FileSystemInfo
        Dim file As String
        Try
            For Each fileObject In dirInfo.GetFileSystemInfos()
                If (fileObject.Attributes And FileAttributes.Directory) = FileAttributes.Directory Then
                    If cbRecursive.Checked = True Then
                        m_FolderCounter += 1
                        RecursiveSearch(fileObject.FullName)
                    End If
                Else
                    If LCase(Microsoft.VisualBasic.Right(fileObject.Extension.ToString, 3)) = (zFileExtension) Then
                        m_FileCounter += 1
                        If zSelectedDirectory.Length = 3 Then
                            zSelectedDirectory = Mid(zSelectedDirectory, 1, zSelectedDirectory.Length - 1)
                        End If
                        file = Mid(fileObject.FullName.ToString, zSelectedDirectory.Length + 2, fileObject.FullName.Length)
                        lbShow.Items.Add(file)
                    End If
                End If
            Next
        Catch ex As Exception
            My.Computer.FileSystem.WriteAllText(zLogfile, ex.Message & vbCrLf, True)
            My.Computer.FileSystem.WriteAllText(zErrorLogfile, ex.Message & vbCrLf, True)

        End Try
        Return True
    End Function


    Private Sub EXEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXEToolStripMenuItem.Click
        lblCurrentDirectory.Text = "current:"
        zSelectedDirectory = zLocApplications
        lblCurrentDirectory.Text += " " & zLocApplications
        btnSingleFile.Enabled = False
        zFileExtension = "exe"
        listFiles()
        btnClearListSelected.PerformClick()
    End Sub


    Private Sub btnSignAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllFiles.Click
        lbShow.SelectionMode = SelectionMode.MultiExtended
        ShowwaitCursor()
        For i As Integer = 0 To lbShow.Items.Count - 1
            lbShow.SetSelected(i, True)
            lbSelectedFiles.Items.Add(lbShow.Items(i))
        Next
        ShowDefaultCursor()
        Me.TopMost = False
    End Sub


    Private Sub btnSignSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSingleFile.Click
        Try
            lbSelectedFiles.Items.Add(lbShow.SelectedItem.ToString)
        Catch ex As Exception

        End Try
        lbShow.Refresh()
        Me.TopMost = False
    End Sub


    Private Sub btnClearListSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearListSelected.Click
        lbSelectedFiles.Items.Clear()
    End Sub


    Private Sub VBScriptFilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VBScriptFilesToolStripMenuItem.Click
        lblCurrentDirectory.Text = "current:"
        btnSingleFile.Enabled = False
        zSelectedDirectory = zLocVBScripts
        lblCurrentDirectory.Text += " " & zLocVBScripts
        zFileExtension = "vbs"
        listFiles()
        btnClearListSelected.PerformClick()
    End Sub


    Private Sub PowerShellFilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PowerShellFilesToolStripMenuItem.Click
        lblCurrentDirectory.Text = "current:"
        btnSingleFile.Enabled = False
        zSelectedDirectory = zLocPowerShell
        lblCurrentDirectory.Text += " " & zLocPowerShell
        zFileExtension = "ps1"
        listFiles()
        btnClearListSelected.PerformClick()
    End Sub


    Private Sub RDPFilesToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDPFilesToolStripMenuItem2.Click
        lblCurrentDirectory.Text = "current:"
        btnSingleFile.Enabled = False
        zSelectedDirectory = zLocRDPFiles
        lblCurrentDirectory.Text += " " & zLocRDPFiles
        zFileExtension = "rdp"
        listFiles()
        btnClearListSelected.PerformClick()
    End Sub


    Private Sub MSIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MSIToolStripMenuItem.Click
        lblCurrentDirectory.Text = "current:"
        btnSingleFile.Enabled = False
        zSelectedDirectory = zLocMSIFiles
        lblCurrentDirectory.Text += " " & zLocMSIFiles
        zFileExtension = "msi"
        listFiles()
        btnClearListSelected.PerformClick()
    End Sub


    Private Sub lbShow_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbShow.SelectedValueChanged
        btnSingleFile.Enabled = True
        If lbShow.Items.Count > 1 Then
            btnAllFiles.Enabled = True
        Else
            btnAllFiles.Enabled = False
        End If
    End Sub


    Private Sub btnSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSign.Click
        '###################################################################################################################################
        'disable the trial version checks

        'Try
        '    Dim dummyfile As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        '    dummyfile += "\LPS\appST_Data.ini"
        '    If license.trialExpired = True _
        '        Or count > license.mintTrialPeriod _
        '        Or My.Computer.Registry.CurrentUser.OpenSubKey("Software\Cookie\stool") Is Nothing _
        '        Or My.Computer.FileSystem.FileExists(dummyfile) Then

        '        Try
        '            Dim fs As FileStream = File.Create(dummyfile, 1024)
        '            Dim info As Byte() = New UTF8Encoding(True).GetBytes("AppData GUID=987bc-7bfee8-386823-aacf8b-38742aab")
        '            fs.Write(info, 0, info.Length)
        '            fs.Close()
        '        Catch ex As Exception
        '        End Try
        '        TrialExpired.Show()

        '    End If
        'Catch ex As Exception
        'End Try
        '###################################################################################################################################

        ShowwaitCursor()
        lbShow.SelectedItems.Clear()
        lblProgress.Visible = True
        lblProgressError.Visible = True
        lblProgressError.Text = ""
        zErrorCount = 0


        My.Computer.FileSystem.WriteAllText(zLogfile, vbCrLf, True)

        Dim itemsCount As Integer = lbSelectedFiles.Items.Count
        If itemsCount > 0 Then
            For i = 0 To itemsCount - 1
                lbSelectedFiles.SelectedIndex = i
                zSelectedFile = lbSelectedFiles.SelectedItem.ToString
                lblProgress.Text = "signing " & zSelectedFile
                lblProgress.ForeColor = Color.Black
                lblProgress.Refresh()
                System.Threading.Thread.Sleep(300)

                ' new--------------------------------------------------------------------
                'check extension of selected file 18.07.2026
                ' Extract the extension and check it (ignoring casing)
                ' rdp signing uses a different method
                If Path.GetExtension(zSelectedFile).ToLowerInvariant() = ".rdp" Then
                    ' Run the sub routine
                    'MessageBox.Show($"Selected file: {Path.GetFileName(zSelectedFile)}")
                    zSelectedRDPFile = zLocRDPFiles & "\" & zSelectedFile
                    RdpSigner.SignRdpWithRegistryPfx(zSelectedRDPFile, zDecryptedPassword, zLogfile, zErrorLogfile)

                Else
                    ' Show the message box with the file name
                    'MessageBox.Show($"Selected file: {Path.GetFileName(zSelectedFile)}")
                    AddSignature()

                    ' Or if you are writing a Console application, use:
                    ' Console.WriteLine($"Selected file: {Path.GetFileName(zSelectedFile)}")
                End If
                'new end -----------------------------------------------------------------

                lblPercentage.Text = Percent(i + 1, itemsCount) & " % completed"
                SigninProgress = True
                Application.DoEvents()
                If CancelLoop = True Then
                    Exit For
                End If
                btnAllFiles.Enabled = False
                btnSingleFile.Enabled = False
            Next
            If CancelLoop = True Then
                lblProgress.Text = "cancelled"
                lblProgress.ForeColor = Color.Black
                lblProgress.Refresh()
                lbSelectedFiles.Items.Clear()
                lbShow.SelectedItems.Clear()
                CancelLoop = False
                ShowDefaultCursor()
                SigninProgress = False
                Me.Refresh()
                Exit Sub
            Else

                zTimeShowProgressLabel = 50
                tmrLblProgress.Enabled = True
                tmrLblProgress.Start()
                lblProgress.Text = "signed " & lbSelectedFiles.Items.Count - zErrorCount & " Files successfully"
                lblProgress.ForeColor = Color.Black
                lblProgress.Refresh()
                btnClearListSelected.PerformClick()
                lbShow.SelectedItems.Clear()
            End If
        Else
            MessageBox.Show("nothing selected")
        End If
        SigninProgress = False
        CancelLoop = False
        ShowDefaultCursor()


    End Sub



    Private Sub AddSignature()
        Dim cert As X509Certificate2
        Dim digitalSignInfo As CRYPTUI_WIZ_DIGITAL_SIGN_INFO
        Dim pSignContext As IntPtr
        Dim pSigningCertContext As IntPtr
        Dim signContext As CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT
        Dim blob() As Byte
        Dim TimeStampURL As String = zLocTimeStampURL
        Dim FileToSign As String = zSelectedDirectory & "\" & zSelectedFile

        Try

            cert = New X509Certificate2(zCertificateFileName, zDecryptedPassword)
            pSigningCertContext = cert.Handle


            digitalSignInfo = New CRYPTUI_WIZ_DIGITAL_SIGN_INFO
            digitalSignInfo.dwSize = Marshal.SizeOf(digitalSignInfo)
            digitalSignInfo.dwSubjectChoice = CRYPTUI_WIZ_DIGITAL_SIGN_SUBJECT_FILE
            digitalSignInfo.pwszFileName = FileToSign
            digitalSignInfo.dwSigningCertChoice = CRYPTUI_WIZ_DIGITAL_SIGN_CERT
            digitalSignInfo.pSigningCertContext = pSigningCertContext
            digitalSignInfo.pwszTimestampURL = TimeStampURL
            digitalSignInfo.dwAdditionalCertChoice = 0
            digitalSignInfo.pSignExtInfo = IntPtr.Zero


            If (Not CryptUIWizDigitalSign( _
                CRYPTUI_WIZ_NO_UI, _
                IntPtr.Zero, _
                vbNullString, _
                digitalSignInfo, _
                pSignContext _
            )) Then
                Throw New Win32Exception(Marshal.GetLastWin32Error(), "CryptUIWizDigitalSign")
            End If


            signContext = Marshal.PtrToStructure(pSignContext, GetType(CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT))
            blob = New Byte(signContext.cbBlob) {}
            Marshal.Copy(signContext.pbBlob, blob, 0, signContext.cbBlob)
            If (Not CryptUIWizFreeDigitalSignContext(pSignContext)) Then
                Throw New Win32Exception(Marshal.GetLastWin32Error(), "CryptUIWizFreeDigitalSignContext")
            End If


            lblProgress.Text = "successfully signed"
            lblProgress.ForeColor = Color.Green

            My.Computer.FileSystem.WriteAllText(zLogfile, Date.Now & ":" & zSelectedDirectory & "\" & zSelectedFile & " successfully signed" & vbCrLf, True)
        Catch ex As Win32Exception

            zErrorCount += 1
            My.Computer.FileSystem.WriteAllText(zErrorLogfile, Date.Now & ":" & "while signing : " & zSelectedDirectory & "\" & zSelectedFile & " = " & ex.Message + " error#" + ex.NativeErrorCode.ToString & vbCrLf, True)
            lblProgressError.Text = zErrorCount & " errors occured - see Info - Errors"
        Catch ex As Exception

            zErrorCount += 1
            My.Computer.FileSystem.WriteAllText(zErrorLogfile, Date.Now & ":" & "an error occured : " & ex.Message & vbCrLf, True)
            lblProgressError.Text = zErrorCount & " errors occured - see Info - Errors"
        End Try
    End Sub



    Private Sub lbSelectedFiles_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lbSelectedFiles.DrawItem
        Try
            e.DrawBackground()
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(Brushes.Black, e.Bounds)
            End If
            Using b As New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(lbSelectedFiles.GetItemText(lbSelectedFiles.Items(e.Index)), e.Font, b, e.Bounds)
            End Using
            e.DrawFocusRectangle()
        Catch ex As Exception
        End Try
    End Sub



    Private Sub tmrLblProgress_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrLblProgress.Tick
        zTimeShowProgressLabel -= 1
        If zTimeShowProgressLabel = 25 Then

            Me.TopMost = True
            Me.Refresh()
        End If
        If zTimeShowProgressLabel = 0 Then
            tmrLblProgress.Stop()
            tmrLblProgress.Enabled = False
            lblProgress.Text = ""
            lblProgressError.Text = ""
            lblPercentage.Text = ""
            btnClearListSelected.PerformClick()
        End If
        Me.TopMost = False
    End Sub


    Private Sub ShowwaitCursor()
        Me.Text = "Digital Signatures Tool - ...please wait"
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        btnAllFiles.Enabled = False
        btnSingleFile.Enabled = False
        btnClearListSelected.Enabled = False
        btnSign.Enabled = False
        btnClearShowItems.Enabled = False
        cbRecursive.Enabled = False
        VBScriptFilesToolStripMenuItem.Enabled = False
        PowerShellFilesToolStripMenuItem.Enabled = False
        EXEToolStripMenuItem.Enabled = False
        MSIToolStripMenuItem.Enabled = False
        OptionsToolStripMenuItem.Enabled = False
        AboutToolStripMenuItem.Enabled = False
    End Sub


    Private Sub ShowDefaultCursor()
        Me.Text = "Digital Signatures Tool"
        Me.Cursor = System.Windows.Forms.Cursors.Default
        btnAllFiles.Enabled = True
        btnSingleFile.Enabled = True
        btnClearListSelected.Enabled = True
        btnSign.Enabled = True
        btnClearShowItems.Enabled = True
        cbRecursive.Enabled = True
        VBScriptFilesToolStripMenuItem.Enabled = True
        PowerShellFilesToolStripMenuItem.Enabled = True
        EXEToolStripMenuItem.Enabled = True
        MSIToolStripMenuItem.Enabled = True
        OptionsToolStripMenuItem.Enabled = True
        AboutToolStripMenuItem.Enabled = True
    End Sub


    Public Sub New()

        InitializeComponent()

    End Sub


    Private Sub ErrorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ErrorsToolStripMenuItem.Click
        System.Diagnostics.Process.Start("notepad.exe", zErrorLogfile)
    End Sub


    Private Sub OpenLogfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenLogfileToolStripMenuItem.Click
        System.Diagnostics.Process.Start("notepad.exe", zLogfile)
    End Sub



    Private Sub CheckAuthorization()
        If zTestmode = False Then
            Dim aName As String = System.Security.Principal.WindowsIdentity.GetCurrent.Name
            Dim aDomain As String = aName.Substring(0, aName.IndexOf("\") + 1)
            AppDomain.CurrentDomain.SetPrincipalPolicy( _
                 System.Security.Principal.PrincipalPolicy.WindowsPrincipal)
            Try
                If Not Thread.CurrentPrincipal.IsInRole(aDomain & zAccessGroup) Then
                    Me.Hide()
                    Me.Enabled = False
                    Options.Hide()
                    Options.Enabled = False
                    Options.Dispose()
                    SplashScreen1.Enabled = False
                    SplashScreen1.Dispose()
                    SplashScreen1.Close()
                    MessageBox.Show("Access Denied - not a member of group 'SignatureToolUser'", "Digital Signature Tool", MessageBoxButtons.OK)
                    System.Diagnostics.Process.GetCurrentProcess.Kill()
                End If
            Catch ex As Exception
                Me.Hide()
                Me.Enabled = False
                Options.Hide()
                Options.Enabled = False
                Options.Dispose()
                SplashScreen1.Enabled = False
                SplashScreen1.Dispose()
                SplashScreen1.Close()
                MessageBox.Show("Access Denied - not a member of group 'SignatureToolUser'", "Digital Signature Tool", MessageBoxButtons.OK)
                System.Diagnostics.Process.GetCurrentProcess.Kill()
            End Try
        End If
    End Sub


    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Me.TopMost = False
        AboutBox1.Show()
    End Sub



    Private Sub verifyCert()

        My.Computer.FileSystem.WriteAllText(zLogfile, "Certificate Information : " & vbCrLf, True)
        fileExists = My.Computer.FileSystem.FileExists(zCertificateFileName)
        Try
            If fileExists = False Then
                Options.Show()
            Else
                Dim Cert As New X509Certificate(zCertificateFileName, zDecryptedPassword)
                Dim isExpired As Boolean
                Dim DateExpired As Date = Cert.GetExpirationDateString
                Select Case DateTime.Compare(DateExpired, Date.UtcNow)
                    Case Is > 0
                        isExpired = False
                    Case Else
                        isExpired = True
                End Select
                Dim strExpiredDate As String = (DateExpired.ToString("D", Globalization.CultureInfo.CreateSpecificCulture("en-US")))
                My.Computer.FileSystem.WriteAllText(zLogfile, "----------------------------------------------------------------------------------------------------------------------------" & vbCrLf, True)
                If (isExpired = True) Then
                    lblCertName.Font = New Font(lblCertName.Font, FontStyle.Bold)
                    lblCertName.ForeColor = Color.Red
                    lblCertName.Text = "Certificate has been expired - see 'About'"
                    My.Computer.FileSystem.WriteAllText(zLogfile, "this Certificate IS NOT VALID ANYMORE" & Date.Now & vbCrLf, True)
                    My.Computer.FileSystem.WriteAllText(zErrorLogfile, "this Certificate IS NOT VALID ANYMORE" & Date.Now & vbCrLf, True)
                    btnAllFiles.Enabled = False
                    btnClearListSelected.Enabled = False
                    btnSign.Enabled = False
                    btnSingleFile.Enabled = False
                 
                Else
                    lblCertName.Text = "Certificate is valid until " & strExpiredDate
                 
                End If
                My.Computer.FileSystem.WriteAllText(zLogfile, "DateTime              : " & Date.Now & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "Subject               : " & Cert.Subject & vbCrLf, True)
                lblCertInfo.Text = zCertificateFileName
                My.Computer.FileSystem.WriteAllText(zLogfile, "File Name             : " & zCertificateFileName & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "Expired               : " & isExpired.ToString & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "Issued by             : " & Cert.Issuer & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "Serial Number         : " & Cert.GetSerialNumberString & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "valid from            : " & Cert.GetEffectiveDateString & vbCrLf, True)
                My.Computer.FileSystem.WriteAllText(zLogfile, "valid to              : " & DateExpired.ToString & vbCrLf, True)
                zSubjectDN = Cert.Subject.ToString
            End If
            Options.lblWarning.Visible = False
        Catch ex As Exception
            Options.lblWarning.Visible = True
            Options.lblWarning.Text = "check config : " & ex.Message
            lblCertInfo.Text = "check config : " & ex.Message
            Options.Show()
        End Try
    End Sub



    Private Function InternetConnection() As Boolean
        Try
            Dim req As System.Net.WebRequest = System.Net.WebRequest.Create(zInetCheckURL)
            Dim resp As System.Net.WebResponse
            resp = req.GetResponse()
            resp.Close()
            req = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function



    Private Sub cbRecursive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbRecursive.CheckedChanged
        listFiles()
        If Not lbShow.Items.Count = 0 Then

            btnSingleFile.Enabled = True
            btnAllFiles.Enabled = True
        Else
            btnSingleFile.Enabled = False
            btnAllFiles.Enabled = False
        End If
    End Sub


    Private Sub btnClearShowItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearShowItems.Click
        lbShow.Items.Clear()
        lblFolderInfo.Text = ("")
        btnSingleFile.Enabled = False
        btnAllFiles.Enabled = False
    End Sub



    Private Sub lbShow_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles lbShow.DrawItem
        Try
            e.DrawBackground()
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(Brushes.Black, e.Bounds)
            End If
            Using b As New SolidBrush(e.ForeColor)
                e.Graphics.DrawString(lbShow.GetItemText(lbShow.Items(e.Index)), e.Font, b, e.Bounds)
            End Using
            e.DrawFocusRectangle()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub lbShow_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbShow.SelectedIndexChanged
        If lbShow.Items.Count > 1 Then
            btnAllFiles.Enabled = True
        Else
            btnAllFiles.Enabled = False
        End If
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        CancelLoop = True
    End Sub


    Private Sub btnCancel_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.MouseHover
        Me.Cursor = Cursors.Default
        btnCancel.ForeColor = Color.Red
    End Sub


    Private Sub btnCancel_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.MouseLeave
        If SigninProgress = True Then
            btnCancel.ForeColor = Color.Black
            Me.Cursor = Cursors.WaitCursor
        End If
    End Sub


    Private Function Percent(ByVal CurrVal As Long, ByVal MaxVal As Long) As Integer
        Return Int(CurrVal / MaxVal * 100 + 0.5)
    End Function


    Private Sub CABToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CABToolStripMenuItem.Click
        lblCurrentDirectory.Text = "current:"
        btnSingleFile.Enabled = False
        zSelectedDirectory = zLocCABFiles
        lblCurrentDirectory.Text += " " & zLocCABFiles
        zFileExtension = "cab"
        listFiles()
        btnClearListSelected.PerformClick()
    End Sub


    Private Sub LicenseAgreementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LicenseAgreementToolStripMenuItem.Click
        eula.Show()
    End Sub



    Private Sub CreateDummyDirectory()
        Dim dummyDir As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        dummyDir += "\LPS"
        Dim folderExists As Boolean
        folderExists = My.Computer.FileSystem.DirectoryExists(dummyDir)
        If folderExists = False Then
            My.Computer.FileSystem.CreateDirectory(dummyDir)
        End If
    End Sub



    Private Sub BuyFullVersionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=S6YPPFDTRPWP2")
    End Sub



    Private Sub CreateSelfsignedCertificateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateSelfsignedCertificateToolStripMenuItem.Click
        createCert.Show()
    End Sub


End Class
