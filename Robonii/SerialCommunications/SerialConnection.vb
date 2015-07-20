Imports System.IO.Ports
Imports System.Threading
Imports System.Text

Public Class SerialConnection
    Implements IDisposable

    Private WithEvents incomingCmd As BaseCommand
    Private mySerialPort As New SerialPort
    Private packetNumber As Integer
    Private offset As Integer
    Private lock As New Object()

#Region " Properties "

    Public Property ChannelNo As Integer
    Public Property PortName As String
    Public Property BaudRate As Integer
    Public Property DataBits As Integer
    Public Property Parity As Parity
    Public Property StopBits As StopBits
    Public Property HandShake As Handshake

    Public ReadOnly Property IsConnected As Boolean
        Get
            If Me.mySerialPort Is Nothing Then
                Return False
            End If

            Return Me.mySerialPort.IsOpen
        End Get
    End Property

#End Region

#Region " Constructor "

    Public Sub New(channelNo As Integer, portName As String, baudRate As Integer, dataBits As Integer, parity As Parity, stopBits As StopBits, handShake As Handshake)
        Me.ChannelNo = channelNo
        Me.PortName = portName
        Me.BaudRate = baudRate
        Me.DataBits = dataBits
        Me.Parity = parity
        Me.StopBits = stopBits
        Me.HandShake = handShake
    End Sub

    Public Sub New(channelNo As Integer, portName As String)
        Me.New(channelNo, portName, 115200, 8, IO.Ports.Parity.None, IO.Ports.StopBits.Two, IO.Ports.Handshake.None)
    End Sub

#End Region

#Region " Events "
    Public Delegate Sub CommandRecievedHandler(sender As SerialConnection, command As BaseCommand)

    Public Event CommandReceived As CommandRecievedHandler
#End Region

#Region " Receive "


    Public Sub ReceiveAsync()
        Dim threadStart As New ThreadStart(AddressOf Me.Receive)
        Dim thread As New Thread(threadStart)
        thread.Start()
    End Sub

    Public Sub Receive()
        AddHandler mySerialPort.DataReceived, AddressOf ReceiveSerialBytes
        With mySerialPort
            .PortName = Me.PortName
            .BaudRate = Me.BaudRate
            .DataBits = Me.DataBits
            .Parity = Me.Parity
            .StopBits = Me.StopBits
            .Handshake = Me.HandShake
        End With

        Try
            Me.resetCommand()
            mySerialPort.Open()
        Catch ex As Exception
            MessageBox.Show(String.Format("Failed to connect to device on Port '{0}'", Me.PortName), "Could not connect to device", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Read data from port when it becomes available, and send it to AppendByte and AppendString and append string Decimal
    Private Sub ReceiveSerialBytes(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        SyncLock (lock)
            'Handles serial port data received events 
            Dim n As Integer = mySerialPort.BytesToRead
            Dim comBuffer As Byte() = New Byte(n - 1) {}
            mySerialPort.Read(comBuffer, 0, n)

            For i = 0 To comBuffer.Length - 1
                '// Current the packets
                If Not CommandManager.BuildCommand(comBuffer, Me.incomingCmd, Me.packetNumber, i, Me.offset) Then
                    Me.resetCommand()
                End If
            Next
        End SyncLock
    End Sub

    Private Sub cmdBuilt(cmd As BaseCommand) Handles incomingCmd.CommandBuiltSuccessfully
        RaiseEvent CommandReceived(Me, cmd)
    End Sub

    Private Sub resetCommand()
        Me.packetNumber = 1 '// Default we start with the packet no. 1
        Me.offset = 0
        Me.incomingCmd = Nothing
    End Sub

#End Region

#Region " Send "

    Public Sub Send(outgoingCmd As BaseCommand)
        'Convert the command to a byte array and then send it.
        Dim sendBytes = CommandManager.TranslateToBytes(outgoingCmd)
        Me.Send(sendBytes)
    End Sub

    Public Sub Send(sendBytes As Byte())
        If sendBytes Is Nothing OrElse sendBytes.Length = 0 Then
            Exit Sub
        End If

        'Send the command to the Serial device
        mySerialPort.Write(sendBytes, 0, sendBytes.Length)
    End Sub

#End Region

#Region " IDisposable Members "

    Public Sub Dispose() Implements IDisposable.Dispose
        If Me.mySerialPort IsNot Nothing Then
            RemoveHandler mySerialPort.DataReceived, AddressOf ReceiveSerialBytes
            If Me.mySerialPort.IsOpen Then
                Me.mySerialPort.Close()
            End If
            Me.mySerialPort.Dispose()
        End If
    End Sub

#End Region

End Class