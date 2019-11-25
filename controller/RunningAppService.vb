Imports System.IO
Imports System.Windows.Forms
Imports System.Windows
Imports wap

Namespace RunningAppService

Public Class RunningAppMethod

        Shared ReadOnly CurrentUsingAppID As String
        Private Shared AppOwner As Object

        Private Shared ReadOnly lst_apps As New ListBox

        Public Shared RunningAppUID As New List(Of EAPHost)
        Public Shared ActiveApp As New List(Of EAPHost)
        Public Shared CurrentRemovedApp As New List(Of EAPHost)
        Public Shared CurrentAddedApp As New List(Of EAPHost)
        Public Shared OwnedAppForm As New List(Of AppForm)

        Public Shared LastActiveApp As New EAPHost



        Public Shared Event WindowLocationChanged(appid As String)
        Public Shared Event WindowFocusChnaged(appid As String)
        Public Shared Event ActiveAppChanged(appid As String)
        Public Shared Event AppListLengthChanged()
        Public Shared Event GetCurrentAppAdded(appid As String)


#Region "HostControl Properties"

        Private Shared _HCbackcolor As Drawing.Color
        Public Shared Property HostControlBackColor(appid As String) As Drawing.Color
            Get
                Return _HCbackcolor
            End Get
            Set(value As Drawing.Color)
                _HCbackcolor = value
                For i = 0 To RunningAppUID.Count - 1
                    If appid = RunningAppUID(i).AppID Then
                        RunningAppUID(i).GetAppContainer.Background = New Media.SolidColorBrush(Media.Color.FromArgb(_HCbackcolor.A, _HCbackcolor.R, _HCbackcolor.G, _HCbackcolor.B))
                    End If
                Next
            End Set
        End Property

        Private Shared _HCvisible As Boolean
        Public Shared Property HostControlVisible(appid As String) As Boolean
            Get
                Return _HCvisible
            End Get
            Set(value As Boolean)
                _HCvisible = value
                For i = 0 To RunningAppUID.Count - 1
                    If appid = RunningAppUID(i).AppID Then
                        If _HCvisible = True Then
                            RunningAppUID(i).GetAppContainer.Visibility = Visibility.Visible
                        Else
                            RunningAppUID(i).GetAppContainer.Visibility = Visibility.Hidden
                        End If
                    End If
                Next
            End Set
        End Property

#End Region

#Region "HostControlContainer Properties"

        Public Shared Function GetActiveControl(appid As String) As Control
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    '   Dim ctrcont As ContainerControl = TryCast(RunningAppUID(i).GetContainerControl.ActiveControl, ContainerControl)
                    '     Dim ctr As Control = ctrcont.ActiveControl
                    '  Return ctr
                End If
            Next
            Return Nothing
        End Function

        Public Shared Function GetControlByName(appid As String, name As String) As Control
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    ' Dim ctrcont As ContainerControl = TryCast(RunningAppUID(i).GetContainerControl.ActiveControl, ContainerControl)
                    ' Return SubGetControlByName(ctrcont, name)
                End If
            Next
            Return Nothing
        End Function

        Private Shared Function SubGetControlByName(ctrlContainer As Control, name As String) As Control
            For Each ctrl As Control In ctrlContainer.Controls
                If ctrl.Name = name Then
                    Return ctrl
                ElseIf ctrl.Controls.Count > 0 Then
                    For Each ctrl1 As Control In ctrl.Controls
                        If ctrl1.Name = name Then
                            Return ctrl1
                        ElseIf ctrl1.Controls.Count > 0 Then
                            SubGetControlByName(ctrl1, name)
                        End If
                    Next
                End If
            Next
            Return Nothing
        End Function

#End Region

#Region "Window Properties"

        Private Shared _WNlocation As Drawing.Point
        Public Shared Property AppWindowLocation(appid As String) As Drawing.Point
            Get
                Return _WNlocation
            End Get
            Set(value As Drawing.Point)
                _WNlocation = value
                For i = 0 To RunningAppUID.Count - 1
                    If appid = RunningAppUID(i).AppID Then
                        SetWindowLocation(appid, _WNlocation.X, _WNlocation.Y)
                        RaiseEvent WindowLocationChanged(appid)
                    End If
                Next
            End Set
        End Property

