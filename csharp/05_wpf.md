# WPF デスクトップアプリ入門編

> **前提知識:** C# 基礎編を完了していること
> **成果物:** 「TODO デスクトップアプリ」を段階的に作りながら WPF・MVVM を習得
> **判定方式:** セルフチェック
> **推奨エディタ:** Visual Studio 2022（WPF のデザイナー機能があるため圧倒的に便利）

---

## Station 1: WPF プロジェクト作成と最初のウィンドウ

### クリア条件
- WPF プロジェクトを作成し、ウィンドウが表示されること
- XAML ファイルを編集してウィンドウのタイトル・サイズを変更できること
- ボタンとテキストブロックを配置し、画面に表示されること

### 問題概要
WPF（Windows Presentation Foundation）は Windows デスクトップアプリを作るためのフレームワーク。画面のレイアウトを XAML（ザムル）という XML ベースの言語で記述し、動作を C# で記述する。

**WPF の特徴**
| 特徴 | 説明 |
|---|---|
| XAML | UI を XML ベースで記述する |
| データバインディング | UI とデータを自動的に同期する |
| MVVM パターン | UI とロジックを分離する設計パターン |
| リッチな UI | アニメーション・3D・カスタムコントロールに対応 |

### 確認テスト
1. Visual Studio で「WPF アプリケーション」プロジェクトを作成する（.NET 8）
2. `F5` でビルド・実行し、空のウィンドウが表示されることを確認する
3. `MainWindow.xaml` を開き、`Title` を変更する
4. `Width` と `Height` を変更してウィンドウサイズを調整する
5. `Button` と `TextBlock` を XAML で配置する
6. GitHub にプッシュする

