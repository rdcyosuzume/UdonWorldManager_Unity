## $${\color{yellow}Team \space Alice}$$

<div align="center"><img src="./Udon%20World%20Analyzer/Resources/PA_bnr.png" width="800px;" ></div>

## Language

- [한국어](readme_KR.md)
- [日本語](readme.md)
- [English](readme_EN.md)

## Project ALice Unity

This project is a tool derived from the Project Alice Udon World Manager.<br />
It is designed for use in VRC's Unity (UdonSharp) environment.<br />
It can be used in other Unity projects, but it is not recommended. (We are not responsible for any issues that may arise from this.)<br />
Support for general Unity projects may be expanded in the future. (Currently not supported.)

## Skills

<img src="https://camo.githubusercontent.com/40343d2dedbbcbf0d410e317854794ee6238e1c77ffb8513340ca7e2f79ef46d/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f55646f6e20632532332d2532333233393132302e7376673f7374796c653d666f722d7468652d6261646765266c6f676f3d637368617270266c6f676f436f6c6f723d7768697465">
<img src="https://camo.githubusercontent.com/72ae6d80592b6f4af5f527002f7ddfd389b538a1a4b38115a1e263a1996cc487/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f756e69747920632532332d2532333233393132302e7376673f7374796c653d666f722d7468652d6261646765266c6f676f3d637368617270266c6f676f436f6c6f723d7768697465">
<img src="https://camo.githubusercontent.com/b1148630e3728ffb774987b47193e6f82887f7027b0f5844f541ccc5672a7ce3/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f756e6974792d2532333030303030302e7376673f7374796c653d666f722d7468652d6261646765266c6f676f3d756e697479266c6f676f436f6c6f723d7768697465">

## Implementation Guide

> Warning! It is recommended to test the connection to the server using the built-in script of this asset.<br />
> If you create a separate script and send too many requests to the server in a short time, you may be blocked by the server.<br />
> In this case, the block will not be lifted under any circumstances, so please be careful.

1. Import the Unity Package into your project.
2. Drag and drop Asset > Project ALice > WorldAnalyzer.prefab into your scene.
3. Select the WorldAnalyzer object in the Hierarchy and enter the world code in the Inspector.
4. Follow the sequence of Server Connection Test > World Connection Test > Apply World Code.
5. You can upload the world as it is or follow the guidelines below to test it.

> After pressing the Server Connection Test button, wait 1-3 seconds. If you see "Connected" in green text below, it is normal.<br />
> After pressing the World Connection Test button, wait 1-3 seconds. If you see "Connected" in green text below, it is normal.<br />
> After pressing the Apply World Code button, if the world code and URL are entered in the script's URL section below, it is normal.

## Testing

1. Follow the above implementation guide and enter Unity's play mode.
2. If you see "200 Connect Success" in the Console after entering play mode, it is complete.
3. Go to https://worldmanager.mystialolelei.site/LogList and check if the log appears.

## Features

1. Stores visit records based on world code.
2. Saves instance variables per player during runtime (Beta).

## Development Schedule

<table>
<thead>
<tr>
<th>Idx</th>
<th>Date</th>
<th>Content</th>
</tr>
</thead>
<tbody>
<tr>
<td>1</td>
<td>2024-07-01</td>
<td>Code cleaning (For SRP)</td>
</tr>
<tr>
<td>2</td>
<td>2024-08-01</td>
<td>Save code function (Beta)</td>
</tr>
<tr>
<td>3</td>
<td>2024-09-01</td>
<td>Real-time user statistics</td>
</tr>
<tr>
<td>4</td>
<td>2024-10-01</td>
<td>Direct messaging across all instances</td>
</tr>
<tr>
<td>5</td>
<td>2024-11-01</td>
<td>Automatic update and viewing function for Patreon and Fanbox supporters</td>
</tr>
</tbody>
</table>

## Terms of Use

The terms of use are based on https://worldmanager.mystialolelei.site/Rules

## License

- [MIT License](LICENSE)
- [API_License](API_LICENSE)
