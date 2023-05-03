using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public GameObject allDoneText;
    public GameObject notFinishedText;

    private void Update()
    {
        if (DeliveryIndicator.GlobalDeliveryCount == 16)
        {
            allDoneText.SetActive(true);
            notFinishedText.SetActive(false);
        }
        else
        {
            allDoneText.SetActive(false);
            notFinishedText.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (DeliveryIndicator.GlobalDeliveryCount == 16)
        {
            SceneManager.LoadScene("Menu_GameVictory");
        }
    }
}
