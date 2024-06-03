using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using System.Reflection;
using Unity.EditorCoroutines.Editor;
using VRC.SDKBase;

namespace TeamAlice.WorldAnalyzer
{
    [CustomEditor(typeof(ProjectAlice))]
    public class CustomInspector : Editor
    {
        private Texture2D banner;
        private Texture2D bannerJp;
        private Texture2D bannerEn;
        private string language = "English";
        private bool showLanguageOptions = false;
        private string connectionStatus = "disconnected";
        private string jsonResponse = "";
        [SerializeField] private string worldCode = "";
        [SerializeField] private WorldAnalyzer targetScript;

        private string headerText = "";
        private string introductionText = "";
        private string worldConnectionTestBtnText;
        private string serverConnectionTestBtnText;
        private string connectionStatusText;
        private string helpBoxFirst;
        private string helpBoxSecond;
        private string helpBoxThree;
        private string errorTitle;
        private string noWorldfoundTextFirst;
        private string noWorldfoundTextSecond;
        private string noWorldfoundTextThree;
        private string serverErrorTextFirst;
        private string serverErrorTextSecond;
        private string serverErrorTextThree;

        private void OnEnable()
        {
            bannerEn = Resources.Load<Texture2D>("PA_bnr");
            bannerJp = Resources.Load<Texture2D>("PA_bnr_jp");
            var data = EditorPrefs.GetString("AnExampleWindow", JsonUtility.ToJson(this, false));
            JsonUtility.FromJsonOverwrite(data, this);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            switch (language)
            {
                case "English":
                    headerText = "Welcome to Project ALice";
                    introductionText = "This script makes it easier to track visitor statistics in the world of the VRC.";
                    worldConnectionTestBtnText = "Check World Connection";
                    serverConnectionTestBtnText = "Check Connection";
                    connectionStatusText = "Connection Status";
                    helpBoxFirst = "Be sure to enter the World Code before pressing Apply World Code.";
                    helpBoxSecond = "It's a button to check if the world code you entered is correct.";
                    helpBoxThree = "A button to verify that the server is currently operational.";
                    errorTitle = "What can I do for it?";
                    noWorldfoundTextFirst = "The world code is undefined.";
                    noWorldfoundTextSecond = "Please check whether special characters or incorrectly entered in the world code box.";
                    noWorldfoundTextThree = "If the problem is not solved, I would appreciate it if you could contact me with the picture through Discord.";
                    serverErrorTextFirst = "I can't connect to the server at the moment.";
                    serverErrorTextSecond = "Please wait for TeamAlice's action or try again later.";
                    serverErrorTextThree = "Server-related issues can be found on the website.";
                    banner = bannerEn;
                    break;

                case "Korean":
                    headerText = "Project ALice에 오신 것을 환영합니다";
                    introductionText = "이 스크립트는 VRC 월드의 방문자 통계를 추적하기 쉽게 만들어줍니다.";
                    worldConnectionTestBtnText = "월드 연결 테스트";
                    serverConnectionTestBtnText = "서버 연결 테스트";
                    connectionStatusText = "연결 상태";
                    helpBoxFirst = "Apply World Code를 누르시기 전에 World Code를 반드시 입력해주세요.";
                    helpBoxSecond = "입력 하신 월드 코드가 맞는지 확인하는 버튼입니다.";
                    helpBoxThree = "서버가 현재 작동 중인지 확인하는 버튼입니다.";
                    errorTitle = "조치 사항";
                    noWorldfoundTextFirst = "월드 코드가 잘못되었습니다.";
                    noWorldfoundTextSecond = "월드 코드 입력란에 특수문자 혹은 잘못 입력이 되어있는지 확인해주세요.";
                    noWorldfoundTextThree = "문제가 해결되지 않으면 Discord를 통해 사진과 함께 문의해 주시면 감사하겠습니다.";
                    serverErrorTextFirst = "현재 서버와 연결이 되지 않습니다.";
                    serverErrorTextSecond = "TeamAlice의 조치를 기다리거나 나중에 다시 시도해주세요.";
                    serverErrorTextThree = "서버관련 문제는 홈페이지에서 확인 하실 수 있습니다.";
                    banner = bannerEn;
                    break;

                case "Japanese":
                    headerText = "Project ALiceへようこそ";
                    introductionText = "このスクリプトは、VRCのワールドの訪問者統計を追跡しやすくしてくれます。";
                    worldConnectionTestBtnText = "ワールド連結テスト";
                    serverConnectionTestBtnText = "サーバー連結テスト";
                    connectionStatusText = "連結状態";
                    helpBoxFirst = "Apply World Codeを押す前に、必ずWorld Codeを入力してください。";
                    helpBoxSecond = "入力されたワールドコードが正しいことを確認するボタンです。";
                    helpBoxThree = "サーバーが現在動作中であることを確認するボタンです。";
                    errorTitle = "措置事項";
                    noWorldfoundTextFirst = "ワールドコードが無効です。";
                    noWorldfoundTextSecond = "ワールドコード入力欄に特殊文字または間違って入力されていることを確認してください。";
                    noWorldfoundTextThree = "問題が解決されなければ、Discordを通じて写真と一緒にお問い合わせいただければ幸いです。";
                    serverErrorTextFirst = "現在、サーバーと接続できません。";
                    serverErrorTextSecond = "TeamAliceの処置を待つか、後でやり直してください。";
                    serverErrorTextThree = "サーバー関連の問題はホームページでご確認いただけます。";
                    banner = bannerJp;
                    break;
            }

            showLanguageOptions = EditorGUILayout.Foldout(showLanguageOptions, "Language Options");
            if (showLanguageOptions)
            {
                GUILayout.BeginHorizontal();
                if (GUILayout.Button("English"))
                {
                    language = "English";
                }
                if (GUILayout.Button("한국어"))
                {
                    language = "Korean";
                }
                if (GUILayout.Button("日本語"))
                {
                    language = "Japanese";
                }
                GUILayout.EndHorizontal();
            }

            GUILayout.Space(10);

            if (banner != null)
            {
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label(banner, GUILayout.Width(banner.width / 4), GUILayout.Height(banner.height / 4));
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }

            GUILayout.Space(10);

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label(headerText, EditorStyles.boldLabel);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.Space(5);

            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            GUILayout.Label(introductionText, EditorStyles.wordWrappedLabel);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            worldCode = EditorGUILayout.TextField("World Code:", worldCode);
            targetScript = (WorldAnalyzer)EditorGUILayout.ObjectField("Target Script", targetScript, typeof(WorldAnalyzer), true);

            GUILayout.Space(10);
            EditorGUILayout.HelpBox(helpBoxFirst, MessageType.Info);
            if (GUILayout.Button("Apply World Code"))
            {
                ApplyWorldCode();
            }

            GUILayout.Space(10);

            EditorGUI.BeginDisabledGroup(connectionStatus == "connecting...");
            EditorGUILayout.HelpBox(helpBoxSecond, MessageType.Info);
            if (GUILayout.Button(worldConnectionTestBtnText))
            {
                connectionStatus = "connecting...";
                ResetStatus();
                CheckWorldConnection(worldCode);
            }
            EditorGUILayout.HelpBox(helpBoxThree, MessageType.Info);
            if (GUILayout.Button(serverConnectionTestBtnText))
            {
                connectionStatus = "connecting...";
                ResetStatus();
                CheckConnection();
            }
            EditorGUI.EndDisabledGroup();

            GUILayout.BeginVertical("box");

            GUILayout.Label(connectionStatusText, EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            GUIStyle statusStyle = new GUIStyle(EditorStyles.label)
            {
                fontSize = 14,
                fontStyle = FontStyle.Bold,
                normal = { textColor = GetConnectionStatusColor(connectionStatus) }
            };

            GUILayout.Label(connectionStatus, statusStyle);
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            if (!string.IsNullOrEmpty(jsonResponse))
            {
                GUILayout.Label("JSON Response", EditorStyles.boldLabel);
                GUILayout.BeginHorizontal();
                GUILayout.FlexibleSpace();
                GUILayout.Label(jsonResponse, EditorStyles.wordWrappedLabel);
                GUILayout.FlexibleSpace();
                GUILayout.EndHorizontal();
            }

            GUILayout.Space(10);

            if (connectionStatus == "fail")
            {
                DrawSeparator(Color.white);
                GUILayout.Space(10);
                DisplayActionMessages();
                GUILayout.Space(10);
                DrawSeparator(Color.white);
            }

            GUILayout.EndVertical();

            GUILayout.Space(10);

            serializedObject.ApplyModifiedProperties();
            if (GUI.changed)
            {
                var data = JsonUtility.ToJson(this, false);
                EditorPrefs.SetString("AnExampleWindow", data);
            }
        }

        private Color GetConnectionStatusColor(string status)
        {
            switch (status)
            {
                case "success":
                    return Color.green;
                case "connecting...":
                    return new Color(1.0f, 0.64f, 0.0f);
                default:
                    return Color.red;
            }
        }

        private void CheckWorldConnection(string worldCode)
        {
            EditorCoroutineUtility.StartCoroutineOwnerless(EditorCoroutineCheckWorldConnection(worldCode));
        }

        private IEnumerator EditorCoroutineCheckWorldConnection(string worldCode)
        {
            string url = $"https://alice.mystialolelei.site/api/user?worldcode={worldCode}";
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();

                while (!request.isDone)
                {
                    yield return null;
                }

                if (request.result == UnityWebRequest.Result.Success)
                {
                    jsonResponse = request.downloadHandler.text;
                    Debug.Log("Response: " + jsonResponse);

                    MyData myData = JsonUtility.FromJson<MyData>(jsonResponse);
                    Debug.Log("Parsed Data: " + myData.result);
                    connectionStatus = myData.result;
                }
                else
                {
                    Debug.Log(request.result);
                    jsonResponse = request.downloadHandler.text;
                    Debug.Log("Response: " + jsonResponse);
                    MyData myData = JsonUtility.FromJson<MyData>(jsonResponse);
                    Debug.Log("Parsed Data: " + myData.result);
                    Debug.LogError("Error: " + request.error);
                    connectionStatus = myData.result;
                }
            }

            Repaint();
        }

