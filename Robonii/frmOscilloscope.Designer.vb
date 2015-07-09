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
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.pnlConfig = New System.Windows.Forms.Panel()
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
        Me.nudTrigger1 = New System.Windows.Forms.NumericUpDown()
        Me.lblTrigger1 = New System.Windows.Forms.Label()
        Me.nudZeroLine1 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chtOscilloscope = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btnClearGraph = New System.Windows.Forms.Button()
        Me.pnlConfig.SuspendLayout()
        Me.gbChannel3.SuspendLayout()
        CType(Me.nudZeroLine3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbChannel2.SuspendLayout()
        CType(Me.nudZeroLine2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbChannel1.SuspendLayout()
        CType(Me.nudTrigger1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudZeroLine1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chtOscilloscope, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlConfig
        '
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
        'gbChannel3
        '
        Me.gbChannel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbChannel3.Controls.Add(Me.nudZeroLine3)
        Me.gbChannel3.Controls.Add(Me.Label10)
        Me.gbChannel3.Controls.Add(Me.Label12)
        Me.gbChannel3.Controls.Add(Me.cmbCOM3)
        Me.gbChannel3.Location = New System.Drawing.Point(12, 349)
        Me.gbChannel3.Name = "gbChannel3"
        Me.gbChannel3.Size = New System.Drawing.Size(227, 156)
        Me.gbChannel3.TabIndex = 15
        Me.gbChannel3.TabStop = False
        Me.gbChannel3.Text = "Channel 3"
        '
        'nudZeroLine3
        '
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
        Me.gbChannel2.Location = New System.Drawing.Point(12, 178)
        Me.gbChannel2.Name = "gbChannel2"
        Me.gbChannel2.Size = New System.Drawing.Size(227, 165)
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
        Me.gbChannel1.Controls.Add(Me.nudTrigger1)
        Me.gbChannel1.Controls.Add(Me.lblTrigger1)
        Me.gbChannel1.Controls.Add(Me.nudZeroLine1)
        Me.gbChannel1.Controls.Add(Me.Label4)
        Me.gbChannel1.Location = New System.Drawing.Point(12, 12)
        Me.gbChannel1.Name = "gbChannel1"
        Me.gbChannel1.Size = New System.Drawing.Size(227, 160)
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
        Me.cmbCOM1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCOM1.FormattingEnabled = True
        Me.cmbCOM1.Location = New System.Drawing.Point(83, 22)
        Me.cmbCOM1.Name = "cmbCOM1"
        Me.cmbCOM1.Size = New System.Drawing.Size(120, 21)
        Me.cmbCOM1.TabIndex = 0
        '
        'nudTrigger1
        '
        Me.nudTrigger1.DecimalPlaces = 2
        Me.nudTrigger1.Location = New System.Drawing.Point(83, 129)
        Me.nudTrigger1.Name = "nudTrigger1"
        Me.nudTrigger1.Size = New System.Drawing.Size(120, 20)
        Me.nudTrigger1.TabIndex = 7
        '
        'lblTrigger1
        '
        Me.lblTrigger1.AutoSize = True
        Me.lblTrigger1.Location = New System.Drawing.Point(7, 131)
        Me.lblTrigger1.Name = "lblTrigger1"
        Me.lblTrigger1.Size = New System.Drawing.Size(40, 13)
        Me.lblTrigger1.TabIndex = 6
        Me.lblTrigger1.Text = "Trigger"
        '
        'nudZeroLine1
        '
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
        ChartArea3.AxisX.IsStartedFromZero = False
        ChartArea3.AxisY.IsStartedFromZero = False
        ChartArea3.Name = "ChartArea1"
        Me.chtOscilloscope.ChartAreas.Add(ChartArea3)
        Me.chtOscilloscope.Dock = System.Windows.Forms.DockStyle.Fill
        Legend3.Name = "Legend1"
        Me.chtOscilloscope.Legends.Add(Legend3)
        Me.chtOscilloscope.Location = New System.Drawing.Point(0, 0)
        Me.chtOscilloscope.Name = "chtOscilloscope"
        Me.chtOscilloscope.Size = New System.Drawing.Size(829, 760)
        Me.chtOscilloscope.TabIndex = 3
        Me.chtOscilloscope.Text = "Oscilloscope"
        '
        'btnClearGraph
        '
        Me.btnClearGraph.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearGraph.Location = New System.Drawing.Point(6, 725)
        Me.btnClearGraph.Name = "btnClearGraph"
        Me.btnClearGraph.Size = New System.Drawing.Size(233, 23)
        Me.btnClearGraph.TabIndex = 16
        Me.btnClearGraph.Text = "Clear All"
        Me.btnClearGraph.UseVisualStyleBackColor = True
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
        CType(Me.nudTrigger1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudZeroLine1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chtOscilloscope, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlConfig As System.Windows.Forms.Panel
    Friend WithEvents chtOscilloscope As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents cmbCOM3 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCOM2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCOM1 As System.Windows.Forms.ComboBox
    Friend WithEvents nudTrigger1 As System.Windows.Forms.NumericUpDown
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
End Class
