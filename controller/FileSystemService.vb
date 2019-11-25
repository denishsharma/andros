Imports System.IO
Imports System.Windows.Forms

Namespace FileSystemService

    Public Class FileSystemMethod

        Private Shared ListOfDirectories As New List(Of iDirectory)
        Private Shared ListOfFiles As New List(Of iFile)
        Private Shared ListOfDrives As New List(Of iDrive)
        Private Shared ReadOnly SingleDirectoryInstance As iDirectory

        ''' <summary>
        ''' Return file.
        ''' </summary>
        ''' <param name="path">Path of file.</param>
        ''' <returns></returns>
        Public Shared Function GetFile(path As String) As iFile
            Dim file As New iFile(path)
            If file.Exist = True Then
                Return file
            End If
            Return Nothing
        End Function

        ''' <summary>
        ''' Return directory.
        ''' </summary>
        ''' <param name="path">Path of directory.</param>
        ''' <returns></returns>
        Public Shared Function GetDirectory(path As String) As iDirectory
            Dim dir As New iDirectory(path)
            If dir.Exist = True Then
                Return dir
            End If
            Return Nothing
        End Function

        ''' <summary>
        ''' Return drive.
        ''' </summary>
        ''' <param name="path">Path of drive.</param>
        ''' <returns></returns>
        Public Shared Function GetDrive(path As String) As iDrive
            Dim drv As New iDrive(path)
            If drv.IsReady Then
                Return drv
            End If
            Return Nothing
        End Function

        ''' <summary>
        ''' Load all first children directory from path.
        ''' </summary>
        ''' <param name="path">Path of parent directory.</param>
        Public Shared Sub LoadDirectories(path As String)
            ListOfDirectories.Clear()
            Dim dirinf As New DirectoryInfo(path)
            If dirinf.Exists Then
                For Each directory As DirectoryInfo In dirinf.GetDirectories()
                    Dim dir As New iDirectory(directory.FullName)
                    ListOfDirectories.Add(dir)
                Next
            End If
        End Sub

        ''' <summary>
        ''' Load all first children file from path
        ''' </summary>
        ''' <param name="path">Path of parent directory.</param>
        Public Shared Sub LoadFiles(path As String)
            ListOfFiles.Clear()
            Dim dirinf As New DirectoryInfo(path)
            If dirinf.Exists Then
                For Each file As FileInfo In dirinf.GetFiles
                    Dim fl As New iFile(file.FullName)
                    ListOfFiles.Add(fl)
                Next
            End If
        End Sub

        ''' <summary>
        ''' Load all drives.
        ''' </summary>
        Public Shared Sub LoadDrives()
            ListOfDrives.Clear()
            For Each drv As DriveInfo In DriveInfo.GetDrives
                Dim idrv As New iDrive(drv.Name)
                If drv.DriveType = DriveType.Fixed Then
                    ListOfDrives.Add(idrv)
                End If
            Next
        End Sub

        Public Shared Sub GetDirectoriesToListBox(listBox As ListBox)
            listBox.Items.Clear()
            For i = 0 To ListOfDirectories.Count - 1
                listBox.Items.Add(ListOfDirectories(i).Name)
            Next
        End Sub

        Public Shared Sub GetFilesToListBox(listBox As ListBox)
            listBox.Items.Clear()
            For i = 0 To ListOfFiles.Count - 1
                listBox.Items.Add(ListOfFiles(i).Name)
            Next
        End Sub

        Public Shared Sub GetDrivesToListBox(listBox As ListBox)
            listBox.Items.Clear()
            For i = 0 To ListOfDrives.Count - 1
                listBox.Items.Add(ListOfDrives(i).Name)
            Next
        End Sub

        ''' <summary>
        ''' Create a directory instance from loaded directories using name.
        ''' </summary>
        ''' <param name="name">Specify name of directory.</param>
        ''' <returns></returns>
        Public Shared Function CreateSingleDirectoryInstance(name As String) As iDirectory
            If Not ListOfDirectories.Count = 0 Then
                For i = 0 To ListOfDirectories.Count - 1
                    If name = ListOfDirectories(i).Name Then
                        Return ListOfDirectories(i)
                    End If
                Next
            End If
            Return Nothing
        End Function

        ''' <summary>
        ''' Create a file instance from loaded files using name.
        ''' </summary>
        ''' <param name="name">Specify name of file.</param>
        ''' <returns></returns>
        Public Shared Function CreateSingleFileInstance(name As String) As iFile
            If Not ListOfFiles.Count = 0 Then
                For i = 0 To ListOfFiles.Count - 1
                    If name = ListOfFiles(i).Name Then
                        Return ListOfFiles(i)
                    End If
                Next
            End If
            Return Nothing
        End Function


    End Class


    Public Class iDirectory

        ''' <summary>
        ''' Returns full path of directory.
        ''' </summary>
        Public ReadOnly FullPath As String
        ''' <summary>
        ''' Returns name of directory.
        ''' </summary>
        Public ReadOnly Name As String
        ''' <summary>
        ''' Returns category of directory.
        ''' </summary>
        Public ReadOnly Category As DirectoryCategories
        ''' <summary>
        ''' Returns icon path.
        ''' </summary>
        Private ReadOnly Icon As String
        ''' <summary>
        ''' Tag of directory as object.
        ''' </summary>
        Public ReadOnly Tag As Object
        ''' <summary>
        ''' Sets command on execution mode.
        ''' </summary>
        Public CommandOnExecute As Boolean = False
        ''' <summary>
        ''' Check if directory exists.
        ''' </summary>
        Public ReadOnly Exist As Boolean
        ''' <summary>
        ''' Returns drive of directory.
        ''' </summary>
        Public ReadOnly Drive As String
        ''' <summary>
        ''' Returns parent directory path of a children directory.
        ''' </summary>
        Public ReadOnly ParentDirectoryPath As String
        ''' <summary>
        ''' Gets the time when current directory was last written to.
        ''' </summary>
        Public ReadOnly LastWriteTime As String
        ''' <summary>
        ''' Gets the time the current directory was last accessed.
        ''' </summary>
        Public ReadOnly LastAccessTime As String
        ''' <summary>
        ''' Gets the creation time of the current directory.
        ''' </summary>
        Public ReadOnly CreationTime As String

        Private Shared CurrentPath As String

        Enum DirectoryCategories
            Normal = 0
            CloudStorage = 1
            NetworkSharing = 2
            Downloads = 3
            Music = 4
            Pictures = 5
            Videos = 6
            Documents = 7
        End Enum

        ''' <summary>
        ''' Load directory.
        ''' </summary>
        ''' <param name="path">Full path of directory.</param>
        Sub New(path As String)
            Dim dirinf As New DirectoryInfo(path)
            If dirinf.Exists Then
                CurrentPath = path
                FullPath = dirinf.FullName
                Drive = dirinf.FullName.Substring(0, 2)
                Category = DirectoryCategories.Normal
                Exist = True
                ParentDirectoryPath = dirinf.Parent.FullName
                Name = dirinf.Name
                LastAccessTime = dirinf.LastAccessTime.TimeOfDay.ToString
                LastWriteTime = dirinf.LastWriteTime.TimeOfDay.ToString
                CreationTime = dirinf.CreationTime.TimeOfDay.ToString
            Else
                Exist = False
            End If
        End Sub

        Public Function LoadCategory(path As String) As DirectoryCategories

            Return Nothing
        End Function

        Public Sub Remove()
            My.Computer.FileSystem.DeleteDirectory(CurrentPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End Sub

        Public Shared Sub Remove(path As String)
            My.Computer.FileSystem.DeleteDirectory(path, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End Sub

        Public Shared Sub Create(path As String)
            My.Computer.FileSystem.CreateDirectory(path)
        End Sub

    End Class

    Public Class iFile
        Public ReadOnly FullPath As String
        Public ReadOnly Name As String
        Public ReadOnly Icon As String
        Public ReadOnly Tag As Object
        Public CommandOnExecute As Boolean = False
        Public ReadOnly Exist As Boolean
        Public ReadOnly Drive As String
        Public ReadOnly ParentDirectoryPath As String
        Public ReadOnly LastWriteTime As String
        Public ReadOnly LastAccessTime As String
        Public ReadOnly CreationTime As String
        Public ReadOnly FileExtension As String
        Public ReadOnly IsReadOnly As Boolean

        Private Shared CurrentPath As String

        Sub New(path As String)
            Dim fileinf As New FileInfo(path)
            If fileinf.Exists Then
                CurrentPath = path
                FullPath = fileinf.FullName
                Drive = fileinf.FullName.Substring(0, 2)
                Exist = True
                IsReadOnly = fileinf.IsReadOnly
                ParentDirectoryPath = fileinf.DirectoryName
                FileExtension = fileinf.Extension
                Name = fileinf.Name
                LastAccessTime = fileinf.LastAccessTime.TimeOfDay.ToString
                LastWriteTime = fileinf.LastWriteTime.TimeOfDay.ToString
                CreationTime = fileinf.CreationTime.TimeOfDay.ToString
            Else
                Exist = False
            End If
        End Sub


        Public Sub Remove()
            My.Computer.FileSystem.DeleteFile(CurrentPath, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
        End Sub

        Public Shared Sub Remove(path As String)
            My.Computer.FileSystem.DeleteFile(path, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
        End Sub

        Public Shared Sub RemovePermanetly()
            My.Computer.FileSystem.DeleteFile(CurrentPath, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        End Sub

        Public Shared Sub Create(path As String)
            My.Computer.FileSystem.WriteAllText(path, "", False)
        End Sub

    End Class

    Public Class iDrive
        Public ReadOnly VolumeLabel As String
        Public ReadOnly Name As String
        Public ReadOnly Category As DriveCategories
        Public ReadOnly Icon As String
        Public ReadOnly Tag As Object
        Public CommandOnExecute As Boolean = True
        Public ReadOnly Exist As Boolean
        Public ReadOnly RootDirectoryPath As String
        Public ReadOnly IsReady As Boolean
        Public ReadOnly TotalSize As Long
        Public ReadOnly TotalFreeSpace As Long
        Public ReadOnly AvailableFreeSpace As Long
        Public ReadOnly DriveFormat As String

        Private Shared CurrentPath As String

        Enum DriveCategories
            LocalDisk = 0
            System = 1
            Removable = 2
            CDRom = 3
            Unknown = 4
            Ram = 5
            NoRootDirectory = 6
            Network = 7
        End Enum

        Sub New(path As String)
            Dim driveinf As New DriveInfo(path)
            Try
                If driveinf.IsReady Then
                    CurrentPath = path
                    Exist = True
                    RootDirectoryPath = driveinf.RootDirectory.FullName
                    Name = driveinf.Name
                    VolumeLabel = driveinf.VolumeLabel
                    TotalSize = driveinf.TotalSize
                    TotalFreeSpace = driveinf.TotalFreeSpace
                    AvailableFreeSpace = driveinf.AvailableFreeSpace
                    DriveFormat = driveinf.DriveFormat
                    IsReady = driveinf.IsReady

                    If driveinf.DriveFormat = DriveType.Fixed Then
                        Category = DriveCategories.LocalDisk
                    ElseIf driveinf.DriveType = DriveType.CDRom Then
                        Category = DriveCategories.CDRom
                    ElseIf driveinf.DriveType = DriveType.Removable Then
                        Category = DriveCategories.Removable
                    ElseIf driveinf.DriveType = DriveType.Ram Then
                        Category = DriveCategories.Ram
                    ElseIf driveinf.DriveType = DriveType.NoRootDirectory Then
                        Category = DriveCategories.NoRootDirectory
                    ElseIf driveinf.DriveType = DriveType.Network Then
                        Category = DriveCategories.Network
                    Else
                        Dim fl As New FileInfo(CurrentPath + "drive.ini")
                        If fl.Exists Then
                            Category = DriveCategories.System
                        Else
                            Category = DriveCategories.Unknown
                        End If

                    End If
                End If
            Catch ex As Exception
                Exist = False
                IsReady = driveinf.IsReady
            End Try

        End Sub

    End Class


End Namespace
