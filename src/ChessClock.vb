Public Class ChessClock
    Public Players As Dictionary(Of String, PlayersTimer)
    Private WithEvents _CurrentPlayer As PlayersTimer
    Public Property CurrentPlayer() As PlayersTimer
        Get
            Return _CurrentPlayer
        End Get
        Private Set(ByVal value As PlayersTimer)
            _CurrentPlayer = value
        End Set
    End Property

    ''' <summary>
    ''' 秒読みありか
    ''' </summary>
    Private _EnableByo_yomi As Boolean
    Public Property EnableByo_yomi() As Boolean
        Get
            Return _EnableByo_yomi
        End Get
        Set(ByVal value As Boolean)
            _EnableByo_yomi = value
        End Set
    End Property

    ''' <summary>
    ''' ハンデありか
    ''' </summary>
    Private _HandicapAvailable As Boolean
    Public Property HandicapAvailable() As Boolean
        Get
            Return _HandicapAvailable
        End Get
        Set(ByVal value As Boolean)
            _HandicapAvailable = value
        End Set
    End Property

    ''' <summary>
    ''' 持ち時間更新イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Event UpdatedHeldTime(ByVal sender As ChessClock, ByVal e As ChessClockEventArgs)

    ''' <summary>
    ''' 秒読み時間更新イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Event UpdatedByo_yomiTime(ByVal sender As ChessClock, ByVal e As ChessClockEventArgs)

    ''' <summary>
    ''' 時間切れイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Event TimeUp(ByVal sender As ChessClock, ByVal e As ChessClockEventArgs)


    Public Sub New(ByVal playerNum As Integer)
        Players = New Dictionary(Of String, PlayersTimer)(playerNum)
        _EnableByo_yomi = False
        _CurrentPlayer = Nothing
        _HandicapAvailable = False
    End Sub

    Public Sub SetPlayerData(ByVal name As String, ByVal heldTime As Integer, ByVal byo_yomiTime As Integer)
        Players.Add(name, New PlayersTimer(name, heldTime, byo_yomiTime))
    End Sub

    ''' <summary>
    ''' 現在のプレイヤーのタイマーを停止し、指定するプレイヤーのタイマーを開始する。
    ''' </summary>
    ''' <param name="nextPlayer"></param>
    ''' <exception cref="ArgumentOutOfRangeException">プレイヤー数と引数の不一致時に発生する。発生時はなにもしない。</exception>
    Public Sub StartNextPlayer(ByVal nextPlayer As String)
        If Players.ContainsKey(nextPlayer) = False Then
            Throw New ArgumentOutOfRangeException("nextPlayer", "It must already be in the 'players'.")
        End If
        CurrentPlayer.StopTimer()

        ' 秒読み中か
        If EnableByo_yomi = True AndAlso CurrentPlayer.DuringByo_yomi = True Then
            CurrentPlayer.ResetByo_yomiTime()
        End If

        CurrentPlayer = Players(nextPlayer)
        CurrentPlayer.StartTimer()
    End Sub

    ''' <summary>
    ''' カウントダウンの開始メソッド。開始時以外に（StartNextPlayerメソッドの代わりに）呼び出してはならない。
    ''' </summary>
    ''' <param name="playerName"></param>
    Public Sub StartCountDown(ByVal playerName As String)
        If IsNothing(CurrentPlayer) = False Then
            Throw New InvalidOperationException("This method can be called only once.")
        End If
        If Players.ContainsKey(playerName) = False Then
            Throw New ArgumentOutOfRangeException("nextPlayer", "It must already be in the 'players'.")
        End If

        CurrentPlayer = Players(playerName)
        If EnableByo_yomi AndAlso CurrentPlayer.RemainHeldTime = 0 Then
            CurrentPlayer.DuringByo_yomi = True
        End If
        CurrentPlayer.StartTimer()
    End Sub

    Public Sub PauseTimer()
        CurrentPlayer.StopTimer()
    End Sub

    Public Sub Reset()
        CurrentPlayer.StopTimer()
        CurrentPlayer = Nothing
        For Each player As PlayersTimer In Players.Values()
            player.Reset()
        Next
    End Sub

    Private Sub OnPlayersTimerTick(ByVal sender As Object, ByVal e As EventArgs) Handles _CurrentPlayer.TickOwnTimer
        If CurrentPlayer.DuringByo_yomi Then
            CurrentPlayer.DecreaseByo_yomiTime()
            RaiseEvent UpdatedByo_yomiTime(Me, New ChessClockEventArgs(CurrentPlayer))

            If CurrentPlayer.RemainByo_yomiTime = 0 Then
                RaiseEvent TimeUp(Me, New ChessClockEventArgs(CurrentPlayer))
            Else
                ' Do nothing.
            End If
        Else
            CurrentPlayer.DecreaseHeldTime()
            RaiseEvent UpdatedHeldTime(Me, New ChessClockEventArgs(CurrentPlayer))

            If CurrentPlayer.RemainHeldTime = 0 Then
                If EnableByo_yomi Then
                    CurrentPlayer.DuringByo_yomi = True
                Else
                    RaiseEvent TimeUp(Me, New ChessClockEventArgs(CurrentPlayer))
                End If
            End If
        End If
    End Sub

End Class
