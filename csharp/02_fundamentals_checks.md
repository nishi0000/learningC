# C# 基礎編 - AI チェックプロンプト

> **使い方:** [checker_guide.md](checker_guide.md) を先に読んでください

---

## Station 1: 継承とポリモーフィズム

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて判定してください。

## クリア条件
- Animal 基底クラスが定義され、Name プロパティと virtual Speak() メソッドを持つこと
- Dog と Cat が Animal を継承し、Speak() を override していること
- base キーワードでコンストラクタを呼び出していること
- List<Animal> で Dog と Cat を混在させ、foreach で Speak() を呼んでいること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」と理由を表示
- OOP 設計の観点からアドバイスも添える

## 対象コード
#file:Models/Animal.cs #file:Models/Dog.cs #file:Models/Cat.cs #file:Program.cs を確認してください。
```

---

## Station 2: インターフェースと抽象クラス

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて判定してください。

## クリア条件
- IExportable インターフェースが定義され、Export() メソッドを持つこと
- CsvExporter と JsonExporter が IExportable を実装していること
- Shape 抽象クラスが定義され、CalcArea() 抽象メソッドを持つこと
- Circle と Rectangle が Shape を継承し、CalcArea() を実装していること
- インターフェースと抽象クラスの違いが使い分けられていること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」
- 設計方針のアドバイスも添える

## 対象コード
@workspace のすべての .cs ファイルを確認してください。
```

---

## Station 3: ジェネリクス

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて判定してください。

## クリア条件
- Swap<T>(ref T a, ref T b) ジェネリックメソッドが定義されていること
- int と string の両方で Swap を使用していること
- Repository<T> クラスが定義され、Add, GetAll, GetById メソッドを持つこと
- where T : class の型制約が Repository<T> に付いていること
- ジェネリクスの <T> の意味を正しく理解して使えていること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」
- 型安全性の観点からコメント

## 対象コード
#file:GenericExercises.cs #file:Repository.cs を確認してください。
```

---

## Station 4: LINQ

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて判定してください。

## クリア条件
- Where で条件による絞り込みが実装されていること
- Select で変換処理が実装されていること
- OrderBy / OrderByDescending で並べ替えが実装されていること
- GroupBy でカテゴリ別グループ化と Sum で集計が実装されていること
- Any, Count, Sum, First/FirstOrDefault のうち 3 つ以上使われていること
- foreach ではなく LINQ メソッド構文が使われていること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」
- LINQ チェーンの可読性についてもコメント

## 対象コード
#file:LinqExercises.cs #file:Models/Product.cs を確認してください。
```

---

## Station 5: 非同期処理（async / await）

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて判定してください。

## クリア条件
- async / await を使った非同期メソッドが定義されていること
- Task と Task<T> の両方が使われていること
- HttpClient を使って外部 API を呼び出していること
- await の使い方が正しいこと（.Result や .Wait() を使っていないこと）
- using または IDisposable の扱いが適切であること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」
- HttpClient の生成方法（new vs DI vs IHttpClientFactory）についてアドバイス

## 対象コード
#file:AsyncExercises.cs #file:Program.cs を確認してください。
```

---

## Station 6: ファイル I/O と JSON 操作

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて判定してください。

## クリア条件
- File.WriteAllText / File.ReadAllText でテキストファイルの読み書きができること
- JsonSerializer.Serialize でオブジェクトを JSON に変換できること
- JsonSerializer.Deserialize でJSON からオブジェクトに戻せること
- List<T> を JSON ファイルに保存し、読み込み直せること
- System.Text.Json を使っていること（Newtonsoft.Json ではなく）

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」
- JsonSerializerOptions の使用やエラーハンドリングについてもコメント

## 対象コード
#file:JsonExercises.cs を確認してください。
```

---

## Station 7: Null 安全とモダン C# の機能

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて判定してください。

## クリア条件
- .csproj で <Nullable>enable</Nullable> が設定されていること
- ?? (null 合体演算子)を使用していること
- ?. (null 条件演算子)を使用していること
- switch 式（=> を使ったパターンマッチング形式）を使用していること
- record 型で PersonRecord を定義し、with 式を使用していること
- ファイルスコープ名前空間 (namespace Xxx;) を使用していること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」
- モダン C# の活用度を A〜D で評価

## 対象コード
@workspace のすべての .cs ファイルと .csproj ファイルを確認してください。
```

---

## Station 8: タスク管理アプリの作成（総合演習）

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて、タスク管理アプリを総合判定してください。

## クリア条件
- コンソールアプリとして動作すること
- TodoItem が record 型で定義され、Id, Title, Priority, DueDate, IsCompleted を持つこと
- Priority が enum(High, Medium, Low)で定義されていること
- ITaskRepository インターフェースを定義し、JsonTaskRepository で実装していること
- メニュー（追加/一覧/完了/削除/終了）がループ実装されていること
- LINQ で未完了タスクの絞り込み・優先度順表示が実装されていること
- データが JSON ファイルに永続化されること
- 基礎編の知識（継承/インターフェース/ジェネリクス/LINQ/async-await/JSON/モダンC#）のうち 5 つ以上が活用されていること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」
- コード全体の設計（SOLID 原則の適用度）を A〜D で評価
- GitHub にプッシュされていること確認を促す

## 対象コード
@workspace のすべての .cs ファイルを確認してください。
```

---

## 全 Station 一括 AI チェックプロンプト

```
あなたは C# の学習チェッカーです。C# 基礎編（Station 1〜8）の全クリア条件を一括で判定してください。

## 一括チェック項目
- Station 1: Animal/Dog/Cat クラスがあり、継承・ポリモーフィズムが実装されていること
- Station 2: IExportable インターフェースと Shape 抽象クラスが定義されていること
- Station 3: Swap<T> メソッドと Repository<T> クラス（where T : class）が定義されていること
- Station 4: LinqExercises に Where/Select/OrderBy/GroupBy/Sum/Any を使ったメソッドがあること
- Station 5: async/await メソッドと HttpClient による API 呼び出しがあること
- Station 6: JsonExercises に Serialize/Deserialize/SaveToJson/LoadFromJson があること
- Station 7: record 型、??, ?., switch 式が使われていること
- Station 8: TodoItem record, Priority enum, ITaskRepository + JsonTaskRepository があり、JSON 永続化されること

## 判定ルール
- 各 Station ごとに「✅ PASS」「❌ FAIL」を表示
- 全体の進捗を「X / 8 PASS」で表示
- 不合格の Station には何が不足か簡潔に記載
- 全 PASS の場合は「🎉 基礎編クリアおめでとうございます！」を表示

## 対象
@workspace のすべての .cs ファイル
```
