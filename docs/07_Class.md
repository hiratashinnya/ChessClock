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
  持ち時間の更新イベントハンドラ()
  秒読み時間の更新イベントハンドラ()
  時間切れの更新イベントハンドラ()
}

class ChessClock{
  +players:List<Player>
  +秒読みあり:bool
  -currentPlayer:int
  +ハンデあり:bool
  +プレイヤーを設定する(name:String, time1:int, time2:int):void
  +次プレイヤーに手番を移す():void
  +一時停止する():void
  +リセットする():void
  +Timerイベントハンドラ():void
}

class Player{
  name:String
  総持ち時間:int
  総秒読み時間:int
  残持ち時間:int
  残秒読み時間:int
  owntimer:timer
}

Form "1" --> "1" ChessClock
ChessClock "1" o-- "N" Player
@enduml
```