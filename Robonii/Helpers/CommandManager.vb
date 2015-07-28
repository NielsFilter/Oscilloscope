Public Class CommandManager

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
    Public Shared Function TranslateToBytes(cmd As BaseCommand) As Byte()
        If cmd Is Nothing Then
            Return Nothing
        End If

        Dim lstBytes As New List(Of Byte)

        '==============
        '*** Header ***
        '==============

        'Start Bytes
        '// The Start Bytes are constant and are set in the BaseCommand class.
        lstBytes.Add(BaseCommand.StartByte1)
        lstBytes.Add(BaseCommand.StartByte2)

        'Packet Type
        '// PacketTypes enum holds the possible packet types. The enum value holds the correct packet type integer value
        lstBytes.Add(cmd.PacketType)

        'Name
        '// The validation to limit the name is in the BaseCommand class.
        '// Here we simply get the name and cast it from ASCII back to a byte array.
        lstBytes.AddRange(Utils.ASCIIToBytes(cmd.DeviceName))

        'Time Division Param
        lstBytes.Add(cmd.TimeDivision)

        'VTrigger
        lstBytes.Add(cmd.VTrigger)

        'Gain
        lstBytes.Add(cmd.Gain)

        'Data Packet Number
        lstBytes.Add(cmd.PacketNumber)

        'Data Packet Total
        lstBytes.Add(cmd.TotalPackets)

        '// CommandType enum holds the possible commands. The enum value holds the correct command integer value.
        lstBytes.Add(cmd.Command)

        'Data Stream Length
        '// Take the DataStreamLength property and convert it to Byte array (We need an array as the 2 bytes are allocated for this number)
        Dim dataStreamBytes As Byte() = Utils.ToBytes(cmd.DataStreamLength, BaseCommand.DATASTREAMBYTE_LENGTH)
        lstBytes.AddRange(dataStreamBytes.Reverse()) '// Call Reverse, since the High byte must come first, but in the above array, the Low byte is first.

        'Data Stream Position
        '// See explanation as 'Data Stream Length' above.
        Dim dataStreamPositionBytes As Byte() = Utils.ToBytes(cmd.DataStreamPosition, BaseCommand.DATASTREAMBYTE_LENGTH)
        lstBytes.AddRange(dataStreamPositionBytes.Reverse()) '// Call Reverse, since the High byte must come first, but in the above array, the Low byte is first.

        '// Set Header Bytes (This is needed to calculate CRC Header)
        cmd.HeaderBytes = lstBytes

        'CRC Header
        '// Automatically calculated in the BaseCommand class.
        lstBytes.Add(cmd.CRCHeader)


        '============
        '*** Body ***
        '============

        'Data
        '// This is the actual Command Data.
        lstBytes.AddRange(cmd.Data)

        '// Set All Bytes (This is needed to calculate CRC Data)
        cmd.AllBytes = lstBytes

        'CRC Data
        '// Automatically calculated in the BaseCommand class.
        lstBytes.Add(cmd.CRCData)

        Return lstBytes.ToArray()
    End Function

    Public Shared Function BuildCommand(bytes As Byte(), ByRef cmd As BaseCommand, ByRef packetNumber As Integer, ByRef startPosition As Integer, ByRef offset As Integer) As Boolean

        Dim isMorePacketsToFollow As Boolean = False
        Dim currentByte = bytes(startPosition)

        Try
            Select Case offset
                Case 0 'Start Byte 1
                    If currentByte <> BaseCommand.StartByte1 Then
                        Return False
                    End If

                    offset += 1

                Case 1 'Start Byte 2
                    If currentByte <> BaseCommand.StartByte2 Then
                        Return False
                    End If

                    offset += 1

                Case 2 'Packet Type
                    If currentByte = &H53 Then
                        cmd = New OscilloscopeCommand()
                    ElseIf currentByte = &H46 Then
                        cmd = New FFTCommand()
                    Else
                        Return False
                    End If

                    '// Since we only instantiate the command here, now we can do the checksum for the start bytes and packet type byte.
                    cmd.HeaderBytes = New List(Of Byte)()
                    cmd.AllBytes = New List(Of Byte)()
                    cmd.AddHeaderBytes(BaseCommand.StartByte1, BaseCommand.StartByte2, currentByte)

                    offset += 1

                Case 3 To 7 'Device Name
                    Dim bytesToTake = BaseCommand.DEVICENAME_LENGTH - (offset - 3)

                    Dim diviceNameBytes = bytes.Skip(startPosition).Take(bytesToTake).ToArray()
                    If diviceNameBytes.Length < BaseCommand.DEVICENAME_LENGTH Then
                        '// Name bytes are not together. Build it as we receive.
                        '// We first get translate the part of bytes we did receive to ASCII
                        Dim deviceNamePart = Utils.ByteToASCII(diviceNameBytes)
                        '// Now we remove the existing bytes from the existing name (if not set, then we're simply removing spaces)
                        Dim currentDeviceName = cmd.DeviceName.Remove(offset - 3, deviceNamePart.Length)
                        '// Finally we insert the new ASCII part to the name and set the property.
                        cmd.DeviceName = currentDeviceName.Insert(offset - 3, deviceNamePart)
                    Else
                        '// All name bytes are together, simply use them.
                        cmd.DeviceName = Utils.ByteToASCII(diviceNameBytes)
                    End If

                    cmd.AddHeaderBytes(diviceNameBytes)
                    startPosition += diviceNameBytes.Length - 1
                    offset += diviceNameBytes.Length

                Case 8 'Time Division Parameter
                    cmd.TimeDivision = currentByte

                    cmd.AddHeaderBytes(currentByte)
                    offset += 1

                Case 9 'V Trigger
                    cmd.VTrigger = currentByte

                    cmd.AddHeaderBytes(currentByte)
                    offset += 1

                Case 10 'Gain
                    Dim gain As Integer = currentByte
                    If Not [Enum].IsDefined(GetType(GainTypes), gain) Then
                        Return False
                    End If

                    cmd.Gain = gain
                    cmd.AddHeaderBytes(currentByte)
                    offset += 1

                Case 11 'Packet Number
                    cmd.PacketNumber = currentByte

                    If cmd.PacketNumber <> packetNumber Then
                        Return False '// We've received a different packet number than expected.
                    End If

                    cmd.AddHeaderBytes(currentByte)
                    offset += 1

                Case 12 'Total Packets
                    cmd.TotalPackets = currentByte

                    If cmd.PacketNumber < cmd.TotalPackets Then
                        isMorePacketsToFollow = True
                        packetNumber += 1 '// Next time we come past here, we expect the "next" packet.
                    ElseIf cmd.PacketNumber > cmd.TotalPackets Then
                        Return False '// Not possible. Data invalid, chuck it.
                    Else
                        isMorePacketsToFollow = False
                    End If

                    cmd.AddHeaderBytes(currentByte)
                    offset += 1

                Case 13 'Command
                    Dim commandValue As Integer = currentByte
                    If Not [Enum].IsDefined(GetType(CommandTypes), commandValue) Then
                        Return False
                    End If

                    '// We don't set the command. Each command type is set in stone.
                    '// So what we do here is we check that the command type that we have is correct according to the current command we're building.
                    '// If it's not, chuck it out. If it is, simply carry on.
                    If cmd.Command <> currentByte Then
                        Return False
                    End If

                    cmd.AddHeaderBytes(currentByte)
                    offset += 1

                Case 14 To 15 'Data Stream Length
                    Dim bytesToTake = IIf(offset = 14, BaseCommand.DATASTREAMBYTE_LENGTH, BaseCommand.DATASTREAMBYTE_LENGTH - 1)
                    Dim dataStreamLengthByteArr = bytes.Skip(startPosition).Take(bytesToTake).ToArray()

                    If dataStreamLengthByteArr.Count = 1 Then
                        '// Our 2 bytes are split up, then next one will be in another buffer.
                        Dim dataStreamLengthByte = dataStreamLengthByteArr.ElementAt(0)
                        If offset = 14 Then
                            '// We're receiving the first one (HIGH Byte).
                            cmd.DataStreamLength = CType(dataStreamLengthByte, Short) << 8
                        Else
                            '// We're receiving the second one (LOW Byte).
                            cmd.DataStreamLength = cmd.DataStreamLength Or CType(dataStreamLengthByte, Short)
                        End If
                        cmd.AddHeaderBytes(dataStreamLengthByte)
                    Else
                        '// Both bytes are together, simply use them.
                        cmd.DataStreamLength = CType(dataStreamLengthByteArr.ElementAt(0), Short) << 8 Or CType(dataStreamLengthByteArr.ElementAt(1), Short)
                        cmd.AddHeaderBytes(dataStreamLengthByteArr.ElementAt(0), dataStreamLengthByteArr.ElementAt(1))  '// We pass the 2 Data Stream Length bytes as an array
                    End If

                    offset += dataStreamLengthByteArr.Length
                    startPosition += dataStreamLengthByteArr.Length - 1

                Case 16 To 17 'Data Stream Position
                    Dim bytesToTake = IIf(offset = 16, BaseCommand.DATASTREAMBYTE_LENGTH, BaseCommand.DATASTREAMBYTE_LENGTH - 1)
                    Dim dataStreamPositionByteArr = bytes.Skip(startPosition).Take(bytesToTake).ToArray()

                    If dataStreamPositionByteArr.Count = 1 Then
                        '// Our 2 bytes are split up, then next one will be in another buffer.
                        Dim dataStreamPositionByte = dataStreamPositionByteArr.ElementAt(0)
                        If offset = 16 Then
                            '// We're receiving the first one (HIGH Byte).
                            cmd.DataStreamPosition = CType(dataStreamPositionByte, Short) << 8
                        Else
                            '// We're receiving the second one (LOW Byte).
                            cmd.DataStreamPosition = cmd.DataStreamPosition Or CType(dataStreamPositionByte, Short)
                        End If
                        cmd.AddHeaderBytes(dataStreamPositionByte)
                    Else
                        '// Both bytes are together, simply use them.
                        cmd.DataStreamPosition = CType(dataStreamPositionByteArr.ElementAt(0), Short) << 8 Or CType(dataStreamPositionByteArr.ElementAt(1), Short)
                        cmd.AddHeaderBytes(dataStreamPositionByteArr.ElementAt(0), dataStreamPositionByteArr.ElementAt(1))  '// We pass the 2 Data Stream Position bytes as an array
                    End If

                    offset += dataStreamPositionByteArr.Length
                    startPosition += dataStreamPositionByteArr.Length - 1

                Case 18 ' CRC Header
                    If cmd.CRCHeader <> currentByte Then
                        'Invalid CRC Header, cannot trust data.
                        Return False
                    End If

                    cmd.AddBodyBytes(currentByte)
                    offset += 1

                    '// Data and CRC header
                Case Else
                    Dim crcDataIndex = (19 + cmd.DataStreamLength)

                    If offset > 18 AndAlso offset < crcDataIndex Then
                        '// Data
                        If cmd.Data Is Nothing Then
                            cmd.Data = New List(Of Byte)()
                        End If

                        Dim bytesToTake = cmd.DataStreamLength - cmd.Data.Count

                        Dim dataByteArr = bytes.Skip(startPosition).Take(bytesToTake).ToArray()
                        For Each b In dataByteArr
                            cmd.Data.Add(b)

                            cmd.AddBodyBytes(b)
                            offset += 1
                        Next

                        startPosition += dataByteArr.Length - 1

                    ElseIf offset = crcDataIndex Then
                        '// CRC Data
                        If cmd.CRCData <> currentByte Then
                            'Invalid CRC Data, cannot trust data.
                            Return False
                        End If

                        '// Reset offset
                        offset = 0

                        If cmd.PacketNumber = cmd.TotalPackets Then
                            '// We're not expecting anymore packets. Signal that we're done.
                            cmd.DoneBuildingCommand()
                        End If

                    Else
                        Return False
                    End If
            End Select

            Return True
        Catch
            Return False
        End Try
    End Function

    Public Shared Function CalculateCRC(bytes As List(Of Byte)) As Byte
        Dim checkSum As Byte = 0
        For Each b In bytes
            checkSum = checkSum Xor b '// Apply XOR
        Next
        Return checkSum
    End Function
End Class