#End Region


#Region "GetWindowProperties"

        Public Shared Function GetOwnedAppFormByID(appid As String) As List(Of AppForm)
            Dim lst As New List(Of AppForm)
            lst.Clear()
            For Each app As AppForm In OwnedAppForm
                If appid = app.AppID Then
                    lst.Add(app)
                    Return lst
                End If
            Next
            Return Nothing
        End Function

        Public Shared Function GetAppIndex(appid As String) As String
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    Return RunningAppUID.IndexOf(GetAppById(appid))
                End If
            Next
            Return Nothing
        End Function

        Public Shared Function GetAppById(appid As String) As EAPHost
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    Return RunningAppUID(i)
                End If
            Next
            Return Nothing
        End Function

        Public Shared Function GetRunningAppGUID(appid As String) As String
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    Return RunningAppUID(i)._appguid
                End If
            Next
            Return Nothing
        End Function

        Public Shared Function GetRunningAppGUIDByInfo(appname As String) As String
            For i = 0 To RunningAppUID.Count - 1
                If appname = RunningAppUID(i).AppName Then
                    Return RunningAppUID(i)._appguid
                End If
            Next
            Return Nothing
        End Function
        Public Shared Function GetRunningAppGUIDByInfo(appname As String, appversion As String) As String
            For i = 0 To RunningAppUID.Count - 1
                If appname = RunningAppUID(i).AppName Then
                    If appversion = RunningAppUID(i).AppVersion Then
                        Return RunningAppUID(i)._appguid
                    End If
                End If
            Next
            Return Nothing
        End Function

        Public Shared Function GetRunningAppIDByInfo(appname As String) As String
            For i = 0 To RunningAppUID.Count - 1
                If appname = RunningAppUID(i).AppName Then
                    Return RunningAppUID(i).AppID
                End If
            Next
            Return Nothing
        End Function
        Public Shared Function GetRunningAppIDByInfo(appname As String, appversion As String) As String
            For i = 0 To RunningAppUID.Count - 1
                If appname = RunningAppUID(i).AppName Then
                    If appversion = RunningAppUID(i).AppVersion Then
                        Return RunningAppUID(i).AppID
                    End If
                End If
            Next
            Return Nothing
        End Function

        Public Shared Function GetAppID(app As EAPHost) As String
            Return app.AppID
        End Function

        Public Shared Function GetActiveAppID() As String
            Return ActiveApp(0).AppID
        End Function

        Public Shared Function GetWindowText(appid As String) As String
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    Return RunningAppUID(i).AppTitle
                End If
            Next
            Return Nothing
        End Function

        Public Shared Function GetWindowTextByInfo(appname As String) As String
            For i = 0 To RunningAppUID.Count - 1
                If appname = RunningAppUID(i).AppName Then
                    Return RunningAppUID(i).AppTitle
                End If
            Next
            Return Nothing
        End Function
        Public Shared Function GetWindowTextByInfo(appname As String, appversion As String) As String
            For i = 0 To RunningAppUID.Count - 1
                If appname = RunningAppUID(i).AppName Then
                    If appversion = RunningAppUID(i).AppVersion Then
                        Return RunningAppUID(i).AppTitle
                    End If
                End If
            Next
            Return Nothing
        End Function

        Public Shared Function GetAppName(appid As String) As String
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    Return RunningAppUID(i).AppName
                End If
            Next
            Return Nothing
        End Function

        Public Shared Function GetAppIcon(appid As String) As Media.ImageSource
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    Return RunningAppUID(i).AppIcon
                End If
            Next
            Return Nothing
        End Function

        Public Shared Function GetAppVersion(appid As String) As String
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    Return RunningAppUID(i).AppVersion
                End If
            Next
            Return Nothing
        End Function

        Public Shared Function GetWindowLocation(appid As String) As Drawing.Point
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    Return New System.Drawing.Point(RunningAppUID(i).Left, RunningAppUID(i).Top)
                End If
            Next
            Return Nothing
        End Function

#End Region

