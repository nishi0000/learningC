# MVC 理解・モダン化編

> **前提知識:** ASP.NET Core Web API 入門編を完了していること
> **目的:** 実務で触っている ASP.NET MVC のコードを読めるようにし、モダン化の道筋を理解する
> **判定方式:** セルフチェック

---

## この Railway の背景

あなたの会社では ASP.NET MVC（レガシー）を使ったプロジェクトが動いています。
しかし、最新技術を学びたい気持ちもあり「何から学べばいいのか」迷っている状況です。

**この Railway の方針:**
1. まず **MVC パターンそのものを正しく理解する**（レガシー/モダンに共通する考え方）
2. **レガシー MVC のコードを読めるようになる**（今すぐ仕事に活きる）
3. **モダン化の方向性を把握する**（将来に活きる）

---

## Station 1: MVC パターンを理解する

### クリア条件
- MVC（Model-View-Controller）パターンの各層の役割を説明できること
- 「リクエストが来てからレスポンスが返るまで」の流れを説明できること
- MVC が WPF の MVVM とどう違うのか説明できること

### 問題概要
MVC は Web アプリケーションの設計パターン。ASP.NET MVC だけでなく、Ruby on Rails・Laravel・Spring など多くのフレームワークが採用している普遍的な概念。

**MVC の構成**
| 層 | 役割 | 例 |
|---|---|---|
| **Model** | データ・ビジネスロジック | `User.cs`, `OrderService.cs` |
| **View** | 画面表示（HTML 生成） | `Index.cshtml`（Razor テンプレート） |
| **Controller** | リクエスト受付・Model と View の仲介 | `HomeController.cs` |

**リクエストの流れ**
```
ブラウザ → URL → [ルーティング] → Controller → Model（データ取得）
                                       ↓
ブラウザ ← HTML ← View ← Controller（データを View に渡す）
```

**MVC vs MVVM**
| 項目 | MVC（Web） | MVVM（WPF） |
|---|---|---|
| 用途 | Web アプリ（HTTP リクエスト/レスポンス） | デスクトップアプリ |
| View | サーバー側で HTML を生成（Razor） | XAML でリアルタイム表示 |
| データ連携 | Controller が Model から View にデータを渡す | ViewModel が双方向バインディング |
| 状態管理 | HTTP はステートレス（毎回リクエスト） | アプリケーションの状態を常に保持 |

### 確認テスト
1. MVC パターンの各層を自分の言葉でメモに書く
2. 「ユーザーが掲示板のスレッド一覧ページを開くとき」の流れを MVC で説明する
3. MVC と MVVM の違いを表にまとめる
4. Web API（入門編で作ったもの）と MVC の違いをメモに書く
   - ヒント: Web API は View がなく、JSON を返す。MVC は View（HTML）を返す

