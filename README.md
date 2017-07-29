# PostgreSQLSample
PostgreSQLをC#で使うサンプル

## 接続プロバイダについて
Npgsql or Odbc を使ってみた．
使い勝手に判断つくほどやってない．
NpgsqlはライセンスがPostgreSQL Licenceのため，PostgreSQLと同じでやりやすい面はあるかもしれない．
ちなみにOdbcはLGPL.

1. Npgsql
    Nuget パッケージマネージャで入れるだけ．
    PM> Install-Package Npgsql
    参照 https://www.nuget.org/packages/Npgsql/

1. Odbc
    インストール後，Windows -> 管理メニュー -> データソース(ODBC)
    ユーザーDSN -> 追加
    データソースの新規作成 -> 名前 -> PostgreSQL
    セットアップダイアログに各種情報を入力する．
    データソース名が大事．プログラムで使用する．
