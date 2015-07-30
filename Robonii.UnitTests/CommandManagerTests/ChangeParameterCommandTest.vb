<TestClass()>
 Public Class ChangeParameterCommandTest

    ''' <summary>
    ''' Create a ChangeName command, Translate it to bytes and verify bytes are correct 
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub BuildCommand_ChangeParameter()
        '// Arrange
        Dim cmd As New ChangeParameterCommand()
        cmd.DeviceName = "TIAN6"
        cmd.PacketType = PacketTypes.Oscilloscope
        cmd.TimeDivision = 5
        cmd.VTrigger = 10
        cmd.Gain = 4

        '// Act
        Dim byteArr = CommandManager.TranslateToBytes(cmd)

        '// Assert
        Dim expectedByteArr As Byte() =
        {
            &HF5,
            &H5,
            &H53,
            &H54,
            &H49,
            &H41,
            &H4E,
            &H36,
            &H5,
            &HA,
            &H4,
            &H1,
            &H1,
            &H55,
            &H0,
            &H5,
            &H0,
            &H0,
            &HDC,
            &H0,
            &H55,
            &H0,
            &H0,
            &H0,
            &H55
        }
        Assert.AreEqual(True, expectedByteArr.SequenceEqual(byteArr))
    End Sub

End Class
