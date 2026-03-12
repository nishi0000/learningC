# C# 入門編 - AI チェックプロンプト

> **使い方:** [checker_guide.md](checker_guide.md) を先に読んでください

---

## Station 1: 環境構築と Hello World

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて判定してください。

## クリア条件
- .NET SDK がインストールされ、dotnet --version でバージョンが表示されること
- dotnet new console でプロジェクトが作成されていること
- dotnet run で "Hello, World!" または変更後のメッセージが出力されること
- GitHub にリポジトリが作成されていること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」と理由を表示
- 改善のヒントも 1〜2 行で添える

## 確認対象
#file:Program.cs と #file:CSharpIntro.csproj を確認してください。
```

---

## Station 2: 変数とデータ型

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて判定してください。

## クリア条件
- int, double, string, bool の 4 つの型を使った変数宣言があること
- var を使った型推論の変数宣言があること
- Console.ReadLine() でユーザーからの入力を受け取っていること
- 文字列補間（$"..."）を使っていること
- int.Parse() または int.TryParse() で文字列を数値に変換していること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」と理由を表示
- 改善のヒントも 1〜2 行で添える

## 対象コード
@workspace のすべての .cs ファイルを確認してください。
```

---

## Station 3: 条件分岐

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて判定してください。

## クリア条件
- if / else if / else を使った条件分岐が書かれていること
- switch 文を使った条件分岐が書かれていること
- 比較演算子（==, !=, <, >, <=, >=）が使われていること
- 論理演算子（&&, ||, !）のうち少なくとも 1 つが使われていること
- 年齢判定プログラム（3 段階以上の分岐）があること
- 曜日判定プログラム（switch 文使用）があること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」と理由を表示
- 改善のヒントも 1〜2 行で添える

## 対象コード
@workspace のすべての .cs ファイルを確認してください。
```

---

## Station 4: ループ（繰り返し処理）

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて判定してください。

## クリア条件
- for ループを使って指定回数の繰り返しが書かれていること
- while ループを使って条件に基づく繰り返しが書かれていること
- foreach ループを使って配列の要素を処理していること
- break または continue を使ってループ制御が行われていること
- 九九の表、または同等の二重ループが書かれていること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」と理由を表示
- 改善のヒントも 1〜2 行で添える

## 対象コード
@workspace のすべての .cs ファイルを確認してください。
```

---

## Station 5: メソッド（関数）

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて判定してください。

## クリア条件
- 引数と戻り値のある static メソッド Add(int a, int b) が定義されていること
- 戻り値なし（void）の Greet メソッドが定義されていること
- Add メソッドのオーバーロード（引数 3 つ版）が定義されていること
- CalcTax メソッドにデフォルト引数（rate = 0.10）が設定されていること
- メソッドが public かつ static であり、テストから呼び出し可能であること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」と理由を表示
- コードの品質（命名規則、適切なアクセス修飾子）についてもコメント

## 対象コード
#file:Methods.cs を確認してください。
```

---

## Station 6: クラスとオブジェクト

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて判定してください。

## クリア条件
- Item クラスが定義され、Name (string) と Price (int) のプロパティを持つこと
- コンストラクタで Name と Price を受け取って初期化すること
- GetInfo() メソッドが「〇〇は△△円です」形式の文字列を返すこと
- Price の setter が private であること
- Item.cs が Models フォルダに分離されていること
- new キーワードでインスタンスを作成して使用していること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」と理由を表示
- OOP の観点からのアドバイスも添える

## 対象コード
#file:Models/Item.cs と #file:Program.cs を確認してください。
```

---

## Station 7: 配列とリスト

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて判定してください。

## クリア条件
- int[] 配列を使ってデータを格納・取り出ししていること
- List<T> を使って Add / Remove / Contains / Count を使った操作があること
- Dictionary<TKey, TValue> を使ってキーと値の管理があること
- foreach で配列やリストの全要素を処理していること
- CalcSum と CalcAverage が public static メソッドとして定義されていること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」と理由を表示

## 対象コード
@workspace のすべての .cs ファイルを確認してください。
```

---

## Station 8: 例外処理

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて判定してください。

## クリア条件
- try-catch で例外をキャッチしてエラーメッセージを表示するコードがあること
- finally ブロックが使われていること
- FormatException や DivideByZeroException など、特定の例外を個別にキャッチしていること
- throw で ArgumentException を投げるコードがあること
- SafeParseInt, SafeDivide, ValidateAmount メソッドが定義されていること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」と理由を表示
- 例外処理のベストプラクティスについてもコメント

## 対象コード
#file:ExceptionExercises.cs を確認してください。
```

---

## Station 9: ミニ家計簿アプリ（総合演習）

### AI チェックプロンプト

```
あなたは C# の学習チェッカーです。以下のクリア条件に基づいて、ミニ家計簿アプリを総合判定してください。

## クリア条件
- コンソールアプリとして動作すること
- Entry クラスが Models フォルダにあり、Date, Category, Amount, IsIncome プロパティを持つこと
- AccountBook クラスが AddEntry, GetAll, GetTotalIncome, GetTotalExpense, GetBalance, GetCategorySummary メソッドを持つこと
- メニュー表示（登録/一覧/集計/終了）がループで実装されていること
- 不正な入力に対する例外処理がされていること
- Station 1〜8 の知識（変数・条件分岐・ループ・メソッド・クラス・コレクション・例外処理）が使われていること

## 判定ルール
- すべて満たしていれば「✅ PASS」、不足があれば「❌ FAIL」と理由を表示
- コード全体の品質（命名・構造・可読性）についても A〜D で評価してコメント

## 対象コード
@workspace のすべての .cs ファイルを確認してください。
```

---

## 全 Station 一括 AI チェックプロンプト

```
あなたは C# の学習チェッカーです。C# 入門編（Station 1〜9）の全クリア条件を一括で判定してください。

## 一括チェック項目
- Station 1: プロジェクトが存在し、コンパイルが通ること
- Station 2: int, double, string, bool, var が使われていること
- Station 3: if/else/switch が使われていること
- Station 4: for/while/foreach/break か continue が使われていること
- Station 5: Methods クラスに Add, CalcTax メソッドがあること
- Station 6: Item クラスが Models フォルダにあること
- Station 7: CollectionExercises クラスに CalcSum, CalcAverage メソッドがあること
- Station 8: ExceptionExercises クラスに SafeParseInt, SafeDivide, ValidateAmount メソッドがあること
- Station 9: Entry クラスと AccountBook クラスがあり、家計簿が動作すること

## 判定ルール
- 各 Station ごとに「✅ PASS」「❌ FAIL」を表示
- 全体の進捗を「X / 9 PASS」で表示
- 不合格の Station には何が不足か簡潔に記載

## 対象
@workspace のすべての .cs ファイル
```
