# ASP.NET Core Web API 入門編

> **前提知識:** C# 基礎編を完了していること
> **成果物:** 「掲示板 API」を段階的に構築しながら Web API 開発を習得
> **判定方式:** セルフチェック（Swagger / curl / Postman で動作確認）

---

## Station 1: 最初の Web API プロジェクト

### クリア条件
- `dotnet new webapi` で Web API プロジェクトを作成し、起動できること
- Swagger UI (`/swagger`) にアクセスして API を試せること
- `WeatherForecast` の GET エンドポイントにリクエストを送り、JSON レスポンスを受け取れること
- プロジェクトを GitHub にプッシュできていること

### 問題概要
ASP.NET Core で Web API プロジェクトを作成し、自動生成されるサンプル API の仕組みを理解する。

**Web API とは**
- Web 経由でデータをやり取りする仕組み
- フロントエンド（React など）やモバイルアプリからデータを取得・送信するために使う
- データは主に JSON 形式でやり取りする
- React 入門編で `fetch` を使って Dog API を呼んだあの「API」をサーバー側で作る

**プロジェクト構成**
| ファイル | 役割 |
|---|---|
| `Program.cs` | アプリの起動設定・ミドルウェア登録 |
| `Controllers/` | API のエンドポイントを定義するフォルダ |
| `appsettings.json` | 設定ファイル（DB 接続文字列など） |
| `*.csproj` | プロジェクトの設定（NuGet パッケージなど） |

### 確認テスト
1. `dotnet new webapi -n BoardApi` でプロジェクトを作成する
2. `dotnet run` で起動し、Swagger UI にアクセスする
3. Swagger UI から `GET /WeatherForecast` を試す
4. ブラウザや `curl` でも同じ結果が返ることを確認する
5. `Program.cs` を読み、各行の役割をコメントで書く
6. GitHub にプッシュする

