Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmOscilloscope

    Dim isLoading As Boolean = True
    Dim suppressChangeEvent As Boolean = False

    Private oldZeroLine1 As Double = 0
    Private oldZeroLine2 As Double = 0
    Private oldZeroLine3 As Double = 0

    Private oldCOMPort1 As String = "COM0"
    Private oldCOMPort2 As String = "COM0"
    Private oldCOMPort3 As String = "COM0"

    Private WithEvents device1 As SerialConnection
    Private WithEvents device2 As SerialConnection
    Private WithEvents device3 As SerialConnection

    Private Sub frmOscilloscope_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.gbChannel1.ForeColor = Me.ChannelColour(1)
        Me.gbChannel2.ForeColor = Me.ChannelColour(2)
        Me.gbChannel3.ForeColor = Me.ChannelColour(3)

        Me.PopulateCOMPorts()

        Me.isLoading = False
    End Sub

    Private Sub PopulateCOMPorts()

        Dim comPortList As New List(Of String)()
        For index = 0 To 100
            comPortList.Add("COM" & index)
        Next

        cmbCOM1.DataSource = comPortList.ToList()
        cmbCOM2.DataSource = comPortList.ToList()
        cmbCOM3.DataSource = comPortList.ToList()
    End Sub

    Public Sub PlotData(data As ChartData)

        Dim plotWork As New Action(Sub()
                                       '// Add series to plot values.
                                       Dim seriesName = data.COMPort & " - " & data.Name
                                       Dim dataSeries As Series
                                       If chtOscilloscope.Series.IndexOf(seriesName) = -1 Then
                                           chtOscilloscope.Series.Add(seriesName)
                                           chtOscilloscope.Series(seriesName).ChartType = DataVisualization.Charting.SeriesChartType.Line
                                           chtOscilloscope.Series(seriesName).Tag = data.COMPort
                                       End If
                                       dataSeries = chtOscilloscope.Series(seriesName)

                                       '// Get the last X Value for the current series.
                                       Dim lastXCoordinate = 0
                                       If dataSeries.Points.Count > 0 Then
                                           lastXCoordinate = dataSeries.Points.FindMaxByValue().XValue
                                       End If

                                       '// Plot each point
                                       For Each item In data.Items
                                           '// Y coordinate = voltage plus current Zero Line offset
                                           Dim yCoordinate = item + GetZeroLineOffset(data.Channel)

                                           dataSeries.Points.AddXY(lastXCoordinate, yCoordinate)
                                           lastXCoordinate += 1
                                       Next

                                       '// Done plotting values, let's add a Zero Line (baseline) for this channel.
                                       '// Check if chart already has a zero line for this channel.
                                       Dim zeroLine = chtOscilloscope.ChartAreas(0).AxisY.StripLines.FirstOrDefault(Function(sl) sl.Tag = data.Channel)
                                       If zeroLine Is Nothing Then
                                           '// No Zero Line found, let's create one.
                                           zeroLine = New StripLine()
                                           zeroLine.Tag = data.Channel
                                           zeroLine.Interval = 0
                                           zeroLine.IntervalOffset = GetZeroLineOffset(data.Channel)
                                           zeroLine.StripWidth = 1
                                           zeroLine.BackColor = ChannelColour(data.Channel)

                                           chtOscilloscope.ChartAreas(0).AxisY.StripLines.Add(zeroLine)
                                       End If
                                   End Sub)

        If Me.InvokeRequired Then
            Me.Invoke(plotWork)
        Else
            plotWork()
        End If

    End Sub

    Public Function GetZeroLineOffset(channel As Integer)
        If channel = 1 Then
            Return oldZeroLine1
        ElseIf channel = 2 Then
            Return oldZeroLine2
        ElseIf channel = 3 Then
            Return oldZeroLine3
        End If
    End Function

    Private Function ChannelColour(channelNumber As Integer) As Color
        If channelNumber = 1 Then
            Return Color.Red
        ElseIf channelNumber = 2 Then
            Return Color.Green
        ElseIf channelNumber = 3 Then
            Return Color.Orange
        End If

        Return Color.Blue
    End Function

