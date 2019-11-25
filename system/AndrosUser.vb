Public Class AndrosUser

    Public Shared Users As New List(Of User)

    Public Shared Sub LoadUser()
    End Sub

    Public Shared Sub CreateUser(name As String, password As String, iconpath As String)
        Users.Add(New User(name, password, iconpath, False))
    End Sub

    Public Shared Sub DeleteUser(name As String, password As String)
        Dim u As User = Users.Find(Function(a)
                                       If a.Username = name And a.Password = password Then
                                           Return True
                                       End If
                                       Return Nothing
                                   End Function)
        Users.Remove(u)
    End Sub

    Public Shared Sub ChangePassword(name As String, oldPassword As String, newPassword As String)
        Dim u As User = Users.Find(Function(a)
                                       If a.Username = name And a.Password = oldPassword Then
                                           Return True
                                       End If
                                       Return Nothing
                                   End Function)
        u.ChangeArgument(newPassword, User.UserArguments.Password)
    End Sub

    Public Shared Sub ChangeIcon(name As String, password As String, iconpath As String)
        Dim u As User = Users.Find(Function(a)
                                       If a.Username = name And a.Password = password Then
                                           Return True
                                       End If
                                       Return Nothing
                                   End Function)
        u.ChangeArgument(iconpath, User.UserArguments.IconPath)
    End Sub

    Public Shared Sub ChangeUsername(name As String, newName As String, password As String)
        Dim u As User = Users.Find(Function(a)
                                       If a.Username = name And a.Password = password Then
                                           Return True
                                       End If
                                       Return Nothing
                                   End Function)
        u.ChangeArgument(newName, User.UserArguments.Username)
    End Sub

    Public Shared Sub MakeUserAdmin(name As String, password As String, adminPassword As String)
        Dim u As User = Users.Find(Function(a)
                                       If a.Username = name And a.Password = password Then
                                           Return True
                                       End If
                                       Return Nothing
                                   End Function)
        u.ChangeArgument(True, User.UserArguments.IsAdmin)
    End Sub

    Public Shared Sub RemoveUserAdmin(name As String, adminPassword As String)
        Dim u As User = Users.Find(Function(a)
                                       If a.Username = name Then
                                           Return True
                                       End If
                                       Return Nothing
                                   End Function)
        u.ChangeArgument(False, User.UserArguments.IsAdmin)
    End Sub

    Public Shared Function GetCurrentUser() As User
        Return New User
    End Function

    Public Shared Function UserCount() As Integer
        Return Users.Count
    End Function

End Class

Public Class User
    Private _admin, _locked As Boolean : Private _name, _icon, _pass As Object

    Public ReadOnly Property IsAdmin As Boolean
        Get
            Return _admin
        End Get
    End Property
    Public ReadOnly Property IsLocked As Boolean
        Get
            Return _locked
        End Get
    End Property
    Public ReadOnly Property Username As String
        Get
            Return _name
        End Get
    End Property
    Public ReadOnly Property IconPath As String
        Get
            Return _icon
        End Get
    End Property
    Public ReadOnly Property Password As String
        Get
            Return _pass
        End Get
    End Property

    Sub New()
    End Sub
    Sub New(name As String, password As String, iconpath As String, admin As Boolean)

    End Sub

    Public Sub ChangeArgument(value As Object, userArg As UserArguments)
        If userArg = 0 Then
            _admin = value
        ElseIf userArg = 1 Then
            _name = value
        ElseIf userArg = 2 Then
            _icon = value
        ElseIf userArg = 3 Then
            _pass = value
        ElseIf userArg = 4 Then
            _locked = value
        End If
    End Sub

    Enum UserArguments
        IsAdmin = 0
        Username = 1
        IconPath = 2
        Password = 3
        IsLocked = 4
    End Enum
End Class