<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class eula
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(eula))
        Me.tbEULA = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'tbEULA
        '
        Me.tbEULA.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.tbEULA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEULA.Location = New System.Drawing.Point(13, 13)
        Me.tbEULA.Multiline = True
        Me.tbEULA.Name = "tbEULA"
        Me.tbEULA.ReadOnly = True
        Me.tbEULA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbEULA.Size = New System.Drawing.Size(644, 522)
        Me.tbEULA.TabIndex = 0
        '
        'eula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.ClientSize = New System.Drawing.Size(666, 547)
        Me.Controls.Add(Me.tbEULA)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "eula"
        Me.Text = "End-User License Agreement"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbEULA As System.Windows.Forms.TextBox
End Class
