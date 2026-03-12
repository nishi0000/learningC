# C# 学習計画 - Station 形式クリア条件まとめ

> **対象者:** C# 初心者（触って数日レベル）
> **目標:** C# の基礎から ASP.NET Core Web API・WPF デスクトップアプリまで段階的に習得し、実務の MVC プロジェクトを理解・改善できるようになる

---

## Railway 一覧

| # | ファイル | Railway | 内容 | 想定期間 |
|---|---|---|---|---|
| 1 | [01_intro.md](01_intro.md) | C# 入門編 | 基本文法・制御構文・メソッド | 2〜3 週間 |
| 2 | [02_fundamentals.md](02_fundamentals.md) | C# 基礎編 | OOP・コレクション・LINQ・非同期処理 | 3〜4 週間 |
| 3 | [03_aspnet_intro.md](03_aspnet_intro.md) | ASP.NET Core Web API 入門編 | REST API 構築・EF Core・DI | 3〜4 週間 |
| 4 | [04_aspnet_practice.md](04_aspnet_practice.md) | ASP.NET Core Web API 実践編 | 認証・テスト・ログ・デプロイ | 3〜4 週間 |
| 5 | [05_wpf.md](05_wpf.md) | WPF デスクトップアプリ入門編 | XAML・データバインディング・MVVM | 3〜4 週間 |
| 6 | [06_mvc_modernize.md](06_mvc_modernize.md) | MVC 理解・モダン化編 | レガシー MVC の読解と最新化の考え方 | 2〜3 週間 |

## 判定システム

| ファイル | 内容 |
|---|---|
| [checker_guide.md](checker_guide.md) | テスト環境セットアップ＆使い方ガイド |
| [01_intro_checks.md](01_intro_checks.md) | 入門編（9 Station）のテスト＆AI チェック |
| [02_fundamentals_checks.md](02_fundamentals_checks.md) | 基礎編（8 Station）のテスト＆AI チェック |

---

## 学習の進め方

### 推奨順序

```
C# 入門編 → C# 基礎編 → ASP.NET Core 入門編 → ASP.NET Core 実践編
                                                 ↘ WPF 入門編
                                                 ↘ MVC 理解・モダン化編
```

- **入門編 → 基礎編** は必ず順番に進めてください
- **ASP.NET Core 入門編** まで終わったら、以降は興味・業務の必要性に応じて選択可能です
- **MVC 理解・モダン化編** は実務で MVC を触っているなら、ASP.NET Core 入門編の後に取り組むと理解が深まります

### 各 Station の取り組み方
1. **クリア条件** を確認する
2. **問題概要** を読んで概念を理解する
3. **確認テスト** に従ってコードを書く
4. クリア条件をすべて満たしたら次の Station へ進む
5. 分からないことがあれば AI（Copilot など）に質問して OK

### 環境

| ツール | 用途 | 備考 |
|---|---|---|
| .NET 8 SDK（以上） | C# の実行環境 | [ダウンロード](https://dotnet.microsoft.com/download) |
| Visual Studio 2022 | 統合開発環境 | Community 版は無料。WPF 開発に特に便利 |
| VS Code + C# Dev Kit | 軽量エディタ | コンソールアプリや Web API はこちらでも OK |
| Git / GitHub | ソース管理 | 各 Railway のプロジェクトを GitHub で管理する |

---

## 実務（MVC）との関連マップ

> 「今の仕事で触っている〇〇が、どの Railway で学べるか」の対応表

| 実務で見かけるもの | 関連する Railway | 補足 |
|---|---|---|
| Controller / View / Model | Railway 3, 6 | MVC パターンの理解 |
| `@Html.xxx` / Razor 構文 | Railway 6 | レガシー Razor の読み方 |
| `DbContext` / Entity Framework | Railway 3 | EF Core で学ぶ（EF6 との差は Railway 6 で解説） |
| `web.config` | Railway 6 | Core では `appsettings.json` に移行 |
| NuGet パッケージ | Railway 1, 3 | .NET のパッケージ管理 |
| `async/await` | Railway 2 | 非同期処理の基礎 |
| DI（依存性注入） | Railway 3 | ASP.NET Core では標準機能 |
| LINQ | Railway 2 | データ操作の必須知識 |
