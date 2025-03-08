# deserialize-rrs_message-cs

[adf-core-java](https://github.com/roborescue/adf-core-java/tree/master)を用いた[RoboCupRescue Simulation Server](https://github.com/roborescue/rcrs-server)のシミュレーションにおいて，エージェントが送信する通信をデシリアライズするコードです

本コードの使い方は index.cs 内に記述されています．
下記のセットアップと実行方法は index.cs および本コードの実行の際の手順です．

## くわしく

adf-core-java を用いた RoboCupRescue Simulation のシミュレーション上で，エージェントは通信をおこないます．
シミュレーションでは通信に使用できる帯域やデータ量に制限があります．
そのため，adf-core-java 上でモジュールの再利用可能性の向上とともに，通信の最適化も同時に行われます．
そのため，シミュレーションログなどに含まれる通信データはバイナリであり，そのままでは解読ができません．
その解読ができないバイナリの通信データを解読可能にするコードが，本コードです．

## セットアップ

### 1. 本リポジトリのクローンを作成

はじめに，本リポジトリをコンピュータにダウンロードします

```sh
git clone https://github.com/nono2224/deserialize-rrs_message-cs.git
```

### 2. リポジトリへ移動

ダウンロードしたリポジトリへ移動を行います

```sh
cd deserialize-rrs_messagecs
```

### 3. 依存関係の復元

依存関係の復元を行います

```sh
dotnet restore
```

## 実行方法

### 1. ビルド

ビルドを行います

```sh
dotnet build
```

### 3. 実行

下記スクリプトで実行させます

```sh
dotnet run
```

## \*

-   CommandAmbulance
-   CommandFire
-   CommandScout
-   MessageReport

これらのメッセージは解読できません
