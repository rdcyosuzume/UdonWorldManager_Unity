## $${\color{yellow}Team \space Alice}$$

<div align="center" > <img src="./Udon%20World%20Analyzer/Resources/PA_bnr.png" width="800px;" ></div>

## Language

- [한국어](readme_KR.md)
- [日本語](readme.md)
- [English](readme_EN.md)

# Project ALice Unity

이 프로젝트는 프로젝트 엘리스 우동 월드 매니저로 부터 파생된 도구입니다.<br />
VRC 의 Unity(Udonsharp) 환경에서의 사용을 전재로 제작되었습니다.<br />
다른 Unity 의 프로젝트에도 사용은 가능하나 추천하지 않습니다.(이로 인해 발생하는 문제에 대해서 현재 책임 지지 않습니다.)<br />
추후 일반적인 Unity 프로젝트에도 지원을 확대할 수도 있습니다.(지금은 지원하지 않습니다.)

## Skill

<img src="https://camo.githubusercontent.com/40343d2dedbbcbf0d410e317854794ee6238e1c77ffb8513340ca7e2f79ef46d/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f55646f6e20632532332d2532333233393132302e7376673f7374796c653d666f722d7468652d6261646765266c6f676f3d637368617270266c6f676f436f6c6f723d7768697465">
<img src="https://camo.githubusercontent.com/72ae6d80592b6f4af5f527002f7ddfd389b538a1a4b38115a1e263a1996cc487/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f756e69747920632532332d2532333233393132302e7376673f7374796c653d666f722d7468652d6261646765266c6f676f3d637368617270266c6f676f436f6c6f723d7768697465">
<img src="https://camo.githubusercontent.com/b1148630e3728ffb774987b47193e6f82887f7027b0f5844f541ccc5672a7ce3/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f756e6974792d2532333030303030302e7376673f7374796c653d666f722d7468652d6261646765266c6f676f3d756e697479266c6f676f436f6c6f723d7768697465">

## 적용 방법

> 주의! 서버와의 연결 테스트를 이 에셋의 내장된 스크립트를 통해서 하시는 것을 권장합니다. <br />
> 별도의 스크립트로 제작 하실 때 몇초 내에 너무 많은 서버로의 요청을 보낼 경우 서버로부터 차단 당할 수 있습니다.<br />
> 이 경우에는 어떠한 이유에도 불문하고 차단을 해제 하지 않으니 주의 해주시길 바랍니다.

1. Unity Package를 당신의 프로젝트에 임폴트 해주세요.
2. Asset > Project ALice > WorldAnalyzer.prefab 를 드래그 앤 드롭으로 씬에 추가해주세요.
3. Hierarchy에서 WorldAnalyzer 오브젝트를 선택 후 Inspector에 월드 코드를 입력해주세요.
4. 서버 연결 테스트 > 월드 연결 테스트 > Apply World Code 순으로 진행해주세요
5. 그대로 월드를 업로드 하셔도 됩니다. 테스트 하고 싶은 분은 아래의 가이드 라인을 따라주세요.

> 서버 연결 테스트 버튼을 누른후 1-3초간 기다리면 아래에 "Connected"라고 초록 글씨가 뜨면 정상입니다.<br />
> 월드 연결 테스트 버튼을 누른후 1-3초간 기다리면 아래에 "Connected"라고 초록 글씨가 뜨면 정상입니다.<br />
> Apply World Code 버튼을 누른후 아래의 스크립트의 Url 부분에 월드 코드 및 주소가 입력이 되면 정상입니다.

## 테스트

1. 위의 적용 방법을 따른 후 Unity 의 플레이 모드로 진입해 주세요.
2. 유니티의 플레이 모드 진입 후 Console에 "200 Connect Success" 를 발견하면 완료입니다.
3. https://worldmanager.mystialolelei.site/LogList 에 진입하여 해당 로그가 보인다면 정상입니다.

## 기능

1. 월드 코드에 따른 월드 방문자 방문 기록 저장 기능.
2. 런타임 중 플레이어 별 인스턴스 변수 저장 기능 (베타)

## 개발 스케줄

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
<td>코드 클리닝(For SRP)</td>
</tr>
<tr>
<td>2</td>
<td>2024-08-01</td>
<td>세이브 코드 기능 (베타)</td>
</tr>
<tr>
<td>3</td>
<td>2024-09-01</td>
<td>실시간 유저 수 통계 조회 기능</td>
</tr>
<tr>
<td>4</td>
<td>2024-10-01</td>
<td>전 인스턴스 다이렉트 메시지</td>
</tr>
<tr>
<td>5</td>
<td>2024-11-01</td>
<td>patreon 및 Fanbox 후원자 목록 자동 갱신 및 조회 기능</td>
</tr>
</tbody>
</table>

## 이용약관

이용약관은 https://worldmanager.mystialolelei.site/Rules 에 기반합니다.

## License

- [MIT License](LICENSE)
- [API_License](API_LICENSE)
