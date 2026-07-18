<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class createCert
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
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblEMail = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbName = New System.Windows.Forms.TextBox()
        Me.tbEmail = New System.Windows.Forms.TextBox()
        Me.gbCreateCert = New System.Windows.Forms.GroupBox()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.btnOpenStore = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.gbCreateCert.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAdd.Location = New System.Drawing.Point(29, 164)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(90, 23)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "add to store"
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(286, 164)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(26, 34)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 13)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Name"
        '
        'lblEMail
        '
        Me.lblEMail.AutoSize = True
        Me.lblEMail.Location = New System.Drawing.Point(26, 69)
        Me.lblEMail.Name = "lblEMail"
        Me.lblEMail.Size = New System.Drawing.Size(73, 13)
        Me.lblEMail.TabIndex = 2
        Me.lblEMail.Text = "eMail Address"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Expiration date"
        '
        'tbName
        '
        Me.tbName.BackColor = System.Drawing.SystemColors.Control
        Me.tbName.Location = New System.Drawing.Point(145, 31)
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(234, 20)
        Me.tbName.TabIndex = 4
        '
        'tbEmail
        '
        Me.tbEmail.BackColor = System.Drawing.SystemColors.Control
        Me.tbEmail.Location = New System.Drawing.Point(145, 66)
        Me.tbEmail.Name = "tbEmail"
        Me.tbEmail.Size = New System.Drawing.Size(234, 20)
        Me.tbEmail.TabIndex = 5
        '
        'gbCreateCert
        '
        Me.gbCreateCert.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.gbCreateCert.Controls.Add(Me.lblResult)
        Me.gbCreateCert.Controls.Add(Me.btnOpenStore)
        Me.gbCreateCert.Controls.Add(Me.DateTimePicker1)
        Me.gbCreateCert.Controls.Add(Me.btnCancel)
        Me.gbCreateCert.Controls.Add(Me.lblName)
        Me.gbCreateCert.Controls.Add(Me.btnAdd)
        Me.gbCreateCert.Controls.Add(Me.lblEMail)
        Me.gbCreateCert.Controls.Add(Me.Label3)
        Me.gbCreateCert.Controls.Add(Me.tbEmail)
        Me.gbCreateCert.Controls.Add(Me.tbName)
        Me.gbCreateCert.Location = New System.Drawing.Point(23, 23)
        Me.gbCreateCert.Name = "gbCreateCert"
        Me.gbCreateCert.Size = New System.Drawing.Size(417, 241)
        Me.gbCreateCert.TabIndex = 7
        Me.gbCreateCert.TabStop = False
        Me.gbCreateCert.Text = "add a certificate to your Personal Certificate store"
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(29, 203)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(39, 13)
        Me.lblResult.TabIndex = 8
        Me.lblResult.Text = "Label1"
        '
        'btnOpenStore
        '
        Me.btnOpenStore.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnOpenStore.Location = New System.Drawing.Point(157, 164)
        Me.btnOpenStore.Name = "btnOpenStore"
        Me.btnOpenStore.Size = New System.Drawing.Size(90, 23)
        Me.btnOpenStore.TabIndex = 7
        Me.btnOpenStore.Text = "open Store"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarForeColor = System.Drawing.SystemColors.HotTrack
        Me.DateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.Info
        Me.DateTimePicker1.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText
        Me.DateTimePicker1.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.DateTimePicker1.CalendarTrailingForeColor = System.Drawing.SystemColors.Highlight
        Me.DateTimePicker1.Location = New System.Drawing.Point(145, 105)
        Me.DateTimePicker1.MaxDate = New Date(2030, 12, 31, 0, 0, 0, 0)
        Me.DateTimePicker1.MinDate = New Date(2013, 1, 1, 0, 0, 0, 0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(234, 20)
        Me.DateTimePicker1.TabIndex = 6
        '
        'createCert
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.BackgroundImage = Global.SignTool.My.Resources.Resources.signature
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(465, 286)
        Me.Controls.Add(Me.gbCreateCert)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "createCert"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "create a self-signed certificate"
        Me.gbCreateCert.ResumeLayout(False)
        Me.gbCreateCert.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblEMail As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbName As System.Windows.Forms.TextBox
    Friend WithEvents tbEmail As System.Windows.Forms.TextBox
    Friend WithEvents gbCreateCert As System.Windows.Forms.GroupBox
    Friend WithEvents btnOpenStore As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblResult As System.Windows.Forms.Label

End Class
