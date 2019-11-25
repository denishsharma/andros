Imports SCR130

Public Class Form1
    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        CreateMemoryBlock(txt_address.Text, txt_content.Text)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox(DumpMemoryCount())
    End Sub

    Private Sub btn_showcontent_Click(sender As Object, e As EventArgs) Handles btn_showcontent.Click
        MsgBox(ReadMemoryContent(txt_address.Text))
    End Sub

    Private Sub btn_mov_Click(sender As Object, e As EventArgs) Handles btn_mov.Click
        MoveContentToMemoryBlock(txt_address.Text, txt_content.Text)
        txt_datamemory.Text = ExportDumpMemory()
    End Sub

    Private Sub btn_remove_Click(sender As Object, e As EventArgs) Handles btn_remove.Click
        RemoveMemoryBlock(txt_address.Text)
        txt_datamemory.Text = ExportDumpMemory()
    End Sub

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        CleanDumpMemory()
    End Sub

    Private Sub btn_parse_Click(sender As Object, e As EventArgs) Handles btn_parse.Click
        MsgBox(ParseMemoryBlock(GetMemoryBlock(txt_address.Text)))
    End Sub

    Private Sub btn_export_Click(sender As Object, e As EventArgs) Handles btn_export.Click
        txt_datamemory.Text = ExportDumpMemory()
    End Sub

    Private Sub btn_cleanimport_Click(sender As Object, e As EventArgs) Handles btn_cleanimport.Click
        ClearAndImportFromMemoryData(txt_datamemory.Text)
        txt_datamemory.Text = ExportDumpMemory()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox(SizeOfBlock(GetMemoryBlock(txt_address.Text)).ToString())
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateDumpMemoryLengthOf(1000)
    End Sub

    Private Sub btn_combine_Click(sender As Object, e As EventArgs) Handles btn_combine.Click
        MsgBox(CombineContentOf(txt_address.Text, txt_blocklen.Text))
    End Sub
End Class
