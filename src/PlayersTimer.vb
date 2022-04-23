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

    Private WithEvents _OwnTimer As Timer
    Public ReadOnly Property OwnTimer() As Timer
        Get
            Return _OwnTimer
        End Get
    End Property

    Public Sub New(ByVal name As String, ByVal heldTime As Integer, ByVal countdownTime As Integer)
        _Name = name

        _TotalHeldTime = heldTime
        _RemainHeldTime = heldTime

        _TotalByo_yomiTime = countdownTime
        _RemainByo_yomiTime = countdownTime

        _OwnTimer = New Timer
    End Sub

    Private Sub RaiseTickerEvent() Handles _OwnTimer.Tick
        RaiseEvent TickOwnTimer(Me, Nothing)
    End Sub

    Public Shared Event TickOwnTimer(ByVal sender As Object, ByVal e As EventArgs)

End Class
