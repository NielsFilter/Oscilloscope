Public MustInherit Class BaseCommand

    Public Const DEVICENAME_LENGTH As Integer = 5
    Public Const DATASTREAMBYTE_LENGTH As Integer = 2

    '0 - 1: StartBytes
    Public Shared StartByte1 As Byte = &HF5 '0xF5
    Public Shared StartByte2 As Byte = &H5  '0x05


#Region " Events "
    Public Delegate Sub CommandBuiltHandler(command As BaseCommand)

    Public Event CommandBuiltSuccessfully As CommandBuiltHandler
#End Region

#Region " Properties "

    '2: Packet Type
    Public MustOverride ReadOnly Property PacketType As PacketTypes

    '3 - 7: Device Name
    Private _deviceName As String = New String(" ", DEVICENAME_LENGTH)
    Public Property DeviceName As String
        Get
            Return Me._deviceName
        End Get
        Set(value As String)
            If value.Length <> DEVICENAME_LENGTH Then
                Throw New ArgumentException(String.Format("DeviceName must be {0} characters", DEVICENAME_LENGTH))
            End If
            Me._deviceName = value
        End Set
    End Property

    '8: Time Division Parameter
    Private _timeDivision As Integer
    Public Property TimeDivision As Integer
        Get
            Return Me._timeDivision
        End Get
        Set(value As Integer)
            Me._timeDivision = value
        End Set
    End Property

    '9: VTrigger
    Private _vTrigger As Integer
    Public Property VTrigger As Integer
        Get
            Return Me._vTrigger
        End Get
        Set(value As Integer)
            Me._vTrigger = value
        End Set
    End Property

    '10: Gain
    Private _gain As GainTypes = GainTypes.x1
    Public Property Gain As GainTypes
        Get
            Return Me._gain
        End Get
        Set(value As GainTypes)
            Me._gain = value
        End Set
    End Property

    '11: Packet Number
    Private _packetNumber As Integer
    Public Property PacketNumber As Integer
        Get
            Return Me._packetNumber
        End Get
        Set(value As Integer)
            Me._packetNumber = value
        End Set
    End Property

    '12: Total Packets
    Private _totalPackets As Integer
    Public Property TotalPackets As Integer
        Get
            Return Me._totalPackets
        End Get
        Set(value As Integer)
            Me._totalPackets = value
        End Set
    End Property

    '13: Command
    Private _command As Integer
    Public Property Command As Integer
        Get
            Return Me._command
        End Get
        Set(value As Integer)
            Me._command = value
        End Set
    End Property

    '14 - 15: Data Stream Length
    Private _dataStreamLength As Integer
    Public Property DataStreamLength As Integer
        Get
            Return Me._dataStreamLength
        End Get
        Set(value As Integer)
            Dim maxValue = 256 * DATASTREAMBYTE_LENGTH
            If value > maxValue Then
                Throw New ArgumentException(String.Format("Data Stream Length must be less than {0}, which is {1} bytes", maxValue, DATASTREAMBYTE_LENGTH))
            End If

            Me._dataStreamLength = value
        End Set
    End Property

    '16 - 17: Data Stream Position
    Private _dataStreamPosition As Integer
    Public Property DataStreamPosition As Integer
        Get
            Return Me._dataStreamPosition
        End Get
        Set(value As Integer)
            Dim maxValue = 256 * DATASTREAMBYTE_LENGTH
            If value > maxValue Then
                Throw New ArgumentException(String.Format("Data Stream Position must be less than {0}, which is {1} bytes", maxValue, DATASTREAMBYTE_LENGTH))
            End If

            Me._dataStreamPosition = value
        End Set
    End Property

    '18: CRC Header
    Private _crcHeader As Byte
    Public Property CRCHeader As Byte
        Get
            Return Me._crcHeader
        End Get
        Set(value As Byte)
            Me._crcHeader = value
        End Set
    End Property

    '19 - n: Data
    Private _data As List(Of Byte)
    Public Property Data As List(Of Byte)
        Get
            Return Me._data
        End Get
        Set(value As List(Of Byte))
            Me._data = value
        End Set
    End Property

    'n + 1: CRC Data
    Public ReadOnly Property CRCData As Byte
        Get
            Return 0 'TODO: Implement Header Check
        End Get
    End Property

