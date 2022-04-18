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
  ハンデあり
  秒読みあり
  設定中
  player1name
  player1の持ち時間
  player1の秒読み時間
  player2name
  player2の持ち時間
  player2の秒読み時間
  リセットボタン
  Doneボタン
  リセットボタンクリック()
  Doneボタンクリック()
  設定中変更()
  ハンデ有無変更()
  秒読み有無変更()
  持ち時間の更新イベントハンドラ()
  秒読み時間の更新イベントハンドラ()
  時間切れの更新イベントハンドラ()
}
Abstract AbstractChessClock<<mustInherit>>{
  players:List<Player>
  秒読みあり
  {abstract}プレイヤーを設定する(name:String, time1:int, time2:int)
  {abstract}次プレイヤーに手番を移す()
  {abstract}一時停止する()
  {abstract}リセットする()
  {abstract}持ち時間の更新イベントハンドラ()
  {abstract}秒読み時間の更新イベントハンドラ()
  {abstract}時間切れの更新イベントハンドラ()
}

class ChessClock{
  ハンデあり
  プレイヤーを設定する(name:String, time1:int, time2:int)
  次プレイヤーに手番を移す()
  一時停止する()
  リセットする()
  持ち時間の更新イベントハンドラ()
  秒読み時間の更新イベントハンドラ()
  時間切れの更新イベントハンドラ()
}

class Player{
  name:String
  総持ち時間:int
  総秒読み時間:int
  残持ち時間:int
  残秒読み時間:int
  owntimer:timer
}

Form "1" <-- "1" ChessClock
Form ..> AbstractChessClock
AbstractChessClock <|- ChessClock
AbstractChessClock "1" o-- "N" Player
@enduml
```