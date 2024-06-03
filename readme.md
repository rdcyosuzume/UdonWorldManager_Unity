## $${\color{yellow}Team \space Alice}$$

<div align="center" > <img src="./Udon%20World%20Analyzer/Resources/PA_bnr_jp.png" width="800px;" ></div>

## Language

- [한국어](readme_KR.md)
- [日本語](readme.md)
- [English](readme_EN.md)

# ProjectALiceUnity

このプロジェクトは、プロジェクトアリスワールドマネージャーから派生したツールです。<br />
VRC の Unity(Udonsharp)環境での使用を前提に制作されています。<br />
他の Unity のプロジェクトにも使用することは可能ですが、推奨いたしません(これにより発生する問題についても現在責任を負いかねます)。<br />
しかし、今後一般的な Unity プロジェクトにもサポートを拡大する予定でいます。

## インストールの仕方

＜ご注意＞

> サーバーとの接続テストは、このアセットに組み込まれたスクリプトを使用することを推奨します。<br />
> 別スクリプトで制作する場合、数秒以内にサーバーに多くのリクエストを送信すると、サーバーからブロックされる可能性があります。<br />
> この場合、理由の如何を問わず、ブロックを解除しませんのでご注意ください。

1. Unity Package をあなたのプロジェクトにインポートしてください。
2. Asset > Project ALice > WorldManager.prefab をドラッグ＆ドロップでシーンに追加してください。
3. Hierarchy で WorldManager オブジェクトを選択した後、Inspector にワールドコードを入力してください。
4. サーバー接続テスト > ワールド接続テスト > Apply World Code の順に進めてください。
5. そのままワールドをアップロードしてください。テストしたい方は、下記のガイドラインに従ってください。

> サーバー接続テストボタンを押した後、1 ～ 3 秒間待ち、下に「Connected」と緑色の文字が表示されたら正常です。
> ワールド接続テストボタンを押した後、1 ～ 3 秒間待ち、下に「Connected」と表示されたら正常です。
> Apply World Code ボタンを押した後、下のスクリプトの Url 部分にワールドコード及びアドレスが入力されたら正常です。

## テスト

1. 上記の適用方法に従い、Unity のプレイモードに入ります。
2. Unity のプレイモードに入った後、Console に「200 Connect Success」が表示されたら完了です。
3. https://worldmanager.mystialolelei.site/LogList にアクセスし、該当ログが表示されたら正常です。

## 機能

1. ワールドコードによるワールド訪問者記録保存機能
2. ランタイム中のプレイヤー別インスタンス変数保存機能(ベータ版)

## 開発スケジュール

<table>
<thead>
<tr>
<th>idx</th>
<th>date</th>
<th>content</th>
</tr>
</thead>
<tbody>
<tr>
<td>1</td>
<td>2024-07-01</td>
<td>コードクリーニング(For SRP)</td>
</tr>
<tr>
<td>2</td>
<td>2024-08-01</td>
<td>コード保存機能(ベータ版)</td>
</tr>
<tr>
<td>3</td>
<td>2024-09-01</td>
<td>リアルタイムユーザー数統計参照機能</td>
</tr>
<tr>
<td>4</td>
<td>2024-10-01</td>
<td>全インスタンスダイレクトメッセージ</td>
</tr>
<tr>
<td>5</td>
<td>2024-11-01</td>
<td>patreon及びFanbox支援者リストの自動更新及び表示機能</td>
</tr>
</tbody>
</table>

## 利用規約

利用規約は https://worldmanager.mystialolelei.site/Rules に基づいています。

## License

- [MIT License](LICENSE)
- [API_License](API_LICENSE)