#End Region

    Private offset As Integer = 0
    Public Function BuildFromBytes(ByRef bytes As Byte(), ByRef startPosition As Integer, ByRef offset As Integer) As Boolean
        Dim currentByte = bytes(startPosition)

        Try
            Select Case Me.offset
                'Case 0 'Start Byte 1
                '    If currentByte = Me.StartByte1 Then
                '        Me.offset += 1
                '    Else
                '        Return False
                '    End If

                'Case 1 'Start Byte 2
                '    If currentByte = Me.StartByte2 Then
                '        Me.offset += 1
                '    Else
                '        Return False
                '    End If

                'Case 2 'Packet Type
                '    'TODO: See if theres a dynamic way to incorporate HexCode attribute
                '    If currentByte = &H53 Then
                '        Me.PacketType = PacketTypes.Oscilloscope
                '        Me.offset += 1
                '    ElseIf currentByte = &H46 Then
                '        Me.PacketType = PacketTypes.FFT
                '        Me.offset += 1
                '    Else
                '        Return False
                '    End If

                Case 3 'Device Name
                    Dim diviceNameBytes = bytes.Skip(startPosition).Take(BaseCommand.DEVICENAME_LENGTH).ToArray()
                    Me.DeviceName = Utils.ByteToASCII(diviceNameBytes)
                    offset += BaseCommand.DEVICENAME_LENGTH
                    startPosition += BaseCommand.DEVICENAME_LENGTH - 1
                    'TODO: Look for a better way to combine offset and start position

                Case 8 'Time Division Param
                    Me.TimeDivision = currentByte
                    offset += 1

                Case 9 'V Trigger
                    Me.VTrigger = currentByte
                    offset += 1

                Case 10 'Gain
                    Dim gain As Integer = currentByte
                    'Me.Gain = 
                    Me.offset += 1

                Case 11 'Packet Number
                    Me.PacketNumber = currentByte
                    Me.offset += 1

                Case 12 'Total Packets
                    Me.TotalPackets = currentByte
                    Me.offset += 1

                Case 13 'Command
                    Me.Command = currentByte
                    Me.offset += 1

                Case 14 'Data Stream Length
                    'TODO: current byte must be 2 lengths
                    Me.DataStreamLength = currentByte
                    Me.offset += BaseCommand.DATASTREAMBYTE_LENGTH
                    startPosition += BaseCommand.DATASTREAMBYTE_LENGTH - 1

                Case 16 'Data Stream Position
                    'TODO: current byte must be 2 lengths
                    Me.DataStreamPosition = currentByte
                    Me.offset += BaseCommand.DATASTREAMBYTE_LENGTH
                    startPosition += BaseCommand.DATASTREAMBYTE_LENGTH - 1

                Case 18 ' CRC Header
                    'TODO: Calculate CRC Header
                    Dim isCRCCorrect As Boolean = True
                    If isCRCCorrect Then
                        'Correct CRC Header
                        Me.CRCHeader = currentByte
                        Me.offset += 1
                    Else
                        'Invalid CRC Header, cannot trust data.
                        Return False
                    End If

                Case 19 'Data
                    If Me.PacketType = PacketTypes.Oscilloscope Then
                        If Me.Data Is Nothing Then
                            Me.Data = New List(Of Byte)()
                        Else
                            Return False
                        End If

                        Me.Data.AddRange(bytes.Skip(startPosition).Take(10))
                    End If
                Case Else
                    If Me.offset > 19 Then '// TODO: Work out which byte is the actual CRC
                        RaiseEvent CommandBuiltSuccessfully(Me)
                    End If
            End Select

            Return True
        Catch
            Return False
        End Try

    End Function

    Public Sub DoneBuildingCommand()
        RaiseEvent CommandBuiltSuccessfully(Me)
    End Sub

End Class