#Region "SetWindowProperties"

        Public Shared Sub RemoveActiveApp(app As EAPHost)
            Try
                LastActiveApp = GetAppById(GetActiveAppID)
                ' ActiveApp.Remove(app)
                '  ActiveApp.Clear()
                RaiseEvent ActiveAppChanged(app.AppID)
                RaiseEvent WindowFocusChnaged(app.AppID)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Public Shared Sub SetActiveApp(app As EAPHost)
            Try
                ActiveApp.Clear()
                ActiveApp.Add(app)
                FocusWindow(app.AppID)
                RaiseEvent ActiveAppChanged(app.AppID)
                RaiseEvent WindowFocusChnaged(app.AppID)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Public Shared Sub SetActiveAppByID(appid As String)
            ActiveApp.Clear()
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    ActiveApp.Add(RunningAppUID(i))
                    FocusWindow(appid)
                    RaiseEvent ActiveAppChanged(appid)
                    RaiseEvent WindowFocusChnaged(appid)
                End If
            Next
        End Sub

        Private Shared Sub SubSetActiveAppByID(appid As String)
            ActiveApp.Clear()
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    ActiveApp.Add(RunningAppUID(i))
                    RaiseEvent ActiveAppChanged(appid)
                    RaiseEvent WindowFocusChnaged(appid)
                End If
            Next
        End Sub

        Public Shared Sub SetWindowTextByInfo(appname As String, windowtext As String)
            For i = 0 To RunningAppUID.Count - 1
                If appname = RunningAppUID(i).AppName Then
                    RunningAppUID(i).AppTitle = windowtext
                End If
            Next
        End Sub
        Public Shared Sub SetWindowTextByInfo(appname As String, appversion As String, windowtext As String)
            For i = 0 To RunningAppUID.Count - 1
                If appname = RunningAppUID(i).AppName Then
                    If appversion = RunningAppUID(i).AppVersion Then
                        RunningAppUID(i).AppTitle = windowtext
                    End If
                End If
            Next
        End Sub

        Public Shared Sub SetWindowText(appid As String, windowtext As String)
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    RunningAppUID(i).AppTitle = windowtext
                End If
            Next
        End Sub

        Public Shared Sub SetWindowLocation(appid As String, windowlocationX As Double, windowlocationY As Double)
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    RunningAppUID(i).Left = windowlocationX
                    RunningAppUID(i).Top = windowlocationY
                End If
            Next
        End Sub

        Public Shared Sub SetWindowSize(appid As String, windowWidth As Double, windowHeight As Double)
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    RunningAppUID(i).Width = windowWidth + 40
                    RunningAppUID(i).Height = windowHeight + 40
                End If
            Next
        End Sub

#End Region

