using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SubmitChannelName : MonoBehaviour
{
    public TMP_InputField input;

    public static string channelName;

    public void Submit()
    {
        channelName = input.text;
        Debug.Log("String: " + input.text);
    }
}
