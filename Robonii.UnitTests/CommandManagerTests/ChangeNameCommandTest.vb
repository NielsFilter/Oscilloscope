Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class ChangeNameCommandTest

    ''' <summary>
    ''' Create a ChangeName command, Translate it to bytes and verify bytes are correct 
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub BuildCommand_ChangeName()
        '// Arrange
        Dim cmd As New ChangeNameCommand()
        cmd.DeviceName = "TIAN6"
        cmd.PacketType = PacketTypes.Oscilloscope
        cmd.SetNewName("NIELS")

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
            &H0,
            &H0,
            &H1,
            &H1,
            &H1,
            &H3,
            &H0,
            &H5,
            &H0,
            &H0,
            &H80,
            &H4E,
            &H49,
            &H45,
            &H4C,
            &H53,
            &H5D
        }
        Assert.AreEqual(True, expectedByteArr.SequenceEqual(byteArr))
    End Sub

End Class