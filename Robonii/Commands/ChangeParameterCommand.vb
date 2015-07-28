﻿Public Class ChangeParameterCommand
    Inherits BaseCommand

    Public Overrides ReadOnly Property Command As CommandTypes
        Get
            Return CommandTypes.ChangeParameters
        End Get
    End Property

    Public Overrides Property Data As List(Of Byte)
        Get
            Dim dataBytes As Byte() = {&H0, &H55, &H0, &H0, &H0}
            Return dataBytes.ToList()
        End Get
        Set(value As List(Of Byte))
            '// Do Nothing. The change parameters command has a fixed data
        End Set
    End Property

End Class
