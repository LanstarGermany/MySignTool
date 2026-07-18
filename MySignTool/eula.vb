Imports System.IO
Imports System.Reflection



Public Class eula

    Private Sub eula_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tbEULA.Text = GetResourceContent("EULA.txt")
        tbEULA.Text += vbCrLf
        tbEULA.Focus()
        tbEULA.SelectionStart = tbEULA.Text.Length
    End Sub


    Function GetResourceContent(ByVal filename As String) As String
        Dim asm As System.Reflection.[Assembly] = _
            System.Reflection.[Assembly].GetExecutingAssembly()
        Dim strm As System.IO.Stream = asm.GetManifestResourceStream(asm.GetName() _
            .Name + "." + filename)
        Dim reader As New System.IO.StreamReader(strm)
        GetResourceContent = reader.ReadToEnd()
        reader.Close()
    End Function

   
End Class