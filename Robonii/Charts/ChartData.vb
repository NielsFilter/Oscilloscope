''' <summary>
''' This class is used to hold all the data needed for plotting a graph.
''' </summary>
''' <remarks>
''' If in the future, different types of graphs need extra fields that other graph types do not, a good consideration would be
''' to create a ChartData class per chart which inherits this one. Then keep all the "core" properties shared by all charts in this class
''' and all the properties specific  </remarks>
Public Class ChartData
    Public Property Channel As Integer
    Public Property COMPort As String
    Public Property Name As String
    Public Property Items As List(Of Double)
End Class
