# Microsoft Graph API サンプル (Windows Form)

[Microsoft Graph のクイック スタート](https://developer.microsoft.com/ja-jp/graph/quick-start)

のページでは .NET Framework 4.8 の Windows Form を使ったサンプルが含まれていないので作ってみました。

Microsoft 365 に接続して、Microsoft Graph API を呼び出すためには いろいろな認証方法があるようですが、
簡単に Graph API を実行するため、Microsoft アカウントを使った その人の情報にアクセスする事ができるアプリとなっています。

## インストール方法

```cmd
git clone https://github.com/kkato233/ms-graph-api-win-form.git
cd ms-graph-api-win-form
msbuild
```

## 利用方法

### Graph Exploer にログインしてそのアクセスキーを利用する。

[Graph Exploer](https://developer.microsoft.com/ja-jp/graph/graph-explorer)
に Microsoft アカウントで ログインして 「アクセストークン」
![image](https://user-images.githubusercontent.com/5441449/113753820-84b82700-9749-11eb-9090-58f6c4a7b19d.png)
をコピーして

アプリのアクセストークンの欄に貼り付けます。
![image](https://user-images.githubusercontent.com/5441449/113754096-d06ad080-9749-11eb-8fc6-50cc725a8bb6.png)

そうして メイン画面の 「クエリー実行」 ボタンを クリックすると

![image](https://user-images.githubusercontent.com/5441449/113757800-01e59b00-974e-11eb-953b-d6edbf63180a.png)

クエリーが実行されます。

また、Graph Exploer にある コードスニペットも

![image](https://user-images.githubusercontent.com/5441449/113757940-378a8400-974e-11eb-8c6f-808c209e27f8.png)

そのまま ソースコードに貼り付けて ビルドして 実行可能です。

![image](https://user-images.githubusercontent.com/5441449/113758144-7a4c5c00-974e-11eb-8975-24848c1bae13.png)

![image](https://user-images.githubusercontent.com/5441449/113758277-9f40cf00-974e-11eb-85ea-b42c1ec91742.png)

### アプリケーションを登録する

[クイック スタート:Windows デスクトップ アプリからトークンを取得し、Microsoft Graph API を呼び出す](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/quickstart-v2-windows-desktop)

を参考に Azure 管理画面から アプリケーションを登録して アプリケーションの ClientID を取得します。

アプリケーションのクライアントID を設定すると、「クエリー実行」のタイミングで
Microsoft の 認証を行うダイアログが表示されるようになります。

![image](https://user-images.githubusercontent.com/5441449/113759519-1f1b6900-9750-11eb-842f-54bb4c134ccc.png)