### 参考資料
- [WPF 入門](https://learn.microsoft.com/ja-jp/dotnet/desktop/wpf/overview/)
- [XAML の概要](https://learn.microsoft.com/ja-jp/dotnet/desktop/wpf/xaml/)

---

## Station 2: XAML レイアウトとコントロール

### クリア条件
- `StackPanel`, `Grid`, `DockPanel` を使ってレイアウトを組めること
- `TextBox`, `Button`, `CheckBox`, `ListBox` などの標準コントロールを配置できること
- イベントハンドラーでボタンクリック時の処理を書けること

### 問題概要
XAML のレイアウトパネルと標準コントロールを使い、実用的な画面を作る方法を学ぶ。

**主要なレイアウトパネル**
| パネル | 特徴 |
|---|---|
| `StackPanel` | 要素を縦または横に並べる |
| `Grid` | 行と列でセルに配置する（最も柔軟） |
| `DockPanel` | 上下左右に要素をドッキングする |
| `WrapPanel` | 折り返しながら並べる |

**主要なコントロール**
| コントロール | 用途 |
|---|---|
| `TextBlock` | テキスト表示（読み取り専用） |
| `TextBox` | テキスト入力 |
| `Button` | ボタン |
| `CheckBox` | チェックボックス |
| `ListBox` | リスト表示 |
| `ComboBox` | ドロップダウンリスト |

### 確認テスト
1. `Grid` を使ってヘッダー・メインエリア・フッターの 3 行レイアウトを作る
2. ヘッダーにアプリ名を `TextBlock` で表示する
3. メインエリアに `TextBox`（TODO 入力欄）と「追加」ボタンを横並びで配置する
4. メインエリアに `ListBox`（TODO リスト表示用）を配置する
5. 「追加」ボタンのクリックイベント（`Click`）をコードビハインドで処理し、`ListBox` にアイテムを追加する
6. `TextBox` が空の場合は追加しない（バリデーション）

### 参考資料
- [WPF のレイアウトパネル](https://learn.microsoft.com/ja-jp/dotnet/desktop/wpf/controls/panels-overview)

---

## Station 3: データバインディング

### クリア条件
- `{Binding}` 構文を使って XAML とプロパティを連携できること
- `INotifyPropertyChanged` を実装し、プロパティ変更時に UI が自動更新されること
- `ObservableCollection<T>` を使ってリストの変更が UI に自動反映されること

### 問題概要
WPF の最重要機能「データバインディング」を学ぶ。UI（XAML）とデータ（C#）を直接結びつけることで、手動で UI を更新するコードが不要になる。

**データバインディングの仕組み**
```
XAML: <TextBlock Text="{Binding UserName}" />
  ↕ 自動同期
C#:   public string UserName { get; set; } = "Nishimura";
```

**UI 更新に必要な仕組み**
| 対象 | 使うもの |
|---|---|
| 単一のプロパティ | `INotifyPropertyChanged` |
| コレクション（リスト） | `ObservableCollection<T>` |

### 確認テスト
1. `MainWindow` の `DataContext` に自身を設定する
2. `string` プロパティを作り、`TextBlock` に `{Binding}` で表示する
3. `INotifyPropertyChanged` を実装し、プロパティ変更時に UI が更新されることを確認する
4. `ObservableCollection<string>` を作成し、`ListBox` の `ItemsSource` にバインドする
5. Station 2 の「追加」ボタンの処理を、コードビハインドでの直接操作から `ObservableCollection.Add()` に変更する

### 参考資料
- [データバインディングの概要](https://learn.microsoft.com/ja-jp/dotnet/desktop/wpf/data/data-binding-overview)
- [INotifyPropertyChanged](https://learn.microsoft.com/ja-jp/dotnet/api/system.componentmodel.inotifypropertychanged)

---

## Station 4: MVVM パターン

### クリア条件
- Model・View・ViewModel の役割を理解し説明できること
- `ViewModel` クラスを作成し、`View`（XAML）から分離できること
- コードビハインド（`MainWindow.xaml.cs`）にビジネスロジックがないこと
- `ICommand` を使ってボタン操作を ViewModel で処理できること

### 問題概要
WPF 開発の標準設計パターン「MVVM（Model-View-ViewModel）」を学ぶ。UI とロジックを完全に分離することで、テストしやすく保守しやすいコードになる。

**MVVM の構成**
| 層 | 役割 | 例 |
|---|---|---|
| **Model** | データ・ビジネスロジック | `TodoItem` クラス |
| **View** | 画面（XAML） | `MainWindow.xaml` |
| **ViewModel** | View と Model の仲介 | `MainViewModel` |

**イメージ**
```
View（XAML）←→ ViewModel（C#） ←→ Model（C#）
  表示・入力      データ変換・コマンド    データ・保存
```

### 確認テスト
1. `Models/TodoItem.cs` を作成する（`Title`, `IsCompleted`）
2. `ViewModels/MainViewModel.cs` を作成する
   - `ObservableCollection<TodoItem> Todos` プロパティ
   - `string NewTodoTitle` プロパティ
   - `ICommand AddCommand` プロパティ
3. `RelayCommand`（または `DelegateCommand`）クラスを作成し、`ICommand` を実装する
4. `MainWindow.xaml` の `DataContext` に `MainViewModel` を設定する
5. ボタンの `Command` に `{Binding AddCommand}` を設定する
6. コードビハインド（`MainWindow.xaml.cs`）には `InitializeComponent()` 以外のコードがないことを確認する

### 参考資料
- [MVVM パターン](https://learn.microsoft.com/ja-jp/dotnet/architecture/maui/mvvm)
- [コマンド](https://learn.microsoft.com/ja-jp/dotnet/desktop/wpf/advanced/commanding-overview)

---

## Station 5: スタイルとテンプレート

### クリア条件
- `Style` を使ってコントロールの見た目をカスタマイズできること
- `DataTemplate` を使ってリスト項目の表示をカスタマイズできること
- `ResourceDictionary` で共通スタイルを定義できること

### 問題概要
WPF のスタイルとテンプレート機能を使い、アプリの見た目を整える。HTML/CSS の関係に似た仕組み。

**CSS との比較**
| WPF | CSS | 説明 |
|---|---|---|
| `Style` | クラスセレクタ（`.class`） | コントロールのプロパティ一括設定 |
| `DataTemplate` | コンポーネントの `render` | リスト項目の表示方法の定義 |
| `ResourceDictionary` | 外部 CSS ファイル | スタイルを別ファイルに分離 |

### 確認テスト
1. ボタンに `Style` を適用し、色・フォントサイズ・角丸を変更する
2. `ListBox` に `DataTemplate` を設定し、TODO のタイトルとチェックボックスを横並びで表示する
3. `Resources/Styles.xaml` に `ResourceDictionary` を作成し、共通スタイルを定義する
4. `App.xaml` で `ResourceDictionary` を読み込む
5. 完了済みの TODO はグレーで表示するスタイルをトリガーで実装する

### 参考資料
- [WPF のスタイル](https://learn.microsoft.com/ja-jp/dotnet/desktop/wpf/controls/styles-templates-overview)

---

## Station 6: TODO デスクトップアプリの完成（総合演習）

### クリア条件
- MVVM パターンで実装された TODO デスクトップアプリが完成していること
- TODO の追加・完了・削除・編集ができること
- データが JSON ファイルに永続化されること
- 見た目がスタイル/テンプレートで整えられていること
- GitHub にプッシュされていること

### 問題概要
WPF 入門編の総まとめとして、TODO デスクトップアプリを完成させる。

**要件**

| 機能 | 使う知識 |
|---|---|
| TODO の追加 | MVVM・Command・データバインディング |
| TODO の一覧表示 | ObservableCollection・DataTemplate |
| TODO の完了チェック | CheckBox バインディング |
| TODO の削除 | Command +パラメータ |
| TODO の編集 | ダイアログ or インライン編集 |
| データ永続化 | JSON ファイル I/O（基礎編の知識） |
| 見た目の装飾 | Style・DataTemplate・ResourceDictionary |

### 確認テスト
1. TODO の追加ができる（空文字は追加不可）
2. TODO のリスト表示ができる（完了/未完了がチェックボックスで切り替え可能）
3. TODO の削除ができる
4. TODO の編集ができる（タイトルの修正）
5. アプリ終了時に JSON ファイルにデータが保存される
6. アプリ起動時に JSON ファイルからデータが読み込まれる
7. スタイルが適用されて見た目が整っている
8. コードビハインドにビジネスロジックが書かれていない（MVVM を守っている）
9. GitHub にプッシュする
10. **(挑戦課題)** 入門編で作った掲示板 API と連携し、TODO をサーバーに保存する
