Imports System.Windows.Forms.DataVisualization.Charting

Public Class frmOscilloscope

#Region " Variables "

    Dim isLoading As Boolean = True
    Dim suppressChangeEvent As Boolean = False

    '// Device variables...

    '// Device 1
    Private WithEvents device1 As SerialConnection
    Private oldCOMPort1 As String = "COM0"
    Private oldZeroLine1 As Double = 0

    '// Device 2
    Private WithEvents device2 As SerialConnection
    Private oldCOMPort2 As String = "COM0"
    Private oldZeroLine2 As Double = 0

    '// Device 3
    Private WithEvents device3 As SerialConnection
    Private oldZeroLine3 As Double = 0
    Private oldCOMPort3 As String = "COM0"

#End Region

#Region " Form Load "

    Private Sub frmOscilloscope_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '// Set the primary colours
        Me.gbChannel1.ForeColor = Me.ChannelColour(1)
        Me.gbChannel2.ForeColor = Me.ChannelColour(2)
        Me.gbChannel3.ForeColor = Me.ChannelColour(3)

        '// Populate the Combo Boxes
        Me.PopulateCOMPorts() '// COM Ports
        Me.PopulateGainTypes() '// Gain Types

        '// Setup Trigger channel Combo Box
        Me.cmbTriggerChannel.DisplayMember = "Display"
        Me.cmbTriggerChannel.ValueMember = "COMPort"

        '// This variable is used so that as we set the Port Combo Boxes for instance, we don't fire the "Changed" event during a load.
        '// Initially this is true, and now that we're done loading we set it to false. See the SelectedIndexChanged methods to understand where it's used.
        Me.isLoading = False
    End Sub

    ''' <summary>
    ''' Fill the Port combo boxes will all the possible COM Ports. COM Ports 0 - 99 are populated.
    ''' </summary>
    ''' <remarks>"COM0" means no device connected.</remarks>
    Private Sub PopulateCOMPorts()

        Dim comPortList As New List(Of String)()
        '// Loop through 0 - 99
        For index = 0 To 99
            '// Items built up like "COM0", "COM1", "COM2"... and stored in a list
            comPortList.Add("COM" & index)
        Next

        '// Populate all the Ports combo boxes with the built up list.
        cmbCOM1.DataSource = comPortList.ToList()
        cmbCOM2.DataSource = comPortList.ToList()
        cmbCOM3.DataSource = comPortList.ToList()
    End Sub

    Private Sub PopulateGainTypes()
        cmbGain.DataSource = [Enum].GetValues(GetType(GainTypes))
    End Sub

#End Region

#Region " Colours, Styles and all things Pretty "

    ''' <summary>
    ''' Just to make it more distinguishable, we represent each channel with a colour.
    ''' So immediately when we see the baseline colour for instance we know which channel it is for.
    ''' </summary>
    ''' <param name="channelNumber">Channel Number</param>
    ''' <returns>A colour for the channel number</returns>
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

#End Region