#Region "AppProperties"

        Public Shared Sub LaunchApp(apppath As String)
            Dim eapl As New wap.EAPLoader : Dim eaph As New EAPHost
            eapl.LoadEAP(apppath, eaph)
            AddAppSetActive(eaph)
            AppOwner.AddOwnedForm(eaph)
        End Sub

        Public Shared Sub CloseApp(appid As String)
            Try
                For i = 0 To RunningAppUID.Count - 1
                    If appid = RunningAppUID(i).AppID Then
                        RunningAppUID(i).Close()
                    End If
                Next
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Sub AddAppOwner(owner As Object)
            AppOwner = owner
        End Sub

        Public Shared Sub ShowAppForm(appform As AppForm, parent As EAPHost)
            appform.SetParentForm(parent)
            OwnedAppForm.Add(appform)
            appform.Show()
        End Sub

        Public Shared Sub ShowAppFormByID(appform As AppForm, appid As String)
            appform.SetParentForm(GetAppById(appid))
            OwnedAppForm.Add(appform)
            appform.Show()
        End Sub

        Public Shared Sub CloseAppForm(appform As AppForm)
            OwnedAppForm.Remove(appform)
        End Sub


        Public Shared Sub AddApp(app As EAPHost)
            RunningAppUID.Add(app)
            RaiseEvent AppListLengthChanged()
            RaiseEvent GetCurrentAppAdded(app.AppID)
        End Sub

        Public Shared Sub AddAppSetActive(app As EAPHost)
            CurrentAddedApp.Clear()
            CurrentRemovedApp.Clear()
            CurrentAddedApp.Add(app)

            RunningAppUID.Add(app)
            SetActiveApp(app)

            RaiseEvent AppListLengthChanged()
        End Sub


        Public Shared Sub RemoveApp(app As EAPHost)
            RunningAppUID.Remove(app)
            CurrentRemovedApp.Clear()
            CurrentAddedApp.Clear()
            CurrentRemovedApp.Add(app)
            RaiseEvent AppListLengthChanged()
        End Sub

        Public Shared Sub RemoveAppByID(appid As String)
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    RunningAppUID.RemoveAt(i)
                    CurrentRemovedApp.Clear()
                    CurrentRemovedApp.Add(RunningAppUID(i))
                    RaiseEvent AppListLengthChanged()
                End If
            Next
        End Sub

        Public Shared Sub RemoveAppByInfo(appname As String)
            For i = 0 To RunningAppUID.Count - 1
                If appname = RunningAppUID(i).AppName Then
                    RunningAppUID.RemoveAt(i)
                    RaiseEvent AppListLengthChanged()
                End If
            Next
        End Sub
        Public Shared Sub RemoveAppByInfo(appname As String, appversion As String)
            For i = 0 To RunningAppUID.Count - 1
                If appname = RunningAppUID(i).AppName Then
                    If appversion = RunningAppUID(i).AppVersion Then
                        RunningAppUID.RemoveAt(i)
                        RaiseEvent AppListLengthChanged()
                    End If
                End If
            Next
        End Sub

        Public Shared Sub RemoveAppByGUID(appguid As String)
            For i = 0 To RunningAppUID.Count - 1
                If appguid = RunningAppUID(i)._appguid Then
                    RunningAppUID.RemoveAt(i)
                    RaiseEvent AppListLengthChanged()
                End If
            Next
        End Sub



        Public Shared Sub FocusWindow(appid As String)
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    RunningAppUID(i).TopMost = True
                    RunningAppUID(i).Activate()
                    RunningAppUID(i).TopMost = False
                    RaiseEvent WindowFocusChnaged(appid)
                    RaiseEvent ActiveAppChanged(appid)
                End If
            Next
        End Sub

        Public Shared Function IsAppRunning(appid As String) As Boolean
            For i = 0 To RunningAppUID.Count - 1
                If appid = RunningAppUID(i).AppID Then
                    Return True
                Else
                    Return False
                End If
            Next
            Return Nothing
        End Function

        Public Shared Sub KillAllRunningApp()
            For i = 0 To RunningAppUID.Count - 1
                CloseApp(RunningAppUID(i).AppID)
            Next
        End Sub

#End Region

    End Class

    Public Class WapService
        Public Shared Sub GetAppsFromDirToListBox(dirpath As String, listBox As ListBox)
            Dim directory As New DirectoryInfo(dirpath)
            For Each appFile As FileInfo In directory.GetFiles("*.eap", SearchOption.AllDirectories)
                Dim appdataFile As wap.ExternalAppService.AppDataFile = wap.EAPLoader.LoadDataFile(appFile.FullName)
                Dim lvItem As New ListViewItem(appdataFile.AppName) With {.Tag = appFile.FullName}
                listBox.Items.Add(lvItem)
            Next
        End Sub

        Public Shared Function GetAppsFromDirToListOfApps(dirpath As String) As List(Of List(Of String))
            Dim l As New List(Of List(Of String))

            Dim directory As New DirectoryInfo(dirpath)
            For Each appFile As FileInfo In directory.GetFiles("*.eap", SearchOption.AllDirectories)
                Dim i As New List(Of String)

                Dim appdataFile As wap.ExternalAppService.AppDataFile = EAPLoader.LoadDataFile(appFile.FullName)
                i.Add(appdataFile.AppName) : i.Add(appFile.FullName) : i.Add(appdataFile.AppIcon)

                l.Add(i)
            Next

            Return l
        End Function
    End Class

    Public Class AppForm
        Inherits Form

        Private _parentform As EAPHost

        Public Sub SetParentForm(form As EAPHost)
            _parentform = form
        End Sub

        Private ReadOnly _appid As String
        Public ReadOnly Property AppID As String
            Get
                Return _appid
            End Get
        End Property

        Private ReadOnly _appguid As String
        Public ReadOnly Property AppGUID As String
            Get
                Return _appguid
            End Get
        End Property

        Sub New()
            _appid = _parentform.AppID
            _appguid = New Random().Next(1000000, 999999999)
        End Sub
    End Class

End Namespace