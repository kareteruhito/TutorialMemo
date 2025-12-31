# TutorialMemo

TutorialMemo は、  
**WPF / C# による「MVVM 構成」の最小実装サンプル**です。

単なるメモ帳ですが、

- ViewModel 主導
- Command による操作
- バリデーションと状態管理


---

## 特徴

- WPF (.NET 8 / C#)
- 完全 MVVM 構成
- Command ベースの操作
- ViewModel 主導の永続化・バリデーション
- 固定ファイルへの自動保存
- ログ出力対応

---

## アプリの挙動

- 起動時
  - 前回保存したテキストを自動読み込み
- 編集
  - TextBox への入力は即 ViewModel に反映
  - 入力内容に応じてリアルタイムにバリデーション
- 保存
  - Save ボタンから明示的に保存
  - 無効な状態では保存不可（Command.CanExecute）
- 終了
  - 明示的な保存操作のみ（自動保存なし）

---

## ディレクトリ構成

TutorialMemo/
├─ Domain/ // 業務ルール・意味
│ ├─ Models/
│ │ └─ MemoDocument.cs
│ ├─ Policies/
│ │ └─ TextRequiredPolicy.cs
│ └─ Validation/
│ └─ TextValidationResult.cs
│
├─ Infrastructure/ // 外部依存
│ ├─ Config/
│ │ └─ AppPaths.cs
│ ├─ Logging/
│ │ └─ AppLogger.cs
│ └─ Storage/
│ └─ FixedFileStorage.cs
│
├─ Application/ // MVVM 中心
│ ├─ Commands/
│ │ └─ RelayCommand.cs
│ └─ ViewModels/
│ └─ MainViewModel.cs
│
├─ UI/ // View
│ ├─ MainWindow.xaml
│ └─ MainWindow.xaml.cs
│
├─ App.xaml
└─ App.xaml.cs


---

## 設計方針

### MVVM に振り切る

このプロジェクトでは、以下を分離しています。

| 役割 | 担当 |
|---|---|
| 状態管理 | ViewModel |
| バリデーション | ViewModel + Domain Policy |
| 永続化 | ViewModel → Infrastructure |
| UI | View のみ |

---

## バリデーションについて

- バリデーションは ViewModel が主導します
- Domain の Policy は「判断」だけを返します
- UI 側に if 文は存在しません

### 入力ルール
- テキストは **1文字以上必須**

---

## UpdateSourceTrigger について（重要）

TextBox には以下を採用しています。

```xml
UpdateSourceTrigger=PropertyChanged
