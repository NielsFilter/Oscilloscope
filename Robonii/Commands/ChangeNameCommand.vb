Public Class ChangeNameCommand
    Inherits BaseCommand

    Public Overrides ReadOnly Property Command As CommandTypes
        Get
            Return CommandTypes.ChangeName
        End Get
    End Property

    Public Sub SetNewName(newDeviceName As String)
        If String.IsNullOrWhiteSpace(newDeviceName) OrElse newDeviceName.Trim().Length <> BaseCommand.DEVICENAME_LENGTH Then
            Throw New ArgumentException("Device name must be " & BaseCommand.DEVICENAME_LENGTH & " characters long)")
        End If

        MyBase.Data = System.Text.Encoding.ASCII.GetBytes(newDeviceName.ToArray()).ToList()
        MyBase.DataStreamLength = MyBase.Data.Count
    End Sub

End Class
