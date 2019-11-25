Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AndrosDisk.CreateVHD("C:\test.vhd", 100, "Andros", "Z", "fat32", "fixed")
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        AndrosDisk.DetachDisk("C:\test.vhd")
    End Sub

    Private Sub Form1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick
    End Sub

End Class