#Region " Charting "

    ''' <summary>
    ''' Makes sure that the we're able to update the UI (the chart) from any thread.
    ''' </summary>
    ''' <param name="data">data to be plotted.</param>
    Public Sub PlotDataFromDifferentThreads(data As ChartData)

        Dim plotWork As New Action(Sub() PlotData(data))

        If Me.InvokeRequired Then
            'We're on a different thread (not the main UI thread)
            Me.Invoke(plotWork)
        Else
            'We're on the main UI thread. We can simply call PlotData and carry on...
            PlotData(data)
        End If

    End Sub

    ''' <summary>
    ''' This is where the plotting magic happens. We receive a ChartData instance, which holds the info we need
    ''' (the name, plot data etc) and plot it to the graph / chart.
    ''' </summary>
    ''' <param name="data">data to be plotted.</param>
    Public Sub PlotData(data As ChartData)
        '// Add a series to plot values. A series is equivalent to a "line" in our oscilloscope.
        Dim seriesName = data.COMPort & " - " & data.Name
        Dim dataSeries As Series
        If chtOscilloscope.Series.IndexOf(seriesName) = -1 Then
            '// The series doesn't exist yet on the chart, so we'll create it.
            chtOscilloscope.Series.Add(seriesName)
            chtOscilloscope.Series(seriesName).ChartType = DataVisualization.Charting.SeriesChartType.Line '// Important to indicate that our series is a type of Line chart type..
            chtOscilloscope.Series(seriesName).Tag = data.COMPort '// We store the Port in the series Tag property. The Tag property is kind of like a placeholder for extra stuff, which we can pull out later.
        End If
        dataSeries = chtOscilloscope.Series(seriesName)

        '// Get the last X Value for the current series.
        Dim lastXCoordinate = 0
        If dataSeries.Points.Count > 0 Then
            lastXCoordinate = dataSeries.Points.Max(Function(p) p.XValue)
        End If

        '// Plot each point
        For Each item In data.Items
            '// Y coordinate = voltage plus current Zero Line offset
            Dim yCoordinate = item + getZeroLineOffset(data.Channel)

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
            zeroLine.IntervalOffset = getZeroLineOffset(data.Channel)
            zeroLine.StripWidth = 1
            zeroLine.BackColor = ChannelColour(data.Channel)

            chtOscilloscope.ChartAreas(0).AxisY.StripLines.Add(zeroLine)
        End If

        chtOscilloscope.Refresh()
    End Sub

    ''' <summary>
    ''' We keep a variable which stores the "offset" each channel's Zero Line. This method retrieves that offset.
    ''' </summary>
    ''' <param name="channel">Which channel's offset to retrieve</param>
    ''' <returns>The base line offset for the passed channel</returns>
    ''' <remarks>
    ''' The offset is simply the value of the Zero Line.
    ''' So if the Base Line was set to 10 previously, then the offset is 10. If - 5, then the offset is -5
    ''' </remarks>
    Private Function getZeroLineOffset(channel As Integer) As Double
        '// Pretty straight-forward logic here. Check the channel and return it's related variable.
        If channel = 1 Then
            Return oldZeroLine1
        ElseIf channel = 2 Then
            Return oldZeroLine2
        ElseIf channel = 3 Then
            Return oldZeroLine3
        End If

        '// This exception will only be throw in future development. If more channels are allowed one day, but the channel hasn't been added here, it will throw this exception as a reminder.
        Throw New NotImplementedException(String.Format("Channel {0} is not implemented.", channel))
    End Function

    ''' <summary>
    ''' Clear ALL graphs button click.
    ''' </summary>
    Private Sub btnClearGraph_Click(sender As Object, e As EventArgs) Handles btnClearGraph.Click
        '// All we need to clear a graph is to set the selected index to 0 ("COM0").
        '// The selectedIndexChanged event will fire and see that "No Port" was selected and handle the clearing.
        cmbCOM1.SelectedIndex = 0
        cmbCOM2.SelectedIndex = 0
        cmbCOM3.SelectedIndex = 0
    End Sub

#End Region

#Region " COM Port Changed - Connect and Disconnect Channel Logic "

    '// These SelectedIndexChanged events are where we connect to the device on a COM Port and enable us to receive data.
    '// These events also handle the "clearing" of a channel (if "COM0" is selected).

    Private Sub COM1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCOM1.SelectedIndexChanged
        If Me.isLoading Then
            Exit Sub '// Prevent this event firing whilst loading the form and filling the combo boxes.
        End If

        '// If an "invalid" selection was made and we need to change the selected index back to the previous value and don't want all the "Connect" logic to fire,
        '// this variable is set and we can simply exit the Sub before getting into the meat and potatoes of this method.
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

        '//*** These items are only for Primary channel ***//
        Me.txtName.Text = String.Empty
        Me.nudVTrigger.Value = 0
        '//*** These items are only for Primary channel ***//

        '// The is the heart of event. Here we reset the channel and if a valid COM Port is selected, a connection is established.
        Me.ResetAndConnectChannel(1, device1, oldCOMPort1, nudZeroLine1, cmbCOM1)
    End Sub
    Private Sub COM2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCOM2.SelectedIndexChanged
        If Me.isLoading Then
            Exit Sub '// Prevent this event firing whilst loading the form and filling the combo boxes.
        End If

        '// If an "invalid" selection was made and we need to change the selected index back to the previous value and don't want all the "Connect" logic to fire,
        '// this variable is set and we can simply exit the Sub before getting into the meat and potatoes of this method.
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

        '// The is the heart of event. Here we reset the channel and if a valid COM Port is selected, a connection is established.
        Me.ResetAndConnectChannel(2, device2, oldCOMPort2, nudZeroLine2, cmbCOM2)
    End Sub
    Private Sub COM3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCOM3.SelectedIndexChanged
        If Me.isLoading Then
            Exit Sub '// Prevent this event firing whilst loading the form and filling the combo boxes.
        End If

        '// If an "invalid" selection was made and we need to change the selected index back to the previous value and don't want all the "Connect" logic to fire,
        '// this variable is set and we can simply exit the Sub before getting into the meat and potatoes of this method.
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

        '// The is the heart of event. Here we reset the channel and if a valid COM Port is selected, a connection is established.
        Me.ResetAndConnectChannel(3, device3, oldCOMPort3, nudZeroLine3, cmbCOM3)
    End Sub

    ''' <summary>
    ''' Reset the channel and establish a connection to the selected "COM" port.
    ''' </summary>
    Private Sub ResetAndConnectChannel(channel As Integer, ByRef device As SerialConnection, ByRef oldCOMPort As String, zeroLineValue As NumericUpDown, cmbCOM As ComboBox)
        '// Disconnect device currently connected.
        disconnectDevice(device)

        '// Our Zero Line offset will be back to 0
        zeroLineValue.Value = 0

        '// Remove the "previously" connected device from the Connect List
        Me.removeDeviceFromConnectedList(oldCOMPort)

        '// Remove Series for the COM Port (clear the plotted graph values for that COM Port)
        Dim comPort = oldCOMPort
        Dim seriesList = chtOscilloscope.Series.Where(Function(s) s.Tag = comPort) '// We stored the Port for each series in the Tag property. Now we can retrieve all the Series' / Chart Lines related to the passed COM Port
        If seriesList.Count > 0 Then
            For Each series In seriesList.ToList()
                '// Remove each Chart Line for this port.
                chtOscilloscope.Series.Remove(series)
            Next
        End If

        '// Remove Chart Zero Line previously Plotted.
        Dim zeroLine = Me.chtOscilloscope.ChartAreas(0).AxisY.StripLines.FirstOrDefault(Function(sl) sl.Tag = channel)
        If zeroLine IsNot Nothing Then
            Me.chtOscilloscope.ChartAreas(0).AxisY.StripLines.Remove(zeroLine)
        End If

        '// Refresh the Graph, to make sure the UI reflects our changes.
        chtOscilloscope.Refresh()

        '// Store the current COM Port, which will be used later.
        oldCOMPort = cmbCOM.SelectedValue.ToString()

        '// All of the above was just resetting everything. Now if we've selected a valid COM Port (anything but "COM0") we establish a new connection.
        If cmbCOM.SelectedIndex > 0 Then
            Me.connectDevice(device, channel, cmbCOM.SelectedValue)
        End If
    End Sub

