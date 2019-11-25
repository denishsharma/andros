Namespace DefineRoots

    Public Class DefinitionMethod

        Public Shared Function ConvertToPath(path As String) As String
            If path.Contains("%regroot%") Then
                Return path.Replace("%regroot%", Registry.Define(0))
            ElseIf path.Contains("%regroot_fa%") Then
                Return path.Replace("%regroot_fa%", Registry.Define(1))
            ElseIf path.Contains("%regroot_cl%") Then
                Return path.Replace("%regroot_cl%", Registry.Define(2))
            ElseIf path.Contains("%regroot_usr%") Then
                Return path.Replace("%regroot_usr%", Registry.Define(3))
            ElseIf path.Contains("%regroot_key%") Then
                Return path.Replace("%regroot_key%", Registry.Define(4))
            End If

            If path.Contains("%andros%") Then
                Return path.Replace("%andros%", FileSystem.Define(0))
            ElseIf path.Contains("%andros_sys%") Then
                Return path.Replace("%andros_sys%", FileSystem.Define(1))
            ElseIf path.Contains("%andros_prg%") Then
                Return path.Replace("%andros_prg%", FileSystem.Define(2))
            ElseIf path.Contains("%andros_usr%") Then
                Return path.Replace("%andros_usr%", FileSystem.Define(3))
            ElseIf path.Contains("%andros_updt%") Then
                Return path.Replace("%andros_updt%", FileSystem.Define(4))
            ElseIf path.Contains("%andros_dat%") Then
                Return path.Replace("%andros_dat%", FileSystem.Define(5))
            End If

            If path.Contains("%user%") Then
                Return path.Replace("%user%", Users.Define(0))
            ElseIf path.Contains("%user_loc%") Then
                Return path.Replace("%user_loc%", Users.Define(1))
            ElseIf path.Contains("%user_pub%") Then
                Return path.Replace("%user_pub%", Users.Define(2))
            ElseIf path.Contains("%curruser%") Then
                Return path.Replace("%curruser%", Users.Define(3))
            ElseIf path.Contains("%user_admin%") Then
                Return path.Replace("%user_admin%", Users.Define(4))
            ElseIf path.Contains("%appdata%") Then
                Return path.Replace("%appdata%", Users.Define(5))
            ElseIf path.Contains("%user_dsk%") Then
                Return path.Replace("%user_dsk%", Users.Define(6))
            ElseIf path.Contains("%temp%") Then
                Return path.Replace("%temp%", Users.Define(7))
            ElseIf path.Contains("%user_doc%") Then
                Return path.Replace("%user_doc%", Users.Define(8))
            ElseIf path.Contains("%user_down%") Then
                Return path.Replace("%user_down%", Users.Define(9))
            ElseIf path.Contains("%user_music%") Then
                Return path.Replace("%user_music%", Users.Define(10))
            ElseIf path.Contains("%user_pics%") Then
                Return path.Replace("%user_pics%", Users.Define(11))
            ElseIf path.Contains("%user_vids%") Then
                Return path.Replace("%user_vids%", Users.Define(12))
            ElseIf path.Contains("%user_home%") Then
                Return path.Replace("%user_home%", Users.Define(13))
            End If
            Return Nothing
        End Function

    End Class

    Public Class Registry

        Public Shared ReadOnly MainRoot As String = "%regroot%" 'Program Files/Common/Andros/Data/Registry/
        Public Shared ReadOnly FileAssociationRoot As String = "%regroot_fa%" 'Program Files/Common/Andros/Data/Registry/User/%curruser%/File Association/
        Public Shared ReadOnly ClassesRoot As String = "%regroot_cl%" 'Program Files/Common/Andros/Data/Registry/Public/Main Classes/
        Public Shared ReadOnly UserRoot As String = "%regroot_usr%" 'Program Files/Common/Andros/Data/Registry/User/
        Public Shared ReadOnly KeyRoot As String = "%regroot_key%" 'Program Files/Common/Andros/Data/Registry/Public/Main Classes/LocKey/

        Public Enum RegistryDefinitions
            MainRoot = 0
            FileAssociationRoot = 1
            ClassesRoot = 2
            UserRoot = 3
            KeyRoot = 4
        End Enum

        Public Shared Function Define(definition As RegistryDefinitions) As String
            Dim i = "Program Files/Common/Andros/Data/"
            Select Case definition
                Case 0
                    Return i + "Registry"
                Case 1
                    Return i + "Registry/User/%curruser%/File Association"
                Case 2
                    Return i + "Registry/Public/Main Classes"
                Case 3
                    Return i + "Registry/User"
                Case 4
                    Return i + "Registry/Public/Main Classes/LocKey"
            End Select
            Return Nothing
        End Function

    End Class

    Public Class FileSystem

        Public Shared ReadOnly AndrosRoot As String = "%andros%" 'Program Files/Andros/
        Public Shared ReadOnly AndrosSystemRoot As String = "%andros_sys%" 'Program Files/Andros/Andros/
        Public Shared ReadOnly AndrosProgramFilesRoot As String = "%andros_prg%" 'Program Files/Andros/Program Files/
        Public Shared ReadOnly AndrosUserRoot As String = "%andros_usr%" 'Program Files/Andros/User/
        Public Shared ReadOnly AndrosUpdatesRoot As String = "%andros_updt%" 'Program Files/Andros/Updates/
        Public Shared ReadOnly AndrosAppDataRoot As String = "%andros_dat%" 'Program Files/Andros/Data/

        Public Enum FileSystemDefinitions
            AndrosRoot = 0
            AndrosSystemRoot = 1
            AndrosProgramFilesRoot = 2
            AndrosUserRoot = 3
            AndrosUpdatesRoot = 4
            AndrosAppDataRoot = 5
        End Enum

        Public Shared Function Define(definition As FileSystemDefinitions) As String
            Dim i = "Program Files/Andros"
            Select Case definition
                Case 0
                    Return i
                Case 1
                    Return i + "/Andros"
                Case 2
                    Return i + "/Program Files"
                Case 3
                    Return i + "/User"
                Case 4
                    Return i + "/Updates"
                Case 5
                    Return i + "/Data"
            End Select
            Return Nothing
        End Function

    End Class

    Public Class Users

        Public Shared ReadOnly UsersRoot As String = "%user%" 'Program Files/Andros/User/
        Public Shared ReadOnly UsersLocalRoot As String = "%user_loc%" 'Program Files/Andros/User/%curruser%/Local/
        Public Shared ReadOnly UsersPublicRoot As String = "%user_pub%" 'Program Files/Andros/User/%curruser%/Public/
        Public Shared ReadOnly CurrentUserRoot As String = "%curruser%" 'Program Files/Andros/User/%curruser%/
        Public Shared ReadOnly AdminRoot As String = "%user_admin%" 'Program Files/Andros/User/Admin/
        Public Shared ReadOnly AppDataRoot As String = "%appdata%" 'Program Files/Andros/User/%curruser%/Local/AppData/
        Public Shared ReadOnly DesktopRoot As String = "%user_dsk%" 'Program Files/Andros/User/%curruser%/Local/Desktop/
        Public Shared ReadOnly TempRoot As String = "%temp%" 'Program Files/Andros/User/%curruser%/Local/AppData/Temp/
        Public Shared ReadOnly DocumentsRoot As String = "%user_doc%" 'Program Files/Andros/User/%curruser%/Local/Documents/
        Public Shared ReadOnly DownloadsRoot As String = "%user_down%" 'Program Files/Andros/User/%curruser%/Local/Downloads/
        Public Shared ReadOnly MusicsRoot As String = "%user_music%" 'Program Files/Andros/User/%curruser%/Local/Musics/
        Public Shared ReadOnly PicturesRoot As String = "%user_pics%" 'Program Files/Andros/User/%curruser%/Local/Pictures/
        Public Shared ReadOnly VideosRoot As String = "%user_vids%" 'Program Files/Andros/User/%curruser%/Local/Videos/
        Public Shared ReadOnly HomeRoot As String = "%user_home%" 'Program Files/Andros/User/%curruser%/Local/Home/

        Public Enum UsersDefinitions
            UsersRoot = 0
            UsersLocalRoot = 1
            UsersPublicRoot = 2
            CurrentUserRoot = 3
            AdminRoot = 4
            AppDataRoot = 5
            DesktopRoot = 6
            TempRoot = 7
            DocumentsRoot = 8
            DownloadsRoot = 9
            MusicsRoot = 10
            PicturesRoot = 11
            VideosRoot = 12
            HomeRoot = 13
        End Enum


        Public Shared Function Define(definition As UsersDefinitions) As String
            Dim i = "Program Files/Andros/User/%curruser%/Local"
            Select Case definition
                Case 0
                    Return "/Program Files/Andros/User"
                Case 1
                    Return i
                Case 2
                    Return "/Program Files/Andros/User/%curruser%/Public"
                Case 3
                    Return "/Program Files/Andros/User/%curruser%"
                Case 4
                    Return "/Program Files/Andros/User/Admin"
                Case 5
                    Return i + "/AppData"
                Case 6
                    Return i + "/Desktop"
                Case 7
                    Return i + "/AppData/Temp"
                Case 8
                    Return i + "/Documents"
                Case 9
                    Return i + "/Downloads"
                Case 10
                    Return i + "/Musics"
                Case 11
                    Return i + "/Pictures"
                Case 12
                    Return i + "/Videos"
                Case 13
                    Return i + "/Home"
            End Select
            Return Nothing
        End Function

    End Class

End Namespace