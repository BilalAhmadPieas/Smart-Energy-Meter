<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.TextBoxPowerConsumed = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ButtonConnectEV = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.ButtonDisconnectEV = New System.Windows.Forms.Button()
        Me.TextBoxPowerAvailable = New System.Windows.Forms.TextBox()
        Me.TextBoxSOC = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBoxPowerAllowed = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBoxclallowed = New System.Windows.Forms.TextBox()
        Me.ButtonConnectCL = New System.Windows.Forms.Button()
        Me.ButtonConnectNCL = New System.Windows.Forms.Button()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBoxNCLAllowed = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.ButtonConnectref = New System.Windows.Forms.Button()
        Me.ButtonConnecthsystem = New System.Windows.Forms.Button()
        Me.ButtonConnectwmachine = New System.Windows.Forms.Button()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.TextBoxclstatus = New System.Windows.Forms.TextBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.TextBoxNCLStatus = New System.Windows.Forms.TextBox()
        Me.ButtonDisconnectNCL = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.ButtonDisconnectCL = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBoxPowerConsumed
        '
        Me.TextBoxPowerConsumed.AccessibleDescription = ""
        Me.TextBoxPowerConsumed.Location = New System.Drawing.Point(213, 43)
        Me.TextBoxPowerConsumed.Multiline = True
        Me.TextBoxPowerConsumed.Name = "TextBoxPowerConsumed"
        Me.TextBoxPowerConsumed.Size = New System.Drawing.Size(100, 26)
        Me.TextBoxPowerConsumed.TabIndex = 0
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(213, 14)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 1
        '
        'ButtonConnectEV
        '
        Me.ButtonConnectEV.Location = New System.Drawing.Point(481, 46)
        Me.ButtonConnectEV.Name = "ButtonConnectEV"
        Me.ButtonConnectEV.Size = New System.Drawing.Size(141, 32)
        Me.ButtonConnectEV.TabIndex = 2
        Me.ButtonConnectEV.Text = "Connect EV"
        Me.ButtonConnectEV.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM7"
        '
        'ButtonDisconnectEV
        '
        Me.ButtonDisconnectEV.Location = New System.Drawing.Point(665, 46)
        Me.ButtonDisconnectEV.Name = "ButtonDisconnectEV"
        Me.ButtonDisconnectEV.Size = New System.Drawing.Size(141, 32)
        Me.ButtonDisconnectEV.TabIndex = 3
        Me.ButtonDisconnectEV.Text = "Disconnect EV"
        Me.ButtonDisconnectEV.UseVisualStyleBackColor = True
        '
        'TextBoxPowerAvailable
        '
        Me.TextBoxPowerAvailable.Location = New System.Drawing.Point(213, 75)
        Me.TextBoxPowerAvailable.Multiline = True
        Me.TextBoxPowerAvailable.Name = "TextBoxPowerAvailable"
        Me.TextBoxPowerAvailable.Size = New System.Drawing.Size(100, 26)
        Me.TextBoxPowerAvailable.TabIndex = 4
        '
        'TextBoxSOC
        '
        Me.TextBoxSOC.Location = New System.Drawing.Point(143, 14)
        Me.TextBoxSOC.Multiline = True
        Me.TextBoxSOC.Name = "TextBoxSOC"
        Me.TextBoxSOC.Size = New System.Drawing.Size(64, 26)
        Me.TextBoxSOC.TabIndex = 5
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(65, 46)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(142, 26)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.Text = "Energy Consumed"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(91, 75)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(116, 26)
        Me.TextBox2.TabIndex = 7
        Me.TextBox2.Text = "Power Available"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(91, 14)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(46, 26)
        Me.TextBox3.TabIndex = 8
        Me.TextBox3.Text = "SOC"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(91, 107)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(116, 26)
        Me.TextBox4.TabIndex = 10
        Me.TextBox4.Text = "Power Allowed"
        '
        'TextBoxPowerAllowed
        '
        Me.TextBoxPowerAllowed.Location = New System.Drawing.Point(213, 107)
        Me.TextBoxPowerAllowed.Multiline = True
        Me.TextBoxPowerAllowed.Name = "TextBoxPowerAllowed"
        Me.TextBoxPowerAllowed.Size = New System.Drawing.Size(100, 26)
        Me.TextBoxPowerAllowed.TabIndex = 9
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(91, 373)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(116, 52)
        Me.TextBox5.TabIndex = 12
        Me.TextBox5.Text = "Critical Load:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lights"
        '
        'TextBoxclallowed
        '
        Me.TextBoxclallowed.Location = New System.Drawing.Point(213, 373)
        Me.TextBoxclallowed.Multiline = True
        Me.TextBoxclallowed.Name = "TextBoxclallowed"
        Me.TextBoxclallowed.Size = New System.Drawing.Size(100, 26)
        Me.TextBoxclallowed.TabIndex = 11
        '
        'ButtonConnectCL
        '
        Me.ButtonConnectCL.Location = New System.Drawing.Point(481, 367)
        Me.ButtonConnectCL.Name = "ButtonConnectCL"
        Me.ButtonConnectCL.Size = New System.Drawing.Size(141, 32)
        Me.ButtonConnectCL.TabIndex = 13
        Me.ButtonConnectCL.Text = "Connect"
        Me.ButtonConnectCL.UseVisualStyleBackColor = True
        '
        'ButtonConnectNCL
        '
        Me.ButtonConnectNCL.Location = New System.Drawing.Point(481, 180)
        Me.ButtonConnectNCL.Name = "ButtonConnectNCL"
        Me.ButtonConnectNCL.Size = New System.Drawing.Size(141, 32)
        Me.ButtonConnectNCL.TabIndex = 16
        Me.ButtonConnectNCL.Text = "Connect"
        Me.ButtonConnectNCL.UseVisualStyleBackColor = True
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(61, 148)
        Me.TextBox7.Multiline = True
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(146, 190)
        Me.TextBox7.TabIndex = 15
        Me.TextBox7.Text = "Non-Critical Loads:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Air Conditioner(AC)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Refregenration" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Heating System" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Washing Machine"
        '
        'TextBoxNCLAllowed
        '
        Me.TextBoxNCLAllowed.Location = New System.Drawing.Point(213, 186)
        Me.TextBoxNCLAllowed.Multiline = True
        Me.TextBoxNCLAllowed.Name = "TextBoxNCLAllowed"
        Me.TextBoxNCLAllowed.Size = New System.Drawing.Size(100, 26)
        Me.TextBoxNCLAllowed.TabIndex = 14
        '
        'TextBox9
        '
        Me.TextBox9.Location = New System.Drawing.Point(213, 308)
        Me.TextBox9.Multiline = True
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(100, 26)
        Me.TextBox9.TabIndex = 17
        '
        'TextBox10
        '
        Me.TextBox10.Location = New System.Drawing.Point(213, 266)
        Me.TextBox10.Multiline = True
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(100, 26)
        Me.TextBox10.TabIndex = 18
        '
        'TextBox11
        '
        Me.TextBox11.Location = New System.Drawing.Point(213, 227)
        Me.TextBox11.Multiline = True
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(100, 26)
        Me.TextBox11.TabIndex = 19
        '
        'ButtonConnectref
        '
        Me.ButtonConnectref.Location = New System.Drawing.Point(481, 221)
        Me.ButtonConnectref.Name = "ButtonConnectref"
        Me.ButtonConnectref.Size = New System.Drawing.Size(141, 32)
        Me.ButtonConnectref.TabIndex = 20
        Me.ButtonConnectref.Text = "Connect"
        Me.ButtonConnectref.UseVisualStyleBackColor = True
        '
        'ButtonConnecthsystem
        '
        Me.ButtonConnecthsystem.Location = New System.Drawing.Point(481, 260)
        Me.ButtonConnecthsystem.Name = "ButtonConnecthsystem"
        Me.ButtonConnecthsystem.Size = New System.Drawing.Size(141, 32)
        Me.ButtonConnecthsystem.TabIndex = 21
        Me.ButtonConnecthsystem.Text = "Connect"
        Me.ButtonConnecthsystem.UseVisualStyleBackColor = True
        '
        'ButtonConnectwmachine
        '
        Me.ButtonConnectwmachine.Location = New System.Drawing.Point(481, 302)
        Me.ButtonConnectwmachine.Name = "ButtonConnectwmachine"
        Me.ButtonConnectwmachine.Size = New System.Drawing.Size(141, 32)
        Me.ButtonConnectwmachine.TabIndex = 22
        Me.ButtonConnectwmachine.Text = "Connect"
        Me.ButtonConnectwmachine.UseVisualStyleBackColor = True
        '
        'TextBox12
        '
        Me.TextBox12.Location = New System.Drawing.Point(213, 148)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(219, 26)
        Me.TextBox12.TabIndex = 23
        Me.TextBox12.Text = "Power Allowed         Status"
        '
        'TextBoxclstatus
        '
        Me.TextBoxclstatus.Location = New System.Drawing.Point(332, 373)
        Me.TextBoxclstatus.Multiline = True
        Me.TextBoxclstatus.Name = "TextBoxclstatus"
        Me.TextBoxclstatus.Size = New System.Drawing.Size(100, 26)
        Me.TextBoxclstatus.TabIndex = 24
        '
        'TextBox14
        '
        Me.TextBox14.Location = New System.Drawing.Point(332, 308)
        Me.TextBox14.Multiline = True
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(100, 26)
        Me.TextBox14.TabIndex = 25
        '
        'TextBox15
        '
        Me.TextBox15.Location = New System.Drawing.Point(332, 266)
        Me.TextBox15.Multiline = True
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(100, 26)
        Me.TextBox15.TabIndex = 26
        '
        'TextBox16
        '
        Me.TextBox16.Location = New System.Drawing.Point(332, 227)
        Me.TextBox16.Multiline = True
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(100, 26)
        Me.TextBox16.TabIndex = 27
        '
        'TextBoxNCLStatus
        '
        Me.TextBoxNCLStatus.Location = New System.Drawing.Point(332, 186)
        Me.TextBoxNCLStatus.Multiline = True
        Me.TextBoxNCLStatus.Name = "TextBoxNCLStatus"
        Me.TextBoxNCLStatus.Size = New System.Drawing.Size(100, 26)
        Me.TextBoxNCLStatus.TabIndex = 28
        '
        'ButtonDisconnectNCL
        '
        Me.ButtonDisconnectNCL.Location = New System.Drawing.Point(665, 180)
        Me.ButtonDisconnectNCL.Name = "ButtonDisconnectNCL"
        Me.ButtonDisconnectNCL.Size = New System.Drawing.Size(141, 32)
        Me.ButtonDisconnectNCL.TabIndex = 29
        Me.ButtonDisconnectNCL.Text = "Disconnect"
        Me.ButtonDisconnectNCL.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(665, 221)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(141, 32)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "Disconnect"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(665, 260)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(141, 32)
        Me.Button3.TabIndex = 31
        Me.Button3.Text = "Disconnect"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(665, 302)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(141, 32)
        Me.Button4.TabIndex = 32
        Me.Button4.Text = "Disconnect"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'ButtonDisconnectCL
        '
        Me.ButtonDisconnectCL.Location = New System.Drawing.Point(665, 367)
        Me.ButtonDisconnectCL.Name = "ButtonDisconnectCL"
        Me.ButtonDisconnectCL.Size = New System.Drawing.Size(141, 32)
        Me.ButtonDisconnectCL.TabIndex = 33
        Me.ButtonDisconnectCL.Text = "Disconnect"
        Me.ButtonDisconnectCL.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1248, 450)
        Me.Controls.Add(Me.ButtonDisconnectCL)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ButtonDisconnectNCL)
        Me.Controls.Add(Me.TextBoxNCLStatus)
        Me.Controls.Add(Me.TextBox16)
        Me.Controls.Add(Me.TextBox15)
        Me.Controls.Add(Me.TextBox14)
        Me.Controls.Add(Me.TextBoxclstatus)
        Me.Controls.Add(Me.TextBox12)
        Me.Controls.Add(Me.ButtonConnectwmachine)
        Me.Controls.Add(Me.ButtonConnecthsystem)
        Me.Controls.Add(Me.ButtonConnectref)
        Me.Controls.Add(Me.TextBox11)
        Me.Controls.Add(Me.TextBox10)
        Me.Controls.Add(Me.TextBox9)
        Me.Controls.Add(Me.ButtonConnectNCL)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.TextBoxNCLAllowed)
        Me.Controls.Add(Me.ButtonConnectCL)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBoxclallowed)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBoxPowerAllowed)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBoxSOC)
        Me.Controls.Add(Me.TextBoxPowerAvailable)
        Me.Controls.Add(Me.ButtonDisconnectEV)
        Me.Controls.Add(Me.ButtonConnectEV)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.TextBoxPowerConsumed)
        Me.DoubleBuffered = True
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxPowerConsumed As TextBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ButtonConnectEV As Button
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents ButtonDisconnectEV As Button
    Friend WithEvents TextBoxPowerAvailable As TextBox
    Friend WithEvents TextBoxSOC As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBoxPowerAllowed As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBoxclallowed As TextBox
    Friend WithEvents ButtonConnectCL As Button
    Friend WithEvents ButtonConnectNCL As Button
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBoxNCLAllowed As TextBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents ButtonConnectref As Button
    Friend WithEvents ButtonConnecthsystem As Button
    Friend WithEvents ButtonConnectwmachine As Button
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents TextBoxclstatus As TextBox
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents TextBox16 As TextBox
    Friend WithEvents TextBoxNCLStatus As TextBox
    Friend WithEvents ButtonDisconnectNCL As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents ButtonDisconnectCL As Button
End Class
