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

    Private Const min2sec As Integer = 60

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clock = New ChessClock(2)
        DuringCountdown = False
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
        ResetButton.Enabled = True

        If CheckSettingDataFormat() Then
            If CanDifferentTime_CheckBox.Checked = False Then
                SyncP1P2()
            End If
            clock.ClearPlayerData()
            clock.SetPlayerData(Player1Name_TextBox.Text, p1min * min2sec + p1sec, p1byo)
            clock.SetPlayerData(Player2Name_TextBox.Text, p2min * min2sec + p2sec, p2byo)
        Else
            DuringSetting_CheckBox.Checked = True
        End If
    End Sub

    Private Sub StartSetting()
        Player1Done_Button.Enabled = False
        Player2Done_Button.Enabled = False
        ResetButton.Enabled = False

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

    Private Sub Player1Done_Button_Click(sender As Object, e As EventArgs) Handles Player1Done_Button.Click, Player2Done_Button.Click
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
        Else
            DuringCountdown = True
            DuringSetting_CheckBox.Enabled = False
            clock.StartCountDown(nextPlayer)
        End If
    End Sub


    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click

    End Sub
End Class
