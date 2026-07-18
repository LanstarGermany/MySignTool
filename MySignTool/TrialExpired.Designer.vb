<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TrialExpired
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TrialExpired))
        Me.rtbTrialInfo = New System.Windows.Forms.RichTextBox()
        Me.btnTrialExitApp = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rtbTrialInfo
        '
        Me.rtbTrialInfo.BackColor = System.Drawing.Color.Silver
        Me.rtbTrialInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbTrialInfo.Location = New System.Drawing.Point(12, 12)
        Me.rtbTrialInfo.Name = "rtbTrialInfo"
        Me.rtbTrialInfo.ReadOnly = True
        Me.rtbTrialInfo.Size = New System.Drawing.Size(409, 154)
        Me.rtbTrialInfo.TabIndex = 0
        Me.rtbTrialInfo.Text = resources.GetString("rtbTrialInfo.Text")
        '
        'btnTrialExitApp
        '
        Me.btnTrialExitApp.BackColor = System.Drawing.Color.SteelBlue
        Me.btnTrialExitApp.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnTrialExitApp.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTrialExitApp.Location = New System.Drawing.Point(27, 117)
        Me.btnTrialExitApp.Name = "btnTrialExitApp"
        Me.btnTrialExitApp.Size = New System.Drawing.Size(381, 33)
        Me.btnTrialExitApp.TabIndex = 1
        Me.btnTrialExitApp.Text = "Buy Now"
        Me.btnTrialExitApp.UseVisualStyleBackColor = False
        '
        'TrialExpired
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.IndianRed
        Me.CancelButton = Me.btnTrialExitApp
        Me.ClientSize = New System.Drawing.Size(436, 178)
        Me.Controls.Add(Me.btnTrialExitApp)
        Me.Controls.Add(Me.rtbTrialInfo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "TrialExpired"
        Me.ShowInTaskbar = False
        Me.Tag = "lo"
        Me.Text = "Trial period expired"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rtbTrialInfo As System.Windows.Forms.RichTextBox
    Friend WithEvents btnTrialExitApp As System.Windows.Forms.Button
End Class
