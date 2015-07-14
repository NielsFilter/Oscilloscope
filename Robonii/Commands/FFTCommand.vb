Public Class FFTCommand
    Inherits BaseCommand

    Public Overrides ReadOnly Property PacketType As PacketTypes
        Get
            Return PacketTypes.FFT
        End Get
    End Property

    Public ReadOnly Property FFTData As List(Of Double)
        Get
            Dim lstData = New List(Of Double)()
            If Me.Data Is Nothing Then
                Return lstData
            End If

            For Each rawData As Byte In MyBase.Data
                Dim signedByte As SByte = rawData
                lstData.Add(CType(signedByte, Double))
            Next

            Return lstData
        End Get
    End Property

End Class
