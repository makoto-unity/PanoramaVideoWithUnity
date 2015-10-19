# UnityとOculusで360度パノラマ全天周動画を見る方法【無料編】

「UnityとOculusで360度パノラマ全天周動画を見る方法」のシリーズとしては第３回目なのですが、今までの２回は全て有料アセットを使ったりしていてイマイチ一般性がなかったのではないかと思います。今回は「無料」ということにこだわり（Oculus をUnityで使うのも無料になりましたし）、パノラマ動画アプリを作ってみたいと思います。

## 素材作り
まずは RICOH Theta でパノラマ動画を撮影します。最近発売される（2015/10/19現在）、「RICOH Theta S」いいですね！これはマストバイですよ！奥さん！パノラマ好きだったらしのごの言わずに買いましょう。今のところこれ以上のモノは世界中にはないでしょう。<br />
iPhone/Androidアプリでパノラマ動画を持ってきます。Theta Sからアプリで持ってくるだけで、正距円筒図法の動画になるので楽です。<br />
Theta m-15の方はMac/Windows 側で正距円筒図法にステッチ（複数カメラからの映像を一つのパノラマ映像にする作業）をする必要があります。専用Mac/Winアプリで自動ステッチしてください。<br />
Theta Sなんてないよ、とかいう人はとりあえず、この<a href="https://github.com/makoto-unity/PanoramaVideoWithUnity/blob/master/Assets/MyGame/Movies/IMG_4865.MP4">この動画</a>をダウンロードして使ってください。<br />

## 投影する天球をシーンに置く
Unity を立ち上げてください。<br />
とりあえずUnity エディタの説明をしようと思いましたが、面倒なので<a href="http://gihyo.jp/dev/serial/01/unity-asset-tech/0001?page=1">「Unity仮面が教える！ ラクしてゲームを作るためのAssetStore超活用術」</a>を参考にしてください。<br />
だいたいエディタの使い方を学んだところで、先ほどのパノラマ動画をUnityのProject ビュー にドラッグアンドドロップ（以下D&D）します。するとインポート処理が始まります。インポート処理が終わると、画像のように音声と動画が分離されます。<br />
天球モデルは <a href="https://dl.dropboxusercontent.com/u/5911974/Sphere100.fbx">「Sphere100.fbx」</a> を私の方で提供しているので、そちらをお使いください。 Blender から作るやり方 は天球の極点で動画が歪んでしまうので、あまりお勧めしません。そして、「 Sphere100 」を Hierarchy ビューにD&Dします<br />

## マテリアルを作る
Project ビューで右クリックしてメニューを出し、 Create → Material を選択して新しいマテリアル（素材）を作ります。適当な名前をつけます。ここでは「SampleMovieMat」とかにしましょうか。<br />
「 MovieMat 」を選択して、Inspector ビューで Shader を Unlit → Texture にします。これで、影つかなくなりました。ムービーに天球の影がついたらおかしいですからね。<br />
先ほどインポートした ムービーファイルを Inspector の None (Texture) という箇所にD＆Dします。<br />
そしてこのマテリアルを先ほど Hierarchy ビュー の 「 Sphere100 」にD&Dします。<br />

## 再生スクリプトを作る
ただ、このままでは再生してくれません。再生するスクリプトを作らなくてはいけないのです。<br />
Project ビューで Create → C# Script でC#スクリプトを作成します。名前はなんでもいいのですが、「 SampleMoviePlay 」にしましょうか。<br />
作ったC# スクリプトをダブルクリックすると、スクリプトを書けるエディタが立ち上がります。<br />

    void Start () {

の次の行に以下の行を追加します<br />

    (GetComponent<Renderer>().material.mainTexture as MovieTexture).Play();

書けたら保存します。そしてUnityに戻ってみます。左下に赤いエラーが出ていなければokです。出ていたらよーく見比べてみましょう。 <br />
問題ないようなら、このスクリプト「 SampleMoviePlay 」を動画が貼っている「 Sphere100 」にD&Dします。<br />
これでプレイボタン（画面中央上の▲）を押してみて、動画が動くか確認しましょう。確認したらもう一度プレイボタンを押して止めましょう。 <br />

## 音声をつける
Project ビューのムービーの▲をクリックして、サウンドを表示します。<br />
このサウンドを Hierarchy ビューの「 Sphere100 」にD&Dします。<br />
またプレイボタンを押してみて、音が再生されるか確認します<br />

## マウスで方向が向けるように

## エフェクト
カラーコレクション
ColorSuite

## Oculus Rift 対応

ーーー以下スマホ対応ーーー

【EasyMovieTexture の購入】

【iOSの場合】
一部ソースコードの変更

【Androidの場合】

