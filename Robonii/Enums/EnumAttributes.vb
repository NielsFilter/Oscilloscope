<AttributeUsage(AttributeTargets.Enum Or AttributeTargets.Field)> _
Public Class HexCodeAttribute
    Inherits Attribute
    Public Sub New(hex As Integer)
        Me.HexCode = hex
    End Sub

    Public Property HexCode As Integer

#Region "Public Static Methods"

    Public Shared Function GetAttribute(type As PacketTypes) As HexCodeAttribute
        Dim mi = type.[GetType]().GetMember(type.ToString())
        If mi IsNot Nothing AndAlso mi.Length > 0 Then
            Dim attr = Attribute.GetCustomAttribute(mi(0), GetType(HexCodeAttribute))
            If attr IsNot Nothing Then
                Return DirectCast(attr, HexCodeAttribute)
            End If
        End If
        Return Nothing
    End Function

    Public Shared Function GetHexCode(code As PacketTypes) As Integer
        Dim attr = GetAttribute(code)

        If attr Is Nothing Then
            Throw New ArgumentNullException(String.Format("Could not find an attribute for FunctionCode '{0}'", code))
        End If

        Return attr.HexCode
    End Function

#End Region
End Class