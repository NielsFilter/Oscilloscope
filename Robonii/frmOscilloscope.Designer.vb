<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOscilloscope
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim CustomLabel1 As System.Windows.Forms.DataVisualization.Charting.CustomLabel = New System.Windows.Forms.DataVisualization.Charting.CustomLabel()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.pnlConfig = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.nudYMax = New System.Windows.Forms.NumericUpDown()
        Me.nudYMin = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAxisXLabel = New System.Windows.Forms.TextBox()
        Me.lblLockedText = New System.Windows.Forms.Label()
        Me.btnLock = New System.Windows.Forms.Button()
        Me.gbConfiguration = New System.Windows.Forms.GroupBox()
        Me.gbChangeParams = New System.Windows.Forms.GroupBox()
        Me.nudTimeDivision = New System.Windows.Forms.NumericUpDown()
        Me.lblTrigger1 = New System.Windows.Forms.Label()
        Me.btnUpdateParameters = New System.Windows.Forms.Button()
        Me.nudVTrigger = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbGain = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnUpdateName = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTriggerChannel = New System.Windows.Forms.ComboBox()
        Me.btnClearGraph = New System.Windows.Forms.Button()
        Me.gbChannel3 = New System.Windows.Forms.GroupBox()
        Me.nudZeroLine3 = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbCOM3 = New System.Windows.Forms.ComboBox()
        Me.gbChannel2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nudZeroLine2 = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbCOM2 = New System.Windows.Forms.ComboBox()
        Me.gbChannel1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbCOM1 = New System.Windows.Forms.ComboBox()
        Me.nudZeroLine1 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chtOscilloscope = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.pnlConfig.SuspendLayout()
        CType(Me.nudYMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudYMin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbConfiguration.SuspendLayout()
        Me.gbChangeParams.SuspendLayout()
        CType(Me.nudTimeDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudVTrigger, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbChannel3.SuspendLayout()
        CType(Me.nudZeroLine3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbChannel2.SuspendLayout()
        CType(Me.nudZeroLine2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbChannel1.SuspendLayout()
        CType(Me.nudZeroLine1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chtOscilloscope, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlConfig
        '
        Me.pnlConfig.Controls.Add(Me.Label13)
        Me.pnlConfig.Controls.Add(Me.Label11)
        Me.pnlConfig.Controls.Add(Me.nudYMax)
        Me.pnlConfig.Controls.Add(Me.nudYMin)
        Me.pnlConfig.Controls.Add(Me.Label8)
        Me.pnlConfig.Controls.Add(Me.txtAxisXLabel)
        Me.pnlConfig.Controls.Add(Me.lblLockedText)
        Me.pnlConfig.Controls.Add(Me.btnLock)
        Me.pnlConfig.Controls.Add(Me.gbConfiguration)
        Me.pnlConfig.Controls.Add(Me.btnClearGraph)
        Me.pnlConfig.Controls.Add(Me.gbChannel3)
        Me.pnlConfig.Controls.Add(Me.gbChannel2)
        Me.pnlConfig.Controls.Add(Me.gbChannel1)
        Me.pnlConfig.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlConfig.Location = New System.Drawing.Point(829, 0)
        Me.pnlConfig.Name = "pnlConfig"
        Me.pnlConfig.Size = New System.Drawing.Size(249, 729)
        Me.pnlConfig.TabIndex = 2
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 614)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Y Axis Max Value"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 588)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "Y Axis Min Value"
        '
        'nudYMax
        '
        Me.nudYMax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudYMax.DecimalPlaces = 2
        Me.nudYMax.Location = New System.Drawing.Point(129, 612)
        Me.nudYMax.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudYMax.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.nudYMax.Name = "nudYMax"
        Me.nudYMax.Size = New System.Drawing.Size(100, 20)
        Me.nudYMax.TabIndex = 23
        '
        'nudYMin
        '
        Me.nudYMin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudYMin.DecimalPlaces = 2
        Me.nudYMin.Location = New System.Drawing.Point(129, 586)
        Me.nudYMin.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudYMin.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.nudYMin.Name = "nudYMin"
        Me.nudYMin.Size = New System.Drawing.Size(100, 20)
        Me.nudYMin.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(14, 641)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "X Axis Label"
        '
        'txtAxisXLabel
        '
        Me.txtAxisXLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAxisXLabel.Location = New System.Drawing.Point(129, 638)
        Me.txtAxisXLabel.Name = "txtAxisXLabel"
        Me.txtAxisXLabel.Size = New System.Drawing.Size(100, 20)
        Me.txtAxisXLabel.TabIndex = 20
        Me.txtAxisXLabel.Text = "Time"
        '
        'lblLockedText
        '
        Me.lblLockedText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLockedText.AutoSize = True
        Me.lblLockedText.ForeColor = System.Drawing.Color.Red
        Me.lblLockedText.Location = New System.Drawing.Point(0, 678)
        Me.lblLockedText.Name = "lblLockedText"
        Me.lblLockedText.Size = New System.Drawing.Size(245, 13)
        Me.lblLockedText.TabIndex = 19
        Me.lblLockedText.Text = "* Oscilloscope is locked, (incoming data is ignored)"
        Me.lblLockedText.Visible = False
        '
        'btnLock
        '
        Me.btnLock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLock.Location = New System.Drawing.Point(129, 694)
        Me.btnLock.Name = "btnLock"
        Me.btnLock.Size = New System.Drawing.Size(109, 23)
        Me.btnLock.TabIndex = 18
        Me.btnLock.Text = "Lock"
        Me.btnLock.UseVisualStyleBackColor = True
        '
        'gbConfiguration
        '
        Me.gbConfiguration.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbConfiguration.Controls.Add(Me.gbChangeParams)
        Me.gbConfiguration.Controls.Add(Me.GroupBox1)
        Me.gbConfiguration.Controls.Add(Me.Label1)
        Me.gbConfiguration.Controls.Add(Me.cmbTriggerChannel)
        Me.gbConfiguration.Location = New System.Drawing.Point(12, 290)
        Me.gbConfiguration.Name = "gbConfiguration"
        Me.gbConfiguration.Size = New System.Drawing.Size(227, 283)
        Me.gbConfiguration.TabIndex = 17
        Me.gbConfiguration.TabStop = False
        Me.gbConfiguration.Text = "Configuration"
        '
        'gbChangeParams
        '
        Me.gbChangeParams.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbChangeParams.Controls.Add(Me.nudTimeDivision)
        Me.gbChangeParams.Controls.Add(Me.lblTrigger1)
        Me.gbChangeParams.Controls.Add(Me.btnUpdateParameters)
        Me.gbChangeParams.Controls.Add(Me.nudVTrigger)
        Me.gbChangeParams.Controls.Add(Me.Label3)
        Me.gbChangeParams.Controls.Add(Me.Label2)
        Me.gbChangeParams.Controls.Add(Me.cmbGain)
        Me.gbChangeParams.Location = New System.Drawing.Point(6, 62)
        Me.gbChangeParams.Name = "gbChangeParams"
        Me.gbChangeParams.Size = New System.Drawing.Size(215, 131)
        Me.gbChangeParams.TabIndex = 18
        Me.gbChangeParams.TabStop = False
        Me.gbChangeParams.Text = "Update Parameters"
        '
        'nudTimeDivision
        '
        Me.nudTimeDivision.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudTimeDivision.Location = New System.Drawing.Point(77, 19)
        Me.nudTimeDivision.Name = "nudTimeDivision"
        Me.nudTimeDivision.Size = New System.Drawing.Size(132, 20)
        Me.nudTimeDivision.TabIndex = 12
        '
        'lblTrigger1
        '
        Me.lblTrigger1.AutoSize = True
        Me.lblTrigger1.Location = New System.Drawing.Point(5, 47)
        Me.lblTrigger1.Name = "lblTrigger1"
        Me.lblTrigger1.Size = New System.Drawing.Size(40, 13)
        Me.lblTrigger1.TabIndex = 6
        Me.lblTrigger1.Text = "Trigger"
        '
        'btnUpdateParameters
        '
        Me.btnUpdateParameters.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUpdateParameters.Location = New System.Drawing.Point(8, 98)
        Me.btnUpdateParameters.Name = "btnUpdateParameters"
        Me.btnUpdateParameters.Size = New System.Drawing.Size(201, 23)
        Me.btnUpdateParameters.TabIndex = 16
        Me.btnUpdateParameters.Text = "Update Parameters"
        Me.btnUpdateParameters.UseVisualStyleBackColor = True
        '
        'nudVTrigger
        '
        Me.nudVTrigger.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudVTrigger.Location = New System.Drawing.Point(77, 45)
        Me.nudVTrigger.Name = "nudVTrigger"
        Me.nudVTrigger.Size = New System.Drawing.Size(132, 20)
        Me.nudVTrigger.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Time Divsion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Gain"
        '
        'cmbGain
        '
        Me.cmbGain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbGain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGain.FormattingEnabled = True
        Me.cmbGain.Location = New System.Drawing.Point(77, 71)
        Me.cmbGain.Name = "cmbGain"
        Me.cmbGain.Size = New System.Drawing.Size(132, 21)
        Me.cmbGain.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtName)
        Me.GroupBox1.Controls.Add(Me.btnUpdateName)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 199)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(215, 78)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Update Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Trigger"
        '
        'txtName
        '
        Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtName.Location = New System.Drawing.Point(77, 19)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(132, 20)
        Me.txtName.TabIndex = 14
        '
        'btnUpdateName
        '
        Me.btnUpdateName.Location = New System.Drawing.Point(8, 45)
        Me.btnUpdateName.Name = "btnUpdateName"
        Me.btnUpdateName.Size = New System.Drawing.Size(201, 23)
        Me.btnUpdateName.TabIndex = 15
        Me.btnUpdateName.Text = "Update Name"
        Me.btnUpdateName.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Trigger Device"
        '
        'cmbTriggerChannel
        '
        Me.cmbTriggerChannel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTriggerChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTriggerChannel.FormattingEnabled = True
        Me.cmbTriggerChannel.Location = New System.Drawing.Point(83, 24)
        Me.cmbTriggerChannel.Name = "cmbTriggerChannel"
        Me.cmbTriggerChannel.Size = New System.Drawing.Size(138, 21)
        Me.cmbTriggerChannel.TabIndex = 0
        '
        'btnClearGraph
        '
        Me.btnClearGraph.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearGraph.Location = New System.Drawing.Point(12, 694)
        Me.btnClearGraph.Name = "btnClearGraph"
        Me.btnClearGraph.Size = New System.Drawing.Size(111, 23)
        Me.btnClearGraph.TabIndex = 16
        Me.btnClearGraph.Text = "Clear All"
        Me.btnClearGraph.UseVisualStyleBackColor = True
        '
        'gbChannel3
        '
        Me.gbChannel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbChannel3.Controls.Add(Me.nudZeroLine3)
        Me.gbChannel3.Controls.Add(Me.Label10)
        Me.gbChannel3.Controls.Add(Me.Label12)
        Me.gbChannel3.Controls.Add(Me.cmbCOM3)
        Me.gbChannel3.Location = New System.Drawing.Point(12, 195)
        Me.gbChannel3.Name = "gbChannel3"
        Me.gbChannel3.Size = New System.Drawing.Size(227, 89)
        Me.gbChannel3.TabIndex = 15
        Me.gbChannel3.TabStop = False
        Me.gbChannel3.Text = "Channel 3"
        '
        'nudZeroLine3
        '
        Me.nudZeroLine3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudZeroLine3.DecimalPlaces = 2
        Me.nudZeroLine3.Location = New System.Drawing.Point(83, 49)
        Me.nudZeroLine3.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudZeroLine3.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.nudZeroLine3.Name = "nudZeroLine3"
        Me.nudZeroLine3.Size = New System.Drawing.Size(120, 20)
        Me.nudZeroLine3.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "COM Port"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Zero Line"
        '
        'cmbCOM3
        '
        Me.cmbCOM3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCOM3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOM3.FormattingEnabled = True
        Me.cmbCOM3.Location = New System.Drawing.Point(83, 22)
        Me.cmbCOM3.Name = "cmbCOM3"
        Me.cmbCOM3.Size = New System.Drawing.Size(120, 21)
        Me.cmbCOM3.TabIndex = 2
        '
        'gbChannel2
        '
        Me.gbChannel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbChannel2.Controls.Add(Me.Label7)
        Me.gbChannel2.Controls.Add(Me.nudZeroLine2)
        Me.gbChannel2.Controls.Add(Me.Label9)
        Me.gbChannel2.Controls.Add(Me.cmbCOM2)
        Me.gbChannel2.Location = New System.Drawing.Point(12, 101)
        Me.gbChannel2.Name = "gbChannel2"
        Me.gbChannel2.Size = New System.Drawing.Size(227, 88)
        Me.gbChannel2.TabIndex = 14
        Me.gbChannel2.TabStop = False
        Me.gbChannel2.Text = "Channel 2"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "COM Port"
        '
        'nudZeroLine2
        '
        Me.nudZeroLine2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudZeroLine2.DecimalPlaces = 2
        Me.nudZeroLine2.Location = New System.Drawing.Point(83, 49)
        Me.nudZeroLine2.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudZeroLine2.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.nudZeroLine2.Name = "nudZeroLine2"
        Me.nudZeroLine2.Size = New System.Drawing.Size(120, 20)
        Me.nudZeroLine2.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Zero Line"
        '
        'cmbCOM2
        '
        Me.cmbCOM2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCOM2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOM2.FormattingEnabled = True
        Me.cmbCOM2.Location = New System.Drawing.Point(83, 22)
        Me.cmbCOM2.Name = "cmbCOM2"
        Me.cmbCOM2.Size = New System.Drawing.Size(120, 21)
        Me.cmbCOM2.TabIndex = 1
        '
        'gbChannel1
        '
        Me.gbChannel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbChannel1.Controls.Add(Me.Label6)
        Me.gbChannel1.Controls.Add(Me.cmbCOM1)
        Me.gbChannel1.Controls.Add(Me.nudZeroLine1)
        Me.gbChannel1.Controls.Add(Me.Label4)
        Me.gbChannel1.Location = New System.Drawing.Point(12, 12)
        Me.gbChannel1.Name = "gbChannel1"
        Me.gbChannel1.Size = New System.Drawing.Size(227, 83)
        Me.gbChannel1.TabIndex = 12
        Me.gbChannel1.TabStop = False
        Me.gbChannel1.Text = "Primary Channel"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "COM Port"
        '
        'cmbCOM1
        '
        Me.cmbCOM1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCOM1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOM1.FormattingEnabled = True
        Me.cmbCOM1.Location = New System.Drawing.Point(83, 22)
        Me.cmbCOM1.Name = "cmbCOM1"
        Me.cmbCOM1.Size = New System.Drawing.Size(120, 21)
        Me.cmbCOM1.TabIndex = 0
        '
        'nudZeroLine1
        '
        Me.nudZeroLine1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudZeroLine1.DecimalPlaces = 2
        Me.nudZeroLine1.Location = New System.Drawing.Point(83, 49)
        Me.nudZeroLine1.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudZeroLine1.Minimum = New Decimal(New Integer() {1000, 0, 0, -2147483648})
        Me.nudZeroLine1.Name = "nudZeroLine1"
        Me.nudZeroLine1.Size = New System.Drawing.Size(120, 20)
        Me.nudZeroLine1.TabIndex = 9
        Me.nudZeroLine1.Tag = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Zero Line"
        '
        'chtOscilloscope
        '
        ChartArea1.AxisX.CustomLabels.Add(CustomLabel1)
        ChartArea1.AxisX.IsStartedFromZero = False
        ChartArea1.AxisY.IsStartedFromZero = False
        ChartArea1.Name = "ChartArea1"
        Me.chtOscilloscope.ChartAreas.Add(ChartArea1)
        Me.chtOscilloscope.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.chtOscilloscope.Legends.Add(Legend1)
        Me.chtOscilloscope.Location = New System.Drawing.Point(0, 0)
        Me.chtOscilloscope.Name = "chtOscilloscope"
        Me.chtOscilloscope.Size = New System.Drawing.Size(829, 729)
        Me.chtOscilloscope.TabIndex = 3
        Me.chtOscilloscope.Text = "Oscilloscope"
        '
        'frmOscilloscope
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 729)
        Me.Controls.Add(Me.chtOscilloscope)
        Me.Controls.Add(Me.pnlConfig)
        Me.Name = "frmOscilloscope"
        Me.Text = "Oscilloscope"
        Me.pnlConfig.ResumeLayout(False)
        Me.pnlConfig.PerformLayout()
        CType(Me.nudYMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudYMin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbConfiguration.ResumeLayout(False)
        Me.gbConfiguration.PerformLayout()
        Me.gbChangeParams.ResumeLayout(False)
        Me.gbChangeParams.PerformLayout()
        CType(Me.nudTimeDivision, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudVTrigger, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbChannel3.ResumeLayout(False)
        Me.gbChannel3.PerformLayout()
        CType(Me.nudZeroLine3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbChannel2.ResumeLayout(False)
        Me.gbChannel2.PerformLayout()
        CType(Me.nudZeroLine2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbChannel1.ResumeLayout(False)
        Me.gbChannel1.PerformLayout()
        CType(Me.nudZeroLine1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chtOscilloscope, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlConfig As System.Windows.Forms.Panel
    Friend WithEvents chtOscilloscope As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents cmbCOM3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCOM2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCOM1 As System.Windows.Forms.ComboBox
    Friend WithEvents nudVTrigger As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTrigger1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nudZeroLine1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents gbChannel1 As System.Windows.Forms.GroupBox
    Friend WithEvents nudZeroLine2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudZeroLine3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents gbChannel3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents gbChannel2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnClearGraph As System.Windows.Forms.Button
    Friend WithEvents btnLock As System.Windows.Forms.Button
    Friend WithEvents gbConfiguration As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTriggerChannel As System.Windows.Forms.ComboBox
    Friend WithEvents cmbGain As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdateName As System.Windows.Forms.Button
    Friend WithEvents btnUpdateParameters As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudTimeDivision As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbChangeParams As System.Windows.Forms.GroupBox
    Friend WithEvents lblLockedText As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAxisXLabel As System.Windows.Forms.TextBox
    Friend WithEvents nudYMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudYMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
