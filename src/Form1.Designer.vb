<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Player2Minitute_TextBox = New System.Windows.Forms.TextBox()
        Me.Player1Minitute_TextBox = New System.Windows.Forms.TextBox()
        Me.Player1Second_TextBox = New System.Windows.Forms.TextBox()
        Me.Player2Second_TextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Player1Name_TextBox = New System.Windows.Forms.TextBox()
        Me.Player2Name_TextBox = New System.Windows.Forms.TextBox()
        Me.HasCountdown_CheckBox = New System.Windows.Forms.CheckBox()
        Me.DuringSetting_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Player1Countdown_TextBox = New System.Windows.Forms.TextBox()
        Me.Player2Countdown_TextBox = New System.Windows.Forms.TextBox()
        Me.Countdown2_Label = New System.Windows.Forms.Label()
        Me.Countdown1_Label = New System.Windows.Forms.Label()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.Player2Done_Button = New System.Windows.Forms.Button()
        Me.Player1Done_Button1 = New System.Windows.Forms.Button()
        Me.CanDifferentTime_CheckBox = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Player2Minitute_TextBox
        '
        Me.Player2Minitute_TextBox.Location = New System.Drawing.Point(437, 142)
        Me.Player2Minitute_TextBox.Name = "Player2Minitute_TextBox"
        Me.Player2Minitute_TextBox.Size = New System.Drawing.Size(160, 27)
        Me.Player2Minitute_TextBox.TabIndex = 0
        '
        'Player1Minitute_TextBox
        '
        Me.Player1Minitute_TextBox.Location = New System.Drawing.Point(12, 142)
        Me.Player1Minitute_TextBox.Name = "Player1Minitute_TextBox"
        Me.Player1Minitute_TextBox.Size = New System.Drawing.Size(160, 27)
        Me.Player1Minitute_TextBox.TabIndex = 1
        '
        'Player1Second_TextBox
        '
        Me.Player1Second_TextBox.Location = New System.Drawing.Point(204, 142)
        Me.Player1Second_TextBox.Name = "Player1Second_TextBox"
        Me.Player1Second_TextBox.Size = New System.Drawing.Size(160, 27)
        Me.Player1Second_TextBox.TabIndex = 2
        '
        'Player2Second_TextBox
        '
        Me.Player2Second_TextBox.Location = New System.Drawing.Point(628, 142)
        Me.Player2Second_TextBox.Name = "Player2Second_TextBox"
        Me.Player2Second_TextBox.Size = New System.Drawing.Size(160, 27)
        Me.Player2Second_TextBox.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(603, 142)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = " : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(178, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = " : "
        '
        'Player1Name_TextBox
        '
        Me.Player1Name_TextBox.Location = New System.Drawing.Point(12, 69)
        Me.Player1Name_TextBox.Name = "Player1Name_TextBox"
        Me.Player1Name_TextBox.Size = New System.Drawing.Size(160, 27)
        Me.Player1Name_TextBox.TabIndex = 6
        '
        'Player2Name_TextBox
        '
        Me.Player2Name_TextBox.Location = New System.Drawing.Point(628, 69)
        Me.Player2Name_TextBox.Name = "Player2Name_TextBox"
        Me.Player2Name_TextBox.Size = New System.Drawing.Size(160, 27)
        Me.Player2Name_TextBox.TabIndex = 7
        '
        'HasCountdown_CheckBox
        '
        Me.HasCountdown_CheckBox.AutoSize = True
        Me.HasCountdown_CheckBox.Location = New System.Drawing.Point(358, 101)
        Me.HasCountdown_CheckBox.Name = "HasCountdown_CheckBox"
        Me.HasCountdown_CheckBox.Size = New System.Drawing.Size(96, 24)
        Me.HasCountdown_CheckBox.TabIndex = 8
        Me.HasCountdown_CheckBox.Text = "秒読みあり"
        Me.HasCountdown_CheckBox.UseVisualStyleBackColor = True
        '
        'DuringSetting_CheckBox
        '
        Me.DuringSetting_CheckBox.AutoSize = True
        Me.DuringSetting_CheckBox.Location = New System.Drawing.Point(12, 22)
        Me.DuringSetting_CheckBox.Name = "DuringSetting_CheckBox"
        Me.DuringSetting_CheckBox.Size = New System.Drawing.Size(76, 24)
        Me.DuringSetting_CheckBox.TabIndex = 9
        Me.DuringSetting_CheckBox.Text = "設定中"
        Me.DuringSetting_CheckBox.UseVisualStyleBackColor = True
        '
        'Player1Countdown_TextBox
        '
        Me.Player1Countdown_TextBox.Location = New System.Drawing.Point(204, 200)
        Me.Player1Countdown_TextBox.Name = "Player1Countdown_TextBox"
        Me.Player1Countdown_TextBox.Size = New System.Drawing.Size(160, 27)
        Me.Player1Countdown_TextBox.TabIndex = 10
        '
        'Player2Countdown_TextBox
        '
        Me.Player2Countdown_TextBox.Location = New System.Drawing.Point(628, 200)
        Me.Player2Countdown_TextBox.Name = "Player2Countdown_TextBox"
        Me.Player2Countdown_TextBox.Size = New System.Drawing.Size(160, 27)
        Me.Player2Countdown_TextBox.TabIndex = 11
        '
        'Countdown2_Label
        '
        Me.Countdown2_Label.AutoSize = True
        Me.Countdown2_Label.Location = New System.Drawing.Point(515, 207)
        Me.Countdown2_Label.Name = "Countdown2_Label"
        Me.Countdown2_Label.Size = New System.Drawing.Size(82, 20)
        Me.Countdown2_Label.TabIndex = 12
        Me.Countdown2_Label.Text = "秒読み時間"
        '
        'Countdown1_Label
        '
        Me.Countdown1_Label.AutoSize = True
        Me.Countdown1_Label.Location = New System.Drawing.Point(90, 207)
        Me.Countdown1_Label.Name = "Countdown1_Label"
        Me.Countdown1_Label.Size = New System.Drawing.Size(82, 20)
        Me.Countdown1_Label.TabIndex = 13
        Me.Countdown1_Label.Text = "秒読み時間"
        '
        'ResetButton
        '
        Me.ResetButton.Location = New System.Drawing.Point(358, 407)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(79, 31)
        Me.ResetButton.TabIndex = 14
        Me.ResetButton.Text = "Reset"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'Player2Done_Button
        '
        Me.Player2Done_Button.Location = New System.Drawing.Point(561, 286)
        Me.Player2Done_Button.Name = "Player2Done_Button"
        Me.Player2Done_Button.Size = New System.Drawing.Size(227, 87)
        Me.Player2Done_Button.TabIndex = 15
        Me.Player2Done_Button.Text = "Done"
        Me.Player2Done_Button.UseVisualStyleBackColor = True
        '
        'Player1Done_Button1
        '
        Me.Player1Done_Button1.Location = New System.Drawing.Point(12, 286)
        Me.Player1Done_Button1.Name = "Player1Done_Button1"
        Me.Player1Done_Button1.Size = New System.Drawing.Size(227, 87)
        Me.Player1Done_Button1.TabIndex = 16
        Me.Player1Done_Button1.Text = "Done"
        Me.Player1Done_Button1.UseVisualStyleBackColor = True
        '
        'CanDifferentTime_CheckBox
        '
        Me.CanDifferentTime_CheckBox.AutoSize = True
        Me.CanDifferentTime_CheckBox.Location = New System.Drawing.Point(106, 22)
        Me.CanDifferentTime_CheckBox.Name = "CanDifferentTime_CheckBox"
        Me.CanDifferentTime_CheckBox.Size = New System.Drawing.Size(88, 24)
        Me.CanDifferentTime_CheckBox.TabIndex = 17
        Me.CanDifferentTime_CheckBox.Text = "ハンデあり"
        Me.CanDifferentTime_CheckBox.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CanDifferentTime_CheckBox)
        Me.Controls.Add(Me.Player1Done_Button1)
        Me.Controls.Add(Me.Player2Done_Button)
        Me.Controls.Add(Me.ResetButton)
        Me.Controls.Add(Me.Countdown1_Label)
        Me.Controls.Add(Me.Countdown2_Label)
        Me.Controls.Add(Me.Player2Countdown_TextBox)
        Me.Controls.Add(Me.Player1Countdown_TextBox)
        Me.Controls.Add(Me.DuringSetting_CheckBox)
        Me.Controls.Add(Me.HasCountdown_CheckBox)
        Me.Controls.Add(Me.Player2Name_TextBox)
        Me.Controls.Add(Me.Player1Name_TextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Player2Second_TextBox)
        Me.Controls.Add(Me.Player1Second_TextBox)
        Me.Controls.Add(Me.Player1Minitute_TextBox)
        Me.Controls.Add(Me.Player2Minitute_TextBox)
        Me.Name = "Form1"
        Me.Text = "ChessClock"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Player2Minitute_TextBox As TextBox
    Friend WithEvents Player1Minitute_TextBox As TextBox
    Friend WithEvents Player1Second_TextBox As TextBox
    Friend WithEvents Player2Second_TextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Player1Name_TextBox As TextBox
    Friend WithEvents Player2Name_TextBox As TextBox
    Friend WithEvents HasCountdown_CheckBox As CheckBox
    Friend WithEvents DuringSetting_CheckBox As CheckBox
    Friend WithEvents Player1Countdown_TextBox As TextBox
    Friend WithEvents Player2Countdown_TextBox As TextBox
    Friend WithEvents Countdown2_Label As Label
    Friend WithEvents Countdown1_Label As Label
    Friend WithEvents ResetButton As Button
    Friend WithEvents Player2Done_Button As Button
    Friend WithEvents Player1Done_Button1 As Button
    Friend WithEvents CanDifferentTime_CheckBox As CheckBox
End Class
