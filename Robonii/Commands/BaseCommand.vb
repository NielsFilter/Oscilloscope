Public MustInherit Class BaseCommand

    Public Const DEVICENAME_LENGTH As Integer = 5
    Public Const DATASTREAMBYTE_LENGTH As Integer = 2

    '0 - 1: StartBytes
    Public Shared StartByte1 As Byte = &HF5 '0xF5
    Public Shared StartByte2 As Byte = &H5  '0x05


#Region " Events "
    Public Delegate Sub CommandBuiltHandler(command As BaseCommand)

    Public Event CommandBuiltSuccessfully As CommandBuiltHandler
#End Region

#Region " Protocol Properties "

    '2: Packet Type
    Public Overridable Property PacketType As PacketTypes

    '3 - 7: Device Name
    Private _deviceName As String = New String(" ", DEVICENAME_LENGTH)
    Public Property DeviceName As String
        Get
            Return Me._deviceName
        End Get
        Set(value As String)
            If value.Length <> DEVICENAME_LENGTH Then
                Throw New ArgumentException(String.Format("DeviceName must be {0} characters", DEVICENAME_LENGTH))
            End If
            Me._deviceName = value
        End Set
    End Property

    '8: Time Division Parameter
    Private _timeDivision As Integer
    Public Property TimeDivision As Integer
        Get
            Return Me._timeDivision
        End Get
        Set(value As Integer)
            Me._timeDivision = value
        End Set
    End Property

    '9: VTrigger
    Private _vTrigger As Integer
    Public Property VTrigger As Integer
        Get
            Return Me._vTrigger
        End Get
        Set(value As Integer)
            Me._vTrigger = value
        End Set
    End Property

    '10: Gain
    Private _gain As GainTypes = GainTypes.x1
    Public Property Gain As GainTypes
        Get
            Return Me._gain
        End Get
        Set(value As GainTypes)
            Me._gain = value
        End Set
    End Property

    '11: Packet Number
    Private _packetNumber As Integer = 1
    Public Property PacketNumber As Integer
        Get
            Return Me._packetNumber
        End Get
        Set(value As Integer)
            Me._packetNumber = value
        End Set
    End Property

    '12: Total Packets
    Private _totalPackets As Integer = 1
    Public Property TotalPackets As Integer
        Get
            Return Me._totalPackets
        End Get
        Set(value As Integer)
            Me._totalPackets = value
        End Set
    End Property

    '13: Command
    Public MustOverride ReadOnly Property Command As CommandTypes

    '14 - 15: Data Stream Length
    Private _dataStreamLength As Integer
    Public Overridable Property DataStreamLength As Integer
        Get
            Return Me._dataStreamLength
        End Get
        Set(value As Integer)
            Dim maxValue = Math.Pow(256, DATASTREAMBYTE_LENGTH)
            If value > maxValue Then
                Throw New ArgumentException(String.Format("Data Stream Length must be less than {0}, which is {1} bytes", maxValue, DATASTREAMBYTE_LENGTH))
            End If

            Me._dataStreamLength = value
        End Set
    End Property

    '16 - 17: Data Stream Position
    Private _dataStreamPosition As Integer
    Public Property DataStreamPosition As Integer
        Get
            Return Me._dataStreamPosition
        End Get
        Set(value As Integer)
            Dim maxValue = Math.Pow(256, DATASTREAMBYTE_LENGTH)
            If value > maxValue Then
                Throw New ArgumentException(String.Format("Data Stream Position must be less than {0}, which is {1} bytes", maxValue, DATASTREAMBYTE_LENGTH))
            End If

            Me._dataStreamPosition = value
        End Set
    End Property

    '18: CRC Header
    Public ReadOnly Property CRCHeader As Byte
        Get
            Return CommandManager.CalculateCRC(Me.HeaderBytes)
        End Get
    End Property

    '19 - n: Data
    Private _data As List(Of Byte)
    Public Overridable Property Data As List(Of Byte)
        Get
            Return Me._data
        End Get
        Set(value As List(Of Byte))
            Me._data = value
        End Set
    End Property

    'n + 1: CRC Data
    Public ReadOnly Property CRCData As Byte
        Get
            Return CommandManager.CalculateCRC(Me.AllBytes)
        End Get
    End Property

#End Region

#Region " Checksum (CRC) "

    Public Property HeaderBytes As List(Of Byte)
    Public Property AllBytes As List(Of Byte)

    Public Sub AddHeaderBytes(ParamArray b As Byte())
        Me.HeaderBytes.AddRange(b)
        Me.AllBytes.AddRange(b)
    End Sub

    Public Sub AddBodyBytes(ParamArray b As Byte())
        Me.AllBytes.AddRange(b)
    End Sub

#End Region


    Public Sub DoneBuildingCommand()
        RaiseEvent CommandBuiltSuccessfully(Me)
    End Sub

End Class