#Region " COM Port Changed "

    Private Sub COM1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCOM1.SelectedIndexChanged
        If Me.isLoading Then
            Exit Sub
        End If

        If Me.suppressChangeEvent Then
            Me.suppressChangeEvent = False
            Exit Sub
        End If

        '// Make sure that we don't have multiple channels using the same COM Port
        If cmbCOM1.SelectedIndex > 0 AndAlso
                (cmbCOM1.SelectedValue.ToString() = cmbCOM2.SelectedValue.ToString() OrElse
                 cmbCOM1.SelectedValue.ToString() = cmbCOM3.SelectedValue.ToString()) Then
            MessageBox.Show("There is already a channel using the port " & cmbCOM1.SelectedValue.ToString(), "COM Port already in use.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.suppressChangeEvent = True
            cmbCOM1.SelectedIndex = cmbCOM1.Items.IndexOf(oldCOMPort1)
            Exit Sub
        End If

        '// Primary channel has a few extra columns to clear out.
        Me.nudTrigger1.Value = 0

        If device1 IsNot Nothing Then
            device1.Dispose()
        End If


        '// Reset the channel
        Me.ResetChannel(1, oldCOMPort1, nudZeroLine1, cmbCOM1)

        If cmbCOM1.SelectedIndex > 0 Then
            Me.connectDevice(device1, 1, cmbCOM1.SelectedValue)
        End If
    End Sub
    Private Sub COM2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCOM2.SelectedIndexChanged
        If Me.isLoading Then
            Exit Sub
        End If

        If Me.suppressChangeEvent Then
            Me.suppressChangeEvent = False
            Exit Sub
        End If

        '// Make sure that we don't have multiple channels using the same COM Port
        If cmbCOM2.SelectedIndex > 0 AndAlso
                (cmbCOM2.SelectedValue.ToString() = cmbCOM1.SelectedValue.ToString() OrElse
                 cmbCOM2.SelectedValue.ToString() = cmbCOM3.SelectedValue.ToString()) Then
            MessageBox.Show("There is already a channel using the port " & cmbCOM2.SelectedValue.ToString(), "COM Port already in use.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.suppressChangeEvent = True
            cmbCOM2.SelectedIndex = cmbCOM2.Items.IndexOf(oldCOMPort2)
            Exit Sub
        End If

        '// Reset the channel
        Me.ResetChannel(2, oldCOMPort2, nudZeroLine2, cmbCOM2)

        If cmbCOM2.SelectedIndex > 0 Then
            Me.connectDevice(device2, 2, cmbCOM2.SelectedValue)
        End If
    End Sub
    Private Sub COM3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCOM3.SelectedIndexChanged
        If Me.isLoading Then
            Exit Sub
        End If

        If Me.suppressChangeEvent Then
            Me.suppressChangeEvent = False
            Exit Sub
        End If

        '// Make sure that we don't have multiple channels using the same COM Port
        If cmbCOM3.SelectedIndex > 0 AndAlso
                (cmbCOM3.SelectedValue.ToString() = cmbCOM1.SelectedValue.ToString() OrElse
                 cmbCOM3.SelectedValue.ToString() = cmbCOM2.SelectedValue.ToString()) Then
            MessageBox.Show("There is already a channel using the port " & cmbCOM3.SelectedValue.ToString(), "COM Port already in use.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.suppressChangeEvent = True
            cmbCOM3.SelectedIndex = cmbCOM3.Items.IndexOf(oldCOMPort3)
            Exit Sub
        End If

        '// Reset the channel
        Me.ResetChannel(3, oldCOMPort3, nudZeroLine3, cmbCOM3)

        If cmbCOM3.SelectedIndex > 0 Then
            Me.connectDevice(device3, 3, cmbCOM3.SelectedValue)
        End If
    End Sub

    Private Sub ResetChannel(channel As Integer, ByRef oldCOMPort As String, zeroLineValue As NumericUpDown, cmbCOM As ComboBox)
        '// Reset COM configuration
        zeroLineValue.Value = 0

        '// Remove Series for the COM Port (clear the plotted graph values for that COM Port)
        Dim comPort = oldCOMPort
        Dim seriesList = chtOscilloscope.Series.Where(Function(s) s.Tag = comPort)
        If seriesList.Count > 0 Then
            For Each series In seriesList.ToList()
                chtOscilloscope.Series.Remove(series)
            Next
        End If

        '// Remove Zero Line
        Dim zeroLine = Me.chtOscilloscope.ChartAreas(0).AxisY.StripLines.FirstOrDefault(Function(sl) sl.Tag = channel)
        If zeroLine IsNot Nothing Then
            Me.chtOscilloscope.ChartAreas(0).AxisY.StripLines.Remove(zeroLine)
        End If

        chtOscilloscope.Refresh()

        '// Update the old COM Port to the current one
        oldCOMPort = cmbCOM.SelectedValue.ToString()
    End Sub

#End Region

#Region " Zero Line Shifting "
    Private Sub ZeroLine1_ValueChanged(sender As Object, e As EventArgs) Handles nudZeroLine1.ValueChanged
        If Me.isLoading Then
            Exit Sub
        End If

        Me.ShiftZeroLine(1, cmbCOM1, nudZeroLine1, oldZeroLine1)
    End Sub
    Private Sub ZeroLine2_ValueChanged(sender As Object, e As EventArgs) Handles nudZeroLine2.ValueChanged
        If Me.isLoading Then
            Exit Sub
        End If

        Me.ShiftZeroLine(2, cmbCOM2, nudZeroLine2, oldZeroLine2)
    End Sub
    Private Sub ZeroLine3_ValueChanged(sender As Object, e As EventArgs) Handles nudZeroLine3.ValueChanged
        If Me.isLoading Then
            Exit Sub
        End If

        Me.ShiftZeroLine(3, cmbCOM3, nudZeroLine3, oldZeroLine3)
    End Sub

    Private Sub ShiftZeroLine(channel As Integer, cmbCOM As ComboBox, nudZeroLine As NumericUpDown, ByRef oldZeroLine As String)
        If cmbCOM.SelectedIndex = 0 Then
            Exit Sub
        End If

        Dim shiftAmount = nudZeroLine.Value - oldZeroLine
        If shiftAmount = 0 Then
            Exit Sub '// No change to the chart.
        End If

        For Each series In Me.chtOscilloscope.Series
            If series.Tag = cmbCOM.SelectedValue.ToString() Then
                '// We've found our series belonging to this channel. Let's shift our data points.
                For Each dataPoint In series.Points
                    dataPoint.YValues(0) += shiftAmount
                Next

                chtOscilloscope.Refresh()
            End If
        Next

        '// Time to shift the Zero Line as well
        chtOscilloscope.ChartAreas(0).AxisY.StripLines.FirstOrDefault()
        Dim zeroLine = Me.chtOscilloscope.ChartAreas(0).AxisY.StripLines.FirstOrDefault(Function(sl) sl.Tag = channel)
        If zeroLine IsNot Nothing Then
            zeroLine.IntervalOffset += shiftAmount
        End If

        oldZeroLine = nudZeroLine.Value
    End Sub
#End Region

#Region " Connecting Serial Device and Receiving Data "

    Private Sub connectDevice(ByRef device As SerialConnection, channelNo As Integer, portName As String)
        device = New SerialConnection(channelNo, portName)
        device.ReceiveAsync()
    End Sub

    Private Sub disconnectDevice()
        If device1 IsNot Nothing Then
            device1.Dispose()
        End If
    End Sub

    Private Sub SomeBytesReceived(sender As SerialConnection, cmd As BaseCommand) Handles device1.CommandReceived, device2.CommandReceived, device3.CommandReceived

        If Not TypeOf cmd Is OscilloscopeCommand Then
            Exit Sub '// Wrong command, we only care for Oscilloscope commands
        End If

        Dim oscilloscopeCmd As OscilloscopeCommand = cmd

        Dim data As New ChartData()
        data.Channel = sender.ChannelNo
        data.COMPort = sender.PortName
        data.Name = oscilloscopeCmd.DeviceName
        data.TimeDivision = oscilloscopeCmd.TimeDivision '// Not used anywhere yet.

        data.Items = oscilloscopeCmd.OscilloscopeData

        PlotData(data)
    End Sub

#End Region

    Private Sub btnClearGraph_Click(sender As Object, e As EventArgs) Handles btnClearGraph.Click
        cmbCOM1.SelectedIndex = 0
        cmbCOM2.SelectedIndex = 0
        cmbCOM3.SelectedIndex = 0
    End Sub

    'TODO: REMOVE DUMMY DATA
    '#Region "Dummy Data"
    '    Private Sub startData1(channel As Object)

    '        System.Threading.Thread.Sleep(New Random().Next(0, 1500))

    '        Dim cmb As ComboBox = Me.Controls.Find("cmbCOM" & channel, True).First()

    '        Dim data1 As New ChartData()
    '        data1.Channel = channel
    '        Me.Invoke(New Action(Sub() data1.COMPort = cmb.SelectedValue.ToString()))
    '        data1.Name = "TIAN" & New Random().Next(1, 100)
    '        data1.Items = New List(Of Double)()

    '        Dim x As Double = New Random().Next(80, 120)
    '        For i As Double = 0 To x
    '            data1.Items.Add(i)
    '        Next
    '        For i As Double = x To 30 Step -1
    '            data1.Items.Add(i)
    '        Next

    '        x = New Random().Next(60, 80)
    '        For i As Double = 30 To x Step 1.5
    '            data1.Items.Add(i)
    '        Next
    '        For i As Double = x To 20 Step -0.8
    '            data1.Items.Add(i)
    '        Next

    '        x = New Random().Next(90, 150)
    '        For i As Double = 21 To 120 Step 1
    '            data1.Items.Add(i)
    '        Next

    '        PlotData(data1)
    '    End Sub

    '    Private Sub startData2(channel As Object)
    '        System.Threading.Thread.Sleep(New Random().Next(1000, 4000))
    '        Threading.Thread.Sleep(4000)

    '        Dim cmb As ComboBox = Me.Controls.Find("cmbCOM" & channel, True).First()

    '        Dim data2 As New ChartData()
    '        data2.Channel = channel
    '        Me.Invoke(New Action(Sub() data2.COMPort = cmb.SelectedValue.ToString()))
    '        data2.Name = "TIAN" & New Random().Next(1, 100)
    '        data2.Items = New List(Of Double)()

    '        Dim x As Double = New Random().Next(50, 75)
    '        For i As Double = 40 To x Step 1.5
    '            data2.Items.Add(i)
    '        Next
    '        For i As Double = x To 35 Step -1.1
    '            data2.Items.Add(i)
    '        Next
    '        x = New Random().Next(38, 55)
    '        For i As Double = 35 To x Step 2
    '            data2.Items.Add(i)
    '        Next
    '        For i As Double = x To 65 Step 0.5
    '            data2.Items.Add(i)
    '        Next

    '        x = New Random().Next(10, 45)
    '        For i As Double = 65 To x Step -1
    '            data2.Items.Add(i)
    '        Next

    '        PlotData(data2)
    '    End Sub

    '    Private Sub plotDummyData(channel As Integer)
    '        Dim t1 As New Threading.Thread(New Threading.ParameterizedThreadStart(AddressOf startData1))
    '        Dim t2 As New Threading.Thread(New Threading.ParameterizedThreadStart(AddressOf startData2))

    '        t1.Start(channel)
    '        t2.Start(channel)
    '    End Sub
    '#End Region

End Class