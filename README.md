# TutorialMemo

TutorialMemo は、  
**「MVVM + DDD 風味」** の構成を持つ、  
**動作確認可能なチュートリアル版・簡易メモ帳アプリ**です。

厳密な MVVM や DDD を強制するものではなく、  
**必要になった部分だけを使える“雛形”**として設計されています。

---

## 特徴

- WPF (.NET / C#)
- 単一テキストを編集・保存する簡易メモ帳
- 保存先ファイル名は固定
- 起動時に前回の内容を自動読み込み
- 終了時に自動保存（入力必須）
- ログ出力あり（UI + Debug）

---

## アプリの挙動

1. 起動時  
   - 固定ファイル（`%AppData%/TutorialMemo/memo.txt`）を読み込み、表示します
2. 編集  
   - TextBox に自由に入力できます
3. 終了時  
   - テキストが **1文字以上** の場合のみ保存します  
   - 入力が空の場合は保存せず終了します（前回内容は保持されます）

---

## ディレクトリ構成

TutorialMemo/
├─ Domain/ // 意味・判断
│ ├─ Models/ // 状態（POCO）
│ ├─ Policies/ // if文の置き場
│ └─ Validation/ // バリデーション結果
│
├─ Infrastructure/ // ライブラリ・外部連携
│ ├─ Storage/ // ファイルIO
│ ├─ Config/ // パス・環境依存
│ └─ Logging/ // ログ出力
│
├─ Application/ // つなぎ役
│ └─ ViewModels/
│
├─ UI/ // WPF View / Code-behind
│
├─ AppContext.cs // static なアプリ文脈
└─ App.xaml / MainWindow.xaml

---

## 設計方針

### このプロジェクトは以下を目的としています

- WPFアプリのチュートリアル
- 改造・削除・無視がしやすい

### このプロジェクトが **やらないこと**

- Repository / Service / UnitOfWork の強制
- DI コンテナの導入
- 厳密な MVVM 実装
- DDD の完全適用

---

## 各レイヤの役割

### Domain
- アプリの「意味」や「判断」を置く場所
- Model は POCO / DTO 的で最小構成
- Policy は if 文の集約先

### Infrastructure
- ファイル・ログ・設定など
- ライブラリ呼び出しを集約
- 判断は持たない

### UI / Application
- いつ・どの順で呼ぶかを決める

---

## バリデーションについて

- 「1文字以上入力必須」というルールは  
  `Domain/Policies` に定義されています
- UI 側は **いつバリデーションを呼ぶか** だけを決めます

---

## ログについて

- 起動 / 読み込み / 保存 / エラー をログ出力します
- ログは以下に出力されます
  - 画面下部のログビュー
  - Debug 出力（Visual Studio）

---

## プロジェクト名の変更について


### 推奨手順（手動）

1. フォルダ名を変更
2. `.sln` / `.csproj` の名前を変更
3. Visual Studio で開き直す
4. namespace を一括置換

---


## ライセンス

このプロジェクトは Apache License 2.0 のもとで公開されています。

- 商用利用可
- 改造・再配布可
- 私的利用可

著作権表示およびライセンス文を保持する限り、  
自由に改造・再利用してください。