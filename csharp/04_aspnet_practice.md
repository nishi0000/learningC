# ASP.NET Core Web API 実践編

> **前提知識:** ASP.NET Core Web API 入門編を完了していること
> **成果物:** 入門編の掲示板 API に認証・テスト・ログ・デプロイを追加
> **判定方式:** セルフチェック

---

## Station 1: 認証・認可（JWT）

### クリア条件
- ユーザー登録・ログイン API が動作すること
- ログイン成功時に JWT トークンが返されること
- `[Authorize]` を付けたエンドポイントが、トークンなしでは 401 を返すこと
- トークンありでアクセスした場合は正常にレスポンスが返ること

### 問題概要
API に認証（ログイン）と認可（権限チェック）を実装する。JWT（JSON Web Token）は Web API で最も広く使われる認証方式。

**JWT の仕組み**
```
1. クライアントがログイン情報を送信
2. サーバーが検証し、JWT トークンを発行
3. クライアントは以降のリクエストで Authorization ヘッダーにトークンを付ける
4. サーバーはトークンを検証してリクエストを許可/拒否
```

**ASP.NET Core Identity**
- ユーザー管理・パスワードハッシュ・ロール管理などを提供するライブラリ
- 必須ではないが、実務では利用することが多い

### 確認テスト
1. `User` モデルを作成する（`Id`, `Email`, `PasswordHash`）
2. パスワードのハッシュ化を実装する（`BCrypt.Net` または `Identity`）
3. `POST /api/auth/register` — ユーザー登録
4. `POST /api/auth/login` — ログイン（JWT トークンを返す）
5. `Program.cs` で JWT 認証を設定する
6. スレッド作成・更新・削除に `[Authorize]` を付けて、認証が必要にする
7. Swagger で JWT トークンを設定してテストする

