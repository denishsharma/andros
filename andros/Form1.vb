Imports System.IO
Imports controller.RunningAppService
Imports controller.FileSystemService
Imports System.Windows.Interop


Public Class Form1

    Private path As String = Application.StartupPath & "\Apps\"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WapService.GetAppsFromDirToListBox(path, lst_apps)
        FileSystemMethod.LoadDrives()
        FileSystemMethod.GetDrivesToListBox(lst_drvs)
        Button12.PerformClick()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If lst_apps.SelectedIndex >= 0 Then
            ' Dim a As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile(System.Windows.Forms.Application.StartupPath + "\eaptheme.dll")
            ' Dim ty As Type = a.GetType("eaptheme.EAPHost")
            ' Dim ihost As New Object : ihost = Activator.CreateInstance(ty)
            ' ihost.show()
            Dim eapl As New wap.EAPLoader : Dim eaph As New wap.EAPHost
            eapl.LoadEAP(lst_apps.SelectedItem.Tag, eaph)
            ' MsgBox(lst_apps.SelectedItem.Tag)
            Dim helper As New WindowInteropHelper(eaph) With {.Owner = Me.Handle}

            ' lst_runapp.Items.Add(eaph.AppID)
            lst_runapp.SetSelected(lst_runapp.Items.IndexOf(eaph.AppID), True)

            '
            '
            ' AddHandler eaph.FormClosed, Sub()
            '                                 lst_runapp.Items.RemoveAt(lst_runapp.Items.IndexOf(eaph.AppID))
            '                             End Sub
            ' AddHandler eaph.Activated, Sub()
            '                                lst_runapp.SetSelected(lst_runapp.Items.IndexOf(eaph.AppID), True)
            '                            End Sub
        End If



    End Sub

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler RunningAppMethod.AppListLengthChanged, Sub()
                                                              lst_runapp.Items.Clear()
                                                              TreeView1.Nodes.Clear()

                                                              '  Label1.Text = RunningAppMethod.IsAppRunning(Label2.Text)
                                                              For Each app As wap.EAPHost In RunningAppMethod.RunningAppUID
                                                                  lst_runapp.Items.Add(app.AppID)
                                                                  TreeView1.Nodes.Add(app.AppID)
                                                              Next
                                                          End Sub
        AddHandler RunningAppMethod.ActiveAppChanged, Sub()
                                                          Try
                                                              lst_runapp.SetSelected(lst_runapp.Items.IndexOf(RunningAppMethod.GetActiveAppID), True)
                                                          Catch ex As Exception

                                                          End Try
                                                      End Sub
        AddHandler RunningAppMethod.WindowLocationChanged, Sub()
                                                               Label2.Text = RunningAppMethod.AppWindowLocation(RunningAppMethod.GetActiveAppID).X
                                                               Label3.Text = RunningAppMethod.AppWindowLocation(RunningAppMethod.GetActiveAppID).Y
                                                           End Sub
    End Sub

    Private Sub lst_runapp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_runapp.SelectedIndexChanged
        If lst_runapp.SelectedIndex >= 0 Then
            Label1.Text = RunningAppMethod.GetRunningAppGUID(lst_runapp.SelectedItem.ToString)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RunningAppMethod.SetWindowText(RunningAppMethod.GetActiveAppID, TextBox1.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RunningAppMethod.SetActiveAppByID(lst_runapp.SelectedItem.ToString)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim clrdlg As New ColorDialog
        If clrdlg.ShowDialog = DialogResult.OK Then
            RunningAppMethod.HostControlBackColor(lst_runapp.SelectedItem.ToString) = clrdlg.Color
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            TextBox2.Text = RunningAppMethod.GetControlByName(RunningAppMethod.GetActiveAppID, TextBox2.Text).Controls.Count
        Catch ex As Exception

        End Try
        RunningAppMethod.SetActiveAppByID(lst_runapp.SelectedItem.ToString)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox2.Text = RunningAppMethod.GetActiveControl(RunningAppMethod.GetActiveAppID).Name
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        RunningAppMethod.KillAllRunningApp()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        FileSystemMethod.LoadDirectories(TextBox3.Text)
        FileSystemMethod.GetDirectoriesToListBox(lst_dirs)

    End Sub

    Private Sub lst_drvs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_drvs.SelectedIndexChanged
        TextBox3.Text = lst_drvs.SelectedItem.ToString
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        FileSystemMethod.LoadFiles(TextBox3.Text)
        FileSystemMethod.GetFilesToListBox(lst_files)
    End Sub

    Private Sub lst_dirs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_dirs.SelectedIndexChanged
        rtb1.Clear()
        rtb1.AppendText("Full Path: " + FileSystemMethod.CreateSingleDirectoryInstance(lst_dirs.SelectedItem.ToString).FullPath & vbNewLine)
        rtb1.AppendText("Name: " + FileSystemMethod.CreateSingleDirectoryInstance(lst_dirs.SelectedItem.ToString).Name & vbNewLine)
        rtb1.AppendText("Exists: " & FileSystemMethod.CreateSingleDirectoryInstance(lst_dirs.SelectedItem.ToString).Exist & vbNewLine)
        rtb1.AppendText("Drive: " + FileSystemMethod.CreateSingleDirectoryInstance(lst_dirs.SelectedItem.ToString).Drive & vbNewLine)
        rtb1.AppendText("Last Access Time: " + FileSystemMethod.CreateSingleDirectoryInstance(lst_dirs.SelectedItem.ToString).LastAccessTime & vbNewLine)
        rtb1.AppendText("Last Wirte Time: " + FileSystemMethod.CreateSingleDirectoryInstance(lst_dirs.SelectedItem.ToString).LastWriteTime & vbNewLine)
        rtb1.AppendText("Creation Time: " + FileSystemMethod.CreateSingleDirectoryInstance(lst_dirs.SelectedItem.ToString).CreationTime & vbNewLine)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim a As System.Reflection.Assembly = System.Reflection.Assembly.LoadFile("C:\Users\Mohinish\Documents\Denish\Test_Windows_Forms_App\Andros\Test2\andros\overlay\bin\Debug\overlay.dll")
        Dim ty As Type = a.GetType("overlay.overlayMethod")
        Dim o As New Object : o = Activator.CreateInstance(ty)
        o.ShowOverlay()
    End Sub
End Class