### 参考資料
- [ASP.NET Core Web API のチュートリアル](https://learn.microsoft.com/ja-jp/aspnet/core/tutorials/first-web-api)
- [Swagger / OpenAPI](https://learn.microsoft.com/ja-jp/aspnet/core/tutorials/web-api-help-pages-using-swagger)

---

## Station 2: コントローラーとルーティング

### クリア条件
- 自分で Controller クラスを作成し、API エンドポイントを定義できること
- `[HttpGet]`, `[HttpPost]` などの属性でルーティングを指定できること
- URL パラメータ（`[FromRoute]`）とクエリパラメータ（`[FromQuery]`）を受け取れること
- 適切な HTTP ステータスコード（200, 201, 404 など）を返せること

### 問題概要
API の「入り口」であるコントローラーとルーティングの仕組みを学ぶ。リクエストの URL に応じて適切なメソッドが呼ばれる仕組みを理解する。

**HTTP メソッドと CRUD の対応**
| HTTP メソッド | 操作 | 例 |
|---|---|---|
| `GET` | 取得（読み取り） | スレッド一覧を取得 |
| `POST` | 作成 | 新しいスレッドを作成 |
| `PUT` | 更新（全体） | スレッド情報を更新 |
| `DELETE` | 削除 | スレッドを削除 |

### 確認テスト
1. `ThreadsController` を作成する（`[ApiController]`, `[Route("api/[controller]")]`）
2. `GET /api/threads` でスレッド一覧を返すエンドポイントを作る（まずはハードコーディングの List で OK）
3. `GET /api/threads/{id}` で特定のスレッドを返す（見つからない場合は `404 NotFound`）
4. `POST /api/threads` で新しいスレッドを作成する
5. `PUT /api/threads/{id}` でスレッドを更新する
6. `DELETE /api/threads/{id}` でスレッドを削除する
7. Swagger で全エンドポイントをテストする

### 参考資料
- [ASP.NET Core のコントローラー](https://learn.microsoft.com/ja-jp/aspnet/core/web-api/)
- [ルーティング](https://learn.microsoft.com/ja-jp/aspnet/core/mvc/controllers/routing)

---

## Station 3: モデルと DTO

### クリア条件
- ドメインモデル（Entity）と DTO（Data Transfer Object）を分離して定義できること
- リクエスト用 DTO とレスポンス用 DTO を使い分けられること
- `record` 型を DTO として活用できること

### 問題概要
API が受け取るデータ（リクエスト）と返すデータ（レスポンス）の形を定義するための「モデル」と「DTO」の設計を学ぶ。

**なぜ分離するのか**
- Entity: DB のテーブルに対応するクラス（内部用）
- DTO: API の入出力に使うクラス（外部用）
- パスワード等、外部に出してはいけないプロパティを DTO で除外できる

### 確認テスト
1. `Models/Thread.cs`（Entity）を作成する
   - プロパティ: `Id`, `Title`, `CreatedAt`, `UpdatedAt`
2. `Dtos/CreateThreadRequest.cs`（リクエスト DTO）を `record` で作る
   - プロパティ: `Title` のみ
3. `Dtos/ThreadResponse.cs`（レスポンス DTO）を `record` で作る
   - プロパティ: `Id`, `Title`, `CreatedAt`
4. Controller で Entity を直接返すのではなく、DTO に変換して返すようにする
5. `POST` ではリクエスト DTO から Entity を生成するようにする

### 参考資料
- [DTO パターン](https://learn.microsoft.com/ja-jp/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5)

---

## Station 4: Entity Framework Core（DB 接続）

### クリア条件
- EF Core を使って SQLite データベースに接続できること
- `DbContext` を定義し、`DbSet<T>` でテーブルを管理できること
- マイグレーションを実行してデータベースを作成できること
- CRUD 操作をすべて DB 経由で行えること

### 問題概要
これまでメモリ上（List）で管理していたデータを、実際のデータベースに永続化する。Entity Framework Core（EF Core）は C# のコードから DB を操作できる ORM（Object-Relational Mapper）。

**EF Core の仕組み**
```
C# のクラス（Entity） ←→ EF Core ←→ DB のテーブル
```

**主要な概念**
| 概念 | 説明 |
|---|---|
| `DbContext` | DB 接続を管理するクラス |
| `DbSet<T>` | テーブルに対応するプロパティ |
| マイグレーション | C# のモデル変更を DB に反映する仕組み |
| LINQ to Entities | LINQ で DB を検索する |

### 確認テスト
1. NuGet パッケージをインストールする
   - `Microsoft.EntityFrameworkCore.Sqlite`
   - `Microsoft.EntityFrameworkCore.Design`
2. `AppDbContext` クラスを作成し、`DbSet<Thread>` を定義する
3. `Program.cs` で DI コンテナに `DbContext` を登録する
4. マイグレーションを実行する
   - `dotnet ef migrations add InitialCreate`
   - `dotnet ef database update`
5. Controller を修正し、全 CRUD を DB 経由で行うようにする
6. Swagger でデータの永続化を確認する（再起動してもデータが残ること）

### 参考資料
- [EF Core 入門](https://learn.microsoft.com/ja-jp/ef/core/get-started/overview/first-app)
- [EF Core + SQLite](https://learn.microsoft.com/ja-jp/ef/core/providers/sqlite/)

---

## Station 5: バリデーションとエラーハンドリング

### クリア条件
- データアノテーション（`[Required]`, `[MaxLength]` 等）でバリデーションを実装できること
- バリデーションエラー時に適切なエラーレスポンス（400 Bad Request）が返ること
- グローバル例外ハンドリングを設定し、未処理例外が統一されたエラーレスポンスになること

### 問題概要
API に不正なデータが送られた場合や、サーバー側でエラーが起きた場合の処理を学ぶ。

**バリデーションの種類**
| 方法 | 説明 |
|---|---|
| データアノテーション | モデルの属性に `[Required]` 等を付ける |
| FluentValidation | より複雑なルールをクラスで定義する |
| 手動チェック | Controller 内で if 文で判定する |

### 確認テスト
1. `CreateThreadRequest` に `[Required]`, `[MaxLength(100)]` を付ける
2. タイトルが空の場合に 400 エラーが返ることを確認する
3. 存在しない ID を指定した場合に 404 エラーが返ることを確認する
4. 例外フィルター（`IExceptionFilter`）またはミドルウェアでグローバル例外処理を実装する
5. エラーレスポンスを統一フォーマットにする（例: `{ "error": "メッセージ", "statusCode": 400 }`）

### 参考資料
- [モデルの検証](https://learn.microsoft.com/ja-jp/aspnet/core/mvc/models/validation)
- [エラー処理](https://learn.microsoft.com/ja-jp/aspnet/core/web-api/handle-errors)

---

## Station 6: 依存性注入（DI）

### クリア条件
- DI（Dependency Injection）の概念を理解し、なぜ必要なのか説明できること
- Controller から直接 `DbContext` を使うのではなく、Service クラスを経由する構成に変更できること
- インターフェース + 実装クラスで DI に登録できること

### 問題概要
ASP.NET Core の核となる仕組み「依存性注入（DI）」を学ぶ。DI を使うとコードのテスタビリティと保守性が大幅に向上する。

**DI がない場合 vs ある場合**
```
// DI なし：Controller が直接 DbContext を new する → テストしにくい、変更しにくい
var context = new AppDbContext();

// DI あり：外からもらう → テスト時にモックに差し替え可能
public ThreadsController(IThreadService service) { ... }
```

**レイヤー構成**
```
Controller → Service（ビジネスロジック） → Repository（DB アクセス）
```

### 確認テスト
1. `IThreadService` インターフェースを作成する
2. `ThreadService` クラスを実装する（`AppDbContext` を DI で受け取る）
3. `Program.cs` で `builder.Services.AddScoped<IThreadService, ThreadService>()` を登録する
4. Controller のコンストラクタで `IThreadService` を受け取り、DB 操作を Service に委譲する
5. Service 経由で全 CRUD が動作することを確認する

### 参考資料
- [ASP.NET Core の DI](https://learn.microsoft.com/ja-jp/aspnet/core/fundamentals/dependency-injection)

---

## Station 7: 投稿機能と リレーション

### クリア条件
- スレッドに対する投稿（Post）の 1 対多リレーションを EF Core で定義できること
- 投稿の CRUD API が動作すること
- スレッド取得時に関連する投稿も含めて返せること

### 問題概要
掲示板アプリとして「スレッド」に紐づく「投稿」機能を追加する。データベースの外部キーとリレーションを EF Core で扱う方法を学ぶ。

**リレーション**
```
Thread (1) ←→ (N) Post
```

### 確認テスト
1. `Post` モデルを作成する（`Id`, `ThreadId`, `Content`, `CreatedAt`）
2. `Thread` モデルに `ICollection<Post> Posts` ナビゲーションプロパティを追加する
3. マイグレーションを実行して Post テーブルを作成する
4. `PostsController` を作成し、以下の API を実装する
   - `GET /api/threads/{threadId}/posts` — 投稿一覧取得
   - `POST /api/threads/{threadId}/posts` — 投稿作成
   - `DELETE /api/threads/{threadId}/posts/{postId}` — 投稿削除
5. `GET /api/threads/{id}` で投稿も含めて返す（`Include` を使用）
6. 存在しないスレッドに投稿しようとした場合、404 を返す

### 参考資料
- [EF Core のリレーション](https://learn.microsoft.com/ja-jp/ef/core/modeling/relationships)
- [関連データの読み込み](https://learn.microsoft.com/ja-jp/ef/core/querying/related-data/)

---

## Station 8: 掲示板 API の完成（総合演習）

### クリア条件
- 掲示板 API が以下の機能を持って完成していること
- API 全体が Swagger でドキュメント化されていること
- GitHub にプッシュされていること

### 問題概要
入門編〜Station 7 で学んだ知識を総動員して、掲示板 API を完成させる。

**必要なエンドポイント一覧**
| メソッド | URL | 説明 |
|---|---|---|
| `GET` | `/api/threads` | スレッド一覧取得 |
| `GET` | `/api/threads/{id}` | スレッド詳細（投稿含む） |
| `POST` | `/api/threads` | スレッド作成 |
| `PUT` | `/api/threads/{id}` | スレッド更新 |
| `DELETE` | `/api/threads/{id}` | スレッド削除 |
| `GET` | `/api/threads/{threadId}/posts` | 投稿一覧取得 |
| `POST` | `/api/threads/{threadId}/posts` | 投稿作成 |
| `DELETE` | `/api/threads/{threadId}/posts/{postId}` | 投稿削除 |

### 確認テスト
1. 上記全エンドポイントが正常に動作すること
2. バリデーションエラーや存在しないリソースへのアクセス時のエラー処理が適切であること
3. Service 層と Controller 層が分離されていること
4. Swagger に全エンドポイントが表示され、テストできること
5. コードに適切なコメントが書かれていること
6. GitHub にプッシュする
7. **（挑戦課題）** React の掲示板アプリ（基礎 1）から自作 API を呼び出してみる
