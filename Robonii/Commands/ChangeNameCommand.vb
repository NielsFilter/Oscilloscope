Public Class ChangeNameCommand
    Inherits BaseCommand


    Public Overrides ReadOnly Property PacketType As PacketTypes
        Get
            Return PacketTypes.None
        End Get
    End Property
End Class
