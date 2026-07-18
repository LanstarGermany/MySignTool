Imports System.Windows.Forms


Public Class createCert

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If tbName.Text = "" Or tbEmail.Text = "" Then
            lblResult.ForeColor = Color.Red
            lblResult.Text = "Please fill in both fields"
            tbEmail.Text = ""
            tbName.Text = ""
        Else
            Try
                Dim appdatapath As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                appdatapath += "\LPS"
                Dim programpath As String = Chr(34) & AppDomain.CurrentDomain.BaseDirectory & Chr(34)
                Dim param1 As String = """CN=" & tbName.Text & ", E=" & tbEmail.Text & ", C=US"""
                Dim day As String = DateTimePicker1.Value.Day.ToString.PadLeft(2, "0")
                Dim month As String = DateTimePicker1.Value.Month.ToString.PadLeft(2, "0")
                Dim year As String = DateTimePicker1.Value.Year
                Dim param2 As String = month & "/" & day & "/" & year
                Dim p As New ProcessStartInfo
                p.FileName = Main.createCertcmd
                p.Arguments = appdatapath.ToString & " " & programpath & " " & param1 & " " & param2
                p.WindowStyle = ProcessWindowStyle.Hidden
                Process.Start(p)
                lblResult.ForeColor = Color.Green
                lblResult.Text = "Certificate added to store"
                btnOpenStore.Focus()
            Catch ex As Exception
                lblResult.ForeColor = Color.Red
                lblResult.Text = "failed : " & ex.Message
            End Try
        End If
    End Sub



    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenStore.Click
        System.Diagnostics.Process.Start("certmgr.msc")
    End Sub



    Private Sub createCert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblResult.Text = ""
        tbEmail.Text = ""
        tbName.Text = ""

    End Sub



    Private Sub tbName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbName.Click
        lblResult.Text = ""
        lblResult.ForeColor = Color.Black
    End Sub



    Private Sub tbEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbEmail.Click
        lblResult.Text = ""
        lblResult.ForeColor = Color.Black
    End Sub



End Class
