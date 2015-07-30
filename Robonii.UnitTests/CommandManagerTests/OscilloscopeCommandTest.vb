Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class OscilloscopeCommandTest

    ''' <summary>
    ''' Build up an OscilloscopeCommand from a single byte array.
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub BuildCommand_ValidBytes_SingleBuffer()
        '// Arrange
        Dim packetNumber As Integer = 1
        Dim offset As Integer = 0
        Dim cmd As BaseCommand = Nothing
        Dim buffer As Byte() =
            {
                &HF5,
                &H5,
                &H53,
                &H54,
                &H49,
                &H41,
                &H4E,
                &H36,
                &H1,
                &H0,
                &H2,
                &H1,
                &H1,
                &H53,
                &H0,
                &HA,
                &H0,
                &H0,
                &HDD,
                &HFD,
                &HFE,
                &HFF,
                &H0,
                &H1,
                &H2,
                &H3,
                &H4,
                &H3,
                &H2,
                &HF9
            }

        '// Act
        Dim isSuccessful = CommandManager.BuildCommand(buffer, cmd, packetNumber, offset)

        '// Assert
        Assert.AreEqual(True, isSuccessful)
        Assert.AreNotEqual(Nothing, cmd)
        Assert.IsInstanceOfType(cmd, GetType(OscilloscopeCommand))

        Dim oscCommand As OscilloscopeCommand = cmd
        Assert.AreEqual(PacketTypes.Oscilloscope, oscCommand.PacketType)
        Assert.AreEqual("TIAN6", oscCommand.DeviceName)
        Assert.AreEqual(1, oscCommand.TimeDivision)
        Assert.AreEqual(0, oscCommand.VTrigger)
        Assert.AreEqual(GainTypes.x2, oscCommand.Gain)
        Assert.AreEqual(1, oscCommand.PacketNumber)
        Assert.AreEqual(1, oscCommand.TotalPackets)
        Assert.AreEqual(CommandTypes.OscilloscopeData, oscCommand.Command)
        Assert.AreEqual(10, oscCommand.DataStreamLength)
        Assert.AreEqual(0, oscCommand.DataStreamPosition)
        Assert.AreEqual(&HDD, Convert.ToInt32(oscCommand.CRCHeader))

        Dim expectedData As New List(Of Double)() From {-3, -2, -1, 0, 1, 2, 3, 4, 3, 2}
        Assert.AreEqual(True, expectedData.SequenceEqual(oscCommand.OscilloscopeData))
        Assert.AreEqual(&HF9, Convert.ToInt32(oscCommand.CRCData))

    End Sub

    ''' <summary>
    ''' Build up an OscilloscopeCommand from multiple byte arrays.
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub BuildCommand_ValidBytes_MultipleBuffers()
        '// Arrange
        Dim packetNumber As Integer = 1
        Dim offset As Integer = 0
        Dim cmd As BaseCommand = Nothing
        Dim buffer As Byte() =
            {
                &HF5,
                &H5,
                &H53,
                &H54,
                &H49,
                &H41,
                &H4E,
                &H36,
                &H1,
                &H0,
                &H2,
                &H1,
                &H1,
                &H53,
                &H0,
                &HA,
                &H0,
                &H0,
                &HDD,
                &HFD,
                &HFE,
                &HFF,
                &H0,
                &H1,
                &H2,
                &H3,
                &H4,
                &H3,
                &H2,
                &HF9
            }

        '// Act
        Dim smallBuffer As Byte() '// Create a small byte array to simulate "multiple" buffers carrying parts of the command.
        For index = 0 To buffer.Length - 1
            '// We'll send the byte array through one byte at a time. This ensures that the "BuildCommand" works if message spreads accross buffers.
            smallBuffer = New Byte() {buffer.ElementAt(index)}
            Dim isSuccessful = CommandManager.BuildCommand(smallBuffer, cmd, packetNumber, offset)
            Assert.AreEqual(True, isSuccessful)
        Next

        '// Assert
        Assert.AreNotEqual(Nothing, cmd)
        Assert.IsInstanceOfType(cmd, GetType(OscilloscopeCommand))

        Dim oscCommand As OscilloscopeCommand = cmd
        Assert.AreEqual(PacketTypes.Oscilloscope, oscCommand.PacketType)
        Assert.AreEqual("TIAN6", oscCommand.DeviceName)
        Assert.AreEqual(1, oscCommand.TimeDivision)
        Assert.AreEqual(0, oscCommand.VTrigger)
        Assert.AreEqual(GainTypes.x2, oscCommand.Gain)
        Assert.AreEqual(1, oscCommand.PacketNumber)
        Assert.AreEqual(1, oscCommand.TotalPackets)
        Assert.AreEqual(CommandTypes.OscilloscopeData, oscCommand.Command)
        Assert.AreEqual(10, oscCommand.DataStreamLength)
        Assert.AreEqual(0, oscCommand.DataStreamPosition)
        Assert.AreEqual(&HDD, Convert.ToInt32(oscCommand.CRCHeader))

        Dim expectedData As New List(Of Double)() From {-3, -2, -1, 0, 1, 2, 3, 4, 3, 2}
        Assert.AreEqual(True, expectedData.SequenceEqual(oscCommand.OscilloscopeData))
        Assert.AreEqual(&HF9, Convert.ToInt32(oscCommand.CRCData))

    End Sub

End Class