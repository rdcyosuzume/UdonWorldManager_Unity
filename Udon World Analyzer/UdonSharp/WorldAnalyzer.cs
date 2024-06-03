using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon.Common.Interfaces;
using VRC.SDK3.StringLoading;
using VRC.SDK3.Data;
using UnityEngine.UI;
using VRC.SDK3.Components;
namespace TeamAlice.WorldAnalyzer
{
    public class WorldAnalyzer : UdonSharpBehaviour
    {

        [Header("Auto Login URl DonotChange")]
        public VRCUrl url;

        [Header("Server Configuration (For Beta Tester)--------------------------")]
        [Space(10)]  // Adds space between groups

        [Header("サーバーURL入力UI")]
        public VRCUrlInputField urlinput;
        [Header("サーバーステータスUI")]
        public Text resultvalue;
        [Header("サーバーメッセージUI")]
        public Text resultmessage;
        [Header("URL入力を作成UI")]
        public InputField requestvalue;
        [Header("Local ステイタス表示 TEXT")]
        public Text status;
        [Header("worldCode Setting")]
        public string worldCode;
        private string serverstatus;
        private string saveCode = "";

        void Start()
        {
            CheckServerStatus();
        }

        /**
        * @event: Start()
        * @description: Check Server Status
        * @param: none
        * @returnType: Json
        * @return: Result{string}
        * @return: Status{string}
        */
        public void CheckServerStatus()
        {
            VRCStringDownloader.LoadUrl(url, (IUdonEventReceiver)this);
        }
        /**
         * @description: String Load Success Receive Event. 
         */
        public override void OnStringLoadSuccess(IVRCStringDownload json)
        {
            if (VRCJson.TryDeserializeFromJson(json.Result, out DataToken result))
            {
                // Deserialization succeeded! Let's figure out what we've got.
                if (result.TokenType == TokenType.DataDictionary)
                {
                    Debug.Log($"Successfully deserialized as a dictionary with {result.DataDictionary.Count} items.");
                }
                else if (result.TokenType == TokenType.DataList)
                {
                    Debug.Log($"Successfully deserialized as a list with {result.DataList.Count} items.");
                }
                else
                {
                    // This should not be possible. If DeserializeFromJson returns true, this it *must* be either a dictionary or a list.
                    serverstatus = "fail";
                    Debug.Log($"Failed to Deserialize json {json} - {result.ToString()}");
                    resultvalue.text = "DataFormat is Wrong";
                    resultmessage.text = "Check URL";
                }
            }
            else
            {
                // Deserialization failed. Let's see what the error was.
                Debug.LogError($"Failed to Deserialize json {json} - {result.ToString()}");
            }
            result.DataDictionary.TryGetValue("result", out DataToken value);
            serverstatus = value.ToString();
            if (serverstatus == "success")
            {
                Debug.Log("status Code : 200 Access Successfull!");
                result.DataDictionary.TryGetValue("message", out DataToken message);
                resultmessage.text = message.ToString();
            }else 
            {
                result.DataDictionary.TryGetValue("message", out DataToken message);
                if (message.ToString().Contains("failed"))
                {
                    resultmessage.text = serverstatus;
                    resultvalue.text = message.ToString();
                    Debug.Log("500Error です. サーバー側の問題です。ヨスズメにお問い合わせください。https://alicemanager.mystialolelei.site/Contact");
                    Debug.Log("message :" + message);
                    Debug.Log("Request URL :" + requestvalue.text);
                    Debug.Log("Json:" + json.Result);
                }
                else
                {
                    resultmessage.text = serverstatus;
                    resultvalue.text = message.ToString();
                    Debug.Log("400Error です。送ったデータが間違っています。API の確認をお願いします。https://alicemanager.mystialolelei.site/Documents");
                    Debug.Log("Request URL :" + requestvalue.text);
                    Debug.Log("Json:" + json.Result);
                }
            }
        }
    }
}
