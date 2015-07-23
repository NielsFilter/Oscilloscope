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
        Dim ChartArea7 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend7 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.pnlConfig = New System.Windows.Forms.Panel()
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
        Me.nudVTrigger = New System.Windows.Forms.NumericUpDown()
        Me.lblTrigger1 = New System.Windows.Forms.Label()
        Me.nudZeroLine1 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chtOscilloscope = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.gbConfiguration = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbTriggerChannel = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbGain = New System.Windows.Forms.ComboBox()
        Me.nudTimeDivision = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnUpdateName = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnUpdateParameters = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbChangeParams = New System.Windows.Forms.GroupBox()
        Me.pnlConfig.SuspendLayout()
        Me.gbChannel3.SuspendLayout()
        CType(Me.nudZeroLine3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbChannel2.SuspendLayout()
        CType(Me.nudZeroLine2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbChannel1.SuspendLayout()
        CType(Me.nudVTrigger, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudZeroLine1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chtOscilloscope, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbConfiguration.SuspendLayout()
        CType(Me.nudTimeDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbChangeParams.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlConfig
        '
        Me.pnlConfig.Controls.Add(Me.Button1)
        Me.pnlConfig.Controls.Add(Me.gbConfiguration)
        Me.pnlConfig.Controls.Add(Me.btnClearGraph)
        Me.pnlConfig.Controls.Add(Me.gbChannel3)
        Me.pnlConfig.Controls.Add(Me.gbChannel2)
        Me.pnlConfig.Controls.Add(Me.gbChannel1)
        Me.pnlConfig.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlConfig.Location = New System.Drawing.Point(829, 0)
        Me.pnlConfig.Name = "pnlConfig"
        Me.pnlConfig.Size = New System.Drawing.Size(249, 760)
        Me.pnlConfig.TabIndex = 2
        '
        'btnClearGraph
        '
        Me.btnClearGraph.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearGraph.Location = New System.Drawing.Point(12, 725)
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
        'nudVTrigger
        '
        Me.nudVTrigger.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudVTrigger.DecimalPlaces = 2
        Me.nudVTrigger.Location = New System.Drawing.Point(77, 45)
        Me.nudVTrigger.Name = "nudVTrigger"
        Me.nudVTrigger.Size = New System.Drawing.Size(132, 20)
        Me.nudVTrigger.TabIndex = 7
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
        ChartArea7.AxisX.IsStartedFromZero = False
        ChartArea7.AxisY.IsStartedFromZero = False
        ChartArea7.Name = "ChartArea1"
        Me.chtOscilloscope.ChartAreas.Add(ChartArea7)
        Me.chtOscilloscope.Dock = System.Windows.Forms.DockStyle.Fill
        Legend7.Name = "Legend1"
        Me.chtOscilloscope.Legends.Add(Legend7)
        Me.chtOscilloscope.Location = New System.Drawing.Point(0, 0)
        Me.chtOscilloscope.Name = "chtOscilloscope"
        Me.chtOscilloscope.Size = New System.Drawing.Size(829, 760)
        Me.chtOscilloscope.TabIndex = 3
        Me.chtOscilloscope.Text = "Oscilloscope"
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
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(130, 725)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 23)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Lock"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbTriggerChannel
        '
        Me.cmbTriggerChannel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbTriggerChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTriggerChannel.FormattingEnabled = True
        Me.cmbTriggerChannel.Location = New System.Drawing.Point(58, 24)
        Me.cmbTriggerChannel.Name = "cmbTriggerChannel"
        Me.cmbTriggerChannel.Size = New System.Drawing.Size(163, 21)
        Me.cmbTriggerChannel.TabIndex = 0
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
        'nudTimeDivision
        '
        Me.nudTimeDivision.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nudTimeDivision.Location = New System.Drawing.Point(77, 19)
        Me.nudTimeDivision.Name = "nudTimeDivision"
        Me.nudTimeDivision.Size = New System.Drawing.Size(132, 20)
        Me.nudTimeDivision.TabIndex = 12
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
        'btnUpdateName
        '
        Me.btnUpdateName.Location = New System.Drawing.Point(8, 45)
        Me.btnUpdateName.Name = "btnUpdateName"
        Me.btnUpdateName.Size = New System.Drawing.Size(201, 23)
        Me.btnUpdateName.TabIndex = 15
        Me.btnUpdateName.Text = "Update Name"
        Me.btnUpdateName.UseVisualStyleBackColor = True
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Device"
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
        'frmOscilloscope
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 760)
        Me.Controls.Add(Me.chtOscilloscope)
        Me.Controls.Add(Me.pnlConfig)
        Me.Name = "frmOscilloscope"
        Me.Text = "Oscilloscope"
        Me.pnlConfig.ResumeLayout(False)
        Me.gbChannel3.ResumeLayout(False)
        Me.gbChannel3.PerformLayout()
        CType(Me.nudZeroLine3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbChannel2.ResumeLayout(False)
        Me.gbChannel2.PerformLayout()
        CType(Me.nudZeroLine2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbChannel1.ResumeLayout(False)
        Me.gbChannel1.PerformLayout()
        CType(Me.nudVTrigger, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudZeroLine1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chtOscilloscope, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbConfiguration.ResumeLayout(False)
        Me.gbConfiguration.PerformLayout()
        CType(Me.nudTimeDivision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbChangeParams.ResumeLayout(False)
        Me.gbChangeParams.PerformLayout()
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
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
End Class
