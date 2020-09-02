# MIDI Share

## MIDI の対応表

* [MIDIノート番号と音名、周波数の対応表](http://www.asahi-net.or.jp/~HB9T-KTD/music/Japan/Research/DTM/freq_map.html)

## 参照ライブラリ

* [micdah/RtMidi.Core](https://github.com/micdah/RtMidi.Core)

## P2P

ICE(The Internet Communications Engine) で実装ができそうか試してみる

これは ICE(Interactive Connectivity Establishment) とは異なる

* [Writing an Ice Application with C-Sharp - Ice](https://doc.zeroc.com/ice/3.7/hello-world-application/writing-an-ice-application-with-c-sharp)
* [zeroc-ice/ice](https://github.com/zeroc-ice/ice)
    * GPL v2
    * 商用ライセンスもある

## electron で開発してみる

C# で P2P を実装するいい方法が見つからないので WebRTC を使ったアプリで実装を考えてみる

* [mappum/electron-webrtc](https://github.com/mappum/electron-webrtc)
* [Pomax/midi-with-node](https://github.com/Pomax/midi-with-node)
* [Playing with MIDI in JavaScript](https://medium.com/swinginc/playing-with-midi-in-javascript-b6999f2913c3)
* [Getting Started With The Web MIDI API — Smashing Magazine](https://www.smashingmagazine.com/2018/03/web-midi-api/)
* [MIDIデバイスの準備不要、Web MIDI APIの基礎](https://html5experts.jp/ryoyakawai/16787/)
* [Web MIDI API (日本語訳)](https://g200kg.github.io/web-midi-api-ja/)
* [Web MIDI APIを触ってみた - Qiita](https://qiita.com/ShoheiOno/items/34ae96c2563586982490)