# C# 基礎編

> **前提知識:** C# 入門編を完了していること
> **成果物:** 「タスク管理アプリ」をコンソールで作りながら OOP・LINQ・非同期処理を習得
> **判定方式:** AI チェックプロンプト（Copilot Chat） → [02_fundamentals_checks.md](02_fundamentals_checks.md)

---

## Station 1: 継承とポリモーフィズム

### クリア条件
- 基底クラスを作成し、それを継承した派生クラスを定義できること
- `virtual` / `override` を使って振る舞いを変更できること
- `base` キーワードで基底クラスのコンストラクタやメソッドを呼び出せること
- 基底クラス型の変数に派生クラスのインスタンスを格納して利用できること（ポリモーフィズム）

### 問題概要
オブジェクト指向の中核概念である「継承」と「ポリモーフィズム（多態性）」を学ぶ。共通の処理を基底クラスに持たせ、個別の処理を派生クラスで上書きすることで、コードの重複を減らし拡張性を高める。

**用語**
| 用語 | 説明 |
|---|---|
| 継承 | あるクラスの機能を引き継いで新しいクラスを作ること |
| 基底クラス（親クラス） | 継承元のクラス |
| 派生クラス（子クラス） | 継承先のクラス |
| `virtual` | 「上書きしてもいいよ」という印 |
| `override` | 「上書きするよ」という印 |
| ポリモーフィズム | 同じメソッド呼び出しで、実際のクラスに応じた振る舞いをすること |

### 確認テスト
1. `Animal` クラスを作成する（プロパティ: `Name`、メソッド: `virtual string Speak()`）
2. `Dog` クラスと `Cat` クラスを `Animal` から継承して作る
   - `Dog.Speak()` → 「ワン！」を返す
   - `Cat.Speak()` → 「ニャー！」を返す
3. `List<Animal>` に `Dog` と `Cat` を混ぜて入れ、`foreach` で全員の `Speak()` を呼び出す
4. `base` キーワードを使って、派生クラスのコンストラクタから基底クラスのコンストラクタを呼び出す

