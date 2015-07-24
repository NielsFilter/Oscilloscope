Public Class ConnectedDevice

#Region " Constructors "

    Public Sub New()

    End Sub

    Public Sub New(channelNo As Integer, cOMPort As String, name As String)
        Me.ChannelNo = channelNo
        Me.COMPort = cOMPort
        Me.Name = name
    End Sub

#End Region

    Public Property ChannelNo As Integer
    Public Property COMPort As String
    Public Property Name As String

    Public ReadOnly Property Display As String
        Get
            Return Name & " (" & COMPort & ")"
        End Get
    End Property

End Class
