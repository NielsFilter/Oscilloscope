Public Enum PacketTypes
    <HexCode(0)>
    None '0x00

    <HexCode(&H53)>
    Oscilloscope '0x53 = S in ASCII

    <HexCode(&H46)>
    FFT '0x46 = F in ASCII
End Enum

Public Enum GainTypes
    <GainValue(1)>
    x1
    <GainValue(2)>
    x2
    <GainValue(4)>
    x4
    <GainValue(8)>
    x8
    <GainValue(16)>
    x16
End Enum

Public Enum CommandType
    ChangeName = 3          '0x03
    FFTData = 70            '0x46 
    OscilloscopeData = 83   '0x53
    Calibrate = 84          '0x54
    ChangeParameters = 85   '0x55
    ChangeFunction = 241    '0xF1
End Enum