Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ofd As New OpenFileDialog()
        If (ofd.ShowDialog() = DialogResult.OK) Then
            txtPath.Text = ofd.FileName
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim a As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(System.Windows.Forms.Application.StartupPath + "\wap.dll")
        Dim ty As Type = a.GetType("wap.ExternalAppService.AppDataFileCreator")
        Dim ihost As Object = Activator.CreateInstance(ty)
        ihost.Create(txtName.Text, txtType.Text, txtPath.Text)
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim ofd As New OpenFileDialog()
        If (ofd.ShowDialog() = DialogResult.OK) Then
            txtPath.Text = ofd.FileName
        End If
    End Sub
End Class