### 参考資料
- [ASP.NET Core の認証](https://learn.microsoft.com/ja-jp/aspnet/core/security/authentication/)
- [JWT Bearer 認証](https://learn.microsoft.com/ja-jp/aspnet/core/security/authentication/jwt-authn)

---

## Station 2: ミドルウェア

### クリア条件
- カスタムミドルウェアを作成し、リクエスト/レスポンスの処理をフックできること
- リクエストログを記録するミドルウェアを実装できること
- ミドルウェアの実行順序を理解していること

### 問題概要
ASP.NET Core のリクエストパイプライン（ミドルウェア）の仕組みを学ぶ。ミドルウェアはリクエストがコントローラーに届くまでの間に実行される処理。

**リクエストパイプライン**
```
リクエスト → [ログ] → [認証] → [ルーティング] → Controller → [ログ] → レスポンス
```

### 確認テスト
1. リクエストのメソッド・URL・処理時間をコンソールに出力するミドルウェアを作る
2. `Program.cs` で `app.UseMiddleware<RequestLoggingMiddleware>()` を登録する
3. 認証ミドルウェア（`UseAuthentication`）との順序を変えて動作の違いを確認する
4. エラー時に統一レスポンスを返す例外処理ミドルウェアを作成する

### 参考資料
- [ASP.NET Core のミドルウェア](https://learn.microsoft.com/ja-jp/aspnet/core/fundamentals/middleware/)

---

## Station 3: ロギング

### クリア条件
- `ILogger<T>` を使ってログを出力できること
- ログレベル（Information, Warning, Error 等）を使い分けられること
- Serilog を導入し、ファイルへのログ出力ができること

### 問題概要
本番運用を見据え、アプリケーションのログを適切に記録する方法を学ぶ。

**ログレベル**
| レベル | 用途 |
|---|---|
| `Trace` | 最も詳細（デバッグ時のみ） |
| `Debug` | 開発時のデバッグ情報 |
| `Information` | 正常な処理の記録 |
| `Warning` | 問題の可能性がある状況 |
| `Error` | エラーが発生した場合 |
| `Critical` | アプリが停止するレベルの致命的エラー |

### 確認テスト
1. Controller に `ILogger<ThreadsController>` を DI で注入する
2. 各 CRUD 操作にログ出力を追加する
   - 作成: `Information`（「スレッドが作成されました: {title}」）
   - 削除: `Warning`（「スレッドが削除されました: {id}」）
   - エラー: `Error`（例外メッセージを記録）
3. `Serilog` をインストールし、ファイルにログを出力するよう設定する
4. 構造化ログ（`_logger.LogInformation("Thread created: {Title}", title)`）を使う

### 参考資料
- [ASP.NET Core のログ](https://learn.microsoft.com/ja-jp/aspnet/core/fundamentals/logging/)
- [Serilog](https://serilog.net/)

---

## Station 4: 単体テスト（xUnit）

### クリア条件
- xUnit でテストプロジェクトを作成し、テストを実行できること
- Service クラスのメソッドに対する単体テストが書けること
- モック（`Moq` ライブラリ）を使って依存関係を差し替えたテストが書けること
- `dotnet test` でテストが全件パスすること

### 問題概要
コードの品質を保証するための自動テストを学ぶ。C# では xUnit が現在最も広く使われるテストフレームワーク。

**テストの構成（AAA パターン）**
```csharp
[Fact]
public void Add_TwoNumbers_ReturnsSum()
{
    // Arrange（準備）
    var calculator = new Calculator();

    // Act（実行）
    var result = calculator.Add(2, 3);

    // Assert（検証）
    Assert.Equal(5, result);
}
```

### 確認テスト
1. `dotnet new xunit -n BoardApi.Tests` でテストプロジェクトを作成する
2. `ThreadService` のスレッド作成メソッドのテストを書く
   - 正常系: タイトルを渡したらスレッドが作成されること
   - 異常系: 空のタイトルでは例外がスローされること
3. `Moq` をインストールし、`DbContext` のモックを作ってテストする
4. `[Theory]` と `[InlineData]` を使ってパラメータ化テストを書く
5. `dotnet test` で全テストがパスすることを確認する

### 参考資料
- [.NET での単体テスト](https://learn.microsoft.com/ja-jp/dotnet/core/testing/unit-testing-with-dotnet-test)
- [xUnit](https://xunit.net/)
- [Moq](https://github.com/devlooped/moq)

---

## Station 5: 結合テスト

### クリア条件
- `WebApplicationFactory<T>` を使って API の結合テストが書けること
- HTTP リクエストを送信し、レスポンスのステータスコードとボディを検証できること
- テスト用のインメモリ DB を使って本番 DB に影響しないテストができること

### 問題概要
単体テストに加え、API 全体を起動してリクエスト→レスポンスの流れをテストする「結合テスト」を学ぶ。

### 確認テスト
1. テストプロジェクトに `Microsoft.AspNetCore.Mvc.Testing` をインストールする
2. `WebApplicationFactory<Program>` を使って API サーバーをテスト内で起動する
3. `GET /api/threads` が 200 を返すことをテストする
4. `POST /api/threads` でスレッドを作成し、201 が返ることをテストする
5. 認証が必要なエンドポイントにトークンなしでアクセスして 401 が返ることをテストする
6. テスト用に SQLite のインメモリ DB を使う設定を行う

### 参考資料
- [ASP.NET Core の結合テスト](https://learn.microsoft.com/ja-jp/aspnet/core/test/integration-tests)

---

## Station 6: CORS とフロントエンド連携

### クリア条件
- CORS（Cross-Origin Resource Sharing）を設定し、フロントエンドから API を呼べること
- React アプリ（または簡単な HTML ファイル）から `fetch` で自作 API にアクセスできること

### 問題概要
ブラウザのセキュリティ機能である CORS を設定し、フロントエンドと Web API を連携させる。

**CORS とは**
- ブラウザは、異なるオリジン（ドメイン/ポート）へのリクエストをデフォルトで拒否する
- API 側で「このオリジンからのアクセスを許可する」と設定する必要がある

### 確認テスト
1. `Program.cs` で CORS ポリシーを設定する
2. `http://localhost:3000`（React のデフォルト）からのアクセスを許可する
3. 簡単な HTML ファイルから `fetch` で API を呼び出してデータが表示されることを確認する
4. CORS 設定を外して、ブラウザコンソールにエラーが出ることを確認する
5. **(挑戦課題)** React の掲示板アプリのバックエンドを自作 API に差し替える

### 参考資料
- [ASP.NET Core の CORS](https://learn.microsoft.com/ja-jp/aspnet/core/security/cors)

---

## Station 7: デプロイ

### クリア条件
- アプリケーションを本番用にビルド（`dotnet publish`）できること
- クラウドサービス（Azure App Service / Render / Railway 等）にデプロイできること
- デプロイ先の URL で API が動作すること

### 問題概要
開発した API を本番環境にデプロイし、インターネットからアクセスできるようにする。

**デプロイ先の選択肢**

| サービス | 特徴 |
|---|---|
| Azure App Service | Microsoft 提供。C#/.NET との相性が最も良い。無料枠あり |
| Render | 無料プランあり。Docker 不要で簡単にデプロイ可能 |
| Railway | GitHub 連携で自動デプロイ。無料枠あり |

### 確認テスト
1. `dotnet publish -c Release` で本番ビルドする
2. `appsettings.json` の環境別設定（Development / Production）を理解する
3. いずれかのクラウドサービスにデプロイする
4. デプロイ先 URL の Swagger でAPI が動くことを確認する
5. 環境変数で DB 接続文字列やJWT のシークレットを管理する
6. GitHub にプッシュする

### 参考資料
- [Azure App Service へのデプロイ](https://learn.microsoft.com/ja-jp/aspnet/core/tutorials/publish-to-azure-webapp-using-vs)
- [dotnet publish](https://learn.microsoft.com/ja-jp/dotnet/core/tools/dotnet-publish)