#End Region

#Region " Zero Line Shifting "

    Private Sub ZeroLine1_ValueChanged(sender As Object, e As EventArgs) Handles nudZeroLine1.ValueChanged
        If Me.isLoading Then
            Exit Sub '// Prevent this event firing whilst loading the form.
        End If

        Me.ShiftZeroLine(1, cmbCOM1, nudZeroLine1, oldZeroLine1)
    End Sub
    Private Sub ZeroLine2_ValueChanged(sender As Object, e As EventArgs) Handles nudZeroLine2.ValueChanged
        If Me.isLoading Then
            Exit Sub  '// Prevent this event firing whilst loading the form.
        End If

        Me.ShiftZeroLine(2, cmbCOM2, nudZeroLine2, oldZeroLine2)
    End Sub
    Private Sub ZeroLine3_ValueChanged(sender As Object, e As EventArgs) Handles nudZeroLine3.ValueChanged
        If Me.isLoading Then
            Exit Sub  '// Prevent this event firing whilst loading the form.
        End If

        Me.ShiftZeroLine(3, cmbCOM3, nudZeroLine3, oldZeroLine3)
    End Sub

    ''' <summary>
    ''' Handles shifting of the Zero Line / Base Line.
    ''' </summary>
    ''' <param name="channel">Channel number we're referring to</param>
    ''' <param name="cmbCOM">COM Port combo Box for the channel</param>
    ''' <param name="nudZeroLine">The Zero Line NumericUpDown control instance.</param>
    ''' <param name="oldZeroLine">A reference to the Previous zero line.</param>
    Private Sub ShiftZeroLine(channel As Integer, cmbCOM As ComboBox, nudZeroLine As NumericUpDown, ByRef oldZeroLine As String)
        If cmbCOM.SelectedIndex = 0 Then
            Exit Sub '// No need to go on, we're not connected ("COM0" is selected).
        End If

        '// Work out the shift amount. This is the new Zero line value - the old value (offset).
        '// Example if the Zero Line is on 10 and we change it to 8, the shift amount = 8 - 10 = -2. If it was 5 and we change it to 10, the shift amount = 10 - 5 = +5.
        '// A positive shift amount will move the line up and negative will move it down.
        Dim shiftAmount = nudZeroLine.Value - oldZeroLine
        If shiftAmount = 0 Then
            Exit Sub '// No change to the chart.
        End If

        '// Loop through each series in the graph and look for the ones with the specific COM Port.
        For Each series In Me.chtOscilloscope.Series
            If series.Tag = cmbCOM.SelectedValue.ToString() Then '// We use the Tag property on the series to store the COM Port related to it
                '// We've found our series belonging to this channel. Let's shift our data points.
                '// Loop through all data points and adjust them according to the shift amount.
                For Each dataPoint In series.Points
                    dataPoint.YValues(0) += shiftAmount
                Next

                '// Refresh the chart to make sure the UI reflects the changes.
                chtOscilloscope.Refresh()
            End If
        Next

        '// We've shifted the plotted values, now it's time to shift the Zero Line as well
        Dim zeroLine = Me.chtOscilloscope.ChartAreas(0).AxisY.StripLines.FirstOrDefault(Function(sl) sl.Tag = channel) '// The Zero Line (which is a chart SplitLine) store its related channel in the Tag property.
        If zeroLine IsNot Nothing Then
            '// We've found the zero line. Now we also shift it Up or Down.
            zeroLine.IntervalOffset += shiftAmount
        End If

        '// Update the oldZeroLine variable's value to the current Zero Line value (used to calculate shift amount on next change).
        oldZeroLine = nudZeroLine.Value
    End Sub

#End Region

#Region " Connecting Serial Device and Receiving Data "

    ''' <summary>
    ''' Connects to the Serial device and starts receiving data.
    ''' </summary>
    Private Sub connectDevice(ByRef device As SerialConnection, channelNo As Integer, portName As String)
        device = New SerialConnection(channelNo, portName)
        device.ReceiveAsync()
    End Sub

    ''' <summary>
    ''' Disconnect serial device
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub disconnectDevice(ByRef device As SerialConnection)
        If device1 IsNot Nothing Then
            device1.Dispose() '// This disconnect and close stuff will be in here.
            device1 = Nothing
        End If
    End Sub

    ''' <summary>
    ''' When any device sends Data, this method is called.
    ''' </summary>
    Private Sub SomeBytesReceived(sender As SerialConnection, cmd As BaseCommand) Handles device1.CommandReceived, device2.CommandReceived, device3.CommandReceived

        If Not TypeOf cmd Is OscilloscopeCommand Then
            Exit Sub '// Wrong command, we only care for Oscilloscope commands, since that is what we're plotting.
        End If

        '// Cast the received BaseCommand to a type of OscilloscopeCommand./
        Dim oscilloscopeCmd As OscilloscopeCommand = cmd

        '// Check if the current device is already connected
        Me.addConnectedDevice(New ConnectedDevice(sender.PortName, cmd.DeviceName))

        '// Build up a ChartData instance, which is used to plot the data.
        Dim data As New ChartData()
        data.Channel = sender.ChannelNo
        data.COMPort = sender.PortName
        data.Name = oscilloscopeCmd.DeviceName
        data.Items = oscilloscopeCmd.OscilloscopeData

        '// Plot the data (import to call the PlotDataFromDifferentThreads as this method will be called from separate threads)
        PlotDataFromDifferentThreads(data)
    End Sub

#End Region

#Region " Sending Data to Device "

    ''' <summary>
    ''' Update the Device's name. Build up a ChangeNameCommand and send it.
    ''' </summary>
    Private Sub btnUpdateName_Click(sender As Object, e As EventArgs)
        '// Make sure that we're not on "COM0"
        If cmbCOM1.SelectedIndex = 0 Then
            MessageBox.Show("Please select the Port to which the name change must be sent.", "No COM Port selected", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        '// Make sure that we're connected to a device.
        If Me.device1 Is Nothing OrElse Me.device1.IsConnected = False Then
            MessageBox.Show("There is no device connected on " & cmbCOM1.SelectedValue, "No device found on select port", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        '// Validate the new device name's length
        If txtName.Text.Trim().Length <> BaseCommand.DEVICENAME_LENGTH Then
            MessageBox.Show("Device name must be " & BaseCommand.DEVICENAME_LENGTH & " characters long", "Failed to update Device Name", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            '// Done with validation, let's build the command and send it.
            Dim cmd As New ChangeNameCommand()

            cmd.DeviceName = "TIAN6"
            cmd.DataStreamLength = 5
            cmd.Command = CommandTypes.ChangeName
            cmd.SetNewName(txtName.Text.Trim())

            '// Send command to the primary device.
            device1.Send(cmd)
        Catch ex As Exception
            '// Failed to change device's name.
            MessageBox.Show(String.Format("Could not update name to '{0}'.{1}{1}{2}", txtName.Text.Trim(), Environment.NewLine, ex.Message), "Device name change failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnUpdateParameters_Click(sender As Object, e As EventArgs) Handles btnUpdateParameters.Click

    End Sub

#End Region

    Private Sub addConnectedDevice(newDevice As ConnectedDevice)
        If Not Me.cmbTriggerChannel.Items.Cast(Of ConnectedDevice)().Any(Function(d)
                                                                             Return d.COMPort = newDevice.COMPort AndAlso d.Name = newDevice.Name
                                                                         End Function) Then

            '// Device is not yet in the connected list. Let's add it.
            If Me.cmbTriggerChannel.InvokeRequired Then
                Me.cmbTriggerChannel.Invoke(Sub()
                                                Me.cmbTriggerChannel.Items.Add(New ConnectedDevice(newDevice.COMPort, newDevice.Name))
                                            End Sub)
            End If
        End If
    End Sub

    Private Sub removeDeviceFromConnectedList(cOMPort As String)

        '// Remove all devices for a specific COM Port.
        For index = 0 To Me.cmbTriggerChannel.Items.Count - 1
            Dim device As ConnectedDevice = Me.cmbTriggerChannel.Items.Item(index)
            If device.COMPort = cOMPort Then
                Me.cmbTriggerChannel.Items.RemoveAt(index)
            End If
        Next

    End Sub

End Class

Public Class ConnectedDevice

#Region " Constructors "

    Public Sub New()

    End Sub

    Public Sub New(cOMPort As String, name As String)
        Me.COMPort = cOMPort
        Me.Name = name
    End Sub

#End Region

    Public Property COMPort As String
    Public Property Name As String

    Public ReadOnly Property Display As String
        Get
            Return Name & " (" & COMPort & ")"
        End Get
    End Property

End Class