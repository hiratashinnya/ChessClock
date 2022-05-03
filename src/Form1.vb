Imports System.Media

Public Class Form1
    Private WithEvents clock As ChessClock
    Private p1min As Integer = 0
    Private p2min As Integer = 0
    Private p1sec As Integer = 0
    Private p2sec As Integer = 0
    Private p1byo As Integer = 0
    Private p2byo As Integer = 0

    ''' <summary>
    ''' 動作中フラグ
    ''' </summary>
    Private _DuringCountdown As Boolean
    Public Property DuringCountdown() As Boolean
        Get
            Return _DuringCountdown
        End Get
        Set(value As Boolean)
            _DuringCountdown = value
        End Set
    End Property

    Private _DuringPause As Boolean
    Public Property DuringPause() As Boolean
        Get
            Return _DuringPause
        End Get
        Set(ByVal value As Boolean)
            _DuringPause = value
        End Set
    End Property

    Private Const min2sec As Integer = 60

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clock = New ChessClock(2)
        DuringCountdown = False
        DuringPause = False
    End Sub

#Region "Setting"
    Private Sub DuringSetting_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles DuringSetting_CheckBox.CheckedChanged
        If DuringSetting_CheckBox.Checked Then
            ' 設定開始
            StartSetting()
        Else
            ' 設定終了
            FinishSetting()
        End If
    End Sub

    Private Sub FinishSetting()
        Player1Name_TextBox.Enabled = False
        Player1Minitute_TextBox.Enabled = False
        Player1Second_TextBox.Enabled = False
        Player1Byo_yomi_TextBox.Enabled = False

        Player2Name_TextBox.Enabled = False
        Player2Minitute_TextBox.Enabled = False
        Player2Second_TextBox.Enabled = False
        Player2Byo_yomi_TextBox.Enabled = False

        CanDifferentTime_CheckBox.Enabled = False
        HasByo_yomi_CheckBox.Enabled = False

        Player1Done_Button.Enabled = True
        Player2Done_Button.Enabled = True
        Pause_ResetButton.Enabled = False

        If CheckSettingDataFormat() Then
            If CanDifferentTime_CheckBox.Checked = False Then
                SyncP1P2()
            End If
            clock.ClearPlayerData()
            clock.SetPlayerData(Player1Name_TextBox.Text, p1min * min2sec + p1sec, p1byo)
            clock.SetPlayerData(Player2Name_TextBox.Text, p2min * min2sec + p2sec, p2byo)
            clock.EnableByo_yomi = HasByo_yomi_CheckBox.Checked
        Else
            DuringSetting_CheckBox.Checked = True
        End If
    End Sub

    Private Sub StartSetting()
        Player1Done_Button.Enabled = False
        Player2Done_Button.Enabled = False
        Pause_ResetButton.Enabled = False

        Player1Name_TextBox.Enabled = True
        Player1Minitute_TextBox.Enabled = True
        Player1Second_TextBox.Enabled = True
        Player1Byo_yomi_TextBox.Enabled = HasByo_yomi_CheckBox.Checked

        Player2Name_TextBox.Enabled = True
        ' ハンデありの時のみ
        Player2Minitute_TextBox.Enabled = CanDifferentTime_CheckBox.Checked
        Player2Second_TextBox.Enabled = CanDifferentTime_CheckBox.Checked
        Player2Byo_yomi_TextBox.Enabled = CanDifferentTime_CheckBox.Checked And HasByo_yomi_CheckBox.Checked

        CanDifferentTime_CheckBox.Enabled = True
        HasByo_yomi_CheckBox.Enabled = True
    End Sub

    Private Sub SyncP1P2()
        Player2Minitute_TextBox.Text = Player1Minitute_TextBox.Text
        Player2Second_TextBox.Text = Player1Second_TextBox.Text
        Player2Byo_yomi_TextBox.Text = Player1Byo_yomi_TextBox.Text

        p2min = p1min
        p2sec = p1sec
        p2byo = p1byo
    End Sub

    Private Function CheckSettingDataFormat() As Boolean
        If Integer.TryParse(Player1Minitute_TextBox.Text.ToString, p1min) = False _
            OrElse clock.CheckHeldMinRange(p1min) = False Then
            Return False
        End If

        If Integer.TryParse(Player1Second_TextBox.Text.ToString, p1sec) = False _
            OrElse clock.CheckHeldSecRange(p1sec) = False Then
            Return False
        End If

        If Integer.TryParse(Player1Byo_yomi_TextBox.Text.ToString, p1byo) = False _
            OrElse clock.Checkbyo_yomiRange(p1byo) = False Then
            Return False
        End If

        ' ハンデありの時だけチェックする
        If CanDifferentTime_CheckBox.Checked Then
            If Integer.TryParse(Player2Minitute_TextBox.Text.ToString, p2min) = False _
            OrElse clock.CheckHeldMinRange(p2min) = False Then
                Return False
            End If

            If Integer.TryParse(Player2Second_TextBox.Text.ToString, p2sec) = False _
                OrElse clock.CheckHeldSecRange(p2sec) = False Then
                Return False
            End If

            If Integer.TryParse(Player2Byo_yomi_TextBox.Text.ToString, p2byo) = False _
                OrElse clock.Checkbyo_yomiRange(p2byo) = False Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub HasByo_yomi_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles HasByo_yomi_CheckBox.CheckedChanged
        If HasByo_yomi_CheckBox.Checked Then
            Player1Byo_yomi_TextBox.Enabled = DuringSetting_CheckBox.Checked
            Player2Byo_yomi_TextBox.Enabled = DuringSetting_CheckBox.Checked And CanDifferentTime_CheckBox.Checked
        Else
            Player1Byo_yomi_TextBox.Text = "0"
            p1byo = 0
            Player1Byo_yomi_TextBox.Enabled = False

            Player2Byo_yomi_TextBox.Text = "0"
            p2byo = 0
            Player2Byo_yomi_TextBox.Enabled = False
        End If
    End Sub

    Private Sub CanDifferentTime_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CanDifferentTime_CheckBox.CheckedChanged
        If CanDifferentTime_CheckBox.Checked Then
            Player2Minitute_TextBox.Enabled = DuringSetting_CheckBox.Checked
            Player2Second_TextBox.Enabled = DuringSetting_CheckBox.Checked
            Player2Byo_yomi_TextBox.Enabled = DuringSetting_CheckBox.Checked And HasByo_yomi_CheckBox.Checked
        Else
            Player2Minitute_TextBox.Enabled = False
            Player2Second_TextBox.Enabled = False
            Player2Byo_yomi_TextBox.Enabled = False

            SyncP1P2()
        End If
    End Sub

#End Region

    Private Sub Done_Button_Click(sender As Object, e As EventArgs) Handles Player2Done_Button.Click, Player1Done_Button.Click
        Dim nextPlayer As String

        If CType(sender, Button).Name = Player1Done_Button.Name Then
            Player1Done_Button.Enabled = False
            nextPlayer = Player2Name_TextBox.Text
            Player2Done_Button.Enabled = True
        ElseIf CType(sender, Button).Name = Player2Done_Button.Name Then
            Player2Done_Button.Enabled = False
            nextPlayer = Player1Name_TextBox.Text
            Player1Done_Button.Enabled = True
        Else
            ' 起こらないはず
            Throw New Exception("変なイベントを拾っている")
        End If

        If DuringCountdown Then
            clock.StartNextPlayer(nextPlayer)
            UpdateViewOfTimes()
        Else
            If DuringPause Then
                clock.StartNextPlayer(nextPlayer)
                UpdateViewOfTimes()
                DuringPause = False
                DuringCountdown = True
                Pause_ResetButton.Text = "Pause"
            Else
                DuringCountdown = True
                DuringSetting_CheckBox.Enabled = False
                clock.StartCountDown(nextPlayer)
                Pause_ResetButton.Enabled = True
            End If
        End If
    End Sub


    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles Pause_ResetButton.Click
        If DuringCountdown Then
            clock.PauseTimer()
            DuringCountdown = False
            DuringPause = True
            Pause_ResetButton.Text = "Reset"
            Player1Done_Button.Enabled = Not Player1Done_Button.Enabled
            Player2Done_Button.Enabled = Not Player2Done_Button.Enabled
        Else
            If DuringPause Then
                clock.Reset()
                ResetViewOfTimes()
                DuringPause = False
                Pause_ResetButton.Text = "Pause"
                DuringSetting_CheckBox.Enabled = True
                FinishSetting()
            End If
        End If
    End Sub

    Private Sub UpdateViewOfTimes()
        Dim p1Name = Player1Name_TextBox.Text
        Player1Minitute_TextBox.Text = Int(clock.Players(p1Name).RemainHeldTime / 60).ToString()
        Player1Second_TextBox.Text = CInt(clock.Players(p1Name).RemainHeldTime Mod 60).ToString()
        Player1Byo_yomi_TextBox.Text = clock.Players(p1Name).RemainByo_yomiTime.ToString()

        Dim p2Name = Player2Name_TextBox.Text
        Player2Minitute_TextBox.Text = Int(clock.Players(p2Name).RemainHeldTime / 60).ToString()
        Player2Second_TextBox.Text = CInt(clock.Players(p2Name).RemainHeldTime Mod 60).ToString()
        Player2Byo_yomi_TextBox.Text = clock.Players(p2Name).RemainByo_yomiTime.ToString()
    End Sub

    Private Sub ResetViewOfTimes()
        Dim p1Name = Player1Name_TextBox.Text
        Player1Minitute_TextBox.Text = Int(clock.Players(p1Name).TotalHeldTime / 60).ToString()
        Player1Second_TextBox.Text = CInt(clock.Players(p1Name).TotalHeldTime Mod 60).ToString()
        Player1Byo_yomi_TextBox.Text = clock.Players(p1Name).TotalByo_yomiTime.ToString()

        Dim p2Name = Player2Name_TextBox.Text
        Player2Minitute_TextBox.Text = Int(clock.Players(p2Name).TotalHeldTime / 60).ToString()
        Player2Second_TextBox.Text = CInt(clock.Players(p2Name).TotalHeldTime Mod 60).ToString()
        Player2Byo_yomi_TextBox.Text = clock.Players(p2Name).TotalByo_yomiTime.ToString()
    End Sub

    Private Sub UpdateHeldTimes(sender As ChessClock, e As ChessClockEventArgs) Handles clock.UpdatedHeldTime
        UpdateViewOfTimes()
    End Sub

    Private Sub UpdateByo_yomiTimes(sender As ChessClock, e As ChessClockEventArgs) Handles clock.UpdatedByo_yomiTime
        UpdateViewOfTimes()
    End Sub

    Private Sub TimeUp(sender As ChessClock, e As ChessClockEventArgs) Handles clock.TimeUp
        Player1Done_Button.Enabled = False
        Player2Done_Button.Enabled = False
        UpdateViewOfTimes()
        Pause_ResetButton.Text = "Reset"
        DuringCountdown = False
        DuringPause = True
        SystemSounds.Beep.Play()
    End Sub
End Class
