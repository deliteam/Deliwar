using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchIntegration : MonoBehaviour
{
    private string _channelName;

    public void SetChannelName(string channelName)
    {
        _channelName = channelName;
        Debug.Log("Channel Name: " + _channelName);
    }
}
