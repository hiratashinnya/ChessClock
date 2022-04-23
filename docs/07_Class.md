<!---
システムのクラス図を描く
--->
# アプリケーション”ChessClock”のクラス図
| システムID | システム名称 |
| ------ | ------ |
|VB-pra01|ChessClock|

## クラス図
```plantuml
@startuml
skinparam groupInheritance 3

class Form{
  ハンデあり:checkbox
  秒読みあり:checkbox
  設定中:checkbox
  player1name:textbox
  player1の持ち時間:textbox
  player1の秒読み時間:textbox
  player2name:textbox
  player2の持ち時間:textbox
  player2の秒読み時間:textbox
  リセットボタン:button
  Doneボタン:button
  リセットボタンクリック()
  Doneボタンクリック()
  設定中変更()
  ハンデ有無変更()
  秒読み有無変更()
  持ち時間の更新イベントハンドラ()<-ChessClock.持ち時間更新イベント
  秒読み時間の更新イベントハンドラ()<-ChessClock.秒読み時間更新イベント
  時間切れイベントハンドラ()<-ChessClock.時間切れイベント
}

class ChessClock{
  +players:List<PlayersTimer>
  +秒読みあり:bool
  -currentPlayer:int
  +ハンデあり:bool
  +持ち時間更新イベント
  +秒読み時間更新イベント
  +時間切れイベント
  
  +プレイヤーを設定する(name:String, time1:int, time2:int):void
  +プレイヤーに手番を移す(nextID:int):void
  +一時停止する():void
  +リセットする():void
  +タイマー更新イベントハンドラ()<-PlayersTimer.タイマー更新イベント
}

class PlayersTimer{
  name:String
  総持ち時間:int
  総秒読み時間:int
  残持ち時間:int
  残秒読み時間:int
  owntimer:timer
  +{static}タイマー更新イベント
  -タイマー更新イベントの発火()<-owntimer.Tick
}

Form "1" --> "1" ChessClock
ChessClock "1" o-- "N" PlayersTimer
@enduml
```