### 参考資料
- [C# の継承](https://learn.microsoft.com/ja-jp/dotnet/csharp/fundamentals/object-oriented/inheritance)
- [C# のポリモーフィズム](https://learn.microsoft.com/ja-jp/dotnet/csharp/fundamentals/object-oriented/polymorphism)

---

## Station 2: インターフェースと抽象クラス

### クリア条件
- `interface` を定義し、それを実装するクラスを作れること
- `abstract class` を定義し、派生クラスで抽象メソッドを実装できること
- インターフェースと抽象クラスの違いを説明できること

### 問題概要
「何ができるか」を定義するインターフェースと、「未完成の共通部品」を定義する抽象クラスを学ぶ。どちらも実務で非常によく使われる。

**インターフェース vs 抽象クラス**
| 項目 | インターフェース | 抽象クラス |
|---|---|---|
| 役割 | 「何ができるか」の契約 | 共通処理 + 未完成部分のテンプレート |
| メンバー | メソッドの署名のみ（既定の実装も可） | フィールド・実装済みメソッドも持てる |
| 多重継承 | 複数実装可能 | 1 つだけ継承可能 |

### 確認テスト
1. `IExportable` インターフェースを定義する（メソッド: `string Export()`）
2. `CsvExporter` と `JsonExporter` クラスを作り、それぞれ `IExportable` を実装する
3. `IExportable` 型の変数に各インスタンスを入れて、`Export()` を呼び出す
4. `Shape` 抽象クラスを作成する（抽象メソッド: `double CalcArea()`、プロパティ: `Name`）
5. `Circle` と `Rectangle` を `Shape` から派生させ、`CalcArea()` を実装する
6. `List<Shape>` に入れて面積を表示する

### 参考資料
- [C# のインターフェース](https://learn.microsoft.com/ja-jp/dotnet/csharp/fundamentals/types/interfaces)
- [C# の抽象クラス](https://learn.microsoft.com/ja-jp/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members)

---

## Station 3: ジェネリクス

### クリア条件
- `List<T>` や `Dictionary<TKey, TValue>` などジェネリックコレクションの `<T>` の意味を理解していること
- 自分でジェネリクスを使ったクラスまたはメソッドを定義できること
- 型制約（`where T : ...`）を使えること

### 問題概要
`<T>` で「型を後から指定できる」ジェネリクスを学ぶ。`List<int>` や `List<string>` の `<T>` の仕組みを理解し、自分で汎用的なクラスやメソッドを作れるようにする。

### 確認テスト
1. 任意の型の値を 2 つ受け取って入れ替える `Swap<T>(ref T a, ref T b)` ジェネリックメソッドを作る
2. `int` と `string` の両方で `Swap` を呼び出して動作を確認する
3. `Repository<T>` ジェネリッククラスを作る
   - `List<T>` を内部に持ち、`Add(T item)`, `GetAll()`, `GetById(int index)` メソッドを持つ
4. `where T : class` の型制約を付けて、値型（`int` など）を入れるとコンパイルエラーになることを確認する

### 参考資料
- [C# のジェネリクス](https://learn.microsoft.com/ja-jp/dotnet/csharp/fundamentals/types/generics)

---

## Station 4: LINQ

### クリア条件
- LINQ のメソッド構文を使ってコレクションの絞り込み・変換・集計ができること
- `Where`, `Select`, `OrderBy`, `GroupBy`, `First`, `Any`, `Count`, `Sum` を使えること
- `foreach` で書いていた処理を LINQ で書き直せること

### 問題概要
LINQ（Language Integrated Query）は、コレクションに対してデータベースの SQL のような操作を行う C# の強力な機能。実務のコードで最もよく見かける機能の 1 つ。

**主要な LINQ メソッド**
| メソッド | 説明 | SQL との対応 |
|---|---|---|
| `Where(x => ...)` | 条件で絞り込み | `WHERE` |
| `Select(x => ...)` | 変換・射影 | `SELECT` |
| `OrderBy(x => ...)` | 並べ替え | `ORDER BY` |
| `GroupBy(x => ...)` | グループ化 | `GROUP BY` |
| `First()` / `FirstOrDefault()` | 最初の要素 | `TOP 1` |
| `Any(x => ...)` | 1 件でもあるか | `EXISTS` |
| `Count()` | 件数 | `COUNT` |
| `Sum(x => ...)` | 合計 | `SUM` |

### 確認テスト
1. `List<int>` から偶数だけを `Where` で抽出する
2. `List<string>` から文字数が 3 以上のものを抽出し、大文字に変換して表示する（`Where` + `Select`）
3. 商品リスト（`List<Product>`）に対して以下を行う
   - 価格が 1000 円以上の商品だけ抽出する
   - 価格の降順で並べ替える
   - カテゴリ別にグループ化し、各カテゴリの合計金額を求める
4. 入門編の家計簿アプリのカテゴリ別集計を LINQ で書き直す

### 参考資料
- [C# の LINQ](https://learn.microsoft.com/ja-jp/dotnet/csharp/linq/)

---

## Station 5: 非同期処理（async / await）

### クリア条件
- `async` / `await` を使った非同期メソッドが書けること
- `Task` と `Task<T>` の違いを理解していること
- `HttpClient` を使って Web API を呼び出し、レスポンスを取得できること
- なぜ非同期処理が必要なのかを説明できること

### 問題概要
時間がかかる処理（API 呼び出し、ファイル読み書きなど）を「待っている間に他の処理を進められる」ようにする仕組みが非同期処理。C# では `async` / `await` で簡潔に書ける。

**同期 vs 非同期**
| 方式 | 動作 |
|---|---|
| 同期処理 | 処理が終わるまで次に進めない（画面がフリーズする原因） |
| 非同期処理 | 処理が終わるのを待つ間、他のことができる |

### 確認テスト
1. `Task.Delay(3000)` を使い、3 秒待つ非同期メソッドを作成する
2. `await` の有無で実行順序がどう変わるか確認する
3. `HttpClient` を使って以下の API を呼び出し、結果をコンソールに表示する
   - 天気 API 例: `https://api.open-meteo.com/v1/forecast?latitude=35.68&longitude=139.77&current_weather=true`
4. 取得した JSON を `System.Text.Json` でデシリアライズする
5. `Task<T>` の戻り値を持つ非同期メソッドを作成する

### 参考資料
- [C# の非同期プログラミング](https://learn.microsoft.com/ja-jp/dotnet/csharp/asynchronous-programming/)
- [HttpClient の使用](https://learn.microsoft.com/ja-jp/dotnet/fundamentals/networking/http/httpclient)

---

## Station 6: ファイル I/O と JSON 操作

### クリア条件
- `File.WriteAllText` / `File.ReadAllText` でテキストファイルの読み書きができること
- `System.Text.Json` を使ってオブジェクトを JSON にシリアライズ / デシリアライズできること
- アプリのデータを JSON ファイルに永続化できること

### 問題概要
プログラムのデータをファイルに保存し、次回起動時に読み込む方法を学ぶ。JSON は Web 開発での標準的なデータ形式。

### 確認テスト
1. 文字列をテキストファイルに書き出して、読み込み直す
2. `Product` クラスのインスタンスを `JsonSerializer.Serialize()` で JSON 文字列に変換する
3. JSON 文字列を `JsonSerializer.Deserialize<Product>()` でオブジェクトに戻す
4. `List<Product>` を JSON ファイルに保存し、起動時に読み込む処理を実装する
5. 入門編の家計簿アプリのデータを JSON ファイルに保存・読み込みできるように改良する

### 参考資料
- [C# のファイル操作](https://learn.microsoft.com/ja-jp/dotnet/csharp/programming-guide/file-system/)
- [System.Text.Json](https://learn.microsoft.com/ja-jp/dotnet/standard/serialization/system-text-json/overview)

---

## Station 7: Null 安全とモダン C# の機能

### クリア条件
- Null 許容参照型（`string?`）を理解し、プロジェクトで有効化できること
- `??`（null 合体演算子）と `?.`（null 条件演算子）を使えること
- パターンマッチング（`is`, `switch` 式）を使えること
- レコード型（`record`）を定義して使えること

### 問題概要
C# 8 以降のモダンな機能を学ぶ。これらは最新のコードで頻繁に使われ、バグを減らし短く読みやすいコードを書くために重要。

**モダン C# の主な新機能**
| 機能 | バージョン | 説明 |
|---|---|---|
| Null 許容参照型 | C# 8 | `null` に起因するバグを防ぐ |
| パターンマッチング | C# 8〜 | 型や値に応じた分岐をよりシンプルに |
| レコード型 | C# 9 | データの入れ物を簡潔に定義 |
| `switch` 式 | C# 8 | `switch` を式として書ける |
| ファイルスコープ名前空間 | C# 10 | `namespace Xxx;` で波括弧を省略 |
| `required` プロパティ | C# 11 | 初期化を強制するプロパティ |

### 確認テスト
1. プロジェクトの Null 許容参照型を有効化（`.csproj` で `<Nullable>enable</Nullable>`）し、警告を確認する
2. `string?` の変数を定義し、`??` と `?.` を使って安全にアクセスする
3. `switch` 式を使って曜日に応じたメッセージを返すメソッドを作る
4. `record` 型で `Person(string Name, int Age)` を定義し、`with` 式でコピーを作る
5. Station 6 のコードをモダン機能でリファクタリングする

### 参考資料
- [Null 許容参照型](https://learn.microsoft.com/ja-jp/dotnet/csharp/nullable-references)
- [パターンマッチング](https://learn.microsoft.com/ja-jp/dotnet/csharp/fundamentals/functional/pattern-matching)
- [レコード型](https://learn.microsoft.com/ja-jp/dotnet/csharp/language-reference/builtin-types/record)

---

## Station 8: タスク管理アプリの作成（総合演習）

### クリア条件
- コンソールで動作する「タスク管理アプリ」が完成していること
- 基礎編で学んだ知識（OOP・LINQ・非同期・JSON・モダン機能）が活用されていること
- データが JSON ファイルに永続化されること
- GitHub にプッシュされていること

### 問題概要
基礎編の総まとめとして、タスク管理アプリを作る。

**要件**

| 機能 | 使う知識 |
|---|---|
| タスクの登録・一覧・完了・削除 | クラス・`List<T>`・LINQ |
| タスクの優先度（高/中/低） | 列挙型（`enum`）・パターンマッチング |
| 期限日の設定と残り日数の表示 | `DateTime` |
| データの永続化 | JSON ファイル I/O |
| 天気情報の取得（オプション） | `HttpClient`・async/await |
| インターフェースを使った設計 | `ITaskRepository` インターフェース |

### 確認テスト
1. `TodoItem` レコード型を定義する（`Title`, `Priority`, `DueDate`, `IsCompleted`）
2. `Priority` を `enum`（`High`, `Medium`, `Low`）で定義する
3. `ITaskRepository` インターフェースを定義し、JSON ファイルに保存する実装クラスを作る
4. メニュー: タスク追加 / 一覧表示 / 完了にする / 削除 / 終了
5. 一覧表示では LINQ を使って未完了タスクを優先度順に表示する
6. 期限の残り日数を表示する（期限切れは赤文字でも可）
7. データが JSON に保存され、再起動しても残ることを確認する
8. GitHub にプッシュする
