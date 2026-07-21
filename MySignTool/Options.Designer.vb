<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Options))
        Me.rtbVBScripts = New System.Windows.Forms.RichTextBox()
        Me.rtbPowerShell = New System.Windows.Forms.RichTextBox()
        Me.rtbApplications = New System.Windows.Forms.RichTextBox()
        Me.lblVBS = New System.Windows.Forms.Label()
        Me.lblPowerShell = New System.Windows.Forms.Label()
        Me.lblExecutables = New System.Windows.Forms.Label()
        Me.lblMSIFiles = New System.Windows.Forms.Label()
        Me.rtbMSIFiles = New System.Windows.Forms.RichTextBox()
        Me.btnBrowsevbs = New System.Windows.Forms.Button()
        Me.btnBrowsePS1 = New System.Windows.Forms.Button()
        Me.btnBrowseEXE = New System.Windows.Forms.Button()
        Me.btnBrowseMSI = New System.Windows.Forms.Button()
        Me.lblSaveSettings = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblCertificateFile = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.rtbCertificateFileName = New System.Windows.Forms.RichTextBox()
        Me.btnCertificatefileName = New System.Windows.Forms.Button()
        Me.btnPasswordSave = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblTimeStampURL = New System.Windows.Forms.Label()
        Me.rtbTimeStampURL = New System.Windows.Forms.RichTextBox()
        Me.btnTimeStampURL = New System.Windows.Forms.Button()
        Me.btnRestoreDefaults = New System.Windows.Forms.Button()
        Me.lblCertWarning = New System.Windows.Forms.Label()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.btnBrowseCAB = New System.Windows.Forms.Button()
        Me.rtbCABFiles = New System.Windows.Forms.RichTextBox()
        Me.lblCABFiles = New System.Windows.Forms.Label()
        Me.btnBrowsePDF = New System.Windows.Forms.Button()
        Me.lblPDFFiles = New System.Windows.Forms.Label()
        Me.rtbPDFFiles = New System.Windows.Forms.RichTextBox()
        Me.lblRDPFiles = New System.Windows.Forms.Label()
        Me.rtbRDPFiles = New System.Windows.Forms.RichTextBox()
        Me.btnBrowseRDP = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rtbVBScripts
        '
        Me.rtbVBScripts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbVBScripts.Location = New System.Drawing.Point(175, 19)
        Me.rtbVBScripts.Name = "rtbVBScripts"
        Me.rtbVBScripts.ReadOnly = True
        Me.rtbVBScripts.Size = New System.Drawing.Size(299, 21)
        Me.rtbVBScripts.TabIndex = 0
        Me.rtbVBScripts.Text = ""
        '
        'rtbPowerShell
        '
        Me.rtbPowerShell.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbPowerShell.Location = New System.Drawing.Point(175, 63)
        Me.rtbPowerShell.Name = "rtbPowerShell"
        Me.rtbPowerShell.ReadOnly = True
        Me.rtbPowerShell.Size = New System.Drawing.Size(299, 21)
        Me.rtbPowerShell.TabIndex = 1
        Me.rtbPowerShell.Text = ""
        '
        'rtbApplications
        '
        Me.rtbApplications.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbApplications.Location = New System.Drawing.Point(175, 102)
        Me.rtbApplications.Name = "rtbApplications"
        Me.rtbApplications.ReadOnly = True
        Me.rtbApplications.Size = New System.Drawing.Size(299, 21)
        Me.rtbApplications.TabIndex = 3
        Me.rtbApplications.Text = ""
        '
        'lblVBS
        '
        Me.lblVBS.AutoSize = True
        Me.lblVBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVBS.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblVBS.Location = New System.Drawing.Point(59, 19)
        Me.lblVBS.Name = "lblVBS"
        Me.lblVBS.Size = New System.Drawing.Size(85, 13)
        Me.lblVBS.TabIndex = 4
        Me.lblVBS.Text = "VBScripts Folder"
        '
        'lblPowerShell
        '
        Me.lblPowerShell.AutoSize = True
        Me.lblPowerShell.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPowerShell.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblPowerShell.Location = New System.Drawing.Point(25, 66)
        Me.lblPowerShell.Name = "lblPowerShell"
        Me.lblPowerShell.Size = New System.Drawing.Size(127, 13)
        Me.lblPowerShell.TabIndex = 5
        Me.lblPowerShell.Text = "PowerShell Scripts Folder"
        '
        'lblExecutables
        '
        Me.lblExecutables.AutoSize = True
        Me.lblExecutables.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExecutables.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblExecutables.Location = New System.Drawing.Point(56, 105)
        Me.lblExecutables.Name = "lblExecutables"
        Me.lblExecutables.Size = New System.Drawing.Size(96, 13)
        Me.lblExecutables.TabIndex = 7
        Me.lblExecutables.Text = "Applications Folder"
        '
        'lblMSIFiles
        '
        Me.lblMSIFiles.AutoSize = True
        Me.lblMSIFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMSIFiles.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblMSIFiles.Location = New System.Drawing.Point(72, 147)
        Me.lblMSIFiles.Name = "lblMSIFiles"
        Me.lblMSIFiles.Size = New System.Drawing.Size(82, 13)
        Me.lblMSIFiles.TabIndex = 8
        Me.lblMSIFiles.Text = "MSI Files Folder"
        '
        'rtbMSIFiles
        '
        Me.rtbMSIFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbMSIFiles.Location = New System.Drawing.Point(175, 144)
        Me.rtbMSIFiles.Name = "rtbMSIFiles"
        Me.rtbMSIFiles.ReadOnly = True
        Me.rtbMSIFiles.Size = New System.Drawing.Size(299, 21)
        Me.rtbMSIFiles.TabIndex = 9
        Me.rtbMSIFiles.Text = ""
        '
        'btnBrowsevbs
        '
        Me.btnBrowsevbs.Location = New System.Drawing.Point(515, 15)
        Me.btnBrowsevbs.Name = "btnBrowsevbs"
        Me.btnBrowsevbs.Size = New System.Drawing.Size(104, 25)
        Me.btnBrowsevbs.TabIndex = 1
        Me.btnBrowsevbs.Text = "Browse"
        Me.btnBrowsevbs.UseVisualStyleBackColor = True
        '
        'btnBrowsePS1
        '
        Me.btnBrowsePS1.Location = New System.Drawing.Point(516, 60)
        Me.btnBrowsePS1.Name = "btnBrowsePS1"
        Me.btnBrowsePS1.Size = New System.Drawing.Size(104, 25)
        Me.btnBrowsePS1.TabIndex = 2
        Me.btnBrowsePS1.Text = "Browse"
        Me.btnBrowsePS1.UseVisualStyleBackColor = True
        '
        'btnBrowseEXE
        '
        Me.btnBrowseEXE.Location = New System.Drawing.Point(516, 99)
        Me.btnBrowseEXE.Name = "btnBrowseEXE"
        Me.btnBrowseEXE.Size = New System.Drawing.Size(104, 25)
        Me.btnBrowseEXE.TabIndex = 4
        Me.btnBrowseEXE.Text = "Browse"
        Me.btnBrowseEXE.UseVisualStyleBackColor = True
        '
        'btnBrowseMSI
        '
        Me.btnBrowseMSI.Location = New System.Drawing.Point(515, 141)
        Me.btnBrowseMSI.Name = "btnBrowseMSI"
        Me.btnBrowseMSI.Size = New System.Drawing.Size(104, 25)
        Me.btnBrowseMSI.TabIndex = 5
        Me.btnBrowseMSI.Text = "Browse"
        Me.btnBrowseMSI.UseVisualStyleBackColor = True
        '
        'lblSaveSettings
        '
        Me.lblSaveSettings.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblSaveSettings.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblSaveSettings.Location = New System.Drawing.Point(500, 528)
        Me.lblSaveSettings.Name = "lblSaveSettings"
        Me.lblSaveSettings.Size = New System.Drawing.Size(120, 30)
        Me.lblSaveSettings.TabIndex = 9
        Me.lblSaveSettings.Text = "Save Settings"
        Me.lblSaveSettings.UseVisualStyleBackColor = False
        '
        'lblCertificateFile
        '
        Me.lblCertificateFile.AutoSize = True
        Me.lblCertificateFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCertificateFile.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblCertificateFile.Location = New System.Drawing.Point(75, 360)
        Me.lblCertificateFile.Name = "lblCertificateFile"
        Me.lblCertificateFile.Size = New System.Drawing.Size(77, 13)
        Me.lblCertificateFile.TabIndex = 16
        Me.lblCertificateFile.Text = "PFX File Name"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblPassword.Location = New System.Drawing.Point(42, 411)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(110, 13)
        Me.lblPassword.TabIndex = 17
        Me.lblPassword.Text = "Private Key Password"
        '
        'rtbCertificateFileName
        '
        Me.rtbCertificateFileName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbCertificateFileName.Location = New System.Drawing.Point(175, 357)
        Me.rtbCertificateFileName.Name = "rtbCertificateFileName"
        Me.rtbCertificateFileName.ReadOnly = True
        Me.rtbCertificateFileName.Size = New System.Drawing.Size(299, 21)
        Me.rtbCertificateFileName.TabIndex = 18
        Me.rtbCertificateFileName.Text = ""
        '
        'btnCertificatefileName
        '
        Me.btnCertificatefileName.Location = New System.Drawing.Point(515, 354)
        Me.btnCertificatefileName.Name = "btnCertificatefileName"
        Me.btnCertificatefileName.Size = New System.Drawing.Size(104, 25)
        Me.btnCertificatefileName.TabIndex = 6
        Me.btnCertificatefileName.Text = "Browse"
        Me.btnCertificatefileName.UseVisualStyleBackColor = True
        '
        'btnPasswordSave
        '
        Me.btnPasswordSave.Location = New System.Drawing.Point(516, 405)
        Me.btnPasswordSave.Name = "btnPasswordSave"
        Me.btnPasswordSave.Size = New System.Drawing.Size(104, 25)
        Me.btnPasswordSave.TabIndex = 7
        Me.btnPasswordSave.Text = "Change"
        Me.btnPasswordSave.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(34, 528)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 30)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'lblTimeStampURL
        '
        Me.lblTimeStampURL.AutoSize = True
        Me.lblTimeStampURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeStampURL.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblTimeStampURL.Location = New System.Drawing.Point(69, 469)
        Me.lblTimeStampURL.Name = "lblTimeStampURL"
        Me.lblTimeStampURL.Size = New System.Drawing.Size(83, 13)
        Me.lblTimeStampURL.TabIndex = 23
        Me.lblTimeStampURL.Text = "Timestamp URL"
        '
        'rtbTimeStampURL
        '
        Me.rtbTimeStampURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbTimeStampURL.Location = New System.Drawing.Point(175, 461)
        Me.rtbTimeStampURL.Multiline = False
        Me.rtbTimeStampURL.Name = "rtbTimeStampURL"
        Me.rtbTimeStampURL.Size = New System.Drawing.Size(299, 21)
        Me.rtbTimeStampURL.TabIndex = 24
        Me.rtbTimeStampURL.Text = "http://timestamp.digicert.com"
        '
        'btnTimeStampURL
        '
        Me.btnTimeStampURL.Location = New System.Drawing.Point(516, 458)
        Me.btnTimeStampURL.Name = "btnTimeStampURL"
        Me.btnTimeStampURL.Size = New System.Drawing.Size(104, 25)
        Me.btnTimeStampURL.TabIndex = 8
        Me.btnTimeStampURL.Text = "Change"
        Me.btnTimeStampURL.UseVisualStyleBackColor = True
        '
        'btnRestoreDefaults
        '
        Me.btnRestoreDefaults.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnRestoreDefaults.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnRestoreDefaults.Location = New System.Drawing.Point(176, 528)
        Me.btnRestoreDefaults.Name = "btnRestoreDefaults"
        Me.btnRestoreDefaults.Size = New System.Drawing.Size(120, 30)
        Me.btnRestoreDefaults.TabIndex = 25
        Me.btnRestoreDefaults.Text = "Restore Default Paths"
        Me.btnRestoreDefaults.UseVisualStyleBackColor = False
        '
        'lblCertWarning
        '
        Me.lblCertWarning.AutoSize = True
        Me.lblCertWarning.ForeColor = System.Drawing.Color.Red
        Me.lblCertWarning.Location = New System.Drawing.Point(173, 330)
        Me.lblCertWarning.Name = "lblCertWarning"
        Me.lblCertWarning.Size = New System.Drawing.Size(76, 13)
        Me.lblCertWarning.TabIndex = 26
        Me.lblCertWarning.Text = "lblCertWarning"
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(175, 408)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbPassword.Size = New System.Drawing.Size(206, 20)
        Me.tbPassword.TabIndex = 27
        '
        'lblWarning
        '
        Me.lblWarning.AutoSize = True
        Me.lblWarning.ForeColor = System.Drawing.Color.Red
        Me.lblWarning.Location = New System.Drawing.Point(30, 411)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(0, 13)
        Me.lblWarning.TabIndex = 28
        '
        'btnBrowseCAB
        '
        Me.btnBrowseCAB.Location = New System.Drawing.Point(515, 186)
        Me.btnBrowseCAB.Name = "btnBrowseCAB"
        Me.btnBrowseCAB.Size = New System.Drawing.Size(104, 25)
        Me.btnBrowseCAB.TabIndex = 29
        Me.btnBrowseCAB.Text = "Browse"
        Me.btnBrowseCAB.UseVisualStyleBackColor = True
        '
        'rtbCABFiles
        '
        Me.rtbCABFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbCABFiles.Location = New System.Drawing.Point(175, 189)
        Me.rtbCABFiles.Name = "rtbCABFiles"
        Me.rtbCABFiles.ReadOnly = True
        Me.rtbCABFiles.Size = New System.Drawing.Size(299, 21)
        Me.rtbCABFiles.TabIndex = 31
        Me.rtbCABFiles.Text = ""
        '
        'lblCABFiles
        '
        Me.lblCABFiles.AutoSize = True
        Me.lblCABFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCABFiles.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblCABFiles.Location = New System.Drawing.Point(70, 192)
        Me.lblCABFiles.Name = "lblCABFiles"
        Me.lblCABFiles.Size = New System.Drawing.Size(84, 13)
        Me.lblCABFiles.TabIndex = 30
        Me.lblCABFiles.Text = "CAB Files Folder"
        '
        'btnBrowsePDF
        '
        Me.btnBrowsePDF.Enabled = False
        Me.btnBrowsePDF.Location = New System.Drawing.Point(515, 272)
        Me.btnBrowsePDF.Name = "btnBrowsePDF"
        Me.btnBrowsePDF.Size = New System.Drawing.Size(104, 25)
        Me.btnBrowsePDF.TabIndex = 32
        Me.btnBrowsePDF.Text = "Browse"
        Me.btnBrowsePDF.UseVisualStyleBackColor = True
        Me.btnBrowsePDF.Visible = False
        '
        'lblPDFFiles
        '
        Me.lblPDFFiles.AutoSize = True
        Me.lblPDFFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPDFFiles.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblPDFFiles.Location = New System.Drawing.Point(68, 278)
        Me.lblPDFFiles.Name = "lblPDFFiles"
        Me.lblPDFFiles.Size = New System.Drawing.Size(84, 13)
        Me.lblPDFFiles.TabIndex = 33
        Me.lblPDFFiles.Text = "PDF Files Folder"
        Me.lblPDFFiles.UseMnemonic = False
        Me.lblPDFFiles.Visible = False
        '
        'rtbPDFFiles
        '
        Me.rtbPDFFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbPDFFiles.Location = New System.Drawing.Point(175, 275)
        Me.rtbPDFFiles.Name = "rtbPDFFiles"
        Me.rtbPDFFiles.ReadOnly = True
        Me.rtbPDFFiles.Size = New System.Drawing.Size(299, 21)
        Me.rtbPDFFiles.TabIndex = 34
        Me.rtbPDFFiles.Text = "coming soon"
        Me.rtbPDFFiles.Visible = False
        '
        'lblRDPFiles
        '
        Me.lblRDPFiles.AutoSize = True
        Me.lblRDPFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRDPFiles.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblRDPFiles.Location = New System.Drawing.Point(66, 235)
        Me.lblRDPFiles.Name = "lblRDPFiles"
        Me.lblRDPFiles.Size = New System.Drawing.Size(86, 13)
        Me.lblRDPFiles.TabIndex = 35
        Me.lblRDPFiles.Text = "RDP Files Folder"
        Me.lblRDPFiles.UseMnemonic = False
        '
        'rtbRDPFiles
        '
        Me.rtbRDPFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbRDPFiles.Location = New System.Drawing.Point(175, 232)
        Me.rtbRDPFiles.Name = "rtbRDPFiles"
        Me.rtbRDPFiles.ReadOnly = True
        Me.rtbRDPFiles.Size = New System.Drawing.Size(299, 21)
        Me.rtbRDPFiles.TabIndex = 36
        Me.rtbRDPFiles.Text = ""
        '
        'btnBrowseRDP
        '
        Me.btnBrowseRDP.Location = New System.Drawing.Point(515, 229)
        Me.btnBrowseRDP.Name = "btnBrowseRDP"
        Me.btnBrowseRDP.Size = New System.Drawing.Size(104, 25)
        Me.btnBrowseRDP.TabIndex = 37
        Me.btnBrowseRDP.Text = "Browse"
        Me.btnBrowseRDP.UseVisualStyleBackColor = True
        '
        'Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(684, 611)
        Me.Controls.Add(Me.btnBrowseRDP)
        Me.Controls.Add(Me.rtbRDPFiles)
        Me.Controls.Add(Me.lblRDPFiles)
        Me.Controls.Add(Me.rtbPDFFiles)
        Me.Controls.Add(Me.btnBrowsePDF)
        Me.Controls.Add(Me.lblPDFFiles)
        Me.Controls.Add(Me.btnBrowseCAB)
        Me.Controls.Add(Me.rtbCABFiles)
        Me.Controls.Add(Me.lblCABFiles)
        Me.Controls.Add(Me.lblWarning)
        Me.Controls.Add(Me.tbPassword)
        Me.Controls.Add(Me.lblCertWarning)
        Me.Controls.Add(Me.btnRestoreDefaults)
        Me.Controls.Add(Me.btnTimeStampURL)
        Me.Controls.Add(Me.rtbTimeStampURL)
        Me.Controls.Add(Me.lblTimeStampURL)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnPasswordSave)
        Me.Controls.Add(Me.btnCertificatefileName)
        Me.Controls.Add(Me.rtbCertificateFileName)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblCertificateFile)
        Me.Controls.Add(Me.lblSaveSettings)
        Me.Controls.Add(Me.btnBrowseMSI)
        Me.Controls.Add(Me.btnBrowseEXE)
        Me.Controls.Add(Me.btnBrowsePS1)
        Me.Controls.Add(Me.btnBrowsevbs)
        Me.Controls.Add(Me.rtbMSIFiles)
        Me.Controls.Add(Me.lblMSIFiles)
        Me.Controls.Add(Me.lblExecutables)
        Me.Controls.Add(Me.lblPowerShell)
        Me.Controls.Add(Me.lblVBS)
        Me.Controls.Add(Me.rtbApplications)
        Me.Controls.Add(Me.rtbPowerShell)
        Me.Controls.Add(Me.rtbVBScripts)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Options"
        Me.ShowInTaskbar = False
        Me.Text = "SignTool Configuration"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtbVBScripts As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbPowerShell As System.Windows.Forms.RichTextBox
    Friend WithEvents rtbApplications As System.Windows.Forms.RichTextBox
    Friend WithEvents lblVBS As System.Windows.Forms.Label
    Friend WithEvents lblPowerShell As System.Windows.Forms.Label
    Friend WithEvents lblExecutables As System.Windows.Forms.Label
    Friend WithEvents lblMSIFiles As System.Windows.Forms.Label
    Friend WithEvents rtbMSIFiles As System.Windows.Forms.RichTextBox
    Friend WithEvents btnBrowsevbs As System.Windows.Forms.Button
    Friend WithEvents btnBrowsePS1 As System.Windows.Forms.Button
    Friend WithEvents btnBrowseEXE As System.Windows.Forms.Button
    Friend WithEvents btnBrowseMSI As System.Windows.Forms.Button
    Friend WithEvents lblSaveSettings As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblCertificateFile As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents rtbCertificateFileName As System.Windows.Forms.RichTextBox
    Friend WithEvents btnCertificatefileName As System.Windows.Forms.Button
    Friend WithEvents btnPasswordSave As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lblTimeStampURL As System.Windows.Forms.Label
    Friend WithEvents rtbTimeStampURL As System.Windows.Forms.RichTextBox
    Friend WithEvents btnTimeStampURL As System.Windows.Forms.Button
    Friend WithEvents btnRestoreDefaults As System.Windows.Forms.Button
    Friend WithEvents lblCertWarning As System.Windows.Forms.Label
    Friend WithEvents tbPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents btnBrowseCAB As System.Windows.Forms.Button
    Friend WithEvents rtbCABFiles As System.Windows.Forms.RichTextBox
    Friend WithEvents lblCABFiles As System.Windows.Forms.Label
    Friend WithEvents btnBrowsePDF As System.Windows.Forms.Button
    Friend WithEvents lblPDFFiles As System.Windows.Forms.Label
    Friend WithEvents rtbPDFFiles As System.Windows.Forms.RichTextBox
    Friend WithEvents lblRDPFiles As Label
    Friend WithEvents rtbRDPFiles As RichTextBox
    Friend WithEvents btnBrowseRDP As Button
End Class
