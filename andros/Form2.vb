Public Class Form2

    Public Shared AllForms As New Dictionary(Of String, List(Of String))


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.TextLength > 0 And TextBox2.TextLength > 0 Then
            If AllForms.ContainsKey(TextBox1.Text) Then
                AllForms(TextBox1.Text).Add(TextBox2.Text)
            Else
                Dim l As New List(Of String)
                l.Add(TextBox2.Text)
                AllForms.Add(TextBox1.Text, l)
            End If
        End If


        TVU()
    End Sub

    Sub TVU()
        Dim lkeys As New List(Of String)(AllForms.Keys)
        TreeView1.Nodes.Clear()

        For i = 0 To lkeys.Count - 1
            TreeView1.Nodes.Add(lkeys(i))
            If AllForms(lkeys(i)).Count > 0 Then
                For l = 0 To AllForms(lkeys(i)).Count - 1
                    TreeView1.Nodes(i).Nodes.Add(AllForms(lkeys(i))(l))
                Next
            End If
        Next
        TreeView1.ExpandAll()
    End Sub

    Sub GKL()
        ListBox1.Items.Clear()
        If AllForms.ContainsKey(TextBox3.Text) Then
            For l = 0 To AllForms(TextBox3.Text).Count - 1
                ListBox1.Items.Add(AllForms(TextBox3.Text)(l))
            Next
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AllForms.Remove(TextBox3.Text)
        TVU()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GKL()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If AllForms.ContainsKey(TextBox3.Text) Then
            AllForms(TextBox3.Text).Remove(ListBox1.SelectedItem)
        End If
        TVU()
        GKL()
    End Sub
End Class