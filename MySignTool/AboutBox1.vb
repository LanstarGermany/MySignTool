Public NotInheritable Class AboutBox1

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title & " " & Main.zSubjectDN
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        Me.LabelProductName.Text = "Free Version"
        Me.LabelProductName.ForeColor = Color.Green

        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = "Rainer Koch"
        Me.TextBoxDescription.Text = My.Application.Info.Description & vbCrLf & vbCrLf
        Me.TextBoxDescription.Text += "The certificate used to sign applications expires after a certain time. In order to remove the need to constantly re-sign applications with new certificates, SignTool supports timestamp. When an application is signed with a timestamp, its certificate will continue to be accepted even after expiration, provided the timestamp is valid. This allows applications with expired certificates, but valid timestamps, to download and run. It also allows installed applications with expired certificates to continue to download and install updates."
        Me.TextBoxDescription.Text += vbCrLf & vbCrLf
        Me.TextBoxDescription.Text += "Visual Studio Support :"
        Me.TextBoxDescription.Text += vbCrLf
        Me.TextBoxDescription.Text += "go to TOOLS - EXTERNAL TOOLS" & vbCrLf
        Me.TextBoxDescription.Text += vbCrLf
        Me.TextBoxDescription.Text += "press ADD" & vbCrLf
        Me.TextBoxDescription.Text += "Title     : Digital Signature Tool" & vbCrLf
        Me.TextBoxDescription.Text += "Command   : C:\soft\Signing\SignTool.exe" & vbCrLf
        Me.TextBoxDescription.Text += "Arguments : $(BinDir)" & vbCrLf
        Me.TextBoxDescription.Text += "Initial Directory : leave this field blank" & vbCrLf
        Me.TextBoxDescription.Text += vbCrLf
        Me.TextBoxDescription.Text += "below is a list of Timestamp server URL's :" & vbCrLf
        Me.TextBoxDescription.Text += vbCrLf
        Me.TextBoxDescription.Text += "http://timestamp.digicert.com" & vbCrLf
        Me.TextBoxDescription.Text += "http://timestamp.sectigo.com" & vbCrLf
        Me.TextBoxDescription.Text += "http://timestamp.acs.microsoft.com" & vbCrLf
        Me.TextBoxDescription.Text += vbCrLf
        Me.TextBoxDescription.Text += vbCrLf
        Me.TextBoxDescription.Text += "2011 by Rainer Koch" & vbCrLf
        Me.TextBoxDescription.Text += "email: rainer@lanstar.de" & vbCrLf
        Me.TextBoxDescription.Text += vbCrLf



    End Sub


    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

   
    
    Private Sub TableLayoutPanel_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel.Paint

    End Sub
End Class
