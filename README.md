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
とりあえずシーンを保存しましょう。File → Save Scene とすると、名前を聞かれるので、適当に「 Sphere Movie 」とかにしましょうか。<br />
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
<a href="https://github.com/makoto-unity/PanoramaVideoWithUnity/blob/master/Assets/MyGame/Scripts/MouseLook.cs">MouseLook.cs</a>というスクリプトを利用しましょう。<br />
これをダウンロードして、「Camera」オブジェクトにD&Dでいけます。

## エフェクト
カラーコレクションをかけて、色調整をしましょう。<br />

https://github.com/keijiro/ColorSuite

keijiroさんの「ColorSuite」を使います。こちらをダウンロードして、「ColorSuite」フォルダをプロジェクトにD&Dします。<br />
そして、CameraオブジェクトにD&Dしたら、色調整が可能になります。各色を変更して調整しましょう。<br />

## Oculus Rift 対応
メニューから Edit → Project Settings → Player を選択して、PlayerSettings を開きます。ここで、 Virtual Reality Supported にチェックを入れたらオーケーです。あとは Oculus を繋いで、Editor プレイするだけで、トラッキングできるはずです。簡単ですよね！

## デスクトップアプリとしてのビルド
File → Build Settings でビルド設定画面を表示します。<br />
最初はアプリとしてはいるシーンが一つもないので、現在作っているシーン 「 SphereMovie 」を追加します。追加する方法は Scene In Build にシーンファイルをD&Dする方法と、Add Current で現在開いているシーンを追加する方法があります。<br />
そして、出力したいターゲットを選んで、Buildすればアプリが作られます。Build And Run すればそのまま立ち上がります。どうです？アプリとして立ち上がりましたか？

## AVProの紹介
正直、フレームレートが低くて実際の運用（展示会とか）はなかなか厳しいと思います。
そういう際は、AssetStore の「AVPro」シリーズがオススメです。こちらのブログで紹介しているので、
興味あったらそれを参考に実装してください。基本的に実装方法は同じです。

# ーーー以下スマホ対応ーーー

## Easy Movie Texture
スマホでパノラマ動画をやりたい時は、Unityの機能だけでは実装できません。<br />
そこで、AssetStoreにある「 Easy Movie Texture 」を購入して、利用しましょう。$45です。自力でプログラム組むより遥かに楽なので、是非時間をお金で買いましょう。<br />

## iOSパッチ
このままだとXcode でビルド時にエラーが出てしまうので、
    EasyMovieTexture/Unity5_Patch_IOS/Untiy5_Patch_iOS
をダブルクリックして、パッチを適応しましょう。Unity5用ですので、4.6系は適宜対応してください。

## 準備

「 Sperer100 」を選択して、Inspector から先ほど自分で付けた、「Movie Play」スクリプトがあると思うのですけど、それのチェックボックスを外します。これでオフになるはずです。一旦オフにしましょう。<br />
そして、今度は以下の場所のスクリプト

    EasyMovieTexture/Scripts/MediaPlayerCtrl

を　「 Sphere100 」にD&Dして、その機能を付加します。<br />
「 Spherer100 」 の 「 Media Player Ctrl 」の項目で Target Material というところには自分自身つまり 「 Spherer100 」自体をD&Dします。Hierarchy ビューから「 Spherer100 」をD&Dしましょう。<br />

## StreamingAssets について

Str File Name というところにムービーファイル名を書くのですけど、実はこの場所は StreamingAssets フォルダ以下にないといけないのです。なので、先ほど置いたムービーファイルを StreamingAssets フォルダの下に移動させてください。<br />
そうした上で、Str File Name に先ほど置いたファイル名を書きましょう。「.mp4」等の拡張子も忘れずに書いておきましょう。（Unity エディタ内は拡張子が表示されないので気をつけてください）

## とりあえず、サンプルシーンをやってみる

実は Easy Movie Player はエディタ上から再生できません。ですので、イチイチ確認のために書き出す必要があるのです。<br >
File → Build Settings でビルド設定画面を表示します。一旦現在のシーンは捨てて、Assets/EasyMovieTexture/Scene/Demo をD&D します。まずはデモで正常に動くか確認しましょう。

## iOSビルド
では順番に行きましょう。まずはiOSビルド。引き続き Build Settings 画面でPlatform を iOS に変更して、Switch Platform と押すと変換が始まります。そして、Build ボタンを押すと、プロジェクト名を聞かれるので、適当な名前を付けてください。MovieDemo とかでしょうか。<br />
おっと、ビルドエラーがでますので、先ほどMoviePlay.cs の中で書いたコードがモバイルでは動かないということなので、

		MovieTexture movie = (GetComponent<Renderer>().material.mainTexture as MovieTexture);
		movie.loop = true;
		movie.Play();

というコードを

    #if UNITY_EDITOR || UNITY_STANDALONE
		MovieTexture movie = (GetComponent<Renderer>().material.mainTexture as MovieTexture);
		movie.loop = true;
		movie.Play();
    #endif

と、上下で #if〜 と #endif を加えてください。<br />

そして出来たプロジェクトファイルの Unity-iPhone.xcodeproj をダブルクリックしてXcode を立ち上げてください。<br />
それで、iPhone を繋げてビルドして動くことを確認してください。真ん中に二つのムービーが再生されたら成功です。 <br />

## Androidビルド
Androidはもっと簡単です。引き続き Build Settings 画面でPlatform を Android に変更して、Switch Platform と押すと変換が始まります。<br />
すぐにビルド、と行きたいですが、その前に設定するところがあります。Unity → Preference (Mac) /Edit → Preference (Winの場合) でPreference を表示させます。<br />
External Tools を選んでいただいて、Android の SDK の項目を Browse でAndroid SDKのパスを入力すればOKです。<br />
