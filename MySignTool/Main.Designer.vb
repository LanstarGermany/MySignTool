<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddSignatureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VBScriptFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PowerShellFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RDPFilesToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SignFilesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CABToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateSelfsignedCertificateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenLogfileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LicenseAgreementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lbShow = New System.Windows.Forms.ListBox()
        Me.btnSingleFile = New System.Windows.Forms.Button()
        Me.lblCurrentDirectory = New System.Windows.Forms.Label()
        Me.btnAllFiles = New System.Windows.Forms.Button()
        Me.btnSign = New System.Windows.Forms.Button()
        Me.lbSelectedFiles = New System.Windows.Forms.ListBox()
        Me.lblSelectedFiles = New System.Windows.Forms.Label()
        Me.btnClearListSelected = New System.Windows.Forms.Button()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.tmrLblProgress = New System.Windows.Forms.Timer(Me.components)
        Me.lblProgressError = New System.Windows.Forms.Label()
        Me.lblCertName = New System.Windows.Forms.Label()
        Me.lblCertInfo = New System.Windows.Forms.Label()
        Me.lblInternetConnectionOK = New System.Windows.Forms.Label()
        Me.lblInfoCert = New System.Windows.Forms.Label()
        Me.lblInfoTimeStampServer = New System.Windows.Forms.Label()
        Me.lblFolderInfo = New System.Windows.Forms.Label()
        Me.cbRecursive = New System.Windows.Forms.CheckBox()
        Me.btnClearShowItems = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblPercentage = New System.Windows.Forms.Label()
        Me.lblInstallWarning = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.AddSignatureToolStripMenuItem, Me.SignFilesToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.InfoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(980, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(37, 20)
        Me.ToolStripMenuItem1.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Image = CType(resources.GetObject("ExitToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(93, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'AddSignatureToolStripMenuItem
        '
        Me.AddSignatureToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VBScriptFilesToolStripMenuItem, Me.PowerShellFilesToolStripMenuItem, Me.RDPFilesToolStripMenuItem2})
        Me.AddSignatureToolStripMenuItem.Name = "AddSignatureToolStripMenuItem"
        Me.AddSignatureToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.AddSignatureToolStripMenuItem.Text = "Scripts"
        '
        'VBScriptFilesToolStripMenuItem
        '
        Me.VBScriptFilesToolStripMenuItem.Image = CType(resources.GetObject("VBScriptFilesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.VBScriptFilesToolStripMenuItem.Name = "VBScriptFilesToolStripMenuItem"
        Me.VBScriptFilesToolStripMenuItem.Size = New System.Drawing.Size(191, 26)
        Me.VBScriptFilesToolStripMenuItem.Text = "VBScript Files"
        '
        'PowerShellFilesToolStripMenuItem
        '
        Me.PowerShellFilesToolStripMenuItem.Image = CType(resources.GetObject("PowerShellFilesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PowerShellFilesToolStripMenuItem.Name = "PowerShellFilesToolStripMenuItem"
        Me.PowerShellFilesToolStripMenuItem.Size = New System.Drawing.Size(191, 26)
        Me.PowerShellFilesToolStripMenuItem.Text = "PowerShell Files"
        '
        'RDPFilesToolStripMenuItem2
        '
        Me.RDPFilesToolStripMenuItem2.Image = Global.SignTool.My.Resources.Resources.lock
        Me.RDPFilesToolStripMenuItem2.Name = "RDPFilesToolStripMenuItem2"
        Me.RDPFilesToolStripMenuItem2.Size = New System.Drawing.Size(191, 26)
        Me.RDPFilesToolStripMenuItem2.Text = "RDP Connection Files"
        '
        'SignFilesToolStripMenuItem
        '
        Me.SignFilesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EXEToolStripMenuItem, Me.MSIToolStripMenuItem, Me.CABToolStripMenuItem})
        Me.SignFilesToolStripMenuItem.Name = "SignFilesToolStripMenuItem"
        Me.SignFilesToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.SignFilesToolStripMenuItem.Text = "Applications"
        '
        'EXEToolStripMenuItem
        '
        Me.EXEToolStripMenuItem.Image = CType(resources.GetObject("EXEToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EXEToolStripMenuItem.Name = "EXEToolStripMenuItem"
        Me.EXEToolStripMenuItem.Size = New System.Drawing.Size(97, 22)
        Me.EXEToolStripMenuItem.Text = "EXE"
        '
        'MSIToolStripMenuItem
        '
        Me.MSIToolStripMenuItem.Image = CType(resources.GetObject("MSIToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MSIToolStripMenuItem.Name = "MSIToolStripMenuItem"
        Me.MSIToolStripMenuItem.Size = New System.Drawing.Size(97, 22)
        Me.MSIToolStripMenuItem.Text = "MSI"
        '
        'CABToolStripMenuItem
        '
        Me.CABToolStripMenuItem.Image = Global.SignTool.My.Resources.Resources.directory
        Me.CABToolStripMenuItem.Name = "CABToolStripMenuItem"
        Me.CABToolStripMenuItem.Size = New System.Drawing.Size(97, 22)
        Me.CABToolStripMenuItem.Text = "CAB"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateSelfsignedCertificateToolStripMenuItem, Me.OptionsToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'CreateSelfsignedCertificateToolStripMenuItem
        '
        Me.CreateSelfsignedCertificateToolStripMenuItem.Image = Global.SignTool.My.Resources.Resources.certificate1
        Me.CreateSelfsignedCertificateToolStripMenuItem.Name = "CreateSelfsignedCertificateToolStripMenuItem"
        Me.CreateSelfsignedCertificateToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.CreateSelfsignedCertificateToolStripMenuItem.Text = "create self-signed Certificate"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Image = CType(resources.GetObject("OptionsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(224, 22)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'InfoToolStripMenuItem
        '
        Me.InfoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenLogfileToolStripMenuItem, Me.ErrorsToolStripMenuItem, Me.LicenseAgreementToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem"
        Me.InfoToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.InfoToolStripMenuItem.Text = "Info"
        '
        'OpenLogfileToolStripMenuItem
        '
        Me.OpenLogfileToolStripMenuItem.Image = CType(resources.GetObject("OpenLogfileToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenLogfileToolStripMenuItem.Name = "OpenLogfileToolStripMenuItem"
        Me.OpenLogfileToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.OpenLogfileToolStripMenuItem.Text = "open Logfile"
        '
        'ErrorsToolStripMenuItem
        '
        Me.ErrorsToolStripMenuItem.Image = CType(resources.GetObject("ErrorsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ErrorsToolStripMenuItem.Name = "ErrorsToolStripMenuItem"
        Me.ErrorsToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.ErrorsToolStripMenuItem.Text = "open Errorlog"
        '
        'LicenseAgreementToolStripMenuItem
        '
        Me.LicenseAgreementToolStripMenuItem.Image = Global.SignTool.My.Resources.Resources.user
        Me.LicenseAgreementToolStripMenuItem.Name = "LicenseAgreementToolStripMenuItem"
        Me.LicenseAgreementToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.LicenseAgreementToolStripMenuItem.Text = "License agreement"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = CType(resources.GetObject("AboutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'lbShow
        '
        Me.lbShow.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.lbShow.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lbShow.FormattingEnabled = True
        Me.lbShow.HorizontalExtent = 1000
        Me.lbShow.HorizontalScrollbar = True
        Me.lbShow.Location = New System.Drawing.Point(24, 55)
        Me.lbShow.Name = "lbShow"
        Me.lbShow.ScrollAlwaysVisible = True
        Me.lbShow.Size = New System.Drawing.Size(284, 212)
        Me.lbShow.TabIndex = 4
        '
        'btnSingleFile
        '
        Me.btnSingleFile.ForeColor = System.Drawing.Color.Green
        Me.btnSingleFile.Location = New System.Drawing.Point(325, 64)
        Me.btnSingleFile.Name = "btnSingleFile"
        Me.btnSingleFile.Size = New System.Drawing.Size(137, 23)
        Me.btnSingleFile.TabIndex = 5
        Me.btnSingleFile.Text = "select single File >>"
        Me.btnSingleFile.UseVisualStyleBackColor = True
        '
        'lblCurrentDirectory
        '
        Me.lblCurrentDirectory.AutoSize = True
        Me.lblCurrentDirectory.BackColor = System.Drawing.Color.Transparent
        Me.lblCurrentDirectory.Font = New System.Drawing.Font("Arial", 7.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentDirectory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCurrentDirectory.Location = New System.Drawing.Point(21, 36)
        Me.lblCurrentDirectory.Name = "lblCurrentDirectory"
        Me.lblCurrentDirectory.Size = New System.Drawing.Size(49, 12)
        Me.lblCurrentDirectory.TabIndex = 6
        Me.lblCurrentDirectory.Text = "Directory"
        '
        'btnAllFiles
        '
        Me.btnAllFiles.ForeColor = System.Drawing.Color.Green
        Me.btnAllFiles.Location = New System.Drawing.Point(325, 93)
        Me.btnAllFiles.Name = "btnAllFiles"
        Me.btnAllFiles.Size = New System.Drawing.Size(135, 23)
        Me.btnAllFiles.TabIndex = 7
        Me.btnAllFiles.Text = "Select All Files >>"
        Me.btnAllFiles.UseVisualStyleBackColor = True
        '
        'btnSign
        '
        Me.btnSign.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSign.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnSign.Location = New System.Drawing.Point(815, 130)
        Me.btnSign.Name = "btnSign"
        Me.btnSign.Size = New System.Drawing.Size(137, 23)
        Me.btnSign.TabIndex = 8
        Me.btnSign.Text = "Add Signature"
        Me.btnSign.UseVisualStyleBackColor = True
        '
        'lbSelectedFiles
        '
        Me.lbSelectedFiles.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.lbSelectedFiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lbSelectedFiles.FormattingEnabled = True
        Me.lbSelectedFiles.HorizontalExtent = 1000
        Me.lbSelectedFiles.HorizontalScrollbar = True
        Me.lbSelectedFiles.Location = New System.Drawing.Point(514, 55)
        Me.lbSelectedFiles.Name = "lbSelectedFiles"
        Me.lbSelectedFiles.ScrollAlwaysVisible = True
        Me.lbSelectedFiles.Size = New System.Drawing.Size(284, 186)
        Me.lbSelectedFiles.TabIndex = 11
        '
        'lblSelectedFiles
        '
        Me.lblSelectedFiles.AutoSize = True
        Me.lblSelectedFiles.BackColor = System.Drawing.Color.Transparent
        Me.lblSelectedFiles.Font = New System.Drawing.Font("Arial", 7.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectedFiles.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblSelectedFiles.Location = New System.Drawing.Point(511, 36)
        Me.lblSelectedFiles.Name = "lblSelectedFiles"
        Me.lblSelectedFiles.Size = New System.Drawing.Size(74, 12)
        Me.lblSelectedFiles.TabIndex = 12
        Me.lblSelectedFiles.Text = "selected Files"
        '
        'btnClearListSelected
        '
        Me.btnClearListSelected.Location = New System.Drawing.Point(815, 218)
        Me.btnClearListSelected.Name = "btnClearListSelected"
        Me.btnClearListSelected.Size = New System.Drawing.Size(137, 23)
        Me.btnClearListSelected.TabIndex = 13
        Me.btnClearListSelected.Text = "<< clear Selection"
        Me.btnClearListSelected.UseVisualStyleBackColor = True
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.BackColor = System.Drawing.Color.Transparent
        Me.lblProgress.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblProgress.Location = New System.Drawing.Point(511, 253)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(50, 12)
        Me.lblProgress.TabIndex = 14
        Me.lblProgress.Text = "Progress"
        '
        'tmrLblProgress
        '
        Me.tmrLblProgress.Interval = 500
        '
        'lblProgressError
        '
        Me.lblProgressError.AutoSize = True
        Me.lblProgressError.BackColor = System.Drawing.Color.Transparent
        Me.lblProgressError.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgressError.ForeColor = System.Drawing.Color.Red
        Me.lblProgressError.Location = New System.Drawing.Point(511, 282)
        Me.lblProgressError.Name = "lblProgressError"
        Me.lblProgressError.Size = New System.Drawing.Size(70, 11)
        Me.lblProgressError.TabIndex = 15
        Me.lblProgressError.Text = "ProgressError"
        '
        'lblCertName
        '
        Me.lblCertName.AutoSize = True
        Me.lblCertName.BackColor = System.Drawing.Color.Transparent
        Me.lblCertName.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCertName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCertName.Location = New System.Drawing.Point(21, 321)
        Me.lblCertName.Name = "lblCertName"
        Me.lblCertName.Size = New System.Drawing.Size(8, 12)
        Me.lblCertName.TabIndex = 16
        Me.lblCertName.Text = ":"
        '
        'lblCertInfo
        '
        Me.lblCertInfo.AutoSize = True
        Me.lblCertInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblCertInfo.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCertInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblCertInfo.Location = New System.Drawing.Point(22, 309)
        Me.lblCertInfo.Name = "lblCertInfo"
        Me.lblCertInfo.Size = New System.Drawing.Size(0, 12)
        Me.lblCertInfo.TabIndex = 17
        '
        'lblInternetConnectionOK
        '
        Me.lblInternetConnectionOK.AutoSize = True
        Me.lblInternetConnectionOK.BackColor = System.Drawing.Color.Transparent
        Me.lblInternetConnectionOK.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInternetConnectionOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblInternetConnectionOK.Location = New System.Drawing.Point(511, 321)
        Me.lblInternetConnectionOK.Name = "lblInternetConnectionOK"
        Me.lblInternetConnectionOK.Size = New System.Drawing.Size(0, 12)
        Me.lblInternetConnectionOK.TabIndex = 18
        '
        'lblInfoCert
        '
        Me.lblInfoCert.AutoSize = True
        Me.lblInfoCert.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoCert.Font = New System.Drawing.Font("Arial", 7.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoCert.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblInfoCert.Location = New System.Drawing.Point(21, 309)
        Me.lblInfoCert.Name = "lblInfoCert"
        Me.lblInfoCert.Size = New System.Drawing.Size(0, 12)
        Me.lblInfoCert.TabIndex = 19
        '
        'lblInfoTimeStampServer
        '
        Me.lblInfoTimeStampServer.AutoSize = True
        Me.lblInfoTimeStampServer.BackColor = System.Drawing.Color.Transparent
        Me.lblInfoTimeStampServer.Font = New System.Drawing.Font("Arial", 7.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfoTimeStampServer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblInfoTimeStampServer.Location = New System.Drawing.Point(511, 309)
        Me.lblInfoTimeStampServer.Name = "lblInfoTimeStampServer"
        Me.lblInfoTimeStampServer.Size = New System.Drawing.Size(158, 12)
        Me.lblInfoTimeStampServer.TabIndex = 20
        Me.lblInfoTimeStampServer.Text = "Internet Timestamp Server URL"
        '
        'lblFolderInfo
        '
        Me.lblFolderInfo.AutoSize = True
        Me.lblFolderInfo.BackColor = System.Drawing.Color.Transparent
        Me.lblFolderInfo.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolderInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblFolderInfo.Location = New System.Drawing.Point(21, 270)
        Me.lblFolderInfo.Name = "lblFolderInfo"
        Me.lblFolderInfo.Size = New System.Drawing.Size(54, 12)
        Me.lblFolderInfo.TabIndex = 21
        Me.lblFolderInfo.Text = "FolderInfo"
        '
        'cbRecursive
        '
        Me.cbRecursive.AutoSize = True
        Me.cbRecursive.BackColor = System.Drawing.Color.Transparent
        Me.cbRecursive.Location = New System.Drawing.Point(335, 122)
        Me.cbRecursive.Name = "cbRecursive"
        Me.cbRecursive.Size = New System.Drawing.Size(125, 17)
        Me.cbRecursive.TabIndex = 22
        Me.cbRecursive.Text = "including subfolder(s)"
        Me.cbRecursive.UseVisualStyleBackColor = False
        '
        'btnClearShowItems
        '
        Me.btnClearShowItems.Location = New System.Drawing.Point(323, 242)
        Me.btnClearShowItems.Name = "btnClearShowItems"
        Me.btnClearShowItems.Size = New System.Drawing.Size(137, 23)
        Me.btnClearShowItems.TabIndex = 23
        Me.btnClearShowItems.Text = "<< clear Selection"
        Me.btnClearShowItems.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(815, 159)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(137, 23)
        Me.btnCancel.TabIndex = 24
        Me.btnCancel.Text = "cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblPercentage
        '
        Me.lblPercentage.AutoSize = True
        Me.lblPercentage.BackColor = System.Drawing.Color.Transparent
        Me.lblPercentage.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPercentage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblPercentage.Location = New System.Drawing.Point(511, 269)
        Me.lblPercentage.Name = "lblPercentage"
        Me.lblPercentage.Size = New System.Drawing.Size(61, 12)
        Me.lblPercentage.TabIndex = 25
        Me.lblPercentage.Text = "Percentage"
        '
        'lblInstallWarning
        '
        Me.lblInstallWarning.AutoSize = True
        Me.lblInstallWarning.BackColor = System.Drawing.Color.Transparent
        Me.lblInstallWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstallWarning.ForeColor = System.Drawing.Color.Red
        Me.lblInstallWarning.Location = New System.Drawing.Point(29, 282)
        Me.lblInstallWarning.Name = "lblInstallWarning"
        Me.lblInstallWarning.Size = New System.Drawing.Size(0, 29)
        Me.lblInstallWarning.TabIndex = 26
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.BackgroundImage = Global.SignTool.My.Resources.Resources.signature
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(980, 358)
        Me.Controls.Add(Me.lblInstallWarning)
        Me.Controls.Add(Me.lblPercentage)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnClearShowItems)
        Me.Controls.Add(Me.cbRecursive)
        Me.Controls.Add(Me.lblFolderInfo)
        Me.Controls.Add(Me.lblInfoTimeStampServer)
        Me.Controls.Add(Me.lblInfoCert)
        Me.Controls.Add(Me.lblInternetConnectionOK)
        Me.Controls.Add(Me.lblCertInfo)
        Me.Controls.Add(Me.lblCertName)
        Me.Controls.Add(Me.lblProgressError)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.btnClearListSelected)
        Me.Controls.Add(Me.lblSelectedFiles)
        Me.Controls.Add(Me.lbSelectedFiles)
        Me.Controls.Add(Me.btnSign)
        Me.Controls.Add(Me.btnAllFiles)
        Me.Controls.Add(Me.lblCurrentDirectory)
        Me.Controls.Add(Me.btnSingleFile)
        Me.Controls.Add(Me.lbShow)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.Text = "Digital Signatures Tool "
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddSignatureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VBScriptFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PowerShellFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lbShow As System.Windows.Forms.ListBox
    Friend WithEvents btnSingleFile As System.Windows.Forms.Button
    Friend WithEvents lblCurrentDirectory As System.Windows.Forms.Label
    Friend WithEvents btnAllFiles As System.Windows.Forms.Button
    Friend WithEvents btnSign As System.Windows.Forms.Button
    Friend WithEvents lbSelectedFiles As System.Windows.Forms.ListBox
    Friend WithEvents lblSelectedFiles As System.Windows.Forms.Label
    Friend WithEvents btnClearListSelected As System.Windows.Forms.Button
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents tmrLblProgress As System.Windows.Forms.Timer
    Friend WithEvents lblProgressError As System.Windows.Forms.Label
    Friend WithEvents InfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenLogfileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblCertName As System.Windows.Forms.Label
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblCertInfo As System.Windows.Forms.Label
    Friend WithEvents SignFilesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EXEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MSIToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblInternetConnectionOK As System.Windows.Forms.Label
    Friend WithEvents lblInfoCert As System.Windows.Forms.Label
    Friend WithEvents lblInfoTimeStampServer As System.Windows.Forms.Label
    Friend WithEvents lblFolderInfo As System.Windows.Forms.Label
    Friend WithEvents cbRecursive As System.Windows.Forms.CheckBox
    Friend WithEvents btnClearShowItems As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblPercentage As System.Windows.Forms.Label
    Friend WithEvents CABToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LicenseAgreementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateSelfsignedCertificateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblInstallWarning As System.Windows.Forms.Label
    Friend WithEvents RDPFilesToolStripMenuItem2 As ToolStripMenuItem
End Class
