Public Class CommandManager

    Public Shared Function SendCommand(cmd As FFTCommand)
        Dim outgoingBytes As Byte() = TranslateByte(cmd)
        'TODO: Send command to Device
    End Function

    ''' <summary>
    ''' This Method translates our <see cref="OutgoingCommand"/> into a byte array.
    ''' </summary>
    ''' <param name="cmd">The <see cref="OutgoingCommand"/> instance we are converting.</param>
    ''' <returns>A byte array converted from the command sent.</returns>
    ''' <remarks>
    ''' The idea behind this method is to bring our object that we used and manipulated back into a byte array
    ''' which can now be used to send to the device. Working in CLR Types (objects), is much easier and so we
    ''' typically stay in the object world until the command needs to go out.
    ''' </remarks>
    Public Shared Function TranslateByte(cmd As FFTCommand) As Byte()
        Dim lstBytes As New List(Of Byte)

        '==============
        '*** Header ***
        '==============

        'Start Bytes
        '// The Start Bytes are constant and are set in the BaseCommand class.
        lstBytes.Add(cmd.StartByte1)
        lstBytes.Add(cmd.StartByte2)

        'Packet Type
        '// Out PacketTypes enum holds the possible packet types.
        '// Each enum value has an 'HexCode' Attribute (the little piece above it), which holds the integer hex value
        '// Here we get that Hex value from the enum value and convert it back to a byte.
        Dim packetType As Integer = HexCodeAttribute.GetHexCode(cmd.PacketType)
        lstBytes.Add(Utils.ToByte(packetType))

        'Name
        '// The validation to limit the name is in the BaseCommand class.
        '// Here we simply get the name and cast it from ASCII back to a byte array.
        lstBytes.AddRange(System.Text.Encoding.ASCII.GetBytes(cmd.DeviceName.ToArray()))

        'Time Division Param
        lstBytes.Add(Utils.ToByte(cmd.TimeDivision))

        'VTrigger
        lstBytes.Add(Utils.ToByte(cmd.VTrigger))

        'Time Division Param
        lstBytes.Add(Utils.ToByte(cmd.TimeDivision))

        'Data Packet Number
        lstBytes.Add(Utils.ToByte(cmd.PacketNumber))

        'Data Packet Total
        lstBytes.Add(Utils.ToByte(cmd.TotalPackets))

        'Data Stream Length
        '// Take the DataStreamLength property and convert it to Byte array (We need an array as the 2 bytes are allocated for this number)
        '// Once we have the byte array, we call Array.Resize to make sure the Byte array is 2 bytes long. (If integer is small, the second byte will be empty).
        Dim dataStreamBytes As Byte() = Utils.ToBytes(cmd.DataStreamLength)
        Array.Resize(dataStreamBytes, BaseCommand.DATASTREAMBYTE_LENGTH)
        lstBytes.AddRange(dataStreamBytes)

        'Data Stream Position
        '// See explanation as 'Data Stream Length' above.
        Dim dataStreamPositionBytes As Byte() = Utils.ToBytes(cmd.DataStreamPosition)
        Array.Resize(dataStreamPositionBytes, BaseCommand.DATASTREAMBYTE_LENGTH)
        lstBytes.AddRange(dataStreamPositionBytes)

        'CRC Header
        '// Automatically calculated in the BaseCommand class.
        lstBytes.Add(cmd.CRCHeader)


        '============
        '*** Body ***
        '============

        'Data
        '// This is the actual Command Data.
        lstBytes.AddRange(cmd.Data)

        'CRC Data
        '// Automatically calculated in the BaseCommand class.
        lstBytes.Add(cmd.CRCData)

        Return Nothing
    End Function

    Public Shared Function TranslateByte(bytes As Byte(), ByRef cmd As BaseCommand, ByRef startPosition As Integer, ByRef offset As Integer) As Boolean

        Dim currentByte = bytes(startPosition)

        Try
            Select Case offset
                Case 0 'Start Byte 1
                    If currentByte = BaseCommand.StartByte1 Then
                        offset += 1
                    Else
                        Return False
                    End If

                Case 1 'Start Byte 2
                    If currentByte = BaseCommand.StartByte2 Then
                        offset += 1
                    Else
                        Return False
                    End If

                Case 2 'Packet Type
                    'TODO: See if theres a dynamic way to incorporate HexCode attribute
                    If currentByte = &H53 Then
                        cmd = New OscilloscopeCommand()
                        offset += 1
                    ElseIf currentByte = &H46 Then
                        cmd = New FFTCommand()
                        offset += 1
                    Else
                        Return False
                    End If

                Case 3 'Device Name
                    Dim diviceNameBytes = bytes.Skip(startPosition).Take(BaseCommand.DEVICENAME_LENGTH).ToArray()
                    cmd.DeviceName = Utils.ByteToASCII(diviceNameBytes)
                    offset += BaseCommand.DEVICENAME_LENGTH
                    startPosition += BaseCommand.DEVICENAME_LENGTH - 1
                    'TODO: Look for a better way to combine offset and start position

                Case 8 'Time Division Param
                    cmd.TimeDivision = currentByte
                    offset += 1

                Case 9 'V Trigger
                    cmd.VTrigger = currentByte
                    offset += 1

                Case 10 'Gain
                    Dim gain As Integer = currentByte
                    'Me.Gain = 
                    'TODO: NF
                    offset += 1

                Case 11 'Packet Number
                    cmd.PacketNumber = currentByte
                    offset += 1

                Case 12 'Total Packets
                    cmd.TotalPackets = currentByte
                    offset += 1

                Case 13 'Command
                    cmd.Command = currentByte
                    offset += 1

                Case 14 'Data Stream Length
                    'TODO: current byte must be 2 lengths
                    cmd.DataStreamLength = currentByte
                    offset += BaseCommand.DATASTREAMBYTE_LENGTH
                    startPosition += BaseCommand.DATASTREAMBYTE_LENGTH - 1

                Case 16 'Data Stream Position
                    'TODO: current byte must be 2 lengths
                    cmd.DataStreamPosition = currentByte
                    offset += BaseCommand.DATASTREAMBYTE_LENGTH
                    startPosition += BaseCommand.DATASTREAMBYTE_LENGTH - 1

                Case 18 ' CRC Header
                    'TODO: Calculate CRC Header
                    Dim isCRCCorrect As Boolean = True
                    If isCRCCorrect Then
                        'Correct CRC Header
                        cmd.CRCHeader = currentByte
                        offset += 1
                    Else
                        'Invalid CRC Header, cannot trust data.
                        Return False
                    End If

                Case 19 'Data
                    If cmd.Data Is Nothing Then
                        cmd.Data = New List(Of Byte)()
                    End If

                    cmd.Data.AddRange(bytes.Skip(startPosition).Take(20))

                    offset += 1
                Case Else
                    If offset > 19 Then '// TODO: Work out which byte is the actual CRC
                        cmd.DoneBuildingCommand()
                    End If
            End Select

            Return True
        Catch
            Return False
        End Try
    End Function

End Class
