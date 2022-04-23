Public Class ChessClock
    Public players As List(Of PlayersTimer)

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
    ''' 現在の手番のプレイヤーのインデックス
    ''' </summary>
    Private _CurrentPlayerID As Integer
    Public Property CurrentPlayerID() As Integer
        Get
            Return _CurrentPlayerID
        End Get
        Set(ByVal value As Integer)
            _CurrentPlayerID = value
        End Set
    End Property

    ''' <summary>
    ''' ハンデありか
    ''' </summary>
    Private _HandicapAvailable As Boolean
    Public Property HandicapAvailable() As String
        Get
            Return _HandicapAvailable
        End Get
        Set(ByVal value As String)
            _HandicapAvailable = value
        End Set
    End Property

    ''' <summary>
    ''' 持ち時間更新イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Event UpdatedHeldTime(ByVal sender As Object, ByVal e As EventArgs)

    ''' <summary>
    ''' 秒読み時間更新イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Event UpdatedByo_yomiTime(ByVal sender As Object, ByVal e As EventArgs)

    ''' <summary>
    ''' 時間切れイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Event TimeUp(ByVal sender As Object, ByVal e As EventArgs)


    Public Sub New(ByVal playerNum As Integer)
        players = New List(Of PlayersTimer)(playerNum)
        _EnableByo_yomi = False
        _CurrentPlayerID = 0
        _HandicapAvailable = False
    End Sub

End Class
