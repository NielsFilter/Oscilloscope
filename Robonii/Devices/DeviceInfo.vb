Public Class DeviceInfo
    Implements IDisposable

    Public Sub New(id As Integer)
        Me.setDefaultValues()
    End Sub

    Public Delegate Sub DeviceCommandRecievedHandler(device As DeviceInfo, cmd As IncomingCommand)
    Public Shared Event DeviceCommandReceived As DeviceCommandRecievedHandler

    Public WithEvents SerialConn As SerialConnection

    Public Property Id As Integer
    Public Property Name As String
    Public Property Message As String
    Public Property COMPort As String
    Public Property IsConnected As Boolean

    Private Sub setDefaultValues()
        '// Some default values
        Me.Message = "Not Connected"
        Me.Name = "Device" & Id
        Me.COMPort = "COM0"
        Me.IsConnected = False
    End Sub

    Public Sub Connect()
        If IsConnected Then
            Me.Disconnect()
        End If

        Me.SerialConn = New SerialConnection(Me.COMPort)
        Me.SerialConn.ReceiveAsync()
        Me.IsConnected = True
    End Sub

    Public Sub Disconnect()
        If Me.SerialConn IsNot Nothing Then
            Me.SerialConn.Dispose()
        End If

        Me.setDefaultValues()
    End Sub

    Public Sub BytesReceived(sender As SerialConnection, cmd As IncomingCommand) Handles SerialConn.CommandReceived
        RaiseEvent DeviceCommandReceived(Me, cmd)
    End Sub

#Region "IDisposable "
    Public Sub Dispose() Implements IDisposable.Dispose
        If Me.SerialConn IsNot Nothing Then
            Me.SerialConn.Dispose()
        End If
    End Sub
#End Region

End Class