using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System;
using Ultraio;
using TMPro;
//using BrainCloud;

public class UltraAuthSample: MonoBehaviour {
    public TextMeshProUGUI tokenText;

    // Install the Braincloud library first (cf README)
    // private BrainCloudWrapper _ultracloud;

    void Awake() 
    {
        Ultra.Init(OnInitSuccess, OnInitFailure);
    }

    void OnInitSuccess(string username, string idToken) 
    {
        Debug.Log($"{username} is now playing!");
        tokenText.text = "Welcome " + username;
        // SuccessCallback successCallback = (response, cbObject) => 
        // { 
        //     Debug.Log("UltraCloud Authentication was successful");
        // };    
        // FailureCallback failureCallback = (status, code, error, cbObject) => 
        // { 
        //     Debug.Log(string.Format("Failed | {0} {1} {2}", status, code, error)); 
        // };

        // var go = new GameObject();
        // _ultracloud = go.AddComponent<BrainCloudWrapper>();
        // _ultracloud.Init();
        // _ultracloud.AuthenticateUltra(username, idToken, true, successCallback, failureCallback);
        // DontDestroyOnLoad(go);
    }

    void OnInitFailure(UltraError error) 
    {
        tokenText.text = "Initialization failed " + error.Message;
    }
}