Public Class TrialExpired

    Private Sub btnTrialExitApp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrialExitApp.Click
        System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=S6YPPFDTRPWP2")
        Application.Exit()
    End Sub


    Private Sub TrialExpired_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=S6YPPFDTRPWP2")
        Application.Exit()
    End Sub


    Private Sub TrialExpired_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Focus()
    End Sub



End Class