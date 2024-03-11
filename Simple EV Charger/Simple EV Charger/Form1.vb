Imports System.IO.Ports
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks

Public Class Form1
    Private powerAllowed As Double = 0
    Private powerConsumed As Double = 0
    Private voltageRating As Double = 220 ' Example voltage rating
    Private currentRating As Double = 32 ' Example current rating
    Private batteryCapacity As Double = 30 ' Battery capacity in KWh
    Dim soc As Double
    Dim availablePower As Double
    Private chargingActive As Boolean = False ' Flag for charging state

    ' For Critical Load
    Private CLpowerAllowed As Double = 0
    Private CLpowerConsumed As Double = 0
    Private CLloadActive As Boolean = False

    ' For Non-Critical Load (Adjust as needed)
    Private NCLpowerAllowed As Double = 0
    Private NCLpowerConsumed As Double = 0
    Private NCLloadActive As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ButtonDisconnectEV.Enabled = False
        ButtonDisconnectCL.Enabled = False
        ButtonDisconnectNCL.Enabled = False

        Try
            SerialPort1.Open()
        Catch ex As Exception
            MessageBox.Show("Error opening serial port: " & ex.Message)
        End Try
    End Sub

    Private Sub serialPort1_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim data As String = SerialPort1.ReadLine()

        ' Check if the string starts with the expected prefixes
        If data.StartsWith("Power Allowed: ") Then
            Dim powerAllowedString As String = data.Substring(15) ' Remove the prefix
            UpdatePowerAllowed(powerAllowedString)
        ElseIf data.StartsWith("CL Power Allowed: ") Then
            Dim CLpowerAllowedString As String = data.Substring(18) ' Remove the prefix
            UpdateCLPowerAllowed(CLpowerAllowedString)
        ElseIf data.StartsWith("NCL Power Allowed: ") Then
            Dim NCLpowerAllowedString As String = data.Substring(19) ' Remove the prefix
            UpdateNCLPowerAllowed(NCLpowerAllowedString)
        End If
    End Sub

    Private Sub UpdatePowerAllowed(powerAllowedString As String)
        If Double.TryParse(powerAllowedString, powerAllowed) Then
            SerialPort1.WriteLine("Confirmation received")
            UpdateUI()
        Else
            MessageBox.Show("Invalid power allowed value received.")
        End If
    End Sub

    Private Sub UpdateCLPowerAllowed(CLpowerAllowedString As String)
        If Double.TryParse(CLpowerAllowedString, CLpowerAllowed) Then
            UpdateUI()
        Else
            MessageBox.Show("Invalid critical load power allowed value received.")
        End If
    End Sub

    Private Sub UpdateNCLPowerAllowed(NCLpowerAllowedString As String)
        If Double.TryParse(NCLpowerAllowedString, NCLpowerAllowed) Then
            UpdateUI()
        Else
            MessageBox.Show("Invalid non-critical load power allowed value received.")
        End If
    End Sub

    Private Sub UpdateUI()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Sub()
                                     TextBoxPowerAvailable.Text = availablePower.ToString("0.00") & " kWh"
                                     TextBoxPowerAllowed.Text = powerAllowed.ToString("0.00") & " kWh"
                                     TextBoxPowerConsumed.Text = powerConsumed.ToString("0.00") & " kWh"
                                     ProgressBar1.Value = CInt(soc)
                                     TextBoxSOC.Text = soc.ToString("0.00") & " %"
                                     SerialPort1.WriteLine("SOC:" + soc.ToString("0.00") & " %")
                                     TextBoxclallowed.Text = CLpowerAllowed.ToString("0.00") & " kWh"
                                     'TextBoxCLConsumed.Text = CLpowerConsumed.ToString("0.00") & " kWh"
                                     TextBoxclstatus.Text = If(CLloadActive, "ON", "OFF")

                                     TextBoxNCLAllowed.Text = NCLpowerAllowed.ToString("0.00") & " kWh"
                                     'TextBoxNCLConsumed.Text = NCLpowerConsumed.ToString("0.00") & " kWh"
                                     TextBoxNCLStatus.Text = If(NCLloadActive, "ON", "OFF")
                                 End Sub))
        Else
            TextBoxPowerAvailable.Text = availablePower.ToString("0.00") & " kWh"
            TextBoxPowerAllowed.Text = powerAllowed.ToString("0.00") & " kWh"
            TextBoxPowerConsumed.Text = powerConsumed.ToString("0.00") & " kWh"
            ProgressBar1.Value = CInt(soc)
            TextBoxSOC.Text = soc.ToString("0.00") & " %"

            TextBoxclallowed.Text = CLpowerAllowed.ToString("0.00") & " kWh"
            ' TextBoxCLConsumed.Text = CLpowerConsumed.ToString("0.00") & " kWh"
            TextBoxclstatus.Text = If(CLloadActive, "ON", "OFF")

            TextBoxNCLAllowed.Text = NCLpowerAllowed.ToString("0.00") & " kWh"
            'TextBoxNCLConsumed.Text = NCLpowerConsumed.ToString("0.00") & " kWh"
            TextBoxNCLStatus.Text = If(NCLloadActive, "ON", "OFF")
        End If
    End Sub

    Private Sub ButtonStartCharging_Click(sender As Object, e As EventArgs) Handles ButtonConnectEV.Click
        ' Implement charging logic here, considering power allowed and safety limits
        ' Update powerConsumed based on charging time and current
        ' Ensure power allowed is received and valid
        While (chargingActive = False)
            SerialPort1.WriteLine("EV Connected")
            If Not chargingActive Then
                chargingActive = True
                ButtonConnectEV.Enabled = False
                ButtonDisconnectEV.Enabled = True
                Task.Run(AddressOf StartChargingLoop)
            End If
        End While
    End Sub
    Private Sub ButtonStopCharging_Click(sender As Object, e As EventArgs) Handles ButtonDisconnectEV.Click
        While (chargingActive = True)
            SerialPort1.WriteLine("EV Disconnected")
            If chargingActive Then
                chargingActive = False
                ButtonConnectEV.Enabled = True
                ButtonDisconnectEV.Enabled = False
                powerAllowed = 0
                availablePower = 0
                UpdateUI()
            End If
        End While
    End Sub
    Private Sub StartChargingLoop()
        While chargingActive = True And powerAllowed >= 0
            ' Calculate available charging power based on limitations
            availablePower = Math.Min(powerAllowed, ((voltageRating * currentRating) / 1000))

            ' Update power consumed based on available power and time
            powerConsumed += availablePower * 1 / 60 ' 1 hour = 1 minute

            ' Calculate and update State of Charge (SOC)
            soc = powerConsumed / batteryCapacity * 100

            ' Update UI elements
            UpdateUI()

            ' Check for battery full condition (adjust threshold accordingly)
            If soc >= 95 Then
                MessageBox.Show("Battery almost full, stopping charging.")
                chargingActive = False
            End If

            ' Delay between loop iterations to avoid excessive CPU usage
            Thread.Sleep(1000) ' Adjust delay as needed
        End While

        ' Ensure final update of UI after stopping charging
        UpdateUI()
    End Sub
    Private Sub ButtonStartCL_Click(sender As Object, e As EventArgs) Handles ButtonConnectCL.Click
        While (CLloadActive = False)
            SerialPort1.WriteLine("Critical Load Connected")
            If Not CLloadActive Then
                CLloadActive = True
                ButtonConnectCL.Enabled = False
                ButtonDisconnectCL.Enabled = True
                Task.Run(AddressOf StartCLConsumption)
            End If
        End While
    End Sub

    Private Sub ButtonStopCL_Click(sender As Object, e As EventArgs) Handles ButtonDisconnectCL.Click
        While (CLloadActive = True)
            SerialPort1.WriteLine("Critical Load Disconnected")
            If CLloadActive Then
                CLloadActive = False
                ButtonConnectCL.Enabled = True
                ButtonDisconnectCL.Enabled = False
                CLpowerAllowed = 0
                UpdateUI()
            End If
        End While
    End Sub

    Private Sub StartCLConsumption()
        While CLloadActive AndAlso CLpowerAllowed >= 0
            CLpowerConsumed += CLpowerAllowed * 1 / 60
            UpdateUI()
            Thread.Sleep(1000)
        End While

        UpdateUI()
    End Sub

    Private Sub ButtonStartNCL_Click(sender As Object, e As EventArgs) Handles ButtonConnectNCL.Click
        While (NCLloadActive = False)
            SerialPort1.WriteLine("Non-Critical Load Connected")
            If Not NCLloadActive Then
                NCLloadActive = True
                ButtonConnectNCL.Enabled = False
                ButtonDisconnectNCL.Enabled = True
                Task.Run(AddressOf StartNCLConsumption)
            End If
        End While
    End Sub

    Private Sub ButtonStopNCL_Click(sender As Object, e As EventArgs) Handles ButtonDisconnectNCL.Click
        While (NCLloadActive = True)
            SerialPort1.WriteLine("Non-Critical Load Disconnected")
            If NCLloadActive Then
                NCLloadActive = False
                ButtonConnectNCL.Enabled = True
                ButtonDisconnectNCL.Enabled = False
                NCLpowerAllowed = 0
                UpdateUI()
            End If
        End While
    End Sub

    Private Sub StartNCLConsumption()
        While NCLloadActive AndAlso NCLpowerAllowed >= 0
            NCLpowerConsumed += NCLpowerAllowed * 1 / 60
            UpdateUI()
            Thread.Sleep(1000)
        End While

        UpdateUI()
    End Sub
    Private Sub Form1_FormClosed(sender As Object, e As EventArgs) Handles Me.FormClosed
        SerialPort1.Close()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class
