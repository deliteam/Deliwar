using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lexone.UnityTwitchChat;
using DigitalRuby.RainMaker;

public class TwitchIntegration : MonoBehaviour
{
    private GameObject targetObj;

    private string _channelName;

    BaseRainScript rainScript;

    // Start is called before the first frame update
    void Start()
    {
        if (string.IsNullOrEmpty(SubmitChannelName.channelName)) 
        { 
            Debug.LogWarning("bos"); 
        }

        IRC.Instance.channel = SubmitChannelName.channelName;
        IRC.Instance.OnChatMessage += OnChatMessage;
        targetObj = GameObject.Find("RainPrefab2D");
        rainScript = targetObj.GetComponent<BaseRainScript>();
    }

    private void OnChatMessage(Chatter chatter) {
        Debug.Log($"<color=#fef83e><b>[CHAT LISTENER]</b></color> New chat message from {chatter.tags.displayName}: {chatter.message}");

        string input = chatter.message;

        if (input == "!rain") {
            rainScript.RainIntensity = (rainScript.RainIntensity == 0.0f ? 1.0f : 0.0f);
            rainScript.EnableWind = !rainScript.EnableWind;
        }
    }
}
