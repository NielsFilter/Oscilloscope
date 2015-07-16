Imports System.Runtime.Remoting.Metadata.W3cXsd2001

Public Class Utils
    Public Shared Function HexToInt(hex As String) As Integer
        Return Convert.ToInt32(hex, 16)
    End Function

    Public Shared Function IntToHex(hexInt As Integer) As String
        Return hexInt.ToString("X4")
    End Function

    Public Function GetBytesFromHexString(strInput As String) As Byte()
        Dim bytArOutput As Byte() = New Byte() {}
        If Not String.IsNullOrEmpty(strInput) AndAlso strInput.Length Mod 2 = 0 Then
            Dim hexBinary As SoapHexBinary = Nothing
            Try
                hexBinary = SoapHexBinary.Parse(strInput)
                If hexBinary IsNot Nothing Then
                    bytArOutput = hexBinary.Value
                End If
            Catch ex As Exception
                ApplicationErrors.Handle(ex)
            End Try
        End If
        Return bytArOutput
    End Function

    Public Shared Function ToByte(int As Integer) As Byte
        Return Convert.ToByte(int, 16)
    End Function

    Public Shared Function ToBytes(int As Integer) As Byte()
        Return BitConverter.GetBytes(int)
    End Function

    Public Shared Function ByteToASCII(bytes As Byte()) As String
        Return System.Text.Encoding.ASCII.GetString(bytes)
    End Function

    Public Shared Function ASCIIToBytes(asciiValue As String) As Byte()
        Return System.Text.Encoding.ASCII.GetBytes(asciiValue)
    End Function

End Class
