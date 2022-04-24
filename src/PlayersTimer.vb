Public Class PlayersTimer
    Private _Name As String
    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Private _TotalHeldTime As Integer
    Public Property TotalHeldTime() As Integer
        Get
            Return _TotalHeldTime
        End Get
        Set(ByVal value As Integer)
            _TotalHeldTime = value
        End Set
    End Property

    Private _TotalByo_yomiTime As Integer
    Public Property TotalByo_yomiTime() As Integer
        Get
            Return _TotalByo_yomiTime
        End Get
        Set(ByVal value As Integer)
            _TotalByo_yomiTime = value
        End Set
    End Property

    Private _RemainHeldTime As Integer
    Public Property RemainHeldTime() As Integer
        Get
            Return _RemainHeldTime
        End Get
        Set(ByVal value As Integer)
            _RemainHeldTime = value
        End Set
    End Property

    Private _RemainByo_yomiTime As Integer
    Public Property RemainByo_yomiTime() As Integer
        Get
            Return _RemainByo_yomiTime
        End Get
        Set(ByVal value As Integer)
            _RemainByo_yomiTime = value
        End Set
    End Property

    Private _DuringByo_yomi As Boolean
    Public Property DuringByo_yomi() As Boolean
        Get
            Return _DuringByo_yomi
        End Get
        Set(ByVal value As Boolean)
            _DuringByo_yomi = value
        End Set
    End Property

    Private WithEvents _OwnTimer As Timer
    Public ReadOnly Property OwnTimer() As Timer
        Get
            Return _OwnTimer
        End Get
    End Property

    Public Sub New(ByVal name As String, ByVal heldTime As Integer, ByVal byo_yomiTime As Integer)
        _Name = name

        _TotalHeldTime = heldTime
        _RemainHeldTime = heldTime

        _TotalByo_yomiTime = byo_yomiTime
        _RemainByo_yomiTime = byo_yomiTime

        _DuringByo_yomi = False

        _OwnTimer = New Timer
    End Sub

    Public Sub ChangePlayerData(ByVal name As String, ByVal heldTime As Integer, ByVal byo_yomiTime As Integer)
        _Name = name

        _TotalHeldTime = heldTime
        _RemainHeldTime = heldTime

        _TotalByo_yomiTime = byo_yomiTime
        _RemainByo_yomiTime = byo_yomiTime

        _DuringByo_yomi = False

        _OwnTimer = New Timer
    End Sub

    Private Sub RaiseTickerEvent() Handles _OwnTimer.Tick
        RaiseEvent TickOwnTimer(Me, Nothing)
    End Sub

    Public Event TickOwnTimer(ByVal sender As Object, ByVal e As EventArgs)

    Public Sub Reset()
        StopTimer()
        ResetHeldTime()
        ResetByo_yomiTime()
        DuringByo_yomi = False
    End Sub
    Public Sub ResetByo_yomiTime()
        RemainByo_yomiTime = TotalByo_yomiTime
    End Sub

    Public Sub ResetHeldTime()
        RemainHeldTime = TotalHeldTime
    End Sub

    ''' <summary>
    ''' 持ち時間をデクリメントする。0未満になる場合は0にする。
    ''' </summary>
    Public Sub DecreaseHeldTime()
        RemainHeldTime = RemainHeldTime - 1
        If RemainHeldTime < 0 Then
            RemainHeldTime = 0
        Else
            ' Do nothing
        End If
    End Sub

    ''' <summary>
    ''' 秒読み時間をデクリメントする。0未満になる場合は0にする。
    ''' </summary>
    Public Sub DecreaseByo_yomiTime()
        RemainByo_yomiTime = RemainByo_yomiTime - 1
        If RemainByo_yomiTime <= 0 Then
            RemainByo_yomiTime = 0
        Else
            ' Do nothing
        End If
    End Sub

    Public Sub StartTimer()
        OwnTimer.Start()
    End Sub

    Public Sub StopTimer()
        OwnTimer.Stop()
    End Sub
End Class