### 参考資料
- [ASP.NET Core MVC の概要](https://learn.microsoft.com/ja-jp/aspnet/core/mvc/overview)

---

## Station 2: ASP.NET Core MVC プロジェクトを作る

### クリア条件
- `dotnet new mvc` で MVC プロジェクトを作成し、ブラウザで画面が表示されること
- Controller → View の流れを理解していること
- Razor 構文（`@`）で C# の変数を HTML 内に表示できること
- `ViewBag` / `ViewData` / `Model` の 3 つの方法で View にデータを渡せること

### 問題概要
実際に ASP.NET Core MVC プロジェクトを作って動かしながら、MVC の仕組みを体感する。

**Razor 構文**
```html
<!-- C# のコードを @ で埋め込める -->
<h1>@ViewBag.Title</h1>
<p>こんにちは、@Model.Name さん</p>

@if (Model.IsAdmin) {
    <span>管理者です</span>
}

@foreach (var item in Model.Items) {
    <li>@item.Name</li>
}
```

### 確認テスト
1. `dotnet new mvc -n MvcPractice` でプロジェクトを作成する
2. ブラウザで `https://localhost:xxxx` にアクセスして画面を確認する
3. プロジェクト構成を確認する（`Controllers/`, `Views/`, `Models/`, `wwwroot/`）
4. `HomeController.cs` を読み、`Index()` アクションメソッドが `Views/Home/Index.cshtml` を返す仕組みを理解する
5. `ViewBag.Message = "こんにちは";` でデータを渡し、View で `@ViewBag.Message` を表示する
6. 強く型付けされたモデルを使った View を作成する（`@model Product`）

### 参考資料
- [Razor 構文](https://learn.microsoft.com/ja-jp/aspnet/core/mvc/views/razor)
- [View へのデータ渡し](https://learn.microsoft.com/ja-jp/aspnet/core/mvc/views/overview)

---

## Station 3: MVC での CRUD 実装

### クリア条件
- EF Core を使って MVC で CRUD（一覧・詳細・作成・編集・削除）が実装できること
- フォーム送信（`<form>`）で POST リクエストを送れること
- `[HttpGet]` と `[HttpPost]` を使い分けられること
- バリデーションエラーをフォーム上に表示できること

### 問題概要
MVC でデータベースの CRUD 画面を作る。Web API では JSON を返すだけだったが、MVC では HTML フォームとの連携が加わる。

**Web API との比較**
| 操作 | Web API | MVC |
|---|---|---|
| 一覧表示 | `GET /api/threads` → JSON | `GET /threads` → HTML ページ |
| 作成フォーム表示 | なし（フロントエンドが担当） | `GET /threads/create` → フォーム HTML |
| 作成実行 | `POST /api/threads` ← JSON | `POST /threads/create` ← フォームデータ |
| 編集 | `PUT /api/threads/{id}` | `GET /threads/edit/{id}` + `POST /threads/edit/{id}` |

### 確認テスト
1. `Product` モデルと `AppDbContext` を作成する（入門編の知識を活用）
2. EF Core のマイグレーションで DB を作成する
3. `ProductsController` で以下の画面を実装する
   - `Index` — 商品一覧（`GET /products`）
   - `Details` — 商品詳細（`GET /products/details/{id}`）
   - `Create` — 商品作成フォーム（`GET`）+ 作成処理（`POST`）
   - `Edit` — 商品編集フォーム（`GET`）+ 更新処理（`POST`）
   - `Delete` — 削除確認（`GET`）+ 削除処理（`POST`）
4. フォームに `[Required]` バリデーションを適用し、エラー時にメッセージを表示する
5. スキャフォールディング（`dotnet aspnet-codegenerator`）は使わず手動で実装して理解を深める

### 参考資料
- [ASP.NET Core MVC のチュートリアル](https://learn.microsoft.com/ja-jp/aspnet/core/tutorials/first-mvc-app/start-mvc)

---

## Station 4: レガシー ASP.NET MVC のコードを読む

### クリア条件
- ASP.NET MVC 5（.NET Framework）と ASP.NET Core MVC の主な違いを 5 つ以上挙げられること
- レガシーコードで見かける典型的なパターンを認識できること
- `web.config` と `appsettings.json` の役割の違いを説明できること

### 問題概要
実務のレガシーコードを理解するために、旧バージョンと新バージョンの違いを把握する。コードを読む力は実務で最も重要なスキルの 1 つ。

**ASP.NET MVC 5 (.NET Framework) vs ASP.NET Core MVC の主な違い**

| 項目 | レガシー（MVC 5） | モダン（ASP.NET Core） |
|---|---|---|
| フレームワーク | .NET Framework 4.x | .NET 8+ |
| 設定ファイル | `web.config`（XML） | `appsettings.json`（JSON） |
| DI | 手動設定 or 外部ライブラリ（Unity, Ninject 等） | 組み込み DI |
| ルーティング | `RouteConfig.cs` | `Program.cs` + 属性ルーティング |
| 起動設定 | `Global.asax` + `Startup.cs`（OWIN） | `Program.cs` に統合 |
| パッケージ管理 | `packages.config` | `*.csproj`（PackageReference） |
| View エンジン | Razor（`@Html.xxx` ヘルパー多用） | Razor（タグヘルパー推奨） |
| EF バージョン | Entity Framework 6 | Entity Framework Core |
| OS | Windows のみ | 跨デプラットフォーム |
| デプロイ先 | IIS | IIS / Kestrel / Docker / Azure |

**レガシーコードでよく見るパターン**
```csharp
// ❌ レガシー: Global.asax
protected void Application_Start()
{
    RouteConfig.RegisterRoutes(RouteTable.Routes);
}

// ❌ レガシー: packages.config
// <package id="Newtonsoft.Json" version="13.0.1" />

// ❌ レガシー: Razor の @Html ヘルパー
@Html.TextBoxFor(m => m.Name)
@Html.ValidationMessageFor(m => m.Name)

// ✅ モダン: タグヘルパー
<input asp-for="Name" />
<span asp-validation-for="Name"></span>
```

### 確認テスト
1. レガシーとモダンの違いを自分でまとめた表を作る（上記を参考に、5 つ以上）
2. 以下のレガシーコードが何をしているか読み解く練習をする
   - `Global.asax` の `Application_Start()`
   - `RouteConfig.cs` の `RegisterRoutes()`
   - `web.config` の `connectionStrings`
3. レガシーで `@Html.TextBoxFor(m => m.Name)` と書かれているものをモダンのタグヘルパーで書き直す
4. 「もし実務のコードを ASP.NET Core に移行するとしたら、何から手をつけるか」を考えてメモする

### 参考資料
- [ASP.NET から ASP.NET Core への移行](https://learn.microsoft.com/ja-jp/aspnet/core/migration/proper-to-2x/)

---

## Station 5: モダン化の方向性を理解する

### クリア条件
- 「MVC（サーバーレンダリング）」と「Web API + SPA」の違い・メリット/デメリットを説明できること
- Minimal API の書き方を理解し、簡単な API を作れること
- 実務のプロジェクトを改善するための次のステップを言語化できること

### 問題概要
Web アプリ開発の全体像を把握し、今後のキャリアに活かせる方向性を理解する。

**Web アプリのアーキテクチャ比較**

| アーキテクチャ | 構成 | メリット | デメリット |
|---|---|---|---|
| **MVC（サーバーレンダリング）** | サーバーが HTML を返す | サーバー 1 つで完結。SEO に強い | リッチ UI が難しい。ページ遷移が重い |
| **Web API + SPA** | API（JSON）+ React 等 | リッチ UI。フロント/バックの分離 | 2 つのプロジェクトが必要 |
| **Blazor** | C# でフロント・バックの両方を書く | C# だけで完結。コード共有しやすい | エコシステムが React ほど成熟していない |

**Minimal API**
ASP.NET Core 6 以降で追加された軽量な API の書き方。Controller を使わず `Program.cs` に直接記述する。

```csharp
var app = WebApplication.Create();

app.MapGet("/api/hello", () => "Hello World!");

app.MapGet("/api/threads", async (AppDbContext db) =>
    await db.Threads.ToListAsync());

app.MapPost("/api/threads", async (CreateThreadRequest req, AppDbContext db) =>
{
    var thread = new Thread { Title = req.Title };
    db.Threads.Add(thread);
    await db.SaveChangesAsync();
    return Results.Created($"/api/threads/{thread.Id}", thread);
});

app.Run();
```

### 確認テスト
1. MVC と Web API + SPA のメリット/デメリットを自分の言葉でまとめる
2. Minimal API で簡単な CRUD API を `Program.cs` だけで作成する
3. 「自社のプロジェクトをモダン化するなら？」を以下の観点で考えてメモする
   - 今すぐできること（EF Core への移行、DI の導入など）
   - 中期的にやること（ASP.NET Core への移行）
   - 長期的な方向性（Web API + SPA 化、Blazor 化）
4. これまでの学習を振り返り、「自分がまだ弱いと思う分野」をリストアップする
5. GitHub に学習過程のリポジトリがすべて揃っていることを確認する

### 参考資料
- [Minimal API](https://learn.microsoft.com/ja-jp/aspnet/core/fundamentals/minimal-apis)
- [Blazor](https://learn.microsoft.com/ja-jp/aspnet/core/blazor/)
- [ASP.NET Core への移行ガイド](https://learn.microsoft.com/ja-jp/aspnet/core/migration/proper-to-2x/)

---

## おわりに: 学習のロードマップ

ここまで完了したあなたは、以下のスキルが身についているはずです。

```
✅ C# の基本文法とモダン機能
✅ オブジェクト指向プログラミング
✅ LINQ / 非同期処理 / JSON 操作
✅ ASP.NET Core Web API の構築（CRUD / 認証 / テスト / デプロイ）
✅ WPF デスクトップアプリ開発（MVVM パターン）
✅ MVC パターンの理解とレガシーコードの読解力
✅ モダン化の方向性の把握
```

**次のステップ候補:**
- 実務プロジェクトの小さな改善提案をしてみる
- 個人プロジェクトでポートフォリオを作る
- Blazor に挑戦してフルスタック C# 開発を体験する
- Docker / CI/CD（GitHub Actions）を学んでデプロイを自動化する
- デザインパターンやクリーンアーキテクチャを学ぶ
