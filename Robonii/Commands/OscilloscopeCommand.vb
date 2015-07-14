Public Class OscilloscopeCommand
    Inherits BaseCommand

    Public Overrides ReadOnly Property PacketType As PacketTypes
        Get
            Return PacketTypes.Oscilloscope
        End Get
    End Property

    Public ReadOnly Property OscilloscopeData As List(Of Double)
        Get
            Dim lstData = New List(Of Double)()
            If Me.Data Is Nothing Then
                Return lstData
            End If

            For Each rawData As Byte In MyBase.Data
                Dim signedByte As SByte = IIf(rawData < 128, rawData, rawData - 256)
                lstData.Add(signedByte)
            Next

            Return lstData
        End Get
    End Property

End Class
