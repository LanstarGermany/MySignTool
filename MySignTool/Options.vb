Imports System.IO
Imports System.Security.Cryptography
Imports Microsoft.Win32
Imports System.Security.Cryptography.X509Certificates



Public Class Options



    Private Sub btnBrowsevbs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowsevbs.Click
        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog
        MyFolderBrowser.Description = "Select the Folder"

        MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.OK Then
            Main.zLocVBScripts = MyFolderBrowser.SelectedPath
            rtbVBScripts.Text = Main.zLocVBScripts
        End If
        btnBrowsevbs.ForeColor = Color.Green
        btnBrowsevbs.BackColor = Color.GhostWhite
        btnBrowsevbs.Text = "changed"
    End Sub


    Private Sub btnBrowsePS1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowsePS1.Click
        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog
        MyFolderBrowser.Description = "Select the Folder"

        MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.OK Then
            Main.zLocPowerShell = MyFolderBrowser.SelectedPath
            rtbPowerShell.Text = Main.zLocPowerShell
        End If
        btnBrowsePS1.ForeColor = Color.Green
        btnBrowsePS1.BackColor = Color.GhostWhite
        btnBrowsePS1.Text = "changed"
    End Sub


    Private Sub btnBrowseEXE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseEXE.Click
        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog
        MyFolderBrowser.Description = "Select the Folder"

        MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.OK Then
            Main.zLocApplications = MyFolderBrowser.SelectedPath
            rtbApplications.Text = Main.zLocApplications
        End If
        btnBrowseEXE.ForeColor = Color.Green
        btnBrowseEXE.BackColor = Color.GhostWhite
        btnBrowseEXE.Text = "changed"
    End Sub





    Private Sub btnBrowseMSI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseMSI.Click
        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog
        MyFolderBrowser.Description = "Select the Folder"

        MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.OK Then
            Main.zLocMSIFiles = MyFolderBrowser.SelectedPath
            rtbMSIFiles.Text = Main.zLocMSIFiles
        End If
        btnBrowseMSI.ForeColor = Color.Green
        btnBrowseMSI.BackColor = Color.GhostWhite
        btnBrowseMSI.Text = "changed"
    End Sub

    Private Sub lblSaveSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSaveSettings.Click
        btnTimeStampURL.PerformClick()
        If Main.count < 2 Then
          
            If My.Computer.Registry.CurrentUser.OpenSubKey("Software\Lanstar\SigningTool") IsNot Nothing Then
                Main.zLocApplications = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkApplicationsPath", "Default Value")
                Main.zLocMSIFiles = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkMSIPath", "Default Value")
                Main.zLocRDPFiles = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkRDPPath", "Default Value")
                Main.zLocPowerShell = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkPowerShellPath", "Default Value")
                Main.zLocVBScripts = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkVBScriptPath", "Default Value")
                Main.zLocCABFiles = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkCABPath", "Default Value")
                Main.zLocPDFFiles = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkPDFPath", "Default Value")
                Main.zLocTimeStampURL = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkTimeStampURL", "Default Value")
            End If
            My.Computer.Registry.CurrentUser.Close()
        End If
        Main.Show()
        Me.Close()
    End Sub


    Private Sub Options_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Main.Show()
    End Sub


    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If My.Computer.Registry.CurrentUser.OpenSubKey("Software\Lanstar\SigningTool") IsNot Nothing Then
                rtbApplications.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkApplicationsPath", "Default Value")
                rtbMSIFiles.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkMSIPath", "Default Value")
                rtbRDPFiles.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkRDPPath", "Default Value")
                rtbPowerShell.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkPowerShellPath", "Default Value")
                rtbVBScripts.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkVBScriptPath", "Default Value")
                rtbCABFiles.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkCABPath", "Default Value")
                rtbPDFFiles.Text = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkPDFPath", "Default Value")
                rtbTimeStampURL = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkTimeStampURL", "Default Value")
                rtbTimeStampURL.Refresh()
            End If
        Catch ex As Exception
        End Try
        If Main.OptionsCalled = True Then
            lblWarning.Text = ""
        End If
        Dim oEncryptedPassword As New Crypto(Main.zPassword)
        lblCertWarning.Text = ""

        rtbCertificateFileName.Text = Main.zCertificateFileName
        tbPassword.Text = oEncryptedPassword.decryptString(Main.zPassword)


        Dim fileExists As Boolean = My.Computer.FileSystem.FileExists(Main.zCertificateFileName)
        If fileExists = False Then
            lblCertWarning.Text = "cannot find Certificate File!"
        End If
        Main.OptionsCalled = True


        'Dim newKey As RegistryKey
        'newKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\FearZone\Cookie")
        'My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\FearZone\Cookie", "rkIsInstalled", "done")


    End Sub


    Private Sub btnCertificatefileName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCertificatefileName.Click
        Dim openFileDialog1 As New OpenFileDialog()
        lblCertWarning.Text = ""
        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "pfx files (*.pfx)|*.pfx"
        openFileDialog1.FilterIndex = 1
        openFileDialog1.RestoreDirectory = True
        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Main.zCertificateFileName = openFileDialog1.FileName
            rtbCertificateFileName.Text = Main.zCertificateFileName
        End If
        btnCertificatefileName.ForeColor = Color.Green
        btnCertificatefileName.BackColor = Color.GhostWhite
        btnCertificatefileName.Text = "changed"
    End Sub


    Private Sub btnPasswordSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasswordSave.Click

        Dim oPassword As New Crypto(tbPassword.Text)
        Dim encryptedPwd As String = oPassword.encryptString(tbPassword.Text)

        Dim newKey As RegistryKey
        newKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Lanstar\SigningTool")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkpfxpwd", encryptedPwd)
        Main.zPassword = encryptedPwd
        Main.zDecryptedPassword = tbPassword.Text
        btnPasswordSave.ForeColor = Color.Green
        btnPasswordSave.BackColor = Color.GhostWhite
        btnPasswordSave.Text = "changed"
        verifyCert()
    End Sub

    
    Private Sub rtbVBScripts_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbVBScripts.TextChanged
        Dim newKey As RegistryKey
        newKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Lanstar\SigningTool")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkVBScriptPath", rtbVBScripts.Text)
    End Sub


    Private Sub rtbPowerShell_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbPowerShell.TextChanged
        Dim newKey As RegistryKey
        newKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Lanstar\SigningTool")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkPowerShellPath", rtbPowerShell.Text)
    End Sub


    Private Sub rtbApplications_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbApplications.TextChanged
        Dim newKey As RegistryKey
        newKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Lanstar\SigningTool")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkApplicationsPath", rtbApplications.Text)
    End Sub


    Private Sub rtbMSIFiles_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbMSIFiles.TextChanged
        Dim newKey As RegistryKey
        newKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Lanstar\SigningTool")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkMSIPath", rtbMSIFiles.Text)
    End Sub


    Private Sub rtbRDPFiles_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbRDPFiles.TextChanged
        Dim newKey As RegistryKey
        newKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Lanstar\SigningTool")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkRDPPath", rtbRDPFiles.Text)
    End Sub


    Private Sub rtbCertificateFileName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbCertificateFileName.TextChanged
        Dim newKey As RegistryKey
        newKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Lanstar\SigningTool")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkCertFileName", rtbCertificateFileName.Text)
    End Sub


    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Main.Show()
        Me.Close()
    End Sub


    Private Sub btnTimeStampURL_Click(sender As System.Object, e As System.EventArgs) Handles btnTimeStampURL.Click
        Dim newKey As RegistryKey
        newKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Lanstar\SigningTool")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkTimeStampURL", rtbTimeStampURL.Text)

        btnTimeStampURL.ForeColor = Color.Green
        btnTimeStampURL.BackColor = Color.GhostWhite
        btnTimeStampURL.Text = "changed"
        Main.lblInternetConnectionOK.Text = rtbTimeStampURL.Text
    End Sub


    Private Sub btnRestoreDefaults_Click(sender As System.Object, e As System.EventArgs) Handles btnRestoreDefaults.Click
        rtbVBScripts.Text = "C:\soft\Signing\vbScript"
        rtbVBScripts.Refresh()
        rtbPowerShell.Text = "C:\soft\Signing\PowerShell"
        rtbPowerShell.Refresh()
        rtbApplications.Text = "C:\soft\Signing\Applications"
        rtbApplications.Refresh()
        rtbMSIFiles.Text = "C:\soft\Signing\MSI_Files"
        rtbMSIFiles.Refresh()
        rtbRDPFiles.Text = "C:\soft\Signing\RDP_Files"
        rtbRDPFiles.Refresh()
        rtbCABFiles.Text = "C:\soft\Signing\CAB_Files"
        rtbCABFiles.Refresh()
        rtbPDFFiles.Text = "C:\soft\Signing\PDF_Files"
        rtbPDFFiles.Refresh()
        rtbCertificateFileName.Text = "Choose Certificate"
        rtbCertificateFileName.Refresh()
        tbPassword.Text = "*******"
        rtbTimeStampURL.Text = "http://timestamp.digicert.com"
        rtbTimeStampURL.Refresh()

        Dim folderExists As Boolean
        folderExists = My.Computer.FileSystem.DirectoryExists("C:\soft")
        If folderExists = False Then
            My.Computer.FileSystem.CreateDirectory("C:\soft")
        End If
        folderExists = My.Computer.FileSystem.DirectoryExists("C:\soft\Signing")
        If folderExists = False Then
            My.Computer.FileSystem.CreateDirectory("C:\soft\Signing")
        End If
        folderExists = My.Computer.FileSystem.DirectoryExists("C:\soft\Signing\vbScript")
        If folderExists = False Then
            My.Computer.FileSystem.CreateDirectory("C:\soft\Signing\vbScript")
        End If
        folderExists = My.Computer.FileSystem.DirectoryExists("C:\soft\Signing\PowerShell")
        If folderExists = False Then
            My.Computer.FileSystem.CreateDirectory("C:\soft\Signing\PowerShell")
        End If
        folderExists = My.Computer.FileSystem.DirectoryExists("C:\soft\Signing\Applications")
        If folderExists = False Then
            My.Computer.FileSystem.CreateDirectory("C:\soft\Signing\Applications")
        End If
        folderExists = My.Computer.FileSystem.DirectoryExists("C:\soft\Signing\MSI_Files")
        If folderExists = False Then
            My.Computer.FileSystem.CreateDirectory("C:\soft\Signing\MSI_Files")
        End If
        folderExists = My.Computer.FileSystem.DirectoryExists("C:\soft\Signing\RDP_Files")
        If folderExists = False Then
            My.Computer.FileSystem.CreateDirectory("C:\soft\Signing\RDP_Files")
        End If
        folderExists = My.Computer.FileSystem.DirectoryExists("C:\soft\Signing\CAB_Files")
        If folderExists = False Then
            My.Computer.FileSystem.CreateDirectory("C:\soft\Signing\CAB_Files")
        End If
        folderExists = My.Computer.FileSystem.DirectoryExists("C:\soft\Signing\PDF_Files")
        If folderExists = False Then
            My.Computer.FileSystem.CreateDirectory("C:\soft\Signing\PDF_Files")
        End If
        btnTimeStampURL.PerformClick()
        btnBrowseEXE.ForeColor = Color.Green
        btnBrowseEXE.BackColor = Color.GhostWhite
        btnBrowseEXE.Text = "changed"
        btnBrowseMSI.ForeColor = Color.Green
        btnBrowseMSI.BackColor = Color.GhostWhite
        btnBrowseMSI.Text = "changed"
        btnBrowseRDP.ForeColor = Color.Green
        btnBrowseRDP.BackColor = Color.GhostWhite
        btnBrowseRDP.Text = "changed"
        btnBrowseCAB.ForeColor = Color.Green
        btnBrowseCAB.BackColor = Color.GhostWhite
        btnBrowseCAB.Text = "changed"
        btnBrowsePDF.ForeColor = Color.Green
        btnBrowsePDF.BackColor = Color.GhostWhite
        btnBrowsePDF.Text = "changed"
        btnBrowsePS1.ForeColor = Color.Green
        btnBrowsePS1.BackColor = Color.GhostWhite
        btnBrowsePS1.Text = "changed"
        btnBrowsevbs.ForeColor = Color.Green
        btnBrowsevbs.BackColor = Color.GhostWhite
        btnBrowsevbs.Text = "changed"
        btnCertificatefileName.ForeColor = Color.Red
        btnCertificatefileName.Text = "change"
        btnPasswordSave.ForeColor = Color.Red
        btnPasswordSave.Text = "change"
    End Sub


    Private Sub verifyCert()

        Dim fileexists As Boolean
        fileexists = My.Computer.FileSystem.FileExists(Main.zCertificateFileName)
        Try
            If fileExists = False Then
            Else
                Dim Cert As New X509Certificate(Main.zCertificateFileName, Main.zDecryptedPassword)
                Dim isExpired As Boolean
                Dim DateExpired As Date = Cert.GetExpirationDateString
                Select Case DateTime.Compare(DateExpired, Date.UtcNow)
                    Case Is > 0
                        isExpired = False
                    Case Else
                        isExpired = True
                End Select
                Dim strExpiredDate As String = (DateExpired.ToString("D", Globalization.CultureInfo.CreateSpecificCulture("en-US")))
                If (isExpired = True) Then
                    Main.lblCertName.Font = New Font(Main.lblCertName.Font, FontStyle.Bold)
                    Main.lblCertName.ForeColor = Color.Red
                    Main.lblCertName.Text = "Certificate has been expired - see 'About'"
                Else
                    Main.lblCertName.Text = "Certificate is valid until " & strExpiredDate
                End If
                Main.lblCertInfo.Text = Main.zCertificateFileName
            End If
        Catch ex As Exception
            Main.lblCertInfo.Text = "wrong Certificate password !"
            Main.lblCertName.Text = ""
        End Try
    End Sub


    Private Sub tbPassword_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbPassword.MouseClick
        tbPassword.Text = ""
    End Sub

   
    Private Sub rtbCABFiles_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbCABFiles.TextChanged
        Dim newKey As RegistryKey
        newKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Lanstar\SigningTool")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkCABPath", rtbCABFiles.Text)
    End Sub


    Private Sub btnBrowseCAB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseCAB.Click
        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog
        MyFolderBrowser.Description = "Select the Folder"

        MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.OK Then
            Main.zLocCABFiles = MyFolderBrowser.SelectedPath
            rtbCABFiles.Text = Main.zLocCABFiles
        End If
        btnBrowseCAB.ForeColor = Color.Green
        btnBrowseCAB.BackColor = Color.GhostWhite
        btnBrowseCAB.Text = "changed"
    End Sub


    Private Sub rtbPDFFiles_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rtbPDFFiles.TextChanged
        Dim newKey As RegistryKey
        newKey = My.Computer.Registry.CurrentUser.CreateSubKey("Software\Lanstar\SigningTool")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Lanstar\SigningTool", "rkPDFPath", rtbPDFFiles.Text)
    End Sub


    Private Sub btnBrowsePDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowsePDF.Click
        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog
        MyFolderBrowser.Description = "Select the Folder"

        MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.OK Then
            Main.zLocPDFFiles = MyFolderBrowser.SelectedPath
            rtbPDFFiles.Text = Main.zLocPDFFiles
        End If
        btnBrowsePDF.ForeColor = Color.Green
        btnBrowsePDF.BackColor = Color.GhostWhite
        btnBrowsePDF.Text = "changed"
    End Sub

    Private Sub btnBrowseRDP_Click(sender As Object, e As EventArgs) Handles btnBrowseRDP.Click
        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog
        MyFolderBrowser.Description = "Select the Folder"

        MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.OK Then
            Main.zLocRDPFiles = MyFolderBrowser.SelectedPath
            rtbRDPFiles.Text = Main.zLocRDPFiles
        End If
        btnBrowseRDP.ForeColor = Color.Green
        btnBrowseRDP.BackColor = Color.GhostWhite
        btnBrowseRDP.Text = "changed"
    End Sub


End Class