        private void CheckConnection()
        {
            EditorCoroutineUtility.StartCoroutineOwnerless(EditorCoroutineCheckConnection());
        }

        private IEnumerator EditorCoroutineCheckConnection()
        {
            using (UnityWebRequest request = UnityWebRequest.Get("https://alice.mystialolelei.site/serverstatus"))
            {
                yield return request.SendWebRequest();

                while (!request.isDone)
                {
                    yield return null;
                }

                if (request.result == UnityWebRequest.Result.Success)
                {
                    jsonResponse = request.downloadHandler.text;
                    Debug.Log("Response: " + jsonResponse);

                    MyData myData = JsonUtility.FromJson<MyData>(jsonResponse);
                    Debug.Log("Parsed Data: " + myData.message);
                    connectionStatus = myData.result;
                }
                else
                {
                    Debug.LogError("Error: " + request.error);
                    connectionStatus = "failed";
                }
            }

            Repaint();
        }

        private void ResetStatus()
        {
            connectionStatus = "connecting...";
        }

        private void DisplayActionMessages()
        {
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();

            if (jsonResponse.Contains("No world found"))
            {
                GUILayout.Label(errorTitle, EditorStyles.boldLabel, GUILayout.ExpandWidth(true));
                GUILayout.Label(noWorldfoundTextFirst, EditorStyles.wordWrappedLabel, GUILayout.ExpandWidth(true));
                GUILayout.Label(noWorldfoundTextSecond, EditorStyles.wordWrappedLabel, GUILayout.ExpandWidth(true));
                GUILayout.Label(noWorldfoundTextThree, EditorStyles.wordWrappedLabel, GUILayout.ExpandWidth(true));

                if (GUILayout.Button("Open Website"))
                {
                    Process.Start("https://worldmanager.mystialolelei.site/ContactUs");
                }
            }
            else
            {
                GUILayout.Label(errorTitle, EditorStyles.boldLabel, GUILayout.ExpandWidth(true));
                GUILayout.Label(serverErrorTextFirst, EditorStyles.wordWrappedLabel, GUILayout.ExpandWidth(true));
                GUILayout.Label(serverErrorTextSecond, EditorStyles.wordWrappedLabel, GUILayout.ExpandWidth(true));
                GUILayout.Label(serverErrorTextThree, EditorStyles.wordWrappedLabel, GUILayout.ExpandWidth(true));

                if (GUILayout.Button("Open Website"))
                {
                    Process.Start("https://worldmanager.mystialolelei.site/ContactUs");
                }
            }

            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
        }

        private void DrawSeparator(Color color, float thickness = 1.0f, float padding = 10.0f)
        {
            Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(padding + thickness));
            rect.height = thickness;
            rect.y += padding / 2.0f;
            EditorGUI.DrawRect(rect, color);
        }

        private void ApplyWorldCode()
        {
            if (targetScript != null)
            {
                targetScript.url = new VRCUrl("https://alice.mystialolelei.site/api/user?worldcode=" + worldCode);
                EditorUtility.SetDirty(targetScript);
            }
            else
            {
                Debug.LogWarning("Target script is not assigned.");
            }
        }
    }

    [System.Serializable]
    public class MyData
    {
        public string result;
        public string message;
    }

    internal static class UdonSharpBehaviourExtensions
    {
        internal static object GetPublicVariable(this WorldAnalyzer self, string symbolName)
        {
            return null;
        }

        internal static void SetPublicVariable<T>(this WorldAnalyzer self, string symbolName, T value)
        {
            var field = self.GetType().GetField(symbolName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(self, value);
        }
    }
}
